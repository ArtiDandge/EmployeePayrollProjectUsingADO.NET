using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollUsingADO
{
    public class EmployeeRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
      
         public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT * FROM employee_payroll ";

                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();
                    Console.WriteLine("\nDatabased Connected");
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.id = dr.GetInt32(0);
                            employeeModel.name = dr.GetString(1);
                            employeeModel.basic_pay = Convert.ToDouble(dr.GetDecimal(2));
                            employeeModel.start_date = dr.GetDateTime(3);
                            employeeModel.gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.address = dr.GetString(5);
                            employeeModel.phone_number = dr.GetString(6);
                            employeeModel.department = dr.GetString(7);
                            employeeModel.deduction = Convert.ToDouble(dr.GetDecimal(8));
                            employeeModel.taxable_pay = Convert.ToDouble(dr.GetDecimal(9));
                            employeeModel.income_tax = Convert.ToDouble(dr.GetDecimal(10));
                            employeeModel.net_pay = Convert.ToDouble(dr.GetDecimal(11));

                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", employeeModel.id, employeeModel.name, employeeModel.basic_pay, employeeModel.start_date, employeeModel.gender, employeeModel.address);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
         }
    }
}
