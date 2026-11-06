using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;
using Uni_database_project.Main_Functions;

namespace Uni_database_project.Student_Functions
{
    
    public class Student_Creation
    {
        private ErrorMessages ErrorMsg;
        private Student_Data_Ask DataAsk;
        private Student_List DataList;
        public Student_Creation(ErrorMessages errorMsg, Student_List dataList, Student_Data_Ask dataAsk)
        {
            this.ErrorMsg = errorMsg;
            this.DataList = dataList;
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

            double grade = DataAsk.TakeGrade();


            DataList.Database.Add(new Student_Class(studentID, firstName, lastName, selectedGender, adress, PESEL_number, grade));
            ErrorMsg.StudentAdded();
        }

        public void RemoveStudent()
        {
            while (true)
            {
                Console.WriteLine(
                "_____________________________\n" +
                "Enter student's ID to remove: ");
                int searchID;
                if (!int.TryParse(Console.ReadLine(), out searchID))
                {
                    ErrorMsg.Incorrectinput();
                    continue;
                }

                if (!DataList.Database.Any(student => student.StudentID == searchID))
                {
                    ErrorMsg.NoMatchingStudentFound();
                    continue;
                }

                int DeleteIndex = 0;

                foreach (var student in DataList.Database)
                {
                    if (student.StudentID == searchID)
                    {
                        DeleteIndex = DataList.Database.IndexOf(student);
                    }
                }

                DataList.Database.RemoveAt(DeleteIndex);

                break;
            }

        }

    }
}