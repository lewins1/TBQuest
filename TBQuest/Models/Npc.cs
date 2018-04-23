using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public abstract class Npc : Character
    {
        public abstract int Id { get; set; }
        public abstract string Description { get; set; }
    }
}
