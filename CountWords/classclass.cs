using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWords
{
    class classclass: ICountWords
	{
		public class Node
		{
			public char ch;
			public List<Node> childs;
			public uint count;
			public bool end_of_word;

			public Node()
			{
				childs = new List<Node>();
			}

			public Node(char c, uint cnt)
			{
				ch = c;
				count = cnt;
				childs = new List<Node>();
			}
		}

		public Node root;

       

        public classclass()
		{
			root = new Node();
		}

		public void Count(int count)
		{
			int count2 = count;

			if (tree != null && tree.left == null && tree.right == null)
			{
				return 1;
			}
			else
			{
				if (tree.left != null) // added check
					count += tree.left.leafCount();
				if (tree.right != null) // added check
					count += tree.right.leafCount();
			}
		}

		public void Add(string key, int value)
		{
			var current = root;
			for (int i = 0; i < key.Length; i++)
			{
				char ch = key[i];
				int index = current.childs.FindIndex(x => x.ch == ch);
				// символа в потомках нет, добавляем
				if (index < 0)
				{
					current.childs.Add(new Node(ch, 1));
					++current.count;
					current = current.childs.Last();
				}
				else
				{
					++current.count;
					current = current.childs[index];
				}
				// если есть среди потомков потомок с символом ch
			}
			++current.count;
			current.end_of_word = true;
		}

		public bool ContainsKey(string key)
		{
			var current = root;
			for (int i = 0; i < key.Length; i++)
			{
				char ch = key[i];
				int index = current.childs.FindIndex(x => x.ch == ch);
				if (index < 0)
					return false;
				else
				{
					//Console.WriteLine(current.ch);
					current = current.childs[index];
				}
			}
			return current.end_of_word;
		}
	}
}
