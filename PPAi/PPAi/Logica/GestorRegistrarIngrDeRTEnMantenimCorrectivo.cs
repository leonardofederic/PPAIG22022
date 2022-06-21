using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.Entidades;
using PPAi.Formularios;
using PPAi.AccesoDatos;

namespace PPAi.Logica
{
    class GestorRegistrarIngrDeRTEnMantenimCorrectivo
    {
        private Ventana_Secuandario pantalla;
        private Ventana_Turnos pantalla_turnos = new Ventana_Turnos();
        private List<RecursoTecnológico> lisRT;
        private RecursoTecnológico rt;
        private Sesion sesion;
        private Estado estado;
        private List<AsignacionRepotTecRT> asigResTecRT;
        private AsignacionRepotTecRT ra;
        private PersonalCientífico pc;
        private RecursoTecnológico rtSelec = Datos.RTseleccionadoPrueba;
        private DateTime fechaFinPrevistaSeleccionada = new DateTime(2022, 06, 11, 15, 32, 20);
        private DateTime timeActual;
        private string razonMantenimientoIngresado;
        private List<Turno> listaTurnos; //resultado del metodo buscarExistenciaTurno
        private Estado esConfMCorr;
        private Estado esEnMCorr;
        private Estado disponible;
        private DateTime fechaActual;


        public GestorRegistrarIngrDeRTEnMantenimCorrectivo()//Ventana_Secuandario pantalla)
        {
            //this.pantalla = pantalla;
        }

        //public static int obtenerUsuarioLogueado() { }
        public void tomarRegIngreRTMantenimCorrect()
        {
            PersonalCientífico per1 = new PersonalCientífico();
            AsignacionRepotTecRT asig = new AsignacionRepotTecRT();
            PersonalCientífico pc = per1.obtenerPersonalCientifico();
            CentroDeInvestigacion ci = Datos.ci;
            obtenerUsuarioLogueado(ci);
            ra = asig.obtenerRTCientifico(pc);
            (lisRT) = buscarRTDisponible(ra);
            pantalla.CargarGrilla(lisRT);

            pantalla.solicitarSeleccionRT();
        }

        public void obtenerUsuarioLogueado(CentroDeInvestigacion ci)
        {
            this.sesion = Datos.sesion;
            this.sesion.mostrarCientifico(sesion);
        }

        public void buscarEstadoDisponible ()
        {
            //flalta metos es estado para arroje estado disponible DateTime.Now.ToString("hh:mm:ss");
        }

        public void tomarFechaYHoraActualSistema()
        {
            fechaActual = DateTime.Now;
        }
        public List<RecursoTecnológico> buscarRTDisponible(AsignacionRepotTecRT ra)
        {
            lisRT = ra.obtenerRTDisponibles(ra);
            if (lisRT.Count == 0)
            {
                 pantalla.mensajeNoEcontrado();
            }

            return lisRT;
        }
        public RecursoTecnológico tomarRTSelecionado(string numero)
        {
            for (int i = 0; lisRT.Count > i; i++)
            {
                if (lisRT[i].NumeroRT.ToString().Equals(numero))
                {
                    rtSelec = lisRT[i];
                }
            }
            return rtSelec;
        }

        public void tomarFechaPrevistaDatosMant(DateTime fechaFin)
        {
            this.fechaFinPrevistaSeleccionada = fechaFin;
        }
        public void tomarMotivoMantenimiento(string razon)
        {
            this.razonMantenimientoIngresado = razon;
            buscarExistenciaTurno();
        }
        public void buscarExistenciaTurno()
        {
            Estado pendienteDeConfirmacion = null; // estado recuperado de la lista de estados
            Estado confirmado = null; // estado recuperado de la lista de estados
            timeActual = fechaActual;

            foreach (Estado estado in Datos.conocerEstados()) // obtenemos los 2 estados necesarios
            {
                if (estado.esAmbitoReserva())
                {
                    if (estado.esPendienteConfirmacion()) { pendienteDeConfirmacion = estado; }
                    else if (estado.esConfirmado()) { confirmado = estado; }
                }
            }
            listaTurnos = rtSelec.mostrarTurnoReservado(pendienteDeConfirmacion, confirmado, fechaFinPrevistaSeleccionada, Datos.asignacionesCientificosDelCI()); // obtenemos los datos de los turnos
            ordenarPorCientifico(listaTurnos);
            pantalla_turnos.mostrarDatosTurnoReservado(listaTurnos);
        }
        public static List<Turno> ordenarPorCientifico(List<Turno> turnos)
        { return turnos; }
    } 
}




