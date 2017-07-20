using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_application.Models;
using System.Diagnostics;

namespace test_application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            List<StaffModels> model = new List<StaffModels>();

            return View(model);
        }
        [HttpPost]
        public ActionResult About(HttpPostedFileBase postedFile)
        {
            List<string> rows = new List<string>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(postedFile.InputStream))
            {
                while (!reader.EndOfStream)
                {
                    rows.Add(reader.ReadLine());
                }
            }
            foreach(var row in rows)
            {
                Debug.WriteLine(row);
            }
            return RedirectToAction("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}