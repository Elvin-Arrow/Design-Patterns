using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02
{
    public abstract class Test
    {
        private string _Title { get; set; }
        public string Title => _Title;
        public Test(string title)
        {
            _Title = title;
        }
    }

    public class Assignment : Test
    {
        public Assignment(string title) : base(title) { }
        
    }
    public class Quiz : Test
    {
        public Quiz(string title) : base(title) { }
    }
    public class Sessional : Test
    {
        public Sessional(string title) : base(title) { }
    }
    public class Final : Test
    {
        public Final(string title) : base(title) { }
    }
    public class Other : Test
    {
        public Other(string title) : base(title) { }
    }

    public abstract class Exam
    {
        private string _Title { get; set; }
        public string Title => _Title;

        private List<Test> _Tests = new List<Test>();
        public List<Test> Tests => _Tests;

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
            Tests.Add(new Assignment("Assignment - 1"));
            Tests.Add(new Assignment("Assignment - 2"));
            Tests.Add(new Assignment("Assignment - 3"));
            Tests.Add(new Assignment("Assignment - 4"));
            Tests.Add(new Quiz("Quiz - 1"));
            Tests.Add(new Quiz("Quiz - 2"));
            Tests.Add(new Quiz("Quiz - 3"));
            Tests.Add(new Quiz("Quiz - 4"));
            Tests.Add(new Sessional("Sessional - 1"));
            Tests.Add(new Sessional("Sessional - 2"));
            Tests.Add(new Final("Fianl Term"));
            Tests.Add(new Other("Other type"));
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
