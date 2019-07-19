using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Goblin : Monster
    {
        public bool IsSmall { get; set; }

        public Goblin(string name, int hitChance, int life, int maxLife, int block, int minDamage, int maxDamage, string description, bool isSmall)
            : base(name, hitChance, life, maxLife, block, minDamage, maxDamage, description)
        {
            IsSmall = isSmall;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + "\n" + (IsSmall ? "The goblin is small and fast. You struggle to hit it." : "");
        }//end override string

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsSmall)
            {
                calculatedBlock += calculatedBlock * 2;
                //50% block improvement

            }//end if
            return calculatedBlock;
        }//end override CalcBlock

    }//end class
}//end namespace
