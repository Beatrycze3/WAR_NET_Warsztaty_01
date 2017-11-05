using System;
using System.Text;
using System.Collections.Generic;

namespace TaskList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = Encoding.GetEncoding(852);
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("!!!Witamy w programie \"Task\"!!!");
            ConsoleClr consoleClr = new ConsoleClr();

            Commands.Load();

            bool keepOnLooping = true;

            do
            {
                consoleClr.WriteLine("Wpisz polecenie (z listy poniżej):",ConsoleColor.Blue);
                Console.WriteLine("AddTasks / a - Dodanie zdarzenia do listy");
                Console.WriteLine("ShowTasks - Wyświetlenie zdarzeń z listy");
                Console.WriteLine("RemoveTasks - Usunięcie zdarzenia do listy");
                Console.WriteLine("Save / s  - Zapisanie listy");
                Console.WriteLine("Load / l - Załadowanie zapisanej listy");
                Console.WriteLine("exit - Wyjście z programu");

                string command = Console.ReadLine();
                
                switch (command)
                {
                    case "exit":
                        keepOnLooping = false;
                        break;
                    case "AddTasks":
                    case "a":
                        Commands.AddTask();
                        break;
                    case "ShowTasks":
                        Commands.ShowTasks();
                        break;
                    case "RemoveTasks":
                        Commands.RemoveTasks();
                        break;
                    case "Save":
                    case "s":
                        Commands.Save();
                        break;
                    case "Load":
                    case "l":
                        Commands.Load();
                        break;
                    default:
                        consoleClr.WriteLine("Nie ma takiego polecenia.",ConsoleColor.Red);
                        break;
                }

            } while (keepOnLooping);

            consoleClr.WriteLine("Dziękujemy za skorzystanie z naszego programu \"Task\".",ConsoleColor.Yellow);
            Console.ReadKey();
        }
    }
}
