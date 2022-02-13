using System;
using System.Text;
using Task2;

namespace Task4
{
    public static class MyListExtension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] arrayFromList = new T[list.NumberOfElements];
            for (int i = 0; i < list.NumberOfElements; i++)
            {
                arrayFromList[i] = list[i];
            }
            return arrayFromList;
        }

        public static void ShowArray<T>(this T[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Show: {array.GetType()}\n");
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append($"\t{i + 1}:\t{array[i].ToString()}\n");
            }
            Console.WriteLine(sb.ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string line = new string('-', Console.WindowWidth);

            MyList<string> names = new MyList<string>("Denis");
            names.Add("Ivan");
            names.Add("Katya");
            names.Add("Egor");
            Console.WriteLine(names);
     
            Console.WriteLine(line);
            names.GetArray().ShowArray();

            Console.WriteLine(line);
            int[] arrayInt = { 7, 5, 6 };
            arrayInt.ShowArray();

            Console.WriteLine(line);
            MyList<int> numbers = new MyList<int>(7);
            numbers.Add(152);
            numbers.Add(20);
            numbers.GetArray().ShowArray();
        }
    }
}
