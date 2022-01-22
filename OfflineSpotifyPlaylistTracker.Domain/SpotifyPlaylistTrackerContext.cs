using Microsoft.EntityFrameworkCore;
using OfflineSpotifyPlaylistTracker.Domain.Models;

namespace OfflineSpotifyPlaylistTracker.Domain
{
    public class SpotifyPlaylistTrackerContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackPosition> TrackPositions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionString = "server=localhost;database=tradeup;user=root;password=admin";
            optionsBuilder.UseMySql(
                connectionString, ServerVersion.AutoDetect(connectionString))
                // The following three options help with debugging, but should
                // be changed or removed for production.
                //.LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //var iron = new Resource { Id = 1, Name = "Iron", Price = 10.5, CountAvailable = 100 };
            //var copper = new Resource { Id = 2, Name = "Copper", Price = 4.0, CountAvailable = 50 };

            //modelBuilder.Entity<Resource>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name).IsRequired();
            //    entity.HasData(
            //        iron,
            //        copper);
            //});

            //var london = new Contributor { Id = 1, Name = "London", ContributionFactor = 1, Size = 100 };
            //var manchester = new Contributor { Id = 2, Name = "Manchester", ContributionFactor = 1, Size = 50 };

            //modelBuilder.Entity<Contributor>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name).IsRequired();
            //    entity.HasData(
            //       london,
            //        manchester);
            //});
        }
    }
}