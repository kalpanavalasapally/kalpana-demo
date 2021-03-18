using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class EmployeeDBAccessLayer
    {
        SqlConnection con = new SqlConnection("Server=tcp:coremvcdatabase.database.windows.net,1433;Initial Catalog=CoreMvcDB;Persist Security Info=False;User ID=naveenbest;Password=Conduent@123;MultipleActiveResultSets=False;Encrypt = True; TrustServerCertificate=False;Connection Timeout = 30;");
        public string AddEmployeeRecord(EmployeeEntities employeeEntities)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Name", employeeEntities.Emp_Name);
                cmd.Parameters.AddWithValue("@City", employeeEntities.City);
                cmd.Parameters.AddWithValue("@State", employeeEntities.State);
                cmd.Parameters.AddWithValue("@Country", employeeEntities.Country);
                cmd.Parameters.AddWithValue("@Department", employeeEntities.Department);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
