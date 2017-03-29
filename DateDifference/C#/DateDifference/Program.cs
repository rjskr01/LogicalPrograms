using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateDifference
{
    class Program
    {
        const int DAY_INDEX = 1;
        const int MONTH_INDEX = 0;
        const int YEAR_INDEX = 2;

        static void Main(string[] args)
        {

            //---------------Month Day Year format--------------
            string strGivenDate = "2-16-2014";
            string strCurrentDate = "3-28-2017";

            int[] givenDate = ConvertToDate(strGivenDate);
            int[] currentDate = ConvertToDate(strCurrentDate);
            Stopwatch startWatch = Stopwatch.StartNew();
            int days=DateDifference(givenDate, currentDate);

            TimeSpan timeSpan= startWatch.Elapsed;

            Console.WriteLine("Total Days:" + days+"\tTime Taken:"+timeSpan);

            startWatch = Stopwatch.StartNew();
            days = BuiltInDifference(currentDate, givenDate);
            TimeSpan builtInSpan = startWatch.Elapsed;
            Console.WriteLine("Using Built In Function:" + days+ "\tTime Taken:"+builtInSpan);

            Console.WriteLine(strGivenDate + " is " + GetWeekDays(days));

            Console.ReadLine();
        }
        static string GetWeekDays(int days)
        {
            switch(days%7)
            {
                case 3: return "Saturday";
                case 4: return "Sunday";
                case 5: return "Monday";
                case 6: return "Tuesday";
                case 0: return "Wednesday";
                case 1: return "Thursday";
                case 2: return "Friday";
            }   
            throw new NotSupportedException("This exception will not raise.");
        }
        static int DateDifference(int[] fromDate, int[] toDate)
        {
            int month = fromDate[MONTH_INDEX];
            int day = fromDate[DAY_INDEX];
            int year = fromDate[YEAR_INDEX];

            int noOfdaysInYears = YearDifference(fromDate[YEAR_INDEX], toDate[YEAR_INDEX]);

            int noOfDaysinToYear = DaysCountIgnoreYear(new int[] { 1, 1, toDate[YEAR_INDEX] }, toDate, false);

            int noOfDaysinFromYear = DaysCountIgnoreYear(fromDate, new int[] { 12, 31, fromDate[YEAR_INDEX] }, true);

            return noOfdaysInYears + noOfDaysinFromYear + noOfDaysinToYear;

        }
        static int DaysCountIgnoreYear(int[] fromDate, int[] toDate, bool considerEndMonth)
        {
            int year = fromDate[YEAR_INDEX];
            int days = 0;
            int fromMonth, toMonth;

            if (considerEndMonth)
            {
                fromMonth = fromDate[MONTH_INDEX] + 1;
                toMonth = toDate[MONTH_INDEX];
                int noOfDaysinFromDate = GetDaysinMonth(fromDate[MONTH_INDEX], year);
                days = noOfDaysinFromDate - fromDate[DAY_INDEX] + 1;
            }
            else
            {
                fromMonth = fromDate[MONTH_INDEX];
                toMonth = toDate[MONTH_INDEX] - 1;
                days = toDate[DAY_INDEX];
            }
            while (fromMonth <= toMonth)
            {
                days += GetDaysinMonth(fromMonth, year);
                fromMonth++;
            }

            return days;
        }
        static int GetDaysinMonth(int month, int year)
        {
            switch (month)
            {
                //1,3,5,7,8,10,12
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;

                case 2:
                    return (isLeapYear(year)) ? 29 : 28;

                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
            }
            throw new NotSupportedException("Invalid Month");
        }
        static int YearDifference(int fromYear, int toYear)
        {
            const int DAYS_IN_YEAR = 365;
            int noOfyears = (toYear - fromYear) - 1;
            int noOfLeapYear = noOfyears / 4;
            return noOfyears * DAYS_IN_YEAR + noOfLeapYear;
        }
        static int[] ConvertToDate(string strDate)
        {
            int[] date = new int[3];
            string[] dateConvertion = strDate.Split('-');
            for (int i = 0; i < date.Length; i++)
                date[i] = Convert.ToInt32(dateConvertion[i]);
            return date;
        }
        static bool isLeapYear(int year)
        {
            return year % 4 == 0;
        }
        static int BuiltInDifference(int[] fromDate, int[] toDate)
        {
            DateTime fromBuiltDate = new DateTime(fromDate[YEAR_INDEX],
                fromDate[MONTH_INDEX],
                fromDate[DAY_INDEX]);

            DateTime toBuiltDate = new DateTime(toDate[YEAR_INDEX],
                toDate[MONTH_INDEX],
                toDate[DAY_INDEX]);

            return (fromBuiltDate - toBuiltDate).Days;

        }
    }
}
