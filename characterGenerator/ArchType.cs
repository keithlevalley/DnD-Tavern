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

        List<string[]> tempList = new List<string[]>();

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
                    createWarlord(); //temp for test
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
            
            ArchTypeAbilities.Add(ChannelDivinityTurnUndead);
            ArchTypeAbilities.Add(HealingWord);

            atWillBuilder(clericAtWill);

            tempList.Add(clericEncounter);

            if (Level > 1)
            {
                tempList.Add(cleric2Utility);
            }
            if (Level > 2)
            {
                tempList[0] = cleric3Encounter;
            }

            abilityBuilder(tempList);
            
        } // end createCleric

        private void createWarlock()
        {
            Name = "Warlock";
            armor = "Leather";
            mainHand = "dagger";
            offHand = "";
            ranged = "";
            implement = "Rod";

            ArchTypeSpecial.Add(PrimeShot);
            ArchTypeSpecial.Add(WarlocksCurse);
            ArchTypeSpecial.Add(ShadowWalk);

            Stats[0] = 10 + allStatModier(Level);
            Stats[1] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[2] = 10 + allStatModier(Level);
            Stats[3] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[4] = 12 + allStatModier(Level);
            Stats[5] = 18 + primStatModier(Level) + allStatModier(Level);

            Defenses[0] = 2;
            Defenses[2] = 1;
            Defenses[3] = 1;
            Speed = 0;

            HP = 12 + 5 * (Level);
            HealingSurges = 6;

            ArchTypeSkills.Add("Arcana");
            ArchTypeSkills.Add("Bluff");
            ArchTypeSkills.Add("History");
            ArchTypeSkills.Add("Insight");
            ArchTypeSkills.Add("Intimidate");
            ArchTypeSkills.Add("Religion");
            ArchTypeSkills.Add("Streetwise");

            ArchTypeAbilities.Add(EldritchBlast);
            ArchTypeAbilities.Add(warlockAtWill[MainWindow.rand.Next(warlockAtWill.Count())]);

            tempList.Add(warlockEncounter);

            if (Level > 1)
            {
                tempList.Add(warlock2Utility);
            }
            if (Level > 2)
            {
                tempList[0] = warlock3Encounter;
            }

            abilityBuilder(tempList);
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

            atWillBuilder(fighterAtWill);

            tempList.Add(fighterEncounter);

            if (Level > 1)
            {
                tempList.Add(fighter2Utility);
            }
            if (Level > 2)
            {
                tempList[0] = fighter3Encounter;
            }

            abilityBuilder(tempList);

        } // end fighter

        private void createPaladin()
        {
            Name = "Paladin";
            armor = "Plate";
            mainHand = "Longsword";
            offHand = "Heavy Shield";
            ranged = "";
            implement = "Divine Symbol";

            Stats[0] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 14 + allStatModier(Level);
            Stats[2] = 12 + allStatModier(Level);
            Stats[3] = 10 + allStatModier(Level);
            Stats[4] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[5] = 16 + primStatModier(Level) + allStatModier(Level);

            Defenses[0] = 9;
            Defenses[1] = 1;
            Defenses[2] = 1;
            Defenses[3] = 1;
            Speed = -2;

            HP = 15 + 6 * (Level);
            HealingSurges = 10;

            ArchTypeSkills.Add("Religion");
            ArchTypeSkills.Add("Diplomacy");
            ArchTypeSkills.Add("Endurance");
            ArchTypeSkills.Add("Heal");
            ArchTypeSkills.Add("Intimidate");

            ArchTypeAbilities.Add(ChannelDivinityDivineMettle);
            ArchTypeAbilities.Add(ChannelDivinityDivineStrength);
            ArchTypeAbilities.Add(DivineChallenge);
            //ArchTypeAbilities.Add(LayOnHands);

            atWillBuilder(paladinAtWill);

            tempList.Add(paladinEncounter);

            if (Level > 2)
            {
                tempList[0] = paladin3Encounter;
            }

            abilityBuilder(tempList);
        }

        private void createWizard()
        {
            Name = "generic";
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

            atWillBuilder(rangerAtWill);

            tempList.Add(rangerEncounter);

            if (Level > 1)
            {
                tempList.Add(ranger2Utility);
            }
            if (Level > 2)
            {
                tempList[0] = ranger3Encounter;
            }

            abilityBuilder(tempList);

        }

        private void createRogue()
        {
            Name = "Rogue";
            armor = "Leather";
            mainHand = "Dagger";
            offHand = "";
            ranged = "Hand Crossbow";
            implement = "";

            ArchTypeSpecial.Add(FirstStrike);
            ArchTypeSpecial.Add(ArtFulDodger);
            ArchTypeSpecial.Add(RogueWeaponTalent);
            ArchTypeSpecial.Add(SneakAttack);

            Stats[0] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 12 + allStatModier(Level);
            Stats[2] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[3] = 12 + allStatModier(Level);
            Stats[4] = 14 + allStatModier(Level);
            Stats[5] = 16 + primStatModier(Level) + allStatModier(Level);

            Defenses[0] = 2;
            Defenses[2] = 2;
            Speed = 0;

            HP = 12 + 5 * (Level);
            HealingSurges = 6;

            ArchTypeSkills.Add("Stealth");
            ArchTypeSkills.Add("Thievery");
            ArchTypeSkills.Add("Acrobatics");
            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Dungeoneering");
            ArchTypeSkills.Add("Perception");
            ArchTypeSkills.Add("Streetwise");
            
            atWillBuilder(rogueAtWill);

            tempList.Add(rogueEncounter);

            if (Level > 1)
            {
                tempList.Add(rogue2Utility);
            }
            if (Level > 2)
            {
                tempList[0] = rogue3Encounter;
            }

            abilityBuilder(tempList);
        }

        private void createWarlord()
        {
            Name = "Warlord";
            armor = "Chainmail";
            mainHand = "Longsword";
            offHand = "light shield";
            ranged = "";
            implement = "";
            ArchTypeSpecial.Add(CombatLeader);
            ArchTypeSpecial.Add(CommandingPresence);

            Stats[0] = 18 + primStatModier(Level) + allStatModier(Level);
            Stats[1] = 12 + allStatModier(Level);
            Stats[2] = 12 + allStatModier(Level);
            Stats[3] = 16 + primStatModier(Level) + allStatModier(Level);
            Stats[4] = 12 + allStatModier(Level);
            Stats[5] = 16 + primStatModier(Level) + allStatModier(Level);

            Defenses[0] = 6;
            Defenses[1] = 1;
            Defenses[2] = 1;
            Defenses[3] = 1;
            Speed = -1;

            HP = 12 + 5 * (Level);
            HealingSurges = 7;

            ArchTypeSkills.Add("Athletics");
            ArchTypeSkills.Add("Diplomacy");
            ArchTypeSkills.Add("Endurance");
            ArchTypeSkills.Add("Heal");
            ArchTypeSkills.Add("History");
            ArchTypeSkills.Add("Intimidate");

            ArchTypeAbilities.Add(InspiringWord);
            atWillBuilder(warlordAtWill);

            tempList.Add(warlordEncounter);

            if (Level > 1)
            {
                tempList.Add(warlord2Utility);
            }
            if (Level > 2)
            {
                tempList[0] = warlord3Encounter;
            }

            abilityBuilder(tempList);
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

        private void atWillBuilder(string[] atWills)
        {
            int count = 0;
            do
            {
                int temp = MainWindow.rand.Next(atWills.Count());
                if (!ArchTypeAbilities.Contains(atWills[temp]))
                {
                    ArchTypeAbilities.Add(atWills[temp]);
                    count++;
                }
            } while (count != 2);
        }

        private void abilityBuilder(List<string[]> abilityList)
        {
            foreach (var ability in abilityList)
            {
                this.ArchTypeAbilities.Add(
                    ability[MainWindow.rand.Next(ability.Count())]);
            }
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


        // Paladin Class Features

        static string ChannelDivinityDivineMettle = "Channel Divinity: Divine Mettle\n"
+ "Encounter - Divine - Minor - Close burst 10 - One creature in burst\n"
+ "Effect: The target makes a saving throw with a +`CHAMOD` bonus to the roll.";

        static string ChannelDivinityDivineStrength = "Channel Divinity: Divine Strength\n"
+ "Encounter - Divine - Minor - Personal\n"
+ "Effect: Your next attack this turn does +`STRMOD` bonus damage.";

        static string DivineChallenge = "Divine Challenge\n"
+ "At-Will - Divine, Radiant - Minor - Close burst 5, One creature in burst\n"
+ "You mark the target.  The target remains marked until you mark another target.You must either attack the target on your turn or end your turn adjacent to it \n"
+ " or the target is no longer marked and you cannot use Divine Challenge on your next turn.  While the target is marked it takes a -2 penalty to any attack that \n"
+ "doesn't include you as the target and takes 3 + `CHAMOD` for the first attack that doesn't include you as the target.";

        static string LayOnHands = "Lay on Hands\n"
+ "At-Will - Divine, Healing - Minor - melee touch - One creature\n"
+ "Effect: You spend a healing surge but regain no hp.  Instead the target regains hit points as if it had spent a healing surge.\n"
+ "Special:  You can use this ability `WISMOD` times per day.";

        // Paladin At-Wills
        static string BolsteringStrike = "Bolstering Strike\n"
+ "At-Will - Divine, Weapon - Standard - Melee Weapon - One Creature | Attack: +`CHAWEA` vs. AC\n"
+ "Hit: 1[W] + `CHAMOD`, and you gain `WISMOD` temporary hp .";

        static string EnfeeblingStrike = "Enfeebling Strike\n"
+ "At-Will - Divine, Weapon - Standard - Melee Weapon - One Creature | Attack: +`CHAWEA` vs AC\n"
+ "Hit: 1[W] +`CHAMOD`.  If you marked the target, it takes a -2 penalty to attack rolls until the end of your next turn.";

        static string HolyStrike = "Holy Strike\n"
+ "At-Will - Divine, Radiant, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` radiant damage.  If you marked the target, you gain a +`WISMOD` bonus damage to the attack.";

        static string ValiantStrike = "Valiant Strike\n"
+ "At-Will - Divine, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` + 1 per enemy adjacent to you vs AC\n"
+ "Hit: 1[W] + `STRMOD` damage.";

        static string[] paladinAtWill = new string[] { BolsteringStrike, EnfeeblingStrike, HolyStrike, ValiantStrike };

        // Paladin Encounters
        static string FearsomeSmite = "Fearsome Smith\n"
+ "Encounter - Divine, Fear, Weapon - Standard - Melee Weapon - One Creature | Attack: +`CHAWEA` vs AC\n"
+ "Hit: 2[W] + `CHAMOD` damage.  Until the end of your next turn the target takes a -`WISMID` penalty to attack rolls.";

        static string PiercingSmite = "Piercing Smite\n"
+ "Encounter - Divine, Weapon - Standard - Melee weapon - One creature | Attack: +`STRWEA` vs Reflex\n"
+ "Hit: 2[W] +`STRMOD` damage, and `WISMOD` enemies adjacent to you are marked until the end of your next turn.\n";

        static string RadiantSmite = "Radiant Smite\n"
+ "Encounter - Divine, Radiant, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` +`WISMOD` radiant damage.";

        static string ShieldingSmite = "Shielding Smite\n"
+ "Encounter - Divine, Weapon - Standard - Melee Weapon - One Creature | Attack: +`CHAWEA` vs AC\n"
+ "Hit: 2[W] +`CHAMOD` Effect: Until the end of your next turn, one ally within 5 squares gains a +`WISMOD` bonus to AC.";

        static string[] paladinEncounter = new string[] { FearsomeSmite, PiercingSmite, RadiantSmite, ShieldingSmite };

        // Paladin Level 2 Utility Prayers
        static string SacredCircle = "Sacred Circle\n"
+ "Encounter - Divine, Implement, Zone - Standard - Close burst 3\n"
+ "Effect: The burst creates a zone that, until the end of your next turn gives you and allies within it a +1 bonus to AC.";

        static string[] paladin2Utility = new string[] { SacredCircle };

        // Paladin Level 3 Encounter Prayers
        static string ArcingSmite = "Arcing Smite\n"
+ "Encounter - Divine, Weapon - Standard - Melee Weapon - One or two Creatures | Attack: +`STRWEA` vs AC, one attack per target\n"
+ "Hit: 1[W] +`STRMOD` damage, and the target is marked until the end of your next turn.";

        static string InvigoratingSmite = "Invigorating Smite\n"
+ "Encounter - Divine, Healing, Weapon - Standard - Melee Weapon - One Creature | Attack: +`CHAWEA` vs Will\n"
+ "Hit: 2[W] + `CHAMOD` damage.  Bloodied allies within 5 squares (you included) regain 5 + `WISMOD` hp.";

        static string RighteousSmite = "Righteous Smite\n"
+ "Encounter - Divine, Healing, Weapon - Standard - Melee Weapon - One Creature | Attack: +`CHAWEA` vs AC\n"
+ "Hit: 2[W] +`CHAMOD` damage, and you and each ally within 5 squares gains 5 +`WISMOD` temporary hp\n";

        static string StaggeringSmite = "Staggering Smite\n"
+ "Encounter - Divine, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage, and you push the target `WISMOD` squares.";

        static string[] paladin3Encounter = new string[] { ArcingSmite, InvigoratingSmite, RighteousSmite, StaggeringSmite };

        // Rogue Specials
        static string FirstStrike = "At the start of the encounter, you have combat advantage against any creature that has not acted";

        static string ArtFulDodger = "You gain a +`CHAMOD` AC bonus against opportunity attacks.";

        static string RogueWeaponTalent = "When you wield a dagger, you gain a +1 bonus to attack rolls.";

        static string SneakAttack = "Once per round if you have combat advantage against the target.  You do 2d6 bonus damage to an attack.";

        // Rogue At-Wills
        static string DeftStrike = "Deft Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature | Attack: +`DEXWEA` vs AC\n"
+ "Hit: 1[W] +`DEXMOD` damage.  Special:  You can move 2 spaces before the attack.";

        static string PiercingStrike = "Piercing Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`DEXWEA` vs Reflex\n"
+ "Hit: 1[W] +`DEXMOD` damage.";

        static string RiposteStrike = "Riposte Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`DEXWEA` vs AC\n"
+ "Hit: 1[W] +`DEXMOD` damage.  If the target attacks you before your next turn you make an attack as an immediate interuppt.\n"
+ "Attack: +`STRWEA` vs AC and deals 1[W] + `STRMOD` damage.";

        static string SlyFlourish = "Sly Flourish\n"
+ "At-Will - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature | Attack: +`DEXWEA` vs AC\n"
+ "Hit: 1[W] +`DEXMOD` +`CHAMOD`\n";

        static string[] rogueAtWill = new string[] { DeftStrike, PiercingStrike, RiposteStrike, SlyFlourish };

        // Rogue Encounters
        static string DazingStrike = "Dazing Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`DEXWEA` vs AC\n"
+ "Hit: 1[W] +`DEXMOD` damage, and the target is dazed until the end of your next turn.";

        static string KingsCastle = "King's Castle\n"
+ "Encounter - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature | Attack: +`DEXWEA` vs Reflex\n"
+ "Hit: 2[W] +`DEXMOD` damage.  Effect: Switch places with a willing adjacent ally.";

        static string PositioningStrike = "Positioning Strike\n"
+ "Encounter - Martial, Weapon - Melee Weapon - One creature | Attack: +`DEXWEA` vs Will \n"
+ "Hit: 1[W] +`DEXMOD` damage, and you slide the target `CHAMOD` squares."
+ "Special You can shift 1 square, then make a basic attack against the enemy with a power bonus of `WISMOD`\n";
        
        static string[] rogueEncounter = new string[] { DazingStrike, KingsCastle, PositioningStrike };

        // Rogue Level 2 Utility
        static string FleetingGhost = "Fleeting Ghost\n"
+ "At-Will - Martial - Move - Personal\n"
+ "Effect: You can move your speed and make a Stealth check.  You do not take the normal penalty from movement on this check.";

        static string[] rogue2Utility = new string[] { FleetingGhost };

        // Ranger Level 3 Encounter
        static string BaitandSwitch = "Bait and Switch\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`DEXWEA` vs Will\n"
+ "Hit: 2[W] +`DEXMOD` damage.  In addition, you switch places with the target and can shift `CHAMOD` squares.";

        static string SetupStrike = "Disruptive Strike\n"
+ "Encounter - Martial, Weapon - Immediate Interrupt - Melee or Ranged Weapon - The attacking Creature | Attack: (+`STRWEA` (Melee) or `DEXWEA` (Ranged)) vs AC\n"
+ "Trigger: You or an ally is attacked by a creature.\n"
+ "Hit: 1[W] +`STRMOD` (Melee) or 1[W] +`DEXMOD` damage per attack.  The target takes a 3 + `WISMOD` penalty to the triggering attack roll.\n";

        static string ToppleOver = "Topple Over\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`DEXWEA` vs AC\n"
+ "Hit: 1[W] +`DEXMOD` damage, and the target is knocked prone.";

        static string TrickstersBlade = "Trickster's Blade\n"
+ "Encounter - Martial, Weapon - Standard - Melee or Ranged Weapon - One Creature | Attack: +`DEXWEA` vs AC\n"
+ "Hit: 2[W] +`DEXMOD`.  You gain a +`CHAMOD` bonus to AC until the start of your next turn."
+ "you push the target 1 + `WISMOD` squares.\n";

        static string[] rogue3Encounter = new string[] { BaitandSwitch, SetupStrike, ToppleOver, TrickstersBlade };


        // warlock Specials
        static string ShadowWalk = "On your turn, if you move at least 3 squares away from where you started your turn, you gain concealment until the end of your next turn.";

        static string WarlocksCurse = "Once per turn as a minor action you can place a Warlock's curse on the enemy nearest to you that you can see.  A cursed enemy is more \n"
+ "vulnerable to your attacks.  You may deal an additional 1d6 dmg to a cursed target, you may only do this to one target per round.";

        // Warlocks At-Wills
        static string DireRadiance = "Dire Radiance\n"
+ "At-Will - Arcane, Fear, Implement, Radiant - Standard - Ranged 10 - One Creature | Attack: +`CONIMP` vs Fortitude\n"
+ "Hit: 1d6 +`CONMOD` radiant damage.  If the target moved nearer to you on its next turn, it takes an additional 1d6 +`CONMOD` damage";

        static string EldritchBlast = "Eldritch Blast\n"
+ "At-Will - Arcane, Implement - Standard - Ranged 10 - One Creature | Attack: +(`CHAIMP` or `CONIMP`) vs Reflex\n"
+ "Hit: 1d10 +(`CHAMOD` or `CONMOD`) damage.  Special: This ability counts as a basic ranged attack.";

        static string Eyebite = "Eyebite\n"
+ "At-Will - Arcane, Charm, Implement, Psychic - Standard - Ranged 10 - One Creature | Attack: +`CHAIMP` vs Will\n"
+ "Hit: 1d6 +`CHAMOD` psychic damage and you are invisible to the target until the start of your next turn.";

        static string HellishRebuke = "Hellish Rebuke\n"
+ "At-Will - Arcane, Fire, Implement - Standard - Ranged 10 - One Creature | Attack: +`CONIMP` vs Reflex\n"
+ "Hit: 1d6 +`CONMOD` fire damage.  If you take damage before the end of your next turn, the target takes an extra \n"
+ "1d6 +`CONMOD` fire damage"            ;

        static string[] warlockAtWill = new string[] { DireRadiance, Eyebite, HellishRebuke };

        // Warlock Encounters
        static string DiabolicGrasp = "Diabolic Grasp\n"
+ "Encounter - Arcane, Implement - Standard - Ranged 10 - One Creature | Attack: +`CONIMP` vs Fortitude\n"
+ "Hit: 2d8 +`CONMOD` and you slide the target `INTMOD` squares.";

        static string DreadfulWord = "Dreadful Word\n"
+ "Encounter - Arcane, Fear, Implement, Psychic - Standard - Ranged 5 - One Creature | Attack: +`CHAIMP` vs Will\n"
+ "Hit: 2d8 +`CHAMOD` psychic damage and the target takes a 1+`INTMOD` penalty to will defense until the end of your next turn.";

        static string VampiricEmbrace = "Vampiric Embrace\n"
+ "Encounter - Arcane, Implement, Necrotic - Ranged 5 - One creature | Attack: +`CONIMP` vs Will\n"
+ "Hit: 2d8 +`CONMOD` necrotic damage and you gain 5 +`INTMOD` temporary hp.";

        static string Witchfire = "Witchfire\n"
+ "Encounter - Arcane, Implement, Fire - Ranged 10 - One creature | Attack: +`CHAIMP` vs Reflex\n"
+ "Hit: 2d6 +`CHAMOD` fire damage and the target takes a 2+`INTMOD` penalty to attack rolls until the end of your next turn.";

        static string[] warlockEncounter = new string[] { DiabolicGrasp, DreadfulWord, VampiricEmbrace, Witchfire };

        // Warlock Level 2 Utility
        static string BeguilingTongue = "Beguiling Tongue\n"
+ "Encounter - Arcane - Minor - Personal\n"
+ "Effect: You gain a +5 power bonus to your next Bluff, Diplomacy, or Intimidate check during this encounter.";

        static string EtherealStride = "Ethereal Stride\n"
+ "Encounter - Arcane, Teleportation - Move - Personal\n"
+ "Effect: You can teleport 3 squares and you gain a +2 power bonus to all defenses until the end of your next turn.";

        static string ShadowVeil = "Shadow Veil\n"
+ "Encounter - Arcane, Illusion - Minor - Personal\n"
+ "Effect: You gain a +5 power bonus to stealth checks until the end of your next turn.";

        static string[] warlock2Utility = new string[] { BeguilingTongue, EtherealStride, ShadowVeil };

        // Warlock Level 3 Encounter
        static string EldritchRain = "Eldritch Rain\n"
+ "Encounter - Arcane, Implement - Standard - Ranged 10 - One Creature or two creatues within 5 squares | Attack: +`CHAIMP` vs Reflex\n"
+ "Hit: 1d10 +`CHAMOD` damage gain a +`INTMOD` to each die roll.";

        static string FieryBolt = "Fiery Bolt\n"
+ "Encounter - Arcane, Fire, Implement - Standard - Ranged 10 - One Creature | Attack: +`CONIMP` vs Reflex\n"
+ "Hit: 3d6 +`CONMOD` fire damage, and creatures adjacent to the target take 1d6 +`CONMOD` +`INTMOD` fire damage.";

        static string FrigidDarkness = "Frigid Darkness\n"
+ "Encounter - Arcane, Cold, Fear, Implement - Standard - Ranged 10 - One Creature | Attack: +`CONIMP` vs Fortitude\n"
+ "Hit: 2d8 +`CONMOD` cold damage, and the target grants combat advantage until the end of your next turn.  The target takes a `INT` penalty to AC.";

        static string OtherwindStride = "Otherwind Stride\n"
+ "Encounter - Arcane, Implement, Teleportation - Standard - Close burst 1 - Each Creature in burst | Attack: +`CHAIMP` vs Fortitude\n"
+ "Hit: 1d8 +`CHAMOD` damage and the target is immobilized until the end of your next turn.  Effect: You teleport 5 +`INTMOD` squares.";

        static string[] warlock3Encounter = new string[] { EldritchRain, FieryBolt, FrigidDarkness, OtherwindStride };

        // Warlord Specials
        static string CombatLeader = "You and each ally within 10 squares who can see and hear you gain a +2 bonus to initiative.";

        static string CommandingPresence = "When an ally who can see you takes an extra action they heal `HALFLEVEL` + `CHAMOD`.  If that extra action is an attack \n"
+ "They may instead gain a +(`INTMOD` / 2 (rounded down)).";

        static string InspiringWord = "Inspiring Word\n"
+ "Encounter - Martial, Healing - Minor - Close burst 5 - You or one ally in burst\n"
+ "Effect: The target can spend a healing surge and regian an additional 1d6 hit points.  Special: You can use this power twice per encounter but only once per round.";

        // Warlords At-Wills
        static string CommandersStrike = "Commander's Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: An ally of your choice makes a melee basic attack against the target\n"
+ "Hit: Ally's basic attack damage +`INTMOD`";

        static string FuriousSmash = "Furious Smash\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs Fortitude\n"
+ "Hit: Deal `STRMOD` damage and choose an adjacent target to you or the target.  The ally gains a +`CHAMOD` bonus to attack and damage roll of the next attack against the target.";

        static string VipersStrike = "Viper's Strike\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage.  Effect: If the target shifts before the start of your next turn, it provokes an opportunity attack from an ally of your choice.";

        static string WolfPackTactics = "Wolf Pack Tactics\n"
+ "At-Will - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[w] +`STRMOD`.  Special: Before you attack, you let an ally adjacent to either you or the target shift 1 square as a free action.";

        static string[] warlordAtWill = new string[] { CommandersStrike, FuriousSmash, VipersStrike, WolfPackTactics };

        // Warlord Encounters
        static string GuardingAttack = "Guarding Attack\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage.  Until the end of your next turn, one ally adjacent to either you or the target gains +1 +`CHAMOD` bonus to AC against the target.";

        static string HammerAndAnvil = "Hammer and Anvil\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs Reflex\n"
+ "Hit: 1[W] +`STRMOD` damage.  One ally adjacent to the target makes a melee basic attack against the target.  The ally gets +`CHAMOD` to the damage role.";

        static string LeafOnTheWind = "Leaf on the Wind\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage.  You or an ally adjacent to the target swaps places with the target.";

        static string WarlordsFavor = "Warlord's Favor\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD`.  One ally within 5 squares of you gains +1 +`INTMOD` to attack rolls against the target until the end of your next turn.";

        static string[] warlordEncounter = new string[] { GuardingAttack, HammerAndAnvil, LeafOnTheWind, WarlordsFavor };

        // Warlord Level 2 Utility
        static string AidTheInjured = "Aid the Injured\n"
+ "Encounter - Healing, Martial - Standard - Melee touch - You or one adjacent ally\n"
+ "Effect: The target can spend a healing surge.";

        static string CrescendoOfViolence = "Crescendo of Violence\n"
+ "Encounter - Martial - Immediate Reaction - Ranged 5\n"
+ "Trigger: An ally within range scores a critical hit. Effect: The ally gains `CHAMOD` temporary hp.";

        static string KnightsMove = "Knight's Move\n"
+ "Encounter - Martial - Move - Ranged 10 - One ally\n"
+ "Effect: The target takes a move action as a free action.";

        static string ShakeIfOff = "Shake it Off\n"
+ "Encounter - Martial - Minor - Ranged 10 - You or one ally\n"
+ "Effect: The target makes a saving throw with a +`CHAMOD` bonus";

        static string[] warlord2Utility = new string[] { AidTheInjured, CrescendoOfViolence, KnightsMove, ShakeIfOff };

        // Warlord Level 3 Encounter
        static string HoldTheLine = "Hold the Line\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 1[W] +`STRMOD` damage.  Effect: Until the end of your next turn, allies adjacent to you gain a +2 bonus to AC and cannot be pulled, pushed, or slid.";

        static string InspiringWarCry = "Inspiring War Cry\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD`.  Effect: One ally who can hear you and is within 5 squares of you makes a saving throw.";

        static string SteelMonsoon = "Steel Monsoon\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One Creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage, and `INTMOD` allies within 5 squares of you can shift 1 square.";

        static string WarlordsStrike = "Warlord's Strike\n"
+ "Encounter - Martial, Weapon - Standard - Melee Weapon - One creature | Attack: +`STRWEA` vs AC\n"
+ "Hit: 2[W] +`STRMOD` damage.  Until the end of your next turn, all of your allies gain +1 +`INTMOD` to damage rolls against the target.";

        static string[] warlord3Encounter = new string[] { HoldTheLine, InspiringWarCry, SteelMonsoon, WarlordsStrike };



    } // end class ArchType
} // end NameSpace
