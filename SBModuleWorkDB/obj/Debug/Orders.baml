   M S B A M L   `   `   `  ����I  ESBModuleWorkDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SBModuleWorkDBSBModuleWorkDB  5   	       SBModuleWorkDB.Orders   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SBModuleWorkDB     5   	     � Title$  Orders��5   	   $	��300��5	   	   $	��450��5
   	    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridView��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         
IsReadOnly .    AutoGenerateColumns .  $��1��5      $��3��5      ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        id��,  &System.Windows.Controls.DataGridColumn	   Header$	 Order Id��5      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5      �� *Id+5        5      -   5        	email��$	 Email��5      
 5      �� *Email+5        5      -   5        	orderCode��$
	 Code��5      
 5      �� *Code+5        5       -   5        product��$	 Product��5"      
 5!      �� *	Product+5"      5$      5%      5&      