using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields

        private string _name;
        private bool _isTwoHanded;
        private int _bonusHitChance;
        private int _minDamage;
        private int _maxDamage;

        //properties
        //any time you have properties with buisness rules they are built last. possible they may rely on properties that have been set
        //properties with buisness rules always go last because the buisness rules may rely
        //on the value of other properties. Business rule is the last line of defence agains bad code. Third layer of protection.

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else  ternary option: if value > 0 && value <= MaxDamage ? _minDamage = value : _minDamage = 1;
            }//end set
        }//end MinDAmage


        //ctors
        public Weapon(string name, bool isTwoHanded, int bonusHitChance, int maxDamage, int minDamage)
        {
            //MinDamage has a dependency on MaxDamage, so MaxDamage must be set before MinDamage:
            //PascalCase = camelCase (setting Property to the parameter value) and max damage set before min
            Name = name;
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
            MaxDamage = maxDamage;
            MinDamage = minDamage;

        }//end FQCTOR


        //methods
        public override string ToString()
        {
            return string.Format("{0}\n{1} to {2}\nBonus Hit: {3}%\n{4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                IsTwoHanded ? "Two-handed" : "One-handed");
        }

    }//end class
}//end namespace
