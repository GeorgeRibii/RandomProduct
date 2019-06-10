using System;
using System.Collections.Generic;
using System.Text;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Contracts
{
    public interface IDiscountEngine
    {
        /// <summary>
        /// Revises added products to basket and determines set of changes which should be applied to basket
        /// </summary>
        /// <param name="basket">Basket on which changes must be applied</param>
        /// <returns>Returns set of rules result</returns>
        IEnumerable<DiscountRuleResult> ReviseBasket(Basket basket);

        /// <summary>
        /// Registers discount rule
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        bool RegisterDiscountRule(IDiscountRule rule);

        /// <summary>
        /// Registers set of discount rules
        /// </summary>
        /// <param name="rules"></param>
        /// <returns></returns>
        bool RegisterDiscountRules(IEnumerable<IDiscountRule> rules);
    }
}
