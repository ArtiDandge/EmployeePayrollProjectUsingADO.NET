using System;

namespace EmployeePayrollUsingADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service Project Using ADO.NET Framework!");
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();

            employee.id = 112;
            employee.name = "Abby";
            employee.basic_pay = 50300.00;
            employee.start_date = new DateTime(2019, 12, 02);
            employee.gender = 'F';
            employee.address = "XY Street";
            employee.phone_number = "6556543210";
            employee.department = "Production";
            employee.deduction = 7700.00;
            employee.taxable_pay = 33400.00;
            employee.income_tax = 44400.40;
            employee.net_pay = 550000.00;

            //repo.AddEmployee(employee);
            //repo.GetAllEmployee();
            //repo.GetPerticularEmployeeData();
            repo.AggregateFunctionOperations();
        }
    }
}
