using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyNetQ;
using Udemy.Merchant.Bus;
using Udemy.Merchant.Bus.Messages;
using Udemy.Merchant.Bus.Model;

namespace Udemy.Merchant.Consumer
{
    internal static class ConsumerFactory
    {
        public static IBus s_Bus;

        static ConsumerFactory()
        {
           s_Bus = Factory.PrepareBus("dotnet_user", "dotnet");
        }

        public static void StartConsumeOrder()
        {
            s_Bus.SubscribeAsync<PutOrderNotification>("orders", 
            message => 
            {
                // todo push order to database
                // todo get Products from database
                System.Console.WriteLine(message.Order.ToString());
                // PublishNotification(message.Order);
                return Task.CompletedTask;
            });
        }

        public static void StartRespondingProducts()
        {
            s_Bus.RespondAsync<ProductRequest, ProductResponse>(request => 
            {
                // todo extract from database
                var response = new ProductResponse
                {
                    Products = Enumerable.Range(1, 4)
                        .Select(x => new Product
                        {
                            Id = x,
                            ArticleNumber = $"{x}",
                            Name = $"product_{x}",
                            Price = x*100,
                            SupplierId = 10,
                        }).ToArray()
                };

                return Task.FromResult(response);
            });

        }

        public static void StartConsumingSupplierNotifications()
        {
            // todo connect with advanced bus to existing queue
        }

        public static void PublishNotification(Order Order)
        {
            // todo publish to customer
            // todo publish to subscriber
            // --> external uses (will be simulated)
        }
    }
}