using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.CommandsHelper
{
    public static class DateHelper
    {
        public static bool Check(int year, int month, int day, int hour, int minute, int sec)
        {
            if (year <= 0) { return false; }
            if (hour < 0 || hour >= 24) { return false; }
            if (minute < 0 || minute > 60) { return false; }
            if (sec < 0 || sec > 60) { return false; }

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (day < 1 || day > 31) { return false; }
                    else { return true; }
                case 2:
                    if (day < 1 || day > 28) { return false; }
                    else { return true; }
                case 4:
                case 6:
                case 9:
                case 11:
                    if (day < 1 || day > 30) { return false; }
                    else { return true; }
                default:
                    return false;
            }
        }

        public static bool CheckDate(string text)
        {
            string[] tempText = text.Split('-');
            if (tempText.Length !=6) { return false; }
            int[] t = new int[6];
            for (int i=0; i<tempText.Length;i++)
            {
                t[i] = Convert.ToInt32(tempText[i]);
            }

            if (Check(t[0], t[1], t[2], t[3], t[4], t[5]) == false) { return false; }
            return true;
        }

        public static DateTime StringToDate(string text)
        {
            string[] tempText = text.Split('-');
            int[] t = new int[6];
            for (int i=0; i<tempText.Length;i++)
            {
                t[i] = Convert.ToInt32(tempText[i]);
            }
            DateTime myDate = new DateTime(t[0], t[1], t[2], t[3], t[4], t[5]);
            return myDate;
        }
        


    }
}
