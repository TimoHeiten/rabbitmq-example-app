using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Udemy.Merchant.Bus.Model;

namespace Udemy.Merchant.Bus.Messages
{
    public class ProductResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }
}