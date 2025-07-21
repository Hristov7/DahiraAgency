using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DahiraAgency.Data
{
    public class ApplicationDbContext : IdentityDbContext
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

            var defaultUser = new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@touristagency.com",
                NormalizedUserName = "ADMIN@TOURISTAGENCY.COM",
                Email = "admin@touristagency.com",
                NormalizedEmail = "ADMIN@TOURISTAGENCY.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@touristagency.com" },
                    "Admin123!")
            };
            modelBuilder.Entity<IdentityUser>().HasData(defaultUser);
        }
    }
}
