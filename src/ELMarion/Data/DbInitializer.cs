using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ELMarion.Data;

namespace ELMarion.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }


            var products = new Product[]
              {
            new Product{
                        ProductName = "Apple",
                        ProductPrice = 1.24,
                        ProductSKU = 1200},
            new Product{
                        ProductName = "Bacon",
                        ProductPrice = 3.89,
                        ProductSKU = 666},
            new Product{ProductName = "Feta",
                        ProductPrice = 8.99,
                        ProductSKU = 652},
            new Product{ProductName = "Blueberry Pie",
                        ProductPrice = 18.52,
                        ProductSKU = 150}
              };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
