using Microsoft.EntityFrameworkCore;
using MobileLab3_APIHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLab3_APIHost.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<ArtType> ArtTypes { get; set; }
        public DbSet<Artwork> Artworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Artwork>()
            //    .HasIndex(a => new { a.ArtTypeID, a.Name })
            //    .IsUnique();

            modelBuilder.Entity<Artwork>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder.Entity<ArtType>()
                .HasMany(at => at.Artworks)
                .WithOne(a => a.ArtType)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
