using System;
using System.Collections.Generic;
using System.Text;

namespace RandomProduct.Models.Domain.Models
{
    public class ProductInBasket : Product
    {
        public Guid ProductInBasketId { get; set; }

        public ProductInBasket(Product product) : base(product)
        {
            ProductInBasketId = Guid.NewGuid();
        }
    }
}
