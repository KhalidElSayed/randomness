/*
 * File         : MiddleSquareGenerator.cs
 * Type         : Class
 *
 * Description  : MiddleSquareGenerator (MSG) Generator
 *
 * Notes        : In mathematics, the middle-square method is a method of generating pseudorandom numbers. 
 *                In practice it is not a good method, since its period is usually very short and it has some 
 *                crippling weaknesses, such as the output sequence always converging to zero.
 *                WIKIPEDIA PAGE : http://en.wikipedia.org/wiki/Middle-square_method
 *                
 *                
 * 
 * External 
 * Interfaces   : None
 *
 *
 * See Also     : https://github.com/taesiri/randomness
 *
 * Functions    : int GenerateNumber()
 *
 *
 * Engineering
 * Status       : BETA
 *
 * 
 * Author       : MohammadReza Taesiri
 */


using System;

namespace Randomness2
{
    public class MiddleSquareGenerator
    {
        private Int64 _seed;

        public MiddleSquareGenerator(Int64 seed)
        {
            _seed = seed;
        }

        public Int64 GenerateNumber()
        {
            long value = _seed*_seed;
            
            var lenSeed = _seed.ToString().Length;
            var lenValue = value.ToString().Length;
            var dl = lenValue - lenSeed;
            if (dl%2 == 1) dl++;
            dl = dl/2;

            value = (long)(value / (Math.Pow(10, dl)));
            value = (long)(value % (Math.Pow(10, lenSeed)));

            _seed = value;
            return value;
        }
    }
}