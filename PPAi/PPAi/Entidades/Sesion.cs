using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAi.AccesoDatos;

namespace PPAi.Entidades
{
    public class Sesion
    {
        private DateTime fechaHoraFin;
        private DateTime fechaHoraInicio;
        private Usuario usuarioSeleccionado;

        public Sesion()
        {

        }

        public Sesion(DateTime fechaHoraFin, DateTime fechaHoraInicio, Usuario usuarioSeleccionado)
        {
            this.fechaHoraFin = fechaHoraFin;
            this.fechaHoraInicio = fechaHoraInicio;
            this.usuarioSeleccionado = usuarioSeleccionado;
        }

        public DateTime FechaHoraInicio
        {
            get => this.fechaHoraInicio;
            set => this.fechaHoraInicio = value;
        }

        public DateTime FechaHoraFin
        {
            get => this.fechaHoraFin;
            set => this.fechaHoraFin = value;
        }

        public Usuario UsuarioSeleccionado
        {
            get => this.usuarioSeleccionado;
            set => this.usuarioSeleccionado = value;
        }

        public Usuario esTuUsuario(string nombreUsuario, string contraseña)
        {
            Usuario logueado = new Usuario(nombreUsuario, contraseña, true);
            this.usuarioSeleccionado = logueado;
            bool usu = logueado.esUsuario(nombreUsuario);
            if (usu)
            {
                return logueado;
            }
            else
            {
                return null;
            }
        }

        public Usuario mostrarCientifico(Sesion sesionActual)
        {
            sesionActual.UsuarioSeleccionado = Datos.usuario;

            if (sesionActual.UsuarioSeleccionado != null)
            {
                return UsuarioSeleccionado.obtenerPersonal();
            }
            else
            {
                MessageBox.Show("No hay usuario seleccionado");
                return null;
            }
        }
    }
}
