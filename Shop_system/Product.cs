using System;
using System.Globalization;

namespace Shop_system
{
    // Base class for all the products
    internal class Product
    {
        // Protected variables (visible in subclass)
        protected string Name { get; }
        protected decimal Price { get; set; }
        protected int Stock { get; set; }


        // Constructor initializes all variables when the object is created
        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        // Shows information about the product
        public virtual void ShowProductLabel()
        {
            Console.WriteLine($"Name: {Name}, Price: {Price.ToString("C", CultureInfo.CurrentCulture)}, Stock: {Stock}");
        }

        // adding a product to a cart
        // Change the return type of AddToCart from void to decimal? (nullable decimal) to allow returning Price or null in case of error
        public virtual decimal? AddToCart()
        {
            try
            {
                // Check if product is still available
                if (Stock <= 0)
                {
                    throw new Exception($"The product '{Name}' is out of stock!");
                }
                else
                {
                    // Reduce stock by one
                    Stock--;
                    Console.WriteLine($"Added '{Name}' to cart successfully.");
                    return Price;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }
    }
}

