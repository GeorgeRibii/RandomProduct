using System;
using System.Collections.Generic;
using System.Text;

namespace RandomProduct.Models.Domain.Models
{
    public class DiscountRuleResult
    {
        public Guid DiscountRuleId { get; }

        public IEnumerable<ProductInBasket> ProductsChangeSet { get; }

        public DiscountRuleResult(Guid discountRuleId, IEnumerable<ProductInBasket> productsChangeSet)
        {
            DiscountRuleId = discountRuleId;
            ProductsChangeSet = productsChangeSet;
        }
    }
}
