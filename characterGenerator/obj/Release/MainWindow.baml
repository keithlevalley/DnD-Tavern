   M S B A M L   `   `   `  ���� M  IcharacterGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:characterGeneratorcharacterGenerator  #    characterGenerator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:characterGenerator       � Title$  
MainWindow��$	��800��$
��1280��.��� .+��� .+��� $
��Auto��$
��Auto��.+��� -   $��Header��$��Center=�$��10,10,10,10q�$
��Bold"�$��Italic$�.��%#DnD 4th Edition Character Generator��  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��NoCharsText��$
��Left=�.��No. of Characters?�� -   $��comboBoxNumChars��.@���  �� 
IsSelected . .��10�� .��9�� .��8�� .��7�� .��6�� .��5�� .��4�� .��3�� .��2�� .��1�� -   $��NoLvText��$
��Left=�.��Level of Characters?�� -   $��comboBoxLevel��.@���  . .��1�� .��2�� .��3�� .��4�� .��5�� .��6�� .��7�� .��8�� .��9�� .��10�� .��11�� .��12�� .��13�� .��14�� .��15�� .��16�� .��17�� .��18�� .��19�� .��20�� .��21�� .��22�� .��23�� .��24�� .��25�� .��26�� .��27�� .��28�� .��29�� .��30�� .��31�� .��32�� .��33�� .��34�� .��35�� .��36�� .��37�� .��38�� .��39�� .��40�� $ 
Horizontal=�$��Center=�$
��Auto��$
��Auto��.+��� .��Role:�� .��Damage�� -   $��
DamageRole��$��25�� �� TextAlignment$ Center=�$��Center=��� .��	Defense�� -   $��DefenseRole��$��25��$ Center=�$��Center=��� .��	Control�� -   $��ControlRole��$��25��$ Center=�$��Center=��� .��Leader�� -	   $��
LeaderRole��$��25��$ Center=�$��Center=��� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��Elf�� -
    ��Name$ 	sliderElf�� � Minimum$ 0Q� � Maximum$ 10Q�$��5,5,5,5q�$	��200���� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��Human�� -   $ sliderHuman��$ 0Q�$ 10Q�$��5,5,5,5q�$	��200���� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��Dwarf�� -   $ sliderDwarf��$ 0Q�$ 10Q�$��5,5,5,5q�$	��200���� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��	Eladrin�� -   $ sliderEladrin��$ 0Q�$ 10Q�$��5,5,5,5q�$	��200���� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��Dragon Born�� -   $ sliderDragonBorn��$ 0Q�$ 10Q�$��5,5,5,5q�$	��200���� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��
Halfling�� -   $ sliderHalfling��$ 0Q�$ 10Q�$��5,5,5,5q�$	��200���� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��
Half Elf�� -   $ sliderHalfElf��$ 0Q�$ 10Q�$��5,5,5,5q�$	��200���� $ 
Horizontal=�$
��Auto��.+��� $
��Left=�$��	230,5,5,5q�$	��350��.��
Tiefling�� -   $ sliderTiefling��$ 0Q�$ 10Q�$��5,5,5,5q�$	��200���� -   $��SubmitButton��$	��100��$��50��$��Bottom=�$��10,10,10,10q�$��10,50,10,10q�.��Submit