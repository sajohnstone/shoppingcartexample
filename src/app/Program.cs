using System;
using System.Collections.Generic;
using core;
using service;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            //initilise the cart with the requested items
            Cart cart = new Cart(args);
            CartCalculator cartCalculator = new CartCalculator(cart.CartItems);
            cartCalculator.ApplyDiscounts();

            foreach (CartItem cartItem in cart.CartItems)
            {
                Console.WriteLine($"{cartItem.Quantity} x {cartItem.Name} = {cartItem.Total:c}");
            }
            Console.WriteLine($"Subtotal: {cartCalculator.SubTotal:c}");
            Console.Write(cartCalculator.DiscountDescriptions);
            Console.WriteLine($"Total: {cartCalculator.Total:c}");

            Console.ReadKey();
        }
    }
}