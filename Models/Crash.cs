﻿using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UTCrash2.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public double CRASH_ID { get; set; }
        public double ROUTE { get; set; }
        public double MILEPOINT { get; set; }

        [MaxLength(100)]
        public string MAIN_ROAD_NAME { get; set; }

        [MaxLength(100)]
        public string CITY { get; set; }

        [Required]
        public int COUNTY_ID { get; set; }
        [ForeignKey("COUNTY_ID")]
        public County COUNTY { get; set; }

        [Required]
        public int CRASH_SEVERITY_ID { get; set; }

        internal Tensor<object> AsTensor()
        {
            throw new NotImplementedException();
        }

        public int WORK_ZONE_RELATED { get; set; }
        public int PEDESTRIAN_INVOLVED { get; set; }
        public int BICYCLIST_INVOLVED { get; set; }
        public int MOTORCYCLE_INVOLVED { get; set; }
        public int IMPROPER_RESTRAINT { get; set; }
        public int UNRESTRAINED { get; set; }
        public int DUI { get; set; }
        public int INTERSECTION_RELATED { get; set; }
        public int WILD_ANIMAL_RELATED { get; set; }
        public int DOMESTIC_ANIMAL_RELATED { get; set; }
        public int OVERTURN_ROLLOVER { get; set; }
        public int COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        public int TEENAGE_DRIVER_INVOLVED { get; set; }

        public int OLDER_DRIVER_INVOLVED { get; set; }
        public int NIGHT_DARK_CONDITION { get; set; }
        public int SINGLE_VEHICLE { get; set; }
        public int DISTRACTED_DRIVING { get; set; }
        public int DROWSY_DRIVING { get; set; }
        public int ROADWAY_DEPARTURE { get; set; }

        [MaxLength(100)]
        public string Dates { get; set; }
        [MaxLength(100)]
        public string Times { get; set; }
        public int Days { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public int Hours { get; set; }
        public int Mins { get; set; }

        public Tensor<int> AsTensor()
        {
            int[] data = new int[]
            {
                //IDK if this is in the right space, these also have different names as the ones in here.
                Months, CITY, COUNTY_ID, CRASH_SEVERITY_ID, WORK_ZONE_RELATED, PEDESTRIAN_INVOLVED, BICYCLIST_INVOLVED, 
                MOTORCYCLE_INVOLVED, COMMERCIAL_MOTOR_VEH_INVOLVED, TEENAGE_DRIVER_INVOLVED, IMPROPER_RESTRAINT, UNRESTRAINED,
                DUI, INTERSECTION_RELATED, WILD_ANIMAL_RELATED, DOMESTIC_ANIMAL_RELATED, OVERTURN_ROLLOVER, NIGHT_DARK_CONDITION,
                OLDER_DRIVER_INVOLVED, SINGLE_VEHICLE, DISTRACTED_DRIVING, DROWSY_DRIVING, ROADWAY_DEPARTURE
            };
            int[] dimensions = new int[] { 1, 29 };
            return new DenseTensor<int>(data, dimensions);
        }
    }
}
