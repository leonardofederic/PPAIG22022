using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.AccesoDatos;
using PPAi.Entidades;

namespace PPAi.Entidades
{
    public class AsignacionRepotTecRT
    {
        private DateTime? fechaDesde;
        private DateTime? fechaHasta;
        private List<RecursoTecnológico> rt;
        private PersonalCientífico personal;
        private List<AsignacionRepotTecRT> asigResTecRT;
        private AsignacionRepotTecRT ra;

        public DateTime? FechaDesde
        {
            get => fechaDesde;
            set => fechaDesde = value;
        }

        public DateTime? FechaHasta
        {
            get => fechaHasta;
            set => fechaHasta = value;
        }

        public List<RecursoTecnológico> RT
        {
            get => rt;
            set => rt = value;
        }

        public PersonalCientífico PersonalCientifico
        {
            get => personal; set => personal = value;
        }

        public AsignacionRepotTecRT()
        {

        }
        public AsignacionRepotTecRT(DateTime? fechaDesde, DateTime? fechaHasta, List<RecursoTecnológico> rt, PersonalCientífico personal)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.rt = rt;
            this.personal = personal;
        }

        public List<RecursoTecnológico> obtenerRTDisponibles(AsignacionRepotTecRT ra)
        {
            rt = ra.RT;
            List<string> datos = new List<string>();
            //string tipo, modelo, marca;
            for (int i = 0; i < rt.Count; i++)
            {
                bool esDispo = rt[i].esDisponible(rt[i]);
                if (!esDispo)
                {
                    rt.RemoveAt(i);
                }
            }

            for (int i = 0; i < rt.Count; i++)
            {
                if (rt[i] != null)
                {
                    //(int num, string tipo, string marca, string modelo) = rt[i].mostrarDatosRT(rt[i]);
                    //datos.Add(num.ToString());
                    //datos.Add(tipo);
                    //datos.Add(marca);
                    //datos.Add(modelo);
                }
            }
            return rt;
        }

        public bool esAsignacionVigenteCientifico(AsignacionRepotTecRT asignaciones)
        {
            return esViegente(asignaciones);
        }

        private bool esViegente(AsignacionRepotTecRT asignaciones)
        {
            if (asignaciones.FechaHasta.Equals(null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public AsignacionRepotTecRT obtenerRTCientifico(PersonalCientífico pc)
        {
            asigResTecRT = Datos.crearAsignaciones();
            for (int i = 0; i < asigResTecRT.Count; i++)
            {
                if (asigResTecRT[i].PersonalCientifico.ToString().Equals(pc.ToString()))
                {
                    bool es = asigResTecRT[i].esAsignacionVigenteCientifico(asigResTecRT[i]);
                    if (es)
                    {
                        ra = asigResTecRT[i];
                    }
                }
            }
            return ra;
        }

    }
}
