using System;

namespace B18_Ex01_5
{
    public class Program
    {
        private static string s_preInputMessage = "Please enter a positive 6 digits number(and press enter):";
        private static string s_invalidInputMessage = "The string {0} is invalid. Input must be a positive 6 digits number!";
        private static string s_formatMessage =
@"The string is: {0}
The maximum digit is {1}, minimum digit is {2}.
There are {3} even digits, and there are {4} digits smaller than the units digit.";

        public static void Main()
        {
            getNumberStatistics();
            Console.ReadLine();
        }

        private static void getNumberStatistics()
        {
            string userInputNumber;
            int inputDecimalValue;
            int maxDigit, minDigit, numOfEvenDigits, numOfDigitsSmallerThanUnitsDigit;
            bool validInput;
            string outputMessage;

            Console.WriteLine(s_preInputMessage);
            userInputNumber = Console.ReadLine();
            validInput = checkInputValidity(userInputNumber);

            if (validInput)
            {
                inputDecimalValue = int.Parse(userInputNumber);
                maxDigit = findMaxDigit(inputDecimalValue);
                minDigit = findMinDigit(inputDecimalValue);
                numOfEvenDigits = countEvenDigits(inputDecimalValue);
                numOfDigitsSmallerThanUnitsDigit = countNumOfDigitsSmallerThanUnits(inputDecimalValue);
                outputMessage = string.Format(s_formatMessage, userInputNumber, maxDigit, minDigit, numOfEvenDigits, numOfDigitsSmallerThanUnitsDigit);
            }
            else
            {
                outputMessage = string.Format(s_invalidInputMessage, userInputNumber);
            }

            Console.WriteLine(outputMessage);
        }

        private static bool checkInputValidity(string i_stringToCheck)
        {
            int dummy;
            return int.TryParse(i_stringToCheck, out dummy) && i_stringToCheck.Length == 6;
        }

        private static int findMaxDigit(int i_numberToCheck)
        {
            int maxDigit = i_numberToCheck % 10;
            i_numberToCheck /= 10;

            while (i_numberToCheck > 0)
            {
                if (i_numberToCheck % 10 > maxDigit)
                {
                    maxDigit = i_numberToCheck % 10;
                }

                i_numberToCheck /= 10;
            }

            return maxDigit;
        }

        private static int findMinDigit(int i_numberToCheck)
        {
            int minDigit = i_numberToCheck % 10;
            i_numberToCheck /= 10;

            while (i_numberToCheck > 0)
            {
                if (i_numberToCheck % 10 < minDigit)
                {
                    minDigit = i_numberToCheck % 10;
                }

                i_numberToCheck /= 10;
            }

            return minDigit;
        }

        private static int countEvenDigits(int i_numberToCheck)
        {
            int numOfEvenDigits = 0;

            while (i_numberToCheck > 0)
            {
                if ((i_numberToCheck % 10) % 2 == 0)
                {
                    numOfEvenDigits++;
                }

                i_numberToCheck /= 10;
            }

            return numOfEvenDigits;
        }

        private static int countNumOfDigitsSmallerThanUnits(int i_numberToCheck)
        {
            int numOfDigitsSmallerThanUnits = 0;
            int unitsDigit = i_numberToCheck % 10;

            i_numberToCheck /= 10;
            while (i_numberToCheck > 0)
            {
                if (i_numberToCheck % 10 < unitsDigit)
                {
                    numOfDigitsSmallerThanUnits++;
                }

                i_numberToCheck /= 10;
            }

            return numOfDigitsSmallerThanUnits;
        }
    }
}
