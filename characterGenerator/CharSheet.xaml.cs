using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace characterGenerator
{
    /// <summary>
    /// Interaction logic for CharSheet.xaml
    /// </summary>

    public partial class CharSheet : Window
    {
        public int Level { get; set; }
        public String Type { get; set; }

        //Archtype archtype;

        String name, skills, languages;
        int hp, numSurge, weaponProf, armor, shield;
        bool light;

        RaceTemplate Race;
        ArchType Job;
        int[] ldefenses;
        int[] lstats;
        int[] lstatsMod;
        List<String> racialAbilities;
        List<String> jobAbilities;
        List<String> racialSpecials;
        List<String> jobSpecials;

        static string[] prof3Weapons = new string[] { "Dagger", "Longsword", "Short sword", "Falchion", "Bastard sword", "Katar", "Rapier", "Spiked Chain", "Shuriken" };

        static string[] lightArmor = new string[] { "Cloth", "Leather", "Hide" };


        public CharSheet(int level, String race, String type)
        {
            InitializeComponent();
            Level = level;
            Type = type;
            Race = new RaceTemplate(race);
            Job = new ArchType(type, level);

            ldefenses = new int[4];
            lstats = new int[6];
            lstatsMod = new int[6];

            racialAbilities = new List<string>();
            jobAbilities = new List<string>();
            racialSpecials = new List<string>();
            jobSpecials = new List<string>();
            skills = "";

            foreach (string language in Race.Languages)
            {
                languages += language + ", ";
            }

            foreach (String skill in Job.ArchTypeSkills)
            {
                skills += skill + ", ";
            }
            foreach (String skill in Race.RacialSkills)
            {
                if (!skills.Contains(skill))
                {
                    skills += skill + ", ";
                }
            }
            
            for (int i = 0; i < lstats.Length; i++)
            {
                lstats[i] = Job.Stats[i] + Race.Stats[i];
                if (lstats[i] < 10)
                {
                    lstatsMod[i] = (lstats[i] - 11) / 2;
                }
                else
                {
                    lstatsMod[i] = (lstats[i] - 10) / 2;
                }
            }

            for (int i = 0; i < ldefenses.Length; i++)
            {
                ldefenses[i] = Job.Defenses[i];
            }

            if (lightArmor.Contains(Job.armor))
            {
                if (lstatsMod[2] > lstatsMod[3])
                {
                    ldefenses[0] = ldefenses[0] + lstatsMod[2];
                }
                else
                {
                    ldefenses[0] = ldefenses[0] + lstatsMod[3];
                }
            }

            if (lstatsMod[0] > lstatsMod[1])
            {
                ldefenses[1] = ldefenses[1] + lstatsMod[0];
            }
            else
            {
                ldefenses[1] = ldefenses[1] + lstatsMod[1];
            }

            if (lstatsMod[2] > lstatsMod[3])
            {
                ldefenses[2] = ldefenses[2] + lstatsMod[2];
            }
            else
            {
                ldefenses[2] = ldefenses[2] + lstatsMod[3];
            }

            if (lstatsMod[4] > lstatsMod[5])
            {
                ldefenses[3] = ldefenses[3] + lstatsMod[4];
            }
            else
            {
                ldefenses[3] = ldefenses[3] + lstatsMod[5];
            }

            hp = Job.HP + lstats[1] ;
            numSurge = Job.HealingSurges + lstatsMod[1];

            String abilities = "";
            foreach (String ability in Job.ArchTypeAbilities)
            {
                abilities += ability + "\n\n";
            }
            foreach (String ability in Race.RacialAbilities)
            {
                abilities += ability + "\n\n";
            }

            String specials = "";
            foreach (String special in Job.ArchTypeSpecial)
            {
                specials += "-" + special + "\n";
            }
            foreach (String special in Race.RacialSpecial)
            {
                specials += "-" + special + "\n";
            }

            if (prof3Weapons.Contains(Job.mainHand)) weaponProf = 4 + ((Level - 1) / 5);
            else weaponProf = 3 + ((Level - 1) / 5);

            abilities = abilities.Replace("`STRMOD`", lstatsMod[0].ToString());
            abilities = abilities.Replace("`CONMOD`", lstatsMod[1].ToString());
            abilities = abilities.Replace("`DEXMOD`", lstatsMod[2].ToString());
            abilities = abilities.Replace("`INTMOD`", lstatsMod[3].ToString());
            abilities = abilities.Replace("`WISMOD`", lstatsMod[4].ToString());
            abilities = abilities.Replace("`CHAMOD`", lstatsMod[5].ToString());

            abilities = abilities.Replace("`HALFLEVEL`", (Level / 2).ToString());

            specials = specials.Replace("`STRMOD`", lstatsMod[0].ToString());
            specials = specials.Replace("`CONMOD`", lstatsMod[1].ToString());
            specials = specials.Replace("`DEXMOD`", lstatsMod[2].ToString());
            specials = specials.Replace("`INTMOD`", lstatsMod[3].ToString());
            specials = specials.Replace("`WISMOD`", lstatsMod[4].ToString());
            specials = specials.Replace("`CHAMOD`", lstatsMod[5].ToString());

            specials = specials.Replace("`HALFLEVEL`", (Level / 2).ToString());

            abilities = abilities.Replace("`STRWEA`", (lstatsMod[0] + weaponProf).ToString());
            abilities = abilities.Replace("`CONWEA`", (lstatsMod[1] + weaponProf).ToString());
            abilities = abilities.Replace("`DEXWEA`", (lstatsMod[2] + weaponProf).ToString());
            abilities = abilities.Replace("`INTWEA`", (lstatsMod[3] + weaponProf).ToString());
            abilities = abilities.Replace("`WISWEA`", (lstatsMod[4] + weaponProf).ToString());
            abilities = abilities.Replace("`CHAWEA`", (lstatsMod[5] + weaponProf).ToString());

            specials = specials.Replace("`STRWEA`", (lstatsMod[0] + weaponProf).ToString());
            specials = specials.Replace("`CONWEA`", (lstatsMod[1] + weaponProf).ToString());
            specials = specials.Replace("`DEXWEA`", (lstatsMod[2] + weaponProf).ToString());
            specials = specials.Replace("`INTWEA`", (lstatsMod[3] + weaponProf).ToString());
            specials = specials.Replace("`WISWEA`", (lstatsMod[4] + weaponProf).ToString());
            specials = specials.Replace("`CHAWEA`", (lstatsMod[5] + weaponProf).ToString());

            abilities = abilities.Replace("`STRIMP`", (lstatsMod[0] + 1 + ((Level - 1) / 5)).ToString());
            abilities = abilities.Replace("`CONIMP`", (lstatsMod[1] + 1 + ((Level - 1) / 5)).ToString());
            abilities = abilities.Replace("`DEXIMP`", (lstatsMod[2] + 1 + ((Level - 1) / 5)).ToString());
            abilities = abilities.Replace("`INTIMP`", (lstatsMod[3] + 1 + ((Level - 1) / 5)).ToString());
            abilities = abilities.Replace("`WISIMP`", (lstatsMod[4] + 1 + ((Level - 1) / 5)).ToString());
            abilities = abilities.Replace("`CHAIMP`", (lstatsMod[5] + 1 + ((Level - 1) / 5)).ToString());

            specials = specials.Replace("`STRIMP`", (lstatsMod[0] + 1 + ((Level - 1) / 5)).ToString());
            specials = specials.Replace("`CONIMP`", (lstatsMod[1] + 1 + ((Level - 1) / 5)).ToString());
            specials = specials.Replace("`DEXIMP`", (lstatsMod[2] + 1 + ((Level - 1) / 5)).ToString());
            specials = specials.Replace("`INTIMP`", (lstatsMod[3] + 1 + ((Level - 1) / 5)).ToString());
            specials = specials.Replace("`WISIMP`", (lstatsMod[4] + 1 + ((Level - 1) / 5)).ToString());
            specials = specials.Replace("`CHAIMP`", (lstatsMod[5] + 1 + ((Level - 1) / 5)).ToString());

            labelLanguageValue.Content = languages;
            labelSizevalue.Content = Race.Size;

            labelName.Content = "               ";
            labelClass.Content = Job.Name;
            labelLevel.Content = "Level " + Level;
            labelRace.Content = Race.Name;
            labelSpeedValue.Content = Race.Speed + Job.Speed;
            labelInitiativeValue.Content = lstatsMod[2];
            labelHpValue.Content = hp;
            labelBloodiedValue.Content = hp / 2;
            labelSurgeNumValue.Content = numSurge;
            labelSurgeValue.Content = hp / 4;
            labelStrValue.Content = lstats[0];
            labelConValue.Content = lstats[1];
            labelDexValue.Content = lstats[2];
            labelIntValue.Content = lstats[3];
            labelWisValue.Content = lstats[4];
            labelChaValue.Content = lstats[5];
            labelStrModValue.Content = "(+" + lstatsMod[0] + ")";
            labelConModValue.Content = "(+" + lstatsMod[1] + ")";
            labelDexModValue.Content = "(+" + lstatsMod[2] + ")";
            labelIntModValue.Content = "(+" + lstatsMod[3] + ")";
            labelWisModValue.Content = "(+" + lstatsMod[4] + ")";
            labelChaModValue.Content = "(+" + lstatsMod[5] + ")";
            labelSkillsValue.Content = skills;
            labelAbilities.Content = abilities;
            labelSpecialsValue.Content = specials;
            labelACValue.Content = (ldefenses[0] + 11 + (Level / 2) + ((Level - 1) / 5)).ToString();
            labelFortValue.Content = (ldefenses[1] + 10 + (Level / 2)).ToString();
            labelRefValue.Content = (ldefenses[2] + 10 + (Level / 2)).ToString();
            labelWillValue.Content = (ldefenses[3] + 10 + (Level / 2)).ToString();
            labelArmorValue.Content = Job.armor;
            labelMainHandValue.Content = Job.mainHand;
            labelOffHandValue.Content = Job.offHand;
            labelImplementValue.Content = Job.implement;
            labelRangedWeaponValue.Content = Job.ranged;

        } // end constructor
    } // end class
} // end namespace
