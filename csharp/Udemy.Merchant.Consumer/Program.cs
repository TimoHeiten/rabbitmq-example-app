using System;
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

            var repository = new Repository();
            repository.InitializeDatabase();
            var products = repository.GetProducts();
            foreach (var item in products)
            {
                System.Console.WriteLine(item.ToString());
            }

            System.Console.WriteLine("press any key to quit");
            
            Console.ReadKey();
        }
    }
}
