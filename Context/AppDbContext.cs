using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>()
                            .Property(c => c.Name)
                                .HasMaxLength(100)
                                    .IsRequired();

            modelBuilder.Entity<Category>()
                            .HasData(
                                new Category()
                                {
                                    CategoryId = 1,
                                    Name = "Material escolar"
                                },
                                new Category()
                                {
                                    CategoryId = 2,
                                    Name = "Acessórios"
                                }
                            );

            //Product
            modelBuilder.Entity<Product>()
                            .Property(c => c.Name)
                                .HasMaxLength(100)
                                    .IsRequired();

            modelBuilder.Entity<Product>()
                            .Property(c => c.Price)
                                .HasPrecision(12, 2);

            modelBuilder.Entity<Product>()
                            .Property(c => c.Description)
                                .HasMaxLength(255)
                                    .IsRequired();

            modelBuilder.Entity<Product>()
                            .Property(c => c.ImageUrl)
                                .HasMaxLength(255)
                                    .IsRequired();

            modelBuilder.Entity<Category>()
                            .HasMany(g => g.Products)
                                .WithOne(c => c.Category)
                                    .IsRequired()
                                        .OnDelete(DeleteBehavior.Cascade);           

            base.OnModelCreating(modelBuilder);
        }
    }
}