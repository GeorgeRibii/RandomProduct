using System;
using System.Collections.Generic;
using RandomProduct.Models.Domain.Enums;

namespace RandomProduct.Models.Domain.Models
{
    public class DiscountRuleResult
    {
        public Guid DiscountRuleId { get; }
        public DiscountRuleType DiscountRuleType { get; }

        public IEnumerable<Guid> ProductIds { get; }
        public Action<ProductInBasket> Action { get; }
        public IEnumerable<ProductInBasket> AdditionalProducts { get; }

        public DiscountRuleResult(Guid discountRuleId, DiscountRuleType type, IEnumerable<Guid> productIds, Action<ProductInBasket> action)
        {
            DiscountRuleId = discountRuleId;
            DiscountRuleType = type;
            ProductIds = productIds;
            Action = action;
        }

        public DiscountRuleResult(Guid discountRuleId, DiscountRuleType type, IEnumerable<ProductInBasket> additionalProducts)
        {
            DiscountRuleId = discountRuleId;
            DiscountRuleType = type;
            AdditionalProducts = additionalProducts;
        }
    }
}
