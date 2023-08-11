using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLibrary
{

    public enum Gender
    {
        Male,
        Female
    }

    public class Human
    {
        public string Name { get; set; }

        public Gender Gender;
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name:{Name} ,Gender:{Gender} ,Age:{Age}";
        }
    }

    public class Employee : Human
    {
        public static int counter = 1;
        public int Id;
        public double Salary { set; get; }


        public Employee(string name, double salary, Gender gender, int age)
        {
            Id = counter++;
            Gender = gender;
            Name = name;
            Salary = salary;
            Age = age;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, EmployeeId: {Id} , Salary: {Salary:C}";
        }

        public void DisplayData()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Age: {Age}");
        }
    }

    public class EmployeeSearch
    {
        public static void SearchEmployeesById(List<Employee> employeesList)
        {
            Console.WriteLine("Enter Employee ID to search:");
            int searchId = int.Parse(Console.ReadLine());

            Employee foundEmployee = employeesList.FirstOrDefault(employee => employee.Id == searchId);

            if (foundEmployee != null)
            {
                Console.WriteLine("Employee found:");
                foundEmployee.DisplayData();
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
            Console.ReadLine();
        }

        public static void SearchEmployeesByName(List<Employee> employeesList)
        {
            Console.WriteLine("Enter Employee Name to search:");
            string searchName = Console.ReadLine();

            var foundEmployees = employeesList.Where(employee =>
                employee.Name.ToLower().Contains(searchName.ToLower()));

            if (foundEmployees.Any())
            {
                Console.WriteLine("Employees found:");
                foreach (var employee in foundEmployees)
                {
                    employee.DisplayData();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
            Console.ReadLine();
        }

        public static void SearchEmployeesBySalary(List<Employee> employeesList)
        {
            Console.WriteLine("Enter Employee Salary to search:");
            double searchSalary = double.Parse(Console.ReadLine());

            var foundEmployees = employeesList.Where(employee =>
                employee.Salary == searchSalary);

            if (foundEmployees.Any())
            {
                Console.WriteLine("Employees found:");
                foreach (var employee in foundEmployees)
                {
                    employee.DisplayData();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
            Console.ReadLine();
        }
    }


    public class EmployeeNameComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }

    public class EmployeeIdComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }

    public class EmployeeSalaryComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }

    public static class EmployeeExtensions
    {
        public static void DisplayEmployees(this Employee[] employees)
        {
            foreach (var employee in employees)
            {
                employee.DisplayData();
                Console.WriteLine();
            }
        }
    }
}

