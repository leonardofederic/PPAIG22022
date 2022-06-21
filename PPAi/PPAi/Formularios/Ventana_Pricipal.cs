using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAi.Formularios;
using PPAi.Logica;

namespace PPAi
{
    public partial class Ventana_Pricipal : Form
    {
        public Ventana_Pricipal()
        {
            InitializeComponent();
        }

        private void Btn_Principal_Click(object sender, EventArgs e)
        {
            //Ventana_Secuandario ventana = new Ventana_Secuandario();
            //ventana.Show();
            //this.Hide();
            GestorRegistrarIngrDeRTEnMantenimCorrectivo gestor = new GestorRegistrarIngrDeRTEnMantenimCorrectivo();
            gestor.buscarExistenciaTurno();
            this.Hide();

        }
    }
}
