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

        private static SqlConnection CreateConnection(string connKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connKey].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            return sqlConnection;
        }


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

        public static DataTable GetTreeviewCandidate()
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("Select distinct DepartmentLevel1  from CANDIDATE");

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;       
        }

        public static DataTable GetTreeviewCandidateDP1()
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("Select distinct DepartmentLevel2 from CANDIDATE where DepartmentLevel1 = DepartmentLevel1");

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable GetTreeviewCandidateDP2()
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("Select distinct DepartmentLevel3 from CANDIDATE where DepartmentLevel2 = DepartmentLevel2");

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable GetTreeviewCandidateDP3()
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("Select distinct DepartmentLevel4 from CANDIDATE where DepartmentLevel3 = DepartmentLevel3");

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }







        


    }
}