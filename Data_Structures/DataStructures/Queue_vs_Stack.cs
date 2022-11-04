using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace DataStructures
{
    public class Queue_vs_Stack
    {
        public Queue_vs_Stack(List<Birthday> bd)
        {
            Queue(bd);
            Stack(bd);
        }

        public static void Queue(List<Birthday> bday)
        {
            //Queue
            WriteLine("Queue\n------");

            //Both Stacks and Queue have similar limitations
            //The only major difference is the order in which the are stored,
            //the priority at which data is stored
            //It stores all of the data but looses its index ability

            List<Birthday> list = bday;
            Queue<Birthday> queue = new Queue<Birthday>(bday);

            foreach(var items in queue)
            {
                WriteLine($"{items.Day} {items.Month}");
            }

            WriteLine($"\n\n# of Birthdays: {queue.Count}\n");
        }

        public static void Stack(List<Birthday> bday)
        {
            //Stack
            WriteLine("Stack\n------");

            //The Stack is properly storing all the data, and converting a list to a stack is very easy,
            //but you losse the indexing power that a list has. It works well if you want to
            //store data and only get it in the order in which it was filled

            List<Birthday> list = bday;
            Stack<Birthday> stack = new Stack<Birthday>(bday);

            foreach(var item in stack)
            {
                WriteLine($"{item.Day} {item.Month}");
            }

            //Stacks do not have the same indexing qualites of an array or map
            //so getting the 5th item in a stack is not nearly as simple without removing the ones before it
            WriteLine($"\n\n# of Birthdays: {stack.Count}\n");
        }

    }
}
