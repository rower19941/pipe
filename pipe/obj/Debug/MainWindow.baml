   M S B A M L   `   `   `  ����\  XHelixToolkit.Wpf, Version=2015.1.629.0, Culture=neutral, PublicKeyToken=52aa3500039caf0dM8clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.WpfHelixToolkit.Wpf  5   	   M8clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.WpfHelixToolkit.Wpf  5   	    pipe   pipe.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6#   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Ght8clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.Wpf     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   QHelixToolkit8clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.Wpf     5   	     � Title$  Модель��6W   $	��600��6f   $	��930��5   	      MaterialDesignBody#���   6   #��� ��5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5	   	    � Icon$ Resources/favicon.ico��5
   	   .��5      �  � ShowGridLines .  � RowDefinitions 5   
   �� 5      6    � ColumnDefinitions 5   
   �� 5      $
��1.6* �6   6.   �� 5      $
��auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $��1��6$   $��2��64   $��5��6E   $��Stretch=�6O   $��Center=�5      5      ]� 5   
   -   5        $	��dp1��5   1   $��0��6   $��0��6!   .+�5      o� $	��Top=�6   
�������.@�5      m� $��Настройки��6   .@�5      m� $<��6Чувствительность увеличения ��6   .@�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      ��  � Minimum$	 0.1Q�6Z    � Maximum$ 5Q�6h   $	��200��5    %    � Value 5   %   �� *ZoomSensitivity+	 �� ElementName$	 view1��5    %   �� 5!      ��6(   �� *ZoomSensitivity+
 �� StringFormat$
 {0:0.0}��$	 view1��5"      5#      5$      m� 5%      $��Камера��6   .@�5&      m� -   5         m� IsCheckable . $��Центрировать��5&   2   6H   m� 5'       . $��Orthographic��62    m� 	IsChecked 5(      �� *Orthographic+$	 view1��m� 5)      $A��;Расстояние до ближней плоскости��6   .@�5*      �� ��6"   �� *Camera.NearPlaneDistance+$	 view1��6a   5+      m� 5,      $A��;Расстояние до дальней плоскости��6   .@�5-      �� ��6"   �� *Camera.FarPlaneDistance+$	 view1��6`   5.      m� 5/       . $2��,Вращание вокруг курсора��62    50      �� *RotateAroundMouseDownPoint+$	 view1��m� 51       . $6��0Увеличение вокруг курсора��62    52      �� *ZoomAroundMouseDownPoint+$	 view1��m� 53       . $-��'Бесконечное вращение��62    54      �� *InfiniteSpin+$	 view1��m� 55       . $��IsInertiaEnabled��62    56      �� *IsInertiaEnabled+$	 view1��m� 57       . $��IsPanEnabled��62    58      �� *IsPanEnabled+$	 view1��m� 59       . $&�� Передвижение вкл.��62    5:      �� *IsMoveEnabled+$	 view1��m� 5;       . $��Вращение вкл.��62    5<      �� *IsRotationEnabled+$	 view1��m� 5=       . $"��Увеличение вкл.��62    5>      �� *IsZoomEnabled+$	 view1��m� 5?       . $,��&Показать поле зрения��62    5@      �� *IsChangeFieldOfViewEnabled+$	 view1��m� 5A      $7��1Чувствительность вращения��6   .@�5B      �� $ 
Horizontal=�6%   .+�5C      �� $	 0.1Q�6^   $ 5Q�6l   $	��200��5D   %    5C   %   �� *RotationSensitivity+$	 view1��5D   %   �� 5E      ��6(   �� *RotationSensitivity+$
 {0:0.0}��$	 view1��5F      5G      m� 5H      $��ZoomSensitivity��6   .@�5I      �� $ 
Horizontal=�6%   .+�5J      �� $	 0.1Q�6Z   $ 5Q�6h   $	��200��5K   %    5J   %   �� *ZoomSensitivity+$	 view1��5K   %   �� 5L      ��6(   �� *ZoomSensitivity+$
 {0:0.0}��$	 view1��5M      5N      m� 5O      $��CameraInertiaFactor��6   .@�5P      �� $ 
Horizontal=�6%   .+�5Q      �� $	 0.7Q�6^   $ 1Q�6l   $	��200��5R   %    5Q   %   �� *CameraInertiaFactor+$	 view1��5R   %   �� 5S      ��5T   %   �� *CameraInertiaFactor+$
 	{0:0.000}��$	 view1��5U      5V      5W      m� 5X      $��Вид��6   .@�5Y      m�  . $8��2Показать систему координат��62    5Z      �� *ShowCoordinateSystem+$	 view1��m� 5[       . $.��(Показать куб вращения��62    5\      �� *ShowViewCube+$	 view1��m� 5]       . $*��$Информация о камере��62    5^      �� *ShowCameraInfo+$	 view1��m� 5_       . $-��'Количество полигонов��62    5`      �� *ShowTriangleCountInfo+$	 view1��m� 5a       . $��Поле зрения��62    5b      �� *ShowFieldOfView+$	 view1��m� 5c       . $!��Частота кадров��62    5d      �� *ShowFrameRate+$	 view1��m� 5e       . $��Цель камеры��62    5f      �� *ShowCameraTarget+$	 view1��.@�5g      �� $	��100��6$   $��0q�61   $	��100��6<   5h      m� 5j      $��Подпись��6   .@�5k      �� $	��200��6L   ��6"   �� *Title+$	 view1��6L   5l      m� 5m      $��Подпись 1��6   .@�5n      �� $	��200��6O   ��6"   �� *
SubTitle+$	 view1��6O   5o      5p      m� 5q      -   5         m�Name$ 	AboutMenu��5q      $ ��Дополнительно��6.   .@�5r      m� -   5        $ About_Program��5r      $��О программе��66   6K   m� 5s      -   5        $ About_Process��5s      $'��!Описание процесса��66   6Q   m� 5t      -   5        $
 Grap��5t      $��Графики��6-   6>   5u      5v      &    HelixToolkit.Wpf.HelixViewport3D  5x      -   5          Name$ view1��5x   !      ZoomExtentsWhenLoaded .    ShowCoordinateSystem .    UpDownPanSensitivity$ -5Q�5y      
�������   DefaultCamera 5{      =� 5|       � Position$ 1,1,31�6(    � LookDirection$ -1,-1,-15�69    � UpDirection$ 0,0,255�6R    =� FieldOfView$ 60Q�6g    � NearPlaneDistance$	 0.1Q�5}         Children. 5      $   HelixToolkit.Wpf.DefaultLights  (   "HelixToolkit.Wpf.CuttingPlaneGroup  5�      -   5        cuttingGroup1��.2�5�      g�  g� Content 6$   �� *Model+5�      5�      5�      �� 5�   
   -	   5         ��Name$ 
btn_create��5�      $0��*Построить и рассчитать��6%   $��2��6F   $
��Left=�6V   $��
10,385,0,0q�5�      $	��Top=�6%   $	��192��6=    �� 	IsDefault . $��46��5�       � ToolTip$  ��6   �� 5�   
   -
   5        $ btn_flow��5�      $��2��6#   $
��Left=�63   $��
10,331,0,0q�6N   $	��Top=�6b   $	��192��5�      $��45��63   .��5�      �� $
��Wrap=�6   ,*Состав входного потока5�      5�      �� 5�   
   -   5         ��Name$ txb_flow_rate��5�      $��2��6)   $
��Left=�69   $��26��6T   $��
144,42,0,0q�6`    �� TextWrapping$
 Wrap=�5�      $�� ��6%   $	��Top=�6-   $	��120��6E   
�������6Q   �� 5�   
   -   5         ��Name$ lbl_flow_rate��5�      $
��Left=�6'   $��2��6B   $��	10,35,0,0q�6R   $	��Top=�5�      .��5�      �� $
��Wrap=�6   $	��125��6,   0.Производительность, м^3/ч:5�      5�      �� 5�   
   -   5        $ lbl_optimal_velocity��5�      $��2��6.   $
��Left=�6>   $��	10,70,0,0q�6Y   $	��Top=�5�      .��5�      �� $
��Wrap=�6   $��80��6,   1/Оптимальная скорость, м/с:5�      5�      �� 5�   
   -   5        $ txb_optimal_speed��5�      $��2��6-   $
��Left=�6=   $��26��6X   $��
144,75,0,0q�6d   $
 Wrap=�5�      $�� ��6%   $	��Top=�6-   $	��120��6E   
�������6Q   �� 5�   
   -   5        $ txb_results��5�      $��2��6'     �� 
IsReadOnly  . $
��Left=�6I   $	��141��6d   $��
10,183,0,0q�5�      $
 Wrap=�6%   $	��Top=�69   $	��337��6Q   
�������.��6p   5�      �� 5�   
   -   5        $
 e500��5�      $��2��6   $
��Left=�6.   $��
10,110,0,0q�6I   $	��Top=�6]   .��5�      �� $
��Wrap=�6   $	��100��6,   E500:5�      5�      �� 5�   
   -   5        $ txb_e500��5�      $��2��6$   $
��Left=�64   $��26��6O   $��144,104,0,0q�6[   $
 Wrap=�5�      $	��Top=�6%   $	��120��6=   
�������6I   �� 5�   
   -   5        $ lbl_flow_temp��5�      $��2��6'   $
��Left=�67   $��
10,141,0,0q�6R   $	��Top=�5�      .��5�      �� $
��Wrap=�6   $��80��6,   1/Температура газовй смеси:5�      5�      �� 5�   
   -   5        $ txb_flow_temp��5�      $��2��6)   $
��Left=�69   $��26��6T   $��144,147,0,0q�6`   $
 Wrap=�5�      $	��Top=�6%   $	��120��6=   
�������6I   �� 5�   
   -   5        $ 
txb_Memory��5�      $��2��6&   $
��Left=�66   $��26��6Q   $��148,537,0,0q�6]   $
 Wrap=�5�      $	��Top=�6%   $��67��6=   �� 5�   
   -   5        $ 
lbl_Memory��5�      $,��&Использовано памяти:��6$   $��2��6C   $
��Left=�6S   $��	9,538,0,0q�5�      $	��Top=�6$   $��26��6<   5�      5�      