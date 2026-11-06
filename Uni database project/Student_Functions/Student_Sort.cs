using System;
using System.Collections.Generic;
using System.Text;
using Uni_database_project.Classes;
using Uni_database_project.Database_Operations;

namespace Uni_database_project.Student_Functions
{
    public class Student_Sort
    {
        private Student_List DataList;
        public Student_Sort(Student_List dataList)
        {
            this.DataList = dataList;
        }

        public void SortByPESEL()
        {
            DataList.Database.Sort(delegate (Student_Class x, Student_Class y)
            {
                if (x.PESEL_Number == null && y.PESEL_Number == null) return 0;
                else if (x.PESEL_Number == null) return -1;
                else if (y.PESEL_Number == null) return 1;
                else return x.PESEL_Number.CompareTo(y.PESEL_Number);
            });
        }

        public void SortByName()
        {
            DataList.Database.Sort(delegate (Student_Class x, Student_Class y)
            {
                if (x.LastName == null && y.LastName == null) return 0;
                else if (x.LastName == null) return -1;
                else if (y.LastName == null) return 1;
                else return x.LastName.CompareTo(y.LastName);
            });
        }
    }
}
