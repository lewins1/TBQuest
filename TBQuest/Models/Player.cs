using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES

        public enum PlayerClass
        {
            Fighter,
            Cleric,
            Mage
        }

        #endregion

        #region FIELDS

        private string _homeTown;

        private bool _playerRecruited;

        private PlayerClass _class;

        private int _experience;

        private int _health;

        private List<int> _spaceTimeLocationsVisited;
        #endregion


        #region PROPERTIES

        public string HomeTown
        {
            get { return _homeTown; }
            set { _homeTown = value; }
        }

        public bool PlayerRecruited
        {
            get { return _playerRecruited; }
            set { _playerRecruited = value; }
        }

        public PlayerClass Class
        {
            get { return _class; }
            set { _class = value; }
        }

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public List<int> SpaceTimeLocationsVisited
        {
            get { return _spaceTimeLocationsVisited; }
            set { _spaceTimeLocationsVisited = value; }
        }
        #endregion


        #region CONSTRUCTORS

        public Player()
        {
            _spaceTimeLocationsVisited = new List<int>();
        }

        public Player(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {
            _spaceTimeLocationsVisited = new List<int>();
        }

        #endregion


        #region METHODS

        public override string Greeting()
        {
            return $"Hello, my name is {base.Name}, I am a {base.Race}, and I am from {_homeTown}.";
        }

        public override string AdventureReasoning()
        {
            switch (_playerRecruited)
            {
                case true:
                    return "I was recruited to be a part of this adventure by G R E G";
                case false:
                    return "I came to this town by my own, to follow my own stuffs";
                default:
                    return base.AdventureReasoning();
            }

        }

        public bool HasVisited(int _spaceTimeLocationID)
        {
            if (SpaceTimeLocationsVisited.Contains(_spaceTimeLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
