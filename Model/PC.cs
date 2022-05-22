using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class PC : Platform, Observer
    {
        private List<String> stream = new List<String>() { "Exit" };

        /// <summary>
        /// Метод для обробки події початку чи завершення трансляції з
        /// мобільного пристрою
        /// </summary>
        /// <param name="m"></param>
        /// <param name="a"></param>
        public void HandleEvent(Mobile m, About a)
        {
            this.stream.Add($"Stream: {a.what} {a.when}");
       }

        public PC(float ram = 16, double rom = 512, uint cpuCores = 6, float cpuFrequency = 4, float gpuMemory = 4, String os = "Windows")
        {
            this.RAM = ram;
            this.ROM = rom;
            this.CpuCores = cpuCores;
            this.CpuFrequency = cpuFrequency;
            this.GpuMemory = gpuMemory;
            this.Name = "PC";
            this.OS = os;

            this.games = new List<Game>();
            this.controllers = 1;
        }

        protected override void ConnectGamepad()
        {
            Cout.Message("Message", "You can't connect multiple gamepad to PC");
        }

        protected override void DisconnectGamepad()
        {
            Cout.Message("Message", "You can't connect multiple gamepad to PC");
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
            while (Cout.Switch("Streams", this.stream.ToArray()) != "Exit") {
                continue;
            }
        }
    }
}
