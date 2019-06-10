using System;
using System.Collections.Generic;
using System.Text;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Contracts
{
    public interface IDiscountRule
    {
        /// <summary>
        /// Returns fixed Id of rule
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Returns discount rule result in case when rule is applicable. Otherwise returns null
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        DiscountRuleResult ReviseBasket(Basket basket);

        Action<ProductInBasket> Action { get; }
    }
}
