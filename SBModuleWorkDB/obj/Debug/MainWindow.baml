   M S B A M L   `   `   `  ����I  ESBModuleWorkDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SBModuleWorkDBSBModuleWorkDB  5   	       SBModuleWorkDB.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SBModuleWorkDB     5   	     � Title$  
MainWindow��5   	   $	��450��5	   	   $	��800��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��2q�6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridView��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      $��0��5         SelectionMode$ Single=�5         AutoGenerateColumns .     
IsReadOnly . ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        id��,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��5   %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5   %   �� *Id+5   %     5      -   5        
secondName��$	 Second Name��5   %   
 5   %   �� *
SecondName+5   %     5       -   5        name��$
	 Name��5"   %   
 5!   %   �� *Name+5"   %     5#      -   5        
patronymic��$	 
Patronymic��5%   %   
 5$   %   �� *
Patronymic+5%   %     5&      -   5        	phone��$	 Phone Number��5(   %   
 5'   %   �� *Number+5(   %     5)      -   5        	email��$	 Email��5+   %   
 5*   %   �� *Email+5+   %    � ContextMenu 5-      �� 5.      .@�5/      m� -   5        $��Add new��5/      60   m� 50      -	   5        $
��Edit��50      6-   m� 51      -
   5        $��Delete��51      6/   m� 52      -   5        $��Orders��52      6/   53      56      �� 57   
   -   5        $��1��57      $	��Top=�58      $��Stretch=�59      $��2q�5:      $��30��5;      .��5=      �� $��Orders journal��6   $��16(�5>      5?      5@      5A      