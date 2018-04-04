


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace utils
{
    public class fileUtils
    {
        public static string pathToApp;
        public static void writeToFile(string[] fileArr, string path)
        {

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string s in fileArr)
                {
                    sw.WriteLine(s);
                }
            }
        }
        public static List<string> readFromFile(string path)
        {
            List<string> result = new List<string> { string.Empty };
            // Read and show each line from the file.
            string line = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return result;
        }
        public static void runTest(string pathToTestFile, string pathToResultFile)
        {
            List<string> inputData = readFromFile(pathToTestFile);
            string[] outputData = new string[inputData.Count];

            inputData.CopyTo(outputData);

            for (int i = 0; i < outputData.Length; i++)
            {
                int result;
                bool validity = int.TryParse(inputData[i], out result);
                outputData[i] = validity ? BegginersHourglass.Question2.createHourglass(result) : "something went wrong mate!";
            }
            writeToFile(outputData, pathToResultFile);

        }
        public static void paddingForRunTest(string i_fileName, string o_fileName)
        {
            string pathToTxtfile = @"C:\Users\lerman\Desktop\tests\" + i_fileName;
            string PathToResultFile = @"C:\Users\lerman\Desktop\tests\" + o_fileName;
            runTest(pathToTxtfile, PathToResultFile);
        }
        public static void Main(string[] args)
        {
            string pathToTstFolde = @"C:\Users\lerman\Desktop\tests\";
            string fileName = @"hourGlass_tst0.txt";
            //string[] test = makeMytest();
            //writeToFile(test, pathToTstFolde + fileName);
            paddingForRunTest(fileName, "testRes0_HourGlass.txt");


        }

        private static string[] makeMytest()
        {
            string[] result = new string[101];

            for(int i = 0;i<=100;i++)
            {
                result[i] += i.ToString();
            }
            return result;

        }
    }
}




