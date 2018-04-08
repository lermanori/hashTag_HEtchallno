namespace StringAnalysis
{
    using System;
    using System.Text;

    public class Question4
    {
        public enum eStringStates
        {
            Alphebetical,
            NumericString,
            Undefined,
            WrongInput
        }

        public static void Main()
        {
            Console.WriteLine("Hi. Plz enter a string:");
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
            eStringStates StringState = CheckStringValidityAndKind(userInputString);


            if (StringState == eStringStates.NumericString)
            {
                isEvenNumber = ((lastCharInString - '0') % 2 == 0) ? true : false;
            }

            if (StringState == eStringStates.Alphebetical)
            {
                numberOfLowerCaseLetters = countLowerCaseLetters(userInputString);
            }


            isDigitsMessage = string.Format("and is {0}even.", isEvenNumber ? string.Empty : "not ");
            isLettersMessage = string.Format("and it has {0} lower case letters.", numberOfLowerCaseLetters);
            isDigitsOrLettersMessage = StringState == eStringStates.NumericString ? isDigitsMessage : isLettersMessage;
            string goodInputMessage = string.Format("is {0}a palyndrom, {1}", isPalyndrom ? string.Empty : "not ", isDigitsOrLettersMessage);
            messageToShow = userInputString.Length == 8 && StringState != eStringStates.WrongInput ? goodInputMessage : badInputMessage;
            string outputMsg = string.Format("The string {0} {1}", userInputString, messageToShow);

            Console.WriteLine(outputMsg);
            Console.ReadLine();
        }

        private static int countLowerCaseLetters(string userInputString)
        {
            int res = 0;
            for (int i = 0; i < userInputString.Length; i++)
            {
                if (char.IsLower(userInputString[i]))
                {
                    res++;
                }
            }
            return res;
        }

        private static eStringStates CheckStringValidityAndKind(string userInputString)
        {
            eStringStates res = eStringStates.Undefined;
            res = char.IsNumber(userInputString[0]) ? eStringStates.NumericString : eStringStates.Alphebetical;

            for (int i = 1; i < userInputString.Length && res != eStringStates.WrongInput; i++)
            {
                if ((res == eStringStates.Alphebetical && char.IsDigit(userInputString[i])) || (res == eStringStates.NumericString && char.IsLetter(userInputString[i])))
                {
                    res = eStringStates.WrongInput;
                }
            }
            return res;
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



    }
}