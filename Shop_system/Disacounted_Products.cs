using System;
using System.Globalization;


namespace Shop_system
{
    internal class Discounted_Products : Product
    {
        // Field to store discount as percent
        private decimal DiscountPercentage { get; }
        decimal discountedPrice;
        public DiscountedProduct(
              string name,
              decimal price,
              int stock,
              decimal discountPercentage
          ) : base(name, price, stock)
        {
            DiscountPercentage = discountPercentage;
        }
        public new void ShowProductLabel()
        {
            // base-label
            base.ShowProductLabel();
            //append discount info 
            Console.WriteLine($"DISCOUNT: {DiscountPercentage}%");
            discountedPrice = Price - (Price * DiscountPercentage / 100);
            Console.WriteLine($"Price after discount: {discountedPrice.ToString("C", CultureInfo.CurrentCulture)}");
        }
        // Add to cart, but apply discount in the final message
        public override decimal? AddToCart()
        {
        Price= discountedPrice;
            base.AddToCart();
            //simpler version of the above code snippet. 
            //try
            //{
            //    if (Stock <= 0)
            //    {
            //        throw new Exception($"The product '{Name}' is out of stock!");
            //    }

            //    // reduce stock
            //    Stock--;

            //    // price after discount
            //    Console.WriteLine($"Added '{Name}' to cart with discount ({DiscountPercentage}%): {discountedPrice:C}.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}
            return Price;
        }

    }
}
