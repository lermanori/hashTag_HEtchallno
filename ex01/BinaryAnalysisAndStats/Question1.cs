namespace BinaryAnalysisAndStats
{
    using System;

    public class BinaryAnalysisAndStats
    {
        public static void Main()
        {
            ConsoleKeyInfo lastDigitRecieved;
            string decimalNumbers = string.Empty;
            int howManyPowerOfTwo = 0, howManyDownSeries = 0;
            int decimalValue = 0, totalDecimalSum = 0;
            int numbersRead = 0, digitCounter = 0, numberOfOnes = 0, numberOfZeros = 0;
            double decimalAverage = 0;
            string newLine = Environment.NewLine;

            while (numbersRead < 3)
            {
                lastDigitRecieved = Console.ReadKey();

                if (lastDigitRecieved.KeyChar == '1')
                {
                    decimalValue = (decimalValue * 2) + 1;
                    ++numberOfOnes;
                    ++digitCounter;
                }
                else if (lastDigitRecieved.KeyChar == '0')
                {
                    decimalValue *= 2;
                    ++numberOfZeros;
                    ++digitCounter;
                }
                else if (digitCounter == 9 && lastDigitRecieved.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    decimalNumbers += decimalValue.ToString() + ",";
                    decimalNumbers += ",";

                    totalDecimalSum += decimalValue;
                    if (numbersRead == 2)
                    {
                        decimalAverage = totalDecimalSum / 3;
                    }

                    if (Math.Log(decimalValue, 2) - Math.Floor(Math.Log(decimalValue, 2)) == 0)
                    {
                        howManyPowerOfTwo++;
                    }

                    howManyDownSeries += CheckIfDownSeries(decimalValue.ToString());
                    decimalValue = 0;
                    digitCounter = 0;
                    numbersRead++;
                }
                else
                {
                    Console.WriteLine(newLine + "Invalid Input. Please Try Again!");
                    decimalValue = 0;
                    numberOfZeros = 0;
                    numberOfOnes = 0;
                    digitCounter = 0;
                }
            }

            Console.WriteLine("Numbers Are: " + decimalNumbers);
            Console.WriteLine("Out of them #" + howManyPowerOfTwo + " numbers are a power of 2");
            Console.WriteLine("Out of them #" + howManyDownSeries + " numbers compose a down series");
            Console.WriteLine("Total Average is" + decimalAverage);
            Console.ReadLine();
        }

        public static int CheckIfDownSeries(string i_numberToCheck)
        {
            int i;
            int max = i_numberToCheck[0];
            for (i = 1; i < i_numberToCheck.Length; ++i)
            {
                if (i_numberToCheck[i] >= max)
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
