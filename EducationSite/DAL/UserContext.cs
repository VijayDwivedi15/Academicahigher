using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EducationSite.Models;
using EducationSite.Migrations;

namespace EducationSite.DAL
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<EducationSite.Models.AddFaculty> AddFaculty { get; set; }
        public virtual DbSet<EducationSite.Models.Gallery> Gallery { get; set; }
        public virtual DbSet<EducationSite.Models.ContactForm> ContactForm { get; set; }
        public virtual DbSet<EducationSite.Models.Notification> Notification { get; set; }
    }
}