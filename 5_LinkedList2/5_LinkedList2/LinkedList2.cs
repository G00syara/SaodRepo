using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace _5_LinkedList2
{
    public class LinkedList2<T> : IEnumerable<T>
    {
        Node<T> head;

        Node<T> tail;

        public LinkedList2() { }

        public void PushBack(T value)
        {
            Node<T> node = new Node<T>(value);

            if (Count == 0)
            {
                tail = node;
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }

            Count++;
        }

        public void PushFront(T value)
        {
            Node<T> node = new Node<T>(value);

            if (Count == 0)
            {
                tail = node;
                head = node;
            }
            else
            {
                head.Prev = node;
                node.Next = head;
                head = node;
            }

            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                if (Count == 1)
                {
                    tail = null;
                    head = null;
                }
                else
                {
                    head.Next.Prev = null;
                    head = head.Next;
                }
            }
            else if (index == Count - 1)
            {

                tail.Prev.Next = null;
                tail = tail.Prev;
            }
            else
            {
                Node<T> node = NodeByIndex(index);
                node.Next.Prev = node.Prev;
                node.Prev.Next = node.Next;

            }
            Count--;
        }

        public void PopBack()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Can't pop from empty array (Count = " + Count + ")");
            }
            else if (Count == 1)
            {
                tail = null;
                head = null;
            }
            else
            {
                tail.Prev.Next = null;
                tail = tail.Prev;
            }
            --Count;
        }

        public void PopFront()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Can't pop from empty array (Count = " + Count + ")");
            }
            else if (Count == 1)
            {
                tail = null;
                head = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            --Count;
        }

        private Node<T> NodeByIndex(int index)
        {
            if (index < 0 || Count <= index)
            {
                throw new IndexOutOfRangeException();
            }
            Node<T> cur = head;
            for (int i = 0; i < index; ++i)
            {
                cur = cur.Next;
            }

            return cur;
        }

        public T this[int index]
        {
            get
            {
                return NodeByIndex(index).Value;
            }
            set
            {
                NodeByIndex(index).Value = value;
            }
        }

        public int Count
        {
            private set;
            get;
        }

        public T Last
        {
            get { return tail.Value; }
        }
        public T First
        {
            get { return head.Value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0)
                yield break;

            Node<T> current = head;
            while (current != tail)
            {
                yield return current.Value;
                current = current.Next;
            }
            yield return current.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
