using Udemy.Merchant.Bus.Model;

namespace Udemy.Merchant.Bus.Messages
{
    public class PutOrderNotification
    {
        public Order Order { get; set; }
    }
}