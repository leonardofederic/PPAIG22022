using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAi.Entidades
{
    public class CentroDeInvestigacion
    {
        private string nombre;
        private List<RecursoTecnológico> recursosTecnologicos;
        private List<AsignaciónCientíficoDelCI> asignaci;

        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = value;
        }

        public List<RecursoTecnológico> RecursosTecnologicos
        {
            get => this.recursosTecnologicos;
            set => this.recursosTecnologicos = value;
        }

        public List<AsignaciónCientíficoDelCI> AsignaciónCientificoDelCIs
        {
            get => this.asignaci;
            set => this.asignaci = value;
        }

        public CentroDeInvestigacion()
        {

        }

        public CentroDeInvestigacion(string nombre, List<RecursoTecnológico> recursosTecnologicos, List<AsignaciónCientíficoDelCI> asignaci)
        {
            this.nombre = nombre;
            this.recursosTecnologicos = recursosTecnologicos;
            this.asignaci = asignaci;

        }

        public bool esDeCentroDeInvestigacion(CentroDeInvestigacion ci, Sesion sesion)
        {
            for (int i = 0; i < ci.asignaci.Count; i++)
            {
                bool esCentroInve = asignaci[i].esDeCentroDeInvestigacion(sesion.UsuarioSeleccionado);
                if (esCentroInve)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
