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
    /// Interaction logic for Adminitrador.xaml
    /// </summary>
    public partial class Adminitrador : Window
    {
        public Adminitrador()
        {
            InitializeComponent();
        }

        private void btmAgregarAdministrador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Administrador administrador = new Administrador();
                administrador.Usuario = txtAdministradorUser.Text;
                administrador.Password = (string)pswAdministrador.Password;
                DBAgenda.AgregarAdministrador(administrador);
            }
            catch (Exception)
            {
                MessageBox.Show("Revise su Información");
            }
        }

        private void btnAgregarDepartamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Departamento departamento = new Departamento();
                departamento.Nombre = txtDepartamentoNombre.Text;
                departamento.Descripcion = txtDepartamentoDescripcion.Text;
                DBAgenda.AgregarDepartamento(departamento);

            }
            catch (Exception)
            {
                MessageBox.Show("Revise Su información");
            }
        }

        private void btnAgregarSucursal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                sucursal.Nombre = txtSucursalNombre.Text;
                sucursal.Descripcion = txtSucursalNombre.Text;
                DBAgenda.AgregarSucursal(sucursal);
            }
            catch (Exception)
            {
                MessageBox.Show("Revise su información");
            }
        }


    }
}
