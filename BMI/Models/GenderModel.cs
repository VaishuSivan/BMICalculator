using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMI.Models
{
    public class GenderModel
    {
       
        public IEnumerable<SelectListItem> GenderTypesList
        {
            get
            {
                return new List<SelectListItem>()
                     {
                       new SelectListItem { Text = "Male", Value = "Male" },
                        new SelectListItem { Text = "Female", Value = "Female" }

                     };
            }
            set
            {

            }
        }
       
    }
}