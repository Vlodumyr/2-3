using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{   /// <summary>
    /// Використані абстрактний клас а не інтерфейс бо він містить поля і реалізацію 
    /// для більшості методів
    /// </summary>
    abstract class Platform
    {
        /// <summary>
        /// Змінні характеристики системи
        /// </summary>
        protected List<Game> games;
        protected int controllers;

        /// <summary>
        /// Характеристики пристрою
        /// </summary>
        public String OS
        {
            get;
            protected set;
        }
        public String Name
        {
            get;
            protected set;
        }
        public float RAM
        {
            get;
            protected set;
        }
        public double ROM
        {
            get;
            protected set;
        }
        public double UsedRom
        {
            get;
            protected set;
        }
        public uint CpuCores
        {
            get;
            protected set;
        }
        public float CpuFrequency
        {
            get;
            protected set;
        }
        public float GpuMemory
        {
            get;
            protected set;
        }

        /// <summary>
        /// Вхідна точка для запуску пристрою
        /// Тут вибирається яка функція буде виконуватись
        /// </summary>
        public void runOS()
        {
            while (true)
            {
                switch (Cout.Switch(this.Name, new string[] { "Install game", "Deinstall game", "Play game", "Connect gamepad", "Disconnect gamepad", "Start stream", "Stop Stream", "Watch stream", "System props", "Exit" }))
                {
                    case "Install game":
                        InstallGame();
                        break;
                    case "Deinstall game":
                        DeinstallGame();
                        break;
                    case "Play game":
                        PlayGame();
                        break;
                    case "Connect gamepad":
                        ConnectGamepad();
                        break;
                    case "Disconnect gamepad":
                        DisconnectGamepad();
                        break;
                    case "Start stream":
                        StartStream();
                        break;
                    case "Stop Stream":
                        StopStream();
                        break;
                    case "Watch stream":
                        WatchStream();
                        break;
                    case "System props":
                        SystemProps();
                        break;
                    case "Exit":
                        return;
                    default:
                        break;
                }
            }
        }

        protected void InstallGame()
        {
            var arr = new String[] { "RPG", "Strategy", "Adventure" };
            switch (Cout.Switch("Games", arr))
            {
                case "RPG":
                    var f = false;
                    foreach (var i in this.games)
                        if (i.Genre == "RPG")
                        {
                            Cout.Message("Message", "Already installed");
                            f = true;
                            break;
                        }
                    if (f)
                        break;
                    Game rpg = new RPG();
                    if (CompareRequirements(rpg))
                    {
                        LoadInStorage(rpg);
                        Cout.Message("Installed", "RPG");
                    }
                    else
                        Cout.Message("Message", "Requirements don't match");
                    break;
                case "Strategy":
                    f = false;
                    foreach (var i in this.games)
                        if (i.Genre == "Strategy")
                        {
                            Cout.Message("Message", "Already installed");
                            f = true;
                            break;
                        }
                    if (f)
                        break;
                    Game strategy = new Strategy();
                    if (CompareRequirements(strategy))
                    {
                        LoadInStorage(strategy);
                        Cout.Message("Installed", "Strategy");
                    }
                    else
                        Cout.Message("Message", "Requirements don't match");
                    break;
                case "Adventure":
                    f = false;
                    foreach (var i in this.games)
                        if (i.Genre == "Adventure")
                        {
                            Cout.Message("Message", "Already installed");
                            f = true;
                            break;
                        }
                    if (f)
                        break;
                    Game adventure = new Adventure();
                    if (CompareRequirements(adventure))
                    {
                        LoadInStorage(adventure);
                        Cout.Message("Installed", "Adventure");
                    }
                    else
                        Cout.Message("Message", "Requirements don't match");
                    break;
                default:
                    break;
            }
        }
        protected bool CompareRequirements(Game game)
        {
            return game.CompareRequirements(this.OS, this.CpuCores, this.CpuFrequency, this.GpuMemory, this.ROM - this.UsedRom);
        }
        protected void LoadInStorage(Game game)
        {
            this.UsedRom += game.Rom();
            this.games.Add(game);
        }

        protected void DeinstallGame()
        {
            List<String> lst = new List<String>();
            foreach (var i in this.games)
                lst.Add(i.Genre);
            switch (Cout.Switch("Games", lst.ToArray()))
            {
                case "RPG":
                    var newList1 = new List<Game>();
                    foreach (var i in this.games) {
                        if (i.Genre != "RPG")
                        {
                            newList1.Add(i);
                        }
                        else
                        {
                            this.UsedRom -= i.Rom();
                        }
                    }
                    this.games.Clear();
                    this.games = newList1;
                    Cout.Message("Message", "Deleted");
                    break;
                case "Strategy":
                    var newList2 = new List<Game>();
                    foreach (var i in this.games)
                    {
                        if (i.Genre != "Strategy")
                        {
                            newList2.Add(i);
                        }
                        else
                        {
                            this.UsedRom -= i.Rom();
                        }
                    }
                    this.games.Clear();
                    this.games = newList2;
                    Cout.Message("Message", "Deleted");
                    break;
                case "Adventure":
                    var newList = new List<Game>();
                    foreach (var i in this.games)
                    {
                        if (i.Genre != "Adventure")
                        {
                            newList.Add(i);
                        }
                        else
                        {
                            this.UsedRom -= i.Rom();
                        }
                    }
                    this.games.Clear();
                    this.games = newList;
                    Cout.Message("Message", "Deleted");
                    break;
                default:
                    break;
            }
        }

        protected abstract void PlayGame();

        protected void SystemProps()
        {
            Cout.Message("System", $"RAM: {this.RAM}{Environment.NewLine}ROM: {this.ROM}{Environment.NewLine}CPUCores: {this.CpuCores}{Environment.NewLine}CPUFrequency: {this.CpuFrequency}{Environment.NewLine}GPUMemory: {this.GpuMemory}{Environment.NewLine}UsedRom: {this.UsedRom}{Environment.NewLine}");
        }

        protected abstract void ConnectGamepad();
        protected abstract void DisconnectGamepad();

        protected abstract void StartStream();
        protected abstract void StopStream();
        protected abstract void WatchStream();
    }
}
