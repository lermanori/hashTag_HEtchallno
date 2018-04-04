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
            int inputNumber;

            badInputMessage = "input is invalid. Input must be a number!";

            userInput = Console.ReadLine();
            validInput = int.TryParse(userInput, out inputNumber);




            //need to see if this is more clear then if else notation
            goodInputMessage = validInput ? BegginersHourglass.Question2.createHourglass(inputNumber) : string.Empty; 
            outputMessage = validInput ?  goodInputMessage : badInputMessage;

            Console.WriteLine(outputMessage);
            Console.ReadLine();
        }


        }

    
}
