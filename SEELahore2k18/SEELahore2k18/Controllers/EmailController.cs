using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEELahore2k18.Models;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;

namespace SEELahore2k18.Controllers
{
    public class EmailController : Controller
    {

        private static string SenderEmailId = WebConfigurationManager.AppSettings["DefaultEmailId"];
        private static string SenderEmailPassword = WebConfigurationManager.AppSettings["DefaultEmailPassword"];
        private static int SenderEmailPort = Convert.ToInt32(WebConfigurationManager.AppSettings["DefaultEmailPort"]);
        private static string SenderEmailHost = WebConfigurationManager.AppSettings["DefaultEmailHost"];

        private SEELahoreEntities db = new SEELahoreEntities();

        public ActionResult SendEmail(string subject, string body, string To, string Name)
        {

            var fromAddress = new MailAddress(SenderEmailId, "Contact Message By: " + Name);
            var toAddress = new MailAddress(SenderEmailId, "Print My Box");
            string fromPassword = SenderEmailPassword;
            //string subject = "PrintMyBox Contact Us form Submission by: " + Name;
            //string body = "Name: " + Name + "<br>Phone: " + Phone + "<br>" + "Email: " + Email + "<br>" + "Message: " + Message + "<br>Time: " + DateTime.Now;

            var smtp = new SmtpClient
            {
                Host = SenderEmailHost,
                Port = SenderEmailPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body,

            })
            {
                //message.Bcc.Add("support@printmybox.com");
                smtp.Send(message);
            }


            return View();
        }
    }
}