using Xunit;
using core;

namespace Prime.UnitTests.Services
{
    public class CartItemTests
    {
        private readonly CartItem _cartItem;

        public CartItemTests()
        {
            _cartItem = new CartItem();
        }

        [Fact]
        public void HasDiscountTrue()
        {
            _cartItem.DiscountDescription = "test";
            bool result = _cartItem.HasDiscount;

            Assert.True(result, "Has discount should be true");
        }

        [Fact]
        public void HasDiscountFalse()
        {
            _cartItem.DiscountDescription = "";
            bool result = _cartItem.HasDiscount;

            Assert.False(result, "Has discount should be false");
        }
    }
}