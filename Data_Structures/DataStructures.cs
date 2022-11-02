using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructures
{
	public class DataStructures
	{
		public DataStructures()
		{
			/*
			 Create an application that stores the same large amount of data in an array and map, 
			 and the same items in a stack and a queue. Explain how each of the data structures work, 
			 and scenarios in which each would be more appropriate. You can use I/O to read in data 
			 from an external source (such as XML or a text file).

			 Two comparisons:

				Array vs. Map (in C# a map can be implemented as a hash table or dictionary)
				Stack vs. Queue
			 */
			
			var lines = File.ReadLines("C:/Users/grace/source/repos/Algorithms/DataStructures/Data.txt");

			Birthday[] array;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();



		}
	}

	public class Birthday
	{
		int Day, Month;

		public Birthday(int day, int month)
		{
			Day = day;
			Month = month;
		}
	}
}



