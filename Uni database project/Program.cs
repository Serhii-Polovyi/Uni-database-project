using Uni_database_project.Database_Operations;
using Uni_database_project.Main_Functions;
using Uni_database_project.Student_Functions;

// fix ID break

Console.WriteLine(
    "===============================\n" +
    "        STUDENT DATABASE       \n" +
    "===============================\n");

Student_List DataList = new Student_List();

ErrorMessages ErrorMsg = new ErrorMessages();

Write_Read_To_CSV Write = new Write_Read_To_CSV(DataList, ErrorMsg);

Student_Data_Ask DataAsk = new Student_Data_Ask(ErrorMsg, DataList);

Student_Creation Creation = new Student_Creation(ErrorMsg, DataList, DataAsk);

Student_Search Search = new Student_Search(ErrorMsg, DataList);

Student_Sort Sort = new Student_Sort(DataList);

Student_Update Update = new Student_Update(ErrorMsg, DataList, Search, DataAsk);

Update_Choice_loop UpdateLoop = new Update_Choice_loop(ErrorMsg);

Update.UpdLoop = UpdateLoop;
UpdateLoop.StuUpdate = Update;

Choice_Loops ChoiceL = new Choice_Loops(ErrorMsg, Write, Creation, Search, Sort, Update);

await ChoiceL.StudentManagement();