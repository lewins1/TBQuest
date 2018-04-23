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
                Experience = 10
            },
            new SpaceTimeLocation
            {
                CommonName = "2",
                SpaceTimeLocationID = 2,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "Test 2" +
                    "" +
                    "",
                GeneralContents = "" +
                    "" +
                    "",
                Accessible = true,
                Experience = 10
            },
            new SpaceTimeLocation
            {
                CommonName = "3",
                SpaceTimeLocationID = 3,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "Test 3" +
                    "" +
                    "",
                GeneralContents = "" +
                    "" +
                    "",
                Accessible = false,
                Experience = 10
            },
            new SpaceTimeLocation
            {
                CommonName = "4",
                SpaceTimeLocationID = 4,
                UniversalDate = 999999,
                UniversalLocation = "",
                Description = "Test 4" +
                    "" +
                    "",
                GeneralContents = "" +
                    "" +
                    "",
                Accessible = true,
                Experience = 10
            },
        };
    }
}
