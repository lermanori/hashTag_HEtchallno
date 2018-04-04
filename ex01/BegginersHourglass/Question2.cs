namespace BegginersHourglass
{
    using System;
    public class Question2
    {
//        public static string hourGlass =
//@"*****
// ***
//  *
// ***
//*****";

        public static void Main()
        {
            string hourGlass = createHourglass();
            Console.WriteLine(hourGlass);
            Console.ReadLine();
        }
        public static string createHourglass(int i_RequestedHeight=5,int i_rightSpacing=0)
        {
            string hourGlass =  string.Empty;
            int spacingInsideHourGlass = 0;
            i_RequestedHeight = i_RequestedHeight % 2 == 0 ? --i_RequestedHeight : i_RequestedHeight;//our chice for paired input
            for (int j = i_RequestedHeight;j > 0;j-=2)
            {
                hourGlass += string.Format("{0}{1}{0}{2}", createStringFromCharAndNumber(spacingInsideHourGlass++,' ')//here is where spacing is advanced every iteration
                                                        , createStringFromCharAndNumber(j,'*')
                                                        , Environment.NewLine
                                                        );
            }
            spacingInsideHourGlass-=2;//beacuse of first row already printed and we dont wont to duplicate it-spacingWise;
            // at this certion point if we can reverse the array without first line will save the next loop;
            
            for (int j = 3; j <= i_RequestedHeight; j += 2)//beacuse of first row already printed and we dont wont to duplicate it-AstrixWise;
            {
                hourGlass += string.Format("{0}{1}{0}{2}", createStringFromCharAndNumber(spacingInsideHourGlass--, ' ')
                                                        , createStringFromCharAndNumber(j, '*')
                                                        , Environment.NewLine
                                                        );
            }


            return hourGlass;
        }
        public static string createStringFromCharAndNumber(int i_numberOfapperences,char i_requestedChar='*')
        {
            string result = string.Empty;
            for(int i=0; i<i_numberOfapperences;i++)
            {
                result += i_requestedChar;
            }
            return result;
        }
    }
}
