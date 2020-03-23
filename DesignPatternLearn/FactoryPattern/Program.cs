using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            IShape shape1 = shapeFactory.getSharp("Circle");
            shape1.draw();

            IShape shape2 = shapeFactory.getSharp("Rectangle");
            shape2.draw();

            IShape shape3 = shapeFactory.getSharp("Square");
            shape3.draw();

            Console.Read();
        }
    }
}
