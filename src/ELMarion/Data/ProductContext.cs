﻿using ELMarion.Models;
using Microsoft.EntityFrameworkCore;

namespace ELMarion.Data
{
    public class ProductContext : DbContext
    {
        //public ProductContext() : base("TestTechELM") 
        //{
        //}
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }

    }
}
