using System.Collections.Generic;
using Udemy.Merchant.Bus.Model;

namespace Udemy.Merchant.Bus.Messages
{
    public class PutOrderNotification
    {
        public OrderMessage Order { get; set; }
    }

    public class OrderMessage
    {
        public IEnumerable<int> ProductIds { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }

        public override string ToString()
        {
            string products = "[" + string.Join(",", ProductIds) + "]";
            return $"CustomerId:{CustomerId} - SupplierId:{SupplierId} - ProductId: {products}";
        }
    }
}