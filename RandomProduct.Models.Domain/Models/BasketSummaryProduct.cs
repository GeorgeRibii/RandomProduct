using System;
using System.Collections.Generic;
using System.Text;

namespace RandomProduct.Models.Domain.Models
{
    public class BasketSummaryProduct: Product
    {
        public int Quantity { get; }
        public decimal Total { get; }

        public BasketSummaryProduct(Product product, int quantity, decimal total)
            :base(product)
        {
            Quantity = quantity;
            Total = total;
        }
    }
}
