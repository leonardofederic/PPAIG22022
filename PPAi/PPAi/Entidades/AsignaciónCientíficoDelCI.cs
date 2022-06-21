using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.AccesoDatos;

namespace PPAi.Entidades
{
    public class AsignaciónCientíficoDelCI
    {
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        private PersonalCientífico pc;
        private List<Turno> turnos;

        public DateTime FechaDesde
        {
            get => fechaDesde;
            set => fechaDesde = value;
        }

        public DateTime FechaHasta
        {
            get => fechaHasta;
            set => fechaHasta = value;
        }

        public PersonalCientífico PC
        {
            get => pc;
            set => pc = value;
        }

        public List<Turno> Turno
        {
            get => turnos; set => turnos = value;
        }

        public AsignaciónCientíficoDelCI()
        {

        }

        public AsignaciónCientíficoDelCI(DateTime fechaDesde, DateTime fechaHasta, PersonalCientífico pc, List<Turno> turnos)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.pc = pc;
            this.turnos = turnos;

        }

        public bool esDeCentroDeInvestigacion(Usuario usuario)
        {
            if (usuario.NombreDeUsuario.ToString() == PC.UsuarioActual.ToString())
            {
                return true;
            }
            return false;
        }

        /*public (string, string) mostrarDatosCientifico(Turno t)
        {
            for (int i = 0; i < turnos.Count; i++)
            {
                if (turnos[i] == t)
                {
                    string nom = this.pc.getNombre();
                    string mail = this.PC.getMail();
                    return (nom, mail);
                }
            }
            return (null, null);
        }*/
        public bool esTuTurno(Turno turn)
        {
            // si la asignacionCientifico posee el turno enviado como parametro retorna true
            bool respuesta = false;
            foreach (Turno turno in turnos)
            {
                if (turno.Id == turn.Id) { respuesta = true; }
            }
            return respuesta;
        }
        public string mostrarDatosCientifico()
        {
            //retorna una lista con los datos minimos del personal cientifico asocioado a esta asignacionCientifico
            return pc.mostrarDatos();
        }
    }
}
