   M S B A M L   `   `   `  ����M  ISPACE SHOOTER GAME, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SPACE_SHOOTER_GAMESPACE_SHOOTER_GAME  5   	   *    $SPACE_SHOOTER_GAME.Window_HighScores   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SPACE_SHOOTER_GAME     5   	   -   5          � Title$  SPACE SHOOTER��5	   	   $	��560��6    $	��525��6-    � 
ResizeMode$ CanMinimize=�69   .��5
      �� -   5        $��MyCanvas��5
      $
|�True��6   
���   �.+�5   
   �� -   5        $��lblTitle��5      $��30(�6   $��HIGH SCORES��6.   
�������$
��Bold"�6W   
 �� Top$ 13��6i    �� Left$	 150��6y   $	��112��6�   �� 5   
   -   5        $��lblTop10Only��5      $��23(�6   $��Top 10 only��62   ���#02B2B2$
��Bold"�6]   $ 63��6o   $	 193��6   $	��112��6�   �� 5   
   -   5        $��lblRankHeaderAndContent��5      $��20(�6   $
��Rank��6>   
�������$��Normal"�6`   $	 110��6t   $ 60��6�   $	��315��6�   �� 5   
   -   5        $��lblDateHeaderAndContent��5      $��20(�6   $��	     Date��6=   
�������$��Normal"�6d   $	 110��6x   $	 193��6�   $	��315��6�   �� 5   
   -   5        $��lblScoreHeaderAndContent��5      $��20(�6   $��Score��6>   
�������$��Normal"�6a   $	 110��6u   $	 382��6�   $	��315��6�   �� 5   
   -   5        $��btnBack��5      $
��BACK��6    
�������$��16(�6B   $
��Bold"�6P    � Cursor$
 Hand��6b   $ 20��6�   $	 455��6�   $��48��6�   $	��130��6�    J� RenderTransformOrigin$ 0,0.479&�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#02B2B263   �� 5       � �� 5      �� 5      	 �� 
TargetType"	 ��6.   .R�5   "   �� #��z��6)   
���   �$��1q�6g   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      
 �� Triggers
 5      P� 5        P� Property �@J�IsMouseOver P� Value$
 True��69   . �5!      ��  � �� �#05DBDB6;   5"      5$      5&      5(      5)      