using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image obj)
        {
            string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
            string extension = Path.GetExtension(obj.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            obj.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            obj.ImageFile.SaveAs(fileName);
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                db.Images.Add(obj);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("View");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            Image obj = new Image();
            using (SchoolDBEntities db = new SchoolDBEntities())
            {
                obj = db.Images.Where(x => x.ImageID == id).FirstOrDefault();
            }
            return View(obj);
        }
    }
}
   