﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.AccesoDatos;

namespace PPAi.Entidades
{
    public class Turno
    {
        private int id;
        private DateTime fechaGeneracion;
        private string diaSemana;
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private List<CambioEstadoTurno> cambioEstado;
        private AsignaciónCientíficoDelCI asignacion;

        private CambioEstadoTurno ultimo;

        public int Id
        {
            get => id; set => id = value;
        }

        public string DiaSemana
        {
            get => diaSemana;
            set => diaSemana = value;
        }

        public DateTime FechaHoraInicio
        {
            get => fechaHoraInicio; set => fechaHoraInicio = value;
        }

        public DateTime FechaHoraFin
        {
            get => fechaHoraFin; set => fechaHoraFin = value;
        }

        public DateTime FechaGeneracion
        {
            get => fechaGeneracion; set => fechaGeneracion = value;
        }
        public List<CambioEstadoTurno> CambioEstado
        {
            get => cambioEstado; set => cambioEstado = value;
        }

        public AsignaciónCientíficoDelCI AsignacionCientifico
        {
            get => asignacion;
            set => asignacion = value;
        }

        public Turno()
        {

        }

        public Turno(int id, DateTime fechaGeneracion, string diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin, List<CambioEstadoTurno> cambioEstado)
        {
            this.fechaGeneracion = fechaGeneracion;
            this.diaSemana = diaSemana;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.cambioEstado = cambioEstado;


        }

        public bool esCancelableEnPeriodo(int dia, int mes)
        {
            bool es = esDePeriodo(this, dia, mes);
            if (es)
            {
                foreach (CambioEstadoTurno cambio in cambioEstado)
                {
                    if (cambio.esActual())
                    {
                        this.ultimo = cambio;
                    }

                }

                if (ultimo.esCancelable())
                {
                    return true;
                }
                //return false;
            }
            return false;
        }

        private bool esDePeriodo(Turno turno, int dia, int mes)
        {
            if (turno.fechaHoraFin.Month <= mes && turno.fechaHoraFin.Day <= dia)
            {
                return true;
            }

            return false;
        }

        public bool esConReserva()
        {
            if (ultimo.esConReserva())
            {
                return true;
            }
            return false;
        }

        public void mostrarDatosTurno()
        {
            DateTime fechaHora = getFechaHora(this);
            obtenerCientifico();
            //return (fechaHora, nom, mail);
        }

        public DateTime getFechaHora(Turno t)
        {
            return t.FechaHoraFin;
        }

        public (string, string) obtenerCientifico()
        {
            asignacion = Datos.asigCienti;
            (string nom, string mail) = this.AsignacionCientifico.mostrarDatosCientifico(this);
            return (nom, mail);
        }

        public void setFechaFin(DateTime time, Estado estado)
        {
            ultimo.FechaHoraHasta = time;
            this.CambioEstado.Add(new CambioEstadoTurno(time, null, estado));
        }
    }
}
