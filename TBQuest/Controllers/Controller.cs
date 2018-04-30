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
        private bool _battle;
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

                        //SpaceTimeLocation test = _gameUniverse.GetSpaceTimeLocationById(3);
                        //test.Accessible = true;
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
            _gamePlayer.Defense = 10;
            _gamePlayer.AttackPower = 5;
            _gamePlayer.BattleCooldown = 0;
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
            if (_gamePlayer.SpaceTimeLocationID == 3)
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.BattleMenu;
                _battle = true;
                Battle(3);
            }
            else
            {
                if (_currentLocation.FightChance == true)
                {
                    Random random = new Random();
                    int monster= 1;
                    if (random.Next(1, 100) > 50)
                    {
                        monster = 1;
                    }
                    else
                    {
                        monster = 2;
                    }
                     
                    int chance = random.Next(1, 3);
                    if (_gamePlayer.BattleCooldown == 0)
                    {
                        if (chance == 2)
                        {
                            _gamePlayer.BattleCooldown = 10;
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.BattleMenu;
                            _battle = true;
                            Battle(monster);
                        }
                    }
                    else
                    {
                        _gamePlayer.BattleCooldown -= 1;
                    }
                }
            }
            if (_gamePlayer.SpaceTimeLocationID == 1)
            {
                _gamePlayer.Health = 100;
            }
            if (_gamePlayer.Experience > 300)
            {
                SpaceTimeLocation test = _gameUniverse.GetSpaceTimeLocationById(3);
                test.Accessible = true;
            }
            if (_gamePlayer.Experience > 10000)
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.GameOverMenu;
                _gameConsoleView.DisplayGamePlayScreen("You beat the game, Congrats", "You really did it", ActionMenu.GameOverMenu, "");
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

                case ActionMenu.CurrentMenu.BattleMenu:
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.BattleMenu);
                    break;

                case ActionMenu.CurrentMenu.GameOverMenu:
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.GameOverMenu);
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
        private void Battle(int battleid)
        {
            Monster battleMonster = new Monster();
            battleMonster = _gameUniverse.GetMonsterById(battleid);
            
            _gameConsoleView.DisplayGamePlayScreen("Battle screen", Text.BattleStart(battleMonster), ActionMenu.BattleMenu, "");

            Random random = new Random();
            int chance;
            bool missed = false;
            bool monMissed = false;
            bool fled = false;
            int tempPlayerDef = 0;
            int tempMonDef = 0;
            
            int attack = 1;
            int monAttack = 1;
            int round = 1;
            int monHealth = battleMonster.Health;
            PlayerAction playerActionChoice = PlayerAction.None;
            ActionMenu.currentMenu = ActionMenu.CurrentMenu.BattleMenu;
            
            while (_battle)
            {
                if (monHealth <= 0)
                {
                    _battle = false;
                    _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                    break;
                }
                if (_gamePlayer.Health < 0)
                {
                    _battle = false;
                    _gameConsoleView.DisplayGamePlayScreen("Game Over", "Try harder next time, maybe?", ActionMenu.GameOverMenu, "");
                    playerActionChoice = GetNextPlayerAction();
                    Environment.Exit(1);
                    break;
                }

                switch (battleMonster.MonAttackMethod)
                {
                    case Monster.AttackMethod.Defensive:
                        if (round == 1)
                        {
                            round += 1;
                        }
                        else
                        {
                            round -= 1;
                            tempMonDef = 10;
                        }
                        break;
                    case Monster.AttackMethod.Offensive:
                        break;
                    case Monster.AttackMethod.Special:
                        break;
                    case Monster.AttackMethod.Boss:
                        break;
                    default:
                        break;
                }

                playerActionChoice = GetNextPlayerAction();
                switch (playerActionChoice)
                {
                    case PlayerAction.Attack:
                        chance = random.Next(1, 20);
                        chance += _gamePlayer.AttackPower;

                        if (monsterAttack(random, battleMonster, _gamePlayer.Defense))
                        {
                            monAttack = monsterDamage(random, battleMonster);
                            _gamePlayer.Health -= monAttack;
                            monMissed = false;
                        }
                        else
                        {
                            monMissed = true;
                        }

                        if (chance > battleMonster.Defense + tempMonDef)
                        {
                            attack = random.Next(1, 6);
                            attack += _gamePlayer.AttackPower;
                            monHealth -= attack;
                            tempMonDef = 0;
                            tempPlayerDef = 0;
                            missed = false;
                        }
                        else
                        {
                            tempMonDef = 0;
                            tempPlayerDef = 0;
                            missed = true;
                        }
                        _gameConsoleView.DisplayGamePlayScreen("Battle screen", Text.BattleAttack(battleMonster, _gamePlayer, round, missed, monMissed, attack, monAttack, monHealth), ActionMenu.BattleMenu, "");
                        break;
                    case PlayerAction.Defend:
                        tempPlayerDef = random.Next(2, 8);
                        if (monsterAttack(random, battleMonster, _gamePlayer.Defense + tempPlayerDef))
                        {
                            monAttack = monAttack = monsterDamage(random, battleMonster);
                            _gamePlayer.Health -= monAttack;
                            monMissed = false;
                        }
                        else
                        {
                            monMissed = true;
                        }
                        _gameConsoleView.DisplayGamePlayScreen("Battle screen", Text.BattleDefend(battleMonster, _gamePlayer,round, monMissed, monAttack, monHealth), ActionMenu.BattleMenu, "");
                        break;
                    case PlayerAction.UseItem:
                        break;
                    case PlayerAction.Flee:
                        chance = random.Next(1, 100);
                        if (chance >= 75)
                        {
                            _battle = false;
                            fled = true;
                            _gameConsoleView.DisplayGamePlayScreen("Escaped battle", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

                        }
                        else
                        {
                            _gameConsoleView.DisplayGamePlayScreen("Battle screen", Text.BattleFlee(battleMonster, _gamePlayer, round, monMissed, monAttack, monHealth), ActionMenu.BattleMenu, "");
                        }
                        break;
                    default:
                        break;
                }

                
            }
            if (!fled)
            {
                _gamePlayer.Experience += battleMonster.ExpValue;
            }
            ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;



        }
        private bool monsterAttack(Random random, Monster battleMonster, int defense)
        {
            int chance;
            chance = random.Next(1, 20) + battleMonster.AttackPower;
            if (chance > defense)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int monsterDamage(Random random, Monster battleMonster)
        {
            int damage = 0;
            switch (battleMonster.MonAttackMethod)
            {
                case Monster.AttackMethod.Defensive:
                    damage = random.Next(1, 4) + battleMonster.AttackPower;
                    break;
                case Monster.AttackMethod.Offensive:
                    damage = random.Next(1, 8) + battleMonster.AttackPower;
                    break;
                case Monster.AttackMethod.Special:
                    damage = random.Next(1, 1) + battleMonster.AttackPower;
                    break;
                case Monster.AttackMethod.Boss:
                    damage = random.Next(1, 10) + battleMonster.AttackPower;
                    break;
                default:
                    break;
            }


            return damage;
        }
        #endregion
    }
}
