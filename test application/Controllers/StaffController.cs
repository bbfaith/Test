using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using test_application.Models;
using System.IO;

namespace test_application.Controllers
{
    public class StaffController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View(new List<StaffModels>());
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<StaffModels> staff = new List<StaffModels>();
            string filePath = string.Empty;

            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (row.Contains('"'))
                        {
                            staff.Add(new StaffModels
                            {
                                Lastname = row.Split(',')[0].Substring(1),
                                Firstname = row.Split(',')[1]
                            });
                        }
                        else {
                            staff.Add(new StaffModels
                            {
                                Type = row.Split(',')[0],
                                Hour = Convert.ToDouble(row.Split(',')[1])
                            });
                        }
                    }
                }
            }
            return View(staff);
        }
    }
}

