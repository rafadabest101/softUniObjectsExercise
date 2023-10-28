namespace softUniClassesExc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i ++)
            {
                string[] details = Console.ReadLine().Split(' ').ToArray();
                Student student = new Student()
                {
                    FirstName = details[0],
                    LastName = details[1],
                    Grade = double.Parse(details[2])
                };
                students.Add(student);
            }

            List<double> printedGrades = new List<double>();
            while(printedGrades.Count < students.Count)
            {
                foreach(Student student in students)
                {
                    if(student.Grade == GetMaxGrade(students, printedGrades))
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
                        printedGrades.Add(student.Grade);
                    }
                }
            }
        }
        
        static double GetMaxGrade(List<Student> students, List<double> printedGrades)
        {
            double maxGrade = 0.0d;
            foreach(Student student in students)
            {
                if(student.Grade >= maxGrade && !printedGrades.Contains(student.Grade)) maxGrade = student.Grade;
            }
            return maxGrade;
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}