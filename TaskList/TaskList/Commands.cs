using System;
using System.Collections.Generic;
using System.Text;
using TaskList.CommandsHelper;

namespace TaskList
{
    public class Commands
    {
        private static List<Task> tasksList = new List<Task>();
        private static ConsoleClr consoleClr = new ConsoleClr();

        public static void AddTask()
        {
            //ConsoleClr consoleClr = new ConsoleClr();

            Console.WriteLine("Wpisz zdarzenie według jednego z poniższych schematów:");
            Console.WriteLine("- opis; data rozpoczęcia (YYYY-MM-DD-hh-mm-ss); data zakończenia (YYYY-MM-DD); [ważność - opcjonalnie] ");
            Console.WriteLine("- opis; data rozpoczęcia (YYYY-MM-DD-hh-mm-ss); [ważność - opcjonalnie] - zdarzenie całodniowe");

            string text = Console.ReadLine();
            string[] temp = text.Split(';');

            if (temp.Length < 2 || temp.Length > 4)
            {
                consoleClr.WriteLine("Niepoprawny format wpisanego zdarzenia.", ConsoleColor.Red);
                return;
            }

            Task tempTask = new Task
            {
                //Dodanie opisu
                Description = temp[0]
            };

            //Dodanie daty rozpoczęcia
            if (DateHelper.CheckDate(temp[1]) == false)
            {
                consoleClr.WriteLine("Niepoprawny format daty rozpoczęcia zdarzenia.", ConsoleColor.Red);
                return;
            }
            tempTask.StartTime = DateHelper.StringToDate(temp[1]);

            //Sprawdzenie czy całodniowe
            if (temp.Length == 3)
            {
                if (DateHelper.CheckDate(temp[2]) == false)
                {
                    if (temp[2].Contains("-") == true)
                    {
                        consoleClr.WriteLine("Niepoprawny format daty zakończenia zdarzenia.", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        tempTask.EndTime = null;
                        tempTask.IsDaily = true;
                        tempTask.IsImportant = true;

                        tasksList.Add(tempTask);
                        CommentsSuccess("Dodanie");
                        return;
                    }
                }
            }

            tempTask.EndTime = DateHelper.StringToDate(temp[2]);
            tempTask.IsDaily = false;
            if (temp.Length == 4)
            {
                tempTask.IsImportant = true;
            }

            tasksList.Add(tempTask);
            CommentsSuccess("Dodanie");
            return;
        }

        public static void ShowTasks()
        {
            Console.WriteLine("Legenda:");
            consoleClr.WriteLine("- nie rozpoczęte zdarzenie", ConsoleColor.DarkCyan)
                    .WriteLine("- rozpoczęte zdarzenie", ConsoleColor.DarkYellow)
                    .WriteLine("- zakończone zdarzenie", ConsoleColor.DarkGreen)
                    .WriteLine("- ważne nie rozpoczęte zdarzenie", ConsoleColor.Cyan)
                    .WriteLine("- ważne rozpoczęte zdarzenie", ConsoleColor.Yellow)
                    .WriteLine("- ważne zakończone zdarzenie", ConsoleColor.Green);

            int[] padsSize = { 30, 20, 20 };

            string text = $"{"Opis".PadLeft(padsSize[0], ' ')}|" +
               $"{"Data rozpoczęcia".ToString().PadLeft(padsSize[1], ' ')}|" +
               $"{"Data zakończenia".ToString().PadLeft(padsSize[2], ' ')}|";

            Console.WriteLine(text);
            Console.WriteLine("`".PadLeft(padsSize[0] + padsSize[1] + padsSize[2] + 3, '`'));

            foreach (Task item in tasksList)
            {
                ShowHelper.ShowTask(item, padsSize);
            }
        }

        //Commands.RemoveTasks();
        //Commands.Save();
        //Comands.Load();

        private static void CommentsSuccess(string text)
        {
            consoleClr.WriteLine($"{text} zdarzenia zakończone sukcesem.", ConsoleColor.Green);
        }
    }
}
