using System;

namespace B18_Ex01_1
{
    public class Program
    {
        private static int s_NumbersRead = 0;
        private static int s_TotalDecimalSum = 0;
        private static double s_DecimalAverage = 0;
        private static double s_AverageNumOfZeros = 0;
        private static int s_HowManyDescendingSeries = 0;
        private static int s_HowManyPowerOfTwo = 0;
        private static string s_DecimalNumbersString = string.Empty; // will hold the decimal numbers concatenated
        private static int s_TotalNumberOfZeros;
        private static string s_preInputMessage = "Please enter 3 binary numbers of 9 digits each (and press enter between them):";
        private static string s_invalidInputMessage = "Invalid Input. Please Try Again!";
        private static string s_formatMessage =
@"The decimal numbers are {0}.
The average number of 0's inserted in a number is {1:.000}.
There are {2} numbers which are power of 2.
There are {3} numbers which are a descending series.
The general average of the inserted numbers is: {4:.000}.";

        public static void Main()
        {
            runBinaryAnalysis();
        }

        private static void runBinaryAnalysis()
        {
            string lastReadNumber;

            string outputMessage;
            bool validInput;

            Console.WriteLine(s_preInputMessage);
            while (s_NumbersRead < 3)
            {
                lastReadNumber = Console.ReadLine();
                validInput = checkValidity(lastReadNumber);
                analyzeBinaryNumber(validInput, lastReadNumber);
            }

            s_DecimalAverage = (double)s_TotalDecimalSum / 3;
            s_AverageNumOfZeros = (double)s_TotalNumberOfZeros / 3;

            outputMessage = string.Format(s_formatMessage, s_DecimalNumbersString, s_AverageNumOfZeros, s_HowManyPowerOfTwo, s_HowManyDescendingSeries, s_DecimalAverage);

            Console.WriteLine(outputMessage);
            Console.ReadLine();
        }

        private static void analyzeBinaryNumber(bool i_inputValidFlag, string i_numberToInspect)
        {
            int decimalValue;

            if (i_inputValidFlag)
            {
                decimalValue = computeDecimalValue(i_numberToInspect);
                s_TotalDecimalSum += decimalValue;
                s_TotalNumberOfZeros += countZerosInNumber(i_numberToInspect);
                s_DecimalNumbersString += decimalValue + " ";
                if (isPowerOfTwo(decimalValue))
                {
                    s_HowManyPowerOfTwo++;
                }

                if (isDescendingSeries(decimalValue))
                {
                    s_HowManyDescendingSeries++;
                }

                s_NumbersRead++;
            }
            else
            {
                Console.WriteLine(s_invalidInputMessage);
            }
        }

        private static bool checkValidity(string i_numberToInspect)
        {
            if (i_numberToInspect.Length != 9)
            {
                return false;
            }

            for (int i = 0; i < i_numberToInspect.Length; i++)
            {
                if (!char.IsDigit(i_numberToInspect[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static int computeDecimalValue(string i_numberToInspect)
        {
            int returnedDecimalNumber = 0;

            for (int i = 0; i < i_numberToInspect.Length; i++)
            {
                switch (i_numberToInspect[i])
                {
                    case '0':
                        returnedDecimalNumber *= 2;
                        break;
                    case '1':
                        returnedDecimalNumber = (returnedDecimalNumber * 2) + 1;
                        break;
                }
            }

            return returnedDecimalNumber;
        }

        private static int countZerosInNumber(string i_numberToInspect)
        {
            int numberOfZeros = 0;

            for (int i = 0; i < i_numberToInspect.Length; i++)
            {
                if (i_numberToInspect[i] == '0')
                {
                    numberOfZeros++;
                }
            }

            return numberOfZeros;
        }

        private static bool isPowerOfTwo(int i_numberToInspect)
        {
            return Math.Log(i_numberToInspect, 2) - Math.Floor(Math.Log(i_numberToInspect, 2)) == 0;
        }

        private static bool isDescendingSeries(int i_numberToInspect)
        {
            bool retVal = true;
            int digit;
            while (i_numberToInspect > 0 && retVal)
            {
                digit = i_numberToInspect % 10;
                i_numberToInspect /= 10;

                if (i_numberToInspect % 10 <= digit && i_numberToInspect > 0)
                {
                    retVal = false;
                }
            }

            return retVal;
        }
    }
}
