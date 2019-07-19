using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character//parent class must always be public-
    {
        /*
         * Abstract keyword isnidcate that the thing being modified is an incomplete implementation/
         * It indicates that the class is intended to only be a parent
         * to pass class members to child classes and that
         * it cannot be instantiated.
         * */

        private int _life;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//end set
        }//end life

       //WE don't inherit ctors from the parent and because Character is abstract 
       //we are never going to instantiate one. Therefore, we won't build a ctor here/
       //Instead, we'll get the free parameterless one, but we will never be able to use it

        public virtual int CalcBlock()
        {
            return Block;
        }//end CalcBlock

        //Mini lab
        //make CalcHitChance() return HitChance and make it overrideable:
        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance

        public virtual int CalcDamage()
        {
            return 0;
        }//end CalcDAmage



    }//end class
}//end namespace
