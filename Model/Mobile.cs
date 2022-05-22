using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Mobile : Platform
    {
        public event NotifyObserver Start_stream;
        /// <summary>
        /// Делегат методу для обробки подіїї початку та закінчення трансляціїї
        /// </summary>
        /// <param name="m"></param>
        /// <param name="e"></param>
        public delegate void NotifyObserver(Mobile m, About e);

        public Mobile(float ram = 4 , double rom = 64, uint cpuCores = 8, float cpuFrequency = 2, float gpuMemory = 2, String os = "Android")
        {
            this.RAM = ram;
            this.ROM = rom;
            this.CpuCores = cpuCores;
            this.CpuFrequency = cpuFrequency;
            this.GpuMemory = gpuMemory;
            this.Name = "Mobile";
            this.OS = os;

            this.games = new List<Game>();
            this.controllers = 1;
        }

        protected override void ConnectGamepad()
        {
            Cout.Message("Message", "You can't connect multiple gamepad to Mobile");
        }

        protected override void DisconnectGamepad()
        {
            Cout.Message("Message", "You can't connect multiple gamepad to Mobile`");
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
            About a = new About();
            a.when = DateTime.Now.ToString();
            a.what = "Start";
            Start_stream(this, a);
            Cout.Message("Stream", "Started");
        }

        protected override void StopStream()
        {
            About a = new About();
            a.when = DateTime.Now.ToString();
            a.what = "Stop";
            Start_stream(this, a);
            Cout.Message("Stream", "Stopped");
        }

        protected override void WatchStream()
        {
            Cout.Message("Message", "You can't watch stream on Mobile");
        }
    }
}
