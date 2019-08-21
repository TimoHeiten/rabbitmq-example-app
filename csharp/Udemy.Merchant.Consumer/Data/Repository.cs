using System.Data.Common;
using Dapper;
using System.Collections.Generic;
using Udemy.Merchant.Bus.Model;
using System.Linq;
using System;
using System.Data.SQLite;

namespace Udemy.Merchant.Consumer.Data
{
    internal class Repository
    {
       private string connection = $"DataSource={Environment.CurrentDirectory}/merchant.db;Version=3;foreign keys=true";

       private DbConnection Connection()
       {
           return new SQLiteConnection(connection);
       }

       private string insert_customers = "INSERT INTO customers VALUES (@Id, @Name, @Email)";
       private string insert_suppliers = "INSERT INTO suppliers VALUES (@Id, @Name, @Email)";
       private string insert_products = "INSERT INTO products VALUES (@Id, @SupplierId, @Name, @Price, @ArticleNumber)";
    //    private string insert_orders = "INSERT INTO orders VALUES (@Id, @CustomerId, @ProductId, @SupplierId)";

       public void InsertData(string sql, object[] items)
       {
           using (var con = Connection())
           {
               con.Open();
               int affected = con.Execute(sql, items);
               System.Console.WriteLine($"affected: {0} from {sql}");
           }
       }

       public IEnumerable<Product> GetProducts()
       {
           string sql = "SELECT * FROM products";
           using (var con = Connection())
           {
               con.Open();
               return con.Query<Product>(sql).ToList();
           }
       }

       internal void InitializeDatabase()
       {
            string shouldInit = "SELECT COUNT(*) FROM suppliers";
            var c = Connection();
            c.Open();
            var create = c.CreateCommand();
            create.CommandText = shouldInit;
            long result = (long)create.ExecuteScalar();
               c.Close();
            if (result > 0)
            {
                System.Console.WriteLine("database already initialized");
                return;
            }

           InsertData(insert_customers,
                new object[]
                {
                    new { Id = 1, Name = "customer_1", Email = "customer@merchant.com" },
                    new { Id = 2, Name = "customer_2", Email = "customer@merchant.com" },
                    new { Id = 3, Name = "customer_3", Email = "customer@merchant.com" }
                }
           );
           InsertData(insert_suppliers,
                new object[]
                {
                    new { Id = 1, Name = "the_supplier", Email = "supplier@merchant.com" },
                }
           );
           InsertData(insert_products,
                new object[]
                {
                    new { Id = 1, SupplierId = 1, Name = "product_1", Price=42, ArticleNumber="0815" },
                    new { Id = 2, SupplierId = 1, Name = "product_2", Price=84, ArticleNumber="0816" },
                    new { Id = 3,  SupplierId = 1, Name = "product_3", Price=21, ArticleNumber="0817" }
                }
           );
       }
    }
}