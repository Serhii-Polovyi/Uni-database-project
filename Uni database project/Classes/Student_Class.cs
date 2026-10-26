namespace Uni_database_project.Classes
{

    public enum Gender
    {
        Male = 1,
        Female,
        Non_Binary,
        Apache_Atack_Helicopter,
        Armour_Piercing_Fin_Stabilized_Dicarding_Sabot_Round,
        High_Performance_Fiber_Reinforced_Concrete_Masonry_Brick,
        Protogen,
        Other
    }

    public class Student_Class
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender SelectedGender { get; set; }
        public string Adress { get; set; }
        public string PESEL_Number { get; set; }

        public Student_Class(int studentID, string firstName, string lastName, Gender selectedGender, string adress, string pESEL_Number)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            SelectedGender = selectedGender;
            Adress = adress;
            PESEL_Number = pESEL_Number;
        }

        public override string ToString()
        {
            return $"{StudentID},{FirstName},{LastName},{SelectedGender},{Adress},{PESEL_Number}";
        }
    }

}
