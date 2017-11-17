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
    /// Interaction logic for wConsulta.xaml
    /// </summary>
    public partial class wConsulta : Window
    {
        List<Empleado> empleado = new List<Empleado>();

        public wConsulta()
        {
            InitializeComponent();
            cmbDepartamento.ItemsSource = DBAgenda.listaDepartamentos();
            cmbDepartamento.DisplayMemberPath = "Nombre";
            cmbDepartamento.Items.Refresh();
            cmbDepartamento.SelectedIndex = 0;

            cmbBoxSucursal.ItemsSource = DBAgenda.listaSucursales();
            cmbBoxSucursal.DisplayMemberPath = "Nombre";
            cmbBoxSucursal.Items.Refresh();
            cmbBoxSucursal.SelectedIndex = 0;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (cbSinNombre.IsChecked==true)
            {
                empleado = DBAgenda.ConsultaEmpleadosSinNombre(((Departamento)cmbDepartamento.SelectedItem).Nombre, ((Sucursal)cmbBoxSucursal.SelectedItem).Nombre);
                listviewConsulta.ItemsSource = empleado;
                listviewConsulta.Items.Refresh();
            }
            else 
            {
                empleado = DBAgenda.ConsultaEmpleadosConNombre(txtNombre.Text,((Departamento)cmbDepartamento.SelectedItem).Nombre,((Sucursal)cmbBoxSucursal.SelectedItem).Nombre);
                listviewConsulta.ItemsSource = empleado;
                listviewConsulta.Items.Refresh();
            }
        }

        private void btnCerrarBusqueda_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void winConsulta_Closed(object sender, EventArgs e)
        {
            MainWindow.inicio.Show();
        }
    }
}
