using System;
using System.Linq;
using RandomProduct.Contracts;
using RandomProduct.Models.Domain.Constants;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Engines.Discount.Rules
{
    public class TotalDiscountForHundredShurikensDiscountRule: IDiscountRule
    {
        public Guid Id => new Guid("53331526-ccc0-42e5-87be-7be06a7c65b1");

        public DiscountRuleResult ReviseBasket(Basket basket)
        {
            var products = basket.GetAll();

            if (products.Count(x =>
                    x.Id.Equals(Constants.ProductIds.SHURIKEN_ID, StringComparison.InvariantCultureIgnoreCase)) < 100)
                return null;

            var changeSet = products.Select(x =>
            {
                var p = new ProductInBasket(x) {Cost = x.Cost - x.Cost * 0.3M};

                return p;
            });

            return new DiscountRuleResult(Id, changeSet);
        }
    }
}
