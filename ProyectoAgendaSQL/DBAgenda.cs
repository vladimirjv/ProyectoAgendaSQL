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

        public static List<Empleado> BuscarUserEmpleadoLogIn(string userEmpleado)
        {
            List<Empleado> listaUserEmpleado = new List<Empleado>();
            string consulta = string.Format("SELECT * FROM Empleado WHERE User LIKE '{0}'", userEmpleado);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaUserEmpleado.Add(new Empleado(reader.GetInt32(0), reader.GetString(7), reader.GetString(8)));
            }

            reader.Close();
            return listaUserEmpleado;
        }

    }
}
