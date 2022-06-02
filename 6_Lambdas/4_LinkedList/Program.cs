using System;

namespace _6_Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            Console.WriteLine(list.Empty());

            PrintList(list);
            list.PushBack(12);
            list.PushBack(33);
            list.PushBack(52);
            list.PushBack(124);
            list.PushBack(36);
            list.PushBack(11);
            PrintList(list);

            Console.WriteLine();

            Console.WriteLine(list.Contains(1111));
            Console.WriteLine(list.Contains(12));

            Console.WriteLine(list.IndexOf(124));
            Console.WriteLine(list.IndexOf(11));

            Console.WriteLine();

            list.forEach(Console.WriteLine); // передаем функцию которую хотим выполнить с помощью метода forEach

            Console.WriteLine();

            Console.WriteLine(list.Find((x) => x > 50)); // ламда-функция (которая говорит число больше или меньше 50) передается в виде параметра и определяется прямо в скобках

            Console.WriteLine(list.FindIndex((x) => x > 50)); // здесь находим индекс для первого предиката 
            Console.WriteLine(list.FindIndex((x) => x > 100));

        }

        static public void PrintList(LinkedList<int> ll)
        {
            Console.Write("Count =" + ll.Count + " { ");
            for (int i = 0; i < ll.Count; ++i)
            {
                Console.Write(ll[i] + " ");
            }
            Console.WriteLine("}");
        }
    }
}
