using Figgle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    static class Cout
    {
        public static String Input(String Message)
        {
            Console.WriteLine(Message);
            return Console.ReadLine();
        }

        public static void Message(String Header, String Text = "")
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(FiggleFonts.Epic.Render(Header));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(Text);

            Console.ReadKey();
        }
        public static string Switch(String Header, String[] Cases)
        {
            int current = 0;
            RenderText(current, Cases, Header);
            var Key = Console.ReadKey().Key;
            while (Key != ConsoleKey.Enter)
            {
                if (Key == ConsoleKey.DownArrow)
                {
                    current += (current + 1) == Cases.Length ? 0 : 1;
                }
                if (Key == ConsoleKey.UpArrow)
                {
                    current -= current == 0 ? 0 : 1;
                }
                RenderText(current, Cases, Header);
                Key = Console.ReadKey().Key;
            }

            return Cases[current];
        }

        private static void RenderText(int Key, String[] List, String Header)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(FiggleFonts.Epic.Render(Header));
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < List.Length; i += 1)
            {
                if (i == Key)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i.ToString() + " " + List[i] + " <-");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                Console.WriteLine(i.ToString() + " " + List[i]);
            }
        }
    }
}
