using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace DataStructures
{
    public class Array_vs_Map
    {
        public Array_vs_Map(List<Birthday> bd)
        {
            Array(bd);
            Dictionary();
        }


        public static void Array(List<Birthday> bday)
        {
            //Array
            WriteLine("Array\n------");


            //Though the array is a little more dificut to populate from an outside txt file
            //it easily encapsulates all of the data without a needed work arround.

            List<Birthday> list = bday;

            //Convert the list to an array
            Birthday[] array = list.ToArray();

            foreach (Birthday bd in array)
            {
                WriteLine($"{bd.Day} {bd.Month}");
            }

            WriteLine($"\nFifth Birthday\nDay: {array[0].Day} Month: {array[0].Month}\n\n# of Birthdays: {array.Length}\n");
        }


        public static void Dictionary()
        {
            string[] items;

            //Dictionary
            WriteLine("Dictionary\n--------");


            //This dose not get all 50 birthdays from the file, as each dictionary item needs its own key.
            //So only the first birthday of over lapping days is saved.
            //This is the collision that was talked about this week

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

            WriteLine($"\nFifth Birthday:\nDay: {dictionary.ElementAt(4).Key} Year: {dictionary.ElementAt(4).Value}\n\n# of Birthdays: {dictionary.Count}\n");
        }
    }
}
