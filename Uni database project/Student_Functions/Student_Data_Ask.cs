using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;

namespace Uni_database_project.Student_Functions
{
    public class Student_Data_Ask
    {
        private Student_List Data;

        public Student_Data_Ask(Student_List data)
        {
            this.Data = data;
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
                    Console.WriteLine("!!! First name cannot be empty !!!");
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
                    Console.WriteLine("!!! Last name cannot be empty !!!");
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

                Console.WriteLine("!!! Invalid Choice. Please enter a listed option !!!");
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
                    Console.WriteLine("!!! Adress cannot be empty !!!");
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
                while (!int.TryParse(Console.ReadLine(), out studentID))
                {
                    Console.WriteLine("!!! Wrong input for ID! try again !!!");
                }

                if (int.IsNegative(studentID))
                {
                    Console.WriteLine("!!! ID cannot be negative !!!");
                    continue;
                }

                foreach (var student in Data.Database)
                {
                    if (student.StudentID == studentID)
                    {
                        Console.WriteLine("!!! ID matches already existing one !!!");
                        continue;
                    }
                }
                return studentID;
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
                    Console.WriteLine("!!! Incorrect input! the string contains non numbers !!!");
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
                Console.WriteLine("!!! PESEL number is too short/long !!!");
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

            if (KeyCheck != (10 - Key % 10))
            {
                Console.WriteLine("!!! PESEL number is incorrect !!!");
                return false;
            }
            else
            {
                Console.WriteLine("!!! PESEL number set up correctly !!!");
                return true;
            }
        }
    }
}
