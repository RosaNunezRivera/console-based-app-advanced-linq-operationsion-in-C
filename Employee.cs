using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Task 1: Setup
/// Define three classes: Employee, Department, and Project.
/// </summary>
namespace Lab_ConsoleBasedApp_AdvancedLINQOperationsinC_
{
    //The Employee class should have properties like EmployeeID, FirstName, LastName, Salary,
    /// and DepartmentID.
    //Class for employess with EmployeeID, and Department ID
    internal class Employee
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public string DepartmentID { get; set; }

    }

    //The Department class should have properties like DepartmentID and DepartmentName.
    //Class for Department with DepartmentID
    internal class Department 
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    //The Project class should have properties like ProjectID, ProjectName, and DepartmentID.
    //Class for Project with ProjectID & DepartmentID
    internal class Project 
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string DepartmentID { get; set; }
    }
}
