   M S B A M L   `   `   `  ���� I  EHotels_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Hotels_Manager.Views.ControlsHotels_Manager.Views.Controls  Q-clr-namespace:Hotels_Manager.Views.ConvertersHotels_Manager.Views.Converters  W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;   5Hotels_Manager.Views.Converters.CornerRadiusConverter   CornerRadiusConverter  �� 
TargetType �� Property  ContextMenuBackColor �� Value  	TextColor  HoveredMenuItemBackColor �� 
TargetType K� IsItemsHost � 	Resources  TileListBoxStyle � Orientation  SquareListBoxItemStyle  
PlateColor  HotelListBoxItemStyle �� BasedOn �� CornerRadius	 � RowDefinitions
 �� Orientation  HeaderTextBlockStyle �� UpdateSourceTrigger 	 SubHeaderTextBlockStyle 
 SubTextColor5   /Hotels_Manager.Views.Controls.StarRatingControl   
StarsCount �� Mode0  *Hotels_Manager.Views.Controls.ModernButton   CornerRadius � ToolTip �� RelativeSource �� AncestorType  FloorListBoxItemStyle  RoomListBoxItemStyle  GuestListBoxItemStyle  RoomTypeListBoxItemStyle � ColumnDefinitions  GlobalGuestListBoxItemStyle  ListBoxItemBackColor  ReservationListBoxItem  MainStyleColor1   +Hotels_Manager.Views.Controls.ModernTextBox  TextBoxBackColor  MainApplicationFont-  'System.Windows.Input.KeyboardNavigation �� 	Converter ��Name � Cursor ��Name   PlaceHolder  PlaceHolderColor �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName �� Triggers P� Property P� Value  RatingStarBackColor  ��Name5   /Hotels_Manager.Views.Controls.RatingStarCounter!  Name  ComboBoxToggleButton" ��Name# F�Name  ComboBoxTextBox$ �� 	ClickMode% d� 	IsChecked& �� Path' J� IsHitTestVisible( �� SelectionBoxItem) �� SelectionBoxItemTemplate* ��Name+ �� 
IsReadOnly, �� 
IsReadOnly- �� IsDropDownOpen. � AllowsTransparency/ J� SnapsToDevicePixels0 � ActualWidth1 �� MaxDropDownHeight2   DirectionalNavigation3 P� 
SourceName4 �� Padding  ScrollThumbs5 �Name  ScrollBarThumbColor6 ]�Name7 ]� Thumb8 n�Name9 ]� IncreaseRepeatButton: ��Name; J� Opacity< ]� DecreaseRepeatButton  ButtonSelectBrush  	DarkBrush= �� Angle  MainStyleHoveredColor> ��Name  CaptionButtonStyle? �� ClearTypeHint&   System.Windows.Media.TextOptions@   TextRenderingModeA   TextFormattingMode  InternalMenuButton   MenuPanelColor ! MinimizeButtonStyle " MaximizeButtonStyle # RestoreButtonStyle $ CloseButtonStyle % MenuButtonStyle�� H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     8controls+clr-namespace:Hotels_Manager.Views.Controls  <
converters-clr-namespace:Hotels_Manager.Views.Converters  %x8  &	        '��      &	     &	 G    &	 �    7  &	 �    7  &	 �	    7  &	 �    7  &	 �    &	 
    &	 �    &	 �    &		 �    '  )    7   '  �     '  Q!    &	 �#    &	 %    '�� S%    7  7  '�� �*    &	 A,    '�� �-    '  �1    &	 !4    &	 �5    &	! 96    7  &	" b6    7  &	# �6    7  &	$ �6    7  &	% �6    7     �� "  ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0q���  � ��$ 4q���  � �� �� " ��.R��� #��z��#��z��#��z��._��� $
 True�� ���� 'm�       "  m�.���  � ��# �  ��  � ��# �  �� "  ��.���  � �� �� .R�� $ 
Horizontal=��� "  ��.���  � ��$	 150����  � ��$	 150����  � ��$ 5q���  � ��$ 0q���  � ��# �  �� "  ��8   .���  � �� �� " ��.R��� #��z��#��z��#��z��$ 10��._�� 	 �� �� $
��0.9* �.+��� $��Center=�$��Center=�$��0��$��	20,0,20,0q�$
 Vertical=�.+��� $��Center=�#���  $
��Wrap=����� *Name+$ PropertyChanged=��� $��0,10,0,0q�$��Center=�#��� 	 #��� 
 $��NoWrap=�$��CharacterEllipsis=����� *	Address+$ PropertyChanged=��� $��1�����#1f2023$ 	0,0,10,10��  $��1��$��18(�$	��Top=�$��Center=�$��0,0,0,0q� �� *Stars+$ PropertyChanged=�$ TwoWay=��� $��1��$
 
Horizontal=�$��Center=�$��0,0,0,10q�.+�  $��1��$��30��$��30��$ 6��$��Center=�$��Bottom=�$��0,0,10,0q�$ Change data������ *&$DataContext.OpenHotelEditPageCommand+ ��  ListBox���� .���� $��17��$��../Assets/configure.png��  $��1��$��30��$��30��$ 6��$��Right=�$��Bottom=�$��0,0,0,0q�$ Delete hotel������ * DataContext.RemoveHotelCommand+ ��  ListBox���� .���� $��17��$��../Assets/trash_can.png���� "  ��8   .���  � ��$ 85����  � ��$
 auto����  � ��$	 105����  � �� �� " ��.R��� #��z��#��z��#��z��$ 10��._�� 	 �� �� .+��� #���  $��0��$��	10,10,0,5q�$
��Wrap=��� $�Number of the floor: �� �� ��� *Number+�� $��1��$��10,0,0,0q�$
 
Horizontal=�$
��Left=�.+��� $��30��$��../Assets/room.png���� 
�������$��Center=�$��SemiBold"�$��10,0,0,0q�$��13(����� *Rooms.Count+�� $��1��$
 
Horizontal=�$��Right=�$��	0,0,10,10q�.+�  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,5,0q�$ Change data������ *&$DataContext.OpenFloorEditPageCommand+ ��  ListBox���� .���� $��17��$��../Assets/configure.png��  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,0,0q�$ Delete floor������ * DataContext.RemoveFloorCommand+ ��  ListBox���� .���� $��17��$��../Assets/trash_can.png���� "  ��8   .���  � ��$ 85����  � ��$
 auto����  � ��$	 105����  � �� �� " ��.R��� #��z��#��z��#��z��$ 10��._�� 	 �� �� .+��� #���  $��0��$��	10,10,0,5q�$
��Wrap=��� $�Number of the room: �� �� ��� *Number+�� $��1��$��10,0,0,0q�$
 
Horizontal=�$
��Left=�.+��� $��30��$��../Assets/people.png���� 
�������$��Center=�$��SemiBold"�$��10,0,0,0q�$��13(����� *Guests.Count+�� $��1��$
 
Horizontal=�$��Right=�$��	0,0,10,10q�.+�  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,5,0q�$ Change data������ *%#DataContext.OpenRoomEditPageCommand+ ��  ListBox���� .���� $��17��$��../Assets/configure.png��  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,0,0q�$ Delete room������ *DataContext.RemoveRoomCommand+ ��  ListBox���� .���� $��17��$��../Assets/trash_can.png���� "  ��8   .���  � ��$ 85����  � ��$
 auto����  � ��$	 105����  � �� �� " ��.R��� #��z��#��z��#��z��$ 10��._�� 	 �� �� .+��� #���  $��0��$��	10,10,0,5q�$
��Wrap=��� ��� *	FirstName+ �� ��� *
LastName+�� $��1��$��10,0,0,0q�$
 
Horizontal=�$
��Left=��� $��1��$
 
Horizontal=�$��Right=�$��	0,0,10,10q�.+�  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,5,0q�$ Change data������ *&$DataContext.OpenGuestEditPageCommand+ ��  ListBox���� .���� $��17��$��../Assets/configure.png��  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,0,0q�$ Delete guest������ *(&DataContext.RemoveGuestFromRoomCommand+ ��  ListBox���� .���� $��17��$��../Assets/trash_can.png���� "  ��.���  � ��$ 40����  � ��$ 0,0,0,10q���  � �� �� " ��.R��� #��z��#��z��#��z��._��  �� �� $
��0.5* �.+��� $��0��$��10,0,0,0q�$��Center=�$
 
Horizontal=�.+��� #���  $��70��$��SemiBold"�$��13(�$��NoWrap=�$��CharacterEllipsis=����� *
TypeName+�� $��1��$��10,0,0,0q�$
 
Horizontal=�$
��Left=�.+��� $��20��$��../Assets/price.png���� 
�������$��Center=�$��SemiBold"�$��10,0,0,0q�$��13(�$��50��$��NoWrap=�$��CharacterEllipsis=����� *Price+�� $��1��$
 
Horizontal=�$��Right=�$��Center=�$��0,0,10,0q�.+�  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,5,0q�$ Change data������ *)'DataContext.OpenRoomTypeEditPageCommand+ ��  ListBox���� .���� $��17��$��../Assets/configure.png��  $��1��$��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,0,0q�$ Delete room type������ *#!DataContext.RemoveRoomTypeCommand+ ��  ListBox���� .���� $��17��$��../Assets/trash_can.png���� "  ��.���  � ��$ 50����  � ��# �  ��  � ��$ 5,0,5,5q���  � �� �� " ��.R��� $ 5��#��z��#��z��#��z��._��  �� $	��200 ��� �� $
��auto �.+��� $��0��$
��Left=�$��15,0,0,0q�$��Center=�$
 
Horizontal=�.+��� $��SemiBold"�$��12(�#���  �� ��� *	FirstName+ �� ��� *
LastName+ �� $�,�� �� #��� 
 ��� *Age+ �� $�
років��#��� 
 �� $��1��$
 
Horizontal=�$��Right=�$��Center=�$��0,0,10,0q�.+�  $��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,5,0q�$ Змінити дані������ *31DataContext.OpenGuestEditPageFromGuestListCommand+ ��  ListBox���� .���� $��17��$��../Assets/configure.png��  $��27��$��27��$ 6��$��Right=�$��Bottom=�$��0,0,0,0q�$! Видалити гостя������ * DataContext.RemoveGuestCommand+ ��  ListBox���� .���� $��17��$��../Assets/trash_can.png���� "  ��.���  � ��# �  ��  � ��$ 50����  � ��$ 5,0,5,5q���  � �� �� " ��.R��� $ 5��#��z��#��z��#��z��._�� .+��� $
 
Horizontal=�$
��Left=�$��15,0,0,0q�$��Center=�.+��� #���  $��13(��� $�Hotel:�� �� $��SemiBold"���� *Guest.Room.Floor.Hotel.Name+ �� $�- floor:�� �� $��SemiBold"���� *Guest.Room.Floor.Number+ �� $�- room:�� �� $��SemiBold"���� *Guest.Room.Number+ �� $�- Guest Id:�� �� $��SemiBold"���� *
Guest.Id+�� #���  $��13(��� $�, full name -�� �� #���  $��SemiBold"���� *Guest.FirstName+ �� #���  $��SemiBold"���� *Guest.LastName+�� $��13(�$��20,0,0,0q�#��� 
 �� ��� *CheckInDate+ �� $�-�� �� ��� *CheckOutDate+�� $��13(�$��20,0,0,0q�#���  �� $�Amount:��#���   �� $��SemiBold"���� *
TotalPrice+�� "  ��.���  � ��# �  ��  � ��$ 15(���  � ��$
 Bold"��� "  ��.���  � ��# �  ��  � ��$ SemiBold"��� "   .���  � ��# �  ��  � ��$ 35����  � ��# �  ��  � ��# �  ��  � ��$ 	0,0,0,1.5q���  � ��# �  ��  �@J�SnapsToDevicePixels$
 True����  �@ TabNavigation$
 None=���  �@�FocusVisualStyle Z� ��  � ��$	 120����  � ��$ 20����  �@J�	AllowDrop$
 true����  �@=�ErrorTemplate Z� ��  � �� �� "  .R��� $��Border��#��z��#��z��#��z�� �� *CornerRadius+8   ._�� .+��� $ PART_ContentHost��$��Center=�$|�False��$��Disabled=�$��Disabled=�$��5,0,5,0q�$ IBeam��#��z��#��z���� $ PlaceholderTextBlock��#��z #��z��#���  $y�	Collapsed=�$��7,0,0,0q�$��Center=� ]�  ��  � ��$  ��./��� $ PlaceholderTextBlock�� � y�$ Visible=� P�  �@=�HasError$
 True��. ���  � ��
 �  ���� "   .���  � ��$ 12(���  �@ 	StarColor# �  ��  � �� �� "  .R��� #��z��#��z��#��z��._��� $
 
Horizontal=�$��5q�.+��� $  PART_StarPanel��$
 
Horizontal=��� "   .���  � ��$	 115����  � �� �� "  .R��� $ 10��$��30��#��z��#��z��#��z��._�� $��5,0,5,0q�$��Center=� �� $
��auto ��� $
��auto ��� $
��auto �.+�  $! PART_decreaseBtn��$��0��$��0,0,10,0q�$ 50��$��25��$��25��$��20(�.���� $��10��$��../Assets/Minus.png���� $��1��$
 
Horizontal=�.+��� $ PART_starCounterTxb��$��Center=�#���  $��SemiBold"����� *
StarsCount+ �� *TemplatedParent+�� $��5,0,0,0q�$��Center=�$��../Assets/Star.png��$��17��  $! PART_increaseBtn��$��2��$��10,0,0,0q�$ 50��$��25��$��25��$��16(�.���� $��10��$��../Assets/Plus.png���� " d�.R��  �� �� $��20 �.+��� $" Border��$��2��$ 7��#��z��#���  $��1q��� $��0��$ 7��$��1q�#��z�����#27292d$��0,0,1,0q�F� $# Arrow��$��1��
�������$��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	�� " ��.R��� $" PART_ContentHost��$|�False��#��z���� "  ��.���  �@J�SnapsToDevicePixels$
 true����  �@�OverridesDefaultStyle$
 true����  � ��$
 Auto=���  � ��$
 Auto=���  � ��$
 true����  � ��$	 120����  � ��$ 30����  � ��
 �������  � �� �� " ��.R�� .+�d� $��ToggleButton��8��  #��z��$��2��$|�false��$$ Press=�% �� $& IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite��$' False��#��z( #��z) #��z��$��	10,3,23,3q�$��Center=�$
��Left=��� $* PART_EditableTextBox��8�� $
��Left=�$��Center=�$��	10,3,23,3q�$
|�True��#��z��
�������$y�Hidden=�#, z+ ��Z� � $��Popup��$��Bottom=�#��z- $
. True��$|�False��$��Slide=�.��� $��DropDown��$
/ True��#��z0 #��z1 .+��� $" DropDownBorder��#��z��$��1q����#27292d�� $��4,12,4,6q�$
/ True��.���� $
 True��$2 	Contained=� P�  �@��HasItems$ false��. ��� $ DropDownBorder�� � ��$ 95��P�  � {�$ false��. ���  � �� �#2063e8P�  �@��
IsGrouping$
 true��. ���  � ��$ false��P� $3 Popup�� �@�AllowsTransparency$
 true��. ��� $ DropDownBorder�� �@��CornerRadius$ 0���� $ DropDownBorder�� � ��$ 0,10,0,0q�P�  �@��
IsEditable$
 true��. ���  � ��$ false���� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=� �� "  ��.���  �@J�SnapsToDevicePixels$
 true����  � ��
 �������  �@�OverridesDefaultStyle$
 true����  � �� �� " ��.R��� $��Border��$4 2q�$
/ true��._���  P�  �@��IsHighlighted$
 true��. ��� $ Border�� � �� �	#FF4F4F4FP�  � {�$ false��. ���  � �� �#888888�� "  n�.���  � �� �� " n�.R�� $
5 Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $" 
Rectangle1��$ 5��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��#��z�� P�  �@�Tag$ 
Horizontal��. ��� $ 
Rectangle1�� � ��$
 Auto���� $ 
Rectangle1�� � ��$ 7���� "  ��.���  �@��IsFlicksEnabled$ false����  � ��# �  ��  � ��
 ���� ��  � ��$ 8����  � �� �� " ��.R�� $5 GridRoot��$��8��#��z��	 �� $��0.00001* �.+�]� $6 
PART_Track��$��0��$
��true��$|�false��7 n� $8 Thumb��#��z��#���  9 �� $: PageUp��$��ScrollBar.PageDownCommand��$; 0Q�$|�false��< �� $: PageDown��$��ScrollBar.PageUpCommand��$; 0Q�$|�false�� P� $3 Thumb�� �@J�IsMouseOver$
 true��. ��� # �  $ Thumb�� � ��P� $3 Thumb�� �@n�
IsDragging$
 true��. ��� # �  $ Thumb�� � ��P�  � {�$ false��. ��� $ Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	= -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	= -90Q���  � ��$
 Auto����  � ��$ 8���� $ Thumb�� �@�Tag$ 
Horizontal���� $ PageDown�� � ��$ ScrollBar.PageLeftCommand���� $ PageUp�� � ��$  ScrollBar.PageRightCommand���� "   .���  � ��# �  ��  � ��# �  ��  �@ MouseOverColor# �  ��  �@ MouseOverTextColor# �  ��  � ��$ 30����  �@�Cursor$
 Hand����  � ��# �  ��  � ��$ 0q���  �@ CornerRadius$ 5����  � ��$ Center=���  � ��$ Center=���  � �� �� "  .R��� $" border��#��z��#��z��#��z��# z #4 z��._��� $
> cont��#��z��#��z��#��z�� P�  � {�$ False��. ��� $ border�� �@J�Opacity$	 0.5Q�P�  �@J�IsMouseOver$
 True��. ��� $ border�� �� *MouseOverColor+ �� "   � ���� "  ��.���  � ��$ 10(���  � ��$ 30����  � ��$ 50����  � �� �� " ��.R�� $5 
LayoutRoot��
������ #��z��#��z��.+��� $	 txt��#��z��$��Segoe MDL2 Assets)�#��z��#���  $��Center=�$��Center=�$
? Auto=�$@ Aliased=�$A Display=� P�  �@J�IsMouseOver$
 True��. ��� $ 
LayoutRoot��# �   � ���� "   .���  � ��$ SemiBold"���  � ��$ 40����  � ��$ Stretch=���  � ��$ Stretch=���  � ��# �   ��  �@ MouseOverColor# �  �� "  ��8   .���  � ��$	 ���� "  ��8   .���  � ��$	 ���� "  ��8   .���  � ��$	 ���� "  ��8   .���  � ��$	 ���� "  ��8   .���  � ��$	 ����  � ��$ 12(�