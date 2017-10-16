using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class ConsoleClr
    {
        public ConsoleClr WriteLine(string tekst, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(tekst);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public ConsoleClr Write(string tekst, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(tekst);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
