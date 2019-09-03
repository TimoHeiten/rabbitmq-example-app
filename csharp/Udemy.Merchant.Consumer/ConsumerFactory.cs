using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyNetQ;
using Udemy.Merchant.Bus;
using Udemy.Merchant.Bus.Messages;
using Udemy.Merchant.Bus.Model;
using Udemy.Merchant.Consumer.Data;
using EasyNetQ.Topology;

namespace Udemy.Merchant.Consumer
{
    internal static class ConsumerFactory
    {
        public static IBus s_Bus;
        private static Repository s_repository = new Repository();

        static ConsumerFactory()
        {
           s_Bus = Factory.PrepareBus("dotnet_user", "dotnet");
        }

        public static void StartConsumeOrder()
        {
            s_Bus.SubscribeAsync<PutOrderNotification>("orders", 
            async message => 
            {
                s_repository.InsertOrder(message.Order);
                await PublishNotification(message.Order);
            });
        }

        public static void StartRespondingProducts()
        {
            s_Bus.RespondAsync<ProductRequest, ProductResponse>(request => 
            {
                var products = s_repository.GetProducts();
                var response = new ProductResponse
                {
                    Products = products.ToArray()
                };
                return Task.FromResult(response);
            });

        }

        public static void StartConsumingSupplierNotifications()
        {
            // todo connect with advanced bus to existing queue
        }

        public static async Task PublishNotification(OrderMessage order)
        {
            // --> fanout!
            var products = s_repository.GetProducts();
            var relevant = order.ProductIds;
            var numbers = products.Where(y => relevant.Any(n => n == y.Id))
                                  .Select(x => x.ArticleNumber);

            var notify = new NotifySupplier
            {
                CustomerId = order.CustomerId,
                SupplierId = order.SupplierId,
                ProductNumbers = numbers.ToArray()
            };
            
            var advanced = s_Bus.Advanced;
            IExchange ex = advanced.ExchangeDeclare("notifications", "fanout", passive:true);
            IMessage<NotifySupplier> msg = new PushOrder(notify);

            await advanced.PublishAsync(ex, "", mandatory:true, message:msg);
        }

        private class PushOrder : IMessage<NotifySupplier>
        {
            private NotifySupplier notify;

            public PushOrder(NotifySupplier notify)
            {
                this.notify = notify;
            }

            public NotifySupplier Body => notify;

            public MessageProperties Properties => new MessageProperties();

            public Type MessageType => typeof(NotifySupplier);
 
            public object GetBody()
            {
                return notify;
            }
        }
    }
}