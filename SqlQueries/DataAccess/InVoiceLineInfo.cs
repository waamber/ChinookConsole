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
    class InVoiceLineInfo
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<InvoiceLine> GetInvoiceByInvoiceId(int invoiceId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"select count(invoiceLineId)
                                    from invoiceline
                                    groupBy @InvoiceId";

                var invoiceIdParam = new SqlParameter("@InvoiceId", SqlDbType.Int);
                invoiceIdParam.Value = invoiceId;
                cmd.Parameters.Add(invoiceIdParam);

                var reader = cmd.ExecuteReader();

                var invoices = new List<InvoiceLine>();

                while (reader.Read()) //while reader.Read is true
                {
                    var invoiceinfo = new InvoiceLine
                    {
                        
                        
                    };

                    invoices.Add(invoiceinfo);
                }

                return invoices;
            } //calls dispose() when the using statement is complete
        }
    }
}

