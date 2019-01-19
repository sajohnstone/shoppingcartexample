using System;
using System.Collections.Generic;
using System.Linq;
using core;

namespace service
{
    public class CartCalculator
    {
        private List<CartItem> _cartItems = new List<CartItem>();
        public CartCalculator(List<CartItem> cartItems)
        {
            this._cartItems = cartItems;
        }


        public decimal Total
        {
            get
            {
                decimal discount = _cartItems.Sum(x => x.DiscountAmount);
                return SubTotal - discount;
            }
        }

        public decimal SubTotal
        {
            get
            {
                return _cartItems.Sum(x => x.Total);
            }
        }

        public string DiscountDescriptions
        {
            get
            {
                string desc = "";
                foreach (CartItem ci in _cartItems)
                {
                    if (ci.HasDiscount) desc += ci.DiscountDescription + "\n";
                }
                return desc;
            }
        }

        public void ApplyDiscounts()
        {
            //clear discount descs
            foreach (CartItem ci in _cartItems)
            {
                ci.DiscountAmount = 0;
                ci.DiscountDescription = "";
            }
            //apply discounts
            foreach (KeyValuePair<string, IDiscount> discount in Mock.Discounts)
            {
                discount.Value.ApplyDiscount(_cartItems, discount.Key);
            }
        }
    }
}
