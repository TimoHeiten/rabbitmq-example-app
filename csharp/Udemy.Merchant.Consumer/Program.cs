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

            var repository = new Repository();
            var products = repository.GetProducts();
            foreach (var item in products)
            {
                System.Console.WriteLine(item.ToString());
            }

            var order = new Bus.Messages.OrderMessage
            {
                CustomerId = 1,
                SupplierId = 1,
                ProductIds = products.Select(x => x.Id).ToArray()
            };

            repository.InsertOrder(order);
            

            System.Console.WriteLine("press any key to quit");
            
            Console.ReadKey();
        }
    }
}
