using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Udemy.Merchant.Bus.Model;

namespace Udemy.Merchant.Bus.Messages
{
    public class NotifySupplier
    {
        public int SupplierId { get; set; }
        public string[] ProductNumbers { get; set; }
        public int CustomerId { get; set; }
    }
}