using EducationSite.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationSite.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //

        UserContext db = new UserContext();
        // GET: /Admin/Admin/


        //------------------------Functionality For LogOut--------------------------

        [HttpPost]
        public ActionResult LogOff()
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //return RedirectToAction("UserCP", "Dashboard", new { area = "Admin" });
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }




        public ActionResult Index()
        {
            ViewBag.totalFaculty = db.AddFaculty.Count();
            ViewBag.totalImages = db.Gallery.Count();
            ViewBag.Contacts = db.ContactForm.Count();
            return View();
        }

        [HttpGet]
        public ActionResult AddFaculty(Int64 FacultyID = 0)
        {
            Models.AddFaculty fac = new Models.AddFaculty();

            if (FacultyID > 0)
            {
                var faculty = db.AddFaculty.Where(s => s.FacultyID == FacultyID).FirstOrDefault();
                fac.Address = faculty.Address;
                fac.Age = faculty.Age;
                fac.Email = faculty.Email;
                fac.Experience = faculty.Experience;
                fac.ExpertiesIn = faculty.ExpertiesIn;
                fac.FacultyID = FacultyID;
                fac.Gender = faculty.Gender;
                fac.Mobile = faculty.Mobile;
                fac.Name = faculty.Name;
                fac.Qualification = faculty.Address;

            }


            return View(fac);
        }

        [HttpPost]
        public ActionResult AddFaculty(HttpPostedFileBase Image, Int64 FacultyID = 0, string Name = null, string Gender = null, Int32 Age = 0, string Qualification = null, string Experience = null, string ExpertiesIn = null, string Mobile = null, string Email = null, string Address = null)
        {
            string userid = User.Identity.GetUserId();
            string Status = "";

            string teacpic = null;
            teacpic = "UploadedImage/" + Image.FileName;

            Models.AddFaculty faculty = new Models.AddFaculty();

            var fac = db.AddFaculty.Where(s => s.FacultyID == FacultyID).FirstOrDefault();

            if (fac == null)
            {
                faculty.Address = Address;
                faculty.Age = Age;
                faculty.Email = Email;
                faculty.Experience = Experience;
                faculty.ExpertiesIn = ExpertiesIn;
                faculty.Gender = Gender;
                faculty.Mobile = Mobile;
                faculty.Name = Name;
                faculty.Qualification = Qualification;
                faculty.Image = teacpic;
                faculty.CreatedBy = userid;
                faculty.CreatedOn = DateTime.Now;

                db.AddFaculty.Add(faculty);
                db.SaveChanges();

                Status = "Succeeded";
                string path = Server.MapPath("~/UploadedImage/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Image.SaveAs(path + Image.FileName);




            }
            else
            {
                fac.Address = Address;
                fac.Age = Age;
                fac.Email = Email;
                fac.Experience = Experience;
                fac.ExpertiesIn = ExpertiesIn;
                fac.Gender = Gender;
                fac.Mobile = Mobile;
                fac.Name = Name;
                fac.Qualification = Qualification;
                fac.CreatedBy = userid;
                fac.CreatedOn = DateTime.Now;
                fac.Image = teacpic;

                db.SaveChanges();

                Status = "Succeeded";
                string path = Server.MapPath("~/UploadedImage/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Image.SaveAs(path + Image.FileName);

            }




            return RedirectToAction("AllFaculty", "Admin", new { area = "Admin" });
        }


        public ActionResult DeleteFaculty(Int64 FacultyID = 0)
        {
            string Status = "NA";

            var StatusExist = db.AddFaculty.Find(FacultyID);
            if (StatusExist != null)
            {

                db.AddFaculty.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }

            return RedirectToAction("AllFaculty", "Admin", new { area = "Admin" });
        }


        public ActionResult AllFaculty()
        {
            ViewData["AllFaculty"] = db.AddFaculty.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult AddGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGallery(HttpPostedFileBase[] Images, Int64 GalleryID = 0, string Title = null)
        {
            string userid = User.Identity.GetUserId();
            string Status = "";

            Models.Gallery gal = new Models.Gallery();

            var exsist = db.Gallery.Where(s => s.GalleryID == GalleryID).FirstOrDefault();

            if (exsist == null)
            {
                for (int i = 0; i < Images.Length; i++)
                {
                    string path = Server.MapPath("~/UploadedImage/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    Images[i].SaveAs(path + Path.GetFileName(Images[i].FileName));

                    gal.Title = Title;
                    gal.Images = Images[i].FileName;
                    gal.CreatedBy = userid;
                    gal.CreatedOn = DateTime.Now;
                    db.Gallery.Add(gal);
                    db.SaveChanges();

                }
            }



            return RedirectToAction("AllImages", "Admin", new { area = "Admin" });
        }


        public ActionResult AllImages()
        {
            ViewData["Gallery"] = db.Gallery.ToList();
            return View();
        }

        public ActionResult DeleteGallery(Int64 GalleryID = 0)
        {
            string Status = "NA";

            var StatusExist = db.Gallery.Find(GalleryID);
            if (StatusExist != null)
            {

                db.Gallery.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }

            return RedirectToAction("AllImages", "Admin", new { area = "Admin" });
        }

        public ActionResult AllContacts()
        {
            ViewData["Contact"] = db.ContactForm.ToList();
            return View();
        }


        public ActionResult DeleteContacts(Int64 ContactID = 0)
        {
            string Status = "NA";

            var StatusExist = db.ContactForm.Find(ContactID);
            if (StatusExist != null)
            {

                db.ContactForm.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }

            return RedirectToAction("AllContacts", "Admin", new { area = "Admin" });
        }



        //--------------For Notofication Section----------------------

        public ActionResult Notification()
        {
            ViewData["Notify"] = db.Notification.OrderByDescending(s => s.NotificationID).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Notification(Int64 NotificationID = 0, string NotificationText = null)
        {
            string Status = "";

            Models.Notification noti = new Models.Notification();

            noti.NotificationDate = DateTime.Now;
            noti.NotificationText = NotificationText;

            db.Notification.Add(noti);
            int i = db.SaveChanges();

            if(i>0)
            {
                Status = "Succeeded";
            }
            else
            {
                Status = "UnSucceeded";
            }
            TempData["example"] = Status;
            return RedirectToAction("Notification", "Admin", new { area = "Admin" });
        }





        public ActionResult DeleteNotification(Int64 NotificationID=0)
        {
            string Status = "NA";

            var StatusExist = db.Notification.Find(NotificationID);
            if (StatusExist != null)
            {

                db.Notification.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }

            TempData["DeleteResult"] = Status;
            return RedirectToAction("Notification", "Admin", new { area = "Admin" });
        }

    }
}