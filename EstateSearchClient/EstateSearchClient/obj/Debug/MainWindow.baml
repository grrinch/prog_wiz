   M S B A M L   `   `   `  ����  EstateSearchClient#    EstateSearchClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Estates by Rad��5   	   $	��600��6    $
��1000��6-    � 
ResizeMode$ CanMinimize=�5   	    � 	Resources 5         ItemCollectionViewSource �� CollectionViewType��%"   &	        �� 5   
   " ��6A   5      .��5	      � $��0,0,2,2q�6   .+�5
   
   �� $��Szukaj po mieście��6   $
��Left=�6.   $��	10,10,0,0q�6I   $	��Top=�6\   $	��105��6t   $	��380��6�   .��5      � $
��Left=�6   $��70��6.   $	��Top=�6:   $	��360��6R   $��
10,10,-2,0q�6^   .+�5      �� $��Miasto��6   $
��Left=�6)   $	��Top=�6D    J� RenderTransformOrigin$ 0.588,0.385&�6\   $��	10,10,0,0q�6�   �� 5      -   5         ��Name$ cityNameInput��5      $
��Left=�61   $��23��6L   $��	61,13,0,0q�6X    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��209��6�    � Cursor$	 Pen��6�   �� 5      -   5         ��Name$ searchCityButton��5      $��Szukaj��63   $
��Left=�6D   $��
275,14,0,0q�6_   $	��Top=�6s   $��75��6�   $
 Hand��6�   6�   �� 5      -   5        	 ��Name$	 cityNameCombo��5      $
��Left=�62   $	��Top=�6M   $	��209��6e   $��	61,41,0,0q�6q   5      5      �� 5   
   $��Szukaj po agencji��6   $
��Left=�6.   $��
395,10,0,0q�6I   $	��Top=�6]   $	��105��6u   $	��380��6�   .��5      � $
��Left=�6   $��66��6.   $	��Top=�6:   $	��360��6R   $��	10,10,0,0q�6^   .+�5      �� $��Agencja��6   $
��Left=�6*   $	��Top=�6E   $��10,8,0,0q�6]   �� 5      -   5        $ agentNameInput��5      $
��Left=�62   $��23��6M   $��	67,10,0,0q�6Y   $
 Wrap=�6l   $	��Top=�6�   $��209                      ��6�   $	 Pen��6�   �� 5      -   5        $	 agentNameCombo��5      $
��Left=�63   $��	67,38,0,0q�6N   $	��Top=�6a   $	��209��6y   �� 5      -   5        $ searchAgentButton��5      $��Szukaj��64   $
��Left=�6E   $��
281,12,0,0q�6`   $	��Top=�6t   $��75��6�   $
 Hand��6�   6�   5      5      �� 5   
   -   5        $ getAllButton��5      $��Pobierz wszystkie��6'   $
��Left=�6C   $��
780,10,0,0q�6^   $	��Top=�6r   $	��200��6�   $��40��6�   
 �� 	IsDefault
 . $
 Hand��6�    � ToolTip$3 -Kliknij, by pokazać wszystkie nieruchomości��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5        $ showSelectedButton��5      $��Pokaż szczegóły��6-   $
��Left=�6G   $��
780,60,0,0q�6b   $	��Top=�6v   $	��200��6�   $��40��6�    5         5!      5#      &   System.Windows.Controls.DataGrid  5$   
   -	   5          Name$ ggrrr��5%      $
��Left=�5&      $��
10,120,0,0q�5'      $	��Top=�5(      $	��438��5)      $	��970��6      HorizontalGridLinesBrush �	#FFE6E6E6   VerticalGridLinesBrush �	#FFE6E6E6   AlternatingRowBackground �	#FFFFF1DC �� AlternationCount$ 2��5-         AreRowDetailsFrozen .    
IsReadOnly . 5/      52      53      