using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTCrash2.Models
{
    public class CalculatorData
    {
        //public int InsuranceId { get; set; }
       public float MONTH { get; set; }
       public float CRASH_SEVERITY_ID { get; set; }
       public float COUNTY_NAME_GARFIELD { get; set; }
       public float COUNTY_NAME_SALT_LAKE { get; set; }
       public float CITY_AMERICAN_FORK { get; set; }
        public float CITY_HIGHLAND { get; set; }
        public float CITY_LAYTON { get; set; }
        public float CITY_OGDEN { get; set; }
        public float CITY_OUTSIDE_CITY_LIMITS { get; set; }
        public float CITY_PROVO { get; set; }
        public float CITY_ROY { get; set; }
        public float CITY_SALT_LAKE_CITY { get; set; }
        public float CITY_SOUTH_SALT_LAKE { get; set; }
        public float CITY_WEST_JORDAN { get; set; }
        public float CITY_WEST_VALLEY_CITY { get; set; }
        public float PEDESTRIAN_INVOLVED_TRUE { get; set; }
        public float BICYCLIST_INVOLVED_TRUE { get; set; }
        public float MOTORCYCLE_INVOLVED_TRUE { get; set; }
        public float IMPROPER_RESTRAINT_TRUE { get; set; }
        public float DUI_TRUE { get; set; }
        public float INTERSECTION_RELATED_TRUE { get; set; }
        public float WILD_ANIMAL_RELATED_TRUE { get; set; }
        public float OVERTURN_ROLLOVER_TRUE { get; set; }
        public float COMMERCIAL_MOTOR_VEH_INVOLVED_TRUE { get; set; }
        public float OLDER_DRIVER_INVOLVED_TRUE { get; set; }
        public float SINGLE_VEHICLE_TRUE { get; set; }
        public float DISTRACTED_DRIVING_TRUE { get; set; }
        public float DROWSY_DRIVING_TRUE { get; set; }
        public float ROADWAY_DEPARTURE_TRUE { get; set; }
        
        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                MONTH,CRASH_SEVERITY_ID, COUNTY_NAME_GARFIELD,COUNTY_NAME_SALT_LAKE,CITY_AMERICAN_FORK,CITY_HIGHLAND,CITY_LAYTON,CITY_OGDEN,CITY_OUTSIDE_CITY_LIMITS,CITY_PROVO,CITY_ROY,CITY_SALT_LAKE_CITY,CITY_SOUTH_SALT_LAKE,CITY_WEST_JORDAN,CITY_WEST_VALLEY_CITY,PEDESTRIAN_INVOLVED_TRUE,BICYCLIST_INVOLVED_TRUE,MOTORCYCLE_INVOLVED_TRUE,IMPROPER_RESTRAINT_TRUE,DUI_TRUE,INTERSECTION_RELATED_TRUE,WILD_ANIMAL_RELATED_TRUE,OVERTURN_ROLLOVER_TRUE,COMMERCIAL_MOTOR_VEH_INVOLVED_TRUE,OLDER_DRIVER_INVOLVED_TRUE,SINGLE_VEHICLE_TRUE,DISTRACTED_DRIVING_TRUE,DROWSY_DRIVING_TRUE,ROADWAY_DEPARTURE_TRUE
            };
            //Should be 29 temporarily going to 22
            int[] dimensions = new int[] { 1, 29 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
