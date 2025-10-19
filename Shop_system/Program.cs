using System;
using System.Text;

namespace Shop_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set console encoding to UTF-8 to support currency symbol
            //https://www.answeroverflow.com/m/1168217557916975274
            Console.OutputEncoding = Encoding.UTF8;
            // Create shop instance
            Shop myShop = new Shop();

            // Start shopping
            myShop.Start();

            // Keep console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
