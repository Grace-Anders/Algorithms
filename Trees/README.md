# **Trees**

### Sorting Algorithim Used:
#### Merge Sort
##### Merge sort is my go to out of the sorting algorithims, and it felt most fitting for this due to its use of a binary heap
##### The Merge sort both works to sort the data but also as an exaple of a tree
```
public void Heapify(int[] sort, int n, int i)
{
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

```

### Converting Sorted Array into a Tree
##### The below code inserts nodes in level order first getting the root, then going to the left child, and finally the right ensuring the entire tree is triversed and populated

```
Node root = null;
if (i < array.Length)
{
    root = new Node(array[i]);
    root.left = ArrayToTree(array, 2 * i + 1);
    root.right = ArrayToTree(array, 2 * i + 2);
}
return root;

```