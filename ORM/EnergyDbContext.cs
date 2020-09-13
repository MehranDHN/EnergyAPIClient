using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergyApiClient.DomainModels.Models;

namespace EnergyAPIClient.ORM
{
    public class EnergyDbContext : DbContext
    {
        public DbSet<PowerCounter> PowerCounter { get; set; }
        
        public DbSet<BldProperty> BldProperty { get; set; }

        public DbSet<PowerSrcInfo> PowerSrcInfo { get; set; }

        public DbSet<PowerSrcUsage> PowerSrcUsage { get; set; }

        public DbSet<PowerSrcPayment> PowerSrcPayment { get; set; }
        public EnergyDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(
          ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PowerCounter>().HasKey(pc => new { pc.TagIdentifier});
            modelBuilder.Entity<BldProperty>().HasKey(bl => new { bl.Pkid });
            modelBuilder.Entity<PowerSrcInfo>().HasKey(ps => new { ps.bill_identifier });
            modelBuilder.Entity<PowerSrcUsage>().HasKey(ps => new { ps.Pkid });
            modelBuilder.Entity<PowerSrcPayment>().HasKey(ps => new { ps.Pkid });


            modelBuilder.Entity<PowerSrcInfo>()
                .HasOne(o => o.TargetCounter)
                .WithOne(o => o.RelatedInfo).HasForeignKey<PowerCounter>(f => f.TagIdentifier);

            modelBuilder.Entity<BldProperty>()
    .HasOne(o => o.TargetPowerCounter)
    .WithOne(o => o.TargetBuilding).HasForeignKey<PowerCounter>(f => f.LocationID);



            base.OnModelCreating(modelBuilder);
        }
    }
}
