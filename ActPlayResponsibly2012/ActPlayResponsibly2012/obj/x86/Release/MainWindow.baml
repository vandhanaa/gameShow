   M S B A M L   `   `   `  ���� Q  MActPlayResponsibly2012, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ActPlayResponsibly2012ActPlayResponsibly2012  S.clr-namespace:ActPlayResponsibly2012.Questions ActPlayResponsibly2012.Questions  [2clr-namespace:ActPlayResponsibly2012.FlashMessages$ActPlayResponsibly2012.FlashMessages  '    !ActPlayResponsibly2012.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6local$clr-namespace:ActPlayResponsibly2012     D	questions.clr-namespace:ActPlayResponsibly2012.Questions     LflashMessages2clr-namespace:ActPlayResponsibly2012.FlashMessages     -   
���   �  � AllowsTransparency  .  � Title$! Act & Play Responsibly 2012��$	��768��$
��1024�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � WindowStyle$
 None=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ Close�� � 	Resources  �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName   
TeamAvatar<   6ActPlayResponsibly2012.BooleanNOTToVisibilityConverter # BooleanNOTToVisibilityConverter;   5ActPlayResponsibly2012.TeamAvatarBorderBrushConverter " TeamAvatarBorderBrushConverter   BooleanToVisibilityConverter  DiceStoryboard g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  BackgroundImageStoryboard��%=  '��       'd� �    &	      &	 �    &	 �    &	 �    &	 �    &	 `    �� " ��.��� 	 � ��$
 Center=��� 	 � ��$
 Center=��� 	 � ��$
 5q��� 	 � ��

 �   ��� 	 � ��

 ������� 	 � ��$
 16(��� 	 � ��

 ������� 	 � ��$
 3q��� 	 � ��
 �� " ��.R��� $ Border��#��z��#��z��#��z��._��� #��z��#��z��#��z�� P�  � �� . . ��� $ Border��	 � ��

 ������� 	 � ��

 �   ��� " d�.��� 	 � ��

 �   ��� 	 � ��

 ������� 	 � ��$
 16(��� 	 � ��

 ������� 	 � ��$
 3q��� 	 � ��
 �� " d�.R��� $ Border��#��z��#��z��#��z��._��� #��z��#��z��#��z�� P�  � �� . . ��� $ Border��	 � ��

 ������� 	 � ��

 �   �P�  �@d�	IsChecked$
 TrueY�. ��� $ Border��	 � ��

 ������� 	 � ��

 �   ��� " ��.��� 	 � ��$	
 Top=��� 	 � ��$

 Left=��� 	 � ��$
 30���� 	 � ��

 �   ��� 	 � ��$
 3q�    �� �� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�$ label��.\�  $ 0��$ 0Q�  $ 0:0:0.2��$	 360Q��� $ Forever��.��U� $ (UIElement.Opacity)�$ image��.\�  $ 0��$ 1Q�  $ 0:0:3��$	 0.3Q�  $ 0:0:8��$ 1Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[ .��� .+��� -    ��Name$ image��$
��Fill=����� *CurrentTeam.Background+]� ��. .+�� $	��Top=�.+��� -   $��Center=�$��Center=�$#��Act (& Play) Responsibly 2012��
�������
������ $��36(�#��["��$��Normal"��� -   $
��45,5q�$��30��$�� ��$
��Bold"�
���  ��$	��Top=�$��Right=�
������ �� $��5q�$��30��$��X��$
��Bold"�
���  ��$	��Top=�$��Right=�$��Close��
������ � $
��Left=� � ColumnDefinitions �� �� $	��300 �.+��� -   $	��650��$	��650��$��0��
������ .+��� -   $ 	GameBoard��$	��650��$	��650������ *CurrentTeam.GameBoard+� $��1�� � RowDefinitions �� $	��300 ��� �� $	��200 �.+�� $��0��$��10q� �� �� $
��Auto ��� $
��Auto �.+�� $��0��$��Center=�$��Center=� �� �� $
��Auto �.+��� $��0��$��5q����� *CurrentTeam.Id+ �� 	Converter# [ ._��� $	��150��$��Center=�$��Center=����� *CurrentTeam.Avatar+�� $��1��$��Center=�$��Center=�$��0,0,0,5q�$��18(�
����������� *CurrentTeam.Name+�� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��65��$��3q�$
��Pass��
 � Tag$ 
Lifeline 1��y��� *CurrentTeam.LifeLine1+# [ �� -	   $��65��$��3q�$
��Halt��$ 
Lifeline 2��y��� *CurrentTeam.LifeLine2+# [ �� -
   $��65��$��3q�$��Deflect��$ 
Lifeline 3��y��� *CurrentTeam.LifeLine3+# [ �� -   $��65��$��3q�$
��Jump��$ 
Lifeline 4��y��� *CurrentTeam.LifeLine4+# [ �� $��2��$ 
Horizontal=�$��Center=�.+��� $	��100��$
��10,0q�$��	Next Turn������ *NextTurnCommand+d� $	��100��$
��10,0q�$
��Hard�� d� 	IsChecked �� *CurrentTeam.IsHardQuestion+�� -   $��1��$��10q�$	��150��$	��150��
������ $��0q����� *ThrowDiceCommand+.���  �� �� $
��Auto �.+��� -    ��Name$ label��$��0��$	��100��$	��100��$��Center=�  J� RenderTransformOrigin$  0.5,0.5&����� *	DiceImage+z�V� .~��� �� �� T� �� $��1��$��30��$��Bottom=�$ 
Horizontal=�.+��� -   $��1q�
������ ! J� Opacity$	! 0.1Q�$��30��$��30��$ FlashMessage 1���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 2���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 3���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 4���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 5���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 6���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 7���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 8���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 9���� -   $��1q�
������ $	! 0.1Q�$��30��$��30��$ FlashMessage 10��� $��2��$��10q� �� �� ��  �� �� $
��0.5* ��� $
��0.5* �.+��� $��0��$��0��$��Current Team��
�������$��18(�$��Center=��� $��0��$��1��$��5q����� * CurrentTeamMoveBackwardCommand+.���� $=��7/ActPlayResponsibly2012;component/Images/Teams/Down.png���� $��0��$��2��$��5q����� *CurrentTeamMoveForwardCommand+.���� $;��5/ActPlayResponsibly2012;component/Images/Teams/Up.png���� $��1��$��0��$��	All Teams��
�������$��18(�$��Center=��� $��1��$��1��$��5q����� *AllTeamsMoveBackwardCommand+.���� $=��7/ActPlayResponsibly2012;component/Images/Teams/Down.png���� $��1��$��2��$��5q����� *AllTeamsMoveForwardCommand+.���� $;��5/ActPlayResponsibly2012;component/Images/Teams/Up.png���� -   " ��Name$" TeamMoveSelector��$��2��$��0��$��5q�$��Center=����� *Teams+���� ���� .R��� $ 
Horizontal=�$��3q�.+��� $��30������ *Avatar+�� $��Center=����� *Name+���� # �� Color$# White���� $��2��$��1��$��5q����� *TeamMoveBackwardCommand+���� *SelectedItem+$ �� ElementName$$ TeamMoveSelector��.���� $=��7/ActPlayResponsibly2012;component/Images/Teams/Down.png���� $��2��$��2��$��5q����� *TeamMoveForwardCommand+���� *SelectedItem+$$ TeamMoveSelector��.���� $;��5/ActPlayResponsibly2012;component/Images/Teams/Up.png���� $	��650��$	��650��.+��� -   $��Question��
% �� Top$	% 510��& �� Left$& 90��$	��100��$��50��$
 Gray��
��������� -   $��0q�$	% 575��$& 77��$��50��$��50��$
 Gray��
������ �� -   $��0q�$	% 575��$	& 127��$��50��$��50��$
 Gray��
������ �� -   $��0q�$	% 575��$	& 177��$��50��$��50��$
 Gray��
������ �� -   $��0q�$	% 575��$	& 227��$��50��$��50��$
 Gray��
������ �� -   $��0q�$	% 575��$	& 277��$��50��$��50��$ Chance��
������ �� -   $��0q�$	% 575��$	& 327��$��50��$��50��$
 Gray��
������ �� -    $��0q�$	% 575��$	& 377��$��50��$��50��$
 Gray��
������ �� -!   $��0q�$	% 575��$	& 427��$��50��$��50��$
 Gray��
������ �� -"   $��0q�$	% 575��$	& 477��$��50��$��50��$
 Gray��
������ �� -#   $��0q�$	% 575��$	& 527��$��50��$��50��$
 Gray��
������ �� -$   $��0q�$	% 575��$	& 577��$��50��$��50��$ Chance��
������ �� -%   $��0q�$	% 525��$	& 577��$��50��$��50��$
 Gray��
������ �� -&   $��0q�$	% 475��$	& 577��$��50��$��50��$
 Gray��
������ �� -'   $��0q�$	% 425��$	& 577��$��50��$��50��$
 Gray��
������ �� -(   $��0q�$	% 375��$	& 577��$��50��$��50��$
 Gray��
������ �� -)   $��0q�$	% 325��$	& 577��$��50��$��50��$ Chance��
������ �� -*   $��0q�$	% 275��$	& 577��$��50��$��50��$
 Gray��
������ �� -+   $��0q�$	% 225��$	& 577��$��50��$��50��$
 Gray��
������ �� -,   $��0q�$	% 175��$	& 577��$��50��$��50��$
 Gray��
������ �� --   $��0q�$	% 125��$	& 577��$��50��$��50��$
 Gray��
������ �� -.   $��0q�$% 75��$	& 577��$��50��$��50��$
 Gray��
������ �� -/   $��0q�$% 25��$	& 577��$��50��$��50��$ Chance��
������ �� -0   $��0q�$% 25��$	& 527��$��50��$��50��$
 Gray��
������ �� -1   $��0q�$% 25��$	& 477��$��50��$��50��$
 Gray��
������ �� -2   $��0q�$% 25��$	& 427��$��50��$��50��$
 Gray��
������ �� -3   $��0q�$% 25��$	& 377��$��50��$��50��$
 Gray��
������ �� -4   $��0q�$% 25��$	& 327��$��50��$��50��$ Chance��
������ �� -5   $��0q�$% 25��$	& 277��$��50��$��50��$
 Gray��
������ �� -6   $��0q�$% 25��$	& 227��$��50��$��50��$
 Gray��
������ �� -7   $��0q�$% 25��$	& 177��$��50��$��50��$
 Gray��
������ �� -8   $��0q�$% 25��$	& 127��$��50��$��50��$
 Gray��
������ �� -9   $��0q�$% 25��$& 77��$��50��$��50��$
 Gray��
������ �� -:   $��0q�$% 25��$& 27��$��50��$��50��$ Chance��
������ �� -;   $��0q�$% 75��$& 27��$��50��$��50��$
 Gray��
������ �� -<   $��0q�$	% 125��$& 27��$��50��$��50��$
 Gray��
������ �� -=   $��0q�$	% 175��$& 27��$��50��$��50��$
 Gray��
������ �� ->   $��0q�$	% 225��$& 27��$��50��$��50��$
 Gray��
������ �� -?   $��0q�$	% 275��$& 27��$��50��$��50��$ Chance��
������ �� -@   $��0q�$	% 325��$& 27��$��50��$��50��$
 Gray��
������ �� -A   $��0q�$	% 375��$& 27��$��50��$��50��$
 Gray��
������ �� -B   $��0q�$	% 425��$& 27��$��50��$��50��$
 Gray��
������ �� -C   $��0q�$	% 475��$& 27��$��50��$��50��$
 Gray��
������ �� -D   $��0q�$	% 525��$& 27��$��50��$��50��$
 Gray��
������ �� -E   ' ��Name$' DragableContent��$	��650��$	��650��$��0��
������ ( J� IsHitTestVisible( .  .+��� #��[  
���  ��& �� *RedTeam.CurrentPosition.X+) �� Mode$) OneWay=�% �� *RedTeam.CurrentPosition.Y+$) OneWay=�._��� -F   $ 	RedAvatar��$@��:/ActPlayResponsibly2012;component/Images/Teams/RedTeam.png���� #��[  
��� d �& �� *GreenTeam.CurrentPosition.X+$) OneWay=�% �� *GreenTeam.CurrentPosition.Y+$) OneWay=�._��� -G   $ GreenAvatar��$B��</ActPlayResponsibly2012;component/Images/Teams/GreenTeam.png���� #��[  
����  �& �� *BlueTeam.CurrentPosition.X+$) OneWay=�% �� *BlueTeam.CurrentPosition.Y+$) OneWay=�._��� -H   $ 
BlueAvatar��$A��;/ActPlayResponsibly2012;component/Images/Teams/BlueTeam.png���� #��[  
��� ���& �� *YellowTeam.CurrentPosition.X+$) OneWay=�% �� *YellowTeam.CurrentPosition.Y+$) OneWay=�._��� -I   $ YellowAvatar��$C��=/ActPlayResponsibly2012;component/Images/Teams/YellowTeam.png��3   -ActPlayResponsibly2012.Questions.QuestionView  -J   *  Name$* QuestionView��$��2��$	��650��$y�	Collapsed=�+ � DataContext+ �� *CurrentQuestion+;   5ActPlayResponsibly2012.FlashMessages.FlashMessageView  -K   ,  Name$, FlashMessageView��$��2��$	��600��$	��200��$y�	Collapsed=�+ �� *CurrentFlashMessage+