using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class About : EventArgs
    {
        public string when
        {
            set;
            get;
        }
        public string what
        {
            set;
            get;
        }
    }
}
