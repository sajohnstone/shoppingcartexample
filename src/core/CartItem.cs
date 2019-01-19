using System;
namespace core
{
    public class CartItem : Item
    {
        public CartItem()
        {
            this.Quantity = 1;
        }

        public CartItem(Item item)
        {
            //TODO: Could use an automapper here, but 
            //I didn't want to cluter the code.
            this.Name = item.Name;
            this.Price = item.Price;
            this.Quantity = 1;
            this.Unit = item.Unit;
            this.Currency = item.Currency;
        }

        public bool HasDiscount
        {
            get
            {
                return (!String.IsNullOrEmpty(DiscountDescription));
            }
        }
        public string DiscountDescription { get; set; }
        public int Quantity { get; set; }
        public Decimal Total { get { return this.Quantity * this.Price; } }
    }
}
