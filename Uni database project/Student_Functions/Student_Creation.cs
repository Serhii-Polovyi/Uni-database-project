using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;

namespace Uni_database_project.Student_Functions
{
    
    public class Student_Creation
    {
        private Student_Data_Ask DataAsk;
        private Student_List Data;
        public Student_Creation(Student_List data, Student_Data_Ask dataAsk)
        {
            this.Data = data;
            this.DataAsk = dataAsk;
        }

        public void AddStudent()
        {
            string firstName = DataAsk.TakeFistName();

            string lastName = DataAsk.TakeLastName();

            Gender selectedGender = DataAsk.TakeGender();

            string adress = DataAsk.TakeAdress();

            int studentID = DataAsk.TakeID();

            string PESEL_number = DataAsk.TakePESEL();


            Data.Database.Add(new Student_Class(studentID, firstName, lastName, selectedGender, adress, PESEL_number));
            Console.WriteLine("!!! Student Added !!!");
        }

        public void RemoveStudent()
        {
            Console.WriteLine(
                "_____________________________\n" +
                "Enter student's ID to remove: ");
            int searchID = Convert.ToInt32(Console.ReadLine());

            int DeleteIndex = 0;

            foreach (var student in Data.Database)
            {
                if (student.StudentID == searchID)
                {
                    DeleteIndex = Data.Database.IndexOf(student);
                }
            }

            Data.Database.RemoveAt(DeleteIndex);
        }

    }
}