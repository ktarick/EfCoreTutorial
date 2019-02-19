using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreTutorial.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connStr = @"server=STUDENT05\SQLEXPRESS;database=SalesDb2;trusted_connection=true;";
            builder.UseSqlServer(connStr);
        }
    }
}