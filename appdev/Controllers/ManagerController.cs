using appdev.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appdev.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationUser _user;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        public ManagerController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TeamManagement()
        {
            var team = _context.Teams.ToList();
            return View(team);
        }
        public ActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            var create_team = new Team() { TeamName = team.TeamName };
            _context.Teams.Add(create_team);
            _context.SaveChanges();
            return RedirectToAction("TeamManagement");
        }
        public ActionResult DeleteTeam(int id)
        {
            var removeTeam = _context.Teams.SingleOrDefault(t => t.Id == id);
            _context.Teams.Remove(removeTeam);
            _context.SaveChanges();
            return RedirectToAction("TeamManagement");
        }
        public ActionResult EditTeam(int id)
        {
            var findTeam = _context.Teams.SingleOrDefault(t => t.Id == id);
            var cTeam = new Team()
            {
                Id = id,
                TeamName = findTeam.TeamName
            };
            return View(cTeam);
        }
        [HttpPost]
        public ActionResult EditTeam(Team viewModel)
        {
            var team = _context.Teams.SingleOrDefault(t => t.Id == viewModel.Id);
            team.TeamName = viewModel.TeamName;
            _context.SaveChanges();
            return RedirectToAction("TeamManagement", "Manager");
        }
    }
}