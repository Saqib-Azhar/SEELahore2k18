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


        public void SubmitEmailForm(FormCollection fc)
        {
            var EmailSubject = fc["EmailSubject"];
            var EmailBody = fc["EmailBody"];
            var EmailTo = fc["EmailTo"];
            var EmailName = fc["EmailName"];
            SendEmail(EmailSubject, EmailBody, EmailTo, EmailName);
        }



        public JsonResult SendEmail(string EmailSubject, string EmailBody, string EmailTo, string EmailName)
        {

            try
            {
                var fromAddress = new MailAddress(SenderEmailId, "See Lahore 2k18:" + EmailName);
                var toAddress = new MailAddress(EmailTo, EmailName);
                string fromPassword = SenderEmailPassword;

                var smtp = new SmtpClient
                {
                    Host = SenderEmailHost,
                    Port = SenderEmailPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 500000,
                    UseDefaultCredentials = false
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    IsBodyHtml = true,
                    Subject = EmailSubject,
                    Body = EmailBody,

                })
                {
                    //message.Bcc.Add("support@printmybox.com");
                    smtp.Send(message);
                }
                return Json("Email sent successfuly!", JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {

                HomeController.infoMessage(ex.Message);
                HomeController.writeErrorLog(ex);
                return Json("Something went wrong! Please try again", JsonRequestBehavior.AllowGet);
            }
        }
    }
}