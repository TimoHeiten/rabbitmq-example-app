namespace Udemy.Merchant.Bus.Model
{
    public class OrderedProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}