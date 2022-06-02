using System;

namespace _5_LinkedList2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LinkedList2<int> ll = new LinkedList2<int>();

            ll.PushBack(22);
            ll.PushBack(21);
            ll.PushBack(42);

            foreach (var item in ll)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            ll.RemoveAt(1);
            foreach (var item in ll)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            ll.RemoveAt(0);
            foreach (var item in ll)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
