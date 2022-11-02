using System;
using System.Collections.Generic;
using System.Text;

namespace Fisher_Yates_Shuffle
{
    public static class Swapping
    {
        public static void SwapValues(this string[] alphabet, int initial, int swapped)
        {
            //https://stackoverflow.com/questions/43759043/how-can-i-swap-two-values-of-an-array-in-c
            // I disliked the way the videos were swapping, so I wanted to find an alternative way

            (alphabet[initial], alphabet[swapped]) = (alphabet[swapped], alphabet[initial]);

        }
    }
}
