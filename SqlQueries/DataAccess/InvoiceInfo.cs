using SqlQueries.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueries.DataAccess
{
    class InvoiceInfo
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<Invoice> InvoiceInformation()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"select e.firstname + ' ' + e.lastname as employeeName, 
                                           c.firstname + ' ' + c.lastname as customerName, 
                                           c.country, i.total
                                    from employee e
	                                join customer c
		                                on c.SupportRepId = e.EmployeeId
			                        join invoice i
				                        on i.customerid = c.CustomerId";

                var reader = cmd.ExecuteReader();

                var invoices = new List<Invoice>();

                while (reader.Read()) //while reader.Read is true
                {
                    var invoice = new Invoice
                    {
                        Total = double.Parse(reader["Total"].ToString()),
                        CustomerName = reader["customerName"].ToString(),
                        SalesAgent = reader["employeeName"].ToString(),
                        BillingCountry = reader["country"].ToString()
                    };

                    invoices.Add(invoice);
                }

                return invoices;
            } //calls dispose() when the using stateme
        }
    }
}

