using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {
        private SchoolDBEntities2 db = new SchoolDBEntities2();

        // GET: Student
        public ActionResult Index()
        {
            
            User user = (User)Session["User"];
            var usr = db.User.Find(user.UserId);
            if (Session["User"] != null)
            {
                var userDetails = db.User.Where(u => u.UserId == user.UserId);
                if (usr != null)
                    return View(userDetails);
            }
            return View(usr);
        }
    
        //public ActionResult MyProfile(int? id)
        //{
        //    //var dataById = db.User.Where(x => x.UserId == id);
        //    //return View(dataById);
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.User.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}
        public ActionResult Edit(int id)
        {
            var dataById = db.User.Single(x => x.UserId == id);
            return View(dataById);
        }

        // POST: Edit/
        [HttpPost]
        public ActionResult Edit(int id, User collection)
        {
            try
            {
                // TODO: Add update logic here

                User user = db.User.Single(x => x.UserId == id);

                user.FirstName = collection.FirstName;
                user.LastName = collection.LastName;
                user.Gender = collection.Gender;
                user.UserName = collection.UserName;
                user.Password = collection.Password;
                user.ConfirmPassword = collection.ConfirmPassword;
                user.EmailId = collection.EmailId;
                user.Roles = collection.Roles;
                user.RoleId = collection.RoleId;
                user.Courses = collection.Courses;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Add()
        {
            return RedirectToAction("Add", "Image");
        }
    }
}