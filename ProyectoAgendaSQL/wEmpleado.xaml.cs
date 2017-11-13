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
using System.Windows.Shapes;

namespace ProyectoAgendaSQL
{
    /// <summary>
    /// Interaction logic for wEmpleado.xaml
    /// </summary>
    public partial class wEmpleado : Window
    {
        List<Departamento> listaDepartamentos;
        List<Sucursal> listaSucursales;

        public wEmpleado()
        {
            InitializeComponent();

            //Se llenan los ComboBox, y se cargan las listas de departamentos y sucursales.
            listaDepartamentos = DBAgenda.listaDepartamentos();
            cmbDepartamento.ItemsSource = listaDepartamentos;
            cmbDepartamento.DisplayMemberPath = "Nombre";
            cmbDepartamento.Items.Refresh();
            cmbDepartamento.SelectedIndex = 0;

            listaSucursales = DBAgenda.listaSucursales();
            cmbSucursal.ItemsSource = listaSucursales;
            cmbSucursal.DisplayMemberPath = "Nombre";
            cmbSucursal.Items.Refresh();
            cmbSucursal.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try{
                List<Empleado> userEmpleadoLogIn = DBAgenda.MatchUsuarioEmpleado(txtUsuario.Text);
                if (userEmpleadoLogIn.Count == 0)
                {
                    Empleado empleado = new Empleado();
                    empleado.Nombre = txtNombre.Text;
                    empleado.Telefono = txtTelefono.Text;
                    empleado.Fax = txtFax.Text;
                    empleado.Email = txtEmail.Text;
                    empleado.Departamento = listaDepartamentos.ElementAt(cmbDepartamento.SelectedIndex);
                    empleado.Sucursal = listaSucursales.ElementAt(cmbSucursal.SelectedIndex); ;
                    empleado.Usuario = txtUsuario.Text;
                    empleado.Password = txtPassword.Password;
                    DBAgenda.AgregarEmpleado(empleado);

                    MessageBox.Show("Registro Añadido con Exito :)");
                }
                else
                    MessageBox.Show("El usuario ya existe. Favor de introducir otro nombre de usuario ;)");               
            }
            catch(Exception)    {
                MessageBox.Show("Revise los Datos Introducidos :(");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void txtBuscarEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                listViewEmpleados.ItemsSource = DBAgenda.BuscarEmpleadosModificarEliminar(txtBuscarEmpleado.Text);
                listViewEmpleados.Items.Refresh();
            }
        }

        private void listViewEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listViewEmpleados.SelectedItems.Count == 1)
                {
                    Empleado empleadoSeleccionado = (Empleado)listViewEmpleados.SelectedItem;
                    txtNombre.Text = empleadoSeleccionado.Nombre;
                    txtTelefono.Text = empleadoSeleccionado.Telefono;
                    txtFax.Text = empleadoSeleccionado.Fax;
                    txtEmail.Text = empleadoSeleccionado.Telefono;
                    cmbDepartamento.SelectedItem  = empleadoSeleccionado.Departamento;
                    cmbSucursal.SelectedItem = empleadoSeleccionado.Sucursal;
                }
                else
                {
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    txtFax.Text = "";
                    txtEmail.Text = "";
                    cmbDepartamento.SelectedIndex = 0;
                    cmbSucursal.SelectedIndex = 0;
                    txtUsuario.Text = "";
                    txtPassword.Password = "";
                }
            }
            catch (Exception) { }
        }
    }
}
