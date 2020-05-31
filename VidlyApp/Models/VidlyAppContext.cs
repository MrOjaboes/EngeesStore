using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VidlyApp.Models
{
    public class VidlyAppContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public VidlyAppContext() : base("VidlyEntities") 
        {
        }
    }
}