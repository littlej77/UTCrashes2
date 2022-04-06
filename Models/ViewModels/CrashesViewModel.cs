using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTCrash2.Models.ViewModels
{
    public class CrashesViewModel
    {
        public IQueryable<Crash> crashes { get; set; }
        public IQueryable<County> Counties { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
