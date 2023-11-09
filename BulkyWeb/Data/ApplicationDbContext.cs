using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BulkyWeb.Data {
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; init; }

        public static ApplicationDbContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<ApplicationDbContext>().
                UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName).Options);
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToCollection("categories");

            var movies = new []
            {
                new Category() { _id = ObjectId.GenerateNewId(), Name = "Toys", DisplayOrder = 1 },
                new Category() { _id = ObjectId.GenerateNewId(), Name = "Clothes", DisplayOrder = 1 },
                new Category() { _id = ObjectId.GenerateNewId(), Name = "Shoes", DisplayOrder = 1 },
                new Category() { _id = ObjectId.GenerateNewId(), Name = "Perfumes", DisplayOrder = 1 },
                new Category() { _id = ObjectId.GenerateNewId(), Name = "Hats", DisplayOrder = 1 },
                new Category() { _id = ObjectId.GenerateNewId(), Name = "Watches", DisplayOrder = 1 },
                new Category() { _id = ObjectId.GenerateNewId(), Name = "Bags", DisplayOrder = 1 },
            };

            modelBuilder.Entity<Category>().HasData(movies);
        }
    }
}
