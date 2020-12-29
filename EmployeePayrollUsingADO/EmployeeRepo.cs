using System;
using System.Collections.Generic;
using System.Data;
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
                    Console.WriteLine("\nDatabased Connection OK !");
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

                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}", employeeModel.id, employeeModel.name, employeeModel.basic_pay, employeeModel.start_date, employeeModel.gender, employeeModel.address,
                                employeeModel.phone_number, employeeModel.department, employeeModel.deduction, employeeModel.taxable_pay, employeeModel.income_tax, employeeModel.net_pay);
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

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", model.id);
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@basic_pay", model.basic_pay);
                    command.Parameters.AddWithValue("@start_date", model.start_date);
                    command.Parameters.AddWithValue("@gender", model.gender);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@phone_number", model.phone_number);
                    command.Parameters.AddWithValue("@department", model.department);
                    command.Parameters.AddWithValue("@deduction", model.deduction);
                    command.Parameters.AddWithValue("@taxable_pay", model.taxable_pay);
                    command.Parameters.AddWithValue("@income_tax", model.income_tax);
                    command.Parameters.AddWithValue("@net_pay", model.net_pay);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
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
