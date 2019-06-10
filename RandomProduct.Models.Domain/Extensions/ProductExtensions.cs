using System;
using System.Collections.Generic;
using System.Text;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Models.Domain.Extensions
{
    public static class ProductExtensions
    {
        public static ProductInBasket ToProductInBasket(this Product product)
        {
            return new ProductInBasket(product);
        }
    }
}
