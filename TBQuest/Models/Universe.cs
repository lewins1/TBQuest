using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public class Universe
    {
        #region propf   
        private List<SpaceTimeLocation> _spaceTimeLocations;
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;

        public List<SpaceTimeLocation> SpaceTimeLocations
        {
            get { return _spaceTimeLocations; }
            set { _spaceTimeLocations = value; }
        }
        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }
        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }
        #endregion

        #region Constructor

        public Universe()
        {
            IntializeUniverse();
        }

        #endregion
        private void IntializeUniverse()
        {
            _spaceTimeLocations = UniverseObjects.SpaceTimeLocations;
            _gameObjects = UniverseObjects.GameObjects;
            _npcs = UniverseObjects.Npcs;
        }

        #region Methods


        public bool IsValidSpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<int> spaceTimeLocationIds = new List<int>();

            //
            // create a list of space-time location ids
            //
            foreach (SpaceTimeLocation stl in _spaceTimeLocations)
            {
                spaceTimeLocationIds.Add(stl.SpaceTimeLocationID);
            }

            //
            // determine if the space-time location id is a valid id and return the result
            //
            if (spaceTimeLocationIds.Contains(spaceTimeLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentSpaceTimeLocation)
        {
            List<int> gameObjectIds = new List<int>();


            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == currentSpaceTimeLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }

            }


            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsValidPlayerObjectByLocationId(int playerObjectId, int currentSpaceTimeLocation)
        {
            List<int> playerObjectIds = new List<int>();


            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == currentSpaceTimeLocation && gameObject is PlayerObject)
                {
                    playerObjectIds.Add(gameObject.Id);
                }

            }


            if (playerObjectIds.Contains(playerObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidNpcByLocationId(int npcId, int currentSpaceTimeLocation)
        {
            List<int> npcIds = new List<int>();


            foreach (Npc npc in _npcs)
            {
                if (npc.SpaceTimeLocationID == currentSpaceTimeLocation)
                {
                    npcIds.Add(npc.Id);
                }

            }


            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAccessibleLocation(int spaceTimeLocationId)
        {
            SpaceTimeLocation spaceTimeLocation = GetSpaceTimeLocationById(spaceTimeLocationId);
            if (spaceTimeLocation.Accessible == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int GetMaxSpaceTimeLocationId()
        {
            int MaxId = 0;

            foreach (SpaceTimeLocation spaceTimeLocation in SpaceTimeLocations)
            {
                if (spaceTimeLocation.SpaceTimeLocationID > MaxId)
                {
                    MaxId = spaceTimeLocation.SpaceTimeLocationID;
                }
            }

            return MaxId;
        }


        public SpaceTimeLocation GetSpaceTimeLocationById(int Id)
        {
            SpaceTimeLocation spaceTimeLocation = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (SpaceTimeLocation location in _spaceTimeLocations)
            {
                if (location.SpaceTimeLocationID == Id)
                {
                    spaceTimeLocation = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (spaceTimeLocation == null)
            {
                string feedbackMessage = $"The Space-Time Location ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return spaceTimeLocation;
        }

        public int GetMaxGameObjectId()
        {
            int MaxId = 0;

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id > MaxId)
                {
                    MaxId = gameObject.Id;
                }
            }

            return MaxId;
        }


        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;


            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //

            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(feedbackMessage, Id.ToString());
            }

            return gameObjectToReturn;
        }

        public List<GameObject> GetGameObjectsBySpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == spaceTimeLocationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        public List<PlayerObject> GetplayerObjectsBySpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<PlayerObject> playerObjects = new List<PlayerObject>();

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == spaceTimeLocationId && gameObject is PlayerObject)
                {
                    playerObjects.Add(gameObject as PlayerObject);
                }
            }

            return playerObjects;
        }

        public List<PlayerObject> PlayerInventory()
        {
            List<PlayerObject> inventory = new List<PlayerObject>(); ;

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == 0)
                {
                    inventory.Add(gameObject as PlayerObject);
                }
            }

            return inventory;
        }

        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return npcToReturn;
        }

        public List<Npc> GetNpcsBySpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<Npc> npcs = new List<Npc>();

            foreach (Npc npc in _npcs)
            {
                if (npc.SpaceTimeLocationID == spaceTimeLocationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        #endregion

    }
}
