using System;
using System.Linq;
using Udemy.Merchant.Consumer.Data;

namespace Udemy.Merchant.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumerFactory.StartConsumeOrder();
            ConsumerFactory.StartRespondingProducts();
            ConsumerFactory.StartConsumingSupplierNotifications();

            System.Console.WriteLine("started! - consumes messages from now on!");

            System.Console.WriteLine("press any key to quit");
            
            Console.ReadKey();
        }
    }
}
