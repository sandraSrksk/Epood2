namespace Epood.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}