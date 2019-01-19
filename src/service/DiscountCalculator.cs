using System;
using System.Collections.Generic;
using System.Linq;
using core;

namespace service
{
    //Each discount object implements the IDiscount interface
    public interface IDiscount
    {
        decimal Discount { get; set; }
        void ApplyDiscount(List<CartItem> cartItems, string productName);
    }

    //Calculates a discount based on a pcnt off 
    public class DiscountPercentOff : IDiscount
    {
        public decimal Discount { get; set; }

        public DiscountPercentOff(decimal discount)
        {
            this.Discount = discount;
        }

        public void ApplyDiscount(List<CartItem> cartItems, string productName)
        {
            CartItem ci = cartItems.Find
                            (i => (i.Name == productName));

            if (ci == null) return; //if there aren't any products of that type exit

            ci.DiscountAmount = (ci.Price * (this.Discount * 0.01m)) * ci.Quantity;
            ci.DiscountDescription = $"{ci.Name} {this.Discount}% off -{ci.DiscountAmount:C}";
        }
    }

    public class DiscountPercentWhenBuyItem : IDiscount
    {
        public string DiscountedProduct { get; set; }
        public int QuanityRequired { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }

        public DiscountPercentWhenBuyItem(decimal discount, string discountProduct, int quantityRequired)
        {
            this.Discount = discount;
            this.DiscountedProduct = discountProduct;
            this.QuanityRequired = quantityRequired;
        }

        public void ApplyDiscount(List<CartItem> cartItems, string productName)
        {
            CartItem ci = cartItems.Find
                            (i => (i.Name == productName));

            CartItem discountci = cartItems.ToList().Find
                            (i => (i.Name == this.DiscountedProduct));

            if (ci == null || discountci == null) return; //if there aren't any products of that type exit

            if (ci.Quantity >= this.QuanityRequired)
            {
                discountci.DiscountAmount = (discountci.Price * (this.Discount * 0.01m)) * discountci.Quantity;

                discountci.DiscountDescription = $"{this.DiscountedProduct} {this.Discount}% off " +
                    $"when you buy {this.QuanityRequired} {ci.Unit} of {ci.Name} -{discountci.DiscountAmount:C}";
            }
        }

    }

}