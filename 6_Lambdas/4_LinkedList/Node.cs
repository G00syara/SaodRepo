using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Lambdas
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node() { }

        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Next { get; set; }
    }

}
