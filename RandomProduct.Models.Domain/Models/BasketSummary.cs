using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomProduct.Models.Domain.Models
{
    public class BasketSummary
    {
        public IEnumerable<BasketSummaryProduct> Products { get; }
        public decimal Total { get; }

        public BasketSummary(IEnumerable<BasketSummaryProduct> products)
        {
            Products = products;
            Total = products.Sum(p => p.Total);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("=== Basket Summary ===");
            builder.AppendLine("===");

            foreach (var product in Products)
            {
                builder.AppendLine(
                    $"=== * {product.Name} \t {product.Description} \t {product.Quantity} \t {product.Total}");
            }

            builder.AppendLine("===");
            builder.AppendLine($"=== Total: {Total}");

            return builder.ToString();
        }
    }
}
