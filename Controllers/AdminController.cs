using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        private SchoolDBEntities1 db = new SchoolDBEntities1();
        // GET: Admin
        public ActionResult Index()
        {
                return View(db.user.ToList());                    
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var dataById = db.user.Single(x => x.UserId == id);
            return View(dataById);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }
          
            // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(User collection)
        {
        try
        {
            // TODO: Add insert logic here

            db.user.Add(collection);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

        // GET: Admin/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            var dataById = db.user.Single(x => x.UserId == id);
            return View(dataById);
            
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,User collection)
        {
            try
            {
                // TODO: Add delete logic here
                var data = db.user.Single(x => x.UserId == id);
                db.user.Remove(data);
                db.SaveChanges();

                return RedirectToAction("Index");

               
            }
            catch
            {
                return View();
            }
        }
    }
}
