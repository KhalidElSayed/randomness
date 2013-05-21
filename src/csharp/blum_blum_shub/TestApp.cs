using System;
using System.Collections.Generic;

namespace Randomness.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> data = BlumBlumShub.GenerateFullCycle(11, 19, 3);

            foreach (int t in data)
            {
                Console.Write(value: string.Format("{0} \t Least significant bit : {1} \n", t, t & 1));
            }

            Console.ReadLine();
        }
    }
}