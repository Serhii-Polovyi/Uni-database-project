using System;
using System.Collections.Generic;
using System.Text;

namespace Uni_database_project.Main_Functions
{
    public class ErrorMessages
    {

        //successes
        public void StudentLoadSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("!!! Students loaded from the file !!!");
            Console.ResetColor();
        }

        public void SaveSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("!!! Students saved to CSV !!!");
            Console.ResetColor();
        }

        public void PESELIsCorrect()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("!!! PESEL number set up correctly !!!");
            Console.ResetColor();
        }

        //errors

        public void NoStudentDataFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! No saved student data found !!!");
            Console.ResetColor();
        }

        public void GenericError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! Something went wrong !!!");
            Console.ResetColor();
        }

        public void WrongChoiceInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! Wrong input for this choice! try again !!!");
            Console.ResetColor();
        }

        public void StudentAdded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("!!! Student Added !!!");
            Console.ResetColor();
        }

        public void NoMatchingStudentFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Matching Students Were Found!");
            Console.ResetColor();
        }

        public void FieldIsEmpty()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! Field cannot be empty !!!");
            Console.ResetColor();
        }

        public void Incorrectinput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! Wrong input for this field! try again !!!");
            Console.ResetColor();
        }

        public void AlreadyExists()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! This field matches already existing value !!!");
            Console.ResetColor();
        }

        public void ValueIsNegative()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! Value cannot be negative !!!");
            Console.ResetColor();
        }

        public void PESELIncorrectLength()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! PESEL number is too short/long !!!");
            Console.ResetColor();
        }

        public void PESELIsWrong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! PESEL number doesn't match the ckecking standart !!!");
            Console.ResetColor();
        }

        public void InvalidGrade()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! Grade does not match the standarts !!!");
            Console.ResetColor();
        }
    }
}
