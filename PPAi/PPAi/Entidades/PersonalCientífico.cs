using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.AccesoDatos;

namespace PPAi.Entidades
{
    public class PersonalCientífico
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private int numeroDocumento;
        private string correoElectronicoInstitucional;
        private string correoElectronicoPersonal;
        private int telefonoCelular;
        private Usuario usuario;

        public int Legajo
        {
            get => legajo;
            set => legajo = value;
        }
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Apellido
        {
            get => apellido;
            set => apellido = value;
        }

        public int NumeroDocumento
        {
            get => numeroDocumento;
            set => numeroDocumento = value;
        }

        public string CorreoInstitu
        {
            get => correoElectronicoInstitucional; set => correoElectronicoInstitucional = value;
        }

        public string CorreoPersonal
        {
            get => correoElectronicoPersonal; set => correoElectronicoPersonal = value;
        }

        public int TelefonoCelular
        {
            get => telefonoCelular; set => telefonoCelular = value;
        }

        public Usuario UsuarioActual
        {
            get => usuario; set => usuario = value;
        }

        public PersonalCientífico()
        {

        }

        public PersonalCientífico(int legajo, string nombre, string apellido, int numeroDocumento, string correoElectronicoInstitucional, string correoElectronicoPersonal, int telefonoCelular, Usuario usuario)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.numeroDocumento = numeroDocumento;
            this.correoElectronicoInstitucional = correoElectronicoInstitucional;
            this.correoElectronicoPersonal = correoElectronicoPersonal;
            this.telefonoCelular = telefonoCelular;
            this.usuario = usuario;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public string getMail()
        {
            return CorreoInstitu;
        }
        public PersonalCientífico obtenerPersonalCientifico()
        {
            PersonalCientífico pc = new PersonalCientífico();
            pc = Datos.pc;
            return pc;

        }
        public string mostrarDatos()
        {
            /*retorna una lista con los datos minimos del personal cientifico
            List<string> datos = new List<string>();
            datos.Add(Nombre);
            datos.Add(apellido);
            datos.Add(legajo.ToString());*/

            return nombre + " " + apellido;
        }
    }
}
