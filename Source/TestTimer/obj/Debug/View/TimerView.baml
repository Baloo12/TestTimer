   M S B A M L   `   `   `  ����D  @TestTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TestTimer	TestTimer  5   	   9!clr-namespace:TestTimer.ViewModelTestTimer.ViewModel  5   	       TestTimer.View.TimerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TestTimer     5   	   7	viewmodel!clr-namespace:TestTimer.ViewModel     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��500��6)    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      !   TestTimer.ViewModel.TimerVM  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value   errorLabelStyle��%�  '��       &	  �     �� 5   
   " ��6   .�5      ��  � ��$ 50,20q�6'   �� 5       � ��$ 50(�6)   �� 5       � ��$ Center=�69   �� 5       � ��$ Center=�6;   5      �� 5   
   " ��6   .�5      ��  � ��$ 50,20q�6'   �� 5       � ��$ 18(�6)   �� 5       � ��
 �  ��6+   �� 5       � ��$
 Wrap=�6-   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       �� 5!      �� 5"      .+�5&   
   �� #��[  6   ��6=   �� *WarrningMessage+y�6_   �� *IsWarrningVisible+�� 5)   
   $��1��6   $��50(�6   ��6-   �� *InputTimerContent+.��6P   .  (System.Windows.Interactivity.Interaction   Triggers 5*      /  )System.Windows.Interactivity.EventTrigger  5+      	   	EventName$	 	LostFocus��6!   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5,      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *LostFocusCommand+5-        5.      $	 GotFocus��6!   .
 5/         6,   �� *GotFocusCommand+50      .��51   &   52      �� 53   
   $��2��6    �� 
IsReadOnly . ��6   �� *OddTimerContent+6@   �� 54   
   $��3��6    . ��6   �� *EvenTimerContent+6A   55      56      