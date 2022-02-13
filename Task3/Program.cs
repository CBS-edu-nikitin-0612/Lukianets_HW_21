using System;
using System.Linq;
using System.Text;

namespace Task3
{
    internal class MyDictionary<TKey, TValue>
    {
        private TKey[] key;
        private TValue[] value;
        private bool _keyIsValue;

        public MyDictionary(TKey firstKey, TValue firstValue)
        {
            key = new TKey[1];
            value = new TValue[1];
            key[0] = firstKey;
            value[0] = firstValue;

            _keyIsValue = key[0].GetType().IsValueType;
        }

        private MyDictionary(int size)
        {
            key = new TKey[size];
            value = new TValue[size];
        }

        public TValue this[TKey keyIndex]
        {
            get
            {
                if (key.Contains(keyIndex))
                {
                    int index = Array.IndexOf(this.key, keyIndex);
                    return value[index];
                }
                Console.Write("No element for ");
                return default(TValue);
            }
        }

        public string this[int index]
        {
            get
            {
                if (index < key.Length)
                    return $"index {index}: {key[index]} - {value[index]}";
                else 
                    return string.Empty;
            }
        }

        public int NumberOfElements => key.Length;

        public void Add(TKey key, TValue value)
        {
            //bool isValue = this.key[0].GetType().IsValueType;

            for (int i = 0; i < this.key.Length; i++)
            {
                if ((_keyIsValue && this.key[i].ToString() == default(TKey).ToString()) || 
                        (!_keyIsValue && this.key[i] == null))
                {
                    this.key[i] = key;
                    this.value[i] = value;
                    //break;
                    return;
                }
            }

            // dictionary has to be extended
            MyDictionary<TKey, TValue> temp = new MyDictionary<TKey, TValue>(this.key.Length + 1);

            // copy old(this.) dictionaty
            for (int j = 0; j < this.key.Length; j++)
            {
                temp.key[j] = this.key[j];
                temp.value[j] = this.value[j];
            }
            // Add element
            temp.key[this.key.Length] = key;
            temp.value[this.value.Length] = value;

            // redirect reference to newly created dictionary
            this.key = temp.key;
            this.value = temp.value;
        }

        public override string ToString()
        {
            //bool isValue = key[0].GetType().IsValueType;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Dictionaty({key.GetType().Name}, {value.GetType().Name})\n");
            for (int i = 0; i < key.Length; i++)
            {
                // append info about next not null element
                if ((_keyIsValue && this.key[i].ToString() != default(TKey).ToString()) || 
                    (!_keyIsValue && this.key[i] != null))
                {
                    sb.Append($"\tindex {i}: {key[i]} - {value[i]}\n");
                }
            }
            return sb.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string line = new string('-', Console.WindowWidth);

            MyDictionary<string, string> engEsp = new MyDictionary<string, string>("song", "la canción (f)");
            engEsp.Add("apple", "la manzana (f)");
            engEsp.Add("city", "la ciudad (f)");
            engEsp.Add("country", "el país (m)");
            Console.Write(engEsp);
            Console.WriteLine(line);

            Console.WriteLine($"engEsp[\"country\"]: {engEsp["country"]}");
            Console.WriteLine($"engEsp[\"dscd\"]: {engEsp["dscd"]}");
            Console.WriteLine($"engEsp[0]: {engEsp[0]}" );
            Console.WriteLine($"Number of elements: {engEsp.NumberOfElements}");
            Console.WriteLine(line);

            MyDictionary<int, string> numbers = new MyDictionary<int, string>(1, "uno");
            numbers.Add(2, "dos");
            numbers.Add(3, "tres");
            Console.WriteLine(numbers);
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[1]);
            Console.WriteLine($"Number of elements: {numbers.NumberOfElements}");
        }
    }
}
