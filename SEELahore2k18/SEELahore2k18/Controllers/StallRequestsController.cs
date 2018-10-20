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
    public class StallRequestsController : Controller
    {
        private SEELahoreEntities db = new SEELahoreEntities();

        // GET: StallRequests
        public ActionResult Index()
        {
            var stallRequests = db.StallRequests.Include(s => s.AspNetUser).Include(s => s.RequestStatu).Include(s => s.StallCategory);
            return View(stallRequests.ToList());
        }

        // GET: StallRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StallRequest stallRequest = db.StallRequests.Find(id);
            if (stallRequest == null)
            {
                return HttpNotFound();
            }
            return View(stallRequest);
        }

        // GET: StallRequests/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status");
            ViewBag.CategoryId = new SelectList(db.StallCategories, "Id", "StallType");
            return View();
        }

        // POST: StallRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StallName,StallDetails,Logo,RequestStatusId,CategoryId,CreatedBy,CreatedAt,OwnerName,ContactNo,Email,Address,City,Profession,Institute")] StallRequest stallRequest)
        {
            if (ModelState.IsValid)
            {
                db.StallRequests.Add(stallRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.AspNetUsers, "Id", "Email", stallRequest.CreatedBy);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", stallRequest.RequestStatusId);
            ViewBag.CategoryId = new SelectList(db.StallCategories, "Id", "StallType", stallRequest.CategoryId);
            return View(stallRequest);
        }

        // GET: StallRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StallRequest stallRequest = db.StallRequests.Find(id);
            if (stallRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.AspNetUsers, "Id", "Email", stallRequest.CreatedBy);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", stallRequest.RequestStatusId);
            ViewBag.CategoryId = new SelectList(db.StallCategories, "Id", "StallType", stallRequest.CategoryId);
            return View(stallRequest);
        }

        // POST: StallRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StallName,StallDetails,Logo,RequestStatusId,CategoryId,CreatedBy,CreatedAt,OwnerName,ContactNo,Email,Address,City,Profession,Institute")] StallRequest stallRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stallRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.AspNetUsers, "Id", "Email", stallRequest.CreatedBy);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "Id", "Status", stallRequest.RequestStatusId);
            ViewBag.CategoryId = new SelectList(db.StallCategories, "Id", "StallType", stallRequest.CategoryId);
            return View(stallRequest);
        }

        // GET: StallRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StallRequest stallRequest = db.StallRequests.Find(id);
            if (stallRequest == null)
            {
                return HttpNotFound();
            }
            return View(stallRequest);
        }

        // POST: StallRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StallRequest stallRequest = db.StallRequests.Find(id);
            db.StallRequests.Remove(stallRequest);
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
