using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sorting
{
    public class Sorting_Algorithms
    {
        public int[] ToBeSorted = new int[] { 76, 51, 47, 20, 27, 13, 81, 86, 73, 21, 40, 50, 45, 49, 37, 78, 63, 64, 82, 4, 89, 44, 28, 24, 79, 29, 10, 39, 70, 84, 11, 67, 2, 62, 8, 74, 59, 42, 19, 25, 48, 69, 6, 36, 66, 60, 61, 43, 35, 3 };


        public Sorting_Algorithms()
        {
            Test();
        }

        //Bubble Sort
        public int[] BubbleSort(int[] sort)
        {
            /*
             Bubblesort(Data: values[])
                // Repeat until the array is sorted.
                Boolean: not_sorted = True
                While (not_sorted)
                    // Assume we won't find a pair to swap.
                    not_sorted = False
                    // Search the array for adjacent items that are out of order.
                    For i = 0 To <length of values> - 1

                // See if items i and i - 1 are out of order.
                    If (values[i] < values[i - 1]) Then
                        // Swap them.
                        Data: temp = values[i]
                        values[i] = values[i - 1]
                        values[i - 1] = temp
 
                        // The array isn't sorted after all.
                        not_sorted = True
                    End If
                Next i
            End While
        End Bubblesort  
             */

            bool NotSorted = true;
            while (NotSorted)
            {
                NotSorted = false;
                for (int i = 0; i < sort.Length - 1; i++)
                {
                    if (sort[i] > sort[i + 1])
                    {
                        SwapInts(sort, i, i + 1);

                        NotSorted = true;
                    }
                }
            }

            return sort;
        }

        //Insertion Sort
        public int[] InsertionSort(int[] sort)
        {
            /*
            Insertionsort(Data: values[])
                For i = 0 To <length of values> - 1
                    // Move item i into position
                    //in the sorted part of the array
                    < Find  the first index j where
                     j < i and values[j] > values[i].>
                    <Move the item into position j.>
                Next i
            End Insertionsort
             */

            for (int i = 0; i < sort.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0 && sort[j - 1] > sort[j])
                {
                    if (sort[j] < sort[j - 1])
                    {
                        SwapInts(sort, j, j - 1);
                    }
                    else
                    {
                        break;
                    }

                    j = j - 1;
                }
            }

            return sort;
        }

        //Selection SOrt
        public int[] SelectionSort(int[] sort)
        {
            /*
            Selectionsort(Data: values[])
                For i = 0 To <length of values> - 1
                    // Find the item that belongs in position i.
                    <Find the smallest item with index j >= i.>
                    <Swap values[i] and values[j].>
                Next i
            End Selectionsort  
             */

            for (int i = 0; i < sort.Length - 1; i++)
            {
                int Smallest = i;
                for (int j = i + 1; j < sort.Length; j++)
                {
                    if (sort[j] < sort[Smallest])
                    {
                        Smallest = j;
                    }
                }

                SwapInts(sort, Smallest, i);
            }

            return sort;
        }

        //Heep Sort
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

        //Quick Sort
        public int[] QuickSort(int[] sort, int first, int last)
        {//first = 0 index last = last index
            /*
            low  –> Starting index,  high  –> Ending index 

            quickSort(arr[], low, high) {

                if (low < high)
                {

                    pi is partitioning index, arr[pi] is now at right place 

                    pi = partition(arr, low, high);

                    quickSort(arr, low, pi – 1);  // Before pi

                    quickSort(arr, pi + 1, high); // After pi

                }

            }

            */

            if (first < last)
            {
                int pi = Particion(sort, first, last);

                QuickSort(sort, first, pi - 1);
                QuickSort(sort, pi + 1, last);
            }

            return sort;
        }

        public int Particion(int[] sort, int first, int last)
        {
            /*
            partition (arr[], low, high)
            {
            // pivot (Element to be placed at right position)
            pivot = arr[high];  

            i = (low – 1)  // Index of smaller element and indicates the 
            // right position of pivot found so far

            for (j = low; j <= high- 1; j++){

            // If current element is smaller than the pivot
            if (arr[j] < pivot){
            i++;    // increment index of smaller element
            swap arr[i] and arr[j]
            }
            }
            swap arr[i + 1] and arr[high])
            return (i + 1)
            }
             */

            int pivot = sort[last];
            int i = (first - 1);

            for (int j = first; j <= last - 1; j++)
            {
                if (sort[j] < pivot)
                {
                    i++;
                    SwapInts(sort, i, j);
                }
            }

            SwapInts(sort, i + 1, last);
            return (i + 1);
        }

        //Merge Sort
        private static List<int> MergeSort(List<int> sort)
        {
            //if the whole list is empty or there is only one variable
            //return list

            /*
            get middle of the array

            create a left and right data storage
                if its an array calculate the bounds
                if its a list keep conversion in mind
                
            from the start of the list to the middle (left side)
                add values to Left 

            from the middle of the list to the end (right side)
                add values to Right
            
            after seperated run mersort again on both the left and right side
            Once done merge the left and right together
             */

            if (sort.Count <= 1)
                return sort;

            List<int> Left = new List<int>();
            List<int> Right = new List<int>();

            int mid = sort.Count / 2;
            for (int i = 0; i < mid; i++)
                Left.Add(sort[i]);

            for (int i = mid; i < sort.Count; i++)
                Right.Add(sort[i]);

            Left = MergeSort(Left);
            Right = MergeSort(Right);
            return Merge(Left, Right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            /*
            create a storage for the results

            while niether cont is 0
                if both the left and right count is greater then 0
                    if left's smallest is less then or equal to right's
                        add left and remove it from the left
                    else
                        add right and remove it from the left

             return the results
             */
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                        Replace(result, left);
                    else
                        Replace(result, right);
                }
                else if (left.Count > 0)
                    Replace(result, left);
                else if (right.Count > 0)
                    Replace(result, right);
            }

            return result;
        }


        public static void Replace(List<int> result, List<int> lesser)
        {
            result.Add(lesser.First());
            lesser.Remove(lesser.First());
        }
        

        public void SwapInts(int[] sort, int a, int b)
        {
            int Swapping = sort[a];
            sort[a] = sort[b];
            sort[b] = Swapping;
        }


        public void Test()
        {

            Console.WriteLine("Unsorted Array:");
            foreach(var item in ToBeSorted)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nWhich Algorithm do you want to test?\na: BubbleSort\nb: InsertionSort\nc: SelectionSort\nd: HeapSort\ne: QuickSort\nf: MergeSort");

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "a":
                    TestAlgorithim("BubbleSort", BubbleSort(ToBeSorted));
                    break;
                case "b":
                    TestAlgorithim("InsertionSort", InsertionSort(ToBeSorted));
                    break;
                case "c":
                    TestAlgorithim("SelectionSort", SelectionSort(ToBeSorted));
                    break;
                case "d":
                    TestAlgorithim("HeapSort", HeapSort(ToBeSorted));
                    break;
                case "e":
                    TestAlgorithim("QuickSort", QuickSort(ToBeSorted, 0, ToBeSorted.Length - 1));
                    break;
                case "f":
                    TestAlgorithim("MergeSort", MergeSort(ToBeSorted.ToList()).ToArray());
                    break;

            }
        }

        public void TestAlgorithim(string Name, int[] Method)
        {
            //This could be perfected the time is also considering the foreach loop
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"\n{Name}:");
            foreach (var item in Method)
            {
                Console.Write(item + " ");
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"{Name} took: {elapsedMs} milliseconds");
        }

    }
}
