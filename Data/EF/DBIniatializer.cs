using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
    public static class DBIniatializer
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            try
            {
                Category category = new Category();
                category.Id = 1;
                category.Name = "Almentos";
                category.Description = "Relacionado a Produtos";
                category.dt_change = DateTime.Now;
                category.dt_registrattion = DateTime.Now;

                Category category2 = new Category();
                category2.Id = 2;
                category2.Name = "HIGIENE";
                category2.Description = "Relacionado a HIGIENE";
                category2.dt_change = DateTime.Now;
                category2.dt_registrattion = DateTime.Now;


                modelBuilder.Entity<Category>().HasData(

                    category,
                   category2


               );
                Products products = new Products();
                products.Id = 1;
                products.name = "Feijão Padim";
                products.dt_change = DateTime.Now; 
                products.dt_registrattion = DateTime.Now;
                products.Category_Id = 1;

                products.price = 10;

                Products products2 = new Products();
                products2.Id = 2;
                products2.name = "Papel Higienico";
      
                products2.Category_Id = 2;
                products2.price = 10;
                modelBuilder.Entity<Products>().HasData(
                        products,
                        products2


                    );

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
