using System;
namespace core
{
    public abstract class Item
    {
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
