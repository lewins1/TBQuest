using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static partial class UniverseObjects
    {
        public static string ListSpaceTimeLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                "Space-Time Locations\n" +
                " \n" +

                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                spaceTimeLocationList +=
                    $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                    $"{spaceTimeLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }
            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }

        public static List<SpaceTimeLocation> SpaceTimeLocations = new List<SpaceTimeLocation>()
        {

            new SpaceTimeLocation
            {
                CommonName = "Inn",
                SpaceTimeLocationID = 1,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "The staple of any small town settlement." +
                    "A place to lay your head when adventures get too tough, and " +
                    "a long rest is always available of a small price.\n",
                GeneralContents = "Many patrons sit in the lobby bar type area " +
                    ", but hidden upstairs there is bound to be more in the multiple rooms they " +
                    "rent out to the adventurers and any other passersby. \n",
                Accessible = true,
                Experience = 10,
                FightChance = false
            },
            new SpaceTimeLocation
            {
                CommonName = "Market",
                SpaceTimeLocationID = 2,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "The market bazar of this town. Locals and travelers " +
                    "selling their wares out of carts and stands. Anything not found " +
                    "in the actual shops can be found here.",
                GeneralContents = "Most of the town's produce can be purchased here. As well" +
                    " as any specialty goods that come and go as travelers sell off all their " +
                    "wares and procede to gather more or move onto the next town.",
                Accessible = true,
                Experience = 10,
                FightChance = false
            },
            new SpaceTimeLocation
            {
                CommonName = "Blacksmith's shop",
                SpaceTimeLocationID = 3,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "Having finally found a way into the blacksmith's shop, you enter " +
                    "to see what you can find. It is very dusty and seems like it hasn't been used" +
                    " in ages.",
                GeneralContents = "The building feels cold, and you can't help but feel like there is " +
                    "always something behind you. Watching you. Waiting for it's time to strike and " +
                    "add you to it's sadistic collection.",
                Accessible = false,
                Experience = 10,
                FightChance = false
            },
            new SpaceTimeLocation
            {
                CommonName = "Docks",
                SpaceTimeLocationID = 4,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "Where most of the incoming traveler's come by. Strangely most of " +
                    "the people coming by the water aren't attacked. Seems like only the outer plains" +
                    "and areas outside of the city being attacked. Maybe they don't like water?",
                GeneralContents = "Boats of all sizing tied to the docks, coming in and out. Some local" +
                    "fisher boats, while some are travelers who come to sell their wares. All report to the" +
                    "harbor master for paperwork and other talks",
                Accessible = true,
                Experience = 10,
                FightChance = false
            },
            new SpaceTimeLocation
            {
                CommonName = "Plains",
                SpaceTimeLocationID = 5,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "The plains right outside of Phandalin." +
                    "This area seems like it has been abandoned. Not many guards are well enough equiped to " +
                    "handle the monsters that have been appearing out here in the outters of town.",
                GeneralContents = "Lush green grass is everywhere. Not many farmhouses are still maintained." +
                    "Many farmers have fled into the city to try to gain some shelter from whatever is causing these" +
                    "beasts that appear in the night and attack anyone within their reach.",
                Accessible = true,
                Experience = 10,
                FightChance = true
            },

            new SpaceTimeLocation
            {
                CommonName = "Cave",
                SpaceTimeLocationID = 6,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "A cave, not much can be said about it other than the damp smell and the obvious" +
                    "indencations of bats and other rodents." +
                    "",
                GeneralContents = "A very damp and bad smelling cave. Super spooky" +
                    "" +
                    "",
                Accessible = true,
                Experience = 10,
                FightChance = true
            },
        };
    }
}
