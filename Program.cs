using System;
using System.Collections.Generic;
using EmployeeLibrary;

class Program
{
    static void Main(string[] args)
    {
        int highlight = 0;
        bool flag = true;
        string[] menu = new string[]
        {
            "    New  ",
            "   Display ",
            "    Sort   ",
            "   Search ",
            "    Exit  "
        };

        int xDistance = Console.WindowWidth / 2;
        int yDistance = Console.WindowHeight / (menu.Length + 1);

        // New list to store Employee objects
        List<Employee> employees = new List<Employee>();
        int employeeCount = 0;

        do
        {
            Console.ResetColor();
            Console.Clear();
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == highlight)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.SetCursorPosition(xDistance, (i + 1) * yDistance);
                Console.WriteLine(menu[i]);
            }
            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    highlight = (highlight - 1 + menu.Length) % menu.Length;
                    break;
                case ConsoleKey.DownArrow:
                    highlight = (highlight + 1) % menu.Length;
                    break;
                case ConsoleKey.Home:
                    highlight = 0;
                    break;
                case ConsoleKey.End:
                    highlight = 2;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    switch (highlight)
                    {
                        case 0:
                            AddNewEmployee();
                            break;
                        case 1:
                            DisplayEmployees(employees);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Choose sorting option:");
                            Console.WriteLine("1. Sort by ID");
                            Console.WriteLine("2. Sort by Name");
                            Console.WriteLine("3. Sort by Salary");
                            int sortChoice = int.Parse(Console.ReadLine());
                            switch (sortChoice)
                            {
                                case 1:
                                    employees.Sort(new EmployeeIdComparer());
                                    break;
                                case 2:
                                    Console.WriteLine("Sort by Name:");
                                    Console.WriteLine("1. Ascending");
                                    Console.WriteLine("2. Descending");
                                    int nameSortChoice = int.Parse(Console.ReadLine());

                                    employees.Sort((emp1, emp2) =>
                                    {
                                        switch (nameSortChoice)
                                        {
                                            case 1:
                                                return emp1.Name.CompareTo(emp2.Name);
                                            case 2:
                                                return emp2.Name.CompareTo(emp1.Name);
                                            default:
                                                return 0;
                                        }
                                    });
                                    break;
                                case 3:
                                    Console.WriteLine("Sort by Salary:");
                                    Console.WriteLine("1. Ascending");
                                    Console.WriteLine("2. Descending");
                                    int salarySortChoice = int.Parse(Console.ReadLine());

                                    employees.Sort((emp1, emp2) =>
                                    {
                                        switch (salarySortChoice)
                                        {
                                            case 1:
                                                return emp1.Salary.CompareTo(emp2.Salary);
                                            case 2:
                                                return emp2.Salary.CompareTo(emp1.Salary);
                                            default:
                                                return 0;
                                        }
                                    });
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                            DisplayEmployees(employees);
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Choose search option:");
                            Console.WriteLine("1. Search by ID");
                            Console.WriteLine("2. Search by Name");
                            Console.WriteLine("3. Search by Salary");
                            int searchChoice = int.Parse(Console.ReadLine());

                            switch (searchChoice)
                            {
                                case 1:
                                    EmployeeSearch.SearchEmployeesById(employees);
                                    break;
                                case 2:
                                    EmployeeSearch.SearchEmployeesByName(employees);
                                    break;
                                case 3:
                                    EmployeeSearch.SearchEmployeesBySalary(employees);
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                            break;

                        case 4:
                            flag = false;
                            break;
                    }
                    break;
                case ConsoleKey.Escape:
                    flag = false;
                    break;
            }
        } while (flag);

        // Method to add a new employee
        void AddNewEmployee()
        {
            Console.Clear();
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary:");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Gender (M/F):");
            Gender gender = (Console.ReadLine().ToUpper() == "M") ? Gender.Male : Gender.Female;

            Console.WriteLine("Enter Employee Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Employee added successfully!");
            Console.ReadLine();

            employees.Add(new Employee(name, salary, gender, age));
        }

        // Display method for Employee list
        void DisplayEmployees(List<Employee> employeesList)
        {
            Console.Clear();
            if (employeesList.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                Console.WriteLine("Employee List:");
                foreach (var employee in employeesList)
                {
                    employee.DisplayData();
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
