using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTCrash2.Models
{
    public class EFCrashesRepository : ICrashesRepository
    {
        private CrashesDbContext _context { get; set; }
        public EFCrashesRepository(CrashesDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Crash> crashes => _context.crashes;
        public IQueryable<County> Counties => _context.Counties;

        public void AddCrash(Crash c) //this allows us to add crashes to our database
        {
            _context.Add(c);
            _context.SaveChanges();
        }

        public void EditCrash(Crash c) //this allows us to edit crashes in our datbase and then save them
        {
            _context.Update(c);
            _context.SaveChanges();
        }

        public void DeleteCrash(Crash c) // this allows us to delete a crash entry from our database
        {
            _context.Remove(c);
            _context.SaveChanges();
        }

    }
}
