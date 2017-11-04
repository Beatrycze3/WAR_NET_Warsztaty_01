using System;
using System.Collections.Generic;
using System.Text;
using TaskList.CommandsHelper;

namespace TaskList
{
    public class Commands
    {
        static List<Task> tasksList = new List<Task>();
        private static ConsoleClr consoleClr = new ConsoleClr();
        public static void AddTask()
        {
            //ConsoleClr consoleClr = new ConsoleClr();

            Console.WriteLine("Wpisz zdarzenie według jednego z poniższych schematów:");
            Console.WriteLine("- opis; data rozpoczęcia (YYYY-MM-DD); data zakończenia (YYYY-MM-DD); [ważność - opcjonalnie] ");
            Console.WriteLine("- opis; data rozpoczęcia (YYYY-MM-DD); [ważność - opcjonalnie] - zdarzenie całodniowe");

            string text = Console.ReadLine();
            string[] temp = text.Split(';');

            if (temp.Length < 2 || temp.Length > 4)
            {
                consoleClr.WriteLine("Niepoprawny format wpisanego zdarzenia.", ConsoleColor.Red);
                return;
            }

            Task addedTask = new Task(); 
           
        }

        public static void ShowTasks()
        {
            ConsoleClr consoleClr = new ConsoleClr();
        }
        //Commands.ShowTasks();
        //Commands.RemoveTasks();
        //Commands.Save();
        //Comands.Load();






        

        
    }
}
