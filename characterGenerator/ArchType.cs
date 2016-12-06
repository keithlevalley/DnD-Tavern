using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace characterGenerator
{
    class ArchType
    {
        public String Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int HealingSurges { get; set; }
        // Str, Con, Dex, Int, Wis, Cha
        public int[] Stats { get; set; }
        public int[] Defenses { get; set; }
        public List<String> ArchTypeAbilities { get; set; }
        public List<String> ArchTypeSkills { get; set; }
        public List<String> ArchTypeSpecial { get; set; }

        public String armor, mainHand, offHand, implement, ranged;

        public ArchType(String archType, int level)
        {
            Name = "Temp";
            Level = level;
            Stats = new int[6];
            Defenses = new int[4];
            ArchTypeAbilities = new List<string>();
            ArchTypeSkills = new List<string>();
            ArchTypeSpecial = new List<string>();

            switch (archType)
            {
                case "Cleric":
                    createCleric();
                    break;
                case "Warlock":
                    createWarlock();
                    break;
                case "Fighter":
                    createFighter();
                    break;
                case "Paladin":
                    createPaladin();
                    break;
                case "Wizard":
                    createWizard();
                    break;
                case "Ranger":
                    createRanger();
                    break;
                case "Rogue":
                    createRogue();
                    break;
                case "Warlord":
                    createCleric(); //temp for test
                    break;
                default:
                    createGeneric();
                    break;
            } // end switch
        } // end constructor
        
        public int[] RacialAbilities { get; set; }

        private void createCleric()
        {
            Name = "Cleric";
            armor = "Chainmail";
            mainHand = "Mace";
            offHand = "";
            ranged = "";
            implement = "Holy Symbol";
            ArchTypeSpecial.Add(HealingLore);

            Stats[0] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 12 + allStatModier(Level);
            Stats[2] = 12 + allStatModier(Level);
            Stats[3] = 12 + allStatModier(Level);
            Stats[4] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 16 + primStatModier(Level) + allStatModier(Level);

            Defenses[0] = 6;
            Defenses[3] = 2;
            Speed = -1;

            HP = 12 + 5 * (Level);
            HealingSurges = 7;

            ArchTypeSkills.Add("Religion");
            ArchTypeSkills.Add("Arcana");
            ArchTypeSkills.Add("Diplomacy");
            ArchTypeSkills.Add("Heal");
            ArchTypeSkills.Add("History");
            ArchTypeSkills.Add("Insight");

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(clericAtWill[temp]))
                {
                    ArchTypeAbilities.Add(clericAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(clericEncounter[temp]))
                {
                    ArchTypeAbilities.Add(clericEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(2);
                    if (!ArchTypeAbilities.Contains(cleric2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(cleric2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }

            if (Level >= 3)
            {
                do
                {
                    int temp = MainWindow.rand.Next(4);
                    if (!ArchTypeAbilities.Contains(cleric3Encounter[temp]))
                    {
                        ArchTypeAbilities.Add(cleric3Encounter[temp]);
                    }
                } while (ArchTypeAbilities.Count != 5);
            }

            ArchTypeAbilities.Add(ChannelDivinityTurnUndead);
            ArchTypeAbilities.Add(HealingWord);
            
        } // end createCleric

        private void createWarlock()
        {
            Name = "Ranger";
            armor = "Leather";
            mainHand = "Longsword";
            offHand = "Shortsword";
            ranged = "Longbow";
            implement = "";

            ArchTypeSpecial.Add(PrimeShot);
            ArchTypeSpecial.Add(HuntersQuarry);

            Stats[0] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 12 + allStatModier(Level);
            Stats[2] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[3] = 12 + allStatModier(Level);
            Stats[4] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 10 + allStatModier(Level);

            Defenses[0] = 2;
            Defenses[1] = 1;
            Defenses[2] = 1;
            Speed = 0;

            HP = 12 + 5 * (Level);
            HealingSurges = 6;

            ArchTypeSkills.Add("Dungeoneering");
            ArchTypeSkills.Add("Nature");
            ArchTypeSkills.Add("Acrobatics");
            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Perception");
            ArchTypeSkills.Add("Stealth");
            ArchTypeSkills.Add("Heal");

            do
            {
                int temp = MainWindow.rand.Next(rangerAtWill.Count());
                if (!ArchTypeAbilities.Contains(rangerAtWill[temp]))
                {
                    ArchTypeAbilities.Add(rangerAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(rangerEncounter.Count());
                if (!ArchTypeAbilities.Contains(rangerEncounter[temp]))
                {
                    ArchTypeAbilities.Add(rangerEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(ranger2Utility.Count());
                    if (!ArchTypeAbilities.Contains(ranger2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(ranger2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }
        }

        private void createFighter()
        {
            Name = "Fighter";
            armor = "Scale";
            mainHand = "Longsword";
            offHand = "Light Shield";
            ranged = "";
            implement = "";
            ArchTypeSpecial.Add(combatChallenge);
            ArchTypeSpecial.Add(combatSuperiority);
            ArchTypeSpecial.Add(fighterWeaponTalent);

            Stats[0] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[2] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[3] = 10 + allStatModier(Level);
            Stats[4] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 10 + allStatModier(Level);

            Defenses[0] = 8;
            Defenses[1] = 2;
            Defenses[2] = 1;
            Speed = -1;

            HP = 12 + 5 * (Level);
            HealingSurges = 7;

            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Endurance");
            ArchTypeSkills.Add("Heal");
            ArchTypeSkills.Add("Intimidate");
            ArchTypeSkills.Add("Streetwise");

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(fighterAtWill[temp]))
                {
                    ArchTypeAbilities.Add(fighterAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(fighterEncounter[temp]))
                {
                    ArchTypeAbilities.Add(fighterEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(2);
                    if (!ArchTypeAbilities.Contains(fighter2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(fighter2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }

            if (Level >= 3)
            {
                do
                {
                    int temp = MainWindow.rand.Next(4);
                    if (!ArchTypeAbilities.Contains(fighter3Encounter[temp]))
                    {
                        ArchTypeAbilities.Add(fighter3Encounter[temp]);
                    }
                } while (ArchTypeAbilities.Count != 5);
            }
        }

        private void createPaladin()
        {
            Name = "Fighter";
            armor = "Scale";
            mainHand = "Longsword";
            offHand = "Light Shield";
            ranged = "";
            implement = "";
            ArchTypeSpecial.Add(combatChallenge);
            ArchTypeSpecial.Add(combatSuperiority);
            ArchTypeSpecial.Add(fighterWeaponTalent);

            Stats[0] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[2] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[3] = 10 + allStatModier(Level);
            Stats[4] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 10 + allStatModier(Level);

            Defenses[0] = 8;
            Defenses[1] = 2;
            Defenses[2] = 1;
            Speed = -1;

            HP = 12 + 5 * (Level);
            HealingSurges = 7;

            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Endurance");
            ArchTypeSkills.Add("Heal");
            ArchTypeSkills.Add("Intimidate");
            ArchTypeSkills.Add("Streetwise");

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(fighterAtWill[temp]))
                {
                    ArchTypeAbilities.Add(fighterAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(fighterEncounter[temp]))
                {
                    ArchTypeAbilities.Add(fighterEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(2);
                    if (!ArchTypeAbilities.Contains(fighter2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(fighter2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }

            if (Level >= 3)
            {
                do
                {
                    int temp = MainWindow.rand.Next(4);
                    if (!ArchTypeAbilities.Contains(fighter3Encounter[temp]))
                    {
                        ArchTypeAbilities.Add(fighter3Encounter[temp]);
                    }
                } while (ArchTypeAbilities.Count != 5);
            }
        }

        private void createWizard()
        {
            Name = "Fighter";
            armor = "Scale";
            mainHand = "Longsword";
            offHand = "Light Shield";
            ranged = "";
            implement = "";
            ArchTypeSpecial.Add(combatChallenge);
            ArchTypeSpecial.Add(combatSuperiority);
            ArchTypeSpecial.Add(fighterWeaponTalent);

            Stats[0] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[2] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[3] = 10 + allStatModier(Level);
            Stats[4] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 10 + allStatModier(Level);

            Defenses[0] = 8;
            Defenses[1] = 2;
            Defenses[2] = 1;
            Speed = -1;

            HP = 12 + 5 * (Level);
            HealingSurges = 7;

            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Endurance");
            ArchTypeSkills.Add("Heal");
            ArchTypeSkills.Add("Intimidate");
            ArchTypeSkills.Add("Streetwise");

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(fighterAtWill[temp]))
                {
                    ArchTypeAbilities.Add(fighterAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(fighterEncounter[temp]))
                {
                    ArchTypeAbilities.Add(fighterEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(2);
                    if (!ArchTypeAbilities.Contains(fighter2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(fighter2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }

            if (Level >= 3)
            {
                do
                {
                    int temp = MainWindow.rand.Next(4);
                    if (!ArchTypeAbilities.Contains(fighter3Encounter[temp]))
                    {
                        ArchTypeAbilities.Add(fighter3Encounter[temp]);
                    }
                } while (ArchTypeAbilities.Count != 5);
            }
        }

        private void createRanger()
        {
            Name = "Ranger";
            armor = "Leather";
            mainHand = "Longsword";
            offHand = "Shortsword";
            ranged = "Longbow";
            implement = "";

            ArchTypeSpecial.Add(PrimeShot);
            ArchTypeSpecial.Add(HuntersQuarry);

            Stats[0] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 12 + allStatModier(Level);
            Stats[2] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[3] = 12 + allStatModier(Level);
            Stats[4] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 10 + allStatModier(Level);

            Defenses[0] = 2;
            Defenses[1] = 1;
            Defenses[2] = 1;
            Speed = 0;

            HP = 12 + 5 * (Level);
            HealingSurges = 6;

            ArchTypeSkills.Add("Dungeoneering");
            ArchTypeSkills.Add("Nature");
            ArchTypeSkills.Add("Acrobatics");
            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Perception");
            ArchTypeSkills.Add("Stealth");
            ArchTypeSkills.Add("Heal");

            do
            {
                int temp = MainWindow.rand.Next(rangerAtWill.Count());
                if (!ArchTypeAbilities.Contains(rangerAtWill[temp]))
                {
                    ArchTypeAbilities.Add(rangerAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(rangerEncounter.Count());
                if (!ArchTypeAbilities.Contains(rangerEncounter[temp]))
                {
                    ArchTypeAbilities.Add(rangerEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(ranger2Utility.Count());
                    if (!ArchTypeAbilities.Contains(ranger2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(ranger2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }

            if (Level >= 3)
            {
                do
                {
                    int temp = MainWindow.rand.Next(ranger3Encounter.Count());
                    if (!ArchTypeAbilities.Contains(ranger3Encounter[temp]))
                    {
                        ArchTypeAbilities.Add(ranger3Encounter[temp]);
                    }
                } while (ArchTypeAbilities.Count != 5);
            }
        }

        private void createRogue()
        {
            Name = "Ranger";
            armor = "Leather";
            mainHand = "Longsword";
            offHand = "Shortsword";
            ranged = "Longbow";
            implement = "";

            ArchTypeSpecial.Add(PrimeShot);
            ArchTypeSpecial.Add(HuntersQuarry);

            Stats[0] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 12 + allStatModier(Level);
            Stats[2] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[3] = 12 + allStatModier(Level);
            Stats[4] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 10 + allStatModier(Level);

            Defenses[0] = 2;
            Defenses[1] = 1;
            Defenses[2] = 1;
            Speed = 0;

            HP = 12 + 5 * (Level);
            HealingSurges = 6;

            ArchTypeSkills.Add("Dungeoneering");
            ArchTypeSkills.Add("Nature");
            ArchTypeSkills.Add("Acrobatics");
            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Perception");
            ArchTypeSkills.Add("Stealth");
            ArchTypeSkills.Add("Heal");

            do
            {
                int temp = MainWindow.rand.Next(rangerAtWill.Count());
                if (!ArchTypeAbilities.Contains(rangerAtWill[temp]))
                {
                    ArchTypeAbilities.Add(rangerAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(rangerEncounter.Count());
                if (!ArchTypeAbilities.Contains(rangerEncounter[temp]))
                {
                    ArchTypeAbilities.Add(rangerEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(ranger2Utility.Count());
                    if (!ArchTypeAbilities.Contains(ranger2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(ranger2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }

            if (Level >= 3)
            {
                do
                {
                    int temp = MainWindow.rand.Next(ranger3Encounter.Count());
                    if (!ArchTypeAbilities.Contains(ranger3Encounter[temp]))
                    {
                        ArchTypeAbilities.Add(ranger3Encounter[temp]);
                    }
                } while (ArchTypeAbilities.Count != 5);
            }
        }

        private void createWarlord()
        {
            Name = "Cleric";
            armor = "Chainmail";
            mainHand = "Mace";
            offHand = "";
            ranged = "";
            implement = "Holy Symbol";
            ArchTypeSpecial.Add(HealingLore);

            Stats[0] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 12 + allStatModier(Level);
            Stats[2] = 12 + allStatModier(Level);
            Stats[3] = 12 + allStatModier(Level);
            Stats[4] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 16 + primStatModier(Level) + allStatModier(Level);

            Defenses[0] = 6;
            Defenses[3] = 2;
            Speed = -1;

            HP = 12 + 5 * (Level);
            HealingSurges = 7;

            ArchTypeSkills.Add("Religion");
            ArchTypeSkills.Add("Arcana");
            ArchTypeSkills.Add("Diplomacy");
            ArchTypeSkills.Add("Heal");
            ArchTypeSkills.Add("History");
            ArchTypeSkills.Add("Insight");

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(clericAtWill[temp]))
                {
                    ArchTypeAbilities.Add(clericAtWill[temp]);
                }
            } while (ArchTypeAbilities.Count != 2);

            do
            {
                int temp = MainWindow.rand.Next(4);
                if (!ArchTypeAbilities.Contains(clericEncounter[temp]))
                {
                    ArchTypeAbilities.Add(clericEncounter[temp]);
                }
            } while (ArchTypeAbilities.Count != 3);

            if (Level >= 2)
            {
                do
                {
                    int temp = MainWindow.rand.Next(2);
                    if (!ArchTypeAbilities.Contains(cleric2Utility[temp]))
                    {
                        ArchTypeAbilities.Add(cleric2Utility[temp]);
                    }
                } while (ArchTypeAbilities.Count != 4);
            }
        }

        private void createGeneric()
        {
            throw new NotImplementedException();
        }

        private int primStatModier (int level)
        {
            if (level < 4) return 0;
            else if (level < 8) return 1;
            else if (level < 14) return 2;
            else if (level < 18) return 3;
            else if (level < 24) return 4;
            else if (level < 28) return 5;
            else return 6;
        }

        private int allStatModier (int level)
        {
            if (level < 11) return 0;
            else if (level < 21) return 1;
            else return 2;
        }



        //****************************************************************************************//
        //                                Class Abilities                                         //
        //****************************************************************************************//

        // WISIMP = Wisdom + Implement
        // STRWEA = Strength + Weapon
        // `HALFLEVEL` = One-half your level

        // Cleric Class Features
        static string HealingLore = "When you grant healing with one of your cleric powers that has the healing keyword, add `WISMOD` to the hp regained.";

        static string ChannelDivinityTurnUndead = "Channel Divinity: Turn Undead\n"
+ "Encounter - Divine, Implement, Radiant - Standard - Close burst 2 - Each Undead in burst | Attack: +`WISIMP` vs Will\n"
+ "Hit: 1d10 +`WISMOD` radiant damage, and you push the targt a number of squares equal to 3 +`CHAMOD`.  The target is immobilized until the end of your next turn."
+ "  2d10 at 5th level\n"
+ "Miss: Half damage, and the target is not pushed or immobilized.";

        static string HealingWord = "Healing Word\n"
+ "Encounter - Divine, Healing - Minor - Close burst 5 - You or one ally\n"
+ "Special: You can use this power twice per encounter, but only once per round.\n"
+ "Effect: The target can spend a healing surge and regains an additional 1d6 hp";

        // Cleric At-Wills
        static string LanceOfFaith = "Lance of Faith\n"
+ "At-Will - Divine, Implement, Radiant - Standard - Ranged 5 - One Creature | Attack: +`WISIMP` vs. Reflex\n"
+ "Hit: 1d8 +`WISMOD` radiant damage, and one ally you can see gains a +2 power bonus to his or her next attack roll against the target.";

        static string PriestShield = "Priest's Shield\n"
+ "At-Will - Divine, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD`, and you and one adjacent ally gain a +1 power bonus to AC until the end of your next turn";

        static string RighteousBrand = "Rightous Brand\n"
+ "At-Will - Divine, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD`, and one ally within 5 squares of you gains a +`STRMOD` power bonus to melee attack rolls against the target until the end of your next turn";

        static string SacredFlame = "Sacred Flame\n"
+ "At-Will - Divine, Implement, Radiant - Standard - Ranged 5 - One Creature | Attack: +`WISIMP` vs Reflex\n"
+ "Hit: 1d6 +`WISMOD` radiant damage, and one ally you can see chooses either to gain `CHAMOD`+`HALFLEVEL` temporary hp or to make a saving throw";

        static string[] clericAtWill = new string[] { LanceOfFaith, PriestShield, RighteousBrand, SacredFlame };

        // Cleric Encounters
        static string CauseFear = "Cause Fear\n"
+ "Encounter - Divine, Implement, Fear - Standard - Ranged 10 - One Creature | Attack: +`WISIMP` vs Will\n"
+ "Hit: The target moves its speed +`CHAMOD` away from you.  The fleeing target avoids unsafe squares and difficult terrain if it can.  This movement provokes opportunity attacks.";

        static string DivineGlow = "Divine Glow\n"
+ "Encounter - Divine, Implement, Radiant - Standard - Close blast 3 - Each enemy in blast | Attack: +`WISIMP` vs Reflex\n"
+ "Hit: 1d8 +`WISMDO` radiant damage.\n"
+ "Effect: Allies in the blast gain +2 power bonus to attack rolls until the end of your next turn";

        static string HealingStrike = "Healing Strike\n"
+ "Encounter - Divine, Healing, Radiant, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` radiant damage, and the target is marked until the end of your next turn.  In addition, you or one ally within 5 squares of you can spend a healing surge.";

        static string WrathfulThunder = "Wrathful Thunder\n"
+ "Encounter - Divine, Thunder, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` thunder damage, and the target is dazed until the end of your next turn.";

        static string[] clericEncounter = new string[] { CauseFear, DivineGlow, HealingStrike, WrathfulThunder };

        // Cleric Level 2 Utility Prayers
        static string DivineAid = "Divine Aid\n"
+ "Encounter - Divine - Standard - Ranged 5, You or one ally\n"
+ "Effect: The target makes a saving throw with a bonus +`CHAMOD`";

        static string Sanctuary = "Sanctuary\n"
+ "Encounter - Divine - Standard - Ranged 10 - You or one creature\n"
+ "Effect: The target recieves a +5 bonus to all defenses.  The effect lasts until the target attacks or until the end of your next turn.";

        static string[] cleric2Utility = new string[] { DivineAid, Sanctuary };

        // Cleric Level 3 Encounter Prayers
        static string BlazingBeacon = "Blazing Beacon\n"
+ "Encounter - Divine, Radiant, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` radiant damage, and all ranged attack rolls against the target gain a +4 power bonus until the end of your next turn.";

        static string Command = "Command\n"
+ "Encounter - Charm, Divine, Implement- Standard - Ranged 10 - One Creature | Attack: +`WISIMP` vs Will\n"
+ "Hit: The target is dazed until the end of your next turn.  In addition, you can choose to knock the target prone or slide the target a number of squares equal to 3 +`CHAMOD`.";

        static string DauntingLight = "Daunting Light\n"
+ "Encounter - Divine, Implement, Radiant - Standard - Ranged 10 - One Creature | Attack: +`WISIMP` vs Reflex\n"
+ "2d10 +`WISMOD` radiant damage.\n"
+ "Effect: One ally you can see gains combat advantage against the target until the end of your next turn.";

        static string SplitTheSky = "Split the Sky\n"
+ "Encounter - Divine, Thunder, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs Fortitude\n"
+ "Hit: 1[W] +`STRMOD` thunder damage, and you push the target 2 squares and knock it prone.";

        static string[] cleric3Encounter = new string[] { BlazingBeacon, Command, DauntingLight, SplitTheSky };

        // Fighter Class Features
        static string combatChallenge = "When you attack a target, that target is marked until the end of your next turn.\nIf the target attacks a target other than you "
+ "they take a -2 penalty to the attack.\nIf a marked target adjacent to you makes an attack that does not include you or shifts you can make a basic melee attack against them.";

        static string combatSuperiority = "You gain a +`WISMOD` bonus to opportunity attacks and the enemy stops moving";

        static string fighterWeaponTalent = "Gain +1 bonus to attack rolls";


        // Fighter At-Wills
        static string Cleave = "Cleave\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs. AC\n"
+ "Hit: 1[W] +`STRMOD` damage, and an enemy adjacent to you takes `STRMOD` damage.";

        static string ReapingStrike = "Reaping Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs. AC\n"
+ "Hit: 1[W] +`STRMOD` damage.\n"
+ "Miss: `STRMOD` divided by 2 if you are wielding a one hand weapon, or `STRMOD` damage if you are wielding a two handed weapon.";

        static string SureStrike = "Sure Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` + 2 vs. AC\n"
+ "Hit: 1[W] damage.";

        static string TideOfIron = "Tide Of Iron\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon (must be wielding a shield) - One Creature | Attack: +`STRWEA` vs. AC\n"
+ "Hit: 1[W] +`STRMOD` damage and you push the target one square if it is smaller, your size, or one size larger.  You then can shift"
+ " into the space that the target occupied.";

        static string[] fighterAtWill = new string[] { Cleave, ReapingStrike, SureStrike, TideOfIron };

        // Fighter Encounter abilities
        static string CoveringAttack = "Covering Attack\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage and an ally adjacent to the target can shift 2 squares.";

        static string PassingAttack = "Passing Attack\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage and you can shift 1 square.  Make a secondary attack.\n"
+ "Secondary Target: One creature other than the primary Target - Secondary Attack `STRWEA` + 2 vs AC.\n"
+ "Hit: 1[W] +`STRMOD` damage";

        static string SpinningSweep = "Spinning Sweep\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage and you knock the target prone.";

        static string SteelSerpentStrike = "Steel Serpent Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage and the target is slowed and cahnot shift until the end of your next turn.";

        static string[] fighterEncounter = new string[] { CoveringAttack, PassingAttack, SpinningSweep, SteelSerpentStrike };

        // Fighter level 2 Utility
        static string GetOverHere = "Get Over Here\n"
+ "Encounter - Martial - Move - Melee 1 - One willing ally\n"
+ "Effect: You slide the target 2 squares to a square that is adjacent to you.";

        static string NoOpening = "No Opening\n"
+ "Encounter - Martial - Immediate Interrupt - Personal\n"
+ "Trigger: An enemy attacks you and has combat advantage against you"
+ "Effect: Cancel the combat advantage you were about to grant to the attack.";

        static string[] fighter2Utility = new string[] { GetOverHere, NoOpening };

        // Fighter level 3 Encounter
        static string ArmorPiercingThrust = "Armor-Piercing Thrust\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs Reflex\n"
+ "Hit: 1[W] +`STRMOD` damage. If you're wielding a light blade or spear, do bonus +`DEXMOD` damage.";

        static string CrushingBlow = "Crushing Blow\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage. If you're wielding an axe, a hammer, or a mace, , do bonus +`CONMOD` damage.";

        static string DanceOfSteel = "Dance of Steel\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage. If you're wielding a polearm or heavy blade, the target is slowed until the end of your next turn.";

        static string PreciseStrike = "Precise Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` +4 vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage.";

        static string RainOfBlows = "Rain of Blows\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC, two attacks\n"
+ "Hit: 1[W] +`STRMOD` damage. If you're wielding a light blade, spear, or flail and have Dex of 15+ make a Secondary Attack.\n"
+ "Hit: 1[W] +`STRMOD` damage";

        static string SweepingBlow = "Sweeping Blow\n"
+ "Encounter - Martial, Weapon - Standard - Close burst 1 - Each enemy in burst you can see | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage. If you're wielding a light blade, spear, or flail and have Dex of 15+ make a Secondary Attack.\n"
+ "If your wielding an axe, flail, heavy blade, or pick you gain a bonus to the attack roll of `STRMOD` / 2"
+ "Hit: 1[W] +`STRMOD` damage";

        static string[] fighter3Encounter = new string[] { ArmorPiercingThrust, CrushingBlow, DanceOfSteel, PreciseStrike, RainOfBlows, SweepingBlow };


        // Ranger Specials
        static string HuntersQuarry = "Once per turn as a minor action you can designate the enemy nearest to you as your quarry.  Once per round \n"
+ "you do a bonus 1d6 damage extra damage to that target.";
        static string PrimeShot = "If none of your allies are nearer to your target than you are, you recieve a +1 bonus to ranged attacks against that target.";

        // Ranger At-Wills
        static string CarefulAttack = "Careful Attack\n"
+ "At-Will - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) + 2 vs AC\n"
+ "Hit: 1[W] damage.\n";

        static string HitandRun = "Hit and Run\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage.  Effect: If you move this turn the target you do not provoke an opportunity attack\n "
+ "for your first square.";

        static string NimbleStrike = "Nimble Strike\n"
+ "At-Will - Martial, Weapon - Standard - Ranged Weapon - One Creature | Attack: +`DEXWEA` vs AC\n"
+ "Special: Shift 1 square before or after you attack\n"
+ "Hit: 1[W] +`DEXMOD` damage.";

        static string TwinStrike = "Twin Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee or Ranged Weapon - One or Two Creature | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC, two attacks\n"
+ "Hit: 1[W] per attack\n";

        static string[] rangerAtWill = new string[] { CarefulAttack, HitandRun, NimbleStrike, TwinStrike };

        // Ranger Encounters
        static string DireWolverineStrike = "Dire Wolverine Strike\n"
+ "Encounter - Martial, Weapon - Standard - Close burst 1 - Each enemy in burst | Attack: `STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage.\n";

        static string EvasiveStrike = "Evasive Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature | (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC\n"
+ "Special: You can shiftup to 1 +`WISMOD` square before or after you attack\n"
+ "Hit: 2[W] +`STRMOD` (Melee) or 2[W] +`DEXMOD` (Ranged)\n";

        static string FoxCunning = "Fox's Cunning\n"
+ "Encounter - Martial, Weapon - Immediate Reaction - Melee or Ranged Weapon\n"
+ "Trigger: An enemy makes a melee attack against you\n"
+ "Special You can shift 1 square, then make a basic attack against the enemy with a power bonus of `WISMOD`\n";

        static string TwoFangedStrike = "Two-Fanged Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC, two attacks \n"
+ "Hit: 1[W] +`STRMOD` (Melee) or 1[W] +`DEXMOD` damage per attack.  If both attacks hit deal +`WISMOD` extra damage.\n";

        static string[] rangerEncounter = new string[] { DireWolverineStrike, EvasiveStrike, FoxCunning, TwoFangedStrike };

        // Ranger Level 2 Utility
        static string CrucialAdvice = "Crucial Advice\n"
+ "Encounter - Martial - Immediate Interrupt - Ranged 5\n"
+ "Trigger: An ally within range that you can see or hear makes a skill check using a skill in which you're trained"
+ "Effect: Grant the ally the ability to reroll the skill check, with a +`WISMOD` power bonus.";

        static string UnbalancingParry = "Unbalancing Parry\n"
+ "Encounter - Martial, Weapon - Immediate Reaction - Melee 1\n"
+ "Trigger: An enemy misses you with a melee attack.\n"
+ "Effect: Slide the enemy into a square adjacent to you and gain combat advantage against it until the end of your next turn.";

        static string YieldGround = "Yield Ground\n"
+ "Encounter - Martial - Immediate Reaction - Personal\n"
+ "Trigger: An enemy damages you with a melee attack.\n"
+ "Effect: You can shift up to `WISMOD` squares.  Gain a +2 power bonus to all defenses until the end of your next turn.";

        static string[] ranger2Utility = new string[] { CrucialAdvice, UnbalancingParry, YieldGround };

        // Ranger Level 3 Encounter
        static string CutandRun = "Cut and Run\n"
+ "Encounter - Martial, Weapon - Standard - Melee or Ranged Weapon - One or Two Creature | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC, two attacks\n"
+ "Special: After the first or second attack, you can shift up to 1 + `WISMOD` squares.\n"
+ "Hit: 1[W] +`STRMOD` (Melee) or 1[W] +`DEXMOD` damage per attack.\n";

        static string DisruptiveStrike = "Disruptive Strike\n"
+ "Encounter - Martial, Weapon - Immediate Interrupt - Melee or Ranged Weapon - The attacking Creature | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC\n"
+ "Trigger: You or an ally is attacked by a creature.\n"
+ "Hit: 1[W] +`STRMOD` (Melee) or 1[W] +`DEXMOD` damage per attack.  The target takes a 3 + `WISMOD` penalty to the triggering attack roll.\n";

        static string ShadowWaspStrike = "Shadow Wasp Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature that is your quarry | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC\n"
+ "Hit: 2[W] +`STRMOD` (Melee) or 2[W] +`DEXMOD` damage.\n";

        static string ThundertuskBoarStrike = "Thundertusk Boar Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee or Ranged Weapon - One or Two Creature | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC\n"
+ "Hit: 1[W] +`STRMOD` (Melee) or 1[W] +`DEXMOD` damage per attack.  With each hit, you push the target 1 square.  If both attacks hit the same target \n"
+ "you push the target 1 + `WISMOD` squares.\n";

        static string[] ranger3Encounter = new string[] { CutandRun, DisruptiveStrike, ShadowWaspStrike, ThundertuskBoarStrike };

    } // end class ArchType
} // end NameSpace
