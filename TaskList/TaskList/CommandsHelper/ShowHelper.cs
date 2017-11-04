using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.CommandsHelper
{
    public static class ShowHelper
    {
        private static ConsoleClr consoleClr = new ConsoleClr();

        public static void ShowTask(Task ourTask, int[] padsSize)
        {
            string text = $"{ourTask.Description.PadLeft(padsSize[0], ' ')}|" +
               $"{ourTask.StartTime.ToString().PadLeft(padsSize[1], ' ')}|" +
               $"{ourTask.EndTime.ToString().PadLeft(padsSize[2], ' ')}|";

            int checkColor = GetTask(ourTask);

            switch (checkColor)
            {
                case 1:
                    consoleClr.WriteLine(text, ConsoleColor.DarkCyan);
                    return;
                case 2:
                    consoleClr.WriteLine(text, ConsoleColor.DarkYellow);
                    return;
                case 3:
                    consoleClr.WriteLine(text, ConsoleColor.DarkGreen);
                    return;
                case 4:
                    consoleClr.WriteLine(text, ConsoleColor.Cyan);
                    return;
                case 5:
                    consoleClr.WriteLine(text, ConsoleColor.Yellow);
                    return;
                case 6:
                    consoleClr.WriteLine(text, ConsoleColor.Green);
                    return;
            }
        }

        public static int GetTask(Task ourTask)
        {
            //zdarzenie niecałodniowe
            if (!ourTask.IsDaily)
            {
                //zdarzenia nie rozpoczęte
                if (ourTask.StartTime < DateTime.Now)
                {
                    if (ourTask.IsImportant) { return 4; }
                    return 1;
                }

                //zdarzenia zakończone
                if (ourTask.EndTime > DateTime.Now)
                {
                    if (ourTask.IsImportant) { return 6; }
                    return 3;
                }

                //zdarzenia w trakcie
                if (ourTask.IsImportant) { return 5; }
                return 2;
            }

            //zdarzenia całodniowe
            else
            {
                //sprawdzenie roku
                if (ourTask.StartTime.Year < DateTime.Now.Year)
                {
                    if (ourTask.IsImportant) { return 4; }
                    return 1;
                }
                else if (ourTask.StartTime.Year > DateTime.Now.Year)
                {
                    if (ourTask.IsImportant) { return 6; }
                    return 3;
                }

                //sprawdzenie miesiąca
                if (ourTask.StartTime.Month < DateTime.Now.Month)
                {
                    if (ourTask.IsImportant) { return 4; }
                    return 1;
                }
                else if (ourTask.StartTime.Month > DateTime.Now.Month)
                {
                    if (ourTask.IsImportant) { return 6; }
                    return 3;
                }

                //sprawdzenie dnia
                if (ourTask.StartTime.Day < DateTime.Now.Day)
                {
                    if (ourTask.IsImportant) { return 4; }
                    return 1;
                }
                else if (ourTask.StartTime.Day > DateTime.Now.Day)
                {
                    if (ourTask.IsImportant) { return 6; }
                    return 3;
                }

                if (ourTask.IsImportant) { return 5; }
                return 2;
            }
        }
    }
}
