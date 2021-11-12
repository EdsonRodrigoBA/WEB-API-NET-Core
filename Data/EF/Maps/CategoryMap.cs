using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Table
            builder.ToTable("Category");

            //Key
            builder.HasKey(x => x.Id);

            //Collums
            builder.Property(p => p.Name).HasColumnType("Varchar(250)").IsRequired(true);
            builder.Property(p => p.Description).HasColumnType("Varchar(300)").IsRequired(true);

      
         


        }


    }
}
