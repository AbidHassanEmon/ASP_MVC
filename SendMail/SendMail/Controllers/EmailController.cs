using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;
using SendMail.Models;
namespace SendMail.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult sendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    Random r = new Random();
                    var x = r.Next(99999,1000000).ToString();

                    var m = message + "  "+ x;
                    var senderEmail = new MailAddress("shovon2186@gmail.com", "No_reply");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "sbfyatzqliswpvzx";
                    var sub = subject;
                    var body = m;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error"+e.Message;
            }
            return View();
        }
    }
}