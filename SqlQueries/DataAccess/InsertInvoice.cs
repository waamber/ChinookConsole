using SqlQueries.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueries.DataAccess
{
    class InsertNewInvoice
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public InsertNewInvoice(string firstName, string lastName, int customerId, string billingAddress, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"insert into customer (FirstName, LastName, CustomerId, Address, Email)
                                    values ('@FirstName', '@LastName', @CustomerId, '@CustomerAddress', '@Email')";

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int);
                customerIdParam.Value = customerId;
                cmd.Parameters.Add(customerIdParam);

                var customerAddressParam = new SqlParameter("@CustomerAddress", SqlDbType.NVarChar);
                customerAddressParam.Value = billingAddress;
                cmd.Parameters.Add(customerAddressParam);

                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                firstNameParam.Value = firstName;
                cmd.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar);
                lastNameParam.Value =lastName;
                cmd.Parameters.Add(lastNameParam);

                var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar);
                emailParam.Value = email;
                cmd.Parameters.Add(emailParam);

                var reader = cmd.ExecuteReader();

                var invoices = new List<Invoice>();

                while (reader.Read()) //while reader.Read is true
                {
                    var invoice = new Invoice
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        CustomerId = int.Parse(reader["CustomerId"].ToString()),
                        Address = reader["CustomerAddress"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    invoices.Add(invoice);
                }


            } //calls dispose() when the using stateme
        }
    }
}

