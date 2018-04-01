namespace NumberStatistics
{
    using System;
    class Question5
    {
        public static void Main()
        {
            string userInputNumber;
            int num;
            int maxDigit, minDigit, numOfEvenDigits, numOfDigitsSmallerThanUnitsDigit;
            string badInputMessage = string.Format("is invalid. Input must be a positive 6 digits number!");
            string goodInputMessage, messageToShow, outputMessage;

            Console.WriteLine("Plz enter a positive 6 digits number:");
            userInputNumber = Console.ReadLine();
            int.TryParse(userInputNumber, out num);

            maxDigit = findMaxDigit(num);
            minDigit = findMinDigit(num);
            numOfEvenDigits = countEvenDigits(num);
            numOfDigitsSmallerThanUnitsDigit = countNumOfDigitsSmallerThanUnits(num);
            goodInputMessage = string.Format(
                "The maximum digit is {0}, minimum digit is {1}.{4}There are {2} even digits, and there are {3} digits smaller than the units digit.",
                                                                                                                    maxDigit,
                                                                                                                    minDigit,
                                                                                                                    numOfEvenDigits,
                                                                                                                    numOfDigitsSmallerThanUnitsDigit,
                                                                                                                    Environment.NewLine);

            messageToShow = int.TryParse(userInputNumber, out num) && userInputNumber.Length == 6 ? goodInputMessage : badInputMessage;

            outputMessage = string.Format("The string is {0}. {1}", userInputNumber, messageToShow);
            Console.WriteLine(outputMessage);
            Console.ReadLine();
            

        }
        public static int findMaxDigit(int i_numberToCheck)
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
        public static int findMinDigit(int i_numberToCheck)
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
        public static int countEvenDigits(int i_numberToCheck)
        {
            int numOfEvenDigits = 0;

            while (i_numberToCheck > 0)
            {
                if((i_numberToCheck%10)%2 ==0)
                {
                    numOfEvenDigits++;
                }
                i_numberToCheck /= 10;
            }
            return numOfEvenDigits;
        }
        public static int countNumOfDigitsSmallerThanUnits(int i_numberToCheck)
        {
            int numOfDigitsSmallerThanUnits = 0;
            int unitsDigit = i_numberToCheck % 10;

            i_numberToCheck /= 10;
            while(i_numberToCheck>0)
            {
                if(i_numberToCheck%10 < unitsDigit)
                {
                    numOfDigitsSmallerThanUnits++;
                }
                i_numberToCheck /= 10;
            }
            return numOfDigitsSmallerThanUnits;
        }
    }
}
