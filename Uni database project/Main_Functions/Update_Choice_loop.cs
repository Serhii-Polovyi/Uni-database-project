using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Student_Functions;

namespace Uni_database_project.Main_Functions
{
    public class Update_Choice_loop
    {
        private ErrorMessages ErrorMsg;
        public Student_Update StuUpdate { get; set; }

        public Update_Choice_loop(ErrorMessages errorMsg) 
        {
            this.ErrorMsg = errorMsg;
        }

        public void UpdateChoice(Student_Class student)
        {
            Console.WriteLine(
                    "_______________________________\n" +
                    "Options available:\n" +
                    "-------------------------------\n" +
                    "1. Change First Name \n" +
                    "2. Change Last Name \n" +
                    "3. Change Gemder \n" +
                    "4. Change Adress \n" +
                    "5. Change PESEL \n" +
                    "6. Change Grade \n" +
                    "0. Exit\n" +
                    "-------------------------------\n" +
                    "Enter your choice:");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                ErrorMsg.WrongChoiceInput();
            }

            switch (choice)
            {
                case 1:
                    StuUpdate.UpdateFirstName(student);
                    break;
                case 2:
                    StuUpdate.UpdateLastName(student);
                    break;
                case 3:
                    StuUpdate.UpdateGender(student);
                    break;
                case 4:
                    StuUpdate.UpdateAdress(student);
                    break;
                case 5:
                    StuUpdate.UpdatePesel(student);
                    break;
                case 6:
                    StuUpdate.UpdateGrade(student);
                    break;
                case 0:
                    return;
                default:
                    ErrorMsg.GenericError();
                    break;
            }
        }
    }
}
