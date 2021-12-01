using appdev.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appdev.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUser _user;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        public AdminController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagerView()
        {
            var displayManager = _context.Users.Where(t => t.Roles.Any(m => m.RoleId == "2")).ToList();
            return View(displayManager);
        }
        public ActionResult UserView()
        {
            var displayUser = _context.Users.Where(t => t.Roles.Any(m => m.RoleId == "3")).ToList();
            return View(displayUser);
        }
        public ActionResult Delete(string id)
        {
            var removeUser = _context.Users.SingleOrDefault(t => t.Id == id);
            _context.Users.Remove(removeUser);
            _context.SaveChanges();
            return RedirectToAction("ManagerView");
        }
    }
}