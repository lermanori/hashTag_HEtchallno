using System;

namespace B18_Ex01_3
{
    public class Program
    {
        private static string preInputMessage = "Please enter the requested hourglass height (and press enter):";
        private static string invalidInputMessage = "Invalid Input.";

        public static void Main()
        {
            runAdvancedHourglass();
        }

        private static void runAdvancedHourglass()
        {
            string hourGlassToPrint = string.Empty;
            string userInput;
            int decimalInput;
            bool validInput;

            Console.WriteLine(preInputMessage);
            userInput = Console.ReadLine();
            validInput = int.TryParse(userInput, out decimalInput);

            if (validInput)
            {
                if (decimalInput % 2 == 0)
                {
                    decimalInput--;
                }

                hourGlassToPrint = B18_Ex01_2.Program.createHourGlass(decimalInput);
                Console.WriteLine(hourGlassToPrint);
            }
            else
            {
                Console.WriteLine(invalidInputMessage);
            }

            Console.ReadLine();
        }
    }
}
