﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Isrequired yazmasak da zorunlu olurdu (çünkü alanı nullable değil)

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            //non-nullable old için Isrequired gereksiz
            builder.Property(x => x.Price).IsRequired().HasPrecision(18,2);

            //nullable old için yazamasak da olurdu
            builder.Property(x => x.PictureUri).IsRequired(false);

            //aşağıdakilerde olmasa olur. çünkü product sınıfında ef geleneğine uygun yazarak ilişkileri belirlemiştik
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId);
        }
    }
}
