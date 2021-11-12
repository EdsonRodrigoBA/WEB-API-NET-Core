using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoWEBAPI.Models
{
    public class CategoryGet
    {

        public int Id { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }


    }

    public class CategoryAddEdit
    {


        [Required(ErrorMessage = "O nome é obrigatório.")]
        public String Name { get; set; }


        [Required(ErrorMessage = "O nome é obrigatório.")]
        public String Description { get; set; }

    }

    public static class CategoryModelExtensios
    {
        public static CategoryGet ToCategoryGet(this Category data)
        {
            return new CategoryGet()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description
            };
        }

        public static Category toCategory(this CategoryAddEdit categoryAddEdit)

            => new Category()
            {

                Name = categoryAddEdit.Name,
                Description = categoryAddEdit.Description,

            };
    }


}
