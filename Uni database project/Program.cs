using Uni_database_project.Database_Operations;
using Uni_database_project.Main_Functions;
using Uni_database_project.Student_Functions;

//add exit to search functions, fix loop if empty list
//add updating info on a created user

Console.WriteLine(
    "===============================\n" +
    "        STUDENT DATABASE       \n" +
    "===============================\n");

Student_List Data = new Student_List();

Write_Read_To_CSV Write = new Write_Read_To_CSV(Data);

Student_Data_Ask DataAsk = new Student_Data_Ask(Data);

Student_Creation Creation = new Student_Creation(Data, DataAsk);

Student_Search Search = new Student_Search(Data);

Student_Sort Sort = new Student_Sort(Data);

Student_Update Update = new Student_Update(Data, Search, DataAsk);

Choice_Loops ChoiceL = new Choice_Loops(Write, Creation, Search, Sort, Update);

await ChoiceL.StudentManagement();