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
        public DbSet<BusinessDirectoryApp.Models.ClientModel> ClientModel { get; set; }
        public DbSet<BusinessDirectoryApp.Models.ContactModel> ContactModel { get; set; }
    }
}
