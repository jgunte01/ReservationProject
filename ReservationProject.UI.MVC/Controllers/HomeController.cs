using ReservationProject.UI.MVC.Models;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace ReservationProject.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult ReservationContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReservationContact(ContactViewModel cvm)
        {

            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            
            //1)
            MailMessage msg = new MailMessage( "admin@jeremy-gunter.com", "jgunte01@gmail.com", cvm.Subject, cvm.Message + "<br />Sent by " + cvm.Name + " - " + cvm.Email);

            //2) 
            msg.IsBodyHtml = true;


            //3)
            SmtpClient client = new SmtpClient("mail.jeremy-gunter.com");
            //client.Port = 8889;
            client.Credentials = new NetworkCredential("admin@jeremy-gunter.com", "Lauren#01");

            //4)
            try
            {
                client.Send(msg);
            }
            catch (System.Exception ex)
            {

                ViewBag.ErrorMessage = $"Something went wrong - {ex.InnerException}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your Login page.";

            return View();
        }

    }
}
