using core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace service.test
{
    public class CartCalculatorTests
    {
        private service.CartCalculator _cartCalculator;

        public CartCalculatorTests()
        {
            List<CartItem> testItems = new List<CartItem>
            {
                new CartItem() { Name = "soup", Price = 0.65m, Unit = "tin(s)", Quantity = 2},
                new CartItem() { Name = "bread", Price = 0.8m, Unit = "loaf(s)", Quantity = 1},
                new CartItem() { Name = "milk", Price = 1.3m, Unit = "bottle(s)", Quantity = 0},
                new CartItem() { Name = "apples", Price = 1m, Unit = "bag(s)", Quantity = 0}
            };

            _cartCalculator = new CartCalculator(testItems);
            _cartCalculator.ApplyDiscounts();
        }

        [Fact]
        public void TestSubTotal()
        {
            Assert.Equal(2.1m, _cartCalculator.SubTotal);
        }

        [Fact]
        public void TestTotal()
        {
            Assert.Equal(1.7m, _cartCalculator.Total);
        }
    }
}
