/*
 * File         : randomness.go
 * Type         : Package
 *
 * Description  : Pseudo Random Generator
 *
 *
 *
 *
 *
 *
 * See Also     : https://github.com/taesiri/randomness
 *
 * Functions    : MiddleSquareGenerator(int64) int64,  GetLen(int64) int
 *                MultiplicativeCongruentialGenerator  (generatedNumber int64, ratio float64 )
 *                MixedCongruentialGenerator  (generatedNumber int64, ratio float64 )
 *
 *
 * Engineering
 * Status       : BETA
 *
 *
 * Author       : MohammadReza Taesiri
 */

package randomness

import "math"
func MiddleSquareGenerator(seed int64) int64{
    value := seed*seed;
    valLen :=  GetLen(value);
    seedLen :=  GetLen(seed);
    dl := valLen - seedLen;
    if dl%2 == 1 {
        dl++
    }
     dl = dl/2;

    value = value / int64((math.Pow(10, float64(dl))))
    value = value % int64((math.Pow(10, float64(seedLen))))

    return value
}

func MultiplicativeCongruentialGenerator(modulus int64, multiplier int64, seed int64)  (generatedNumber int64, ratio float64 ) {

    generatedNumber = (multiplier * seed) % modulus
    ratio = float64(generatedNumber) / float64(modulus)

    return
}

func MixedCongruentialGenerator(modulus int64, multiplier int64, increment int64, seed int64)  (generatedNumber int64, ratio float64 ) {

    generatedNumber =  ((multiplier * seed) + increment) % modulus
    ratio = float64(generatedNumber) / float64(modulus)

    return
}

func GetLen(number int64) int {
    if number == 0 {
        return 1;
    }
    i := 0;
    for  number!=0{
          number = number/10;
          i++;
    }
    return i;
}
