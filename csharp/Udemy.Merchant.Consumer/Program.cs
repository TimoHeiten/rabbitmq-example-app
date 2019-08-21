using System;

namespace Udemy.Merchant.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumerFactory.StartConsumeOrder();
            ConsumerFactory.StartRespondingProducts();
            ConsumerFactory.StartConsumingSupplierNotifications();

            System.Console.WriteLine("press any key to quit");

            Console.ReadKey();
        }
    }
}
