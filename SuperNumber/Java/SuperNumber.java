public class SuperNumber
{
    public static void main(String[] args)
    {
        long startTime = System.currentTimeMillis();
        int[] superNumbers = new int[9];
        for (int j = 2; j <= 9; j++)
        {
            superNumbers = new int[j];
            int possibilityCount = (int)Math.pow(j, j);
            for (int i = 0; i < possibilityCount - 1; i++)
            {
                incrementArray(superNumbers, superNumbers.length - 1);
                if (isSuperNumber(superNumbers))
                {
                    for(int digit : superNumbers)
                        System.out.print(digit);
                    System.out.println();
                }
            }
        }
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
    public static boolean isSuperNumber(int[] superNumbers)
    {
        int count = 0;
        int digitCount = superNumbers.length;
        for (int index = 0; index < digitCount; index++)
        {
            count = 0;
            for (int digit : superNumbers)
            {
                if (digit == index)
                    count++;
            }
            if (count != superNumbers[index])
                return false;
        }
        return true;
    }
}