using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Category : Entity
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }
        public List<Products> Products { get; set; }



        public void Update(String Name, String Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }

    
}
