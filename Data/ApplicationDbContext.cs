using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BusinessDirectoryApp.Models;

namespace BusinessDirectoryApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<ClientContact>()
                       .HasKey(c => new { c.ClientID, c.ContactID });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BusinessDirectoryApp.Models.ClientModel> ClientModel { get; set; }
        public DbSet<BusinessDirectoryApp.Models.ContactModel> ContactModel { get; set; }
        public DbSet<BusinessDirectoryApp.Models.ClientContact> ClientContact { get; set; }
    }
}
