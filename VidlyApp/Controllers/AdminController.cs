using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApp.Models;

namespace VidlyApp.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        private readonly VidlyAppContext _app = new VidlyAppContext();
        // GET: Admin
        public ActionResult Index()
        {
            var customers = _app.Customers.ToList();
            return View(customers);
        }

        //Adding A New Role
       
        // GET: Role
        public ActionResult RoleList()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole identity)
        {

            _db.Roles.Add(identity);
            _db.SaveChanges();
            RedirectToAction("RoleList");

            return View();
        }


    }
}
