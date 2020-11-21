using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02
{
    public abstract class Test
    {
        private string _Title {get;set;}
        public string Title => _Title;
        public Test (string title)
        {
            _Title = title;
         
        }




    }

    public class Assignment : Test{
        public Assignment (string title): base(title){}
    
    }

    public class Quiz : Test{

         public Quiz (string title): base(title){}
    }

    public class Sessional : Test{

         public Sessional (string title): base(title){}
    
    }

    public class Final : Test{

         public Final (string title): base(title){}

    
    }

    public abstract class ExamFactory{

        private List<Test> _Tests = new List<Test>();

        public List <Test> Tests => _Tests;

        public ExamFactory()
        {
            this.Create();
        
        }

        public abstract void Create();
    
    }

    public class Exam : ExamFactory{


        public override void Create()
        {
            Tests.Add( new Assignment("Assignment-01"));
            Tests.Add( new Assignment("Assignment-02"));
            Tests.Add( new Assignment("Assignment-03"));
            Tests.Add( new Assignment("Assignment-04"));
            Tests.Add( new Quiz("Quiz-01"));
            Tests.Add( new Quiz("Quiz-02"));
            Tests.Add( new Quiz("Quiz-03"));
            Tests.Add( new Quiz("Quiz-04"));
            Tests.Add( new Quiz("Quiz-05"));
            Tests.Add( new Sessional("Sessional-01"));
            Tests.Add( new Sessional("Sessional-02"));
            Tests.Add( new Final(("Final-01"));



        }


    }






    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment No- 02");
            List <ExamFactory> exams = new List<ExamFactory>()
            {
                new Exam(),  // Fall 2020
                new Exam(),  // spring 2020
            
            };
            var index =1;
            foreach (var exam in exams)
            {
                Console.WriteLine("\n"+ (index++)+ ".  "+exam.GetType().Name);
                foreach(var test in exam.Tests){
                    Console.WriteLine("   "+test.GetType().Name);
                
                }
            }

            Console.ReadKey();

        }
    }
}
