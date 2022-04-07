using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UTCrash2.Models
{
    //this is our model for the counties table that we have in our database
    public class County 
    {
        [Key]
        [Required]
        public int COUNTY_ID { get; set; }
        public string COUNTY_NAME { get; set; }
    }
}
