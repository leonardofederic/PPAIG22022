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
        public Reserva(Estado estado, DateTime fechaInicio, DateTime fechaFin)
        {
            Estado = estado;
            FechaInicio = fechaInicio;  
            FechaFin = fechaFin; 
        }
        //private int _idReserva;
        private Estado estado;
        private DateTime fechaInicio;
        private DateTime fechaFin;

        //public int idReserva
        //{
        //    get => _idReserva;
        //    set => _idReserva = value;
        //}
        public Estado Estado
        {
            get => estado;
            set => estado = value;
        }
        public DateTime FechaInicio
        {
            get => fechaInicio;
            set => fechaInicio = value;
        }
        public DateTime FechaFin
        {
            get => fechaFin;
            set => fechaFin = value;
        }
        
        public bool esConfirmado(Estado confirmado) { return estado == confirmado; }
        public bool esPendienteDeConfirmacion(Estado pendienteDeConfirmacion) { return estado == pendienteDeConfirmacion; }
        public bool mostrarReserva(DateTime fechaFinMantenimiento)
        {
            if( this.FechaInicio <= fechaFinMantenimiento)
            {
                return true;
            }
            return false;
        }
    }
}
