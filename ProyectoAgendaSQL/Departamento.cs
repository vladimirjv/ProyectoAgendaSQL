using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaSQL
{
    class Departamento
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

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Departamento(int id)
        {
            this.id = id;
        }
        public Departamento(int id, string nombre, string descripcion)
            : this(id)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
