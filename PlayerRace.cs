using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public enum PlayerRace
    {
        //There is no direct way to creat a enum through the VS interface.
        //To make one, first create a class, make it public then change the 
        //class keyword to enum.
       
        Elf,
        Orc,
        Dwarf,
        Human,
        Gnome,
        DragonBorn,
        Tiefling,
        Giant,
        Halfling,
        HalfElf,
        HalfOrc

    }//end enum PlayerRace
}
