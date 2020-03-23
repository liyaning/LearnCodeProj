using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics; //特性
using System.Reflection; //反射

namespace AttributeLearn
{

    [AttributeUsage(AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Field |
    AttributeTargets.Method |
    AttributeTargets.Property,
    AllowMultiple = true)]

    public class DIYAttribute : System.Attribute
    {
        private int age;
        private String name;

        public DIYAttribute(int Age, String Name)
        {
            age = Age;
            name = Name;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String addre;
        public String Addre
        {
            get { return addre; }
            set { addre = value; }
        }
    }

    [DIYAttribute(103, "LiBai", Addre = "Beijing")]
    [DIYAttribute(104, "DuPu", Addre = "JiangXi")]
    public class Company
    {
        private String CompanyID;
        private int EmployeeMembers;
        private int EmployeeWage;

        public Company(String CompId, int EmpMem, int EmpWage)
        {
            CompanyID = CompId;
            EmployeeMembers = EmpMem;
            EmployeeWage = EmpWage;
        }

        [DIYAttribute(105, "Gree Group", Addre = "ZhuHai")]
        [DIYAttribute(117, "Lenovo Group", Addre = "ShengZhen")]
        [DIYAttribute(125, "TCL Group", Addre = "HuiZhou")]
        public void PayToalWage()
        {
            Console.WriteLine("{0} Company total pay wage:{1} RMB", (CompanyID), (EmployeeMembers * EmployeeWage));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "验证C#特性，反射";
            Console.ForegroundColor = ConsoleColor.Red;  //设置字体颜色为红色
            Console.BackgroundColor = ConsoleColor.Green; //设置黑屏为绿屏，即背景颜色


            //当上面的代码被编译和执行时，它会显示附加到类 Company 上的自定义特性：
            System.Reflection.MemberInfo info = typeof(AttributeLearn.Company);
            object[] attributes = info.GetCustomAttributes(true);
            for (int i = 0; i < attributes.Length; i++)
            {
                System.Console.WriteLine(attributes[i]);
            }
            AttributeLearn.Company TempCompany = new AttributeLearn.Company("APPLE", 10, 5000);
            TempCompany.PayToalWage();


            Console.ForegroundColor = ConsoleColor.Gray;  //设置字体颜色为红色
            Console.BackgroundColor = ConsoleColor.Black; //设置黑屏为绿屏，即背景颜色
            Console.WriteLine("\r\n----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;  //设置字体颜色为红色
            Console.BackgroundColor = ConsoleColor.Blue; //设置黑屏为绿屏，即背景颜色



            // 遍历 Company 类的特性
            Type type = typeof(AttributeLearn.Company);
            foreach (Object attributess in type.GetCustomAttributes(false))
            {
                AttributeLearn.DIYAttribute dbi = (AttributeLearn.DIYAttribute)attributess;
                if (null != dbi)
                {
                    Console.WriteLine("Age: {0}", dbi.Age);
                    Console.WriteLine("Name: {0}", dbi.Name);
                    Console.WriteLine("Address: {0}", dbi.Addre);
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;  //设置字体颜色为红色
            Console.BackgroundColor = ConsoleColor.Black; //设置黑屏为绿屏，即背景颜色
            Console.WriteLine("\r\n----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;  //设置字体颜色为红色
            Console.BackgroundColor = ConsoleColor.Blue; //设置黑屏为绿屏，即背景颜色


            // 遍历Company类方法特性
            Type typee = typeof(AttributeLearn.Company);
            foreach (MethodInfo m in typee.GetMethods())
            {
                foreach (Attribute a in m.GetCustomAttributes(true))
                {
                    AttributeLearn.DIYAttribute dbii = a as AttributeLearn.DIYAttribute;
                    if (null != dbii)
                    {
                        Console.WriteLine("Age: {0}", dbii.Age);
                        Console.WriteLine("Name: {0}", dbii.Name);
                        Console.WriteLine("Address: {0}", dbii.Addre);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
