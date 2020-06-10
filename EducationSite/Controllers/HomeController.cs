using EducationSite.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationSite.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();
        public ActionResult Index()
        {
            ViewData["Notify"] = db.Notification.OrderByDescending(s => s.NotificationID).ToList();
            ViewData["Notification"] = db.Notification.OrderByDescending(s => s.NotificationID).Take(3).ToList();
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page..";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Gallery()
        {
            ViewData["Gallery"] = db.Gallery.ToList();
            return View();
        }

        public ActionResult Faculty()
        {
            ViewData["faculty"] = db.AddFaculty.ToList();
            return View();
        }


        [HttpPost]

        public ActionResult Contact(Int64 ContactID=0, string Name=null, string Mobile=null, string Email=null, string Subject=null, string Message=null)
        {
            string status = "";
            Models.ContactForm cf = new Models.ContactForm();

            cf.ContactDate = DateTime.Now;
            cf.Email = Email;
            cf.Message = Message;
            cf.Mobile = Mobile;
            cf.Name = Name;
            cf.Subject = Subject;

            db.ContactForm.Add(cf);
           int i= db.SaveChanges();

            if(i>0)
            {
                status = "Succeeded";
            }
            else
            {
                status = "UnSucceeded";
            }

            return View();
        }

    }
}