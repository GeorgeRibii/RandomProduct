using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomProduct.Contracts;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Engines
{
    public class DiscountEngine: IDiscountEngine
    {
        private readonly List<IDiscountRule> _rules;

        public DiscountEngine()
        {
            _rules = new List<IDiscountRule>(0);
        }

        public void RegisterDiscountRule(IDiscountRule rule)
        {
            if (_rules.Any(x => x.Id == rule.Id))
                return;

            _rules.Add(rule);
        }

        public void RegisterDiscountRules(IEnumerable<IDiscountRule> rules)
        {
            foreach (var rule in rules)
            {
                RegisterDiscountRule(rule);
            }
        }

        public IEnumerable<DiscountRuleResult> ReviseBasket(Basket basket)
        {
            if (!_rules.Any())
                return Array.Empty<DiscountRuleResult>();

            var reviseAggregatedResult = new List<DiscountRuleResult>(0);

            foreach (var rule in _rules)
            {
                var ruleResult = rule.ReviseBasket(basket);
                if (ruleResult != null)
                    reviseAggregatedResult.Add(ruleResult);
            }

            return reviseAggregatedResult;
        }
    }
}
