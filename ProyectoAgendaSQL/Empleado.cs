using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaSQL
{
    class Empleado
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string fax;
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int departamento;
        public int Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        private int sucursal;
        public int Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
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

        public Empleado(int id)
        {
            this.id = id;
        }

        public Empleado(int id, string usuario, string password)
            : this(id)
        {
            this.usuario = usuario;
            this.password = password;
        }

        public Empleado(int id, string nombre, string telefono, string fax, string email, int departamento, int sucursal, string usuario, string password)
            : this(id)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.fax = fax;
            this.email = email;
            this.departamento = departamento;
            this.sucursal = sucursal;
            this.usuario = usuario;
            this.password = password;
        }
    }
}
