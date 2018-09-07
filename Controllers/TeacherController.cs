using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        private SchoolDBEntities1 db = new SchoolDBEntities1();
    
       public ActionResult Index()
        {
            var returnedResult =db.user.Where(x=>x.Roles=="Student").ToList();
            return View(returnedResult);

          
        }
                
        

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            using (SchoolDBEntities1 db = new SchoolDBEntities1())
            {
                var dataById = db.user.Single(x => x.UserId == id);
                return View(dataById);
            }
        }
      
    }
}