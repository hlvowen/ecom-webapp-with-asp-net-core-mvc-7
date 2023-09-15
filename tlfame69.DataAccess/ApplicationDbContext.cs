using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tflame69.Models.dbo;

namespace tlfame69.DataAccess;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext() { }

    public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
    {

    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This method must be called if using IdentityDbContext
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Action", DisplayOrder = 1},
            new Category() { Id = 2, Name = "Science Fiction", DisplayOrder = 2},
            new Category() { Id = 3, Name = "History", DisplayOrder = 3});

        modelBuilder.Entity<Product>().HasData(
            new Product { 
                    Id = 1, 
                    Title = "Fortune of Time", 
                    Author="Billy Spark", 
                    Description= "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN="SWD9999001",
                    PriceList= 99,
                    Price=90,
                    PriceForMoreThan50= 85,
                    PriceForMoreThan100= 80,
                    CategoryId = 1,
                    ImageUrl = string.Empty
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    PriceList = 40,
                    Price = 30,
                    PriceForMoreThan50 = 25,
                    PriceForMoreThan100 = 20,
                    CategoryId = 2,
                    ImageUrl = string.Empty
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    PriceList = 55,
                    Price = 50,
                    PriceForMoreThan50 = 40,
                    PriceForMoreThan100 = 35,
                    CategoryId = 3,
                    ImageUrl = string.Empty
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    PriceList = 70,
                    Price = 65,
                    PriceForMoreThan50 = 60,
                    PriceForMoreThan100 = 55,
                    CategoryId = 1,
                    ImageUrl = string.Empty
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    PriceList = 30,
                    Price = 27,
                    PriceForMoreThan50 = 25,
                    PriceForMoreThan100 = 20,
                    CategoryId = 2,
                    ImageUrl = string.Empty
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    PriceList = 25,
                    Price = 23,
                    PriceForMoreThan50 = 22,
                    PriceForMoreThan100 = 20,
                    CategoryId = 3,
                    ImageUrl = string.Empty
                }
            );
    }
}