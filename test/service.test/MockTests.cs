using System;
using Xunit;

namespace service.test
{
    public class MockTests
    {
        public MockTests()
        {
        }

        [Fact]
        public void TestStockItemsAreThere()
        {
            Assert.Equal(4, service.Mock.StockItems.Count);
        }

        [Fact]
        public void TestDiscountsAreThere()
        {
            Assert.Equal(2, service.Mock.Discounts.Count);
        }
    }
}
