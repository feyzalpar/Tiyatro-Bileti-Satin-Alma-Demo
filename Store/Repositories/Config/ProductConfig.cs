using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();


            builder.HasData(

                    new Product() { ProductId = 1, ImageUrl = "/images/1.jpg", CategoryId = 2, ProductName = "Cadı Kazanı", Price = 17_000 },
                    new Product() { ProductId = 2, ImageUrl = "/images/2.jpg", CategoryId = 2, ProductName = "d", Price = 1_000 },
                    new Product() { ProductId = 3, ImageUrl = "/images/3.jpg", CategoryId = 2, ProductName = "Mouse", Price = 500 },
                    new Product() { ProductId = 4, ImageUrl = "/images/4.jpg", CategoryId = 2, ProductName = "Monitor", Price = 7_000 },
                    new Product() { ProductId = 5, ImageUrl = "/images/5.jpg", CategoryId = 2, ProductName = "Deck", Price = 1_500 },
                    new Product() { ProductId = 6, ImageUrl = "/images/6.jpg", CategoryId = 1, ProductName = "Bilet2", Price = 1_500 },
                    new Product() { ProductId = 7, ImageUrl = "/images/7.jpg", CategoryId = 1, ProductName = "Bilet3", Price = 1_500 }


                );
        }
    }
}
