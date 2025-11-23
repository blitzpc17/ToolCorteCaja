namespace PRESENTACION
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCaptura;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.DataGridView dataGridViewHistorial;
        private System.Windows.Forms.Button btnGenerarExcel;
        private System.Windows.Forms.Button btnNuevoCorte;
        private System.Windows.Forms.DateTimePicker dateTimePicker;

        // Controles para captura de conceptos
        private System.Windows.Forms.GroupBox groupBoxConceptos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.RadioButton radioEntrada;
        private System.Windows.Forms.RadioButton radioSalida;
        private System.Windows.Forms.Button btnAgregarConcepto;
        private System.Windows.Forms.DataGridView dataGridViewConceptos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        // Controles para totales
        private System.Windows.Forms.GroupBox groupBoxTotales;
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Label lblTotalSalidas;
        private System.Windows.Forms.Label lblTotalCaja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        // Controles para desglose de efectivo
        private System.Windows.Forms.GroupBox groupBoxDesglose;
        private System.Windows.Forms.NumericUpDown numeric500;
        private System.Windows.Forms.NumericUpDown numeric200;
        private System.Windows.Forms.NumericUpDown numeric100;
        private System.Windows.Forms.NumericUpDown numeric50;
        private System.Windows.Forms.NumericUpDown numeric20;
        private System.Windows.Forms.NumericUpDown numeric10;
        private System.Windows.Forms.NumericUpDown numeric5;
        private System.Windows.Forms.NumericUpDown numeric1;
        private System.Windows.Forms.NumericUpDown numeric050;
        private System.Windows.Forms.Label lblTotalEfectivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuardarCorte;

        // Labels para denominaciones
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCaptura = new System.Windows.Forms.TabPage();
            this.btnGuardarCorte = new System.Windows.Forms.Button();
            this.groupBoxDesglose = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTotalEfectivo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numeric050 = new System.Windows.Forms.NumericUpDown();
            this.numeric1 = new System.Windows.Forms.NumericUpDown();
            this.numeric5 = new System.Windows.Forms.NumericUpDown();
            this.numeric10 = new System.Windows.Forms.NumericUpDown();
            this.numeric20 = new System.Windows.Forms.NumericUpDown();
            this.numeric50 = new System.Windows.Forms.NumericUpDown();
            this.numeric100 = new System.Windows.Forms.NumericUpDown();
            this.numeric200 = new System.Windows.Forms.NumericUpDown();
            this.numeric500 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxTotales = new System.Windows.Forms.GroupBox();
            this.lblTotalCaja = new System.Windows.Forms.Label();
            this.lblTotalSalidas = new System.Windows.Forms.Label();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewConceptos = new System.Windows.Forms.DataGridView();
            this.groupBoxConceptos = new System.Windows.Forms.GroupBox();
            this.btnAgregarConcepto = new System.Windows.Forms.Button();
            this.radioSalida = new System.Windows.Forms.RadioButton();
            this.radioEntrada = new System.Windows.Forms.RadioButton();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarExcel = new System.Windows.Forms.Button();
            this.btnNuevoCorte = new System.Windows.Forms.Button();
            this.dataGridViewHistorial = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabCaptura.SuspendLayout();
            this.groupBoxDesglose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric050)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric200)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric500)).BeginInit();
            this.groupBoxTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConceptos)).BeginInit();
            this.groupBoxConceptos.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(262, 32);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Sistema de Corte Caja";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 640);
            this.panelMain.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCaptura);
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 640);
            this.tabControl.TabIndex = 3;
            // 
            // tabCaptura
            // 
            this.tabCaptura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tabCaptura.Controls.Add(this.btnGuardarCorte);
            this.tabCaptura.Controls.Add(this.groupBoxDesglose);
            this.tabCaptura.Controls.Add(this.groupBoxTotales);
            this.tabCaptura.Controls.Add(this.dataGridViewConceptos);
            this.tabCaptura.Controls.Add(this.groupBoxConceptos);
            this.tabCaptura.Location = new System.Drawing.Point(4, 26);
            this.tabCaptura.Name = "tabCaptura";
            this.tabCaptura.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaptura.Size = new System.Drawing.Size(992, 610);
            this.tabCaptura.TabIndex = 0;
            this.tabCaptura.Text = "Captura de Corte";
            // 
            // btnGuardarCorte
            // 
            this.btnGuardarCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardarCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCorte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCorte.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCorte.Location = new System.Drawing.Point(800, 550);
            this.btnGuardarCorte.Name = "btnGuardarCorte";
            this.btnGuardarCorte.Size = new System.Drawing.Size(180, 45);
            this.btnGuardarCorte.TabIndex = 4;
            this.btnGuardarCorte.Text = "Guardar Corte";
            this.btnGuardarCorte.UseVisualStyleBackColor = false;
            this.btnGuardarCorte.Click += new System.EventHandler(this.btnGuardarCorte_Click);
            // 
            // groupBoxDesglose
            // 
            this.groupBoxDesglose.BackColor = System.Drawing.Color.White;
            this.groupBoxDesglose.Controls.Add(this.numericUpDown2);
            this.groupBoxDesglose.Controls.Add(this.label18);
            this.groupBoxDesglose.Controls.Add(this.label17);
            this.groupBoxDesglose.Controls.Add(this.lblTotalEfectivo);
            this.groupBoxDesglose.Controls.Add(this.label7);
            this.groupBoxDesglose.Controls.Add(this.numeric050);
            this.groupBoxDesglose.Controls.Add(this.numeric1);
            this.groupBoxDesglose.Controls.Add(this.numeric5);
            this.groupBoxDesglose.Controls.Add(this.numeric10);
            this.groupBoxDesglose.Controls.Add(this.numeric20);
            this.groupBoxDesglose.Controls.Add(this.numeric50);
            this.groupBoxDesglose.Controls.Add(this.numeric100);
            this.groupBoxDesglose.Controls.Add(this.numeric200);
            this.groupBoxDesglose.Controls.Add(this.numeric500);
            this.groupBoxDesglose.Controls.Add(this.label16);
            this.groupBoxDesglose.Controls.Add(this.label15);
            this.groupBoxDesglose.Controls.Add(this.label14);
            this.groupBoxDesglose.Controls.Add(this.label13);
            this.groupBoxDesglose.Controls.Add(this.label12);
            this.groupBoxDesglose.Controls.Add(this.label11);
            this.groupBoxDesglose.Controls.Add(this.label10);
            this.groupBoxDesglose.Controls.Add(this.label9);
            this.groupBoxDesglose.Controls.Add(this.label8);
            this.groupBoxDesglose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDesglose.Location = new System.Drawing.Point(600, 300);
            this.groupBoxDesglose.Name = "groupBoxDesglose";
            this.groupBoxDesglose.Size = new System.Drawing.Size(380, 240);
            this.groupBoxDesglose.TabIndex = 3;
            this.groupBoxDesglose.TabStop = false;
            this.groupBoxDesglose.Text = "Desglose de Efectivo";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(282, 112);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(80, 25);
            this.numericUpDown2.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(202, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 17);
            this.label18.TabIndex = 20;
            this.label18.Text = "Moneda $2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(185, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 17);
            this.label17.TabIndex = 19;
            this.label17.Text = "Moneda $0.50";
            // 
            // lblTotalEfectivo
            // 
            this.lblTotalEfectivo.AutoSize = true;
            this.lblTotalEfectivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalEfectivo.Location = new System.Drawing.Point(286, 207);
            this.lblTotalEfectivo.Name = "lblTotalEfectivo";
            this.lblTotalEfectivo.Size = new System.Drawing.Size(54, 21);
            this.lblTotalEfectivo.TabIndex = 18;
            this.lblTotalEfectivo.Text = "$ 0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(183, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Total Efectivo:";
            // 
            // numeric050
            // 
            this.numeric050.Location = new System.Drawing.Point(283, 175);
            this.numeric050.Name = "numeric050";
            this.numeric050.Size = new System.Drawing.Size(80, 25);
            this.numeric050.TabIndex = 16;
            // 
            // numeric1
            // 
            this.numeric1.Location = new System.Drawing.Point(282, 143);
            this.numeric1.Name = "numeric1";
            this.numeric1.Size = new System.Drawing.Size(80, 25);
            this.numeric1.TabIndex = 15;
            // 
            // numeric5
            // 
            this.numeric5.Location = new System.Drawing.Point(280, 81);
            this.numeric5.Name = "numeric5";
            this.numeric5.Size = new System.Drawing.Size(80, 25);
            this.numeric5.TabIndex = 14;
            // 
            // numeric10
            // 
            this.numeric10.Location = new System.Drawing.Point(280, 50);
            this.numeric10.Name = "numeric10";
            this.numeric10.Size = new System.Drawing.Size(80, 25);
            this.numeric10.TabIndex = 13;
            // 
            // numeric20
            // 
            this.numeric20.Location = new System.Drawing.Point(100, 170);
            this.numeric20.Name = "numeric20";
            this.numeric20.Size = new System.Drawing.Size(80, 25);
            this.numeric20.TabIndex = 12;
            // 
            // numeric50
            // 
            this.numeric50.Location = new System.Drawing.Point(100, 140);
            this.numeric50.Name = "numeric50";
            this.numeric50.Size = new System.Drawing.Size(80, 25);
            this.numeric50.TabIndex = 11;
            // 
            // numeric100
            // 
            this.numeric100.Location = new System.Drawing.Point(100, 110);
            this.numeric100.Name = "numeric100";
            this.numeric100.Size = new System.Drawing.Size(80, 25);
            this.numeric100.TabIndex = 10;
            // 
            // numeric200
            // 
            this.numeric200.Location = new System.Drawing.Point(100, 80);
            this.numeric200.Name = "numeric200";
            this.numeric200.Size = new System.Drawing.Size(80, 25);
            this.numeric200.TabIndex = 9;
            // 
            // numeric500
            // 
            this.numeric500.Location = new System.Drawing.Point(100, 50);
            this.numeric500.Name = "numeric500";
            this.numeric500.Size = new System.Drawing.Size(80, 25);
            this.numeric500.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(202, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 17);
            this.label16.TabIndex = 7;
            this.label16.Text = "Moneda $1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(200, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "Moneda $5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(193, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Moneda $10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 174);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "Moneda $20";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "Moneda $50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Billete $100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Billete $200";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Billete $500";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(339, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ingrese la cantidad de billetes y monedas por denominación:";
            // 
            // groupBoxTotales
            // 
            this.groupBoxTotales.BackColor = System.Drawing.Color.White;
            this.groupBoxTotales.Controls.Add(this.lblTotalCaja);
            this.groupBoxTotales.Controls.Add(this.lblTotalSalidas);
            this.groupBoxTotales.Controls.Add(this.lblTotalEntradas);
            this.groupBoxTotales.Controls.Add(this.label6);
            this.groupBoxTotales.Controls.Add(this.label5);
            this.groupBoxTotales.Controls.Add(this.label4);
            this.groupBoxTotales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTotales.Location = new System.Drawing.Point(600, 150);
            this.groupBoxTotales.Name = "groupBoxTotales";
            this.groupBoxTotales.Size = new System.Drawing.Size(380, 140);
            this.groupBoxTotales.TabIndex = 2;
            this.groupBoxTotales.TabStop = false;
            this.groupBoxTotales.Text = "Totales";
            // 
            // lblTotalCaja
            // 
            this.lblTotalCaja.AutoSize = true;
            this.lblTotalCaja.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalCaja.Location = new System.Drawing.Point(150, 95);
            this.lblTotalCaja.Name = "lblTotalCaja";
            this.lblTotalCaja.Size = new System.Drawing.Size(66, 25);
            this.lblTotalCaja.TabIndex = 5;
            this.lblTotalCaja.Text = "$ 0.00";
            // 
            // lblTotalSalidas
            // 
            this.lblTotalSalidas.AutoSize = true;
            this.lblTotalSalidas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTotalSalidas.Location = new System.Drawing.Point(150, 65);
            this.lblTotalSalidas.Name = "lblTotalSalidas";
            this.lblTotalSalidas.Size = new System.Drawing.Size(53, 20);
            this.lblTotalSalidas.TabIndex = 4;
            this.lblTotalSalidas.Text = "$ 0.00";
            // 
            // lblTotalEntradas
            // 
            this.lblTotalEntradas.AutoSize = true;
            this.lblTotalEntradas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalEntradas.Location = new System.Drawing.Point(150, 35);
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(53, 20);
            this.lblTotalEntradas.TabIndex = 3;
            this.lblTotalEntradas.Text = "$ 0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total en Caja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Salidas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Entradas:";
            // 
            // dataGridViewConceptos
            // 
            this.dataGridViewConceptos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConceptos.Location = new System.Drawing.Point(20, 150);
            this.dataGridViewConceptos.Name = "dataGridViewConceptos";
            this.dataGridViewConceptos.Size = new System.Drawing.Size(560, 390);
            this.dataGridViewConceptos.TabIndex = 1;
            // 
            // groupBoxConceptos
            // 
            this.groupBoxConceptos.BackColor = System.Drawing.Color.White;
            this.groupBoxConceptos.Controls.Add(this.btnAgregarConcepto);
            this.groupBoxConceptos.Controls.Add(this.radioSalida);
            this.groupBoxConceptos.Controls.Add(this.radioEntrada);
            this.groupBoxConceptos.Controls.Add(this.txtValor);
            this.groupBoxConceptos.Controls.Add(this.txtDescripcion);
            this.groupBoxConceptos.Controls.Add(this.label3);
            this.groupBoxConceptos.Controls.Add(this.label2);
            this.groupBoxConceptos.Controls.Add(this.label1);
            this.groupBoxConceptos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConceptos.Location = new System.Drawing.Point(20, 20);
            this.groupBoxConceptos.Name = "groupBoxConceptos";
            this.groupBoxConceptos.Size = new System.Drawing.Size(960, 120);
            this.groupBoxConceptos.TabIndex = 0;
            this.groupBoxConceptos.TabStop = false;
            this.groupBoxConceptos.Text = "Captura de Conceptos";
            // 
            // btnAgregarConcepto
            // 
            this.btnAgregarConcepto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAgregarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarConcepto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarConcepto.Location = new System.Drawing.Point(800, 40);
            this.btnAgregarConcepto.Name = "btnAgregarConcepto";
            this.btnAgregarConcepto.Size = new System.Drawing.Size(140, 35);
            this.btnAgregarConcepto.TabIndex = 7;
            this.btnAgregarConcepto.Text = "Agregar Concepto";
            this.btnAgregarConcepto.UseVisualStyleBackColor = false;
            this.btnAgregarConcepto.Click += new System.EventHandler(this.btnAgregarConcepto_Click);
            // 
            // radioSalida
            // 
            this.radioSalida.AutoSize = true;
            this.radioSalida.Location = new System.Drawing.Point(700, 65);
            this.radioSalida.Name = "radioSalida";
            this.radioSalida.Size = new System.Drawing.Size(63, 21);
            this.radioSalida.TabIndex = 6;
            this.radioSalida.Text = "Salida";
            this.radioSalida.UseVisualStyleBackColor = true;
            // 
            // radioEntrada
            // 
            this.radioEntrada.AutoSize = true;
            this.radioEntrada.Checked = true;
            this.radioEntrada.Location = new System.Drawing.Point(700, 40);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(73, 21);
            this.radioEntrada.TabIndex = 5;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "Entrada";
            this.radioEntrada.UseVisualStyleBackColor = true;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(500, 50);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(150, 25);
            this.txtValor.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(120, 50);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(300, 25);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción:";
            // 
            // tabHistorial
            // 
            this.tabHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tabHistorial.Controls.Add(this.dateTimePicker);
            this.tabHistorial.Controls.Add(this.btnGenerarExcel);
            this.tabHistorial.Controls.Add(this.btnNuevoCorte);
            this.tabHistorial.Controls.Add(this.dataGridViewHistorial);
            this.tabHistorial.Location = new System.Drawing.Point(4, 26);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorial.Size = new System.Drawing.Size(992, 610);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "Historial de Cortes";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(20, 20);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker.TabIndex = 3;
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGenerarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarExcel.ForeColor = System.Drawing.Color.White;
            this.btnGenerarExcel.Location = new System.Drawing.Point(800, 15);
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.Size = new System.Drawing.Size(170, 35);
            this.btnGenerarExcel.TabIndex = 2;
            this.btnGenerarExcel.Text = "Generar Excel";
            this.btnGenerarExcel.UseVisualStyleBackColor = false;
            this.btnGenerarExcel.Click += new System.EventHandler(this.btnGenerarExcel_Click);
            // 
            // btnNuevoCorte
            // 
            this.btnNuevoCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNuevoCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCorte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCorte.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCorte.Location = new System.Drawing.Point(620, 15);
            this.btnNuevoCorte.Name = "btnNuevoCorte";
            this.btnNuevoCorte.Size = new System.Drawing.Size(170, 35);
            this.btnNuevoCorte.TabIndex = 1;
            this.btnNuevoCorte.Text = "Nuevo Corte";
            this.btnNuevoCorte.UseVisualStyleBackColor = false;
            this.btnNuevoCorte.Click += new System.EventHandler(this.btnNuevoCorte_Click);
            // 
            // dataGridViewHistorial
            // 
            this.dataGridViewHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorial.Location = new System.Drawing.Point(20, 60);
            this.dataGridViewHistorial.Name = "dataGridViewHistorial";
            this.dataGridViewHistorial.Size = new System.Drawing.Size(950, 530);
            this.dataGridViewHistorial.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Corte de Caja";
            this.tabControl.ResumeLayout(false);
            this.tabCaptura.ResumeLayout(false);
            this.groupBoxDesglose.ResumeLayout(false);
            this.groupBoxDesglose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric050)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric200)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric500)).EndInit();
            this.groupBoxTotales.ResumeLayout(false);
            this.groupBoxTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConceptos)).EndInit();
            this.groupBoxConceptos.ResumeLayout(false);
            this.groupBoxConceptos.PerformLayout();
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}

