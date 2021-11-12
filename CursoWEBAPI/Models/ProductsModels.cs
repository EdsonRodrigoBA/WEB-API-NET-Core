using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoWEBAPI.Models
{
    public class ProductsGet
    {

        public int Id { get; set; }

        public String name { get; set; }

        public decimal price { get; set; }

        public int category_Id { get; set; }

        public String  category_Name { get; set; }


    }

    public class ProductsAddEdit
    {

     
        [Required(ErrorMessage ="O nome é obrigatório.")]
        public String name { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage ="Valor Invalido")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public int category_Id { get; set; }

    }

    public static class ProductModelExtensions
    {

        public static ProductsGet toProductGet(this Products Products)
        {
            return new ProductsGet()
            {
                Id = Products.Id,
                name = Products.name,
                price = Products.price,
                category_Id = Products.Category_Id,
                category_Name = Products.Category?.Name


            };
        }

        public static Products toProducts(this ProductsAddEdit productsAddEdit)
        {
            return new Products()
            {
             
                name = productsAddEdit.name,
                price = productsAddEdit.price,
                Category_Id = productsAddEdit.category_Id,
                

            };
        }
    }
}
