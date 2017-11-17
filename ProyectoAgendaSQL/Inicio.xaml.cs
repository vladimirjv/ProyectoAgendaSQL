﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoAgendaSQL
{
    /// <summary>
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
        }


        

        private void itemAdmin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (new Adminitrador()).Show();
            this.Close();
        }

        private void itemConsultas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (new wConsulta()).Show();
            this.Close();
        }

        private void itemEmpleado_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (new wEmpleado()).Show();
            this.Close();
        }

        private void CerrarSeción_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }

        

        

        
    }
}
