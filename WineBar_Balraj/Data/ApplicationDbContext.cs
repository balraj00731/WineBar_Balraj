using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WineBar_Balraj.Models;

namespace WineBar_Balraj.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
