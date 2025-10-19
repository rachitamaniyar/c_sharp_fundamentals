using System;

namespace Shop_system
{
    internal class Shop
    {
        // Dictionary to hold products with their unique product numbers
        private readonly Dictionary<int, Product> _inventory;
        decimal totalPrice = 0;  //for task 6: track total

        // Constructor initializes the dictionary and adds products
        public Shop()
        {
            _inventory = new Dictionary<int, Product>
            {
                { 101, new Product("Coffee",     2.50m, 10)       },
                { 102, new DiscountedProduct("Tea Pack", 3.00m, 20, 10m) },
                { 103, new Product("Cookie",     1.00m, 15)       },
                { 104, new DiscountedProduct("Chocolate", 5.00m, 5, 20m) }
            };
            // Add some products (Product and DiscountedProduct)
            _inventory.Add(111, new Product("Laptop", 899.99m, 5));
            _inventory.Add(112, new Product("Mouse", 29.99m, 10));
            _inventory.Add(113, new DiscountedProduct("Keyboard", 79.99m, 5, 10));
            _inventory.Add(114, new DiscountedProduct("Monitor", 299.99m, 3, 15));
            _inventory.Add(115, new DiscountedProduct("Headphones", 149.99m, 7, 20));

        }


        // Private method to display products
        public void ShowProducts()
        {
            Console.WriteLine("\nAvailable Products:");
            Console.WriteLine("-------------------");

            foreach (var item in _inventory)
            {
                int productNumber = item.Key;
                Product product = item.Value;

                Console.WriteLine($"Product Number: {productNumber}");
                product.ShowProductLabel();
                Console.WriteLine();
            }
        }
        private decimal Buy(int productNumber)
        {
            if (!_inventory.TryGetValue(productNumber, out var product))
            {
                Console.WriteLine($"Product number {productNumber} is invalid.");
                return 0;
            }
            else
            {

                try
                {
                    decimal price = (decimal)product.AddToCart();
                    Console.WriteLine($"Product #{productNumber} with price {price:C} successfully added to cart!.");
                    return price;
                }
                catch (InvalidOperationException ex)
                {
                    // Handle out-of-stock exception
                    Console.WriteLine($"Error in adding product to cart: {ex.Message}");
                    return 0;
                }
                catch (Exception ex)
                {
                    // Handle any other exceptions
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}. Please try again later.");
                    return 0;
                }
            }
        }

        public void Start()
        {
           
            bool shopping = true;

            Console.WriteLine("WELCOME TO MY ONLINE SHOP!");
          

            // Main shopping loop
            while (shopping)
            {
                // Show products
                ShowProducts();

                // Get user input
                Console.WriteLine("Enter a product number to buy, or 'x' to finish shopping:");
                Console.Write("");
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("No input received! Please enter a valid product number or 'x'.");
                    continue;
                }

                // Process input
                if (input.ToLower() == "x")
                {
                    shopping = false;
                    Console.WriteLine("Thank you for shopping with us!");
                }
                else
                {
                    // Try to parse as integer
                    if (int.TryParse(input, out int productNumber))
                    {
                        // Buy product and add price to total
                        decimal price = Buy(productNumber);
                        totalPrice += price;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid product number or 'x'.");
                    }
                }

                // Pause before next iteration
                if (shopping)
                {
                    // Display total (Task 6)
                    Console.WriteLine($"TOTAL AMOUNT: {totalPrice:C}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
