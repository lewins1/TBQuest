using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "The Project Project" };
        public static List<string> FooterText = new List<string>() { "I have no idea what to call this studio Productions, 2018" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You have been hired by the Silver Swords " +
            "to investigate a small town that has been under " +
            "the attack of a few dark entities. Your mission is to " +
            "find out what is causing these attacks and vanquish it.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your adventure begins now.\n" +
            " \n" +
            "\tYour first task will be to fill out the usual paper work required for these jobs.\n" +
            " \n" +
            "\tPress any key to begin the Paperwork procedure.\n";

            return messageBoxText;
        }

        public static string CurrentLocationInfo(SpaceTimeLocation spaceTimeLocation)
        {
            string messageBoxText =
                $"Current Location: {spaceTimeLocation.CommonName}\n" +
                " \n" +
                spaceTimeLocation.Description;

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin your adventure we need a basic amount of information.\n" +
                " \n" +
                "You will be prompted for the required information. Please write the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerName()
        {
            string messageBoxText =
                "Enter your name adventurer.\n" +
                " \n" +
                "Please use the name you wish to be referred during your travels.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerAge(string name)
        {
            string messageBoxText =
                $"Ah, right I remember you, {name}, skilled adventurer.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Have to make sure you aren't under the required age to adventure.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerRace(Player gamePlayer)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, it will be important for us to know your race on this adventure.\n" +
                " \n" +
                "Write your race below.\n" +
                " \n" +
                "Please use the terms us common folk can understand." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                raceList += $"\t{race}\n";
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"Very good then {gamePlayer.Name}.\n" +
                " \n" +
                "It appears we have all the necessary information. You will find it" +
                " written below.\n" +
                " \n" +
                $"\tContractee Name: {gamePlayer.Name}\n" +
                $"\tAge: {gamePlayer.Age}\n" +
                $"\tRace: {gamePlayer.Race}\n" +
                $"\tHome Town: {gamePlayer.HomeTown}\n" +
                " \n" +
                "Press any key to begin your adventure.";

            return messageBoxText;
        }

        #endregion

        #region Initialize Home Planet Text

        public static string InitializeMissionGetPlayerHomePlanet(string name)
        {
            string messageBoxText =
                $"{name}, in case of your untimely demise, it may be necessary to return your remains to your hometown.\n" +
                "\n" +
                "Enter your home town below. \n" +
                " \n" +
                "please write in common, I don't have a lick of elvish or orcish.";
            return messageBoxText;
        }

        #endregion

        #region Initialize Reasoning

        public static string InitializeMissionGetPlayerReasoning(string name)
        {
            string messageBoxText =
                $"{name}, did you choose to come on this adventure due to financial obligations?\n" +
                "\n" +
                "Please enter Yes or No \n" +
                " \n" +
                "";
            return messageBoxText;
        }

        public static string InitialLocationInfo()
        {
            string messageBoxText =
            "You are now in the town of Phandalin " +
            "despite the recent murders and missing persons reports, the town seems " +
            "as busy as any port town would be. Most buildings and shops seem open and " +
            "ready for business, all besides the blacksmith's shop.\n" +
            " \n" +
            "\tChoose what you wish to do next.\n";

            return messageBoxText;
        }


        #endregion

        #endregion



        #region MAIN MENU ACTION SCREENS

        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tGeneral Information:\n" +
                $"\tPlayer Name: {gamePlayer.Name}\n" +
                $"\tPlayer Age: {gamePlayer.Age}\n" +
                $"\tPlayer Race: {gamePlayer.Race}\n" +
                $"\tPlayer Home Town: {gamePlayer.HomeTown}\n" +
                $"\tPlayer Greeting: {gamePlayer.Greeting()}\n" +
                $"\t\n" +
                $"\tPlayer Specific Information:\n" +
                $"\tPlayer's reasoning for accepting quest:\n" +
                $"\t{gamePlayer.AdventureReasoning()}\n" +
                $"\t\n" +
                " \n";

            return messageBoxText;
        }

        #endregion

        public static List<string> StatusBox(Player player)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Player's Age: {player.Age}\n");
            statusBoxText.Add($"Player's Health: {player.Health}\n");
            statusBoxText.Add($"Player's Experience: {player.Experience}\n");

            return statusBoxText;
        }
        public static string LookAround(SpaceTimeLocation spaceTimeLocation)
        {
            string messageBoxText =
                   $"Current Location: {spaceTimeLocation.CommonName}\n" +
                   spaceTimeLocation.GeneralContents;
            return messageBoxText;
        }
        public static string Travel(Player gamePlayer, List<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, where are you heading off to?\n" +
                " \n" +
                "Enter the ID number of the location from the table below.\n" +
                " \n" +


                "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";


            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                if (spaceTimeLocation.SpaceTimeLocationID != gamePlayer.SpaceTimeLocationID)
                {
                    spaceTimeLocationList +=
                        $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                        $"{spaceTimeLocation.CommonName}".PadRight(30) +
                        $"{spaceTimeLocation.Accessible}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }
        public static string VisitedLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                "Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
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
        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
                gameObject.Description + " \n" +
                " \n";

            if (gameObject is PlayerObject)
            {
                PlayerObject playerObject = gameObject as PlayerObject;

                messageBoxText += $"The {playerObject.Name} has a value of {playerObject.Value} and ";

                if (playerObject.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else
            {
                messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
            }

            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<PlayerObject> inventory)
        {
            string messageBoxText = "";

            messageBoxText =
            "ID".PadRight(10) +
            "Name".PadRight(30) +
            "Type".PadRight(10) +
            "\n" +
            "---".PadRight(10) +
            "----------------------------".PadRight(30) +
            "----------------------".PadRight(10) +
            "\n";

            string inventoryObjectRows = null;
            foreach (PlayerObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                    $"{inventoryObject.Id}".PadRight(10) +
                    $"{inventoryObject.Name}".PadRight(30) +
                    $"{inventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }
        public static string ListSpaceTimeLocationObjectsBySpaceTimeLocation(int spaceTimeLocationId, IEnumerable<GameObject> gameObjects)
        {

            List<SpaceTimeLocationObject> spaceTimeLocationObjects = new List<SpaceTimeLocationObject>();
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is PlayerObject &&
                    gameObject.SpaceTimeLocationId == spaceTimeLocationId)
                {
                    spaceTimeLocationObjects.Add(gameObject as SpaceTimeLocationObject);
                }
            }


            string messageBoxText =
                "Location Objects\n" +
                " \n" +

                "ID".PadRight(10) + "Name".PadRight(30) + "Type".PadRight(20) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) +
                "----------------------".PadRight(20) + "\n";

            string spaceTimeLocationObjectRows = null;
            foreach (SpaceTimeLocationObject spaceTimeLocationObject in spaceTimeLocationObjects)
            {
                spaceTimeLocationObjectRows +=
                    $"{spaceTimeLocationObject.Id}".PadRight(10) +
                    $"{spaceTimeLocationObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += spaceTimeLocationObjectRows;

            return messageBoxText;
        }
        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {

            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }
        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {

            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Space-Time Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.SpaceTimeLocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }
        public static string ListAllSpaceTimeLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                "Locations\n" +
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

        public static string ListAllNpcObjects(IEnumerable<Npc> npcObjects)
        {

            string messageBoxText =
                "NPC Objects\n" +
                " \n" +
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            string npcObjectRows = null;
            foreach (Npc npcObject in npcObjects)
            {
                npcObjectRows +=
                    $"{npcObject.Id}".PadRight(10) +
                    $"{npcObject.Name}".PadRight(30) +
                    $"{npcObject.SpaceTimeLocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += npcObjectRows;

            return messageBoxText;
        }
        public static string NpcsChooseList(IEnumerable<Npc> npcs)
        {

            string messageBoxText =
                "NPCs\n" +
                " \n" +
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            string npcRows = null;
            foreach (Npc npc in npcs)
            {
                npcRows +=
                    $"{npc.Id}".PadRight(10) +
                    $"{npc.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += npcRows;

            return messageBoxText;
        }
        public static string BattleAttack(Monster battleMonster, Player player, int round, bool missed, bool monMissed, int attack, int monAttack, int monHealth)
        {
            string messageBoxText =
                "You are currently in a battle with " + battleMonster.Name + "\n" +
                "You currently have " + player.Health + " HP" + "\n" +
                "The Monster currently has " + monHealth + "HP" + "\n";
            if (missed)
            {
                messageBoxText += "You attempt to strike the monster, but fail" +  "\n"; ;
            }
            else
            {
                messageBoxText += "You successfully strike the monster for " + attack + " points of damage" + "\n"; ;
            }
            if (battleMonster.MonAttackMethod == Monster.AttackMethod.Defensive)
            {
                if (round == 1)
                {
                    if (monMissed)
                    {
                        messageBoxText += "The monster attempts to strike you, but fails" + "\n"; 
                    }
                    else
                    {
                        messageBoxText += "The monster successfully strikes you for " + monAttack + " points of damage" + "\n"; ;
                    }
                }
                else
                {
                    messageBoxText += "The monster defends itself" + "\n"; 
                }
            }
            else
            {
                if (monMissed)
                {
                    messageBoxText += "The monster attempts to strike you, but fails" + "\n"; ;
                }
                else
                {
                    messageBoxText += "The monster successfully strikes you for " + monAttack + " points of damage" + "\n"; ;
                }
            }
            


            return messageBoxText;
        }
        public static string BattleDefend(Monster battleMonster, Player player, int round, bool monMissed, int monAttack, int monHealth)
        {
            string messageBoxText =
                "You are currently in a battle with " + battleMonster.Name + "\n" +
                "You currently have " + player.Health + " HP" + "\n" +
                "The Monster currently has " + monHealth + "HP" + "\n" +
                 "You take a defensive stance, preparing yourself for the " + battleMonster.Name + "'s attack" + "\n";
            if (battleMonster.MonAttackMethod == Monster.AttackMethod.Defensive)
            {
                if (round == 1)
                {
                    if (monMissed)
                    {
                        messageBoxText += "You successfully block the " + battleMonster.Name + "'s attack.";
                    }
                    else
                    {
                        messageBoxText += "The " + battleMonster.Name + " breaks through your defenses, dealing " + monAttack + " points of damage";
                    }
                }
                else
                {
                    messageBoxText += "The monster defends itself" + "\n";
                }
            }
            else
            {
                if (monMissed)
                {
                    messageBoxText += "You successfully block the " + battleMonster.Name + "'s attack.";
                }
                else
                {
                    messageBoxText += "The " + battleMonster.Name + " breaks through your defenses, dealing " + monAttack + " points of damage";
                }
            }
            return messageBoxText;
        }
        public static string BattleFlee(Monster battleMonster, Player player, int round, bool monMissed, int monAttack, int monHealth)
        {
            string messageBoxText =
                "You are currently in a battle with " + battleMonster.Name + "\n" +
                "You currently have " + player.Health + " HP" + "\n" +
                "The Monster currently has " + monHealth + "HP" + "\n" +
                 "You Attempt to flee from the " + battleMonster.Name + ", but you fail." + "\n";
            if (battleMonster.MonAttackMethod == Monster.AttackMethod.Defensive)
            {
                if (round == 1)
                {
                    if (monMissed)
                    {
                        messageBoxText += "The monster attempts to strike you, but fails" + "\n";
                    }
                    else
                    {
                        messageBoxText += "The monster successfully strikes you for " + monAttack + " points of damage" + "\n"; ;
                    }
                }
                else
                {
                    messageBoxText += "The monster defends itself" + "\n";
                }
            }
            else
            {
                if (monMissed)
                {
                    messageBoxText += "The monster attempts to strike you, but fails" + "\n"; ;
                }
                else
                {
                    messageBoxText += "The monster successfully strikes you for " + monAttack + " points of damage" + "\n"; ;
                }
            }
            return messageBoxText;
        }

        public static string BattleStart(Monster battleMonster)
        {
            string messageBoxText =
                "You start battle with a " + battleMonster.Name;
            return messageBoxText;
        }
    }
}
