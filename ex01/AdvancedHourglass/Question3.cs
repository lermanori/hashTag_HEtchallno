namespace AdvancedHourglass
{
using System;
    public class Question3
    {
        public static void Main()
        {
            string userInput;
            bool validInput;
            string outputMessage, goodInputMessage, badInputMessage;
            string needOldHourglass, needSpacing;
            string topPartOfHourGlass, bottomPartOfHourGlass;
            int inputNumber;

            badInputMessage = "input is invalid. Input must be a number!";

            userInput = Console.ReadLine();
            validInput = int.TryParse(userInput, out inputNumber);
            inputNumber = inputNumber % 2 == 0 ? --inputNumber : inputNumber;// we chose to decrement one in a manner of paired input;
            needOldHourglass = inputNumber < 5 ? string.Empty : BegginersHourglass.Question2.hourGlass;
            needSpacing = inputNumber < 5 ? string.Empty : Environment.NewLine;
            topPartOfHourGlass = addMissingSpaceToSimpleHourGlassToMakeHimAdvAnced(inputNumber);
            bottomPartOfHourGlass = reverseOrderOfStringForHourGlasses(topPartOfHourGlass);
            //0 - new hrgls top, 1 - newline , 2 - q2 hrgls  3 - new hrgls bottom
           goodInputMessage = string.Format("{0}{1}{2}{1}{3}", "%top", needSpacing, needOldHourglass, "%bottom");//we cant use the @ (wysiwyg) because of the usage of simpleHourGlass string because if we dont need it we will have blank line that because of @ cant be nothing and have to be a new line 




            //            goodInputMessage = string.Format(
            //@"{0}
            //{1}
            //{2}", "%top", needOldHourglass, "%bottom");

            outputMessage = validInput ?  goodInputMessage : badInputMessage;

            Console.WriteLine(outputMessage);
            Console.ReadLine();
        }

        private static string reverseOrderOfStringForHourGlasses(string topPartOfHourGlass)
        {
            
        }

        private static string addMissingSpaceToSimpleHourGlassToMakeHimAdvAnced(int inputNumber)
        {
            string result = string.Empty;
            for(int i= inputNumber;i>5; i-=2)
            {
                for (int j = 0; j < i; j++)
                    string.Concat("*");
                string.Concat(Environment.NewLine);
            }
            return result;
        }
    }
}
