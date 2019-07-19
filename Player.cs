using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Automatic properties are a shortcut syntax that was introduced with .Net
        //3.5 that allows us to quickly make a property that doesn't have a business rule.
        //Auto properties automatically create a releated field at runtime and therefore do not require us to manually writh
        //a field.


        //fields:
        //private int _life;


        //properties
        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public PlayerRace Race { get; set; }
        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        _life = value <= MaxLife ? value : MaxLife;
        //    }//end set
        //}//end life


        //ctors
        public Player(string name, int hitChance, int block, int maxLife, Weapon equippedWeapon, PlayerRace race, int life)
        {
            MaxLife = maxLife;
            Life = life;
            Name = name;
            Block = block;
            EquippedWeapon = equippedWeapon;
            Race = race;
            HitChance = hitChance;

            switch (Race)//will need to create a RAce object and set it to a base option and let them choose
            {
                case PlayerRace.Elf:
                    break;
                case PlayerRace.Orc:
                    break;
                case PlayerRace.Dwarf:
                    MaxLife += 10;
                    Life += 10;
                    EquippedWeapon.MinDamage += 1;
                    break;
                case PlayerRace.Human:
                    break;
                case PlayerRace.Gnome:
                    break;
                case PlayerRace.DragonBorn:
                    break;
                case PlayerRace.Tiefling:
                    break;
                case PlayerRace.Giant:
                    break;
                case PlayerRace.Halfling:
                    break;
                case PlayerRace.HalfElf:
                    break;
                case PlayerRace.HalfOrc:
                    break;
                default:
                    break;
            }
        }//end FQCTOR

        //methods
        public override string ToString()
        {
            string description = "";

            switch (Race)
            {
                case PlayerRace.Elf:
                    description = "You're an ancient elf. Your grace and pointed ears are obvious to all.";
                    break;

                case PlayerRace.Orc:
                    description = "You're an orc. You are large and barbaric in nature";
                    break;

                case PlayerRace.Dwarf:
                    description = "You're a stout dwarf, mighty in spirit in not in status.";
                    break;

                case PlayerRace.Human:
                    description = "You chose human? Lame.";
                    break;

                case PlayerRace.Gnome:
                    description = "You're a diminuative forest gnome, quick, clever, and mischevious. ";
                    break;

                case PlayerRace.DragonBorn:
                    description = "You're dragonborn, half human and half dragon. Large and covered with scales you have breath attacks related to your element such as ice or fire.";
                    break;

                case PlayerRace.Tiefling:
                    description = "You're a tiefling, a human with demonic heritags. The six fingers on each hand belie your demon ancestry.";
                    break;

                case PlayerRace.Giant:
                    description = "You're a giant. You are very tall and people are intimidated by your height.";
                    break;

                case PlayerRace.Halfling:
                    description = "As a little halfling you have incredible luck and a large appetite.";
                    break;

                case PlayerRace.HalfElf:
                    description = "You're a halfelf. Born of two worlds and fitting in neither.";
                    break;

                case PlayerRace.HalfOrc:
                    description = "You're a halforc. Born of a barbaric orc and human you don't fit in well in either place.";
                    break;

            }//end switch

            return string.Format("{0}\nLife: {1} of {2}\nHit Chance: {3}%\n" +
                "Weapon:\n{4}\nBlock: {5}\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Block, 
                description);


        }//ent ToString

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }//end override calcDAmage

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }//end override hitChance

    }//end class
}//end namespace
