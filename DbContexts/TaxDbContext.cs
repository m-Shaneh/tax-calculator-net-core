using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using congestion.calculator.Entities;

namespace congestion.calculator.DbContexts
{
    internal class TaxDbContext : DbContext
    {
       public static string Connection= "Data Source=.;Initial Catalog=TaxCalc;Persist Security Info=True;Trusted_Connection=True;Connect Timeout=1024;";

        public TaxDbContext() : base(new DbContextOptionsBuilder<TaxDbContext>()
       .UseSqlServer(Connection).Options)
        {

        }

        public TaxDbContext(DbContextOptions<TaxDbContext> options) : base(options)
        {
            
        }
        DbSet<City> Citys { get; set; }
        DbSet<TollFreeDate> tollFreeDates { get; set; }
        DbSet<TollFreeVehicle> tollFreeVehicles { get; set; }
        DbSet<TollTimeFee> tollTimeFees { get; set; }
        DbSet<Vehicle> vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
