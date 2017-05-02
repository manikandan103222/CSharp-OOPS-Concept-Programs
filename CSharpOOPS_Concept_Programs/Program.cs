/**
 * Author: Manikandan M
 */
using System;
namespace CSharpOOPS_Concept_Programs
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the " + Employee.GetCompanyName() + " Employee System");  //get company name from base class
            Console.WriteLine("Current Branch Address: " + Employee.BranchOfficeAddress()); //get branch address from branch class
            Console.WriteLine("Office Incharge Person Name: " + Employee.getInChargeDetail("Manikandan")); //get incharge own incharge person based on input
            EmployeeArray empArray = new EmployeeArray();
            int continueRunning = 1;
            do
            {

                Console.WriteLine();
                Console.WriteLine("Please Enter Your Choice:");
                Console.WriteLine("1=Enter new employee");
                Console.WriteLine("2=Update existing employee");
                Console.WriteLine("3=Delete employee");
                Console.WriteLine("4=Print employee list");
                Console.WriteLine("Any other number to exit");
                int userChoice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                
                switch(userChoice)
                {
                    case 1:
                        Employee emp = createNewWorker();

                        if (!(empArray.Contains(emp)))
                        {
                            Console.WriteLine("Office Timeing: " + emp.getOfficeTiming()); //get office time from current branch
                            empArray.Add(emp);
                        }
                        else
                            Console.WriteLine("cannot add new worker. This worker already exists");
                        break;
                    case 2:
                        EditEmployee(empArray);
                        break;
                    case 3:
                        DeleteEmployee(empArray);
                        break;
                    case 4:
                        empArray.Print();
                        break;
                    default:
                        continueRunning = 0;
                        break;
                }


            } while (continueRunning == 1);
        }

        /// <summary>
        /// creating new employee
        /// </summary>
        /// <returns></returns>
        static Employee createNewWorker()
        {
            Employee emp;
            Console.WriteLine("Enter first name:");
            string first = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            string last = Console.ReadLine();

            Console.WriteLine("Enter birth date in DD/MM/YYYY format");
            DateTime bDay = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is worker 1=Secretary, 2=HR, 3=SE, 4=SSE, 5=TL, 6=Manager, 7=TechManager, 8=Architect?");
            EmployeeType workerType = (EmployeeType)int.Parse(Console.ReadLine()) - 1;

            EmployeeSalaryInformation salInformation = GetSalarInformation(workerType);

            emp = new Employee(first, last, bDay, workerType, salInformation);

            return emp;
        }

        /// <summary>
        /// editing an employee and his information
        /// </summary>
        /// <param name="employees"></param>
        static void EditEmployee(EmployeeArray employees)
        {
            Employee emp = GetEmployeeInformation();

            EmployeeSalaryInformation salInformation = new EmployeeSalaryInformation();
            if (employees.Contains(emp))
            {
                Console.WriteLine("Has worker position changed? 1=Yes, 2=No");
                int changeType = int.Parse(Console.ReadLine());
                if (changeType == 1)
                {
                    Console.WriteLine("Is worker 1=Secretary, 2=HR, 3=SE, 4=SSE, 5=TL, 6=Manager, 7=TechManager, 8=Architect?");
                    EmployeeType workerType = (EmployeeType)int.Parse(Console.ReadLine()) - 1;

                    salInformation = GetSalarInformation(workerType);

                    employees.Replace(emp, workerType, salInformation);
                }
                else
                {
                    salInformation = GetSalarInformation(employees.Find(emp));
                    employees.Replace(emp, employees.Find(emp), salInformation);
                }
            }
            else
                Console.WriteLine("There is no such employee");
        }

        /// <summary>
        /// deleting an employee from the list
        /// </summary>
        /// <param name="employees"></param>
        static void DeleteEmployee(EmployeeArray employees)
        {
            Employee emp = GetEmployeeInformation();

            if (employees.Contains(emp))
            {
                Console.WriteLine("Deleting employee");
                employees.Remove(emp);
            }
            else
                Console.WriteLine("There is no such employee");
        }

        /// <summary>
        /// getting the basic information about an employee which includes
        /// </summary>
        /// <returns></returns>
        static Employee GetEmployeeInformation()
        {
            Console.WriteLine("Enter first name of the employee");
            string first = Console.ReadLine();
            Console.WriteLine("Enter last name of the employee");
            string last = Console.ReadLine();
            Console.WriteLine("Enter birth date in DD/MM/YYYY format");
            DateTime bDay = DateTime.Parse(Console.ReadLine());
            Employee emp = new Employee(first, last, bDay);
            return emp;
        }

        /// <summary>
        /// getting the salary information about a certain employee type from the user
        /// </summary>
        /// <param name="empType"></param>
        /// <returns></returns>
        static EmployeeSalaryInformation GetSalarInformation(EmployeeType empType)
        {
            EmployeeSalaryInformation salInformation = new EmployeeSalaryInformation(empType);
            switch(empType)
            {
                case (EmployeeType)0:
                    Console.WriteLine("Please Enter Hourly Wage");
                    salInformation.hourlyWage = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Number of Hours Worked in Monthly");
                    salInformation.monthlyHours = int.Parse(Console.ReadLine());
                    break;
                case (EmployeeType)1:
                    Console.WriteLine("Please Enter Base Salary");
                    salInformation.baseSalary = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Number of Recruit New Employee");
                    salInformation.numRecruit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Bonus per Recruit New Employee");
                    salInformation.salaryBonus = float.Parse(Console.ReadLine());
                    break;
                case (EmployeeType)2:
                case (EmployeeType)3:
                case (EmployeeType)4:
                case (EmployeeType)5:
                case (EmployeeType)6:
                case (EmployeeType)7:
                    Console.WriteLine("Please Enter Base Salary");
                    salInformation.baseSalary = float.Parse(Console.ReadLine());
                    break;
            }
            return salInformation;
        }
    }
}
