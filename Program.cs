using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ConsoleBasedApp_AdvancedLINQOperationsinC_
{
    /// <summary>
    /// LINQ - Console Based Lab - Advanced LINQ Operations in C#
    /// Advanced LINQ operations such as GroupBy, Joins, Aggregate, Where, and 
    /// Select on multiple classes in C#
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ - Console Based Lab - Advanced LINQ Operations in C#\n");
          
            //EmployeeBusinessLogic
            EmployeesBusinessLogic ebl = new EmployeesBusinessLogic();

            Console.WriteLine("*--------------GroupBy and Aggregate--------------*\n");
            //Group employees by their departments.
            ebl.GroupEmployeesByTheirDepartments();

            //Calculate the average salary for each department.
            ebl.AverageSalaryByDepartment();

            //Find the department with the highest total salary.
            ebl.HighestTotalSalary();

            //Group employees by the projects they are involved in.
            ebl.GroupEmployeesByProject();

            //Calculate the total number of projects in each department.
            ebl.TotalNumberOfProjectsByDepartment();

            Console.WriteLine("\n\n*--------------J o i n s--------------*\n");
            //Display the result of the join operation
            ebl.InnerJoins();


            Console.WriteLine("\n\n*--------------Where and Select--------------*\n");
            //filter employees based on specific conditions, such as employees with a
            //salary above a certain threshold
            ebl.filtersmallerthanSalary(55_000);
            ebl.filtergreaterThanSalary(55_000);

            //select and display only the FirstName and LastName of employees and the
            //ProjectName of the projects
            ebl.Display("Marketing Campaign");
            ebl.Display("Budget Planning");
            
            Console.ReadKey();
        }
    }
}
