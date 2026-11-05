using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;
using Uni_database_project.Main_Functions;

namespace Uni_database_project.Student_Functions
{
    public class Student_Update
    {

        public Update_Choice_loop UpdLoop { get; set; }
        private Student_List DataList;
        private Student_Search Search;
        private Student_Data_Ask DataAsk;

        public Student_Update(
            Student_List dataList,
            Student_Search search,
            Student_Data_Ask dataAsk
            )
        {
            this.DataList = dataList;
            this.Search = search;
            this.DataAsk = dataAsk;

        }

        public void StudentUpdate()
        {
            Console.WriteLine(
                "_______________________________________\n" +
                "Enter student's ID number to search: ");

            int searchID;
            while (!int.TryParse(Console.ReadLine(), out searchID))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!! Wrong input for ID! try again !!!");
                Console.ResetColor();
                continue;
            }

            foreach (var student in DataList.Database)
            {
                if (student.StudentID == searchID)
                {
                    Console.WriteLine(
                        "______________\n" +
                        "Found Student:");
                    Search.DisplayInfo(student);
                    while (true)
                    {
                        UpdLoop.UpdateChoice(student);


                        Console.WriteLine("you want to exit? y/n");
                        char choice = Convert.ToChar(Console.ReadLine());

                        if (choice == 'y')
                        {
                            return;
                        }
                    }
                }
            }
        }

        public void UpdateFirstName(Student_Class student)
        {
            student.FirstName = DataAsk.TakeFistName();
        }

        public void UpdateLastName(Student_Class student)
        {
            student.LastName = DataAsk.TakeFistName();
        }

        public void UpdateGender(Student_Class student)
        {
            student.SelectedGender = DataAsk.TakeGender();
        }

        public void UpdateAdress(Student_Class student)
        {
            student.Adress = DataAsk.TakeAdress();
        }

        public void UpdatePesel(Student_Class student)
        {
            student.PESEL_Number = DataAsk.TakePESEL();
        }

        public void UpdateGrade(Student_Class student)
        {
            student.Grade = DataAsk.TakeGrade();
        }

    }
}
