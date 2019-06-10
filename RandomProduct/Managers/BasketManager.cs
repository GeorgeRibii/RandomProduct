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

        public BasketManager(IDiscountEngine discountEngine)
        {
            _discountEngine = discountEngine;

            _basket = new Basket();
        }

        public bool Add(Product product)
        {
            _basket.Add(product);

            var reviseResult = _discountEngine.ReviseBasket(_basket);
        }

        public bool Remove(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public bool BatchRemove(string id)
        {
            throw new NotImplementedException();
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

        private void ApplyDiscountRulesResults(IEnumerable<DiscountRuleResult> discountRulesResults)
        {

        }
    }
}
