using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        ////////////////////
        //log-in's
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
        ///////////////////////////////////////////////////////////////////
        //Metodos para agregar
        public static int AgregarEmpleado(Empleado empleado)
        {
            int filasAfectadas = 0;
            string consulta = string.Format("INSERT INTO Empleado (Nombre, Telefono, Fax, Email, Departamento, Sucursal, Usuario, Password) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}')", empleado.Nombre, empleado.Telefono, empleado.Fax, empleado.Email, empleado.Departamento.Id, empleado.Sucursal.Id, empleado.Usuario, empleado.Password);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static int AgregarAdministrador(Administrador administrador)
        {
            int filasAfectadas = 0;
            string query = string.Format("INSERT INTO Administrador (Usuario, Password) VALUES ('{0}', '{1}')",administrador.Usuario, administrador.Password);
            SqlCommand comando = new SqlCommand(query, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static int AgregarDepartamento(Departamento departamento)
        {
            int filasAfectadas = 0;
            string query = string.Format("INSERT INTO Departamento (Nombre, Descripcion) VALUES ('{0}', '{1}')", departamento.Nombre,departamento.Descripcion);
            SqlCommand comando = new SqlCommand(query, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static int AgregarSucursal(Sucursal sucursal)
        {
            int filasAfectadas = 0;
            string query = string.Format("INSERT INTO Sucursal (Nombre, Descripcion) VALUES ('{0}', '{1}')", sucursal.Nombre,sucursal.Descripcion);
            SqlCommand comando = new SqlCommand(query, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        /////////////////////////////////////////////////////////////////////
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

        /////////////////////////////////////////////////////////////////////////////
        //problemas con el DataReader
        
        public static Departamento BusquedaIdDepartamento(string departamento)
        {
            Departamento buscado;
            string consulta = string.Format("SELECT * FROM Departameto WHERE Nombre='{0}'", departamento);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            buscado = new Departamento(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return buscado;
        }

        public static Sucursal BusquedaIdSucursal(int id)
        {
            Sucursal buscado;
            string consulta = string.Format("SELECT * FROM Sucursal WHERE Id='{0}'", id);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            buscado = new Sucursal(id, reader.GetString(1), reader.GetString(2));
            reader.Close();
            return buscado;
        }

        //primer metodo que llama al buscar
        //se abre el primer DataReader y al entrar en la función BusquedaIdDepartamento 
        //entra en un segundo DataREader arrojando una exepción 
        public static List<Empleado> BuscarEmpleadosModificarEliminar(string nombreBuscar)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            //string consulta = string.Format("SELECT Id, Nombre, Telefono, Fax, Email, Departamento, Sucursal FROM Empleado WHERE Nombre like '%{0}%'", nombreBuscar);
            string consulta = string.Format("SELECT E.Id, E.Nombre, E.Telefono, E.Fax, E.Email, D.Nombre, S.Nombre, E.Departamento, E.Sucursal, E.Usuario, E.Password  FROM [Empleado] E JOIN Departamento D ON E.Departamento = D.Id JOIN Sucursal S ON E.Sucursal = S.Id WHERE E.Nombre like '%{0}%'", nombreBuscar);
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
                //aux.Departamento = BusquedaIdDepartamento(reader.GetInt32(5));
                aux.Departamento = new Departamento(reader.GetInt32(7), reader.GetString(5));
                //aux.Sucursal= BusquedaIdSucursal(reader.GetInt32(6));
                aux.Sucursal = new Sucursal(reader.GetInt32(8), reader.GetString(6));
                aux.Usuario = reader.GetString(9);
                aux.Password = reader.GetString(10);
                listaEmpleados.Add(aux);
            }

            reader.Close();
            return listaEmpleados;
        }

        public static List<Empleado> ConsultaEmpleadosConNombre(string nombre, string departamento, string sucursal)
        {
            List<Empleado> empleados = new List<Empleado>();
            MessageBox.Show(departamento + sucursal);
            string query = string.Format("SELECT E.Id, E.Nombre, E.Telefono, E.Fax, E.Email, D.Nombre, S.Nombre, E.Departamento, E.Sucursal  FROM [Empleado] E JOIN Departamento D ON E.Departamento = D.Id JOIN Sucursal S ON E.Sucursal = S.Id WHERE E.Nombre LIKE '%{0}%' AND D.Nombre LIKE '%{1}%' AND S.Nombre LIKE '%{2}%'", nombre,departamento,sucursal);
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Empleado aux = new Empleado();
                aux.Id = reader.GetInt32(0);
                aux.Nombre = reader.GetString(1);
                aux.Telefono = reader.GetString(2);
                aux.Fax = reader.GetString(3);
                aux.Email = reader.GetString(4);
                aux.Departamento = new Departamento(reader.GetInt32(7), reader.GetString(5));
                aux.Sucursal = new Sucursal(reader.GetInt32(8), reader.GetString(6));
                empleados.Add(aux);
            }
            reader.Close();
            return empleados;
        }

        public static List<Empleado> ConsultaEmpleadosSinNombre(string departamento, string sucursal)
        {
            List<Empleado> empleados = new List<Empleado>();
            string query = string.Format("SELECT E.Id, E.Nombre, E.Telefono, E.Fax, E.Email, D.Nombre, S.Nombre, E.Departamento, E.Sucursal  FROM [Empleado] E JOIN Departamento D ON E.Departamento = D.Id JOIN Sucursal S ON E.Sucursal = S.Id WHERE D.Nombre LIKE '%{0}%' AND S.Nombre LIKE '%{1}%'",  departamento, sucursal);
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Empleado aux = new Empleado();
                aux.Id = reader.GetInt32(0);
                aux.Nombre = reader.GetString(1);
                aux.Telefono = reader.GetString(2);
                aux.Fax = reader.GetString(3);
                aux.Email = reader.GetString(4);
                aux.Departamento = new Departamento(reader.GetInt32(7), reader.GetString(5));
                aux.Sucursal = new Sucursal(reader.GetInt32(8), reader.GetString(6));
                empleados.Add(aux);
            }

            reader.Close();
            return empleados;
        }

        public static int Eliminar(Empleado empleado)
        {
            string consulta = string.Format("DELETE FROM Empleado WHERE Id='{0}'", empleado.Id);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static int Modificar(Empleado empleado)
        {
            string consulta = string.Format("UPDATE Empleado SET Nombre = '{0}', Telefono = '{1}', Fax = '{2}', Email = '{3}', Departamento = '{4}', Sucursal = '{5}', Usuario = '{6}', Password = '{7}' WHERE Id='{8}';",
                                                empleado.Nombre,
                                                empleado.Telefono,
                                                empleado.Fax,
                                                empleado.Email,
                                                empleado.Departamento.Id,
                                                empleado.Sucursal.Id,
                                                empleado.Usuario,
                                                empleado.Password,
                                                empleado.Id);

            SqlCommand comando = new SqlCommand(consulta, conexion);
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
    }
}