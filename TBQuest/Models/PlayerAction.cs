using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Travel,
        PlayerInfo,
        Inventory,
        PlayerLocationsVisited,
        ListSpaceTimeLocations,
        ListGameObjects,
        ListNonPlayerCharacters,
        AdminMenu,
        ReturnToMainMenu,
        TalkTo,
        ObjectMenu,
        NonplayerCharacterMenu,
        PlayerMenu,
        Attack,
        Defend,
        UseItem,
        Flee,
        Exit
    }
}
