   M S B A M L   `   `   `  ����I  ESBModuleWorkDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SBModuleWorkDBSBModuleWorkDB  5   	       SBModuleWorkDB.OrderInfo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SBModuleWorkDB     5   	     � Title$  	OrderInfo��5   	    � 
ResizeMode$ NoResize=�5	   	    � SizeToContent$ WidthAndHeight=�5
   	   $	��300��5   	   $	��400��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��2q�6    � 	Resources 5   
    �� 
TargetType �� Property �� Value��%!  '��       '�� �     �� 5      " ��6   .�5      ��  � ��$ 12(�6-   �� 5       � ��$ DemiBold"�6/   �� 5       � ��$ Right=�68   5      �� 5      " ��6   .�5      ��  � ��$ 
0, 4, 0, 0q�6+   �� 5       � ��$ 20��6+   5      5       � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $	��10* �6   	 � ColumnDefinitions	 5   
   �� 5      $��* �6   �� 5       $��2* �6   �� 5!      $��* �6   .+�5#   
   �� 
 �� Orientation$
 Vertical=�6   $��0��5$      .+�5%      �� $
��Code��6   �� 5&      $��Product Name��6   5'      �� 5(   
   $
 Vertical=�6   $��1��5)      .+�5*      �� -   5         ��Name$
 code��5*      �� 5+      -   5        $ productName��5+      5,      �� 5-   
   -   5         ��Name$ 	addButton��5-      $��2��5.      $��Bottom=�5/      $��5q�50      .��52      �� $��	New Order��6   $��12(�53      54      &   System.Windows.Controls.DataGrid  55   
   -   5          Name$ gridView��55      $ �� IsSynchronizedWithCurrentItem$
 TrueY�56         
IsReadOnly .    AutoGenerateColumns .  $��1��5:      $��3��5;      ��58      ��    Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      -   5        id��,  &System.Windows.Controls.DataGridColumn   Header$ Order Id��5?   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5>   %   �� *Id+5?   %     5@      -   5        	email��$ Email��5B   %    5A   %   �� *Email+5B   %     5C      -   5        	orderCode��$
 Code��5E   %    5D   %   �� *Code+5E   %     5F      -   5        product��$ Product��5H   %    5G   %   �� *	Product+5H   %   5J      5L      5M      