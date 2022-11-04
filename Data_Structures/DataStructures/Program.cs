using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateList pl = new PopulateList();
            //Going to first populate a list and then convert it to nessacary types

            var lineCount = File.ReadLines("Data.txt").Count();

            Console.WriteLine($"The file has {lineCount} lines");

            Console.WriteLine("Arrays vs Maps\n---------------");
            Array_vs_Map AM = new Array_vs_Map(pl.MakeList());
            Console.WriteLine("Queues vs Stacks\n---------------");
            Queue_vs_Stack QS = new Queue_vs_Stack(pl.MakeList());

        }

        

    }


}
