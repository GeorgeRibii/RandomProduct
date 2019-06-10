using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomProduct.Contracts;
using RandomProduct.Models.Domain.Enums;
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

        public BasketSummary Summary()
        {
            if (_basket.IsEmpty)
                return null;

            var finalProducts = ApplyRulesSet(_basket, _appliedDiscountRules);

            var groupedProducts = finalProducts.GroupBy(p => p.Id);
            var basketSummaryProducts = new List<BasketSummaryProduct>(0);
            foreach (var productsGroup in groupedProducts)
            {
                basketSummaryProducts.Add(new BasketSummaryProduct(
                    productsGroup.First(), 
                    productsGroup.Count(),
                    productsGroup.Sum(p => p.Cost)));
            }

            return new BasketSummary(basketSummaryProducts);
        }

        private void RefreshDiscountRules()
        {
            var results = _discountEngine.ReviseBasket(_basket);
            _appliedDiscountRules.Clear();
            _appliedDiscountRules.AddRange(results);
        }

        private IEnumerable<ProductInBasket> ApplyRulesSet(Basket basket,
            IEnumerable<DiscountRuleResult> rulesResults)
        {
            var products = basket.GetAll();

            foreach (var discountRuleResult in rulesResults.Where(r => r.DiscountRuleType == DiscountRuleType.Discount))
            {
                foreach (var productInBasket in products.Where(x => discountRuleResult.ProductIds.Contains(x.ProductInBasketId)))
                {
                    discountRuleResult.Action.Invoke(productInBasket);
                }
            }

            foreach (var discountRuleResult in rulesResults.Where(r => r.DiscountRuleType == DiscountRuleType.Extra))
            {
                products.AddRange(discountRuleResult.AdditionalProducts);
            }

            return products;
        }
    }
}
