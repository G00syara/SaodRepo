using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace _4_LinkedList
{
    class LinkedList<T> : IEnumerable<T>

    {
        public int Count { set; get; }

        public Node<T> Head = new Node<T>();

        public LinkedList() { }

        public void PushBack(T value)
        {
            Node<T> node = new Node<T>(value);

            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;

            Count++;
        }

        public void PushFront(T value)
        {
            Node<T> node = new Node<T>(value);
            if (Head.Next != null)
            {
                node.Next = Head.Next;
                Head.Next = node;
            }
            else
            {
                Head.Next = node;
            }
            Count++;
        }

        public void Insert(int index, T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            node.Next = current.Next;
            current.Next = node;
            Count++;
        }

        public void PopBack()
        {
            if (Count <= 0)
                throw new InvalidOperationException();

            Node<T> current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
            Count--;
        }

        public void PopFront()
        {
            if (Count <= 0)
                throw new InvalidOperationException();

            Head.Next = Head.Next.Next;
            Count--;
        }

        private Node<T> GetByIndex(int index)
        {
            Node<T> current = Head;

            for (int i = 0; i <= index; i++)
            {
                current = current.Next;
            }
            return (current);
        }

        public void RemoveAt(int index)
        {
            Node<T> current = Head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            Count--;
        }

        public T this[int index]
        {
            set
            {
                GetByIndex(index).Value = value;
            }

            get
            {
                return GetByIndex(index).Value;
            }
        }

        public bool Empty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
        }

        public T Last()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return GetByIndex(Count - 1).Value;
        }

        public T First()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return Head.Next.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0)
                yield break;

            Node<T> current = Head.Next;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }
}
