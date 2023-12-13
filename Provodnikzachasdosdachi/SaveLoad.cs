using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork9
{
    internal class SaveLoad
    {
        public static List<Hotkey> Load()
        {
            List<Hotkey> Hotkeys;
            if (File.Exists("C:\\Users\\Administrator\\Desktop\\help.json"))
            {
                string Text = File.ReadAllText("C:\\Users\\Administrator\\Desktop\\help.json");
                Hotkeys = JsonConvert.DeserializeObject<List<Hotkey>>(Text);
                return Hotkeys;
            }
            else return null;
        }
        public static void Save(List<Hotkey> hotkeys)
        {
            string json = JsonConvert.SerializeObject(hotkeys);
            File.WriteAllText("C:\\Users\\Administrator\\Desktop\\help.json", json);
        }
    }
}
