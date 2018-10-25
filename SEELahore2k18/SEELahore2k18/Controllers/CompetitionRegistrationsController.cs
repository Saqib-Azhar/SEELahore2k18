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
    [Authorize]
    public class CompetitionRegistrationsController : Controller
    {
        private SEELahoreEntities db = new SEELahoreEntities();

        // GET: CompetitionRegistrations
        public ActionResult Index(int? type = 0)
        {
            if (type != 0)
            {
            ViewBag.InstitutesList = new SelectList(db.Institutes, "Id", "Institute1");
                var competitionRegistrations = db.CompetitionRegistrations.Where(s => s.RequestStatusId == type).Include(c => c.Competition).Include(c => c.RequestStatu);
                return View(competitionRegistrations.ToList());
            }
            else
            {
            ViewBag.InstitutesList = new SelectList(db.Institutes, "Id", "Institute1");
                var competitionRegistrations = db.CompetitionRegistrations.Include(c => c.Competition).Include(c => c.RequestStatu);
                return View(competitionRegistrations.ToList());
            }
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
        [AllowAnonymous]
        // GET: CompetitionRegistrations/Create
        public ActionResult Create(int? val = 0)
        {
            if (val == 1)
            {
                ViewBag.isTalentGala = 1;
            }
            else
            {
                ViewBag.isTalentGala = 0;

            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "CompetitionName");
            ViewBag.InstitutesList = new SelectList(db.Institutes, "Id", "Institute1");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status");
            return View();
        }
        [AllowAnonymous]
        // POST: CompetitionRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContactNo,Designation,EmailId,CNIC,Institute,RequestStatusId,CreatedAt,Address,City,CompetitionId")] CompetitionRegistration competitionRegistration)
        {
            if (ModelState.IsValid)
            {
                var a = ViewBag.isTalentGala;
                competitionRegistration.RequestStatusId = 1;
                competitionRegistration.CreatedAt = DateTime.Now;
                db.CompetitionRegistrations.Add(competitionRegistration);
                db.SaveChanges();
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                return RedirectToAction("SubmissionResponce", "Home", new { status = "Submitted Successfully!", url = controllerName + "/" + actionName });
            }

            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "CompetitionName", competitionRegistration.CompetitionId);
            ViewBag.InstitutesList = new SelectList(db.Institutes, "Id", "Institute1");
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
            ViewBag.InstitutesList = new SelectList(db.Institutes, "Id", "Institute1");
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
                competitionRegistration.CreatedAt = DateTime.Now;
                db.Entry(competitionRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstitutesList = new SelectList(db.Institutes, "Id", "Institute1");
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

        public ActionResult UpdateStatus(int? id, int? Status)
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
            competitionRegistration.RequestStatusId = Status;
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
