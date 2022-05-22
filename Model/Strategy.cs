using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Strategy : Game
    {
        public Strategy()
        {
            this.OS = new String[] { "Windows" };
            this.RAM = 6;
            this.ROM = 49;
            this.CpuCores = 6;
            this.CpuFrequency = 2;
            this.GpuMemory = 2;
            this.Genre = "Strategy";
            this.saves = new List<string>();
        }
        public override void Play(int controllers)
        {
            Login();
            var f = true;
            while (f)
            {
                switch (Cout.Switch("Strategy", new string[] { "Make save", "See saves", "Play", "Exit" }))
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
                        Cout.Message("RPG", "You're playing Strategy))");
                        break;
                    default:
                        f = false;
                        break;
                }
            }
        }
    }
}
