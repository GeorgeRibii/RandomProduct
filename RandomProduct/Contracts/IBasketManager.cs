using System;
using System.Collections.Generic;
using System.Text;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Contracts
{
    public interface IBasketManager
    {
        void Add(Product product);

        bool Remove(Product product);
        bool Remove(string id);

        bool BatchRemove(string id);

        bool Clear();

        BasketSummary Summary();
    }
}
