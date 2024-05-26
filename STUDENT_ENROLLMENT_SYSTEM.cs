namespace Student_Enrollment_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Security())
            {
                School school = new School();
                while (true)
                school.Run();
            }
            else
            {
                Console.WriteLine("Invalid Username or Password");
            }
        }

        static bool Security()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            return (username == "ENROLLMENT" && password == "register") ? true : false;
        }
    }

    class School
    {
        List<Student> students = new List<Student>()
            {
                new Student("Jophil", "Gulane", "Computer Science", "Block 2"),
            };

        List<Course> courses = new List<Course>()
            {
                new Course("Discrete Structure"),
                new Course("Programming II"),
            };
        public void Run()
        {


            Console.WriteLine("Welcome to School Enrollment System");
            Console.WriteLine("Select Action: ");
            Console.WriteLine("1.Enroll");
            Console.WriteLine("2.Drop");
            Console.WriteLine("3.Student List");

            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    EnrollCourse();
                    break;
                case "2":
                    DropCourse();
                    break;
                case "3":
                    StudentList();   
                    break;
                case "4":
                    StudentProfile();
                    break;
            }


        }

        public void EnrollCourse() 
        {
            Student student = SelectStudent();

            if (student == null)
            {
                Console.WriteLine("Student Not Found");
            }
            else if (student.courses.Count >= 5)
            {
                Console.WriteLine("Can't Enroll More Than 5 Courses");
            }
            else
            {
                Course courseToAdd = SelectCourse();
                student.courses.Add(courseToAdd);
            }
            
        }

        public void DropCourse()
        {

        }

        public void StudentList()
        {
            Console.WriteLine("1.Add Student");
            Console.WriteLine("2.Remove Student");
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    string[] studentInfo = { "First Name", "Last Name", "Program", "Block" };
                    string[] student = new string[studentInfo.Length];

                    for (int i = 0; i < studentInfo.Length; i++) 
                    {
                        Console.WriteLine($"Enter {studentInfo[i]}: ");
                        student[i] = Console.ReadLine();
                    }
                    Student newStudent = new Student(student[0], student[1], student[2], student[3]);
                    students.Add(newStudent);
                    break;
                case "2":
                    Student studentToRemove = SelectStudent();
                    students.Remove(studentToRemove);
                    break;
            }
        }

        public void StudentProfile()
        {
            Student student = SelectStudent();

            if (student != null)
            {
                Console.WriteLine($"Student First Name: {student.FirstName}");
                Console.WriteLine($"Student Last Name: {student.LastName}");
                Console.WriteLine($"Student Program: {student.Program}");
                Console.WriteLine($"Student Block: {student.Block}");

                Console.WriteLine("Enrolled Courses: ");
                for (int i = 0; i < student.courses.Count; i++)
                {
                    Console.WriteLine(student.courses[i].CourseName);
                }
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
        }

        Student SelectStudent()
        {
            Console.WriteLine("List of Students: ");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i+1} {students[i].FirstName}, {students[i].LastName}");
            }
            int studentOption = int.Parse( Console.ReadLine() );

            if (studentOption > 0 &&  studentOption <= students.Count)
            {
                return students[studentOption - 1];
            }
            else
            {
                return null;
            }
        }

        Course SelectCourse()
        {
            Console.WriteLine("List of Courses: ");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1} {courses[i].CourseName}");
            }
            int courseOption = int.Parse(Console.ReadLine());

            if (courseOption > 0 && courseOption <= courses.Count)
            {
                return courses[courseOption - 1];
            }
            else
            {
                return null;
            }
        }


    }

    class Student
    {
        public string FirstName;
        public string LastName;
        public string Program;
        public string Block;
        public List<Course> courses;

        public Student(string firstName, string lastName, string course, string block)
        {
            FirstName = firstName;
            LastName = lastName;
            courses = new List<Course>();
            Block = block;
        }
    }

    class Course
    {
        public string CourseName;

        public Course(string CourseName) 
        { 
            this.CourseName = CourseName;
        }
    }
}
