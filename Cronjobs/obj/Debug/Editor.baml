   M S B A M L   `   `   `  ����C  ?Cronjobs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CronjobsCronjobs  5   	       Cronjobs.Editor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Cronjobs     5   	   -   5          � Title$  	Cron Edit��5   	   $	��247��6   $	��419��6(   .��5
      � .+�5   
   �� -   5         ��Name$ lblPath��5      $��Executable Path��6!   $
��Left=�6;   $��	10,24,0,0q�6V   $	��Top=�6i   $��0q�6�   �� 5   
   -   5         ��Name$ txtPath��5      $��10q�6#   $��
10,40,90,0q�60    �� TextWrapping$
 Wrap=�6D   $�� ��6X   $	��Top=�6`   �� 5   
   -   5        $ lblDelayMin��5      $��Min Delay (Minute)��6%   $
��Left=�6B   $��	10,89,0,0q�6]   $	��Top=�6p   $��0q�6�   �� 5   
   -   5        $ txtDelayMin��5      $
��Left=�6'   $��10q�6B   $��
10,105,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��181��6�   �� 5   
   -   5        $ lblDelayMax��5      $��Max Delay (Minute)��6%   $��Right=�6B   $��	0,89,88,0q�6^   $	��Top=�6q   $��0q�6�   �� 5   
   -   5        $ txtDelayMax��5      $��10q�6'   $��
0,105,10,0q�64   $
 Wrap=�6H   $�� ��6\   $	��Top=�6d   $��Right=�6|   $	��181��6�   �� 5   
   -   5         ��Name$ 	btnChoose��5      $��Choose��6$   $��	0,40,10,0q�65   $	��Top=�6H   $��38��6`   $��Right=�6l   $��70��6�   �� 5   
   -	   5        $ btnSave��5      $
��Save��6"   $��Right=�61   $��	0,0,10,10q�6M   $��Bottom=�6`   $��70��6{   $��38��6�   ���	#FF068B00
�������6�   �� 5   
   -
   5        $ 	btnDelete��5      $��Delete��6$   $
��Left=�65   $��	10,0,0,10q�6P   $��70��6c   
���  ��
�������$��38��6�   $��Bottom=�6�   5      5      