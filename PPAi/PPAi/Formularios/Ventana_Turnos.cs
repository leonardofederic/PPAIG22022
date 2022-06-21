using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAi.Entidades;

namespace PPAi.Formularios
{
    public partial class Ventana_Turnos : Form
    {
        public Ventana_Turnos()
        {
            InitializeComponent();
        }
        public void mostrarDatosTurnoReservado(List<Turno> turnos) //llega una lista con los turnos que seran cancelados
        {
            DataRow row;
            DataColumn column;
            try
            {
                grillaTurnos.DataSource = turnos;
                DataTable tablaRecursos = new DataTable();

                column = new DataColumn();
                column.ColumnName = "Inicio";
                tablaRecursos.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "Fin";
                tablaRecursos.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "Cientifico";
                tablaRecursos.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "Mail";
                tablaRecursos.Columns.Add(column);

                foreach (Turno t in turnos)
                {
                    row = tablaRecursos.NewRow();
                    row["Inicio"] = t.Reserva.FechaInicio;
                    row["Fin"] = t.Reserva.FechaFin;
                    row["Cientifico"] = t.AsignacionCientifico.PC.Nombre.ToString();
                    row["Mail"] = t.AsignacionCientifico.PC.CorreoInstitu.ToString();
                    tablaRecursos.Rows.Add(row);
                }

                grillaTurnos.DataSource = tablaRecursos;
                grillaTurnos.Sort(grillaTurnos.Columns["Cientifico"], ListSortDirection.Ascending);

                this.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay listado de recursos tecnologicos");
            }
        }
    }
}
