using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BMI.Models
{
    [Table("DietPlanTable")]
    public class DietPlanModel
    {
        [Key]
        public int ID { get; set; }
        public string EarlyMorning { get; set; }
        public string Breakfast { get; set; }
        public string MidMorning { get; set; }
        public string Lunch { get; set; }
        public string Evening { get; set; }
        public string MidEvening { get; set; }
        public string Dinner { get; set; }
        public string PostDinner { get; set; }

        public string Workouts { get; set; }
       // public IQueryable dietDetails { get; set; }
    }
}