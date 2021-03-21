using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=DESKTOP-VGGFIVR\SQLEXPRESS;Database=api;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                        .Property(x => x.Latitude)
                        .HasPrecision(18, 15);

            modelBuilder.Entity<Location>()
                        .Property(x => x.Longitude)
                        .HasPrecision(18, 15);

            modelBuilder.Entity<CitizenLocations>()
                        .HasKey(x => new { x.CitizenId, x.LocationId });

            modelBuilder.Entity<CitizenLocations>()
                        .HasOne(x => x.Citizen)
                        .WithMany(x => x.CitizenLocations)
                        .HasForeignKey(x => x.CitizenId);

            modelBuilder.Entity<CitizenLocations>()
                        .HasOne(x => x.Location)
                        .WithMany(x => x.CitizenLocations)
                        .HasForeignKey(x => x.LocationId);     
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<PHI> PHIs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CitizenLocations> CitizenLocations { get; set; }

    }
}
