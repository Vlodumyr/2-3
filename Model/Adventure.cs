using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Adventure : Game
    {
        public Adventure()
        {
            this.OS = new String[] { "Windows", "Android", "Console" };
            this.RAM = 2;
            this.ROM = 14;
            this.CpuCores = 2;
            this.CpuFrequency = 1;
            this.GpuMemory = 1;
            this.Genre = "Adventure";
            this.saves = new List<string>();
        }
        public override void Play(int controllers)
        {
            Login();
            var f = true;
            while (f)
            {
                switch (Cout.Switch("Adventure", new string[] { "Make save", "See saves", "Play", "Exit" }))
                {
                    case "Make save":
                        this.saves.Add($"Save at {DateTime.Now.ToString()}");
                        break;
                    case "See saves":
                        var str = "";
                        foreach (var i in this.saves)
                            str += i + Environment.NewLine;
                        Cout.Message("Saves", str);
                        break;
                    case "Play":
                        Cout.Message("Adventure", "You're playing Adventure))");
                        break;
                    default:
                        f = false;
                        break;
                }
            }
        }
    }
}
