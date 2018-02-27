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
    class UpdateEmployee
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public void UpdateEmployeeName(int employeeId, string employeeLastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"update employee
                                    set firstname ='@LastName'
                                    where employeeid = @EmployeeId";

                var employeeIdParam = new SqlParameter("@EmployeeId", SqlDbType.Int);
                employeeIdParam.Value = employeeId;
                cmd.Parameters.Add(employeeIdParam);

                var employeeLastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar);
                employeeLastNameParam.Value = employeeLastName;
                cmd.Parameters.Add(employeeLastNameParam);

                var results = cmd.ExecuteNonQuery();

            } //calls dispose() when the using stateme
        }
    }
}
