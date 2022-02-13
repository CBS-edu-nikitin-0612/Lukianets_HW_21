using System;

namespace AdditionalTask
{
    internal class Cat
    {
        public override string ToString()
        {
            return $"{this.GetType().Name}";
        }
    }

    internal class MyClass<T> 
    {
        static T obj;

        public MyClass(T o)
        {
            obj = o;
        }

        public static T FactoryMethod() 
        {
            return obj;
        }

        public override string ToString()
        {
            return $"{obj} is of type {obj.GetType().Name}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass<String> instance1 = new MyClass<string>("word");
            Console.WriteLine(instance1);

            MyClass<int> instance2 = new MyClass<int>(7);
            Console.WriteLine(instance2);

            MyClass<Cat> cat = new MyClass<Cat>(new Cat());
            Console.WriteLine(cat);
        }
    }
}
