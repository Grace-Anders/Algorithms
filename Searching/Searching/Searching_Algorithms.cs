using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Searching
{
    public class Searching_Algorithms
    {
        public int[] ToBeSearched = new int[] { 76, 51, 47, 20, 27, 13, 81, 86, 73, 21, 40, 50, 45, 49, 37, 78, 63, 64, 82, 4, 89, 44, 28, 24, 79, 29, 10, 39, 70, 84, 11, 67, 2, 62, 8, 74, 59, 42, 19, 25, 48, 69, 6, 36, 66, 60, 61, 43, 35, 3 };

        public Searching_Algorithms() { Test(); }

        public int Linear(int[] TBS, int target)
        {
            /*
             Begin
            1) Set i = 0
            2) If Li = T, go to line 4
            3) Increase i by 1 and go to line 2
            4) If i < n then return i
            End
             */
            int i = 0;
            foreach (var item in TBS)
            {
                if(item == target)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public int Binary(int[] TBS, int target, int min, int max)
        {
            /*
            Binary (int arry, int, int, int)
            if min > max
                return -1
            else
                mid = min + max / 2
                if(target == arry[mid]
                    return mid
                else if target < array[mid]
                    return Binary(array, target, min, mid -1)
                else
                    return Binary(array, target, min + 1, mid)
             */


            if (min > max)
                return -1;
            else
            {
                int mid = (min + max) / 2;
                if (target == TBS[mid])
                    return mid;
                else if (target < TBS[mid])
                    return Binary(TBS, target, min, mid - 1);
                else
                    return Binary(TBS, target, mid + 1, max);
            }
        }

        public int Interpolation(int[] TBS, int target)
        {
            /*
            A → Array list
            N → Size of A
            X → Target Value

            Procedure Interpolation_Search()

            Set Lo  →  0
            Set Mid → -1
            Set Hi  →  N-1

            While X does not match
   
            if Lo equals to Hi OR A[Lo] equals to A[Hi]
            EXIT: Failure, Target not found
            end if
      
            Set Mid = Lo + ((Hi - Lo) / (A[Hi] - A[Lo])) * (X - A[Lo]) 

            if A[Mid] = X
            EXIT: Success, Target found at Mid
            else 
                if A[Mid] < X
                    Set Lo to Mid+1
                else if A[Mid] > X
                    Set Hi to Mid-1
                end if
            end if
            End While

             End Procedure
             */

            int low = 0;
            int mid = -1;
            int high = TBS.Length - 1;
            int index = -1;

            while (low <= high)
            {
                mid = (low + ((high - low) / (TBS[high] - TBS[low])) * (target - TBS[low]));

                if (TBS[mid] == target)
                {
                    return index = mid;
                    //break;
                }
                else
                {
                    if (TBS[mid] < target)
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
            }

            return index;

        }


        //Testing
        public void Test()
        {
            //Linear
            TestAlgorithim("Linear", Linear(ToBeSearched, 29));

            //Binary
            ToBeSearched = MergeSort(ToBeSearched.ToList()).ToArray(); //Sort array
            TestAlgorithim("Binary", Binary(ToBeSearched, 29, 0, ToBeSearched.Length - 1));

            //Interpolation
            ToBeSearched = MergeSort(ToBeSearched.ToList()).ToArray(); //Sort array
            TestAlgorithim("Interpolation", Interpolation(ToBeSearched, 29));
        }

        public void TestAlgorithim(string Name, int Target)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"\n{Name}:");
            Console.WriteLine($"Found {ToBeSearched[Target]} at index {Target}");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"took: {elapsedMs} milliseconds");
        }


        //Sorting : Merge Sort
        public static List<int> MergeSort(List<int> sort)
        {

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
    }
}
