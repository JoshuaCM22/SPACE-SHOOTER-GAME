   M S B A M L   `   `   `  ����M  ISPACE SHOOTER GAME, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SPACE_SHOOTER_GAMESPACE_SHOOTER_GAME  5   	   ,    &SPACE_SHOOTER_GAME.Window_Introduction   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SPACE_SHOOTER_GAME     5   	   -   5          � Title$  SPACE SHOOTER��5	   	   $	��650��6   $	��540��6,    � 
ResizeMode$ CanMinimize=�68   .��5
      �� -   5        $��MyCanvas��5
      $
|�True��6   
���   �.+�5   
   �� -   5        $��	titleText��5      $��SPACE SHOOTER��6!   $��50(�69   $
��Bold"�6G   
������� �� Left$ 63��6l   
 �� Top$ 28��6}   �� 5   
   $��/Images/player.png��6   $	��100��6,   $��80��68   $	 208��6D   $	 118��6V   �� 5   
   -   5        $��lblInstructions��5      $��18(�6   $����Instructions: Shoot all the enemies as long as you can. 
Avoid to escape them and to collide in you to prevent
decrease your health points. When your health points
is 0, the game is over. ��65   ���#02B2B2$��Normal"�6  $	 225��61  $ 43��6B  $	��124��6S  �� 5   
   -   5        $��lblControls��5   3   $��18(�6   ���#02B2B2$y��sControls:  Left Arrow Key = Move Left
                Right Arrow Key = Move Right
                Spacebar = Shoot��6F   $��Normal"�6�   $	 341��6�   $	 105��6�   $	��112��6  �� 5   
   -   5        $��btnPlay��5      $
��PLAY��6    
�������$��16(�6B   $
��Bold"�6P    � Cursor$
 Hand��6y   $	 170��6�   $	 448��6�   $��48��6�   $	��193��6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#02B2B263   �� 5       � �� 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� #��z��6)   
���   �$��1q�6g   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value$
 True��69   . �5       ��  � �� �#05DBDB6;   5!      5#      5%      �� 5'   
   -   5        $��btnHighScores��5'      $��HIGH SCORES��6&   
�������$��16(�6O   $
��Bold"�6]   $
 Hand��6�   $	 170��6�   $	 509��6�   $��48��6�   $	��193��6�   ��5(      �� 5)      " ��6   .�5*      ��  � �� �#02B2B263   �� 5+       � �� 5,      �� 5-      " ��6.   .R�5.   "   �� #��z��6)   
���   �$��1q�6g   ._�5/   &   �� $��Center=�67   $��Center=�6T   50   #   51      53      	 54      P� 55      
 �@J�IsMouseOver$
 True��69   . �56      ��  � �� �#05DBDB6;   57      59      5;      �� 5=   
   -   5        $��btnAudio��5=      $��50��6!   $��50��6,   
������ $
 Hand��6i   $	 473��6w   $	 560��6�   .��5>      �� $/��)pack://application:,,,/Images/unmuted.png��6   ��5?      �� 5@      " ��6   .�5A      ��  � �� 5B      �� 5C      " ��6.   .R�5D   "   �� #��z��6)   
���   �$��1q�6g   ._�5E   &   �� $��Center=�67   $��Center=�6T   5F   #   5G      5I      5J      5L      5P      5Q      