   M S B A M L   `   `   `  ����  COM APP'    !SerialCommunicationApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Serial Communication App��5   	   $	��330��6*   $	��570��67    � 
ResizeMode$ NoResize=�6\   .��5      � .+�5   
   �� $��	COM Port:��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   �� 5   
   -   5         ��Name$ comPortComboBox��5      $
��Left=�6,   $	��Top=�6G   $	��100��6_   $��
120,10,0,0q�6k   �� 5
   
   $��
Baud Rate:��6   $
��Left=�6%   $��	10,40,0,0q�6@   $	��Top=�6S   �� 5   
   -   5         ��Name$ baudRateTextBox��5      $
��Left=�6+   $	��Top=�6F   $	��100��6^   $��
120,40,0,0q�6j   �� 5   
   -   5        $��Connect��5      $
��Left=�6#   $	��Top=�6>   $��80��6V   $��25��6a   $��
240,10,0,0q�6m   6�   �� 5   
   -   5        $��Refresh��5      $
��Left=�6#   $	��Top=�6>   $��80��6V   $��25��6a   $��
330,10,0,0q�6m   6�   �� 5   
   -   5        $ receivedTextBox��5      $
��Left=�6+   $	��Top=�6F   $	��450��6^   $	��150��6j   $��	10,80,0,0q�6w    �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�6�   �� 5   
   -   5        $ sendTextBox��5      $
��Left=�6'   $	��Top=�6B   $	��350��6Z   $��25��6f   $��
10,240,0,0q�6r   �� 5   
   -   5        $
��Send��5      $
��Left=�6    $	��Top=�6;   $��80��6S   $��25��6^   $��370,240,0,0q�6j   6   �� 5   
   -	   5        $��Clear��5      $
��Left=�6!   $	��Top=�6<   $��80��6T   $��25��6_   $��460,240,0,0q�6k   6�   5      5      