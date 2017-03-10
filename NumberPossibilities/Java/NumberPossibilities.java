public class NumberPossibilities
{
    public static void main(String[] args)
    {
        long startTime = System.currentTimeMillis();
        int[] superNumbers = new int[9];
        int j=9;
       // for (int j = 2; j <= 9; j++)
        {
            superNumbers = new int[j];
            int possibilityCount = (int)Math.pow(j, j);
            for (int i = 0; i < possibilityCount - 1; i++)
            {
                incrementArray(superNumbers, superNumbers.length - 1);
            }
        }
        System.out.print("Max Digit:");
            for (int digit : superNumbers)
                System.out.print(digit);
        long stopTime = System.currentTimeMillis();
        long elapsedTime = (stopTime - startTime)/1000;
        System.out.print("\nTime Taken(Seconds):"+elapsedTime);
    }
    public static void incrementArray(int[] possibilities, int digitIndex)
    {
        int tmp = 0;
        int digitCount = possibilities.length;
        tmp = possibilities[digitIndex] + 1;
        if (tmp % digitCount == 0)
        {
            possibilities[digitIndex] = 0;
            incrementArray(possibilities, digitIndex - 1);
        }
        else
            possibilities[digitIndex] = tmp;
    }
}