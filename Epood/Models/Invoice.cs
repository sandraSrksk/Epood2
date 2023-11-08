namespace Epood.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public Booking Booking { get; set; }
        public decimal TotalPayable { get; set; }
        public bool IsPaid { get; set; }
    }
}