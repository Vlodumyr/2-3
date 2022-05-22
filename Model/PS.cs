using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class PS : Platform
    {
        public PS(float ram = 16, double rom = 512, uint cpuCores = 8, float cpuFrequency = 4, float gpuMemory = 10, String os = "Console")
        {
            this.RAM = ram;
            this.ROM = rom;
            this.CpuCores = cpuCores;
            this.CpuFrequency = cpuFrequency;
            this.GpuMemory = gpuMemory;
            this.Name = "PS";
            this.OS = os;

            this.games = new List<Game>();
            this.controllers = 1;
        }

        protected override void ConnectGamepad()
        {
            if (this.controllers + 1 < 4)
                this.controllers += 1;
            Cout.Message("Gamepad", $"{this.controllers} connected");
        }

        protected override void DisconnectGamepad()
        {
            if (this.controllers - 1 >= 1)
                this.controllers -= 1;
            Cout.Message("Gamepad", $"{this.controllers} connected");
        }

        protected override void PlayGame()
        {
            List<String> list = new List<string>();
            list.Add("Exit");
            foreach (var i in this.games)
                list.Add(i.Genre);
            string choice = Cout.Switch("Games", list.ToArray());
            foreach (Game g in this.games)
                if (g.Genre == choice)
                    g.Play(this.controllers);
        }

        protected override void StartStream()
        {
            Cout.Message("Message", "You can stream only on mobile");
        }

        protected override void StopStream()
        {
            Cout.Message("Message", "You can stream only on mobile");
        }

        protected override void WatchStream()
        {
            Cout.Message("Message", "You can watch stream only on PC");
        }
    }
}
