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
    class InvoicesByAgent
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<Employee> InvoicesBySalesAgent()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"select e.firstname, e.lastname, i.invoiceId
                                    from employee e
	                                    join customer c
		                                    on c.SupportRepId = e.EmployeeId
			                            join invoice i 
				                            on i.customerId = c.customerId
                                        where e.title = 'Sales Support Agent'";

                var reader = cmd.ExecuteReader();

                var employees = new List<Employee>();

                while (reader.Read()) //while reader.Read is true
                {
                    var employee = new Employee
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        InvoiceId = int.Parse(reader["InvoiceId"].ToString())
                    };

                    employees.Add(employee);
                }

                return employees;
            } //calls dispose() when the using stateme
        }
    }


}
