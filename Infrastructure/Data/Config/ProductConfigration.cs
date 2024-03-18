using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Description).IsRequired();
            builder.Property(P => P.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(P => P.PictureURL);
            builder.HasOne(P => P.ProductBrand).WithMany()
                .HasForeignKey(P => P.ProductBrandId);
            builder.HasOne(P => P.ProductTYPE).WithMany()
               .HasForeignKey(P => P.ProductTypeId);
        }
        
     
    }
}
