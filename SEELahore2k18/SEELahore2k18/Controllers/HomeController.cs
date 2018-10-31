using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEELahore2k18.Models;
using System.IO;
using System.Data.Entity.Validation;

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

        public ActionResult SubmissionResponce(string status, string url)
        {
            ViewBag.Message = status;
            ViewBag.Url = url;

            return View();
        }
        
        public ActionResult NewSubmission(string url)
        {
            var a = url.Split('/');
            return RedirectToAction(a[1], a[0]);
        }

        public ActionResult RegistrationDeadline(string status)
        {
            ViewBag.Message = status;
            return View();
        }



        public static void infoMessage(string _message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + _message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void writeErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + " | " + ex.Source.ToString().Trim() + " | " + ex.StackTrace.ToString().Trim() + " | " + ex.Message.ToString().Trim()+"\n\n");
                sw.Flush();
                sw.Close();
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }


        public static void EntityinfoMessage(string _message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\EntityErrorLogs.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + _message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void EntitywriteErrorLog(DbEntityValidationException ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\EntityLogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + " | " + ex.Source.ToString().Trim() + " | " + ex.StackTrace.ToString().Trim() + " | " + ex.Message.ToString().Trim() + "\n\n");
                sw.Flush();
                sw.Close();
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

    }
}