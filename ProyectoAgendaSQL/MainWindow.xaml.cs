using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoAgendaSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAccederLogin_Click(object sender, RoutedEventArgs e)
        {
            List<Empleado> userLogIn = DBAgenda.BuscarUserEmpleadoLogIn(txtUsuario.Text);
            if (userLogIn.Count == 0)
                MessageBox.Show("User Empleado Not Found");
            else
                MessageBox.Show("User Empleado Found");
            
        }

        
    }
}
