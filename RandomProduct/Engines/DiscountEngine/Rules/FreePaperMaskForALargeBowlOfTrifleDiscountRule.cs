using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomProduct.Builders;
using RandomProduct.Contracts;
using RandomProduct.Models.Domain.Constants;
using RandomProduct.Models.Domain.Enums;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Engines.Discount.Rules
{
    public class FreePaperMaskForALargeBowlOfTrifleDiscountRule: IDiscountRule
    {
        public Guid Id => new Guid("d8a6f20c-b90e-40ff-a057-a363155781aa");

        public Action<ProductInBasket> Action => null;

        public DiscountRuleResult ReviseBasket(Basket basket)
        {
            var products = basket.GetAll();

            if (!products.Any(x =>
                x.Id.Equals(Constants.ProductIds.LARGE_BOWL_OF_TRIFLE,
                    StringComparison.InvariantCultureIgnoreCase)))
                return null;


            var additionalProducts = new List<ProductInBasket>
            {
                new ProductInBasket(ProductBuilder.BuildProduct(ProductBuilder.ProductType.PaperMask))
            };

            return new DiscountRuleResult(Id, DiscountRuleType.Extra, additionalProducts);
        }
    }
}
