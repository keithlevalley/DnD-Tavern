using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace characterGenerator
{

    class RaceTemplate
    {
        public String Name { get; set; }
        // Str, Con, Dex, Int, Wis, Cha
        public int[] Stats { get; set; }
        public int[] Defenses { get; set; }
        public String Size { get; set; }
        public int Speed { get; set; }
        public String Vision { get; set; }
        public List<String> Languages { get; set; }
        public List<String> RacialAbilities { get; set; }
        public List<String> RacialSkills { get; set; }
        public List<String> RacialSpecial { get; set; }

        public RaceTemplate(String race)
        {
            Stats = new int[6];
            Defenses = new int[4];
            Languages = new List<string>();
            RacialAbilities = new List<string>();
            RacialSkills = new List<string>();
            RacialSpecial = new List<string>();

            switch (race)
            {
                case "DragonBorn":
                    createDragonborn();
                    break;
                case "Dwarf":
                    createDwarf();
                    break;
                case "Eladrin":
                    createEladrin();
                    break;
                case "Elf":
                    createElf();
                    break;
                case "HalfElf":
                    createHalfElf();
                    break;
                case "Halfling":
                    createHalfling();
                    break;
                case "Human":
                    createHuman();
                    break;
                case "Tiefling":
                    createTiefling();
                    break;
                default:
                    createHuman();
                    break;
            } // end switch
        } // end constructor

        private void createDragonborn()
        {
            Name = "Dragonborn";
            Stats = new int[] { 2, 0, 0, 0, 0, 2 };
            Size = "Medium";
            Speed = 6;
            Vision = "Normal";
            Languages.Add("Common");
            Languages.Add("Draconic");

            RacialSkills.Add("History");
            RacialSkills.Add("Intimidate");

            foreach (String ability in dragonBornSpecials)
            {
                RacialSpecial.Add(ability);
            }

            RacialAbilities.Add(DragonBreath);
        }

        private void createDwarf()
        {
            Name = "Dwarf";
            Stats = new int[] { 0, 2, 0, 0, 2, 0 };
            Size = "Medium";
            Speed = 5;
            Vision = "Low-light";
            Languages.Add("Common");
            Languages.Add("Dwarven");

            RacialSkills.Add("Dungeoneering");
            RacialSkills.Add("Endurance");

            foreach (String ability in dwarfSpecials)
            {
                RacialSpecial.Add(ability);
            }
        }

        private void createEladrin()
        {
            Name = "Eladrin";
            Stats = new int[] { 0, 0, 2, 2, 0, 0 };
            Size = "Medium";
            Speed = 6;
            Vision = "Low-light";
            Languages.Add("Common");
            Languages.Add("Elven");

            RacialSkills.Add("Arcana");
            RacialSkills.Add("History");
            RacialSkills.Add("Insight");

            Defenses[3] = 1;

            foreach (String ability in eladrinSpecials)
            {
                RacialSpecial.Add(ability);
            }

            RacialAbilities.Add(FeyStep);
        }

        private void createElf()
        {
            Name = "Elf";
            Stats = new int[] { 0, 0, 2, 0, 2, 0 };
            Size = "Medium";
            Speed = 7;
            Vision = "Low-Light";
            Languages.Add("Common");
            Languages.Add("Elven");

            RacialSkills.Add("Nature");
            RacialSkills.Add("Perception");

            foreach (String ability in elfSpecials)
            {
                RacialSpecial.Add(ability);
            }

            RacialAbilities.Add(elvenAccuracy);
        }

        private void createHalfElf()
        {
            Name = "HalfElf";
            Stats = new int[] { MainWindow.rand.Next(2), 2, MainWindow.rand.Next(2), MainWindow.rand.Next(2), MainWindow.rand.Next(2), 2 };
            Size = "Medium";
            Speed = 6;
            Vision = "Low-light";
            Languages.Add("Common");
            Languages.Add("Elven");
            Languages.Add("Dwarven");

            RacialSkills.Add("Diplomacy");
            RacialSkills.Add("Insight");

            foreach (String ability in halfElfSpecials)
            {
                RacialSpecial.Add(ability);
            }
        }

        private void createHalfling()
        {
            Name = "Halfling";
            Stats = new int[] { 0, 0, 2, 0, 0, 2 };
            Size = "Small";
            Speed = 6;
            Vision = "Normal";
            Languages.Add("Common");
            Languages.Add("Goblin");

            RacialSkills.Add("Acrobatics");
            RacialSkills.Add("Thievery");

            foreach (String ability in halflingSpecials)
            {
                RacialSpecial.Add(ability);
            }

            RacialAbilities.Add(secondChance);
        }

        private void createHuman()
        {
            Name = "Human";
            Stats = new int[] { MainWindow.rand.Next(3), MainWindow.rand.Next(3), MainWindow.rand.Next(3), MainWindow.rand.Next(3), MainWindow.rand.Next(3), MainWindow.rand.Next(3) };
            Size = "Medium";
            Speed = 6;
            Vision = "Normal";
            Languages.Add("Common");
            Languages.Add("Draconic");

            Defenses[1] = 1;
            Defenses[2] = 1;
            Defenses[3] = 1;

            RacialSkills.Add("Endurance");
        }

        private void createTiefling()
        {
            Name = "Tiefling";
            Stats = new int[] { 0, 0, 0, 2, 0, 2 };
            Size = "Medium";
            Speed = 6;
            Vision = "Low-Light";
            Languages.Add("Common");
            Languages.Add("Draconic");

            RacialSkills.Add("Bluff");
            RacialSkills.Add("Stealth");

            foreach (String ability in tieflingSpecials)
            {
                RacialSpecial.Add(ability);
            }

            RacialAbilities.Add(infernalWrath);
        }

        //****************************************************************//
        //                     Racial Abilities                           //
        //****************************************************************//

        // DragonBorn Specials
        static string DragonBornFury = "Dragonborn Fury: When you're bloodied, you gain a +1 racial bonus to attack rolls.";
        static string DraconicHeritage = "Add +`CONMOD` to your healing surge value.";

        static string[] dragonBornSpecials = new string[] { DragonBornFury, DraconicHeritage };

        // Dragonborn Abilities
        static string DragonBreath = "Dragon Breath\n"
+ "Encounter - Minor - Close blast 3 - All creatues in area | Attack: (Highest of `STRMOD`, `CONMOD`, `DEXMOD`) + 2 vs Reflex\n"
+ "Hit: 1d6 +`CONMOD`\n"
+ "Special:  Choose either acid, Cold, Fire, Lightning, or poision for damage type.  Once this selection is made it cannot be changed.";

        // Dwarf Specials
        static string CastIronStomach = "Cast-Iron Stomach: +5 racial bonus to saving throws against poisons";
        static string DwarvenResilience = "Dwarven Resilience: You can use your second wind as a minor action instead of a standard action";
        static string StandYourGround = "Stand Your Ground: When an effect forces you to move through a pull, push or slide, you can move 1 square less."
            + "  In addition when an attack knocks you prone you may immediately make a saving throw to avoid falling prone.";

        static string[] dwarfSpecials = new string[] { CastIronStomach, DwarvenResilience, StandYourGround };

        // Eladrin Specials
        static string FeyOrigen = "Fey Origen: You are considered native to the Feywild and considered a fey creature.";
        static string Trance = "Trance: Rather than sleep you enter a meditative trance for 4 hours.  While in a trance you are fully aware of your surroundings.";

        static string[] eladrinSpecials = new string[] { FeyOrigen, Trance };

        // Eladrin Abilities
        static string FeyStep = "Fey Step\n"
+ "Encounter - Teleportation - Move - Personal | Effect: Teleport up to 5 squares";

        // Elf Specials
        // Include FeyOrigen from Eladrin
        static string groupAwareness = "You grant non-elf allies within 5 squares of you a +1 racial bonus to perception checks";
        static string wildStep = "You ignore difficult terrain when you shift";

        static string[] elfSpecials = new string[] { FeyOrigen, groupAwareness, wildStep };

        // Elf Abilities
        static string elvenAccuracy = "Elven Accuracy\n"
+ "Encounter - Free - Personal | Effect: Reroll an attack roll.  Use the 2nd roll, even if it's lower";

        // Half-Elf Specials
        static string groupDiplomacy = "You grant allies within 10 squares of you a +1 racial bonus to Diplomacy checks.";

        static string[] halfElfSpecials = new string[] { groupDiplomacy };

        // Halfling Specials
        static string bold = "You gain a +5 racial bonus to saving throws against fear.";

        static string nimbleReaction = "You gain a +2 racial bonus to AC against opportunity attacks.";

        static string[] halflingSpecials = new string[] { bold, nimbleReaction };

        // Halfling Abilities
        static string secondChance = "Second Chance\n"
+ "Encounter - Immediate Interrupt - Personal | Effect: When an attack hits you, force an enemy to roll the attack again.";

        // Tiefling Specials
        static string bloodHunt = "You gain a +1 racial bonus to attack rolls against bloodied foes.";

        static string fireResistance = "You have resist fire 5 + `HALFLEVEL`";

        static string[] tieflingSpecials = new string[] { bloodHunt, fireResistance };

        // Tiefling Abilities
        static string infernalWrath = "Infernal Wrath\n"
+ "Encounter - Minor - Personal | Effect: You can channel your fury to gain +1 power bonus to your next attack roll against an enemy that hit you since your last turn."
+ "  If your attack hits and deals damage add `CHAMOD` as extra damage";

    } // end Race Class
} // end NameSpace
