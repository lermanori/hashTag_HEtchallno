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
            int inputNumber;

            badInputMessage = "input is invalid. Input must be a number!";

            userInput = Console.ReadLine();
            validInput = int.TryParse(userInput, out inputNumber);
            needOldHourglass = inputNumber < 5 ? string.Empty : BegginersHourglass.Question2.hourGlass;
            needSpacing = inputNumber < 5 ? string.Empty : Environment.NewLine;

            // 0 - new hrgls top, 1 - newline , 2 - q2 hrgls  3 - new hrgls bottom
            goodInputMessage = string.Format("{0}{1}{2}{1}{3}", "%top" , needSpacing, needOldHourglass, "%bottom");
            goodInputMessage = string.Format(
@"{0}
{1}
{2}", "%top", needOldHourglass, "%bottom");

            outputMessage = validInput ?  goodInputMessage : badInputMessage;

            Console.WriteLine(outputMessage);
            Console.ReadLine();
        }
    }
}
