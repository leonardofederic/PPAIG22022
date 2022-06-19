using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAi.Formularios
{
    public partial class Ventana_Turnos : Form
    {
        public Ventana_Turnos()
        {
            InitializeComponent();
        }
        public void mostrarDatosTurnoReservado(DataTable datos) //llega una lista con listas compuestas de [numero de reserva, nombre y apellido del cientifico, fecha y hora de la reserva] todos son strings
        {
            grid_Turno.DataSource = datos;
        }
    }
}
