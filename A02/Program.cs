using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02
{
    public enum FactoryType
    {
        Deliverable,
        Learner,
    }

    public enum DeliverableType
    {
        Assignment,
        Quiz,
        Sessional,
        Terminal,
    }

    public enum LearnerType
    {
        Student,
        Group,
    }

    public abstract class Deliverable
    {
        private string _title { get; set; }
        public string Title => _title;

        private double _marks { get; set; }
        public double Marks => _marks;

        public Deliverable(string title, double marks)
        {
            _title = title;
            _marks = marks;
        }

        public override string ToString()
        {
            return "Deliverable title: " + _title + "\nDeliverable marks: " + _marks.ToString();
        }
    }

    public class Assignment : Deliverable
    {
        public Assignment(string title, double marks) : base(title, marks)
        {
        }
    }

    public class Quiz : Deliverable
    {
        public Quiz(string title, double marks) : base(title, marks)
        {
        }
    }

    public class Sessional : Deliverable
    {
        public Sessional(string title, double marks) : base(title, marks)
        {
        }
    }

    public class Terminal : Deliverable
    {
        public Terminal(string title, double marks) : base(title, marks)
        {
        }
    }

    public abstract class Learner
    {
        private string _name { get; set; }
        public string Name => _name;

        protected Learner(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return "Name: " + _name;
        }
    }

    public class Student : Learner
    {
        private Group _group { get; set; }
        public Group Group => _group;

        public Student(string name, Group group = null) : base(name)
        {
            _group = group;
        }

        public override string ToString()
        {
            return base.ToString() + "\nGroup name: " + Group?.Name;
        }
    }

    public class Group : Learner
    {
        public Group(string name) : base(name)
        {
        }
    }

    public abstract class AbstractFactory
    {
    }

    public class DeliverableFactory : AbstractFactory
    {
        public Deliverable getDeliverable(DeliverableType type, string name, double marks)
        {
            switch (type)
            {
                case DeliverableType.Assignment:
                    return new Assignment(name, marks);

                case DeliverableType.Quiz:
                    return new Quiz(name, marks);

                case DeliverableType.Sessional:
                    return new Sessional(name, marks);

                case DeliverableType.Terminal:
                    return new Terminal(name, marks);
                default:
                    return null;
            }
        }
    }

    public class LearnerFactory : AbstractFactory
    {
        public Learner getLearner(LearnerType type, string name, Group group = null)
        {
            switch (type)
            {
                case LearnerType.Student:
                    return new Student(name, group);
                        
                case LearnerType.Group:
                    return new Group(name);

                default:
                    return null;
            }
        }
    }

    public class FactoryProducer
    {
        public static AbstractFactory getFactory(FactoryType type)
        {
            switch (type)
            {
                case FactoryType.Deliverable:
                    return new DeliverableFactory();

                case FactoryType.Learner:
                    return new LearnerFactory();
                        
                default:
                    return null;
            }
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            List<Deliverable> deliverables = new List<Deliverable>();
            List<Learner> learners = new List<Learner>();
            // Get Deliverable Factory
            DeliverableFactory deliverableFactory = (DeliverableFactory) FactoryProducer.getFactory(FactoryType.Deliverable);

            // Create Deliverables
            deliverables.Add(deliverableFactory.getDeliverable(DeliverableType.Assignment, "Assignment 1", 10.0));
            deliverables.Add(deliverableFactory.getDeliverable(DeliverableType.Assignment, "Assignment 2", 10.0));
            deliverables.Add(deliverableFactory.getDeliverable(DeliverableType.Quiz, "Quiz 1", 15.0));
            deliverables.Add(deliverableFactory.getDeliverable(DeliverableType.Quiz, "Quiz 2", 15.0));
            deliverables.Add(deliverableFactory.getDeliverable(DeliverableType.Sessional, "Sessional 1", 10.0));
            deliverables.Add(deliverableFactory.getDeliverable(DeliverableType.Sessional, "Sessional 2", 15.0));
            deliverables.Add(deliverableFactory.getDeliverable(DeliverableType.Assignment, "Terminal", 50.0));

            // Get Learner Factory
            LearnerFactory learnerFactory = (LearnerFactory)FactoryProducer.getFactory(FactoryType.Learner);

            learners.Add(learnerFactory.getLearner(LearnerType.Student, "Student A", new Group("Group 1")));
            learners.Add(learnerFactory.getLearner(LearnerType.Student, "Student B", new Group("Group 1")));
            learners.Add(learnerFactory.getLearner(LearnerType.Student, "Student C", new Group("Group 2")));
            learners.Add(learnerFactory.getLearner(LearnerType.Student, "Student D", new Group("Group 2")));
            learners.Add(learnerFactory.getLearner(LearnerType.Student, "Student E", new Group("Group 1")));

            Console.WriteLine("Deliverables...");
            foreach (var deliverable in deliverables)
            {
                Console.WriteLine(deliverable);
            }

            Console.WriteLine("\nLearners...");
            foreach (var learner in learners)
            {
                Console.WriteLine(learner);
            }


            Console.ReadKey();
        }
    }

}
