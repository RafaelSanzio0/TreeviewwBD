using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library
{
    public static class DataLayer
    {
        public static DataTable GetUserDepartment(string userLogin)
        {
            DataTable datatable = new DataTable();
            string command = string.Format("select * from SIMPLAD_DEPARTMENT t1 inner join SIMPLAD_DEPARTMENT_USER t2 on t1.DepartmentID = t2.DepartmentID where t2.UserID = '{0}' ", userLogin);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(datatable);
                }
            }

            return datatable;
        }

        public static DataTable GetComputerUser(string userLogin)
        {
            DataTable datatable = new DataTable();
            string command = string.Format("select * from RUM_COMPUTER where UserLogon = '{0}'", userLogin);

            using (SqlConnection sqlConnection = CreateConnection("SELF_MIGRATE2"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(datatable);
                }
            }

            return datatable;
        }

        private static SqlConnection CreateConnection(string connKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connKey].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            return sqlConnection;
        }


    }
}