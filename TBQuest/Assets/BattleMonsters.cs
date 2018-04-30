using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static class BattleMonsters
    {
        public static List<Monster> Monsters = new List<Monster>()
        {
            new Monster
            {
                Id = 1,
                Name = "Shield",
                Description = "An aggressively floating shield, made of black energy, stares angerly at you",
                MonAttackMethod = Monster.AttackMethod.Defensive,
                Health = 30,
                ExpValue = 20,
                AttackPower = 2,
                Defense = 8
                
            },
            new Monster
            {
                Id = 2,
                Name = "Sword",
                Description = "An aggressively floating sword, made of black energy, stares angerly at you",
                MonAttackMethod = Monster.AttackMethod.Defensive,
                Health = 15,
                ExpValue = 20,
                AttackPower = 4,
                Defense = 4

            },
            new Monster
            {
                Id = 3,
                Name = "Shadow Blacksmith",
                Description = "The evil man behind it all, who would have guessed?",
                MonAttackMethod = Monster.AttackMethod.Boss,
                Health = 30,
                ExpValue = 2000000,
                AttackPower = 10,
                Defense = 10

            },
        };
    }
}
