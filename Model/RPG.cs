using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class RPG : Game
    {
        public RPG()
        {
            this.OS = new String[] { "Windows", "Android", "Console" };
            this.RAM = 4;
            this.ROM = 24;
            this.CpuCores = 4;
            this.CpuFrequency = 2;
            this.GpuMemory = 2;
            this.Genre = "RPG";
            this.saves = new List<string>();
        }
        public override void Play(int controllers)
        {
            Login();
            var f = true;
            while (f)
            {
                switch (Cout.Switch("RPG", new string[] { "Make save", "See saves", "Play", "Exit" }))
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
                        if (controllers == null || controllers == 1)
                            Cout.Message("RPG", "You're playing RPG))");
                        else
                            Cout.Message("RPG", "You're playing RPG in multiplayer!))");
                        break;
                    default:
                        f = false;
                        break;
                }
            }
        }
    }
}
