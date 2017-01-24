using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace characterGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random rand = new Random();
        List<CharSheet> charSheets;
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //***************************************************************//
            //                      Define Objects                           //
            //***************************************************************//

            int[] roles = new int[4];

            List<int> selectRace = new List<int>();
            charSheets = new List<CharSheet>();

            int numChars = Int32.Parse(comboBoxNumChars.Text);

            int level = Int32.Parse(comboBoxLevel.Text);
            String race = "";
            String type = "";
            String archType = "";

            int levelVariance = (int)(level * .1) + 1;

            Random rand = new Random();
            if (!Directory.Exists("charSheets"))
            {
                Directory.CreateDirectory("charSheets");
            }

            //***************************************************************//
            //                         Data Validation                       //
            //***************************************************************//

            try { roles[0] = Int32.Parse(DamageRole.Text); }

            catch (Exception) { roles[0] = 0; }

            try { roles[1] = Int32.Parse(DefenseRole.Text); }

            catch (Exception) { roles[1] = 0; }

            try { roles[2] = Int32.Parse(ControlRole.Text); }

            catch (Exception) { roles[2] = 0; }

            try { roles[3] = Int32.Parse(LeaderRole.Text); }

            catch (Exception) { roles[3] = 0; }

            //**************************************************************//
            //                   Build Select Race List                     //
            //**************************************************************//

            selectRace.Add((int)sliderElf.Value);
            selectRace.Add((int)sliderHuman.Value + selectRace[0]);
            selectRace.Add((int)sliderDwarf.Value + selectRace[1]);
            selectRace.Add((int)sliderEladrin.Value + selectRace[2]);
            selectRace.Add((int)sliderDragonBorn.Value + selectRace[3]);
            selectRace.Add((int)sliderHalfling.Value + selectRace[4]);
            selectRace.Add((int)sliderHalfElf.Value + selectRace[5]);
            selectRace.Add((int)sliderTiefling.Value + selectRace[6]);

            //***************************************************************//
            //                     Create Char Sheet                         //
            //***************************************************************//

            for (int i = 0; i < numChars; i++)
            {
                level = Int32.Parse(comboBoxLevel.Text) + ((rand.Next(levelVariance + 1)) * (rand.Next(3) - 1));
                if (level == 0) level = 1;

                int temp;

                try
                {
                    temp = rand.Next(1, selectRace.Last() + 1);
                }
                catch (Exception)
                {
                    temp = 0;
                }

                if (temp <= selectRace[0])
                {
                    race = "Elf";
                }
                else if (temp <= selectRace[1])
                {
                    race = "Human";
                }
                else if (temp <= selectRace[2])
                {
                    race = "Dwarf";
                }
                else if (temp <= selectRace[3])
                {
                    race = "Eladrin";
                }
                else if (temp <= selectRace[4])
                {
                    race = "DragonBorn";
                }
                else if (temp <= selectRace[5])
                {
                    race = "Halfling";
                }
                else if (temp <= selectRace[6])
                {
                    race = "HalfElf";
                }
                else if (temp <= selectRace[7])
                {
                    race = "Tiefling";
                }
                else race = "Human";

                /*
                while (roles.Sum() < numChars)
                {
                    for (int j = 0; j < roles.Length; j++)
                    {
                        roles[j]++;
                    }
                }*/

                //bool loop = true;

                if (roles[0] > 0)
                {
                    type = "Damage";
                    roles[0]--;
                }
                else if (roles[1] > 0)
                {
                    type = "Defense";
                    roles[1]--;
                }
                /*
                else if (roles[2] > 0)
                {
                    type = "Control";
                }*/
                else if (roles[3] > 0)
                {
                    type = "Leader";
                    roles[3]--;
                }
                else
                {
                    switch (rand.Next(4))
                    {
                        case 0:
                            type = "Damage";
                            break;
                        case 1:
                            type = "Defense";
                            break;
                        case 2:
                            type = "Damage";
                            break;
                        case 3:
                            type = "Leader";
                            break;
                        default:
                            break;
                    }
                } // end else

                /*
                while (loop)
                {
                    temp = rand.Next(4);

                    if (temp == 0 && roles[temp] > 0)
                    {
                        roles[temp]--;
                        type = "Damage";
                        loop = false;
                    }
                    if (temp == 1 && roles[temp] > 0)
                    {
                        roles[temp]--;
                        type = "Defense";
                        loop = false;
                    }
                    if (temp == 2 && roles[temp] > 0)
                    {
                        roles[temp]--;
                        type = "Control";
                        loop = false;
                    }
                    if (temp == 3 && roles[temp] > 0)
                    {
                        roles[temp]--;
                        type = "Leader";
                        loop = false;
                    }
                } // end while
                */

                if (type == "Damage")
                {
                    switch (rand.Next(3))
                    {
                        case 0:
                            archType = "Warlock";
                            break;
                        case 1:
                            archType = "Ranger";
                            break;
                        case 2:
                            archType = "Rogue";
                            break;
                        default:
                            break;
                    }
                }

                else if (type == "Defense")
                {
                    switch (rand.Next(2))
                    {
                        case 0:
                            archType = "Fighter";
                            break;
                        case 1:
                            archType = "Paladin";
                            break;
                        default:
                            break;
                    }
                }

                else if (type == "Leader")
                {
                    switch (rand.Next(2))
                    {
                        case 0:
                            archType = "Cleric";
                            break;
                        case 1:
                            archType = "Warlord";
                            break;
                        default:
                            break;
                    }
                }

                charSheets.Add(new CharSheet(level, race, archType));
            } // end for

            PrintDialog pd = new PrintDialog();

            if (pd.ShowDialog() == true)
            {
                foreach (CharSheet item in charSheets)
                {
                    item.Show();
                    pd.PrintVisual(item, "");
                    item.Close();
                }
            }
        } // end submit

    } // end main Window Class
} // end namespace
