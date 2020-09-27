using System;
using System.Globalization;

namespace Devbridge_Task_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input from year");
            int fromYear = -1;
            bool fromYearParsed = false;
            while (!fromYearParsed || fromYear < 0) {
                string stringFromYear = Console.ReadLine();
                fromYearParsed = Int32.TryParse(stringFromYear, out fromYear);
                if (!fromYearParsed || fromYear < 0)
                {
                    Console.WriteLine("Wrong from year (less than 0)");
                }
            }
            Console.WriteLine("Input to year");
            bool toYearParsed = false;
            int toYear = -1;
            while (!toYearParsed || toYear < 0 || toYear < fromYear)
            {
                string stringToYear = Console.ReadLine();
                toYearParsed = Int32.TryParse(stringToYear, out toYear);
                if (!fromYearParsed || toYear < 0 || toYear < fromYear)
                {
                    Console.WriteLine("Wrong to year (less than 0 or less than from year)");
                }
            }
            printBonusDatesBetween(fromYear, toYear);

        }
        static void printBonusDatesBetween(int fromYear, int toYear)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            for (int i = fromYear; i < toYear; i++) {
                string year = i.ToString();
                string reversedYear = reverseString(year);
                string month = "" + reversedYear[0] + reversedYear[1];
                string day = "" + reversedYear[2] + reversedYear[3];
                string format = "yyyy-MM-dd";
                DateTime dt;
                bool dateExists = DateTime.TryParseExact(year + "-" + month + "-" + day, 
                    format, provider, DateTimeStyles.None, out dt);
                if (dateExists)
                {
                    Console.WriteLine(year + "-" + month + "-" + day);
                }
            }
        }
        static string reverseString(string var)
        {
            string reversedString = "";
            for(int i=var.Length - 1;i>=0; i--)
            {
                reversedString += var[i];
            }
            return reversedString;
        }
    }
}
