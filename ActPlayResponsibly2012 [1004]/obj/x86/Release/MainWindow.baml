   M S B A M L   `   `   `  ���� Q  MActPlayResponsibly2012, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ActPlayResponsibly2012ActPlayResponsibly2012  S.clr-namespace:ActPlayResponsibly2012.Questions ActPlayResponsibly2012.Questions  '    !ActPlayResponsibly2012.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6local$clr-namespace:ActPlayResponsibly2012     D	questions.clr-namespace:ActPlayResponsibly2012.Questions     -   
���   �  � AllowsTransparency  .  � Title$! Act & Play Responsibly 2012��$	��768��$
��1024�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � WindowStyle$
 None=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ Close�� � 	Resources  �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName   
TeamAvatar=   7ActPlayResponsibly2012.PromoteButtonVisibilityConverter $  PromoteButtonVisibilityConverter;   5ActPlayResponsibly2012.TeamAvatarBorderBrushConverter " TeamAvatarBorderBrushConverter   BooleanToVisibilityConverter  DiceStoryboard g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%�  '��       &	  [    &	 �    &	 �    &	 �    &	 �    �� " ��.��� 	 � ��$
 Center=��� 	 � ��$
 Center=��� 	 � ��$
 5q��� 	 � ��

 �   ��� 	 � ��

 ������� 	 � ��$
 16(��� 	 � ��
 �� " ��.R��� $ Border��
�������$��3q�#��z��._��� #��z��#��z��#��z�� P�  � �� . . ��� $ Border��	 � ��

 ������� 	 � ��

 �   ��� " ��.��� 	 � ��$	
 Top=��� 	 � ��$

 Left=��� 	 � ��$
 30���� 	 � ��

 �   ��� 	 � ��$
 3q�    �� �� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�$ label��.\�  $ 0��$ 0Q�  $ 0:0:0.2��$	 360Q�.��]� ��. .+�� $	��Top=�.+��� -   $��Center=�$��Center=�$!��Act & Play Responsibly 2012��
�������
������ $��36(�#��["��$��Normal"��� -   $
��45,5q�$��30��$�� ��$
��Bold"�
���  ��$	��Top=�$��Right=�
������ �� $��5q�$��30��$��X��$
��Bold"�
���  ��$	��Top=�$��Right=�$��Close��
������ � $
��Left=� � ColumnDefinitions �� �� $	��300 �.+�� -    �Name$ DragableContent��$	��600��$	��600��$��0��
������ .+��� -    ��Name$ 	GameBoard��$F��@/ActPlayResponsibly2012;component/Images/GameBoard/GameBoard.png���� -   #��[  
���  ��._��� -   $ 	RedAvatar��$@��:/ActPlayResponsibly2012;component/Images/Teams/RedTeam.png���� -	   #��[  
��� d �._��� -
   $ GreenAvatar��$B��</ActPlayResponsibly2012;component/Images/Teams/GreenTeam.png���� -   #��[  
����  �._��� -   $ 
BlueAvatar��$A��;/ActPlayResponsibly2012;component/Images/Teams/BlueTeam.png���� -   #��[  
��� ���._��� -   $ YellowAvatar��$C��=/ActPlayResponsibly2012;component/Images/Teams/YellowTeam.png��� $��1�� � RowDefinitions �� �� $	��250 ��� $	��250 �.+��� -   $��0��$��10q�$	��200������ *ThrowDiceCommand+.���  �� �� $
��Auto �.+��� $��0��$	��100��$	��100��$��Center=� J� RenderTransformOrigin$ 0.5,0.5&����� *	DiceImage+z�V� .~��� �� �� T� � $��1��$��10q� �� �� $
��Auto �.+�� $��0��$��Center=�$��Center=� �� �� $
��Auto �.+��� $��0��$��5q����� *CurrentTeam.Id+ �� 	Converter# [ ._��� $	��150��$��Center=�$��Center=����� *CurrentTeam.Avatar+�� $��0��$	��-20q�$��Right=�$	��Top=�$
��None=�$=��7/ActPlayResponsibly2012;component/Images/Teams/Star.png��y��� *CurrentTeam.IsHardQuestion+# [ �� $��1��$��Center=�$��Center=�$��0,0,0,5q�$��18(�
����������� *CurrentTeam.Name+�� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $	��100��$
��10,0q�$��	Next Turn������ *NextTurnCommand+�� $	��100��$
��10,0q�$��Promote������ *PromoteCommand+y��� *CurrentTeam.IsHardQuestion+# [ � $��2��$��10q� �� ��  �� �� �� .+��� -    ��Name$	 Red��$��0��$��0��$��3q�
���  ���� -   $ Green��$��0��$��1��$��3q�
��� � ��� -   $
 Blue��$��0��$��2��$��3q�
����  ��� -   $ Yellow��$��1��$��0��$��3q�
��� ����� -   $
 Gray��$��1��$��1��$��3q�
�������3   -ActPlayResponsibly2012.Questions.QuestionView  -     Name$ QuestionView��$��2��$	��400��$y�	Collapsed=� � DataContext �� *CurrentQuestion+