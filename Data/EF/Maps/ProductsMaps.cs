using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.Maps
{
    public class ProductsMaps : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            //Table
            builder.ToTable("Products");
            
            //Key
            builder.HasKey(x => x.Id);

            //Collums
            builder.Property(p => p.name).HasColumnType("Varchar(300)").IsRequired(true);
            builder.Property(p => p.price).HasColumnType("decimal(18,2)");


            builder
            .HasOne<Category>(categorys => categorys.Category)
            .WithMany(products => products.Products)
            .HasForeignKey(productCategoryFK => productCategoryFK.Category_Id);

        }


    }
}
