using System;

namespace SqlQueries.DataAccess.Models
{
    public class Invoice
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get; set; } 
        public string SalesAgent { get; set; }
        public string BillingCountry { get; set; }
        public double Total { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}