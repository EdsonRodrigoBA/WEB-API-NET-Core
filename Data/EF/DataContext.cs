using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataContext(IConfiguration config)
        {
           
                _config = config;
                Database.EnsureCreated();
           

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {


                optionsBuilder.UseSqlServer(_config.GetConnectionString("WebAPIConnection"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {


                modelBuilder.ApplyConfiguration(new Maps.ProductsMaps());
                modelBuilder.ApplyConfiguration(new Maps.CategoryMap());

                modelBuilder.Seed();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
