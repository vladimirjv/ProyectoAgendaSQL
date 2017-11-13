using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaSQL
{
    class DBAgenda
    {
        static SqlConnection conexion;
        public static void DBConectar()
        {
            conexion = new SqlConnection("Data Source=LAPTOP-7JPH5U2H\\SQLExpress;Initial Catalog=DB_Agenda;Integrated Security=True");
            conexion.Open();
        }

        public static List<Empleado> MatchUsuarioEmpleado(string userEmpleado)
        {
            List<Empleado> listaUserEmpleado = new List<Empleado>();
            string consulta = string.Format("SELECT Id, Usuario, Password FROM Empleado WHERE Usuario='{0}'", userEmpleado);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaUserEmpleado.Add(new Empleado(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }

            reader.Close();
            return listaUserEmpleado;

           /*string consulta = string.Format("SELECT COUNT(*) FROM Empleado WHERE Usuario='{0}'", userEmpleado);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            return (Int32)comando.ExecuteScalar();*/
        }

        public static List<Administrador> MatchUsuarioAdministrador(string userAdministrador)
        {
            List<Administrador> listaUserAdministrador = new List<Administrador>();
            string consulta = string.Format("SELECT Id, Usuario, Password FROM Administrador WHERE Usuario='{0}'", userAdministrador);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaUserAdministrador.Add(new Administrador(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }

            reader.Close();
            return listaUserAdministrador;
        }

        public static int AgregarEmpleado(Empleado empleado)
        {
            int filasAfectadas = 0;
            string consulta = string.Format("INSERT INTO Empleado (Nombre, Telefono, Fax, Email, Departamento, Sucursal, Usuario, Password) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}')", empleado.Nombre, empleado.Telefono, empleado.Fax, empleado.Email, empleado.Departamento, empleado.Sucursal, empleado.Usuario, empleado.Password);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static List<Departamento> listaDepartamentos()
        {
            List<Departamento> listaDepartamentos = new List<Departamento>();
            string consulta = "SELECT Id, Nombre FROM Departamento";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaDepartamentos.Add(new Departamento(reader.GetInt32(0), reader.GetString(1)));
            }

            reader.Close();
            return listaDepartamentos;
        }

        public static List<Sucursal> listaSucursales()
        {
            List<Sucursal> listaSucursales = new List<Sucursal>();
            string consulta = "SELECT Id, Nombre FROM Sucursal";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaSucursales.Add(new Sucursal(reader.GetInt32(0), reader.GetString(1)));
            }

            reader.Close();
            return listaSucursales;
        }

        public static List<Empleado> BuscarEmpleadosModificarEliminar(string nombreBuscar)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            string consulta = string.Format("SELECT Id, Nombre, Telefono, Fax, Email, Departamento, Sucursal FROM Empleado WHERE Nombre like '%{0}%'", nombreBuscar);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Empleado aux = new Empleado();
                aux.Id = reader.GetInt32(0);
                aux.Nombre = reader.GetString(1);
                aux.Telefono = reader.GetString(2);
                aux.Fax = reader.GetString(3);
                aux.Email = reader.GetString(4);
                aux.Departamento = reader.GetInt32(5);
                aux.Sucursal= reader.GetInt32(6);
                listaEmpleados.Add(aux);
            }

            reader.Close();
            return listaEmpleados;
        }

    }
}
