﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             *
             * Complete every task using Method OR Query syntax.
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             *
             */

            //TODO: Print the Sum of 

            Console.WriteLine($"Sum of Numbers: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average of Numbers: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("Ordered Numbers: ");
            var numOrder = numbers.OrderBy(num => num);

            foreach (var number in numOrder)
            {
                Console.WriteLine(number);
            }

            //TODO: Order numbers in descending order and print to the console

            Console.WriteLine("Descending Ordered Numbers: ");
            var desOrder = numbers.OrderByDescending(num => num);

            foreach (var number in desOrder)
            {
                Console.WriteLine(number);
            }
            //TODO: Print to the console only the numbers greater than 6

            Console.WriteLine("Numbers Greater Than 6");
            var greatNum = numbers.Where(x => x > 6);

            foreach (var num in greatNum)
            {
                Console.WriteLine(num);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("Printing Only Four Numbers Ascending: ");
            var fourNum = numbers.OrderBy(num => num).Take(4);

            foreach (var number in fourNum)
            {
                Console.WriteLine(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("Ordered numbers with my age descending: ");
            int age = 20;
            numbers[4] = age;

            var ageNum = numbers.OrderByDescending(num => num);

            foreach (var number in ageNum)
            {
                Console.WriteLine(number);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            Console.WriteLine("Employees names that start with c or s: ");
            var filterEmployee = employees.Where(e => e.FirstName.StartsWith("C") || e.FirstName.StartsWith("S"))
                .OrderBy(e => e.FirstName);

            foreach (var employee in filterEmployee)
            {
                Console.WriteLine(employee.FullName);
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Employees over 26: ");
            var filterAge = employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName);

            foreach (var employee in filterAge)
            {
                Console.WriteLine($"{employee.FirstName}, Age: {employee.Age}");
            }

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var totalExperience = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                .Sum(e => e.YearsOfExperience);

            Console.WriteLine($"Total Years of Experience: {totalExperience}");
        
    //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

    var totalExperienceEmployees = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
        .ToList();
    
            var averageExperience = totalExperienceEmployees.Any() ? totalExperienceEmployees.Average(e => e.YearsOfExperience) : 0;
            
            Console.WriteLine($"Average Years of Experience: {averageExperience}");
            
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine();

            Console.WriteLine("Please add a new employee: ");
            
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Age: ");
            int userAge = int.Parse(Console.ReadLine());

            Console.Write("Years of Experience: ");
            int yearsOfExperience = int.Parse(Console.ReadLine());

            // Add the new employee to the end of the list
            employees = employees.Append(new Employee(firstName, lastName, userAge, yearsOfExperience)).ToList();
            
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
