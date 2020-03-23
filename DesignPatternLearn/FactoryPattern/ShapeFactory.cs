using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    //创建一个工厂，生成基于给定信息的实体类的对象。
    class ShapeFactory
    {
        //使用 getShape 方法获取形状类型的对象
        public IShape getSharp(string sharpType)
        {
            if (sharpType == null)
                return null;

            if (sharpType.ToLower().Equals("circle"))
            {
                return new Circle();
            }
            else if (sharpType.ToLower().Equals("rectangle"))
            {
                return new Rectangle();
            }
            else if (sharpType.ToLower().Equals("square"))
            {
                return new Square();
            }

            return null;
        }
    }
}
