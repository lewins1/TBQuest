using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private bool _playingGame;
        private Universe _gameUniverse;
        private SpaceTimeLocation _currentLocation;
        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            _playingGame = true;

            PlayerObject playerObject;

            foreach (GameObject gameObject in _gameUniverse.GameObjects)
            {
                if (gameObject is PlayerObject)
                {
                    playerObject = gameObject as PlayerObject;
                    playerObject.ObjectAddedToInventory += HandleObjectAddedToInventory;
                }
            }
            Console.CursorVisible = false;
        }
        private void HandleObjectAddedToInventory(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(PlayerObject))
            {
                PlayerObject playerObject = gameObject as PlayerObject;
                switch (playerObject.Type)
                {
                    case PlayerObjectType.Food:
                        break;
                    case PlayerObjectType.Medicine:
                        break;
                    case PlayerObjectType.Weapon:
                        break;
                    case PlayerObjectType.Treasure:
                        break;
                    case PlayerObjectType.Information:
                        break;
                    case PlayerObjectType.Key:

                        SpaceTimeLocation test = _gameUniverse.GetSpaceTimeLocationById(3);
                        test.Accessible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission player
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gamePlayer.SpaceTimeLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {

                UpdateGameStatus();
                //
                // get next game action from player
                //
                playerActionChoice = GetNextPlayerAction();

                //
                // choose an action based on the player's menu choice
                //
                switch (playerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case PlayerAction.Travel:
                        TravelAction();
                        //_gamePlayer.SpaceTimeLocationID = _gameConsoleView.DisplayGetNextSpaceTimeLocation();
                        //_currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gamePlayer.SpaceTimeLocationID);
                        //_gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.PlayerLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case PlayerAction.LookAt:
                        LookAtAction();
                        break;

                    case PlayerAction.PickUp:
                        PickUpAction();
                        break;

                    case PlayerAction.PutDown:
                        PutDownAction();
                        break;

                    case PlayerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case PlayerAction.TalkTo:
                        TalkToAction();
                        break;


                    case PlayerAction.ListSpaceTimeLocations:
                        _gameConsoleView.DisplayListOfSpaceTimeLocations();
                        break;

                    case PlayerAction.ListNonPlayerCharacters:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;

                    case PlayerAction.PlayerMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Player Menu", "Select an operation from the menu.", ActionMenu.PlayerMenu, "");
                        break;

                    case PlayerAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu.", ActionMenu.ObjectMenu, "");
                        break;

                    case PlayerAction.NonplayerCharacterMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
                        break;

                    case PlayerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }
        private void TravelAction()
        {
            _gamePlayer.SpaceTimeLocationID = _gameConsoleView.DisplayGetNextSpaceTimeLocation();
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gamePlayer.SpaceTimeLocationID);

            _gameConsoleView.DisplayCurrentLocationInfo();
        }

        private void LookAtAction()
        {
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            if (gameObjectToLookAtId != 0)
            {
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        private void PickUpAction()
        {

            int playerObjectToPickUpId = _gameConsoleView.DisplayGetplayerObjectToPickUp();

            if (playerObjectToPickUpId != 0)
            {
                PlayerObject playerObject = _gameUniverse.GetGameObjectById(playerObjectToPickUpId) as PlayerObject;

                playerObject.SpaceTimeLocationId = 0;

                _gameConsoleView.DisplayConfirmPlayerObjectAddedToInventory(playerObject);
            }
        }

        private void PutDownAction()
        {

            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            PlayerObject playerObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as PlayerObject;

            playerObject.SpaceTimeLocationId = _gamePlayer.SpaceTimeLocationID;

            _gameConsoleView.DisplayConfirmPlayerObjectRemovedFromInventory(playerObject);

        }

        private void InitializeMission()
        {
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            _gamePlayer.Name = player.Name;
            _gamePlayer.Age = player.Age;
            _gamePlayer.Race = player.Race;
            _gamePlayer.HomeTown = player.HomeTown;
            _gamePlayer.SpaceTimeLocationID = 1;
            _gamePlayer.PlayerRecruited = player.PlayerRecruited;

            _gamePlayer.Experience = 0;
            _gamePlayer.Health = 100;

        }
        private void UpdateGameStatus()
        {
            if (!_gamePlayer.HasVisited(_currentLocation.SpaceTimeLocationID))
            {
                _gamePlayer.SpaceTimeLocationsVisited.Add(_currentLocation.SpaceTimeLocationID);

                _gamePlayer.Experience += _currentLocation.Experience;
            }
        }
        private PlayerAction GetNextPlayerAction()
        {
            PlayerAction PlayerActionChoice = PlayerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NpcMenu:
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;

                case ActionMenu.CurrentMenu.PlayerMenu:
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.PlayerMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                default:
                    break;
            }

            return PlayerActionChoice;
        }

        private void TalkToAction()
        {

            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            if (npcToTalkToId != 0)
            {

                Npc npc = _gameUniverse.GetNpcById(npcToTalkToId);

                _gameConsoleView.DisplayTalkTo(npc);
            }
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
        #endregion
    }
}
