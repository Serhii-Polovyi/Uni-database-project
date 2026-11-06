using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;
using Uni_database_project.Main_Functions;

namespace Uni_database_project.Student_Functions
{
    public class Student_Search
    {
        private ErrorMessages ErrorMsg;
        private Student_List DataList;

        public Student_Search(ErrorMessages errorMsg, Student_List dataList)
        {
            this.ErrorMsg = errorMsg;
            this.DataList = dataList;
        }
        public void ShowStudents()
        {

            if (DataList.Database.Count == 0)
            {
                ErrorMsg.NoStudentDataFound();
                return;
            }

            Console.WriteLine(
                            "______________\n" +
                            "Found Students:");

            foreach (var student in DataList.Database)
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
                    ErrorMsg.FieldIsEmpty();
                    continue;
                }

                foreach (var student in DataList.Database)
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
                    ErrorMsg.FieldIsEmpty();
                    continue;
                }

                foreach (var student in DataList.Database)
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
                    $"Grade: {student.Grade}\n" +
                    $"---------------------------------------\n"
                    );
        }
    }
}
