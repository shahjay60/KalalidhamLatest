using Kalalidham.Data;
using Kalalidham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Kalalidham.Controllers
{

    public class HomeController : Controller
    {
        KalalidhamEntities usersEntities = new KalalidhamEntities();
        public ActionResult Index()
        {
            ViewBag.VideoData = usersEntities.tblVideos.ToList().Take(4);
            ViewBag.ImageDatas = usersEntities.tblMultiImages.Where(x=>x.ImageTitleId!=0).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Invitation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendEmail(tblContact mdata)
        {

            #region SendEmail & Password
            //Log.Info("Register Mail started...");
            try
            {
                usersEntities.tblContacts.Add(mdata);
                usersEntities.SaveChanges();
                //MailMessage mail = new MailMessage();
                //mail.To.Add(Email);
                //MailAddress address = new MailAddress(Email);
                //mail.From = address;

                ////   msgs.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                //string body = string.Empty;
                //mail.Subject = "Enqury details from" + mdata.Name;
                //body = "Name: " + mdata.Name;
                //body += "Email: " + mdata.EmailId;
                //body += "Message: " + mdata.Message;
                //body += "Subject: " + mdata.Subject;

                //mail.Subject = "Enquiry from client";
                //string Body = body;
                //mail.Body = Body;
                //mail.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Host = "relay-hosting.secureserver.net";
                //smtp.Port = 25;
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = new System.Net.NetworkCredential(Email, Password); // Enter seders User name and password  
                //smtp.EnableSsl = false;
                //smtp.Send(mail);
                return Json("Ok");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }


            #endregion
        }
    }
}