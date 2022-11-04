# Data Structures

## Array
"fixed length ordered collection of values or objects with the same type"

###### Though the array is a little more dificut to populate from an outside txt file it easily encapsulates all of the data without a needed work arround, while the Dictionary misses data.
```
Birthday[] array = bday.ToArray();

foreach (Birthday bd in array)
{
    WriteLine($"{bd.Day} {bd.Month}");
}

```

## Map
"generic collection which is generally used to store key/value pairs"

###### This dose not get all 50 birthdays from the file, as each dictionary item needs its own key. So only the first birth date with an unused date is saved. This is the collision that was talked about this week, and where work arrounds such as Robin Hood come in.
```
Dictionary<string, string> dictionary = new Dictionary<string, string>();

foreach (string line in File.ReadLines("Data.txt"))
{
    items = line.Split(new String[] { "/" }, 2, StringSplitOptions.None);

    if (!dictionary.ContainsKey(items[0]))
    {
        dictionary.Add(items[0], items[1]);
    }
}

foreach (KeyValuePair<string, string> entry in dictionary)
{
    WriteLine(entry.Key + " " + entry.Value);
}

```

## Queue
"a special type of collection that stores the elements in FIFO style (First In First Out)"

###### Both Stacks and Queue have similar limitations the only major difference is the order in which the are stored, the priority at which data is stored. The Queue stores all of the data but looses it's index ability, which saves space but dose not allow the elements to be dynamically refrenced.
```
Queue<Birthday> queue = new Queue<Birthday>(bday);

foreach(var items in queue)
{
    WriteLine($"{items.Day} {items.Month}");
}

```

## Stack
"a special type of collection that stores elements in LIFO style (Last In First Out)"

###### The Stack is properly storing all the data, and converting a list to a stack is very easy, but you losse the indexing as spoken about earlier. It works well if you want to store data and only get it in the order in which it was filled
```
Stack<Birthday> stack = new Stack<Birthday>(bday);

foreach(var item in stack)
{
    WriteLine($"{item.Day} {item.Month}");
}
```

#### Best Uses
          
|     Array   | If storage is not a concern and data is needed to be dynamically accesed I find Arrays to be the best option |
|    :----:   |    :----:   |
|      Map    | I'd use a dictionary when I'd need to look up info easily, the key/ value pair means they key, or half of the stored data can be utilized to find it usch as the name of an item and its description |
|     Queue   | Queue's are best utilized when you only need to access data in FIFO, such as a task manager that prosessed things as they are recieved |
|     Stack   | Stack's work oppositly, where the most important data is the most recent. I can not think of many practical uses for such storage, but I'm sure I will in the furture|
