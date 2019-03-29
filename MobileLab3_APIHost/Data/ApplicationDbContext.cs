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
            modelBuilder.Entity<Artwork>()
                .HasIndex(a => new { a.ArtTypeID, a.Name })
                .IsUnique();
        }


    }
}
