using Uni_database_project.Database_Operations;
using Uni_database_project.Student_Functions;

namespace Uni_database_project.Main_Functions
{
    public class Choice_Loops
    {
        private Student_List data;
        private Write_Read_To_CSV ToCSV;
        private Student_Creation Creation;
        private Student_Search Search;
        private Student_Sort Sort;
        
        public Choice_Loops(
            Write_Read_To_CSV toCSV,
            Student_Creation creation,
            Student_Search search,
            Student_Sort sort
            )
        {
            this.ToCSV = toCSV;
            this.Creation = creation;
            this.Search = search;
            this.Sort = sort;
        }

        public async Task StudentManagement()
        {

            await ToCSV.ReadFromCSV();

            while (true)
            {
                Console.WriteLine(
                    "_______________________________\n" +
                    "Options available:\n" +
                    "-------------------------------\n" +
                    "1. Add new student\n" +
                    "2. Remove Student\n" +
                    "3. Show all students\n" +
                    "4. Search by PESEL number\n" +
                    "5. Search by Name\n" +
                    "6. Sort by PESEL number\n" +
                    "7. Sort by Name\n" +
                    "0. Exit\n" +
                    "-------------------------------\n" +
                    "Enter your choice:");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("!!! Wrong input for this opertaion! try again !!!");
                }

                switch (choice)
                {
                    case 1:
                        Creation.AddStudent();
                        await ToCSV.WriteToCSV();
                        break;
                    case 2:

                        Creation.RemoveStudent();
                        await ToCSV.WriteToCSV();
                        break;
                    case 3:

                        Search.ShowStudents();
                        break;
                    case 4:

                        Search.SearchByPESEL();
                        break;
                    case 5:

                        Search.SearchByName();
                        break;
                    case 6:

                        Sort.SortByPESEL();
                        await ToCSV.WriteToCSV();
                        break;
                    case 7:

                        Sort.SortByName();
                        await ToCSV.WriteToCSV();
                        break;
                    case 0:
                        return;
                     default:
                        Console.WriteLine("!!! Something went wrong !!!");
                        break;
                }
            }
            
        }


    }
}
