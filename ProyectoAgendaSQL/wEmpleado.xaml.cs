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
                List<Administrador> userAdministradorLogIn = DBAgenda.MatchUsuarioAdministrador(txtUsuario.Text);  //Busca un administrador
                if ((userEmpleadoLogIn.Count == 0 && userAdministradorLogIn.Count == 0))
                {
                        Empleado empleado = new Empleado();
                        empleado.Nombre = txtNombre.Text;
                        empleado.Telefono = txtTelefono.Text;
                        empleado.Fax = txtFax.Text;
                        empleado.Email = txtEmail.Text;
                        empleado.Departamento = (Departamento)listaDepartamentos.ElementAt(cmbDepartamento.SelectedIndex);
                        empleado.Sucursal = (Sucursal)listaSucursales.ElementAt(cmbSucursal.SelectedIndex); ;
                        empleado.Usuario = txtUsuario.Text;
                        empleado.Password = txtPassword.Password;
                        DBAgenda.AgregarEmpleado(empleado);

                        MessageBox.Show("Registro Añadido con Exito :)");
                   }
                    else
                        MessageBox.Show("El usuario ya existe. Favor de introducir otro nombre de usuario ;)");
            } catch(Exception)    {
                //MessageBox.Show("Revise los Datos Introducidos :(");
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
                    txtUsuario.Text = empleadoSeleccionado.Usuario;
                    txtPassword.Password = empleadoSeleccionado.Password;

                    Departamento departamento = listaDepartamentos.Find(s => s.Id == empleadoSeleccionado.Departamento.Id);
                    cmbDepartamento.SelectedItem = departamento;
                    Sucursal sucursal = listaSucursales.Find(s => s.Id == empleadoSeleccionado.Sucursal.Id);
                    cmbSucursal.SelectedItem = sucursal;
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            List<Empleado> userEmpleadoLogIn = DBAgenda.MatchUsuarioEmpleado(txtUsuario.Text);
            List<Administrador> userAdministradorLogIn = DBAgenda.MatchUsuarioAdministrador(txtUsuario.Text);  //Busca un administrador
            if ((userEmpleadoLogIn.Count == 0 && userAdministradorLogIn.Count == 0) || txtUsuario.Text == ((Empleado)listViewEmpleados.SelectedItem).Usuario)
            {
                if (listViewEmpleados.SelectedItems.Count == 1)
                {
                    Empleado auxEmpleado = (Empleado)listViewEmpleados.SelectedItem;
                    Departamento auxDepartamento = (Departamento)cmbDepartamento.SelectedItem;
                    DBAgenda.Modificar(new Empleado(auxEmpleado.Id, txtNombre.Text, txtTelefono.Text, txtFax.Text, txtEmail.Text, (Departamento)cmbDepartamento.SelectedItem, (Sucursal)cmbSucursal.SelectedItem, txtUsuario.Text, txtPassword.Password));
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    txtFax.Text = "";
                    txtEmail.Text = "";
                    cmbDepartamento.SelectedIndex = 0;
                    cmbSucursal.SelectedIndex = 0;
                    txtUsuario.Text = "";
                    txtPassword.Password = "";
                    listViewEmpleados.ItemsSource = null;
                    listViewEmpleados.Items.Refresh();
                    MessageBox.Show("Registro Modificado Exitosamente :)");
                }
            }
            else
            {
                MessageBox.Show("El usuario ya existe. Ingrese otro usuario.");
            }
            }catch (Exception) {}

        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listViewEmpleados.SelectedItems.Count == 1)
                {
                    DBAgenda.Eliminar((Empleado)listViewEmpleados.SelectedItem);
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    txtFax.Text = "";
                    txtEmail.Text = "";
                    txtUsuario.Text = "";
                    txtPassword.Password = "";
                    cmbDepartamento.SelectedIndex = 0;
                    cmbSucursal.SelectedIndex = 0;
                    listViewEmpleados.ItemsSource = null;
                    listViewEmpleados.Items.Refresh();
                    MessageBox.Show("Registro Eliminado Exitosamente");
                }
            }
            catch (Exception) {
                MessageBox.Show("Un error ha ocurrido al eliminar registro");
            }
        }

        private void wEmpleados_Closed(object sender, EventArgs e)
        {
            MainWindow.inicio.Show();
        }
    }
}
