/**
 * Author: Manikandan M
 */
using System;
using System.Collections;

namespace CSharpOOPS_Concept_Programs
{
    /// <summary>
    /// Declaring Enum that is used to define the type of employees
    /// </summary>
    public enum EmployeeType { Secretary, HR, SE, SSE, TL, Manager, TechManager, Architect };

    /// <summary>
    /// defining struct that will contain the salary information for each employee
    /// </summary>
    public struct EmployeeSalaryInformation
    {
        public float hourlyWage;
        public int monthlyHours;
        public float baseSalary;
        public int numRecruit;
        public float salaryBonus;

        public EmployeeSalaryInformation(EmployeeType emType)
        {
            this.hourlyWage = 90; //based on indian rupees
            this.monthlyHours = 172;
            this.baseSalary = 20000;
            this.numRecruit = 2; //by default 2 new employee recruit per month
            this.salaryBonus = 2000; //default bonus
            if (emType == (EmployeeType)3) //if employee type is a senior software engineer(SSE) then his/her bonus will be 8000
                this.salaryBonus = 8000;
            if (emType == (EmployeeType)4) //if employee type is a Team Leader then his/her bonus will be 20000
                this.salaryBonus = 20000;
            if (emType == (EmployeeType)5) //if employee type is a manager then his/her bonus will be 30000
                this.salaryBonus = 30000;
            if (emType == (EmployeeType)6 || emType == (EmployeeType)7) //if employee type is a tech manager / architect then his/her bonus will be 35000
                this.salaryBonus = 35000;
        }
    }

    /// <summary>
    /// An employee class which includes all the information about an employee, ways to retrieve and set the information, and caculate its salary
    /// </summary>
    public class Employee : BranchOffice2
    {
        string firstName;
        string familyName;
        DateTime birthDate;
        EmployeeType employeeType;
        EmployeeSalaryInformation employeeSalaryInformation;

        /// <summary>
        /// constructor which creates an employee without his salary information and type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="family"></param>
        /// <param name="bDay"></param>
        public Employee(string name, string family, DateTime bDay)
        {
            firstName = name;
            familyName = family;
            birthDate = bDay;
        }
        /// <summary>
        /// constructor which create an employee with all information
        /// </summary>
        /// <param name="first"></param>
        /// <param name="family"></param>
        /// <param name="bDay"></param>
        /// <param name="empType"></param>
        /// <param name="salInfo"></param>
        public Employee(string first, string family, DateTime bDay, EmployeeType empType, EmployeeSalaryInformation salInfo)
        {
            firstName = first;
            familyName = family;
            birthDate = bDay;
            employeeType = empType;
            employeeSalaryInformation = salInfo;
        }
        /// <summary>
        /// getting the first name
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
        }

        /// <summary>
        /// getting the last name
        /// </summary>
        public string FamilyName
        {
            get { return this.familyName; }
        }

        /// <summary>
        /// getting birth date
        /// </summary>
        public DateTime BirthDate
        {
            get { return this.birthDate; }
        }

        /// <summary>
        /// getting the type of employee or setting it (in case it changed)
        /// </summary>
        public EmployeeType EmployeeType
        {
            get { return this.employeeType; }
            set { this.employeeType = value; }
        }

        /// <summary>
        /// setting new salary information for the employee
        /// </summary>
        public EmployeeSalaryInformation SalaryInformation
        {
            set { this.employeeSalaryInformation = value; }
        }

        /// <summary>
        /// get employee salary
        /// </summary>
        /// <returns></returns>
        public float getEmployeeSalary()
        {
            return CalculateSalary();
        }

        /// <summary>
        /// calculate employee salary
        /// </summary>
        /// <returns></returns>
        private float CalculateSalary()
        {
            float salary = 0;
            switch(employeeType)
            {
                case (EmployeeType)0: //if employee is secretary than multiply wage per hour by hours worked
                    salary = (employeeSalaryInformation.hourlyWage) * (employeeSalaryInformation.monthlyHours);
                    break;
                case (EmployeeType)1: //if employee is HR than multiply number of recruit by bonus per recruit and add that to the base salary
                    salary = ((employeeSalaryInformation.baseSalary) + (employeeSalaryInformation.numRecruit * (employeeSalaryInformation.salaryBonus)));
                    break;
                case (EmployeeType)2: //if employee is Software Engineer(SE) than take base salary
                    salary = employeeSalaryInformation.baseSalary;
                    break;
                case (EmployeeType)3: //if employee is SSE
                case (EmployeeType)4: //if employee is TL
                case (EmployeeType)5: //if employee is manager
                case (EmployeeType)6: //if employee is Tech Manager
                case (EmployeeType)7: //if employee is Architect
                    salary = (employeeSalaryInformation.baseSalary) + (employeeSalaryInformation.salaryBonus);
                    break;
            }
            return salary;
        }
    }

    /// <summary>
    /// A class dealing with list of employees
    /// </summary>
    public class EmployeeArray
    {
        /// <summary>
        /// based on arraylist
        /// </summary>
        private ArrayList employees;

        /// <summary>
        /// constructor just create an empty array list
        /// </summary>
        public EmployeeArray()
        {
            employees = new ArrayList();
        }

        /// <summary>
        /// add new employee to the list
        /// </summary>
        /// <param name="emp"></param>
        public void Add(Employee emp)
        {
            employees.Add(emp);
        }

        /// <summary>
        /// checking for the employee is contained in the list
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool Contains(Employee emp)
        {
            foreach (Employee e in employees)
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower())
                    && (emp.BirthDate) == e.BirthDate)
                    return true;
            return false;
        }

        /// <summary>
        /// removing the employee from the list
        /// </summary>
        /// <param name="emp"></param>
        public void Remove(Employee emp)
        {
            foreach(Employee e in employees)
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower())
                    && (emp.BirthDate) == e.BirthDate)
                {
                    employees.Remove(e);
                    break;
                }
        }

        /// <summary>
        /// finding an employee in the list and returning his/her employee type
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public EmployeeType Find(Employee emp)
        {
            foreach (Employee e in employees)
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower())
                    && (emp.BirthDate) == e.BirthDate)
                    return e.EmployeeType;
            return (EmployeeType)0;
        }

        /// <summary>
        /// replacing an employee information. only type and salary information could be replaced
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="emType"></param>
        /// <param name="salInformation"></param>
        public void Replace(Employee emp, EmployeeType emType, EmployeeSalaryInformation salInformation)
        {
            foreach (Employee e in employees)
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower())
                    && (emp.BirthDate) == e.BirthDate)
                {
                    e.EmployeeType = emType; //replacing type
                    e.SalaryInformation = salInformation; //replacing salary information
                    break;
                }
        }

        /// <summary>
        /// printing all employees in the list including name, birthdate, type and salary
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Famil Name\tFirst Name\tBirth Date\tWorker Type\tSalary");
            Console.WriteLine("-----------\t----------\t----------\t-----------\t-------");
            foreach (Employee e in employees)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", e.FamilyName.PadRight(11), e.FirstName.PadRight(10),
                    e.BirthDate.ToShortDateString(), e.EmployeeType.ToString().PadRight(11), e.getEmployeeSalary());
            Console.WriteLine();
        }
    }
}
