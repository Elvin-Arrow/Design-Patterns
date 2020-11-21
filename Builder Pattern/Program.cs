using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public interface IBuilder
    {
        void buildPartA();
        void buildPartB();
        void buildPartC();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product product = new Product();

        public void buildPartA()
        {
            
        }

        public void buildPartB()
        {
            throw new NotImplementedException();
        }

        public void buildPartC()
        {
            throw new NotImplementedException();
        }
    }

    public class Director
    {
        private IBuilder builder;

        Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public void buildProduct()
        {
            builder.buildPartA();
            builder.buildPartB();
            builder.buildPartC();
        }
    }

    public class Product
    {
        public String partA { get; set; }
        public String partB { get; set; } 
        public String partC { get; set; }

      
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
