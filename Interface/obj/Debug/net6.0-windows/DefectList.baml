   M S B A M L   `   `   `  ����D  @Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Interface	Interface  5   	       Interface.DefectList   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Interface     5   	   -   5          � Title$  
MainWindow��5   	   $	��728��6   $	��697��6)    � 
ResizeMode$ CanMinimize=�65    � WindowStartupLocation$ CenterScreen=�6N   .��5	      � $��0,0,0,0q�6   .+�5
   
   �� 
�������$��1q�6%   $��Center=�69   $	��630��6V   $	��Top=�6c   $	��697��6{   ���	#FFFDB63C$��0,88,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	Vedomosty��5         AutoGenerateColumns$ False��6&   $��36,101,23,127q�6B      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Продукция��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� 	 �� Path$	 prod_defect�6]     5      $ Вид дефекта��6%   $	 180 6c    6:   �� $	 type_typedefect�6c     5      $4 .Зона поражения продукции��6%   $	 200 6n    6G   �� $	 damage_defect�6n   5      �� 5   
   -   5        $��
Назад��5      $
��Left=�6!   $��465,613,0,0q�6<   $	��Top=�6Q   $��56��6i   $	��189��6u   6�   �� 5   
   $
��Left=�6   $��22��6+   $��	10,16,0,0q�67   $	��Top=�6J   $��90��6b   $��/019.jpg��6m   $
��Fill=�6   �� 5   
   $
��Left=�6   $��56��6+   $��
137,10,0,0q�67   $	��Top=�6K   $	��436��6c   $��36(�6o   $��Center=�6}   $��Center=�6�   $
��Bold"�6�   $��Arial)�6�   $#��Список дефектов��6�   5      5      