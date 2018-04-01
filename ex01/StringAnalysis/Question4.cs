namespace StringAnalysis
{
    using System;
    using System.Text;

    public class Question4
    {
        public enum eStringStates
        {
            NumericString,
            AlphabeticString,
            WrongInput
        }

        public static int NumberOfLowerCaseChars = 0;
        public static eStringStates StringState = eStringStates.AlphabeticString;

        public static void Main()
        {
            Console.WriteLine("Hi. Plz enter a string:");
            string userInputString = Console.ReadLine();
            bool isPalyndrom = CheckIfPalyndrom(userInputString);
            bool isEvenNumber = false;
            bool isInputValid;
            string isDigitsMessage;
            string isLettersMessage;
            string badInputMessage = string.Format("is invalid. String must be 8 letters or digits only!");
            string isDigitsOrLettersMessage;
            string messageToShow;
            char lastCharInString = userInputString[userInputString.Length - 1];

            StringState = char.IsNumber(lastCharInString) ? eStringStates.NumericString : eStringStates.AlphabeticString;

            if (StringState == eStringStates.NumericString)
            {
                isEvenNumber = ((lastCharInString - '0') % 2 == 0) ? true : false;
            }

            for (int i = 0; i < userInputString.Length && StringState != eStringStates.WrongInput; i++)
            {
                isInputValid = CheckCharInString(userInputString[i]);
                if (!isInputValid)
                {
                    StringState = eStringStates.WrongInput;
                }
            }

            isDigitsMessage = string.Format("and is {0}even.", isEvenNumber ? string.Empty : "not ");
            isLettersMessage = string.Format("and it has {0} lower case letters.", NumberOfLowerCaseChars);
            isDigitsOrLettersMessage = StringState == eStringStates.NumericString ? isDigitsMessage : isLettersMessage;
            string goodInputMessage = string.Format("is {0}a palyndrom, {1}", isPalyndrom ? string.Empty : "not ", isDigitsOrLettersMessage);
            messageToShow = userInputString.Length == 8 && StringState != eStringStates.WrongInput ? goodInputMessage : badInputMessage;
            string outputMsg = string.Format("The string {0} {1}", userInputString, messageToShow);

            Console.WriteLine(outputMsg);
            Console.ReadLine();
        }

        public static bool CheckIfPalyndrom(string i_stringToCheck)
        {
            for (int i = 0, j = i_stringToCheck.Length - 1; i < j; i++, j--)
            {
                if (i_stringToCheck[i] != i_stringToCheck[j])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckCharInString(char i_charToCheck)
        {
            switch (StringState)
            {
                case eStringStates.NumericString:
                    return char.IsDigit(i_charToCheck);
                case eStringStates.AlphabeticString:
                    if (char.IsLower(i_charToCheck))
                    {
                        NumberOfLowerCaseChars++;
                    }

                    return char.IsLetter(i_charToCheck);
                default:
                    return false;
            }
        }
    }
}
