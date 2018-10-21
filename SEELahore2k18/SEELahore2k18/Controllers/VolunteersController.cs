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
    public class VolunteersController : Controller
    {
        private SEELahoreEntities db = new SEELahoreEntities();

        // GET: Volunteers
        public ActionResult Index()
        {
            var volunteers = db.Volunteers.Include(v => v.RequestStatu).Include(v => v.VolunteerCategory);
            return View(volunteers.ToList());
        }

        // GET: Volunteers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // GET: Volunteers/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.RequestStatus, "Id", "Status");
            ViewBag.VolunteerCategoryId = new SelectList(db.VolunteerCategories, "Id", "Category");
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContactNo,FacebookId,EmailId,CNIC,Institute,StatusId,CreatedAt,Address,CityOfResidence,Degree,PreviousExperiance,VolunteerCategoryId,Hostelite")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                volunteer.CreatedAt = DateTime.Now;
                db.Volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.RequestStatus, "Id", "Status", volunteer.StatusId);
            ViewBag.VolunteerCategoryId = new SelectList(db.VolunteerCategories, "Id", "Category", volunteer.VolunteerCategoryId);
            return View(volunteer);
        }

        // GET: Volunteers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.RequestStatus, "Id", "Status", volunteer.StatusId);
            ViewBag.VolunteerCategoryId = new SelectList(db.VolunteerCategories, "Id", "Category", volunteer.VolunteerCategoryId);
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContactNo,FacebookId,EmailId,CNIC,Institute,StatusId,CreatedAt,Address,CityOfResidence,Degree,PreviousExperiance,VolunteerCategoryId,Hostelite")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                volunteer.CreatedAt = DateTime.Now;
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.RequestStatus, "Id", "Status", volunteer.StatusId);
            ViewBag.VolunteerCategoryId = new SelectList(db.VolunteerCategories, "Id", "Category", volunteer.VolunteerCategoryId);
            return View(volunteer);
        }

        // GET: Volunteers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateStatus(int? id, int? Status)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            volunteer.StatusId = Status;
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