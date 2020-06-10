using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationSite.Models
{
    public class AddFaculty
    {
        [Key]
        public Int64 FacultyID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public int  Age { get; set; }
        public string ExpertiesIn { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public class Gallery
    {
        [Key]
        public Int64 GalleryID { get; set; }
        public string Images { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }


    public class ContactForm
    {
        [Key]
        public Int64 ContactID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime ContactDate { get; set; }

    }

    public class Notification
    {
        [Key]
        public Int64 NotificationID { get; set; }
        public string NotificationText { get; set; }
        public DateTime NotificationDate { get; set; }
    }

}