using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaSQL
{
    class Administrador
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Administrador()
        {

        }

        public Administrador(int id, string usuario, string password)
        {
            this.id = id;
            this.usuario = usuario;
            this.password = password;
        }
    }
}
