using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataStructures
{
    public class PopulateList
    {
        public static List<Birthday> bd = new List<Birthday>();

        public List<Birthday> MakeList()
        {
            string[] items;

            foreach (string line in File.ReadLines("Data.txt"))
            {
                items = line.Split(new String[] { "/" }, 2, StringSplitOptions.None);

                bd.Add(new Birthday(items[0], items[1]));
            }

            return bd;
        }

    }
}
