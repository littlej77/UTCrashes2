using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using UTCrash2.Models;


namespace aspnetcore.Controllers
{ 
    public class InferenceController : Controller
    {
        private InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }

        [HttpGet]
        public IActionResult EnterData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Score(Crash c)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", c.AsTensor())
            });
            //Tensor<float> score = result.First().AsTensor<float>();
            Tensor<int> score = result.First().AsTensor<int>();
            var prediction = new Crash { CRASH_SEVERITY_ID = (int)score.First() };
            result.Dispose();
            return View("CalculatorResults", prediction);
        }
    }
}