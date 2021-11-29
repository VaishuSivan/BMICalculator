using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace BMI.Models
{
    public class BMIModel
    {
        
        [Range(2, 100, ErrorMessage = "Age must be between 2 to 100 ")]
        public double Age { get; set; }
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public string Unit { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Enter value greater than 0")]
        public double Height { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Enter value greater than 0")]
        public double Weight { get; set; }
        public GenderModel gendermodel { get; set; }
        

    }
}