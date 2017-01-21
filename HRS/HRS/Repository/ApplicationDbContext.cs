using HRS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRS.Repository
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<BookingInfo> BookingInfo { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Gallary> Gallary { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<User> User { get; set; }

    }
}