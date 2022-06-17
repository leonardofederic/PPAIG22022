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
        private List<Turno> turno;

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
            get => turno; set => turno = value;
        }

        public AsignaciónCientíficoDelCI()
        {

        }

        public AsignaciónCientíficoDelCI(DateTime fechaDesde, DateTime fechaHasta, PersonalCientífico pc, List<Turno> turnos)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.pc = pc;
            this.turno = turnos;

        }

        public bool esDeCentroDeInvestigacion(Usuario usuario)
        {
            if (usuario.NombreDeUsuario.ToString() == PC.UsuarioActual.ToString())
            {
                return true;
            }
            return false;
        }

        public (string, string) mostrarDatosCientifico(Turno t)
        {
            for (int i = 0; i < turno.Count; i++)
            {
                if (turno[i] == t)
                {
                    string nom = this.pc.getNombre();
                    string mail = this.PC.getMail();
                    return (nom, mail);
                }
            }
            return (null, null);
        }
    }
}
