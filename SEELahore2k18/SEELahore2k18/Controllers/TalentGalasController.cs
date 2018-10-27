﻿using System;
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
    public class TalentGalasController : Controller
    {
        private SEELahoreEntities db = new SEELahoreEntities();

        // GET: TalentGalas
        public ActionResult Index()
        {
            ViewBag.InstituteId = new SelectList(db.Institutes, "Id", "Institute1");
            var talentGalas = db.TalentGalas.Include(t => t.RequestStatu);
            return View(talentGalas.ToList());
        }

        // GET: TalentGalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalentGala talentGala = db.TalentGalas.Find(id);
            if (talentGala == null)
            {
                return HttpNotFound();
            }
            return View(talentGala);
        }

        [AllowAnonymous]
        // GET: TalentGalas/Create
        public ActionResult Create()
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var dateRange = db.RegistrationDeadLines.FirstOrDefault(s => s.RegistrationType == controllerName);
            var comparisonto = (DateTime.Compare(Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(dateRange.To)));
            var comparisonfrom = (DateTime.Compare(Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(dateRange.From)));

            if (comparisonto != -1)
            {
                return RedirectToAction("RegistrationDeadline", "Home", new { status = "Registrations Ended" });
            }
            else if (comparisonfrom != 1)
            {
                return RedirectToAction("RegistrationDeadline", "Home", new { status = "Registrations will be open soon!" });
            }
            ViewBag.InstituteId = new SelectList(db.Institutes, "Id", "Institute1");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status");
            return View();
        }
        [AllowAnonymous]

        // POST: TalentGalas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,InstituteId,Degree,CGPA_Numbers,TotalNumbers,CNIC,ContactNo_,Email,CreatedAt,CurrentSemester_Year,RequestStatusId")] TalentGala talentGala)
        {
            if (ModelState.IsValid)
            {
                var obj = db.TalentGalas.FirstOrDefault(s => s.Email == talentGala.Email);
                if (obj != null)
                {
                    ViewBag.ErrorMessage = "Email Already Exists!";
                    ViewBag.InstituteId = new SelectList(db.Institutes, "Id", "Institute1");
                    ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", talentGala.RequestStatusId);
                    ModelState.AddModelError("Error: ", "Email Alread");
                    return View(talentGala);
                }
                //var institute = Request.Form["InstituteId"]; talentGala.InstituteId =Convert.ToInt32(institute);
                talentGala.RequestStatusId = 1;
                talentGala.CreatedAt = DateTime.Now;
                db.TalentGalas.Add(talentGala);
                db.SaveChanges();
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                return RedirectToAction("SubmissionResponce", "Home", new { status = "You are successfully registerd for Talent Gala with your crdentials,Team SEE Lahore will soon respond you through Email.Stay Connected for Bigest Event of Lahore,See Lahore 2018", url = controllerName + "/" + actionName });
            }

            ViewBag.InstituteId = new SelectList(db.Institutes, "Id", "Institute1");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", talentGala.RequestStatusId);
            return View(talentGala);
        }

        // GET: TalentGalas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalentGala talentGala = db.TalentGalas.Find(id);
            if (talentGala == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituteId = new SelectList(db.Institutes, "Id", "Institute1");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", talentGala.RequestStatusId);
            return View(talentGala);
        }

        // POST: TalentGalas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,InstituteId,Degree,CGPA_Numbers,TotalNumbers,CNIC,ContactNo_,Email,CreatedAt,CurrentSemester_Year,RequestStatusId")] TalentGala talentGala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talentGala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituteId = new SelectList(db.Institutes, "Id", "Institute1");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", talentGala.RequestStatusId);
            return View(talentGala);
        }

        // GET: TalentGalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalentGala talentGala = db.TalentGalas.Find(id);
            if (talentGala == null)
            {
                return HttpNotFound();
            }
            return View(talentGala);
        }

        // POST: TalentGalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TalentGala talentGala = db.TalentGalas.Find(id);
            db.TalentGalas.Remove(talentGala);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UpdateStatus(int? id, int? Status)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalentGala volunteer = db.TalentGalas.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            volunteer.RequestStatusId = Status;
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
