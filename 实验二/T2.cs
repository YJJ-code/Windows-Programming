/*using System;
namespace Homework
{
    //定义收作业接口
    public interface IHomeworkService
    {
        void HomeworkCollecter();
    }
    //定义person类
    class person
    {
        public person()
        {
            Console.WriteLine("I am a person.");
        }
    }
    //定义teacher子类
    class teacher : person, IHomeworkService
    {
        public teacher()
        {
            Console.WriteLine("I am a teacher.");
        }
        public void HomeworkCollecter()
        {
            Console.WriteLine("I am a teacher,please hand in the homework.");
        }
    }
    //定义student子类
    class student : person, IHomeworkService
    {
        public student()
        {
            Console.WriteLine("I am a student.");
        }
        public void HomeworkCollecter()
        {
            Console.WriteLine("I am a student,i help teacher to collect homework.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            void DoHomeWorkCollector(IHomeworkService collector)
            {
                collector.HomeworkCollecter();
            }
            teacher teacher1 = new teacher();
            DoHomeWorkCollector(teacher1);
            Console.WriteLine("\n");
            student student1 = new student();
            DoHomeWorkCollector(student1);
        }
    }
}
*/