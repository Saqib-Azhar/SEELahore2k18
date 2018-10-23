using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEELahore2k18.Models;

namespace SEELahore2k18.Controllers
{
    public class HomeController : Controller
    {
        private SEELahoreEntities db = new SEELahoreEntities();
        public ActionResult Index()
        {
            ViewBag.Guests = db.Guests.ToList();
            ViewBag.SEELahoreTeams = db.SEELahoreTeams.ToList();
            ViewBag.EventSegments = db.EventSegments.ToList();
            ViewBag.Announcements = db.Announcements.ToList();
            ViewBag.ProudPartners = db.ProudPartners.ToList();
            ViewBag.AmbassadorsCount = db.Ambassadors.Where(s => s.StatusId == 2).Count();
            ViewBag.VolunteersCount = db.Volunteers.Where(s=>s.StatusId == 2).Count();
            return View();
        }



        [Authorize(Roles = "Admin")]
        public ActionResult AdminPanel()
        {
            return View();
        }
    }
}