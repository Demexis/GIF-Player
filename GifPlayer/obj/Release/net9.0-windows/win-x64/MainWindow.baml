   M S B A M L   `   `   `  ���� D  @GifPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GifPlayer	GifPlayer      GifPlayer.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  '	gifPlayerclr-namespace:GifPlayer  -     �Name$  MainWindowInstance�� � Title$ 
GIF Player��$	��250��$	��350��$	��450��$	��600�� � Icon$ Images/film_icon.png�� � 	Resources '   !GifPlayer.StringToDoubleConverter   StringToDoubleConverter��%   &	          .���  � RowDefinitions �� $��* ��� $
��Auto �.+�� -    �Name$ ImageBackground��$��0��.+��� -    ��Name$ GifImage��$��0��$��Uniform=�"  WpfAnimatedGif.ImageBehavior   RepeatBehavior$ Forever��   AnimatedSource �� *	GifSource+�� -   	 ��Name$	 ShowHidePanelButton��$��0��$��30��$��20��$��Bottom=�
������ $��0q�.���� -   $ CollapseExpandIcon��$��Images/collapse_icon.png��� -   $ MainStackPanel��$��1��$��Stretch=�$��10q����� 
 �� Color$

 Gray�� �� Opacity$ .1Q� �� �� .+�� $��0��$��0, 0, 0, 10q�$��15�� � ColumnDefinitions �� $��* ��� $
��Auto �.+�� $��0��.+�� $��0��$��5��${�False��$|�False�� J� IsHitTestVisible$ False�� � Minimum �� *	Minimum+ �� ElementName$ ProgressSlider�� � Maximum �� *	Maximum+$ ProgressSlider�� � Value �� *Value+$ ProgressSlider������ $
 DeepSkyBlue���� -    ��Name$ ProgressSlider��$��0��$��10��$ 0Q�$ 0Q�$ 0Q� �� IsSnapToTickEnabled$
 True�� �� TickFrequency$ 1Q�����  �� 
TargetType" ��.R�� .+�]� $��
PART_Track�� ]� Thumb n� ���� " n�.R�� .+���  ��Name$ 	ThumbRect��
�������
�������$��1��$��-5, -5, -5,-5q��� $��Center=�$��Center=����� *Value+ �� RelativeSource ��  �� AncestorType" �� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ 	ThumbRect�� �� Property � �� �� Value
 ��ح��� $��1��$��
10, 0, 0,0q�$��Center=����� *	Maximum+$ ProgressSlider���� $��1��
���   �$��1q�  �� CornerRadius$  5��._��� $
��Auto=�.���� ! �� Orientation$! 
Horizontal=�$��Center=�$
��Auto��.+��� -   $��5q�$��30��$��30��.���� $��Images/image_icon.png���� " � LayoutTransform" �� # �� Angle$# 90Q��� -	   $	 
StopButton��$��
5, 5, 0, 5q�$��30��$��30��.���� $��Images/stop_icon.png���� $��40��$��40��$��
5, 5, 5, 5q�
���   �$��1q�$  5������ *
Background+$ 
StopButton��._��� -
   $��35��$��35��$��0q�
������ .���� -   $ PlayPauseIcon��$��Images/play_icon.png���� " �� $# 90Q��� $��Images/speed_icon.png��$��30��$��30��$��
0, 0, 5, 0q��� -   $ ��Name$$ SpeedMinTextBox��$	��0.1��$��Center=��� -   $ SpeedSlider��$	��150��$ 1Q�$
 True��$��Center=� �� *Text+$ SpeedMinTextBox��% �� 	Converter#% [   �� *Text+$ SpeedMaxTextBox��#% [   �� *Text+$ SpeedStepTextBox��#% [  �� -   $$ SpeedMaxTextBox��$��2��$��Center=��� -   & ��Name$& SpeedValueText��$��1,00x��$��15��$��5, 0, 10, 0q�$��Center=��� $��Images/step_icon.png��$��20��$��20��$��
0, 0, 5, 0q��� -   $$ SpeedStepTextBox��$
��0.01��$��Center=��� $��
5, 0, 5, 0q�" �� $# 90Q��� -   $��30��$��30��.���� $��Images/fill_icon.png��$��20��$��20���� -   $��30��$��30��.���� $��Images/bg_image_icon.png��$��20��$��20���� -   $��30��$��30��.���� $"��Images/color_picker_icon.png��$��20��$��20��