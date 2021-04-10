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

            modelBuilder.Entity<Citizen>()
                .ToTable("Citizens");

            modelBuilder.Entity<PHI>()
                .ToTable("PHIs");

            modelBuilder.Entity<Citizen>()
                .HasMany(x => x.Locations)
                .WithMany(x => x.Citizens);

            modelBuilder.Entity<Location>()
                        .Property(x => x.Latitude)
                        .HasPrecision(18, 15);

            modelBuilder.Entity<Location>()
                        .Property(x => x.Longitude)
                        .HasPrecision(18, 15);  
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<PHI> PHIs { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
