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
            DBAgenda.DBConectar();
        }

        private void btnAccederLogin_Click(object sender, RoutedEventArgs e)
        {
            
            List<Empleado> userEmpleadoLogIn = DBAgenda.MatchUsuarioEmpleado(txtUsuario.Text);  //Busca un empleado

            if (userEmpleadoLogIn.Count == 0)
            {
                List<Administrador> userAdministradorLogIn = DBAgenda.MatchUsuarioAdministrador(txtUsuario.Text);  //Busca un administrador
                if (userAdministradorLogIn.Count == 0)
                {
                    MessageBox.Show("User No Encontrado");
                }
                else
                {
                    if (userAdministradorLogIn.ElementAt(0).Password == txtPassword.Password)
                        (new wEmpleado()).Show();
                    else
                        MessageBox.Show("Contraseña Admin Incorrecta");
                }
            }
            else {
                if (userEmpleadoLogIn.ElementAt(0).Password == txtPassword.Password)
                    (new wEmpleado()).Show();
                else
                    MessageBox.Show("Contraseña Empleado Incorrecta");
            }
        }

    }
}
