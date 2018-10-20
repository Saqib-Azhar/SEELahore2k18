using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEELahore2k18.Models;

namespace SEELahore2k18.Controllers
{
    public class CompetitionRegistrationsController : Controller
    {
        private SEELahoreEntities db = new SEELahoreEntities();

        // GET: CompetitionRegistrations
        public ActionResult Index()
        {
            var competitionRegistrations = db.CompetitionRegistrations.Include(c => c.Competition).Include(c => c.RequestStatu);
            return View(competitionRegistrations.ToList());
        }

        // GET: CompetitionRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionRegistration competitionRegistration = db.CompetitionRegistrations.Find(id);
            if (competitionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(competitionRegistration);
        }

        // GET: CompetitionRegistrations/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "CompetitionName");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status");
            return View();
        }

        // POST: CompetitionRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContactNo,Designation,EmailId,CNIC,Institute,RequestStatusId,CreatedAt,Address,City,CompetitionId")] CompetitionRegistration competitionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.CompetitionRegistrations.Add(competitionRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "CompetitionName", competitionRegistration.CompetitionId);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", competitionRegistration.RequestStatusId);
            return View(competitionRegistration);
        }

        // GET: CompetitionRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionRegistration competitionRegistration = db.CompetitionRegistrations.Find(id);
            if (competitionRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "CompetitionName", competitionRegistration.CompetitionId);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", competitionRegistration.RequestStatusId);
            return View(competitionRegistration);
        }

        // POST: CompetitionRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContactNo,Designation,EmailId,CNIC,Institute,RequestStatusId,CreatedAt,Address,City,CompetitionId")] CompetitionRegistration competitionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competitionRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "CompetitionName", competitionRegistration.CompetitionId);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", competitionRegistration.RequestStatusId);
            return View(competitionRegistration);
        }

        // GET: CompetitionRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionRegistration competitionRegistration = db.CompetitionRegistrations.Find(id);
            if (competitionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(competitionRegistration);
        }

        // POST: CompetitionRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetitionRegistration competitionRegistration = db.CompetitionRegistrations.Find(id);
            db.CompetitionRegistrations.Remove(competitionRegistration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
