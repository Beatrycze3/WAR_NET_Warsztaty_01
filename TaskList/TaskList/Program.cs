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

            List < Task > lista = new List<Task>();

            bool keepOnLooping = true;

            do
            {
                Console.WriteLine("Wpisz polecenie:");
                string command = Console.ReadLine();
                
                switch (command)
                {
                    case "exit":
                        keepOnLooping = false;
                        break;
                    case "AddTask":
                    case "a":
                        //Commands.AddTask();
                        break;
                    case "ShowTasks":
                        //Commands.ShowTasks();
                        break;
                    case "RemoveTasks":
                        //Commands.RemoveTasks();
                        break;
                    case "Save":
                    case "s":
                        //Commands.Save();
                        break;
                    case "Load":
                    case "l":
                        //Comands.Load();
                        break;
                    default:
                        Console.WriteLine("Nie ma takiego polecenia.");
                        break;
                }

            } while (keepOnLooping);

            Console.WriteLine("Dziękujemy za skorzystanie z naszego programu \"Task\".");
            Console.ReadKey();
        }
    }
}
