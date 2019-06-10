using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomProduct.Models.Domain.Extensions;

namespace RandomProduct.Models.Domain.Models
{
    public class Basket
    {
        private readonly List<ProductInBasket> _products;
        private readonly List<DiscountRuleResult> _appliedDiscountRules;

        public Basket()
        {
            _products = new List<ProductInBasket>(0);
            _appliedDiscountRules = new List<DiscountRuleResult>(0);
        }

        public bool IsEmpty => _products.Count == 0;
        public bool IsRuleApplied(Guid ruleId) => _appliedDiscountRules.Any(x => x.DiscountRuleId == ruleId);

        public void Add(Product product)
        {
            _products.Add(product.ToProductInBasket());
        }

        public bool Remove(string productId)
        {
            var lookup = _products.FirstOrDefault(p => p.Id == productId);

            return lookup != null && Remove(lookup);
        }

        public bool Remove(Product product)
        {
            return _products.Remove(product.ToProductInBasket());
        }

        public void Clear()
        {
            _products.Clear();
        }

        public IEnumerable<ProductInBasket> GetAll()
        {
            return _products.ToList(); // Avoid returning reference but copy
        }

        public void UpdateRules(IEnumerable<DiscountRuleResult> rulesResults)
        {
            _appliedDiscountRules.Clear();
            _appliedDiscountRules.AddRange(rulesResults);
        }
    }
}
