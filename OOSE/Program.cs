using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oose___A02
{

    public enum Deliverable{
        Assignment,
        Quiz,
        Sessional,
        Final,
    }

    public interface IDelivarable {
        void DeliverableInfo();
    }

    public class Assignment : IDelivarable
    {
        private string _title { get; set; }
        public string Title => _title;

        public Assignment(string title) {
            _title = title;
            Console.WriteLine("Assignment: " + title + " created");
        }
        public void DeliverableInfo()
        {
            Console.WriteLine("Assignment: " + _title);
        }
    }

    public class Quiz : IDelivarable
    {
        private string _title { get; set; }
        public string Title => _title;

        public Quiz(string title)
        {
            _title = title;
            Console.WriteLine("Quiz: " + title + " created");
        }

        public void DeliverableInfo()
        {
            Console.WriteLine("Quiz: " + _title);
        }
    }
    public class Sessional : IDelivarable
    {
        private string _title { get; set; }
        public string Title => _title;

        public Sessional (string title) {
            _title = title;
            Console.WriteLine("Sessional: " + title + " created");
        }

        public void DeliverableInfo()
        {
            Console.WriteLine("Quiz: " + _title);
        }
    }
    public class Final : IDelivarable
    {
        private string _title { get; set; }
        public string Title => _title;

        public Final(string title) {
            _title = title;
            Console.WriteLine("Sessional: " + title + " created");
        }

        public void DeliverableInfo()
        {
            Console.WriteLine("Sessional: " + _title);
        }
    }

    public class DeliverableFactory
    {

        public IDelivarable CreateDeliverable(Deliverable deliverable, string deliverableTitle) 
        {
            switch (deliverable)
            {
                case Deliverable.Assignment:
                    return new Assignment(deliverableTitle);
                 
                case Deliverable.Quiz:
                    return new Quiz(deliverableTitle);
                  
                case Deliverable.Sessional:
                    return new Sessional(deliverableTitle);
                    
                case Deliverable.Final:
                    return new Final(deliverableTitle);
                    
                default:
                    return null;
                  
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DeliverableFactory factory = new DeliverableFactory();
            factory.CreateDeliverable(Deliverable.Assignment, "Assignment 1");
            factory.CreateDeliverable(Deliverable.Assignment, "Assignment 2");
            factory.CreateDeliverable(Deliverable.Quiz, "Quiz 1");
            factory.CreateDeliverable(Deliverable.Quiz, "Quiz 2");
            factory.CreateDeliverable(Deliverable.Sessional, "Sessional 1");
            factory.CreateDeliverable(Deliverable.Sessional, "Sessional 2");
            factory.CreateDeliverable(Deliverable.Final, "Terminal");
            Console.ReadKey();
            
        }
    }
}
