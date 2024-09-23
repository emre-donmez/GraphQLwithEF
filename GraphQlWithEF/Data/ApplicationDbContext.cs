using GraphQlwithEF.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlwithEF.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductDetail)
            .WithOne(pd => pd.Product)
            .HasForeignKey<ProductDetail>(pd => pd.ProductId);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" },
            new Category { Id = 3, Name = "Books" },
            new Category { Id = 4, Name = "Home Appliances" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 1200, CategoryId = 1 },
            new Product { Id = 2, Name = "T-Shirt", Price = 20, CategoryId = 2 },
            new Product { Id = 3, Name = "Refrigerator", Price = 850, CategoryId = 4 },
            new Product { Id = 4, Name = "Science Fiction Book", Price = 15, CategoryId = 3 },
            new Product { Id = 5, Name = "Smartphone", Price = 800, CategoryId = 1 }
        );

        modelBuilder.Entity<ProductDetail>().HasData(
            new ProductDetail { Id = 1, ProductId = 1, Description = "Highperformancelaptop" },
            new ProductDetail { Id = 2, ProductId = 3, Description = "Energyefficientrefrigerator" },
            new ProductDetail { Id = 3, ProductId = 4, Description = "Bestsellingsciencefiction novel" },
            new ProductDetail { Id = 4, ProductId = 5, Description = "Latest smartphonemodelwith 5G support" }
        );
    }
}