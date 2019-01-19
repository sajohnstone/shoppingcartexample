using System;
using System.Collections.Generic;
using core;

namespace service
{
    public class Mock
    {
        /// <summary>
        /// This simply mocks the assumption of some kind of persistance
        /// </summary>
        public Mock()
        {
        }

        public static readonly List<Product> StockItems = new List<Product>
        {
            new Product() { Name = "soup", Price = 0.65m, Unit = "tin(s)"},
            new Product() { Name = "bread", Price = 0.8m, Unit = "loaf(s)"},
            new Product() { Name = "milk", Price = 1.3m, Unit = "bottle(s)"},
            new Product() { Name = "apples", Price = 1m, Unit = "bag(s)"}
        };

        public static readonly Dictionary<string, IDiscount> Discounts = new Dictionary<string, IDiscount>
        {
            {"apples", new DiscountPercentOff(10) },
            {"soup", new DiscountPercentWhenBuyItem(50, "bread", 2) }
        };
    }
}
