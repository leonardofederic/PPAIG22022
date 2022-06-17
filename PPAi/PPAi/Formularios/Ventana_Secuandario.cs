using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PPAi.Logica;
using PPAi.Formularios;
using PPAi.Entidades;
using PPAi.AccesoDatos;



namespace PPAi.Formularios
{
    public partial class Ventana_Secuandario : Form
    {
        string numero;
        List<Turno> turnos;
        GestorRegistrarIngrDeRTEnMantenimCorrectivo gestor;
        //int UsuarioLoguidado;
        public Ventana_Secuandario()
        {
            InitializeComponent();
            txtHora.Text = DateTime.Now.ToString("hh:mm:ss");
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gestor = new GestorRegistrarIngrDeRTEnMantenimCorrectivo(this);
            gestor.tomarRegIngreRTMantenimCorrect();
        }
        public void CargarGrilla(List<RecursoTecnológico> rts)
        {
            DataRow row;
            DataColumn column;
            try
            {
                DataTable tablaRecursos = new DataTable();

                column = new DataColumn();
                column.ColumnName = "Numero";
                tablaRecursos.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "Tipo";
                tablaRecursos.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "Marca";
                tablaRecursos.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "Modelo";
                tablaRecursos.Columns.Add(column);

                foreach (RecursoTecnológico r in rts)
                {
                    row = tablaRecursos.NewRow();
                    row["Numero"] = r.NumeroRT;
                    row["Tipo"] = r.TipoRecurso.Nombre.ToString();
                    row["Modelo"] = r.Modelo.Nombre.ToString();
                    row["Marca"] = r.Modelo.Marca.Nombre.ToString();
                    tablaRecursos.Rows.Add(row);
                }

                grillaRTDisponibles.DataSource = tablaRecursos;
                grillaRTDisponibles.Sort(grillaRTDisponibles.Columns["Tipo"], ListSortDirection.Ascending);

                this.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay listado de recursos tecnologicos");
            }
        }

      

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txtFecha.Text.Equals("") || cbx_motivo.Text.Equals(""))
            {
                MessageBox.Show("Por favor Ingresar los datos solicitados.");
            }
            else
            {
                DateTime fechaFin = DateTime.Parse(txtFecha.Text.Trim());
                string motivoMantenimiento = cbx_motivo.Text;
                gestor.tomarFechaPrevistaDatosMant(fechaFin);
                gestor.tomarMotivoMantenimiento(motivoMantenimiento);

            }

            /// solo para ver lo que arroja
            int recursoSelec = Convert.ToInt32(txt_NumeroRT.Text);
            DateTime fecha = Convert.ToDateTime(txt_fechaPrevista.Value.ToString());
            string motivo = cbx_motivo.Text;

            MessageBox.Show(recursoSelec.ToString() + " " + fecha.Date.ToString("dd/MM/yyyy") + " " + motivo.ToString());
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult opc;
            opc = MessageBox.Show("desea cancelar el registro de Mantenimiento ?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opc == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {

        }
        public void solicitarSeleccionRT()
        {
            MessageBox.Show("Por favor seleccionar un recurso tecnologico");
        }

        public void solicitarFechaFinPrevista()
        {
            MessageBox.Show("Ingresar fecha fin prevista y motivo de mantenimiento");
        }
        public void mensajeNoEcontrado()
        {
            DialogResult resultado = MessageBox.Show("No existen recursos asociados al responsable técnico en estado posible de ingresar en mantenimiento correctivo", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (resultado == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay recursos asociados");
                this.Close();
            }
        }

        public void avisoNoturnos()
        {
            DialogResult resultado = MessageBox.Show("No existen turnos reservados a cancelar.", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            
        }

        private void grillaRTDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DataGridViewRow filaseleccionada = grillaRTDisponibles.Rows[indice];
            string numero = filaseleccionada.Cells["Num"].Value.ToString();
            this.numero = numero;
            gestor.tomarRTSelecionado(numero);
            txt_NombreRT.Text = filaseleccionada.Cells["Tipo"].Value.ToString();//estetico
            txt_NumeroRT.Text = numero.ToString();//estetico
            solicitarFechaFinPrevista();
        }
    }
}
