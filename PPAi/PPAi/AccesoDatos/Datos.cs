using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.Entidades;

namespace PPAi.AccesoDatos
{
    public class Datos
    {
        private static Estado confirmado = new Estado(7, "Confirmado", "Descripcion", "Reserva", false, false);
        private static Estado pendienteDeConfirmacion = new Estado(7, "Pendiente de confirmacion", "Descripcion", "Reserva", false, false);

        public static readonly DateTime date1 = new DateTime(2022, 06, 10, 08, 30, 01);
        public static readonly DateTime date2 = new DateTime(2022, 06, 01, 09, 15, 45);
        public static readonly DateTime date3 = new DateTime(2022, 06, 20, 11, 20, 15);
        public static readonly DateTime date4 = new DateTime(2022, 06, 11, 15, 32, 20);

        public static readonly AsignaciónCientíficoDelCI asigCienti = new AsignaciónCientíficoDelCI(date1, date2, new PersonalCientífico(25, "Santiago", "Perez", 38123456, "santiago@frc.utn.edu.ar", "santiago@gmail.com", 351669784, usuario), agregarTurnos());

        public static readonly Mantenimiento mantenimiento = new Mantenimiento();

        public static readonly Marca marca1 = new Marca(1, "SuperSu", agregarModelo());

        public static readonly PersonalCientífico pc = new PersonalCientífico(25, "Maria", "Rodriguez", 38977075, "maria@frc.utn.edu.ar", "mariar95@gmail.com", 351669784, usuario);

        public static readonly Sesion sesion = new Sesion(DateTime.Now, DateTime.Now, usuario);

        public static readonly Usuario usuario = new Usuario("leonardo", "1234", true);
        public static readonly Usuario usuario2 = new Usuario("admin", "1234", false);

        public static readonly CentroDeInvestigacion ci = new CentroDeInvestigacion("Centro 1", agregarRT(), agregarAsignacion());
        public static readonly RecursoTecnológico RTseleccionadoPrueba = new RecursoTecnológico(5, date1, "imagen", 10, 20, 5, agregarTurnos(), new TipoRecursoTecnológico(2, "Osciloscopio", "Tipo2"), new Modelo(2, "Ya-xun"), agregarCamEstado());
        public static List<AsignacionRepotTecRT> crearAsignaciones()
        {
            List<AsignacionRepotTecRT> asigna = new List<AsignacionRepotTecRT>();
            asigna.Add(new AsignacionRepotTecRT(date1, null, agregarRT(), new PersonalCientífico(25, "Santiago", "Perez", 36985214, "santiago@frc.utn.edu.ar", "santiago85@gmail.com", 351565784, usuario)));
            asigna.Add(new AsignacionRepotTecRT(date1, null, agregarRT(), new PersonalCientífico(25, "Santiago", "Perez", 36985214, "santiago@frc.utn.edu.ar", "santiago85@gmail.com", 351565784, usuario)));
            asigna.Add(new AsignacionRepotTecRT(date1, date2, agregarRT(), new PersonalCientífico(28, "Maria", "Rodriguez", 38977075, "maria@frc.utn.edu.ar", "maria95@gmail.com", 351676784, usuario)));
            asigna.Add(new AsignacionRepotTecRT(date1, date2, agregarRT(), new PersonalCientífico(121, "Matias", "Vasquez", 38369987, "matias@unc.edu.ar", "matiasV556@gmail.com", 351556695, usuario2)));
            asigna.Add(new AsignacionRepotTecRT(date1, date2, agregarRT(), new PersonalCientífico(121, "Matias", "Vasquez", 38369987, "matias@unc.edu.ar", "matiasV556@gmail.com", 351683695, usuario2)));
            return asigna;
        }

        private static List<RecursoTecnológico> agregarRT()
        {
            List<RecursoTecnológico> list = new List<RecursoTecnológico>();

            list.Add(new RecursoTecnológico(1, date1, "imagen", 10, 20, 5, agregarTurnos(), new TipoRecursoTecnológico(1, "Balanza", "Tipo1"), new Modelo(1, "Systel"), agregarCamEstado()));
            list.Add(new RecursoTecnológico(2, date1, "imagen", 10, 20, 5, agregarTurnos(), new TipoRecursoTecnológico(2, "Microscopio", "Tipo2"), new Modelo(2, "Quiltech"), agregarCamEstado()));
            list.Add(new RecursoTecnológico(3, date1, "imagen", 10, 20, 5, agregarTurnos(), new TipoRecursoTecnológico(3, "Computadora", "Tipo3"), new Modelo(3, "Intel"), agregarCamEstado()));
            list.Add(new RecursoTecnológico(4, date1, "imagen", 10, 20, 5, agregarTurnos(), new TipoRecursoTecnológico(1, "Resonador magnético", "Tipo1"), new Modelo(1, "Siemens"), agregarCamEstado()));
            list.Add(new RecursoTecnológico(5, date1, "imagen", 10, 20, 5, agregarTurnos(), new TipoRecursoTecnológico(2, "Osciloscopio", "Tipo2"), new Modelo(2, "Ya-xun"), agregarCamEstado()));
            return list;
        }


        
        private static List<Turno> agregarTurnos()
        {
            List<Turno> turnos = new List<Turno>();
    
            Turno turno1 = new Turno(1, date1, "Lunes", date2, date4, agregarCambioEstado());
            Turno turno2 = new Turno(2, date1, "Martes", date2, date3, agregarCambioEstado());
            Turno turno3 = new Turno(3, date1, "Miercoles", date2, date4, agregarCambioEstado());
            Turno turno4 = new Turno(4, date1, "Viernes", date2, date3, agregarCambioEstado());
            turno1.AsignacionCientifico = asigCienti;
            turno2.AsignacionCientifico = asigCienti;
            turno3.AsignacionCientifico = asigCienti;
            turno4.AsignacionCientifico = asigCienti;
            turno1.Reserva = new Reserva(confirmado, date2, date3);
            turno2.Reserva = new Reserva(pendienteDeConfirmacion, date1, date3);
            turno3.Reserva = new Reserva(confirmado, date2, date4);
            turno4.Reserva = new Reserva(pendienteDeConfirmacion, date3, date4);

            turnos.Add(turno1);
            turnos.Add(turno2);
            turnos.Add(turno3);
            turnos.Add(turno4);
            return turnos;
        }

        private static List<Modelo> agregarModelo()
        {
            List<Modelo> lis = new List<Modelo>();

            lis.Add(new Modelo(1, "Systel"));
            lis.Add(new Modelo(2, "Quiltech"));
            lis.Add(new Modelo(3, "Intel"));
            lis.Add(new Modelo(4, "Siemens"));
            lis.Add(new Modelo(5, "Ya-xun"));
            return lis;
        }

        private static List<CambioEstadoRT> agregarCamEstado()
        {
            List<CambioEstadoRT> list = new List<CambioEstadoRT>();

            list.Add(new CambioEstadoRT(date1, date1, new Estado(1, "Disponible", "Descripcion", "Recurso Tecnologico", false, false)));
            list.Add(new CambioEstadoRT(date1, date2, new Estado(1, "Disponible", "Descripcion", "Recurso Tecnologico", false, false)));
            list.Add(new CambioEstadoRT(date2, date3, new Estado(1, "Disponible", "Descripcion", "Recurso Tecnologico", false, false)));
            list.Add(new CambioEstadoRT(date3, null, new Estado(1, "Disponible", "Descripcion", "Recurso Tecnologico", false, false)));
            list.Add(new CambioEstadoRT(date1, date4, new Estado(6, "Mantenimiento Correctivo", "Descripcion", "Recurso Tecnologico", false, false)));
            list.Add(new CambioEstadoRT(date1, date4, new Estado(7, "Preventivo", "Descripcion", "Recurso Tecnologico", false, false)));
            return list;

        }

        private static List<CambioEstadoTurno> agregarCambioEstado()
        {
            List<CambioEstadoTurno> list = new List<CambioEstadoTurno>();

            list.Add(new CambioEstadoTurno(date1, date2, new Estado(2, "Cancelable", "Descripcion", "Turno", false, true)));
            list.Add(new CambioEstadoTurno(date2, date3, new Estado(3, "Reservado", "Descripcion", "Turno", true, false)));
            list.Add(new CambioEstadoTurno(date2, date3, new Estado(5, "CanceladoMantenimientoCorrectivo", "Descripcion", "Turno", false, false)));
            list.Add(new CambioEstadoTurno(date4, null, new Estado(4, "PendienteConfirmacionReserva", "Descripcion", "Turno", true, true)));
            return list;
        }

        private static List<AsignaciónCientíficoDelCI> agregarAsignacion()
        {
            List<AsignaciónCientíficoDelCI> list = new List<AsignaciónCientíficoDelCI>();

            list.Add(asigCienti);
            return list;
        }
        
        public static List<Estado> conocerEstados()
        {
            List<Estado> list = new List<Estado>();
            list.Add(new Estado(1, "Disponible", "Descripcion", "Recurso Tecnologico", false, false));
            list.Add(new Estado(2, "Cancelable", "Descripcion", "Turno", false, true));
            list.Add(new Estado(3, "Reservado", "Descripcion", "Turno", true, false));
            list.Add(new Estado(4, "PendienteConfirmacionReserva", "Descripcion", "Turno", false, false));
            list.Add(new Estado(5, "CanceladoMantenimientoCorrectivo", "Descripcion", "Turno", false, false));
            list.Add(new Estado(6, "Mantenimiento Correctivo", "Descripcion", "Recurso Tecnologico", false, false));
            list.Add(new Estado(7, "Preventivo", "Descripcion", "Recurso Tecnologico", false, false));
            list.Add(pendienteDeConfirmacion);
            list.Add(confirmado);

            return list;
        }
        public static List<AsignaciónCientíficoDelCI> asignacionesCientificosDelCI() //devuelve una lista de asignaciciones de cientificos para el paso de los turnos
        {
            List<AsignaciónCientíficoDelCI> asignacion = new List<AsignaciónCientíficoDelCI>();
            asignacion.Add(asigCienti);
            return asignacion;
        }
    }
}
