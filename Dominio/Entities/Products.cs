using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Products : Entity
    {

        public int Id { get; set; }

        public String name { get; set; }

        public decimal price { get; set; }

       // public String Category { get; set; }

        public Category Category { get; set; }

        public int Category_Id { get; set; }

        public void update(int category_Id, decimal price, string name)
        {
            this.name = name;
            this.price = price;
            this.Category_Id = category_Id;
        }
    }
}
