   M S B A M L   `   `   `  ����D  @GifPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GifPlayer	GifPlayer  5   	       GifPlayer.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   '	gifPlayerclr-namespace:GifPlayer  5   	   -   5          �Name$  MainWindowInstance��5   (    � Title$ 
GIF Player��5   	   $	��250��6   $	��350��6,   $	��450��6;   $	��600��6H    � Icon$ Images/film_icon.png��5   	    � 	Resources 5
      '   !GifPlayer.StringToDoubleConverter   StringToDoubleConverter��%   &	          5   
   6,   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5         �Name$ ImageBackground��5      $��0��6(   .+�5      �� -   5         ��Name$ GifImage��5      $��0��6&   $��Uniform=�63   "  WpfAnimatedGif.ImageBehavior   RepeatBehavior$ Forever��5         AnimatedSource 5      �� *	GifSource+5      �� 5      -   5        	 ��Name$	 ShowHidePanelButton��5   "   $��0��6   $��30��6c   $��20��6n   $��Bottom=�6z   
������ $��0q�6�   .��5      �� -   5        $ CollapseExpandIcon��5      $��Images/collapse_icon.png��64   6X   5      5      � 5    
   -   5        $ MainStackPanel��5       $��1��6'   $��Stretch=�64   $��10q�6R   ��5!      �� 5"      
 �� Color$

 Gray��6"    �� Opacity$ .1Q�6/    5%      �� 5&      6"   �� 5'      6"   .+�5*      � $��0��6   $��0, 0, 0, 10q�6    $��15��65    � ColumnDefinitions 5+      �� 5,      $��* �6'   63   �� 5-      $
��Auto �6'   66   .+�51      � $��0��6   .+�52      � $��0��6"   $��5��6/   ${�False��56   "   $|�False��64    J� IsHitTestVisible$ False��6F    � Minimum 53   "   �� *	Minimum+ �� ElementName$ ProgressSlider�� � Maximum 54   "   �� *	Maximum+$ ProgressSlider�� � Value 55   "   �� *Value+$ ProgressSlider����57      �� 58      $
 DeepSkyBlue��6.   5:      �� 5<      -   5         ��Name$ ProgressSlider��5<   *   $��0��6   $��10��6B   $ 0Q�6N   $ 0Q�6Z   $ 0Q�6f    �� IsSnapToTickEnabled$
 True��6p    �� TickFrequency$ 1Q�6�   ��5>      �� 5?       �� 
TargetType" ��6.   .R�5@   "   � .+�5A   &   ]� $��
PART_Track��6,    ]� Thumb 5B   *   n� 5C   .   ��5D   2   �� 5E   6   " n�6F   .R�5F   :   � .+�5G   >   ��  ��Name$ 	ThumbRect��6H   
�������
�������$��1��6z   $��-5, -5, -5,-5q�6�   �� 5H   >   $��Center=�5I   H   $��Center=�6e   ��5H   H   �� *Value+ �� RelativeSource ��  �� AncestorType" ��5I   e   5J   ;    �� Triggers 5L   :   P� 5M   >    P� Property �@J�IsMouseOver P� Value$
 True��6]   . �5N   B   ��  �� 
TargetName$ 	ThumbRect��6I    �� Property � �� �� Value
 ��ح�6p   5O   ?   5Q   7   5S   /   5U   '   5V   #   5W      5Y      5Z      �� 5[      $��1��6   $��
10, 0, 0,0q�6a   $��Center=�6u   ��6,   �� *	Maximum+$ ProgressSlider��6u   5\      �� 5^      $��1��6   
���   �$��1q�66     �� CornerRadius$  5��6J   ._�5_      �� $
��Auto=�6   .��5`      �� ! �� Orientation$! 
Horizontal=�6!   $��Center=�6:   $
��Auto��6W   .+�5a      �� -   5        $��5q�5a   !   $��30��6,   $��30��68   .��5b      �� $��Images/image_icon.png��6$   6E   5c      �� 5d      " � LayoutTransform" 5e      �� 5f   "   # �� Angle$# 90Q�62   5h      �� 5i      -	   5        $	 
StopButton��5i   !   $��
5, 5, 0, 5q�6H   $��30��6\   $��30��6h   .��5j      �� $��Images/stop_icon.png��6$   6D   5k      �� 5l      $��40��6!   $��40��6-   $��
5, 5, 5, 5q�68   
���   �$��1q�6`   $  5��6t   ��6�   �� *
Background+$ 
StopButton��._�5m      �� -
   5        $��35��5m   =   $��35��6I   $��0q�6T   
������ .��5n   "   �� -   5        $ PlayPauseIcon��5n   (   $��Images/play_icon.png��6?   6_   5o      5p      �� 5q      " 5r      �� 5s   "   $# 90Q�62   5u      �� 5v      $��Images/speed_icon.png��6    $��30��6?   $��30��6J   $��
0, 0, 5, 0q�6V   6l   �� 5w      -   5        $ ��Name$$ SpeedMinTextBox��5w   "   $	��0.1��6;   $��Center=�6F   6�   �� 5x      -   5        $ SpeedSlider��5x   !   $	��150��66   $ 1Q�5z   !   $
 True��5|   !   $��Center=�6<    5x   B   �� *Text+$ SpeedMinTextBox��% �� 	Converter#% [   5y   !   �� *Text+$ SpeedMaxTextBox��#% [   5{   !   �� *Text+$ SpeedStepTextBox��#% [  5|   <   �� 5}      -   5        $$ SpeedMaxTextBox��5}   "   $��2��6;   $��Center=�6D   6�   �� 5~      -   5        & ��Name$& SpeedValueText��5~   $   $��1,00x��6<   $��15��6I   $��5, 0, 10, 0q�6W   $��Center=�6l   �� 5      $��Images/step_icon.png��6    $��20��6>   $��20��6I   $��
0, 0, 5, 0q�6U   6k   �� 5�      -   5        $$ SpeedStepTextBox��5�   "   $
��0.01��6<   $��Center=�6H   6�   �� 5�      $��
5, 0, 5, 0q�6$   " 5�      �� 5�   "   $# 90Q�62   5�      �� 5�      -   5        $��30��5�   !   $��30��6,   .��5�      �� $��Images/fill_icon.png��6$   $��20��6B   $��20��6M   6[   5�      �� 5�      -   5        $��30��5�   !   $��30��6,   .��5�      �� $��Images/bg_image_icon.png��6$   $��20��6F   $��20��6Q   6_   5�      �� 5�      -   5        $��30��5�   !   $��30��6,   .��5�      �� $"��Images/color_picker_icon.png��6$   $��20��6J   $��20��6U   6c   5�      5�      5�      5�      5�      5�      5�      