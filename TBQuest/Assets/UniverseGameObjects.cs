using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static partial class UniverseObjects
    {
        public static List<GameObject> GameObjects = new List<GameObject>()
        {
            new PlayerObject
            {
                Id = 1,
                Name = "Bag of Gold",
                SpaceTimeLocationId = 2,
                Description = "A small leather pouch filled with 9 gold coins.",
                Type = PlayerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new PlayerObject
            {
                Id = 2,
                Name = "Ruby",
                SpaceTimeLocationId = 3,
                Description = "A bright red jewel",
                Type = PlayerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = false
            },

            new PlayerObject
            {
                Id = 3,
                Name = "Red Vial",
                SpaceTimeLocationId = 1,
                Description = "A small red vial, a small amount of liquid can be seen within with flakes of gold.",
                PickUpMessage = "You pocket the Vial, you might be able to use this if things get tough.",
                Type = PlayerObjectType.Medicine,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },



            new PlayerObject
            {
                Id = 4,
                Name = "Map",
                SpaceTimeLocationId = 0,
                Description =
                    "A map handed to you by your employer",
                Type = PlayerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new PlayerObject
            {
                Id = 5,
                Name = "Hardy rations",
                SpaceTimeLocationId = 0,
                Description =
                    "Hard to eat, but gets the job done",
                Type = PlayerObjectType.Food,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new PlayerObject
            {
                Id = 6,
                Name = "Gjolden Key",
                SpaceTimeLocationId = 2,
                Description = "A small Gjolden key that probably goes to a Gjolden Lock.",
                PickUpMessage = "If only I knew where this Gjolden key went to.",
                Type = PlayerObjectType.Key,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

        };
    }
}
