   M S B A M L   `   `   `  ����D  @Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Interface	Interface  5   	       Interface.Log   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Interface     5   	   -   5          � Title$	  Log��5   	   $	��728��6   $
��1167��6"    � 
ResizeMode$ CanMinimize=�6/    � WindowStartupLocation$ CenterScreen=�6H   .��5	      � .+�5
   
   �� 
�������$��1q�6%   $��Center=�69   $	��630��6V   $	��Top=�6c   $
��1167��6{   ���	#FFFDB63C$��0,88,0,0q�6�   �� 5   
   $��Сменить отдел��6   $
��Left=�6(   $��
965,21,0,0q�6C   $	��Top=�6W   $��18(�6o   $	��163��6}   $��Center=�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ Otdels��5      $
��Left=�6#   $��
962,55,0,0q�6>   $	��Top=�6R   $	��166��6j    �� 
IsReadOnly$
 True��6v   .@�5      �� $+��%Разгрузка заготовок��6   �� 5      $��Печь��6   �� 5      $!��Прокатный стан��6   �� 5      $��Холодильник��6   �� 5      $!��Линия контроля��6   �� 5      $)��#Отгрузка продукции��6   �� 5      $)��#История ведомостей��6    �� 
IsSelected$
 True��68   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	Vedomosty��5         AutoGenerateColumns$ False��6&   $��36,101,23,33q�6B      SelectionMode$ Single=�6X   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Тип ведомости��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ��  �� Path$ type_typevedomost�6g     5      $/
 )Дата и время ведомости��6%   $	 180 6q    6E   �� $ data_time_vedomost�6q     5      $#
 Номер продукции��6%   $	 250 6e    6>   �� $ prod_vedomost�6e     5      $
 Отправил��6%   $	 200 6[    67   �� $ 
FIO_sotrud�6[     5      $
 Отправил��6%   $	 200 6^    67   �� $ location_zone�6^   5      �� 5   
   $
��Left=�6   $��45��6+   $��	10,16,0,0q�67   $	��Top=�6J   $	��178��6b   $��/019.jpg��6n   $
��Fill=�6�   �� 5   
   $G��AУчет ведомости рельсовой продукции��6   $��Center=�6=   $��56��6Z   $��0,11,0,0q�6f   $	��Top=�6x   $	��699��6�   $��36(�6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   $��Arial)�6  5       5!      