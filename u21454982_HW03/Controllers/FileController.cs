using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using u21454982_HW03.Models;

namespace u21454982_HW03.Controllers
{
    public class FileController : Controller
    {

        [HttpGet]
        public ActionResult Index()  
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/App_Data/document"));
            List<FileModel> files = new List<FileModel>();
            foreach(string filePath in filepaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files) 
        {

            if (files != null && files.ContentLength > 0)
            {

                var fileName = Path.GetFileName(files.FileName);


                var path = Path.Combine(Server.MapPath("~/App_Data/document"), fileName);


                files.SaveAs(path);
            }
            

            return RedirectToAction("Index");
        }
    }
}

