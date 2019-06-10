using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomProduct.Contracts;
using RandomProduct.Extensions;
using RandomProduct.Models.Domain.Constants;
using RandomProduct.Models.Domain.Enums;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Engines.Discount.Rules
{
    public class DiscountOnMoreThanTwoBagOfPogsDiscountRule : IDiscountRule
    {
        public Guid Id => new Guid("8dc7740b-d73f-4cc5-8aa0-4b5d8a531d78");

        public Action<ProductInBasket> Action => (x) => x.Cost = x.Cost / 2;

        public DiscountRuleResult ReviseBasket(Basket basket)
        {
            var products = basket.GetAll();

            if (products.Count(x =>
                    x.Id.Equals(Constants.ProductIds.BAG_OF_POGS_ID, StringComparison.InvariantCultureIgnoreCase)) <= 1)
                return null;


            var ids = products
                .Where(x => x.Id.Equals(Constants.ProductIds.BAG_OF_POGS_ID,
                    StringComparison.InvariantCultureIgnoreCase))
                .Skip(1)
                .Select(x => x.ProductInBasketId);

            return new DiscountRuleResult(Id, DiscountRuleType.Discount, ids, Action);
        }
    }
}
