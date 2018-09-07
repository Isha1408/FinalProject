using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (SchoolDBEntities1 db = new SchoolDBEntities1())
            {
                return View(db.user.ToList());
            }
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            if(ModelState.IsValid)
            {
                using (SchoolDBEntities1 db = new SchoolDBEntities1()) 
                {
                    db.user.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + "" + user.LastName + "" +user.EmailId+ ""+user.Gender+ "" +user.Password+ "" +user.ConfirmPassword+ ""+user.Roles+ "" +user.UserId+ "" +user.UserName+ "Succesfully Registered.";

            }
            return View("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {

            using (SchoolDBEntities1 db = new SchoolDBEntities1())
            {
                var userDetails = db.user.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                //Code to Authenticate Identity Of user.

                if (userDetails != null)
                {
                    if (userDetails.Roles == "Admin")
                        return RedirectToAction("Index","Admin");
                    else if(userDetails.Roles == "Student")
                        return RedirectToAction("Student");
                    else if (userDetails.Roles == "Teacher")
                        return RedirectToAction("Index","Teacher");

                    Session["UserId"] = userDetails.UserId.ToString();
                    Session["UserName"] = userDetails.UserName.ToString();

                    //return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is wrong");

                }

            }
            return View();
            

        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //public ActionResult Admin()
        //{
        //    using (SchoolDBEntities1 db = new SchoolDBEntities1())
        //    {
        //        return View(db.Users.ToList());
        //    }
         
        //}
        public ActionResult Student()
        {
            return View();
        }
        //public ActionResult Teacher()
        //{
        //    using (SchoolDBEntities1 db = new SchoolDBEntities1())
        //    {
        //        return View(db.user.ToList());
        //    }
        //}
    }
}
   