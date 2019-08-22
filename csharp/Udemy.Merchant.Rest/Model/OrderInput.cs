using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Udemy.Merchant.Rest.Model
{
 
    public class OrderInput
    {
        public IEnumerable<int> ProductIds { get; set; }
        public int CustomerId { get; set; } // assume this comes from login Token
        public int SupplierId { get; set; }
    }
}