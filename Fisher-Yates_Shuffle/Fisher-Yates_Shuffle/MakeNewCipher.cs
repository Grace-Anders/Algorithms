using System;
using System.Collections.Generic;
using System.Text;

namespace Fisher_Yates_Shuffle
{
    public static class MakeNewCipher
    {
        private static Random randNumber = new Random();

        //In this method I utilize the Fisher-Yates Shuffle to run through
        //the alphabet from back to front and create a cipher
        public static void ShuffleAlphabet(this string[] alphabet)
        {
            //I swaped the i and the j for inital and swapped as I think that wording makes more sense

            for(int initial = alphabet.Length - 1; initial > 0; initial--)
            {
                int swapped = GetRandomNumber(initial); //Gets a random number from the yet to shuffle index points
                alphabet.SwapValues(initial, swapped); //Swaps the two values
            }
        }

        //I'm a little uncertin if this is enough changed,
        //I didn't know how to utilize the shuffle algoritm,
        //without following the codding pretty close


        //I hope the rest of my project makes up for this,
        //and if this is not adiquite any pointers on how I should have approached this would be appreciated


        private static int GetRandomNumber(int i)
        {
            return randNumber.Next(i + 1);
        }
    }
}
