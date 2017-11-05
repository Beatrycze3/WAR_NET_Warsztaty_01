using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TaskList.CommandsHelper;

namespace TaskList
{
    public class Commands
    {
        private static List<Task> tasksList = new List<Task>();
        private static ConsoleClr consoleClr = new ConsoleClr();
        private static string path = Directory.GetCurrentDirectory() + "\\TasksList.txt";
        private static int[] padsSize = { 30, 20, 20 };

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

            if (temp.Length == 2)
            {
                tempTask.EndTime = null;
                tempTask.IsDaily = true;
                tempTask.IsImportant = false;

                tasksList.Add(tempTask);
                CommentsSuccess("Dodanie");
                return;
            }

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

            

            string text = $"{"Opis".PadLeft(padsSize[0], ' ')}|" +
               $"{"Data rozpoczęcia".PadLeft(padsSize[1], ' ')}|" +
               $"{"Data zakończenia".PadLeft(padsSize[2], ' ')}|";

            Console.WriteLine(text);
            Console.WriteLine("`".PadLeft(padsSize[0] + padsSize[1] + padsSize[2] + 3, '`'));

            foreach (Task item in tasksList)
            {
                ShowHelper.ShowTask(item, padsSize);
            }
        }

        public static void RemoveTasks()
        {
            

            string text = $"Index|{"Opis".PadLeft(padsSize[0], ' ')}|" +
               $"{"Data rozpoczęcia".PadLeft(padsSize[1], ' ')}|" +
               $"{"Data zakończenia".PadLeft(padsSize[2], ' ')}|";
               
            Console.WriteLine(text);
            Console.WriteLine("`".PadLeft(padsSize[0] + padsSize[1] + padsSize[2] + 8, '`'));

            int index = 1;
            foreach (Task item in tasksList)
            {
                Console.Write($"{index}".PadLeft(5,' '));
                ShowHelper.ShowTask(item, padsSize);
                index++;
            }
            

            index = 1;
            try
            {
                Console.Write("Podaj indeks zdarzenia które chcesz usunąć: ");
                int removeIndex = Convert.ToInt32(Console.ReadLine());

                foreach (Task item in tasksList)
                {
                    if (index == removeIndex)
                    {
                        tasksList.Remove(item);
                        CommentsSuccess("Usunięcie");
                        return;
                    }
                }

                consoleClr.WriteLine("Podany indeks nie istnieje.", ConsoleColor.Red);
            }
            catch(FormatException)
            {
                consoleClr.WriteLine("Niepoprawny format wpisanego indeksu.", ConsoleColor.Red);
            }
        }

        public static void Save()
        {
            StringBuilder allTasks = new StringBuilder();
            foreach (Task item in tasksList)
            {
                allTasks.AppendLine(item.Export());
            }

            File.WriteAllText(path, allTasks.ToString());

            consoleClr.WriteLine("Lista została zapisana do pliku", ConsoleColor.Green);
        }

        public static void Load()
        {
            try
            {
                string[] allTasksInString = File.ReadAllLines(path);

                List<Task> loadedTasksList = new List<Task>();

                foreach (string item in allTasksInString)
                {
                    loadedTasksList.Add(Task.Import(item));
                }

                tasksList = loadedTasksList;
                consoleClr.WriteLine("Lista zadań została pobrana.", ConsoleColor.Green);
            }
            catch (FileNotFoundException)
            {
                consoleClr.WriteLine("Brak zadań do wczytania.", ConsoleColor.DarkRed);
            }
        }

        private static void CommentsSuccess(string text)
        {
            consoleClr.WriteLine($"{text} zdarzenia zakończone sukcesem.", ConsoleColor.Green);
        }
    }
}
