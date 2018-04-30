﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public class SpaceTimeLocation
    {
        #region FIELDS

        private string _commonName;
        private int _spaceTimeLocationID; // must be a unique value for each object
        private int _universalDate;
        private string _universalLocation;
        private string _description;
        private string _generalContents;
        private bool _accessable;
        private int _experience;
        private bool _fightChance;

        #endregion


        #region PROPERTIES

        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int SpaceTimeLocationID
        {
            get { return _spaceTimeLocationID; }
            set { _spaceTimeLocationID = value; }
        }

        public int UniversalDate
        {
            get { return _universalDate; }
            set { _universalDate = value; }
        }

        public string UniversalLocation
        {
            get { return _universalLocation; }
            set { _universalLocation = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public bool Accessible
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        public bool FightChance
        {
            get { return _fightChance; }
            set { _fightChance = value; }
        }


        #endregion

    }
}
