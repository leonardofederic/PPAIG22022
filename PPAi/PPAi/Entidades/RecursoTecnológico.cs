using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.AccesoDatos;
using PPAi.Entidades;


namespace PPAi.Entidades
{
    public class RecursoTecnológico
    {


        private int numeroRT;
        private DateTime fechaAlta;
        private string imagenes;
        private int periodicidadMantenimientoPrev;
        private int duracionMantenimientoPrev;
        private int fraccionHorarioTurnos;
        private List<Turno> turno;
        private TipoRecursoTecnológico tipoRecurso;
        private Modelo modelo;
        private List<CambioEstadoRT> cambioEstado;
        private CambioEstadoRT cambioEstadoActual;

        public int NumeroRT
        {
            get => numeroRT; set => numeroRT = value;
        }

        public DateTime FechaAlta
        {
            get => fechaAlta; set => fechaAlta = value;
        }

        public string Imagenes
        {
            get => imagenes; set => imagenes = value;
        }

        public int Periodicidad
        {
            get => periodicidadMantenimientoPrev; set => periodicidadMantenimientoPrev = value;
        }

        public int Duracion
        {
            get => duracionMantenimientoPrev; set => duracionMantenimientoPrev = value;
        }

        public int FraccionHorarioTurno
        {
            get => fraccionHorarioTurnos; set => fraccionHorarioTurnos = value;
        }

        public List<Turno> Turnos
        {
            get => turno; set => turno = value;
        }

        public TipoRecursoTecnológico TipoRecurso
        {
            get => tipoRecurso; set => tipoRecurso = value;
        }

        public Modelo Modelo
        {
            get => modelo; set => modelo = value;
        }

        public List<CambioEstadoRT> CambioEstado
        {
            get => cambioEstado; set => cambioEstado = value;
        }

        public RecursoTecnológico()
        {

        }

        public RecursoTecnológico(int numeroRT, DateTime fechaAlta, string imagenes, int periodicidadMantenimientoPrev, int duracionMantenimientoPrev, int fraccionHorarioTurnos, List<Turno> turnos, TipoRecursoTecnológico tipoRecurso, Modelo modelo, List<CambioEstadoRT> cambioEstado)
        {
            this.numeroRT = numeroRT;
            this.fechaAlta = fechaAlta;
            this.imagenes = imagenes;
            this.periodicidadMantenimientoPrev = periodicidadMantenimientoPrev;
            this.duracionMantenimientoPrev = duracionMantenimientoPrev;
            this.fraccionHorarioTurnos = fraccionHorarioTurnos;
            this.turno = turnos;
            this.tipoRecurso = tipoRecurso;
            this.modelo = modelo;
            this.cambioEstado = cambioEstado;
        }

        public bool esDisponible(RecursoTecnológico rt)
        {
            cambioEstado = rt.CambioEstado;
            for (int i = 0; i < cambioEstado.Count; i++)
            {
                bool esActual = cambioEstado[i].esActual(cambioEstado[i]);
                if (esActual)
                {
                    bool esDisp = cambioEstado[i].esDisponible(cambioEstado[i]);
                    if (esDisp)
                    {
                        this.cambioEstadoActual = cambioEstado[i];
                        return true;
                    }
                }
            }

            return false;
        }

        /*public (int, string, string, string) mostrarDatosRT(RecursoTecnológico rt)
        {
            int num = getNumero(rt);
            string tipo = rt.TipoRecurso.getNombre().Nombre;
            (string marca, string modelo) = rt.Modelo.mostrarMarcaYModelo();

            return (num, tipo, marca, modelo);
        }*/

        public int getNumero(RecursoTecnológico rt)
        {
            return rt.NumeroRT;
        }

        public List<Turno> obtenerTurnosCancelablesEnPeriodo(List<Turno> turnos, int dia, int mes)
        {
            //List<Turno> turnosList = new List<Turno>();
            bool ban = false;
            foreach (Turno turno in this.turno)
            {
                if (turno.esCancelableEnPeriodo(dia, mes) == false)
                {
                    ban = true;
                    //turnos.Remove(turno);
                }
            }
            if (ban)
            {
                return null;
            }
            else
            {
                return turnos;
            }


        }

        public List<Turno> mostrarTurnosReserva(List<Turno> turnos)
        {
            foreach (Turno turno in this.turno)
            {
                if (turno.esConReserva() == false)
                {
                    this.turno.Remove(turno);
                }
            }

            foreach (Turno turno in this.turno)
            {
                turno.mostrarDatosTurno();
            }
            return this.turno;
        }

        public void ingresarEnMantenimientoCorrectivo(DateTime time, DateTime fechaFinPrev, string motivo, Estado estadoRT)
        {
            this.cambioEstadoActual.setFechaFin(time);
            this.cambioEstado.Add(new CambioEstadoRT(time, null, estadoRT));
            List<Mantenimiento> mantenimiento = new List<Mantenimiento>();
            mantenimiento.Add(new Mantenimiento(null, time, fechaFinPrev, motivo));
        }

        public void cancelarTurnos(DateTime time, Estado estadoRT)
        {
            foreach (Turno turno in this.turno)
            {
                turno.setFechaFin(time, estadoRT);
            }
        }
        public List<Turno> mostrarTurnoReservado(Estado pendienteDeConfirmacion, Estado confirmado, DateTime fechaFinMantenimiento, List<AsignaciónCientíficoDelCI> asignacionesCientificos)
        {
            List<Turno> turnosReservados = new List<Turno>();
            foreach (Turno turn in this.turno)
            {
                Turno turnoSeleccionado = turn.mostarReserva(pendienteDeConfirmacion, confirmado, fechaFinMantenimiento, asignacionesCientificos);
                if(turnoSeleccionado != null)
                {
                    turnosReservados.Add(turnoSeleccionado);
                }
            }
            return turnosReservados;
        }
    }
}
