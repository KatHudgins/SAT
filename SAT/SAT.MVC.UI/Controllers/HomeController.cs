using SAT.MVC.UI.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace SAT.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)

            {
                string body = $"New Messages!<br> Regarding: {cvm.Subject}<br>From: { cvm.Name} <br> Here's what they have to say: {cvm.Message} <br> Reply in turn to:{cvm.Email}";
                MailMessage msg = new MailMessage("Admin@kathrynrosella.com", "Hudginskr@outlook.com", cvm.Subject, body);
                msg.IsBodyHtml = true;
                msg.ReplyToList.Add(cvm.Email);
                SmtpClient client = new SmtpClient("mail.kathrynrosella.com");
                client.Credentials = new NetworkCredential("Admin@kathrynrosella.com", "Ax9401Lackey**");
                try
                {
                    client.Send(msg);
                }
                catch (Exception Ex)
                {
                    ViewBag.SendEmailError = $"Attempt to send message has failed. Details: {Ex.Message}";
                    return View(cvm);
                }
                return View("EmailConfirmation", cvm);
            }

            return View(cvm);
        }
    }
}
