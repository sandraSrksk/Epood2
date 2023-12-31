﻿namespace Epood.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string CreditCardNo { get; set; }
        public string CreditCardCSV { get; set; }
        public string CreditCard { get; set; }
    }
}