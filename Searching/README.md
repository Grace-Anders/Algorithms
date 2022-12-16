# **Searching**

### Linear
#### Linear search sequentially checks each element of a data set. It is generally not as efficient as other options unless the data set is very small.
##### - Runtime: best case is O(1), and worst case is O(n)
##### - Memory: O(1)
```
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
```

### Binary
#### Binary search requires a sorted data set. It compares the value in the middle of the data set to the value being searched for. If the values are equal, the target has been found.If the values are not equal, the algorithm determines which half of the data set will contain the target, and the search procedure is repeated.
##### - Runtime: best case is O(1), and worst case is O(logN)
##### - Memory: O(1)
```
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
```

### Interpolation
####  Interpolation search uses keys. For interpolation search to work efficiently data must be uniformly distributed (in addition to being sorted).
##### - Runtime: best case is O (log log n), and worst case is O(n)
##### - Memory: O(1)
```
int low = 0;
int mid = -1;
int high = TBS.Length - 1;
int index = -1;

while (low <= high)
{
    mid = (low + ((high - low) / (TBS[high] - TBS[low])) * (target - TBS[low]));
    
    if (TBS[mid] == target)
        return index = mid;
    else
    {
        if (TBS[mid] < target)
            low = mid + 1;
        else
            high = mid - 1;
    }
}

 return index;

```