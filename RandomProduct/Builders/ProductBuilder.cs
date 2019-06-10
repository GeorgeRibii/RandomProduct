using System;
using System.Collections.Generic;
using System.Text;
using RandomProduct.Models.Domain.Constants;
using RandomProduct.Models.Domain.Models;

namespace RandomProduct.Builders
{
    /// <summary>
    /// Used to create a predefined products.
    /// In real world - this should not be used, but products must be predefined in data storage.
    /// </summary>
    public static class ProductBuilder
    {
        public enum ProductType
        {
            Shuriken = 1,
            BagOfPogs = 2,
            LargeBowlOfTrifle = 3,
            PaperMask = 4
        }

        public static Product BuildProduct(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Shuriken:
                    return BuildShuriken();
                case ProductType.BagOfPogs:
                    return BuildBagOfPogs();
                case ProductType.LargeBowlOfTrifle:
                    return BuildLargBowlOfTrifle();
                case ProductType.PaperMask:
                    return BuildPaperMask();
                default:
                    throw new ArgumentOutOfRangeException(nameof(productType), productType, null);
            }
        }

        private static Product BuildShuriken() => new Product()
        {
            Id = Constants.ProductIds.SHURIKEN_ID,
            Name = "Shuriken",
            Description = "5 pointed Shuriken made from stainless steel",
            Cost = 8.95M
        };

        private static Product BuildBagOfPogs() => new Product()
        {
            Id = Constants.ProductIds.BAG_OF_POGS_ID,
            Name = "Bag of Pogs",
            Description = "25 Random pogs designs",
            Cost = 5.31M
        };

        private static Product BuildLargBowlOfTrifle() => new Product()
        {
            Id = Constants.ProductIds.LARGE_BOWL_OF_TRIFLE,
            Name = "Large bowl of Trifle",
            Description = "Large collectors edition bowl of Trifle",
            Cost = 2.75M
        };

        private static Product BuildPaperMask() => new Product()
        {
            Id = Constants.ProductIds.PAPER_MASK_ID,
            Name = "Paper Mask",
            Description = "Randomly selected paper mask",
            Cost = 0.30M
        };
    }
}
