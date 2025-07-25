using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DahiraAgency.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Destination
            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(d => d.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(d => d.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(d => d.Price)
                    .IsRequired();

                entity.Property(d => d.Date)
                    .IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(c => c.Destinations)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Favourite
            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.HasOne(f => f.User)
                    .WithMany(u => u.Favourites)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.Destination)
                    .WithMany(d => d.Favourites)
                    .HasForeignKey(f => f.DestinationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            var defaultUser = new ApplicationUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@touristagency.com",
                NormalizedUserName = "ADMIN@TOURISTAGENCY.COM",
                Email = "admin@touristagency.com",
                NormalizedEmail = "ADMIN@TOURISTAGENCY.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(
                    new ApplicationUser { UserName = "admin@touristagency.com" },
                    "Admin123!")
            };
            modelBuilder.Entity<ApplicationUser>().HasData(defaultUser);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Beach" },
                new Category { Id = 2, Name = "Mountain" },
                new Category { Id = 3, Name = "City" }
            );

            modelBuilder.Entity<Destination>().HasData(
                new Destination { Id = 1, Name = "Dubai", Description = "City of luxury.", CategoryId = 3, ImageUrl = "https://lp-cms-production.imgix.net/features/2017/09/dubai-marina-skyline-2c8f1708f2a1.jpg?auto=format,compress&q=72&w=1440&h=810&fit=crop", Price = 1900 },
                new Destination { Id = 2, Name = "Swiss Alps", Description = "Beautiful mountains.", CategoryId = 2, ImageUrl = "https://www.montagnaestate.it/wp-content/uploads/8otmnnrjuhm.jpg", Price = 1500 },
                new Destination { Id = 3, Name = "Maldives", Description = "Stunning beaches.", CategoryId = 1, ImageUrl = "https://digital.ihg.com/is/image/ihg/vignette-collection-noonu-atoll-9970118335-2x1", Price = 2000 }
            );
        }
    }
}
