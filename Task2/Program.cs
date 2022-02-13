using System;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Task4")]

namespace Task2
{
    public class MyList<T>
    {
        T[] array;

        public MyList(T firstElement)
        {
            array = new T[1];
            array[0] = firstElement;
        }

        public void Add(T element)
        {
            T[] temp = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            temp[array.Length] = element;
            array = temp;
        }

        public T this[int index]
        {
            get 
            {
                if (index < array.Length) 
                    return array[index];
                else
                {
                    Console.WriteLine("Not found");
                    return default(T);
                }
            }
        }

        public int NumberOfElements => array.Length;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"List of {this.GetType()}\n");
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append($"\t{i + 1}. - {array[i].ToString()}\n");
            }
            return sb.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<string> names = new MyList<string>("Denis");
            names.Add("Ivan");
            names.Add("Katya");
            names.Add("Egor");
            Console.WriteLine(names);

            Console.WriteLine(names[2]);
            Console.WriteLine(names[5]);

            Console.WriteLine($"Number of elements: {names.NumberOfElements}");

            MyList<int> numbers = new MyList<int>(7);
            numbers.Add(152);
            numbers.Add(20);
            Console.WriteLine(numbers);
            Console.WriteLine(numbers[0]);
        }
    }
}
