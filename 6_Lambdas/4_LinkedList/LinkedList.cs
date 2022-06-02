using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace _6_Lambdas
{
    class LinkedList<T> : IEnumerable<T>

    {
        public int Count { set; get; }

        public Node<T> Head = new Node<T>();

        public delegate bool ContainsDeligate(T item);
        public ContainsDeligate Contains;

        public delegate int IndexOfDelegate(T item);
        public IndexOfDelegate IndexOf;

        public delegate void ActionDelegate(Action<T> action);
        public ActionDelegate forEach;

        public delegate T FindDelegate(Predicate<T> match);
        public FindDelegate Find;

        public delegate int FindIndexDelefate(Predicate<T> match);
        public FindIndexDelefate FindIndex;

        public LinkedList()
        {
            Contains = (T item) =>
            {
                foreach (var cur in this)
                {
                    if (EqualityComparer<T>.Default.Equals(cur, item))
                        return true;
                }
                return false;
            };

            IndexOf = (T item) =>
            {
                int i = 0;
                foreach (var cur in this)
                {
                    if (EqualityComparer<T>.Default.Equals(cur, item))
                        return i;
                    ++i;
                }
                return -1;
            };

            forEach = (Action<T> action) =>
            {
                int i = 0;
                Node<T> cur = Head.Next;
                while (i < Count)
                {
                    action(cur.Value);
                    cur = cur.Next;
                    ++i;
                }
            };

            Find = (Predicate<T> match) =>
            {
                foreach (var item in this)
                {
                    if (match(item))
                    {
                        return item;
                    }
                }
                throw new InvalidOperationException("Object not found");
            };

            FindIndex = (Predicate<T> match) =>
            {
                int i = 0;
                foreach (var item in this)
                {
                    if (match(item))
                    {
                        return i;
                    }
                    ++i;
                }
                return -1;
            };
        }

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
