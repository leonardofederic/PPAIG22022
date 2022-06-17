using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.AccesoDatos;

namespace PPAi.Entidades
{
    public class Reserva
    {
        public Reserva()
        {

        }
        private int _idReserva;
        private Estado _estado;
        private string _fechaInicio;
        private string _fechaFin;

        public int idReserva
        {
            get => _idReserva;
            set => _idReserva = value;
        }
        public Estado estado
        {
            get => _estado;
            set => _estado = value;
        }
        public string fechaInicio
        {
            get => _fechaInicio;
            set => _fechaInicio = value;
        }
        public string fechaFin
        {
            get => _fechaFin;
            set => _fechaFin = value;
        }
        
        public bool esConfirmado(Estado confirmado) { return estado == confirmado; }
        public bool esPendienteDeConfirmacion(Estado pendienteDeConfirmacion) { return estado == pendienteDeConfirmacion; }
        public string mostrarReserva() //devuleve la fecha y hora de inicio
        {
            /*List<string> datos = new List<string>();
            datos.Add(fechaInicio);
            datos.Add(fechaFin);*/

            return fechaInicio;
        }
    }
}
