﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            Human,
            Elf,
            Dwarf
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _spaceTimeLocationID;
        private int _age;
        private RaceType _race;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int SpaceTimeLocationID
        {
            get { return _spaceTimeLocationID; }
            set { _spaceTimeLocationID = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int spaceTimeLocationID)
        {
            _name = name;
            _race = race;
            _spaceTimeLocationID = spaceTimeLocationID;
        }

        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return $"Hello, my name is {_name} and I am a {_race}";
        }

        public virtual string AdventureReasoning()
        {
            return $"I am currently not adventuring, and am a huge nerd";
        }

        #endregion
    }
}
