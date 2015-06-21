using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendMailMVC.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendMailMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email từ: {0} ({1})</p><p> Tin nhắn: </p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("vanloc0301@gmail.com"));
                message.From = new MailAddress("vanloc0301@outlook.com");
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "vanloc0301@outlook.com",
                        Password = "r0ysy0301"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
    }
}