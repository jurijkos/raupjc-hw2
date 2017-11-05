namespace Task1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Student s = (Student)obj;
            if (s.Name == this.Name && s.Jmbag == this.Jmbag && this.Gender == s.Gender)
            {
                return true;
            }
            return false;

        }
        public static bool operator== (Student a, Student b)
        {
            if (a.Equals(b))
            {
                return true;
            }
            return false;
        }
        public static bool operator!=(Student a, Student b)
        {
            if (a.Equals(b))
            {
                return false;
            }
            return true;
        }

    }

    public enum Gender
    {
        Male,
        Female
    }
}