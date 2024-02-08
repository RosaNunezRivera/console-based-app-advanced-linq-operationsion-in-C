using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_ConsoleBasedApp_AdvancedLINQOperationsinC_
{

    /// <summary>
    /// Task 1: Setup
    /// Create lists of objects for all three classes
    /// </summary>
    internal class EmployeesBusinessLogic
    {
        List<Employee> employeesCollection = new List<Employee>()
        {
            new Employee { EmployeeID = "E001", FirstName = "John", LastName = "Doe", Salary = 50_000, DepartmentID = "D001" },
            new Employee { EmployeeID = "E002", FirstName = "Jane", LastName = "Smith", Salary = 60_000, DepartmentID = "D001" },
            new Employee { EmployeeID = "E003", FirstName = "Michael", LastName = "Johnson", Salary = 55_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E004", FirstName = "Emily", LastName = "Brown", Salary = 70_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E005", FirstName = "William", LastName = "Wilson", Salary = 48_000, DepartmentID = "D003" },
            new Employee { EmployeeID = "E006", FirstName = "Olivia", LastName = "Martinez", Salary = 62_000, DepartmentID = "D003" },
            new Employee { EmployeeID = "E007", FirstName = "James", LastName = "Taylor", Salary = 53_000, DepartmentID = "D001" },
            new Employee { EmployeeID = "E008", FirstName = "Sophia", LastName = "Anderson", Salary = 58_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E009", FirstName = "Benjamin", LastName = "Thomas", Salary = 51_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E010", FirstName = "Emma", LastName = "Hernandez", Salary = 65_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E011", FirstName = "Liam", LastName = "Garcia", Salary = 55_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E012", FirstName = "Ava", LastName = "Lopez", Salary = 62_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E013", FirstName = "Noah", LastName = "Perez", Salary = 58_000, DepartmentID = "D002" },
            new Employee { EmployeeID = "E014", FirstName = "Isabella", LastName = "Rodriguez", Salary = 51_000, DepartmentID = "D003" },
            new Employee { EmployeeID = "E015", FirstName = "Mason", LastName = "Gonzalez", Salary = 60_000, DepartmentID = "D003" }
        };

        // Create a list of departments
        List<Department> departmentsCollection = new List<Department>()
        {
            new Department { DepartmentID = "D001", DepartmentName = "Marketing" },
            new Department { DepartmentID = "D002", DepartmentName = "Finance" },
            new Department { DepartmentID = "D003", DepartmentName = "Engineering" }
        };

        // Create a list of projects
        List<Project> projectsCollection = new List<Project>()
        {
            new Project { ProjectID = "P001", ProjectName = "Marketing Campaign", DepartmentID = "D001" },
            new Project { ProjectID = "P002", ProjectName = "Financial Analysis", DepartmentID = "D002" },
            new Project { ProjectID = "P003", ProjectName = "Software Development", DepartmentID = "D003" },
            new Project { ProjectID = "P004", ProjectName = "Product Launch", DepartmentID = "D001" },
            new Project { ProjectID = "P005", ProjectName = "Budget Planning", DepartmentID = "D002" }
        };

        /// <summary>
        /// Group employees by their departments, using GroupBy to create group by DepartmentId 
        /// </summary>
        public void GroupEmployeesByTheirDepartments() 
        {
            Console.WriteLine("Group Employees by their Department");
            Console.WriteLine("-----------------------------------");
            var employessByTheirDepartment = employeesCollection.GroupBy(s => s.DepartmentID);
            
            foreach (var deparmentGroup in employessByTheirDepartment)
            {
                var department = departmentsCollection.FirstOrDefault(dep => dep.DepartmentID == deparmentGroup.Key);
                Console.WriteLine("The Department--> " + department.DepartmentName + " has the following employees:");
                foreach (var emp in deparmentGroup)
                {
                    Console.WriteLine("    Id: " + emp.EmployeeID + " Name: " + emp.LastName + "," +emp.FirstName);
                }
            }

        }

        /// <summary>
        /// Method to calculate the average salary by department
        /// Using GroupBy to group the data by 'DepartmentID' after return other collection
        /// using Select with DepartmentID and 
        /// </summary>
        public void AverageSalaryByDepartment()
        {
            Console.WriteLine("\nAverage Salary by Department");
            Console.WriteLine("-----------------------------------");

            var avgSalaryByDepartment = employeesCollection
            .GroupBy(emp => emp.DepartmentID)
            .Select(group => new
            {
                DepartmentID = group.Key,
                AverageSalary = group.Average(emp => emp.Salary)
            });

            //Printing each group of data by DepartmentID and the average salary 
            foreach (var departmentItem in avgSalaryByDepartment)
            {
                //To get the departmentName of each DepartmentID
                var department = departmentsCollection.FirstOrDefault(dep => dep.DepartmentID == departmentItem.DepartmentID);
               
                if (department != null)
                {
                    Console.WriteLine($"{department.DepartmentName} department, has the average salary of {departmentItem.AverageSalary:C}");
                }
            }
        }

        /// <summary>
        /// Method to find the department with the highest total salary
        /// First thouogh the use of GroupBy by departament, after create a new collections of data
        /// with to values id and total of all salaries in the group
        /// Finally, sorted descending by total salary and take the first value 
        /// </summary>
        public void HighestTotalSalary()
        {
            Console.WriteLine("\nHighest Total Salary Department");
            Console.WriteLine("-----------------------------------");

            var highestSalary = employeesCollection
            .GroupBy(emp => emp.DepartmentID)
            .Select(group => new
            {
                DepartmentID = group.Key,
                TotalSalary = group.Sum(emp => emp.Salary)
            }).OrderByDescending(s => s.TotalSalary).First();

            //Get the department object whose match with 'DepartmentID' to print the DepartmentName 
            var department = departmentsCollection.FirstOrDefault(dep => dep.DepartmentID == highestSalary.DepartmentID);

            //Printin the result Department Name and Highest Total Salary 
            Console.WriteLine("The Department with the highest total Salary is --> " + department.DepartmentName + " with the total salary of " + highestSalary.TotalSalary.ToString("C"));
        }

        /// <summary>
        /// Method to print the groups of employee by the projects 
        /// </summary>
        public void GroupEmployeesByProject() 
        {
            Console.WriteLine("\nGroup Employees by their Project");
            Console.WriteLine("-----------------------------------");
            var employessByTheirProject = projectsCollection.
                Join(employeesCollection, proj => proj.DepartmentID, emp => emp.DepartmentID,
                (proj, emp) => new
                {
                    ProjectName = proj.ProjectName,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    EmployeeID = emp.EmployeeID,
                }).GroupBy(proj => proj.ProjectName);

            foreach (var projectItem in employessByTheirProject)
            {
                Console.WriteLine("The Project--> " + projectItem.Key + " has the following employees:");
                foreach (var emp in projectItem)
                {
                    Console.WriteLine("    Id: " + emp.EmployeeID + " Name: " + emp.LastName + "," + emp.FirstName);
                }
            }
        }

        /// <summary>
        /// Method to print the Department and how many projects there are in each department
        /// </summary>
        public void TotalNumberOfProjectsByDepartment() 
        {
            Console.WriteLine("\nTotal Number of Projects by Departments");
            Console.WriteLine("------------------------------------------");

            var numbersOfProjectsByDepartment = departmentsCollection.
                Join(projectsCollection, dep => dep.DepartmentID, proj => proj.DepartmentID,
                (dep, proj) => new
                {
                    DepartmentName = dep.DepartmentName,
                    ProjectName = proj.ProjectName,
                    ProjectId = proj.ProjectID
                }).GroupBy(dep => dep.DepartmentName).Select(group => new
                {
                    DepartmentName = group.Key,
                    TotalNumberProjects = group.Count()
                });

            //Printint the Department Name and the Count of numbers of project in each deparment 'TotalNumberProjects'
            foreach (var deparmentGroup in numbersOfProjectsByDepartment)
            {
                Console.WriteLine($"{deparmentGroup.DepartmentName} department, has {deparmentGroup.TotalNumberProjects} project(s)");
            }
        }

        /// <summary>
        /// Method to perform inner joins between Employee, Department, and Project collections based
        /// on IDs
        /// </summary>
        public void InnerJoins() 
        {
            Console.WriteLine("\nInner Joins between the data collections");
            Console.WriteLine("----------------------------------------------");

            var innerJoinCollection = departmentsCollection.
                Join(employeesCollection, dep => dep.DepartmentID, emp => emp.DepartmentID,
                (dep, emp) => new
                {
                    DepartmentId = dep.DepartmentID,
                    DepartmentName = dep.DepartmentName,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    employeeId = emp.EmployeeID,
                    Salary = emp.Salary
                }).
                Join(projectsCollection, depEmp => depEmp.DepartmentId, proj => proj.DepartmentID, (depEmp, proj) => new
                {
                    DepartmentName = depEmp.DepartmentName,
                    DepartmentId = depEmp.DepartmentId,
                    FirstName = depEmp.FirstName,
                    LastName = depEmp.LastName,
                    employeeId = depEmp.employeeId,
                    Salary = depEmp.Salary,
                    ProjectName = proj.ProjectName,
                    ProjectId = proj.ProjectID
                });

            var GroupByDepartment = innerJoinCollection.GroupBy(d => d.DepartmentName);

            //Priting the department Group 
            foreach (var deparmentGroup in GroupByDepartment)
            {
                //Setting the GroupBy for Project 
                var groupedByProject = deparmentGroup.GroupBy(item => item.ProjectName);
                Console.WriteLine($"\nThe Department--> {deparmentGroup.Key} has {groupedByProject.Count()} project(s) and {deparmentGroup.Count()} employee(s)");

                //Priting the project Group 
                foreach (var projectGroup in groupedByProject)
                {
                    //Printing the employess
                    Console.WriteLine($"  Project: {projectGroup.Key} has the following employees");
                    foreach (var emp in projectGroup) 
                    {
                        Console.WriteLine($"    Id: {emp.employeeId} Name: {emp.LastName}, {emp.FirstName} and Salary: {emp.Salary.ToString("C")}");
                    }
                }
            }
        }

        /// <summary>
        /// Method to print employees with a salary <= than the parameter 
        /// </summary>
        /// <param name="salary"></param>
        public void filtersmallerthanSalary(int salary) 
        {
            Console.WriteLine($"\nEmployees with a salary <= {salary}");
            Console.WriteLine("--------------------------------------");

            var filterBySalary = employeesCollection
            .Where(emp => emp.Salary <= salary)
            .Select(group => new
            {
                DepartmentID = group.DepartmentID,
                Salary = group.Salary,
                FirstName = group.FirstName,
                LastName = group.LastName
            }).OrderBy(s => s.FirstName);

            //Printing each group of data by DepartmentID and the average salary 
            foreach (var emp in filterBySalary)
            {
                //To get the departmentName of each DepartmentID
                var department = departmentsCollection.FirstOrDefault(dep => dep.DepartmentID == emp.DepartmentID);

                if (department != null)
                {
                    Console.WriteLine($"The employee {emp.FirstName},{emp.LastName} of the Department {department.DepartmentName} has the salary of {emp.Salary:C}");
                }
            }
        }
        
        /// <summary>
        /// Method to print employees with a salary > than the parameter 
        /// </summary>
        /// <param name="salary"></param>
        public void filtergreaterThanSalary(int salary) 
        {
            Console.WriteLine($"\nEmployees with a salary  > {salary}");
            Console.WriteLine("--------------------------------------");

            var filterBySalary = employeesCollection
            .Where(emp => emp.Salary > salary)
            .Select(group => new
            {
                DepartmentID = group.DepartmentID,
                Salary = group.Salary,
                FirstName = group.FirstName,
                LastName = group.LastName
            }).OrderBy(s => s.FirstName);

            //Printing each group of data by DepartmentID and the average salary 
            foreach (var emp in filterBySalary)
            {
                //To get the departmentName of each DepartmentID
                var department = departmentsCollection.FirstOrDefault(dep => dep.DepartmentID == emp.DepartmentID);

                if (department != null)
                {
                    Console.WriteLine($"The employee {emp.FirstName},{emp.LastName} of the Department {department.DepartmentName} has the salary of {emp.Salary:C}");
                }
            }

        }

        /// <summary>
        /// Method to print the FirstName, LastName, project name of the employees with match with
        /// the projects pass as parameter 
        /// </summary>
        /// <param name="proj"></param>
        public void Display(string projectParameter) 
        {
            Console.WriteLine($"\nEmployees of the project: {projectParameter}");
            Console.WriteLine("----------------------------------------------------");

            var filterByProject = projectsCollection
            .Where(proj => proj.ProjectName == projectParameter)
            .Select(group => new
            {
                ProjectName = group.ProjectName,
                ProjectId = group.ProjectID,
                DepartmentId = group.DepartmentID
            }).Join(employeesCollection, proj => proj.DepartmentId, emp => emp.DepartmentID,
               (proj, emp) => new
               {
                   ProjecttName = proj.ProjectName,
                   FirstName = emp.FirstName,
                   LastName = emp.LastName
               });


            //Printing each group of data by DepartmentID and the average salary 
            foreach (var emp in filterByProject)
            {
                Console.WriteLine($"The eployee {emp.FirstName},{emp.LastName} of the Project {emp.ProjecttName}");
            }
        }
    }
}


