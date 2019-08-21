using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Udemy.Merchant.Bus.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ArticleNumber { get; set; }
        public int SupplierId { get; set; }

        public override string ToString()
        {
            return $"[Id:{Id}, Name:{Name}, Price:{Price}, ArticleNumber: {ArticleNumber}, SupplierId: {SupplierId}]";
        }
    }
}