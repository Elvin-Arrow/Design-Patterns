using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02
{
    public abstract class Info
    {
        private string _Title { get; set; }
        public string Title => _Title;
        public Info(string title)
        {
            _Title = title;
        }
    }

    public abstract class Deliverable : Info
    {
        private int _totalMarks { get; set; }
        public int totalMarks => _totalMarks;

        private int _obtainedMarks { get; set; }
        public int obtainedMarks => _obtainedMarks;

        public Deliverable(string title, int totalMarks, int marksObtained) : base(title) {
            _totalMarks = totalMarks;
            _obtainedMarks = marksObtained;
        }
    }

    public class StudentInfo : Info{
        private String _name { get; set; }
        public String Name => _name;
        
        private Group _group { get; set; }
        public Group group => _group;

        private List<Exam> Deliverables { get; set; }

        public StudentInfo(string name, Group group) : base(name) {
            _name = name;
            _group = group;
        }
    
    }

    public class Group : Info{

        public Group(string title) : base(title) {
        }
    }


    public class Assignment : Deliverable
    {
        public Assignment(string title, int total, int obtained) : base(title, total, obtained) { }
        
    }
    public class Quiz : Deliverable
    {
        public Quiz(string title, int total, int obtained) : base(title, total, obtained) { }
    }
    public class Sessional : Deliverable
    {
        public Sessional(string title, int total, int obtained) : base(title, total, obtained) { }
    }
    public class Final : Deliverable
    {
        public Final(string title, int total, int obtained) : base(title, total, obtained) { }
    }
    public class Other : Deliverable
    {
        public Other(string title, int total, int obtained) : base(title, total, obtained) { }
    }

    public abstract class Exam
    {
        private string _Title { get; set; }
        public string Title => _Title;

        private List<Info> _Tests = new List<Info>();
        public List<Info> Tests => _Tests;

        public Exam(string title)
        {
            _Title = title;
            this.Create();
        }
        public abstract void Create();
    }

    public class ExamFactory : Exam
    {
        public ExamFactory(string title) : base(title) { }
        public override void Create()
        {
            base.Tests.Add(new Assignment("Assignment - 1", 10, -1));
            base.Tests.Add(new Assignment("Assignment - 2", 10, -1));
            base.Tests.Add(new Assignment("Assignment - 3", 10, -1));
            base.Tests.Add(new Assignment("Assignment - 4", 10, -1));
            base.Tests.Add(new Quiz("Quiz - 1", 10, -1));
            base.Tests.Add(new Quiz("Quiz - 2", 10, -1));
            base.Tests.Add(new Quiz("Quiz - 3", 10, -1));
            base.Tests.Add(new Quiz("Quiz - 4", 10, -1));
            base.Tests.Add(new Sessional("Sessional - 1", 10, -1));
            base.Tests.Add(new Sessional("Sessional - 2", 15, -1));
            base.Tests.Add(new Final("Fianl Term", 50, -1));
            base.Tests.Add(new Other("Other type", 10, -1));
        }
    }


    public abstract class Student
    {
        private StudentInfo _studentInfo { get; set; }
        public StudentInfo StudentInfo => _studentInfo;

        private List<StudentInfo> _students { get; set; }
        public List<StudentInfo> Students => _students;

        public Student(StudentInfo studentInfo)
        {
            _studentInfo = studentInfo;
            this.Create();
        }

        public abstract void Create();
    }

    public class StudentFactory : Student
    {
        private StudentInfo _studentInfo { get; set; }


        public StudentFactory(StudentInfo studentInfo) : base(studentInfo) {
            _studentInfo = studentInfo;
            this.Create();
        }
        public override void Create()
        {
            base.Students.Add(_studentInfo);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment No- 02");

            List <ExamFactory> exams = new List<ExamFactory>()
            {
                new ExamFactory("Fall 2020"),
                new ExamFactory("Spring 2021"),
                new ExamFactory("Fall 2021"),
                new ExamFactory("Spring 2022"),
            
            };

            List<StudentFactory> students = new List<StudentFactory>()
            {
                new StudentFactory(new StudentInfo("Student A", new Group("Group 1"))),
                new StudentFactory(new StudentInfo("Student B", new Group("Group 2"))),
                new StudentFactory(new StudentInfo("Student C", new Group("Group 2"))),
                new StudentFactory(new StudentInfo("Student D", new Group("Group 1"))),
                new StudentFactory(new StudentInfo("Student E", new Group("Group 2"))),
                new StudentFactory(new StudentInfo("Student F", new Group("Group 1"))),
                new StudentFactory(new StudentInfo("Student G", new Group("Group 1"))),
            };

            var index =1;
            foreach (var exam in exams)
            {
                Console.WriteLine("\n" + $"{index++}.  {exam.Title}  -  {exam.GetType().Name}");
                foreach (var test in exam.Tests)
                {
                    Console.WriteLine("".PadRight(10) + $".  {test.Title}  -  {test.GetType().Name}");
                }
            }

            Console.ReadKey();

        }
    }
}
