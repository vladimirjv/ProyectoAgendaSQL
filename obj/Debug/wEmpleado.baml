   M S B A M L   `   `   `  ����  ProyectoAgendaSQL!    ProyectoAgendaSQL.wEmpleado   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	wEmpleado��5   	   $��563.179��6   $��747.761��6,   .��5      � .+�5   
   �� $��Agenda Empleados��6   $
��Left=�6+   $��
252,10,0,0q�6F   $	��Top=�6Z   $��22(�6r   �� 5   
   -   5         ��Name$ 	txtNombre��5      $
��Left=�6%   $��26��6@   $��
139,68,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��290��6�   $��15(�6�    � Cursor$ IBeam��6�    �� 	MaxLength$ 40��6�   �� 5   
   -   5        $ txtTelefono��5      $
��Left=�6'   $��26��6B   $��139,103,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��290��6�   $��15(�6�   $ 10��6�   �� 5	   
   -   5        $ txtFax��5	      $
��Left=�6"   $��26��6=   $��139,138,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��290��6�   $��15(�6�   $ 10��6�   �� 5
   
   -   5        $ txtEmail��5
      $
��Left=�6$   $��26��6?   $��139,173,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��290��6�   $��15(�6�   $ 40��6�   �� 5   
   $��Nombre:��6   $
��Left=�6"   $��	60,64,0,0q�6=   $	��Top=�6P   $��15(�6h   �� 5   
   $��
Teléfono:��6   $
��Left=�6$   $��	60,99,0,0q�6?   $	��Top=�6R   $��15(�6j   �� 5   
   $
��Fax:��6   $
��Left=�6   $��
60,134,0,0q�6:   $	��Top=�6N   $��15(�6f   �� 5   
   $��Email:��6   $
��Left=�6!   $��
60,176,0,0q�6<   $	��Top=�6P   $��15(�6h   �� 5   
   $��Departamento:��6   $
��Left=�6(   $��
60,211,0,0q�6C   $	��Top=�6W   $��15(�6o   �� 5   
   $��	Sucursal:��6   $
��Left=�6$   $��
62,246,0,0q�6?   $	��Top=�6S   $��15(�6k   �� 5   
   -   5         ��Name$ cmbDepartamento��5      $
��Left=�6,   $��178,215,0,0q�6G   $	��Top=�6\   $	��174��6t   $��26��6�   �� 5   
   -   5        $ cmbSucursal��5      $
��Left=�6(   $��178,250,0,0q�6C   $	��Top=�6X   $	��174��6p   $��26��6|   �� 5   
   -   5        $ 
txtUsuario��5      $
��Left=�6&   $��26��6A   $��
556,67,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��134��6�   $��15(�6�   $ IBeam��6�   $ 10��6�   �� 5   
   $��Usuario��6   $
��Left=�6"   $��
477,63,0,0q�6=   $	��Top=�6Q   $��15(�6i   �� 5   
   $��	Password:��6   $
��Left=�6$   $��
477,99,0,0q�6?   $	��Top=�6S   $��15(�6k   G� 5   
   -	   5         G�Name$ txtPassword��5      $
��Left=�6+   $��557,103,0,0q�6F   $	��Top=�6[   $	��133��6s   $��26��6    G� 	MaxLength$ 8��6�   �� 5   
   -
   5         ��Name$ 
btnAgregar��5      $��Agregar��6%   $
��Left=�67   $��582,256,0,0q�6R   $	��Top=�6g   $��76��6   6�   �� 5   
   -   5        $ txtBuscarEmpleado��5      $
��Left=�6-   $��26��6H   $��
71,312,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $	��378��6�   $��15(�6�   $ IBeam��6�   $ 40��6�   6�   �� 5   
   $��Buscar:��6   $
��Left=�6"   $��
10,308,0,0q�6=   $	��Top=�6Q   $��15(�6i   	 J� RenderTransformOrigin$	 	0.839,0.6&�6w   �� 5   
   -   5        $ btnModificar��5      $��	Modificar��6'   $
��Left=�6;   $��476,314,0,0q�6V   $	��Top=�6k   $��76��6�   6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��582,314,0,0q�6T   $	��Top=�6i   $��76��6�   �� 5   
   -   5        
 ��Name$
 listViewEmpleados��5      $
��Left=�6.   $	��100��6I   $��
10,342,0,0q�6V   $	��Top=�6j   $	��720��6�    �� View 5      �� 5      .P�5      �� $��Nombre��6%    �� Width$	 100��6]    �� DisplayMemberBinding 65   �� *Nombre+6]   �� 5       $��	Teléfono��6%   $	 100��6a    67   �� *
Telefono+6a   �� 5!      $	��Fax��6%   $	 100��6W    62   �� *Fax+6W   �� 5"      $��Email��6%   $	 100��6[    64   �� *Email+6[   �� 5#      $��Departamento��6%   $	 100��6p    6;   �� *Departamento.Nombre+6p   �� 5$      $��Sucursal��6%   $	 100��6h    67   �� *Sucursal.Nombre+6h   5%      5'      �� 5(   
   -   5        $ btnSalir��5(      $��Salir��6#   $
��Left=�63   $��22��6N   $��582,486,0,0q�6Z   $	��Top=�6o   $��76��6�   6�   5*      5+      