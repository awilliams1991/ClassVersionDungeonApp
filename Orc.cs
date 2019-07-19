using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Orc : Monster
    {
        public bool HasArmor { get; set; }
       
        
        public Orc(string name, int hitChance, int life, int maxLife, int block, int minDamage, int maxDamage, string description, bool hasArmor)
            :base (name, hitChance, life, maxLife, block, minDamage, maxDamage, description)
        {
            HasArmor = hasArmor;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + "\n" + (HasArmor ? "The Orc is wearing armor and is moving slowly making him easier to hit" : "");
        }

        //public override int CalcDamage()
        //{
        //    int calculatedDamage = new Random().Next(MinDamage, MaxDamage + 1);

        //    if (HasArmor)
        //    {
        //        calculatedDamage += calculatedDamage / 2;
        //        //50% damage reduction

        //    }//end if
        //    return calculatedDamage;
        //}//end override CalcDamage

    }//end class
}//end namespace
