using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Udemy.Merchant.Bus.Model
{
    public class Order
    {
        public IEnumerable<Product> Products { get; set; }
        public int CustomerId { get; set; }

        public override string ToString()
        {
            string products = string.Join(" ", Products.Select(x => $"{x.ToString()}"));
            return $"Order for Customer: {CustomerId}\n{products}";
        }
    }
}