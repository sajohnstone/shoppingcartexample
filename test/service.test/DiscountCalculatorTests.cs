using core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace service.test
{
    public class DiscountCalculatorTests
    {
        private service.DiscountPercentOff _discountPercentOff;
        private service.DiscountPercentWhenBuyItem _discountPercentWhenBuyItem;
        private List<CartItem> _testItems = new List<CartItem>
        {
            new CartItem() { Name = "soup", Price = 0.65m, Unit = "tin(s)", Quantity = 2},
            new CartItem() { Name = "bread", Price = 0.8m, Unit = "loaf(s)", Quantity = 1},
            new CartItem() { Name = "milk", Price = 1.3m, Unit = "bottle(s)", Quantity = 0},
            new CartItem() { Name = "apples", Price = 1m, Unit = "bag(s)", Quantity = 4}
        };

        public DiscountCalculatorTests()
        {
            _discountPercentOff = new DiscountPercentOff(10);
            _discountPercentWhenBuyItem = new DiscountPercentWhenBuyItem(50, "bread", 2);
        }

        [Fact]
        public void TestDiscountPercentOff()
        {
            _discountPercentOff.ApplyDiscount(_testItems, "apples");
            Assert.Equal(0.4m, _testItems.Sum(x => x.DiscountAmount));
        }

        [Fact]
        public void TestdiscountPercentWhenBuyItem()
        {
            _discountPercentWhenBuyItem.ApplyDiscount(_testItems, "soup");
            Assert.Equal(0.4m, _testItems.Sum(x => x.DiscountAmount));
        }
    }
}
