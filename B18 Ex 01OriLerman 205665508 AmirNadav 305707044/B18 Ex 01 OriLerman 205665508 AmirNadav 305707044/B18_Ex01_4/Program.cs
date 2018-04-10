using System;

namespace B18_Ex01_4
{
    public class Program
    {
        public enum eStringTypes
        {
            Alphebetical,
            NumericString,
            Undefined,
            WrongInput
        }

        public static void Main()
        {
            runStringAnalysis();
            Console.ReadLine();
        }

        private static void runStringAnalysis()
        {
            Console.WriteLine("Hi. Please enter a string:");
            string userInputString = Console.ReadLine();

            bool isEvenNumber = false;
            string isDigitsMessage;
            string isLettersMessage;
            string badInputMessage = "is invalid. String must be 8 letters or digits only!";
            string isDigitsOrLettersMessage;
            string messageToShow;
            int numberOfLowerCaseLetters = 0;
            char lastCharInString = userInputString[userInputString.Length - 1];
            bool isPalyndrom = CheckIfPalyndrom(userInputString);
            eStringTypes StringState = checkStringType(userInputString);

            if (StringState == eStringTypes.NumericString)
            {
                isEvenNumber = ((lastCharInString - '0') % 2 == 0) ? true : false;
            }

            if (StringState == eStringTypes.Alphebetical)
            {
                numberOfLowerCaseLetters = countLowerCaseLetters(userInputString);
            }

            isDigitsMessage = string.Format("and is {0}even.", isEvenNumber ? string.Empty : "not ");
            isLettersMessage = string.Format("and it has {0} lower case letters.", numberOfLowerCaseLetters);
            isDigitsOrLettersMessage = StringState == eStringTypes.NumericString ? isDigitsMessage : isLettersMessage;
            string goodInputMessage = string.Format("is {0}a palyndrom, {1}", isPalyndrom ? string.Empty : "not ", isDigitsOrLettersMessage);
            messageToShow = userInputString.Length == 8 && StringState != eStringTypes.WrongInput ? goodInputMessage : badInputMessage;
            string outputMsg = string.Format("The string {0} {1}", userInputString, messageToShow);

            Console.WriteLine(outputMsg);
        }

        private static int countLowerCaseLetters(string i_stringToCheck)
        {
            int numOfLowerCaseChars = 0;
            for (int i = 0; i < i_stringToCheck.Length; i++)
            {
                if (char.IsLower(i_stringToCheck[i]))
                {
                    numOfLowerCaseChars++;
                }
            }

            return numOfLowerCaseChars;
        }

        private static eStringTypes checkStringType(string i_stringToCheck)
        {
            eStringTypes stringType = eStringTypes.Undefined;
            bool isFirstCharValid;
            isFirstCharValid = char.IsLetterOrDigit(i_stringToCheck[0]);
            if (isFirstCharValid)
            {
                stringType = char.IsNumber(i_stringToCheck[0]) ? eStringTypes.NumericString : eStringTypes.Alphebetical;
            }
            else
            {
                stringType = eStringTypes.WrongInput;
            }

            for (int i = 1; i < i_stringToCheck.Length && stringType != eStringTypes.WrongInput; i++)
            {
                if ((stringType == eStringTypes.Alphebetical && char.IsDigit(i_stringToCheck[i])) || (stringType == eStringTypes.NumericString && char.IsLetter(i_stringToCheck[i])) || !char.IsLetterOrDigit(i_stringToCheck[i]))
                {
                    stringType = eStringTypes.WrongInput;
                }
            }

            return stringType;
        }

        public static bool CheckIfPalyndrom(string i_stringToCheck)
        {
            bool isPalyndrom = true;

            for (int i = 0, j = i_stringToCheck.Length - 1; i < j && isPalyndrom; i++, j--)
            {
                if (i_stringToCheck[i] != i_stringToCheck[j])
                {
                    isPalyndrom = false;
                }
            }

            return isPalyndrom;
        }
    }
}
