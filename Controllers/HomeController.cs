using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UTCrash2.Models;
using UTCrash2.Models.ViewModels;

namespace UTCrash2.Controllers
{
    public class HomeController : Controller
    {
        private ICrashesRepository _repo { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICrashesRepository temp) // constructor
        {
            _logger = logger;
            _repo = temp;
        }

        [HttpPost("cspreport")]
        public IActionResult CSPReport([FromBody] CspReportRequest cspReportRequest) // builds content security policy header
        {
            _logger.LogInformation(@$"CSP Violation: {cspReportRequest.CspReport.DocumentUri},         {cspReportRequest.CspReport.BlockedUri}"); return Ok();
        }

        public IActionResult Index() // landing page
        {
            return View();
        }

        public IActionResult AllCrashes(string county, int pageNum = 1) // displays all crashes
        {
            int pageSize = 30; // display 30 crashes per page

            ViewBag.Counties = _repo.Counties.OrderBy(x => x.COUNTY_NAME).ToList(); // pass in all the county names

            var x = new CrashesViewModel
            {
                crashes = _repo.crashes
                .Where(x => x.COUNTY.COUNTY_NAME == county || county == null) // grab all the crashes where county_name matches the one selected from county vc
                .OrderBy(x => x.CRASH_ID)
                .Skip((pageNum - 1) * pageSize) // skip all the previous records
                .Take(pageSize),

                // determine which page and crashes to display on page
                PageInfo = new PageInfo
                {
                    TotalNumCrashes =
                        (county == null
                            ? _repo.crashes.Count()
                            : _repo.crashes.Where(x => x.COUNTY.COUNTY_NAME == county).Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        public IActionResult ViewCrashes(string county, int pageNum = 1) //this page is for non-logged in users
        {
            int pageSize = 30; // display 30 crashes per page

            ViewBag.Counties = _repo.Counties.OrderBy(x => x.COUNTY_NAME).ToList(); // pass in all the county names

            var x = new CrashesViewModel
            {
                crashes = _repo.crashes
                .Where(x => x.COUNTY.COUNTY_NAME == county || county == null) // grab all the crashes where county_name matches the one selected from county vc
                .OrderBy(x => x.CRASH_ID)
                .Skip((pageNum - 1) * pageSize) // skip all the previous records
                .Take(pageSize),

                // determine which page and crashes to display on page
                PageInfo = new PageInfo
                {
                    TotalNumCrashes =
                        (county == null
                            ? _repo.crashes.Count()
                            : _repo.crashes.Where(x => x.COUNTY.COUNTY_NAME == county).Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        [Authorize(Roles = "Administrator")] //limits the access to Adding crash to users who are logged in with Administrative roles.
        [HttpGet]
        public IActionResult AddCrash()
        {
            Crash crash = new Crash(); // create a new crash

            ViewBag.crashes = _repo.crashes.ToList(); // pass in all current crashes
            ViewBag.Counties = _repo.Counties.ToList(); // pass in all counties

            return View("EditCrash", crash);
        }

        [Authorize(Roles = "Administrator")] //limits the access to Adding crash to users who are logged in with Administrative roles.
        [HttpPost]
        public IActionResult AddCrash(Crash c)
        {
            if (ModelState.IsValid) // check if data validation is met
            {
                c.CRASH_ID = (_repo.crashes.Max(c => c.CRASH_ID)) + 1; // increment crashid for a new record
                _repo.AddCrash(c);
                return RedirectToAction("AllCrashes"); // return to all crashes page
            }
            else
            {
                ViewBag.crashes = _repo.crashes.ToList(); // pass in all current crashes
                ViewBag.Counties = _repo.Counties.ToList(); // pass in all counties
                return View(c);
            }
        }

        [HttpGet]
        public IActionResult EditCrash(int crashid)
        {
            ViewBag.Counties = _repo.Counties.ToList(); // pass in all counties

            var crash = _repo.crashes.Single(x => x.CRASH_ID == crashid); // grab the crash of the particular crashid that's passed in

            return View("EditCrash", crash);
        }

        [HttpPost]
        public IActionResult EditCrash(Crash c)
        {
            _repo.EditCrash(c);
            return RedirectToAction("AllCrashes"); // return to all crashes page
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteCrash(int crashid)
        {
            var crash = _repo.crashes.Single(x => x.CRASH_ID == crashid);
            _repo.DeleteCrash(crash);
            return RedirectToAction("AllCrashes"); // return to all crashes page
        }


        public IActionResult CrashMaps() // displays map page
        {
            return View();
        }

        public IActionResult CrashCalc() // displays calculator page
        {
            return View();
        }

        public IActionResult Solutions() // displays solutions page
        {
            return View();
        }

        public IActionResult Privacy() // displays privacy policy page
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
