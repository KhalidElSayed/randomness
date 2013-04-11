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
