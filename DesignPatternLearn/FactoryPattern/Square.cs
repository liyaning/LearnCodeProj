using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{ 
    //创建实现接口的实体类。
    class Square : IShape
    {
        public void draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
            //Console.ReadKey();
        }
    }
}
