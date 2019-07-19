using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace ClassDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Class Dungeon";

            Console.Write("Enter your name: ");
            string heroName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome, {0}. Your journey begins...", heroName);

            //TODO create a player
            Weapon spear = new Weapon("Rusty Spear", true, 5, 4, 1);
            Player player = new Player(heroName, 50, 15, 40, spear, PlayerRace.Dwarf, 40
                );
            int monstersSlain = 0;

            bool exit = false;

            do
            {
                //TODO build GetRoom()
                Console.WriteLine(GetRoom());
                //TODO create a monster
                Monster monster = GetMonster();
                Console.WriteLine("In this room:" + monster.Name);

                bool reload = false;
                do
                {
                    Console.Title = "Kills: " + monstersSlain;
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Stats\n" +
                        "M) Monster Stats\n" +
                        "E) Exit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //Console.WriteLine("Attack functionality here..");
                            //TODO build combat functionality
                            Combat.DoBattle(player, monster);
                            if (monster.Life < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!", monster.Name);
                                Console.ResetColor();
                                monstersSlain++;
                                reload = true;
                            }//end if monster dead
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("RUN AWAY!");
                            //TODO Monster get a free attack
                            //TODO Refresh a new room & monster
                            Console.WriteLine("{0} attacks you as you flee!", monster.Name);
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            //TODO display player stats
                            break;

                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("Thou hast chosen to flee the field of combat. Shame upon you.");
                            exit = true;
                            break;

                        case ConsoleKey.M:
                            //Console.WriteLine("monster stats here");
                            //TODO display monster stats
                            Console.WriteLine(monster);
                            break;
                        
                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Chooseth thou again.");
                            break;
                    }//end switch menu

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You fought valiently, but have been defeated in single combat.");
                        exit = true;
                    }

                } while (!reload && !exit);//end menu loop allows us to switch to the outer loop if not exiting the game completely
                

            } while (!exit);//end primary loop

            Console.WriteLine("\n\nGAME OVER");


        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "Many doors fill the room ahead. Doors of varied shape, size, and design are set in every wall and even the ceiling and floor. Barely a hand's width lies between one door and the next. All the doors but the one you entered by are shut, and many have obvious locks." ,
                "A dim bluish light suffuses this chamber, its source obvious at a glance. Blue-glowing lichen and violet-glowing moss cling to the ceiling and spread across the floor. It even creeps down and up each wall, as if the colonies on the floor and ceiling are growing to meet each other. Their source seems to be a glowing, narrow crack in the ceiling, the extent of which you cannot gauge from your position. The air in the room smells fresh and damp.",
                "This room is a small antechamber before two titanic bronze doors. Each stands 20 feet tall and is about 7 feet wide. The double doors are peaked at their centers, but unlike many sets of double doors, their division isn't in the center. Instead, the crack between the doors resembles a crooked bolt of lightning, which a figure in a cloud carved in the stone above the door appears to be hurling. The lightning bolt strikes down roughly 2 feet to the right of center. The figure in the clouds is deliberately indistinct, but it appears male, having a beard and male proportions. The stroke of bronze electricity hits a tower that seems small compared to the figure. This tower cracks down the center, continuing the gap between the doors until it reaches the ground. To either side of the tower lie pastoral scenes of hillsides dotted with sheep. There doesn't appear to be a lock or handles.",
                "This room looks like it was designed by drow. Rusted metal tiles create a huge mosaic of a spider in the floor, and someone set up rusted gratings like draperies of webs. At the far end of the chamber, the carving of a spider squats on the floor. It's about 3 feet tall and seems molded into the floor. Beyond it stands tall double doors of stone, their surface covered in a glittering web of gold.",
                "This room is hung with hundreds of dusty tapestries. All show signs of wear: moth holes, scorch marks, dark stains, and the damage of years of neglect. They hang on all the walls and hang from the ceiling to brush against the floor, blocking your view of the rest of the room.",
                "As the door opens, it scrapes up frost from a floor covered in ice. The room before you looks like an ice cave. A tunnel wends its way through solid ice, and huge icicles and pillars of frozen water block your vision of its farthest reaches.",
                "You open the door to reveal a 10-foot-by-10-foot room with a floor studded with spikes. The bones of some creature lie among the spikes and some insects scuttle away from the desiccated remains. No other doors are in the room, and it appears the door you opened was created to blend in with the walls. Additionally, you see no ceiling. You must be at the bottom of a very deep spiked pit.",
                "This chamber is clearly a prison. Small barred cells line the walls, leaving a 15-foot-wide pathway for a guard to walk. Channels run down either side of the path next to the cages, probably to allow the prisoners' waste to flow through the grates on the other side of the room. The cells appear empty but your vantage point doesn't allow you to see the full extent of them all.",
                "A horrendous, overwhelming stench wafts from the room before you. Small cages containing small animals and large insects line the walls. Some of the creatures look sickly and alive but most are clearly dead. Their rotting corpses and the unclean cages no doubt result in the zoo's foul odor. A cat mews weakly from its cage, but the other creatures just silently shrink back into their filthy prisons.",
                " A huge iron cage lies on its side in this room, and its gate rests open on the floor. A broken chain lies under the door, and the cage is on a rotting corpse that looks to be a hobgoblin. Another corpse lies a short distance away from the cage. It lacks a head.",
                "Thick cobwebs fill the corners of the room, and wisps of webbing hang from the ceiling and waver in a wind you can barely feel. One corner of the ceiling has a particularly large clot of webbing within which a goblin's bones are tangled.",
                "You inhale a briny smell like the sea as you crack open the door to this chamber. Within you spy the source of the scent: a dark and still pool of brackish water within a low circular wall. Above it stands a strange statue of a lobster-headed and clawed woman. The statue is nearly 15 feet tall and holds the lobster claws crossed over its naked breasts."
            }; //end rooms string[]

            //Random rand = new Random();
            //int indexNbr = rand.Next(rooms.Length);
            //string room = rooms[indexNbr];
            return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()

        private static Monster GetMonster()
        {
            Rat ratSwarm = new Rat("Rat Swarm", 10, 10, 25, 10, 1, 3, "It's a swarm of rats!", false);
            Rat megaRat = new Rat("Filthy Rat", 15, 15, 30, 15, 2, 6, "A gaint filth encrusted rat appears", true);
            Goblin smallGoblin = new Goblin("Tiny Goblin", 30, 30, 30, 15, 2, 6, "A tiny goblin appears. It is small and fast", true);
            Goblin largeGoblin = new Goblin("Goblin", 30, 30, 30, 15, 2, 6, "A goblin jumps out!", false);
            Orc regularOrc = new Orc("Orc warrior", 20, 30, 30, 25, 3, 7, "A large orc appears and blocks your path", false);
            Orc guardOrc = new Orc("Orc commander", 40, 40, 40, 40, 5, 10, "A menacing orc commander appears. Large and intimidating it blocks your path refusing to let you pass.", true);
            Rat direRat = new Rat("Dire Rat", 40, 40, 60, 25, 10, 20, "The leader of the rats has appeared. Massive, with large muscles it has a foul smelling shiny crust on it's fur.", true);

            List<Monster> monsters = new List<Monster>()
            {
                ratSwarm, ratSwarm, ratSwarm, megaRat, megaRat, direRat, smallGoblin, smallGoblin, smallGoblin, largeGoblin, largeGoblin, largeGoblin, 
                regularOrc, regularOrc, regularOrc, regularOrc, guardOrc, guardOrc, guardOrc, regularOrc, regularOrc, largeGoblin, smallGoblin, 
                ratSwarm, ratSwarm, ratSwarm, megaRat, megaRat, direRat
            };//end list

            return monsters[new Random().Next(monsters.Count)];

            //streamwriter can be used to save the game.
        }
    }//end class
}//end namespace
