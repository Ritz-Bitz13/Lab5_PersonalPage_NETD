using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Lab5_PersonalPage.Controllers;
using Lab5_PersonalPage.Models;

namespace Lab5_PersonalPage.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Gets the data from the tables of the Seller Information Table
        public DbSet<SellerInformation> Seller { get; set; }

        // This gets the data from the Computer Parts Table
        public DbSet<ComputerParts> Parts { get; set; }

        // This gets the data from the Computer Parts Table
        public DbSet<Lab5_PersonalPage.Models.ForgotPassword> ForgotPassword { get; set; }
    }
}
