using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Trees
{
    class Tree_Algorithms
    {
        public int[] Array;
        Node root;

        public void Test()
        {
            GetDataFromFile();
            Array = HeapSort(Array);
            //Heap sort tecnically uses a tree but I will make another

            root = ArrayToTree(Array, 0);
            PrintTree(root);
        }

        public Node ConvertArrayToBinaryTree(int[] array)
        {
            if (array.Length == 0)
                return null;

            int middle = array.Length / 2;

            Node root = new Node(array[middle]);

            root.left = ConvertArrayToBinaryTree(array[..middle]);
            root.right = ConvertArrayToBinaryTree(array[(middle + 1)..]);
            return root;
        }

        public void PrintTree(Node root)
        {
            if (root != null)
            {
                PrintTree(root.left);
                Console.Write(root.data + " ");
                PrintTree(root.right);
            }
        }


        public Node ArrayToTree(int[] array, int i)
        {
            Node root = null;
            if (i < array.Length)
            {
                root = new Node(array[i]);
                root.left = ArrayToTree(array, 2 * i + 1);
                root.right = ArrayToTree(array, 2 * i + 2);
            }
            return root;
        }



        public void GetDataFromFile()
        {
            List<int> temp = new List<int>();
            foreach (string line in System.IO.File.ReadLines(@"c:Data.txt"))
            {
                temp.Add(Convert.ToInt32(line));
            }

            Array = temp.ToArray();
        }

        //Sorting: Heep Sort
        public int[] HeapSort(int[] sort)
        {
            /*
            get array length
            turn array into a heap and get largest value and swap its postion with last
            readjust searching paramaters to exclude the found int
            for the rest of the array length
                readjust the heep with the new index 0 value in mind
                once heepified swap values into place
                readjust bounds
                repeat
             */

            int n = sort.Length;

            for (int i = sort.Length / 2 - 1; i >= 0; i--)
                Heapify(sort, n, i);
            for (int i = sort.Length - 1; i >= 0; i--)
            {
                SwapInts(sort, 0, i);
                Heapify(sort, i, 0);
            }

            return sort;
        }

        public void Heapify(int[] sort, int n, int i)
        {
            /* put list into a heap
             
                parent: (i-1) / 2
                left child: 2 * p  +1
                right child: 2 * p + 2
            */

            int parent = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && sort[left] > sort[parent])
                parent = left;
            if (right < n && sort[right] > sort[parent])
                parent = right;
            if (parent != i)
            {
                SwapInts(sort, i, parent);
                Heapify(sort, n, parent);
            }
        }

        public void SwapInts(int[] sort, int a, int b)
        {
            int Swapping = sort[a];
            sort[a] = sort[b];
            sort[b] = Swapping;
        }
    }
}
