using System;
using System.Collections.Generic;
using core;
using System.Linq;

namespace service
{
    public class Cart
    {
        private List<Product> _cartItems = new List<Product>();

        //Construcutor takes a array of items and adds them to the cart
        public Cart(string[] items)
        {
            //validate there are some items
            if (items.Length > 0)
            {
                //check each item in the command line arguments is a valid product
                foreach (string item in items)
                {
                    Product newItem = Mock.StockItems.Find
                        (i => i.Name.Equals(item.ToLower()));

                    if (newItem != null)
                        _cartItems.Add(newItem);
                    else
                    {
                        throw new ArgumentException($"Invalid item {item}");
                    }

                }
            }
            else
            {
                throw new ArgumentException("No items found.");
            }
        }

        //Gets a distinct list of item and qty
        public List<CartItem> CartItems
        {
            get
            {
                List<CartItem> distinctItems = new List<CartItem>();
                //I could use linq here, but a dictionary is quicker (but not as nice to look at)
                foreach (Product prod in _cartItems)
                {
                    CartItem ci = distinctItems.Find
                        (i => (i.Name == prod.Name));

                    if (ci == null)
                    {
                        distinctItems.Add(new CartItem(prod as Item));
                    }
                    else
                    {
                        distinctItems[distinctItems.IndexOf(ci)].Quantity += 1;
                    }
                }
                return distinctItems;
            }
        }
    }
}
