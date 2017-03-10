package main
import "math"
import "fmt"
import "time"
func main() {
     start := time.Now()
   const DIGIT_COUNT=9
    var possibilities []int=make([]int,DIGIT_COUNT)
   var loopCount int =int (math.Pow(float64(DIGIT_COUNT),float64(DIGIT_COUNT)))
   for i:=0; i<loopCount-1; i++ {
     incrementArray(possibilities,DIGIT_COUNT-1,DIGIT_COUNT)
   }

   fmt.Println(possibilities)
    elapsed := time.Since(start)
    fmt.Printf("Time Taken %s", elapsed)
}
func incrementArray(possibilities []int, digitIndex int,digitCount int) {
        var tmp int= 0;
        tmp = possibilities[digitIndex] + 1;
        if (tmp % digitCount == 0) {
            possibilities[digitIndex] = 0;
            incrementArray(possibilities, digitIndex - 1,digitCount);
        }else {
            possibilities[digitIndex] = tmp;
		}
    }