using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork9
{
    internal class Arrow
    {


        static public int CheckPos(int min, int max)
        {
            int position = min;
            ConsoleKeyInfo key;
            while (true)
            {
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                Console.SetCursorPosition(0, 0);
                key = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.Write("  ");
                if (key.Key == ConsoleKey.UpArrow && position > min)
                {
                    position--;
                }
                if (key.Key == ConsoleKey.DownArrow && position < max)
                {
                    position++;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    return position;
                }
                if (key.Key == ConsoleKey.F1)
                {
                    return -1;
                }
                if (key.Key == ConsoleKey.F10)
                {
                    return -2;
                }
            }
        }
    }
}
