using BMI.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BMI.Controllers
{
    public class HomeController : Controller
    {
        BMIContext db = new BMIContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CalculateBMI()
        {
            var gmodel = new GenderModel();
            ViewBag.GenderTypes = gmodel.GenderTypesList;
            return View();
        }
        [HttpPost]
        public ActionResult CalculateBMI(BMIModel models)
        {
           
            return RedirectToAction("Result");

        }



        [HttpPost]
        public ActionResult Result()
        {
            double bmi = 0.0;
            DietPlanModel dietDetails = new DietPlanModel();
            double Weight = Convert.ToDouble(Request.Form["Weight"]);
            double Height = Convert.ToDouble(Request.Form["Height"]);
            string Unit = Request.Form["Unit"];
            int id;

            if (Unit == "Metric")
            {

                bmi = (Weight / (Height * Height)) * 10000;
            }
            else
            {

                bmi = 703.0 * Weight / (Height * Height);
            }
            ViewBag.Result = "Your BMI is " + (Math.Round(bmi));
            if (bmi > 30.0)
            {
                ViewBag.Res = "Obese";
            }

            else if (bmi >= 25.0 && bmi <= 30.0)
            {
                ViewBag.Res = "Overweight ";


            }
            else if (bmi >= 18.5 && bmi <= 24.9)
            {
                ViewBag.Res = "Normal Weight";
                ViewBag.option = "Your Weight seems to be normal.If you want you can follow the below workout plan to maintain your Wight";
            }
            else
            {
                ViewBag.Res = "Underweight";


            }
            if (bmi > 30.0 || (bmi >= 25.0 && bmi <= 30.0))
            {
                id = 1;
            }
            else
            {
                id = 2;
            }
            dietDetails = db.planTables.Find(id);
            return View(dietDetails);
        }

        [ValidateInput(false)]
        public FileResult Export(string ExportData)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {

                StringReader reader = new StringReader(ExportData);
                Document PdfFile = new Document(PageSize.A4, 2, 2, 20, 20);
                PdfWriter writer = PdfWriter.GetInstance(PdfFile, stream);
                PdfFile.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfFile, reader);
                PdfFile.Close();
                return File(stream.ToArray(), "application/pdf", "ExportData.pdf");
            }
        }
        ShopContext shopdb = new ShopContext();
        static decimal newsum;
        static List<ShopModel> detailList = new List<ShopModel>();

        public ActionResult Shop()
        {
            return View(shopdb.shopTables.ToList());
        }

        public ActionResult ADD(int id)
        {

            ShopModel detail = shopdb.shopTables.Find(id);
            ShopModel mod = new ShopModel();
            detailList.Add(detail);
            decimal price = detail.Price;
            newsum = newsum + price;
            ViewBag.msg = "Your item is added to cart.";
            ViewBag.Sum = "Your Total is " + newsum;
            return View(detailList);
        }

        public ActionResult PlaceOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PlaceOrder(PlaceOrder order)
        {
            string email = Request.Form["Email"];
            ViewData["msg"] = "Your order details,payment options and delivery details will be sent to " + email;
            return View();
        }
        
       
    }
}