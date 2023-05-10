using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            //tiene un primary key
            entityTypeBuilder.HasKey(x => x.ProductId);
            entityTypeBuilder.Property(x=> x.Name).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x=>x.Description).IsRequired().HasMaxLength(500);


            //product by default

            var products = new List<Product>();
            var random = new Random();

            for(var i = 1; i <= 100; i++)
            {
                products.Add(new Product()
                {
                    ProductId = i,
                    Name= $"Producto {i}",
                    Description = $"Description for default {i}",
                    Price = random.Next(100,1000),
                   
                });

            }

            //tiene data inicial
            entityTypeBuilder.HasData(products);
        }




    }
}
