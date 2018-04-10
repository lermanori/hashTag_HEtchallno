using System;

namespace B18_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            string hourGlass = createHourGlass();
            Console.WriteLine(hourGlass);
            Console.ReadLine();
        }

        // this method can only create a proper hourglass for odd inputs --> our choice for implementation
        public static string createHourGlass(int i_requestedHeight = 5)
        {
            string retHourGlass = string.Empty;
            int numOfSpacesBeforeSign = 0;

            for (int i = i_requestedHeight; i > 0; i -= 2, numOfSpacesBeforeSign++) 
            {
                retHourGlass += string.Format(
                    "{0}{1}{0}{2}",
                    createString(numOfSpacesBeforeSign, ' '),
                    createString(i),
                    Environment.NewLine);
            }

            numOfSpacesBeforeSign -= 2; // when we reach the center of the hourglass - we want to decrease the value of this variable by 2 in order to print the bottom part of the hourglass

            for (int i = 3; i <= i_requestedHeight; i += 2, numOfSpacesBeforeSign--)
            {
                retHourGlass += string.Format(
                    "{0}{1}{0}{2}",
                    createString(numOfSpacesBeforeSign, ' '),
                    createString(i),
                    Environment.NewLine);
            }

            return retHourGlass;
        }

        private static string createString(int i_howManyChars, char i_charToPrint = '*')
        {
            System.Text.StringBuilder retString = new System.Text.StringBuilder();
            retString.Append(i_charToPrint, i_howManyChars);
            return retString.ToString();
        }
    }
}
