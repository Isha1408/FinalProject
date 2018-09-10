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
            using (SchoolDBEntities2 db = new SchoolDBEntities2())
            {
                return View(db.User.ToList());
            }
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                using (SchoolDBEntities2 db = new SchoolDBEntities2())
                {
                    db.User.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + "" + user.LastName + "" + user.EmailId + "" + user.Gender + "" + user.Password +""+user.ConfirmPassword+ "" + user.Roles + "" + user.UserId + "" + user.UserName + "" + user.Courses + "Succesfully Registered.";

            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {

            using (SchoolDBEntities2 db = new SchoolDBEntities2())
            {
                var userDetails = db.User.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                //Code to Authenticate Identity Of user.
                if (userDetails != null)
                {
                    if (userDetails.Roles == "Admin")
                        return RedirectToAction("Index","Admin");
                    else if (userDetails.Roles == "Student")
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

        public ActionResult LogOut()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Student()
        {
            return View();
        }

    }
}

   