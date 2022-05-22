using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    abstract class Game
    {
        protected List<String> saves;

        protected String id;
        protected String nick;

        public String[] OS
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
        public String Genre
        {
            get;
            protected set;
        }
        public double Rom()
        {
            return this.ROM;
        }

        public abstract void Play(int controllers);
        public bool CompareRequirements(String os, uint cores, float f, float m, double rom)
        {
            if (Array.IndexOf(this.OS, os) == -1)
                return false;
            if (this.CpuCores > cores)
                return false;
            if (this.CpuFrequency > f)
                return false;
            if (this.GpuMemory > m)
                return false;
            if (this.ROM > rom)
                return false;
            return true;
        }

        protected void Login()
        {
            this.nick = Cout.Input("Set your nickname:");
        }
    }
}
