using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        /// <summary>
        /// Можна було реалізувати вибір через пізнє зв'язування
        /// Але тоді не зберігався б стан при переході між платформами
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool flag = true;
            var pc = new PC();
            var mobile = new Mobile();
            mobile.Start_stream += pc.HandleEvent;
            Platform[] platform = new Platform[] { pc, mobile, new X_BOX(), new PS() } ;
            String[] arr = new String[] { "PC", "Mobile", "X_Box", "PS", "Exit" };
            while (flag)
            {
                switch (Cout.Switch("Main Menu", arr))
                {
                    case "PC":
                        platform[0].runOS();
                        break;
                    case "Mobile":
                        platform[1].runOS();
                        break;
                    case "X_Box":
                        platform[2].runOS();
                        break;
                    case "PS":
                        platform[3].runOS();
                        break;
                    case "Exit":
                        platform = null;
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
            Cout.Message("Bye");
            Console.ReadKey();
        }
    }
}
