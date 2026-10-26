using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;

namespace Uni_database_project.Student_Functions
{
    public class Student_Search
    {
        private Student_List Data;

        public Student_Search(Student_List data)
        {
            this.Data = data;
        }
        public void ShowStudents()
        {

            if (Data.Database.Count == 0)
            {
                Console.WriteLine("!!! No students found !!!");
                return;
            }

            Console.WriteLine(
                            "______________\n" +
                            "Found Students:");

            foreach (var student in Data.Database)
            {
                DisplayInfo(student);
            }
        }

        public void SearchByPESEL()
        {
            while (true) 
            {
            Console.WriteLine(
                "_______________________________________\n" +
                "Enter student's PESEL number to search: ");
            string searchPESEL = Console.ReadLine() ?? "";

                if(string.IsNullOrWhiteSpace(searchPESEL))
                {
                    Console.WriteLine("!!! First name cannot be empty !!!");
                    continue;
                }

                foreach (var student in Data.Database)
                {
                    if (student.PESEL_Number == searchPESEL)
                    {
                        Console.WriteLine(
                            "______________\n" +
                            "Found Student:");
                        DisplayInfo(student);
                    }
                }
                return;
            }
        }

        public void SearchByName()
        {
            while (true)
            {
                Console.WriteLine(
                "____________________________________\n" +
                "Enter student's last name to search:");
                string searchName = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(searchName))
                {
                    Console.WriteLine("!!! First name cannot be empty !!!");
                    continue;
                }

                foreach (var student in Data.Database)
                {
                    if (student.LastName == searchName)
                    {
                        Console.WriteLine(
                            "______________\n" +
                            "Found Student:");
                        DisplayInfo(student);
                    }
                }
                return;
            }
        }

        public void DisplayInfo(Student_Class student)
        {
            Console.WriteLine(
                    $"---------------------------------------\n" +
                    $"Student ID: {student.StudentID}\n" +
                    $"First Name: {student.FirstName}\n" +
                    $"Last Name: {student.LastName}\n" +
                    $"Gender: {student.SelectedGender}\n" +
                    $"Adress: {student.Adress}\n" +
                    $"PESEL: {student.PESEL_Number}\n" +
                    $"---------------------------------------\n"
                    );
        }
    }
}
