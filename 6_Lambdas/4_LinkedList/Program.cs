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
            list.PushBack(1322);
            list.PushBack(11);
            PrintList(list);

            list.PushBack(249);
            PrintList(list);    

            list.PushFront(75);
            list.PushFront(78);
            PrintList(list);

            list.PopFront();
            list.PopFront();
            PrintList(list);

            list.PopBack();
            list.PopBack();
            PrintList(list);

            list.Insert(2, 88);
            PrintList(list);

            list.Insert(2, 55);
            PrintList(list);

            list.RemoveAt(2);
            PrintList(list);

            list.RemoveAt(2);
            PrintList(list);

            Console.WriteLine(list.Last());
            Console.WriteLine(list.First());
            Console.WriteLine(list.Empty());

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            list.Clear();
            Console.WriteLine("\n" + list.Empty());


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
