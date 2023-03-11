using Microsoft.EntityFrameworkCore;
using ReviewSite.Models;

namespace ReviewSite.Context
{
    public class RestaurantContext : DbContext
    {
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantReviews34;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantModel>().HasData
                (
                new RestaurantModel { Id = 1, Name = "Olive Garden", ImageUrl = "\\Images\\Olive_Garden_Logo.svg.png" });

            modelBuilder.Entity<ReviewModel>().HasData(
                new ReviewModel { Id = 1, ReviewerName = "Adison", ReviewText = "Olive Garden is great. I'll porbably eat there for lunch again tomorrow.", RestaurantsId = 1 });

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, UserName = "foodlover247", Password = "hamburgerz" },
                new UserModel { Id = 2, UserName = "foodcritic101", Password = "potato7" });
        }

        public DbSet<ReviewSite.Models.UserModel> UserModel { get; set; }


    }
}
