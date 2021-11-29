using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BMI.Models
{
    public class BMIContext :DbContext
    {
        public BMIContext():base("BmiDBConnectionString")
        {

        }
        public DbSet<DietPlanModel> planTables { get; set; }
    }
}