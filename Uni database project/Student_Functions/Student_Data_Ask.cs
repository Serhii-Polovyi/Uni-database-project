using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;
using Uni_database_project.Main_Functions;

namespace Uni_database_project.Student_Functions
{
    public class Student_Data_Ask
    {
        private ErrorMessages ErrorMsg;
        private Student_List DataList;

        public Student_Data_Ask(ErrorMessages errorMsg, Student_List dataList)
        {
            this.ErrorMsg = errorMsg;
            this.DataList = dataList;
        }

        public string TakeFistName()
        {
            while (true)
            {
                Console.WriteLine(
                    "___________________________\n" +
                    "Enter student's first name: "
                    );
                string firstName = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    ErrorMsg.FieldIsEmpty();
                    continue;
                }

                return firstName;
            }

        }

        public string TakeLastName()
        {
            while (true)
            {
                Console.WriteLine(
                    "___________________________\n" +
                    "Enter student's last name: "
                    );
                string lastName = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(lastName))
                {
                    ErrorMsg.FieldIsEmpty();
                    continue;
                }
                return lastName;
            }
        }

        public Gender TakeGender()
        {
            while (true)
            {
                Console.WriteLine(
                    "_______________________\n" +
                    "Enter student's gender \n" +
                    "_______________________\n" +
                    "options are \n" +
                    "------------\n" +
                    "1. Male\r\n" +
                    "2. Female\r\n" +
                    "3. Non-Binary\r\n" +
                    "4. Apache Atack Helicopter\r\n" +
                    "5. Armour Piercing Fin Stabilized Dicarding Sabot Round\r\n" +
                    "6. High Performance Fiber Reinforced Concrete Masonry Brick\r\n" +
                    "7. Protogen\r\n" +
                    "8. Other\r\n" +
                    "Type in the number you want to choose: "
                    );
                string input = Console.ReadLine() ?? "";

                if (Enum.TryParse<Gender>(input, true, out Gender selectedGender)
                    && Enum.IsDefined(typeof(Gender), selectedGender))
                {
                    return selectedGender;
                }
                ErrorMsg.WrongChoiceInput();
            }

        }

        public string TakeAdress()
        {
            while (true)
            {
                Console.WriteLine(
                    "_______________________\n" +
                    "Enter student's adress: "
                    );
                string? adress = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(adress))
                {
                    ErrorMsg.FieldIsEmpty();
                    continue;
                }

                return adress;
            }
        }

        public int TakeID()
        {
            while (true)
            {
                Console.WriteLine(
                        "___________________\n" +
                        "Enter student's ID: "
                        );
                int studentID;
                if (!int.TryParse(Console.ReadLine(), out studentID))
                {
                    ErrorMsg.Incorrectinput();
                    continue;
                }

                if (int.IsNegative(studentID))
                {
                    ErrorMsg.ValueIsNegative();
                    continue;
                }

                if (DataList.Database.Any(student => student.StudentID == studentID))
                {
                    ErrorMsg.AlreadyExists();
                    continue;
                }

                return studentID;
            }
        }

        public double TakeGrade()
        {
            while (true)
            {
                Console.WriteLine(
                        "___________________\n" +
                        "Enter student's Grade: " +
                        "(use coma as divider, grade step 0.5)"
                        );
                double grade;
                if (!double.TryParse(Console.ReadLine(), out grade))
                {
                    ErrorMsg.Incorrectinput();
                    continue;
                }

                if (!(grade == 1 || grade == 2 || grade == 3 || grade == 3.5 || grade == 4 || grade == 4.5 || grade == 5))
                {
                    ErrorMsg.InvalidGrade();
                    continue;
                }

                if (double.IsNegative(grade))
                {
                    ErrorMsg.ValueIsNegative();
                    continue;
                }
                return grade;
            }
        }

        public string TakePESEL()
        {

            while (true)
            {
                Console.WriteLine(
                    "_____________________________\n" +
                    "Enter student's PESEL number: ");
                string PESEL_number = Console.ReadLine() ?? "";

                bool onlyNumbers = PESEL_number.All(char.IsDigit);
                if (!onlyNumbers)
                {
                    ErrorMsg.Incorrectinput();
                    continue;
                }

                if (DataList.Database.Any(stuent => stuent.PESEL_Number == PESEL_number))
                {
                    ErrorMsg.AlreadyExists();
                    continue;
                }

                if (CheckPESEL(PESEL_number) == true)
                {
                    return PESEL_number;
                }
            }
        }

        public bool CheckPESEL(string PESEL_number)
        {
            string pesel = Convert.ToString(PESEL_number);
            int[] mask = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            if (pesel.Length != 11)
            {
                ErrorMsg.PESELIncorrectLength();
                return false;

            }

            long sum = 0;
            for (int i = 0; i < 10; i++)
            {
                int digit = pesel[i] - '0';
                sum += digit * mask[i];
            }

            long Key = Convert.ToInt64(PESEL_number);
            int KeyCheck = Convert.ToInt32(sum % 10);

            if (KeyCheck != (10 - Key % 10) % 10)
            {
                ErrorMsg.PESELIsWrong();
                return false;
            }
            else
            {
                ErrorMsg.PESELIsCorrect();
                return true;
            }
        }
    }
}
