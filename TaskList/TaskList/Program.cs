using System;
using System.Text;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = Encoding.GetEncoding(852);
            Console.OutputEncoding = Encoding.UTF8;

            do
            {
                Console.WriteLine("Wpisz polecenie:");
                string command = Console.ReadLine();
                if (command=="exit") { break; }


            } while (true);


            Console.ReadKey();
        }
    }
}
