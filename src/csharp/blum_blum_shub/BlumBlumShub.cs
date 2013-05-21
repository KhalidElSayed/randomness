/*
 * File         : BlumBlumShub.cs
 * Type         : Class
 *
 * Description  : Blum Blum Shub (BBS) Generator
 *
 * Notes        : Blum Blum Shub (B.B.S.) is a pseudorandom number generator proposed in 1986 by Lenore Blum, Manuel Blum and Michael Shub (Blum et al., 1986).
 *                WIKIPEDIA PAGE : http://en.wikipedia.org/wiki/Blum_Blum_Shub
 * 
 * External 
 * Interfaces   : None
 *
 *
 * See Also     : https://github.com/taesiri/randomness
 *
 * Functions    : int GenerateNumber(),float GetRandom()
 *
 *
 * Engineering
 * Status       : BETA
 *
 * Dependencies : System.Numerics
 * Author       : MohammadReza Taesiri
 */


using System.Collections.Generic;
using System.Numerics;

namespace Randomness
{
    public class BlumBlumShub
    {
        private readonly int _p;       // p
        private readonly int _q;      // q
                                     // Modulus = p * q
        private readonly int _seed; // Seed or Start Value

        private int _currentValue;

        public BlumBlumShub(int p, int q, int seed)
        {
            _seed = seed;
            _p = p;
            _q = q;
            _currentValue = _seed;
        }

        public int Generate()
        {
            _currentValue = (int) ((((BigInteger)_currentValue) * ((BigInteger)_currentValue)) % (_p * _q));
            return _currentValue;
        }


        public static List<int> GenerateFullCycle(int p, int q, int seed)
        {
            var randomNumbers = new List<int>();
            var bbs = new BlumBlumShub(p, q, seed);

            int rvalue = bbs.Generate();
            while (randomNumbers.Contains(rvalue) == false)
            {
                randomNumbers.Add(rvalue);
                rvalue = bbs.Generate();
            }

            return randomNumbers;
        }
    }
}