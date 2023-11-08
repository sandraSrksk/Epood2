namespace Epood.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceTransport { get; set; }
        public decimal PriceTotal { get; }
        public ProductType Type { get; set; }
    }
}
