using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Rat : Monster
    {
        public bool IsFilthy { get; set; }

        public Rat(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description,
             bool isFilthy)
            :base (name, hitChance, life, maxLife, block, minDamage,maxDamage, description)
        {
            IsFilthy = isFilthy;
        }

        public override string ToString()
        {
            return base.ToString() + (IsFilthy ? "\nThe rat's horrible stench leaves you reeling. You find it hard to swing your weapon" : ""); 
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsFilthy)
            {
                calculatedBlock += calculatedBlock / 2;
                //50% block improvement

            }//end if
            return calculatedBlock;
        }//end override CalcBlock


    }//end class
}
