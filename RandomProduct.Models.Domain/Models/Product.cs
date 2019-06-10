using System;
using System.Collections.Generic;
using System.Text;

namespace RandomProduct.Models.Domain.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public Product() { }

        public Product(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Cost = product.Cost;
        }
    }
}
