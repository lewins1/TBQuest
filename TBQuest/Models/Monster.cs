using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public class Monster
    {
        public enum AttackMethod
        {
            Defensive,
            Offensive,
            Special,
            Boss
        }

        private int _Id;
        private string _name;
        private int _health;
        private AttackMethod _monAttackMethod;
        private int _expValue;
        private string _description;
        private int _defense;
        private int _attackPower;

        public int AttackPower
        {
            get { return _attackPower; }
            set { _attackPower = value; }
        }



        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }


        public int ExpValue
        {
            get { return _expValue; }
            set { _expValue = value; }  
        }
        public AttackMethod MonAttackMethod
        {
            get { return _monAttackMethod; }
            set { _monAttackMethod = value; }
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public void Attack()
        {
            switch (_monAttackMethod)
            {
                case AttackMethod.Defensive:
                    break;
                case AttackMethod.Offensive:
                    break;
                case AttackMethod.Special:
                    break;
                case AttackMethod.Boss:
                    break;
                default:
                    break;
            }
        }
    }
}
