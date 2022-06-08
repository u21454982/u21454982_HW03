using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21454982_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string rbSelection)
        {

            if (files != null && files.ContentLength > 0)
            {
                var filename = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/document"), filename);

                if (rbSelection == "docum")
                {
                     path = Path.Combine(Server.MapPath("~/App_Data/document"), filename);
                }
               else if (rbSelection == "image")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/images"), filename);
                }
                else  if (rbSelection == "video")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/videos"), filename);
                }
                files.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
    }
}