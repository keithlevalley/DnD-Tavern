   M S B A M L   `   `   `  ���� M  IcharacterGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:characterGeneratorcharacterGenerator  "    characterGenerator.CharSheet   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:characterGenerator       � Title$  	CharSheet��$
��1900��$
��1440��$��12(�.��� .+���  �� Orientation$ Vertical=�$��10,0,0,0q�.+��� -   $��	basicInfo��$ 
Horizontal=�$
��Left=�.+��� -    ��Name$ 	labelName��$
��Name���� -   $ 
labelLevel��$��Level���� -   $ 	labelRace��$
��Race���� -   $ 
labelClass��$��Class���� -   $��miscInfo��$ 
Horizontal=�$
��Left=�.+��� -   $ labelLanguage��$��Languages Spoken:���� -   $ labelLanguageValue��$��Level���� -	   $ 	labelSize��$��Size:���� -
   $ labelSizevalue��$��Medium���� -   $��defenses��$ 
Horizontal=�$
��Left=�.+��� -   $ LabelDefense��$��	Defenses:��$
��Bold"��� -   $ labelAC��$��AC���� -   $ labelACValue��$��15���� -   $ 	labelFort��$
��Fort���� -   $ labelFortValue��$��15���� -   $ labelRef��$	��Ref���� -   $ labelRefValue��$��15���� -   $ 	labelWill��$
��Will���� -   $ labelWillValue��$��15���� -   $ 
labelSpeed��$��Speed:��$
��Bold"�$��50,0,0,0q��� -   $ labelSpeedValue��$��15���� -   $ labelInitiative��$��Initiative:��$
��Bold"�$��50,0,0,0q��� -   $ labelInitiativeValue��$��15���� -   $��health��$ 
Horizontal=�.+��� -   $ labelHp��$��Max Hit Points:��$
��Bold"��� -   $ labelHpValue��$��15���� -   $ labelBloodied��$��	Bloodied:��$
��Bold"��� -   $ labelBloodiedValue��$��15���� -   $ labelSurgeNum��$��Number of Healing Surges:��$
��Bold"��� -   $ labelSurgeNumValue��$��15���� -    $ 
labelSurge��$��Healing Surge Value��$
��Bold"��� -!   $ labelSurgeValue��$��15���� -"   $��stats��$ 
Horizontal=�.+��� -#   $ labelStr��$
��Str:��$
��Bold"��� -$   $ labelStrValue��$��15���� -%   $ labelStrModValue��$
��(+1)���� -&   $ labelCon��$
��Con:��$
��Bold"��� -'   $ labelConValue��$��15���� -(   $ labelConModValue��$
��(+1)���� -)   $ labelDex��$
��Dex:��$
��Bold"��� -*   $ labelDexValue��$��15���� -+   $ labelDexModValue��$
��(+1)���� -,   $ labelInt��$
��Int:��$
��Bold"��� --   $ labelIntValue��$��15���� -.   $ labelIntModValue��$
��(+1)���� -/   $ labelWis��$
��Wis:��$
��Bold"��� -0   $ labelWisValue��$��15���� -1   $ labelWisModValue��$
��(+1)���� -2   $ labelCha��$
��Cha:��$
��Bold"��� -3   $ labelChaValue��$��15���� -4   $ labelChaModValue��$
��(+1)���� -5   $��	equipment��$ 
Horizontal=�.+��� -6   $ 
labelArmor��$��Armor:��$
��Bold"��� -7   $ labelArmorValue��$��	chainmail���� -8   $ labelMainHand��$��
Main Hand:��$
��Bold"��� -9   $ labelMainHandValue��$
��Mace���� -:   $ labelOffHand��$��	Off Hand:��$
��Bold"��� -;   $ labelOffHandValue��$��shield���� -<   $ labelRangedWeapon��$��Ranged Weapon:��$
��Bold"��� -=   $ labelRangedWeaponValue��$��Long Bow���� ->   $ labelImplement��$��
Implement:��$
��Bold"��� -?   $ labelImplementValue��$��Holy Symbol���� $ 
Horizontal=�.+��� -@   $ labelSkills��$��Skills��$
��Bold"�$
��Left=��� -A   $ labelSkillsValue��$��List of Skills���� .+��� -B   $ labelSpecials��$��Special Features��$
��Bold"�$
��Left=��� -C   $ labelSpecialsValue��$��List of Special Features���� .+��� -D   $ labelAbility��$��	Abilities��$
��Bold"�$
��Left=��� -E   $ labelAbilities��$��	Abilities��$
��Left=�