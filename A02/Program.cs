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

    public class Student : Info{
        public Student(string title) : base(title) {
        }
    
    }

    public class Group : Info{
        public Group(string title) : base(title) {
        }
    }


    public class Assignment : Info
    {
        public Assignment(string title) : base(title) { }
        
    }
    public class Quiz : Info
    {
        public Quiz(string title) : base(title) { }
    }
    public class Sessional : Info
    {
        public Sessional(string title) : base(title) { }
    }
    public class Final : Info
    {
        public Final(string title) : base(title) { }
    }
    public class Other : Info
    {
        public Other(string title) : base(title) { }
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
            Tests.Add(new Student("Muhammad Talha Bin Mansoor"));
            Tests.Add(new Group("Group-1"));
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

            

            int atr = 1;

            while (atr != 0) {
                Console.WriteLine(" Enter 1 to add student \n Enter 2 to add data of student \n Enter 3 for see all students \n Enter 4 to exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Data Entry");

                        Console.WriteLine("Enter Student ID");
                        string stdID = Console.ReadLine();
                        Console.WriteLine("Do you want to enter assignment Marks... (y/n)");
                        string check = Console.ReadLine();
                        if(check == "y")
                        {
                            Console.WriteLine("Enter title");
                            string asign = Console.ReadLine();
                            Console.WriteLine("Enter Obtained marks");
                            string asignObtn = Console.ReadLine();
                            Console.WriteLine("Enter Total  marks");
                            string asignTot = Console.ReadLine();
                        }

                        Console.WriteLine("Do you want to enter Quiz Marks... (y/n)");
                        string qcheck = Console.ReadLine();
                        if (qcheck == "y")
                        {
                            Console.WriteLine("Enter title");
                            string asign = Console.ReadLine();
                            Console.WriteLine("Enter Obtained marks");
                            string asignObtn = Console.ReadLine();
                            Console.WriteLine("Enter Total  marks");
                            string asignTot = Console.ReadLine();
                        }

                        Console.WriteLine("Do you want to enter Sessional Marks... (y/n)");
                        string scheck = Console.ReadLine();
                        if (scheck == "y")
                        {
                            Console.WriteLine("Enter title");
                            string asign = Console.ReadLine();
                            Console.WriteLine("Enter Obtained marks");
                            string asignObtn = Console.ReadLine();
                            Console.WriteLine("Enter Total  marks");
                            string asignTot = Console.ReadLine();
                        }

                        Console.WriteLine("Do you want to enter final Marks... (y/n)");
                        string fcheck = Console.ReadLine();
                        if (fcheck == "y")
                        {
                            Console.WriteLine("Enter title");
                            string asign = Console.ReadLine();
                            Console.WriteLine("Enter Obtained marks");
                            string asignObtn = Console.ReadLine();
                            Console.WriteLine("Enter Total  marks");
                            string asignTot = Console.ReadLine();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter Student Id");
                        break;

                    case 3:
                        break;

                    default:

                        break;


                }



            }
            


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
