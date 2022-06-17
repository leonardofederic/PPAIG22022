namespace PPAi
{
    partial class Ventana_Pricipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Btn_Principal = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registrar Recurso Tecnológico";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "Registrar reserva de turno para utilización de RT";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(30, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(254, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "Registrar inicio de uso de RT";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(30, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(254, 47);
            this.button4.TabIndex = 3;
            this.button4.Text = "Procesar turnos no utilizados y no reservad";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(30, 258);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(254, 47);
            this.button5.TabIndex = 4;
            this.button5.Text = "Registrar inicio de mantenimiento";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Btn_Principal
            // 
            this.Btn_Principal.Location = new System.Drawing.Point(30, 312);
            this.Btn_Principal.Name = "Btn_Principal";
            this.Btn_Principal.Size = new System.Drawing.Size(254, 47);
            this.Btn_Principal.TabIndex = 5;
            this.Btn_Principal.Text = "Registrar ingreso de RT en mantenimiento correctivo";
            this.Btn_Principal.UseVisualStyleBackColor = true;
            this.Btn_Principal.Click += new System.EventHandler(this.Btn_Principal_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(30, 366);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(254, 47);
            this.button7.TabIndex = 6;
            this.button7.Text = "Emitir reporte de centros y recursos de SeCyT";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(512, 394);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(113, 53);
            this.Btn_Cancelar.TabIndex = 7;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Location = new System.Drawing.Point(380, 394);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(113, 53);
            this.Btn_Aceptar.TabIndex = 8;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(644, 394);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(113, 53);
            this.Btn_Salir.TabIndex = 9;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPAi.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(769, 459);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Aceptar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Btn_Principal);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Pantalla Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button Btn_Principal;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.Button Btn_Salir;
    }
}

