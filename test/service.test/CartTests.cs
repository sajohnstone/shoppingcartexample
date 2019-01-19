using System;
using Xunit;

namespace service.test
{
    public class CartTests
    {
        public CartTests()
        {
        }

        private service.Cart _cart;

        [Fact]
        public void TestInvalidItem()
        {
            string[] values = { "Pear" };
            Action act = () => _cart = new service.Cart(values);
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Invalid item Pear", ex.Message);
        }

        [Fact]
        public void TestDistinctItems()
        {
            string[] values = { "Apples","Apples" };
            _cart = new service.Cart(values);
            Assert.Single(_cart.CartItems);
        }
    }
}
