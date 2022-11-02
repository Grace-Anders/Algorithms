using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using static System.Console;

namespace Fisher_Yates_Shuffle
{
    public class CodeMaker
    {
        public string[] alphabet;
        string Alphabet;

        public CodeMaker()
        {
            GetDataFromFile();
            Write($"{WriteAlphabet()}\n");
            alphabet.ShuffleAlphabet();
            WriteCipher();
        }

        public string WriteAlphabet()
        {
            foreach (string character in alphabet)
            {
                //Write(character + " ");
                Alphabet += character + " ";
            }
            return Alphabet;
        }

        public void WriteCipher()
        {
            foreach (string character in alphabet)
            {
                Write(character + " ");
            }

            ReadKey();
        }


        public void GetDataFromFile()
        {
            alphabet = File.ReadLines("Alphabet.txt").ToArray();
        }
    }
}
