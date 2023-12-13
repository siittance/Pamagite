using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork9
{
    internal class HotkeysManager
    {
        ConsoleKeyInfo Key;
        int pos;
        List<Hotkey> Hotkeys = new List<Hotkey>();
        public void Menu()
        {
            while (true)
            {
                if (File.Exists("C:\\Users\\Administrator\\Desktop\\help.json"))
                    Hotkeys = SaveLoad.Load();
                Console.Clear();
                Console.WriteLine(" Менеджер горячих клавиш");
                Console.WriteLine("F1 - Добавить новую горячую клавишу");
                Console.WriteLine("F10 - Перейти в режим выполнения горячих клавиш");
                Console.WriteLine("-----------------------------------");
                if (Hotkeys.Count > 0)
                {
                    foreach (Hotkey hotkey in Hotkeys)
                    {
                        Console.WriteLine($"  {hotkey.key} - {hotkey.path}");
                    }
                }
                pos = Arrow.CheckPos(4, 4 + Hotkeys.Count - 1);
                if (pos == -1)
                    Hotkeys.Add(Add());
                else if (pos == -2) Run(Hotkeys);
                else
                {
                    Hotkeys[pos - 4] = Edit(Hotkeys[pos - 4]);
                    if (Hotkeys[pos - 4] == null)
                        Hotkeys.RemoveAt(pos - 4);
                }
                SaveLoad.Save(Hotkeys);
            }
        }

        private Hotkey Add()
        {
            Hotkey hotkey = new Hotkey();
            Console.WriteLine();
            Console.WriteLine("Введите новую клавишу");
            Key = Console.ReadKey();
            hotkey.key = Key.Key;
            Console.WriteLine();
            Console.WriteLine("Введите путь");
            hotkey.path = Console.ReadLine();


            return hotkey;
        }

        private Hotkey Edit(Hotkey hotkey)
        {
            Console.Clear();
            Console.WriteLine($"Нажатие на клавишу {hotkey.key}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Запуск файла по пути {hotkey.path}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("F1 - Изменить выбранную горячую клавишу");
            Console.WriteLine("F2 - Удалить выбранную горячую клавишу");
            do
            {
                Key = Console.ReadKey();
                if (Key.Key == ConsoleKey.F1)
                    return Add();
                if (Key.Key == ConsoleKey.F2)
                    return null;
            } while (Key.Key != ConsoleKey.F1 || Key.Key != ConsoleKey.F2);
            return null;
        }

        private void Run(List<Hotkey> Hotkeys)
        {
            Console.Clear();
            Console.WriteLine("Выполнение горячих клавиш");
            Console.WriteLine("F10 - Перейти в режим управления");
            foreach (Hotkey hotkey in Hotkeys)
            {
                Console.WriteLine($"  {hotkey.key} - {hotkey.path}");
            }
            do
            {
                Key = Console.ReadKey();
                foreach (Hotkey hotkey in Hotkeys)
                {
                    if (Key.Key == hotkey.key)
                        Process.Start(hotkey.path);
                }
            } while (Key.Key != ConsoleKey.F10);
        }

    }
}
