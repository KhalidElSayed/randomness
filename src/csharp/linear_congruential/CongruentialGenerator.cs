﻿/*
 * File         : CongruentialGenerator.cs
 * Type         : Class
 *
 * Description  : Linear Congruential Generator (LCG) Generator
 *
 * Notes        : A Linear Congruential Generator (LCG) represents one of the oldest and best-known pseudorandom number generator algorithms.
 *                The theory behind them is easy to understand, and they are easily implemented and fast. 
 *                WIKIPEDIA PAGE : http://en.wikipedia.org/wiki/Linear_congruential_generator
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
 * 
 * Author       : MohammadReza Taesiri
 */


using System.Collections.Generic;

namespace Randomness
{
    public class CongruentialGenerator
    {
        private readonly List<float> _generatedRandomValues; // Random Values Generated by Linear Congruential Generator (LCG) Method
        private readonly int _increment; // Increment
        private readonly int _modulus; // Modulus
        private readonly int _multiplier; //Multiplier
        private readonly int _seed; // Seed or Start Value

        private int _currentValue;

        public CongruentialGenerator(int modulus, int multiplier, int increment, int seed)
        {
            _seed = seed;
            _modulus = modulus;
            _increment = increment;
            _multiplier = multiplier;
            _currentValue = _seed;

            _generatedRandomValues = new List<float>();
        }

        public int GenerateNumber()
        {
            _currentValue = ((_multiplier*_currentValue) + _increment)%_modulus;
            return _currentValue;
        }

        public float GetRandom()
        {
            float rvalue = GenerateNumber()/(float) _modulus;
            _generatedRandomValues.Add(rvalue);
            return rvalue;
        }
    }
}