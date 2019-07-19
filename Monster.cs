using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public string Description { get; set; }
        public int MaxDamage { get; set; }

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
                }//end else  ternary option: if value > 0 && value <= MaxDamage ? _minDamage = value : _minDamage = 1;; }
            }//end set
        }//end mindamage


        //mini lab build fqctor 8 parameters
        public Monster(string name, int hitChance, int life, int maxLife, int block, int minDamage, int maxDamage, string description)
        {
            Name = name;
            HitChance = hitChance;
            MaxLife = maxLife;
            Life = life;
            Block = block;
            Description = description;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }//FQCTOR

        public override string ToString()
        {
            return string.Format($"{Name}\nLife: {Life} of {MaxLife}\nDamage: {MinDamage} to {MaxDamage}\n" +
                $"Hit Chance: {CalcHitChance()}\nBlock: {CalcBlock()}\nDescription:\n{Description}");
        }//end override ToString

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//end override CalcDamage


    }//end class
}//end namespace
