using System;
using System.Collections.Generic;
using System.Text;
using RandomProduct.Contracts;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Managers
{
    public class BasketManager : IBasketManager
    {
        private readonly IDiscountEngine _discountEngine;

        private readonly Basket _basket;
        private readonly List<DiscountRuleResult> _appliedDiscountRules;

        public BasketManager(IDiscountEngine discountEngine)
        {
            _discountEngine = discountEngine;

            _basket = new Basket();
            _appliedDiscountRules = new List<DiscountRuleResult>(0);
        }

        public void Add(Product product)
        {
            _basket.Add(product);
            RefreshDiscountRules();
        }

        public bool Remove(Product product)
        {
            var result = _basket.Remove(product);
            RefreshDiscountRules();

            return result;
        }

        public bool Remove(string id)
        {
            var result = _basket.Remove(id);
            RefreshDiscountRules();

            return result;
        }

        public bool BatchRemove(string id)
        {
            var result = _basket.BatchRemove(id);

            RefreshDiscountRules();

            return result;
        }

        public bool Clear()
        {
            _basket.Clear();

            return _basket.IsEmpty;
        }

        public string Display()
        {
            throw new NotImplementedException();
        }

        private void RefreshDiscountRules()
        {
            var results = _discountEngine.ReviseBasket(_basket);
            _appliedDiscountRules.Clear();
            _appliedDiscountRules.AddRange(results);
        }
    }
}
