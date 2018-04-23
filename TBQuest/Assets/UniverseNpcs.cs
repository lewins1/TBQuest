using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static partial class UniverseObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                Id = 2,
                Name = "Inn keeper",
                SpaceTimeLocationID = 1,
                Description = "The lady keeping this place afloat. Constantly checking people in, waiting tables, and yelling orders to the back.",
                Messages = new List<string>
                {
                    "We have a few rooms left upstairs, can I get your name please?",
                    "ONE MOMENT PLEASE!",
                    "If you're here for food, take a seat and I'll be right over."
                }
            },
        };
    }
}
