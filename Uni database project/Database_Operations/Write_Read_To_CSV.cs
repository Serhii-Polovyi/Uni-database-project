using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Student_Functions;

namespace Uni_database_project.Database_Operations
{
    public class Write_Read_To_CSV
    {

        private Student_List Data;

        public Write_Read_To_CSV(Student_List data) 
        {
            this.Data = data;
        }


        public async Task WriteToCSV()
        {

            using var writer = new StreamWriter(
                "Student_Data.csv",
                false,
                Encoding.UTF8
                );

            await writer.WriteLineAsync(
                "Student ID," +
                "First name," +
                "Last name," +
                "Gender," +
                "Adress," +
                "PESEL number");

            foreach (var student in Data.Database)
            {
                await writer.WriteLineAsync($"{student}");
            }

            Console.WriteLine("!!! Students saved to CSV !!!");
        }

        public async Task ReadFromCSV()
        {
            if (!File.Exists("Student_Data.csv"))
            {
                Console.WriteLine("!!! No saved student data found !!!");
                return;
            }

            string[] buffer = await File.ReadAllLinesAsync("Student_Data.csv");

            Data.Database.Clear();

            foreach (string line in buffer.Skip(1))
            {
                string[] parts = line.Split(',');

                if (parts.Length != 6)
                    continue;

                Student_Class student = new Student_Class(

                    Convert.ToInt32(parts[0]),
                    parts[1],
                    parts[2],
                    Enum.Parse<Gender>(parts[3], true),
                    parts[4],
                    parts[5]
                    );
                Data.Database.Add(student);
            }

            Console.WriteLine("!!! Students loaded from the file !!!");
        }
    }
}
