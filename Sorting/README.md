# **Sorting**

### Bubble Sort
#### Bubble sort starts at the beginning of an array and swaps the first two elements if the first is greater than the second. Moving to the next pair, the same comparison is made.
##### - Runtime: O(n2) average and worst case
##### - Memory: O(1)
```
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
```

### Insertion Sort
#### Insertion sort is a simple sorting algorithm that builds the final sorted set one item at a time. It is efficient on small data sets but is much less efficient on large sets than quicksort, heapsort, or merge sort. 

##### - Runtime: best case is O(n), and worst case is O(n2)
##### - Memory: O(1) to O(n)
```
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
```

### Selection Sort
#### Selection sort is an in-place comparison sorting algorithm. It is inefficient on large lists, and generally performs worse than insertion sort. 

##### - Runtime: O(n2) average and worst case
##### - Memory: O(1)
```
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
```

### Heap Sort
#### Heap sort is a comparison-based sort-in-place algorithm that takes no extra storage. It is often described as an improved selection sort.

##### - Runtime: O(n log n) average and worst cases
##### - Memory: O(1)
```
int n = sort.Length;

for (int i = sort.Length / 2 - 1; i >= 0; i--)
    Heapify(sort, n, i);
for (int i = sort.Length - 1; i >= 0; i--)
{
    SwapInts(sort, 0, i);
    Heapify(sort, i, 0);
}

return sort;
```
```
//Heapify (array, int n, int i)
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
```

### Quick Sort
#### In quicksort an element is chosen from the array to act as a "pivot". The pivot separates the array into two parts, and each element in the subsections is compared to the pivot for sorting. The algorithm recursively calls itself on the subdivided sections until all elements are sorted.

##### - Runtime: best case O(n log n), worst case O(n2)
##### - Memory: O(1)
```
if (first < last)
{
    int pi = Particion(sort, first, last);

    QuickSort(sort, first, pi - 1);
    QuickSort(sort, pi + 1, last);
}

return sort;
```
```
//Particion (array, int first, int last)
int pivot = sort[last];
int i = (first - 1);

for(int j = first; j <= last - 1; j++)
{
    if(sort[j] < pivot)
    {
        i++;
        SwapInts(sort, i, j);
    }
}

SwapInts(sort, i + 1, last);
return (i + 1);

```

### Merge Sort
#### Merge sort method divides the list into halves, then iterates through the new halves, continually dividing them down further to their smaller parts. Subsequently, a comparison of smaller halves is conducted, and the results are combined together to form the final sorted list.

##### - Runtime: O(n log n)
##### - Memory: O(n log n)

```
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
```
```
//Merge (list int left, list int right)
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
```
```
//Replace (list int result, list int lesser)
    result.Add(lesser.First());
    lesser.Remove(lesser.First());
```