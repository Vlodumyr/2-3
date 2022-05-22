using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{/// <summary>
/// Інтерфейс спостерігача
/// </summary>
    interface Observer
    {
        void HandleEvent(Mobile m, About e);
    }
}
