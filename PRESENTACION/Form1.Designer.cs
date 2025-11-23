using System.Collections.Generic;
using System.Windows.Forms;

namespace PRESENTACION
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles principales
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

        // Controles para desglose INICIAL
        //private System.Windows.Forms.GroupBox groupBoxDesgloseInicial;
        //private System.Windows.Forms.NumericUpDown numeric500Inicial;
        //private System.Windows.Forms.NumericUpDown numeric200Inicial;
        //private System.Windows.Forms.NumericUpDown numeric100Inicial;
        //private System.Windows.Forms.NumericUpDown numeric50Inicial;
        //private System.Windows.Forms.NumericUpDown numeric20Inicial;
        //private System.Windows.Forms.NumericUpDown numeric10Inicial;
        //private System.Windows.Forms.NumericUpDown numeric5Inicial;
        //private System.Windows.Forms.NumericUpDown numeric2Inicial;
        //private System.Windows.Forms.NumericUpDown numeric1Inicial;
        //private System.Windows.Forms.NumericUpDown numeric050Inicial;
        //private System.Windows.Forms.Label lblTotalEfectivoInicial;
        //private System.Windows.Forms.Label label7;
        //private System.Windows.Forms.Button btnIniciarCorte;

        // Labels para denominaciones INICIAL
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;

        // Controles para desglose FINAL
        private System.Windows.Forms.GroupBox groupBoxDesgloseFinal;
        private System.Windows.Forms.NumericUpDown numeric500Final;
        private System.Windows.Forms.NumericUpDown numeric200Final;
        private System.Windows.Forms.NumericUpDown numeric100Final;
        private System.Windows.Forms.NumericUpDown numeric50Final;
        private System.Windows.Forms.NumericUpDown numeric20Final;
        private System.Windows.Forms.NumericUpDown numeric10Final;
        private System.Windows.Forms.NumericUpDown numeric5Final;
        private System.Windows.Forms.NumericUpDown numeric2Final;
        private System.Windows.Forms.NumericUpDown numeric1Final;
        private System.Windows.Forms.NumericUpDown numeric050Final;
        private System.Windows.Forms.Label lblTotalEfectivoFinal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCerrarCorte;

        // Labels para denominaciones FINAL
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;

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
            this.groupBoxDesgloseFinal = new System.Windows.Forms.GroupBox();
            this.numeric050Final = new System.Windows.Forms.NumericUpDown();
            this.numeric1Final = new System.Windows.Forms.NumericUpDown();
            this.numeric2Final = new System.Windows.Forms.NumericUpDown();
            this.numeric5Final = new System.Windows.Forms.NumericUpDown();
            this.numeric10Final = new System.Windows.Forms.NumericUpDown();
            this.numeric20Final = new System.Windows.Forms.NumericUpDown();
            this.numeric50Final = new System.Windows.Forms.NumericUpDown();
            this.numeric100Final = new System.Windows.Forms.NumericUpDown();
            this.numeric200Final = new System.Windows.Forms.NumericUpDown();
            this.numeric500Final = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblTotalEfectivoFinal = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnCerrarCorte = new System.Windows.Forms.Button();
            this.groupBoxDesgloseInicial = new System.Windows.Forms.GroupBox();
            this.numeric050Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric1Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric2Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric5Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric10Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric20Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric50Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric100Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric200Inicial = new System.Windows.Forms.NumericUpDown();
            this.numeric500Inicial = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTotalEfectivoInicial = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnIniciarCorte = new System.Windows.Forms.Button();
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
            this.groupBoxDesgloseFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric050Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric5Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric10Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric20Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric50Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric100Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric200Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric500Final)).BeginInit();
            this.groupBoxDesgloseInicial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric050Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric5Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric10Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric20Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric50Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric100Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric200Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric500Inicial)).BeginInit();
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
            this.panelHeader.Size = new System.Drawing.Size(1200, 60);
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
            this.panelMain.Size = new System.Drawing.Size(1200, 740);
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
            this.tabControl.Size = new System.Drawing.Size(1200, 740);
            this.tabControl.TabIndex = 3;
            // 
            // tabCaptura
            // 
            this.tabCaptura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tabCaptura.Controls.Add(this.groupBoxDesgloseFinal);
            this.tabCaptura.Controls.Add(this.groupBoxDesgloseInicial);
            this.tabCaptura.Controls.Add(this.groupBoxTotales);
            this.tabCaptura.Controls.Add(this.dataGridViewConceptos);
            this.tabCaptura.Controls.Add(this.groupBoxConceptos);
            this.tabCaptura.Location = new System.Drawing.Point(4, 26);
            this.tabCaptura.Name = "tabCaptura";
            this.tabCaptura.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaptura.Size = new System.Drawing.Size(1192, 710);
            this.tabCaptura.TabIndex = 0;
            this.tabCaptura.Text = "Captura de Corte";
            // 
            // groupBoxDesgloseFinal
            // 
            this.groupBoxDesgloseFinal.BackColor = System.Drawing.Color.White;
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric050Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric1Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric2Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric5Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric10Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric20Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric50Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric100Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric200Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.numeric500Final);
            this.groupBoxDesgloseFinal.Controls.Add(this.label21);
            this.groupBoxDesgloseFinal.Controls.Add(this.label22);
            this.groupBoxDesgloseFinal.Controls.Add(this.label23);
            this.groupBoxDesgloseFinal.Controls.Add(this.label24);
            this.groupBoxDesgloseFinal.Controls.Add(this.label25);
            this.groupBoxDesgloseFinal.Controls.Add(this.label26);
            this.groupBoxDesgloseFinal.Controls.Add(this.label27);
            this.groupBoxDesgloseFinal.Controls.Add(this.label28);
            this.groupBoxDesgloseFinal.Controls.Add(this.label29);
            this.groupBoxDesgloseFinal.Controls.Add(this.label30);
            this.groupBoxDesgloseFinal.Controls.Add(this.lblTotalEfectivoFinal);
            this.groupBoxDesgloseFinal.Controls.Add(this.label31);
            this.groupBoxDesgloseFinal.Controls.Add(this.btnCerrarCorte);
            this.groupBoxDesgloseFinal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDesgloseFinal.Location = new System.Drawing.Point(600, 400);
            this.groupBoxDesgloseFinal.Name = "groupBoxDesgloseFinal";
            this.groupBoxDesgloseFinal.Size = new System.Drawing.Size(580, 300);
            this.groupBoxDesgloseFinal.TabIndex = 5;
            this.groupBoxDesgloseFinal.TabStop = false;
            this.groupBoxDesgloseFinal.Text = "Desglose de Efectivo Final";
            this.groupBoxDesgloseFinal.Visible = false;
            // 
            // numeric050Final
            // 
            this.numeric050Final.Location = new System.Drawing.Point(483, 175);
            this.numeric050Final.Name = "numeric050Final";
            this.numeric050Final.Size = new System.Drawing.Size(80, 25);
            this.numeric050Final.TabIndex = 21;
            // 
            // numeric1Final
            // 
            this.numeric1Final.Location = new System.Drawing.Point(483, 145);
            this.numeric1Final.Name = "numeric1Final";
            this.numeric1Final.Size = new System.Drawing.Size(80, 25);
            this.numeric1Final.TabIndex = 20;
            // 
            // numeric2Final
            // 
            this.numeric2Final.Location = new System.Drawing.Point(483, 115);
            this.numeric2Final.Name = "numeric2Final";
            this.numeric2Final.Size = new System.Drawing.Size(80, 25);
            this.numeric2Final.TabIndex = 19;
            // 
            // numeric5Final
            // 
            this.numeric5Final.Location = new System.Drawing.Point(483, 85);
            this.numeric5Final.Name = "numeric5Final";
            this.numeric5Final.Size = new System.Drawing.Size(80, 25);
            this.numeric5Final.TabIndex = 18;
            // 
            // numeric10Final
            // 
            this.numeric10Final.Location = new System.Drawing.Point(483, 55);
            this.numeric10Final.Name = "numeric10Final";
            this.numeric10Final.Size = new System.Drawing.Size(80, 25);
            this.numeric10Final.TabIndex = 17;
            // 
            // numeric20Final
            // 
            this.numeric20Final.Location = new System.Drawing.Point(283, 175);
            this.numeric20Final.Name = "numeric20Final";
            this.numeric20Final.Size = new System.Drawing.Size(80, 25);
            this.numeric20Final.TabIndex = 16;
            // 
            // numeric50Final
            // 
            this.numeric50Final.Location = new System.Drawing.Point(283, 145);
            this.numeric50Final.Name = "numeric50Final";
            this.numeric50Final.Size = new System.Drawing.Size(80, 25);
            this.numeric50Final.TabIndex = 15;
            // 
            // numeric100Final
            // 
            this.numeric100Final.Location = new System.Drawing.Point(283, 115);
            this.numeric100Final.Name = "numeric100Final";
            this.numeric100Final.Size = new System.Drawing.Size(80, 25);
            this.numeric100Final.TabIndex = 14;
            // 
            // numeric200Final
            // 
            this.numeric200Final.Location = new System.Drawing.Point(283, 85);
            this.numeric200Final.Name = "numeric200Final";
            this.numeric200Final.Size = new System.Drawing.Size(80, 25);
            this.numeric200Final.TabIndex = 13;
            // 
            // numeric500Final
            // 
            this.numeric500Final.Location = new System.Drawing.Point(283, 55);
            this.numeric500Final.Name = "numeric500Final";
            this.numeric500Final.Size = new System.Drawing.Size(80, 25);
            this.numeric500Final.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(404, 150);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 17);
            this.label21.TabIndex = 11;
            this.label21.Text = "Moneda $1";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(404, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(76, 17);
            this.label22.TabIndex = 10;
            this.label22.Text = "Moneda $2";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(404, 90);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(76, 17);
            this.label23.TabIndex = 9;
            this.label23.Text = "Moneda $5";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(397, 60);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(83, 17);
            this.label24.TabIndex = 8;
            this.label24.Text = "Moneda $10";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(386, 180);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(94, 17);
            this.label25.TabIndex = 7;
            this.label25.Text = "Moneda $0.50";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(200, 180);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 17);
            this.label26.TabIndex = 6;
            this.label26.Text = "Billete $20";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(200, 150);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 17);
            this.label27.TabIndex = 5;
            this.label27.Text = "Billete $50";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(193, 120);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(79, 17);
            this.label28.TabIndex = 4;
            this.label28.Text = "Billete $100";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(193, 90);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(79, 17);
            this.label29.TabIndex = 3;
            this.label29.Text = "Billete $200";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(193, 60);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 17);
            this.label30.TabIndex = 2;
            this.label30.Text = "Billete $500";
            // 
            // lblTotalEfectivoFinal
            // 
            this.lblTotalEfectivoFinal.AutoSize = true;
            this.lblTotalEfectivoFinal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEfectivoFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalEfectivoFinal.Location = new System.Drawing.Point(479, 210);
            this.lblTotalEfectivoFinal.Name = "lblTotalEfectivoFinal";
            this.lblTotalEfectivoFinal.Size = new System.Drawing.Size(54, 21);
            this.lblTotalEfectivoFinal.TabIndex = 1;
            this.lblTotalEfectivoFinal.Text = "$ 0.00";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(379, 213);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 17);
            this.label31.TabIndex = 0;
            this.label31.Text = "Total Efectivo:";
            // 
            // btnCerrarCorte
            // 
            this.btnCerrarCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrarCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCorte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCorte.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCorte.Location = new System.Drawing.Point(400, 250);
            this.btnCerrarCorte.Name = "btnCerrarCorte";
            this.btnCerrarCorte.Size = new System.Drawing.Size(170, 40);
            this.btnCerrarCorte.TabIndex = 22;
            this.btnCerrarCorte.Text = "Cerrar Corte";
            this.btnCerrarCorte.UseVisualStyleBackColor = false;
            this.btnCerrarCorte.Click += new System.EventHandler(this.btnCerrarCorte_Click);
            // 
            // groupBoxDesgloseInicial
            // 
            this.groupBoxDesgloseInicial.BackColor = System.Drawing.Color.White;
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric050Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric1Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric2Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric5Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric10Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric20Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric50Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric100Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric200Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.numeric500Inicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.label8);
            this.groupBoxDesgloseInicial.Controls.Add(this.label9);
            this.groupBoxDesgloseInicial.Controls.Add(this.label10);
            this.groupBoxDesgloseInicial.Controls.Add(this.label11);
            this.groupBoxDesgloseInicial.Controls.Add(this.label12);
            this.groupBoxDesgloseInicial.Controls.Add(this.label13);
            this.groupBoxDesgloseInicial.Controls.Add(this.label14);
            this.groupBoxDesgloseInicial.Controls.Add(this.label15);
            this.groupBoxDesgloseInicial.Controls.Add(this.label16);
            this.groupBoxDesgloseInicial.Controls.Add(this.label17);
            this.groupBoxDesgloseInicial.Controls.Add(this.lblTotalEfectivoInicial);
            this.groupBoxDesgloseInicial.Controls.Add(this.label18);
            this.groupBoxDesgloseInicial.Controls.Add(this.btnIniciarCorte);
            this.groupBoxDesgloseInicial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDesgloseInicial.Location = new System.Drawing.Point(600, 20);
            this.groupBoxDesgloseInicial.Name = "groupBoxDesgloseInicial";
            this.groupBoxDesgloseInicial.Size = new System.Drawing.Size(580, 300);
            this.groupBoxDesgloseInicial.TabIndex = 4;
            this.groupBoxDesgloseInicial.TabStop = false;
            this.groupBoxDesgloseInicial.Text = "Desglose de Efectivo Inicial";
            // 
            // numeric050Inicial
            // 
            this.numeric050Inicial.Location = new System.Drawing.Point(483, 175);
            this.numeric050Inicial.Name = "numeric050Inicial";
            this.numeric050Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric050Inicial.TabIndex = 21;
            // 
            // numeric1Inicial
            // 
            this.numeric1Inicial.Location = new System.Drawing.Point(483, 145);
            this.numeric1Inicial.Name = "numeric1Inicial";
            this.numeric1Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric1Inicial.TabIndex = 20;
            // 
            // numeric2Inicial
            // 
            this.numeric2Inicial.Location = new System.Drawing.Point(483, 115);
            this.numeric2Inicial.Name = "numeric2Inicial";
            this.numeric2Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric2Inicial.TabIndex = 19;
            // 
            // numeric5Inicial
            // 
            this.numeric5Inicial.Location = new System.Drawing.Point(483, 85);
            this.numeric5Inicial.Name = "numeric5Inicial";
            this.numeric5Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric5Inicial.TabIndex = 18;
            // 
            // numeric10Inicial
            // 
            this.numeric10Inicial.Location = new System.Drawing.Point(483, 55);
            this.numeric10Inicial.Name = "numeric10Inicial";
            this.numeric10Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric10Inicial.TabIndex = 17;
            // 
            // numeric20Inicial
            // 
            this.numeric20Inicial.Location = new System.Drawing.Point(283, 175);
            this.numeric20Inicial.Name = "numeric20Inicial";
            this.numeric20Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric20Inicial.TabIndex = 16;
            // 
            // numeric50Inicial
            // 
            this.numeric50Inicial.Location = new System.Drawing.Point(283, 145);
            this.numeric50Inicial.Name = "numeric50Inicial";
            this.numeric50Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric50Inicial.TabIndex = 15;
            // 
            // numeric100Inicial
            // 
            this.numeric100Inicial.Location = new System.Drawing.Point(283, 115);
            this.numeric100Inicial.Name = "numeric100Inicial";
            this.numeric100Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric100Inicial.TabIndex = 14;
            // 
            // numeric200Inicial
            // 
            this.numeric200Inicial.Location = new System.Drawing.Point(283, 85);
            this.numeric200Inicial.Name = "numeric200Inicial";
            this.numeric200Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric200Inicial.TabIndex = 13;
            // 
            // numeric500Inicial
            // 
            this.numeric500Inicial.Location = new System.Drawing.Point(283, 55);
            this.numeric500Inicial.Name = "numeric500Inicial";
            this.numeric500Inicial.Size = new System.Drawing.Size(80, 25);
            this.numeric500Inicial.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Moneda $1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(403, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Moneda $2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(403, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Moneda $5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(396, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Moneda $10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(385, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "Moneda $0.50";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(200, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Billete $20";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(200, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Billete $50";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(193, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 17);
            this.label15.TabIndex = 4;
            this.label15.Text = "Billete $100";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(193, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 17);
            this.label16.TabIndex = 3;
            this.label16.Text = "Billete $200";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 17);
            this.label17.TabIndex = 2;
            this.label17.Text = "Billete $500";
            // 
            // lblTotalEfectivoInicial
            // 
            this.lblTotalEfectivoInicial.AutoSize = true;
            this.lblTotalEfectivoInicial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEfectivoInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalEfectivoInicial.Location = new System.Drawing.Point(479, 210);
            this.lblTotalEfectivoInicial.Name = "lblTotalEfectivoInicial";
            this.lblTotalEfectivoInicial.Size = new System.Drawing.Size(54, 21);
            this.lblTotalEfectivoInicial.TabIndex = 1;
            this.lblTotalEfectivoInicial.Text = "$ 0.00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(379, 213);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "Total Efectivo:";
            // 
            // btnIniciarCorte
            // 
            this.btnIniciarCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnIniciarCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarCorte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarCorte.ForeColor = System.Drawing.Color.White;
            this.btnIniciarCorte.Location = new System.Drawing.Point(400, 250);
            this.btnIniciarCorte.Name = "btnIniciarCorte";
            this.btnIniciarCorte.Size = new System.Drawing.Size(170, 40);
            this.btnIniciarCorte.TabIndex = 22;
            this.btnIniciarCorte.Text = "Iniciar Corte";
            this.btnIniciarCorte.UseVisualStyleBackColor = false;
            this.btnIniciarCorte.Click += new System.EventHandler(this.btnIniciarCorte_Click);
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
            this.groupBoxTotales.Location = new System.Drawing.Point(600, 330);
            this.groupBoxTotales.Name = "groupBoxTotales";
            this.groupBoxTotales.Size = new System.Drawing.Size(580, 60);
            this.groupBoxTotales.TabIndex = 2;
            this.groupBoxTotales.TabStop = false;
            this.groupBoxTotales.Text = "Totales";
            // 
            // lblTotalCaja
            // 
            this.lblTotalCaja.AutoSize = true;
            this.lblTotalCaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalCaja.Location = new System.Drawing.Point(470, 25);
            this.lblTotalCaja.Name = "lblTotalCaja";
            this.lblTotalCaja.Size = new System.Drawing.Size(53, 20);
            this.lblTotalCaja.TabIndex = 5;
            this.lblTotalCaja.Text = "$ 0.00";
            // 
            // lblTotalSalidas
            // 
            this.lblTotalSalidas.AutoSize = true;
            this.lblTotalSalidas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTotalSalidas.Location = new System.Drawing.Point(280, 25);
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
            this.lblTotalEntradas.Location = new System.Drawing.Point(120, 25);
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(53, 20);
            this.lblTotalEntradas.TabIndex = 3;
            this.lblTotalEntradas.Text = "$ 0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Caja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Salidas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 27);
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
            this.dataGridViewConceptos.Size = new System.Drawing.Size(560, 550);
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
            this.groupBoxConceptos.Size = new System.Drawing.Size(560, 120);
            this.groupBoxConceptos.TabIndex = 0;
            this.groupBoxConceptos.TabStop = false;
            this.groupBoxConceptos.Text = "Captura de Conceptos";
            // 
            // btnAgregarConcepto
            // 
            this.btnAgregarConcepto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAgregarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarConcepto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarConcepto.Location = new System.Drawing.Point(400, 40);
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
            this.radioSalida.Location = new System.Drawing.Point(330, 65);
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
            this.radioEntrada.Location = new System.Drawing.Point(330, 40);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(73, 21);
            this.radioEntrada.TabIndex = 5;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "Entrada";
            this.radioEntrada.UseVisualStyleBackColor = true;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(220, 50);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 25);
            this.txtValor.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(100, 50);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(110, 25);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 55);
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
            this.tabHistorial.Size = new System.Drawing.Size(1192, 710);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "Historial de Cortes";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(20, 20);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker.TabIndex = 3;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGenerarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarExcel.ForeColor = System.Drawing.Color.White;
            this.btnGenerarExcel.Location = new System.Drawing.Point(1000, 15);
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
            this.btnNuevoCorte.Location = new System.Drawing.Point(820, 15);
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
            this.dataGridViewHistorial.Size = new System.Drawing.Size(1150, 630);
            this.dataGridViewHistorial.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Corte de Caja";
            this.tabControl.ResumeLayout(false);
            this.tabCaptura.ResumeLayout(false);
            this.groupBoxDesgloseFinal.ResumeLayout(false);
            this.groupBoxDesgloseFinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric050Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric5Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric10Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric20Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric50Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric100Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric200Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric500Final)).EndInit();
            this.groupBoxDesgloseInicial.ResumeLayout(false);
            this.groupBoxDesgloseInicial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric050Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric5Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric10Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric20Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric50Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric100Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric200Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric500Inicial)).EndInit();
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

       
        private System.Windows.Forms.NumericUpDown numeric050Inicial;
        private System.Windows.Forms.NumericUpDown numeric1Inicial;
        private System.Windows.Forms.NumericUpDown numeric2Inicial;
        private System.Windows.Forms.NumericUpDown numeric5Inicial;
        private System.Windows.Forms.NumericUpDown numeric10Inicial;
        private System.Windows.Forms.NumericUpDown numeric20Inicial;
        private System.Windows.Forms.NumericUpDown numeric50Inicial;
        private System.Windows.Forms.NumericUpDown numeric100Inicial;
        private System.Windows.Forms.NumericUpDown numeric200Inicial;
        private System.Windows.Forms.NumericUpDown numeric500Inicial;
       
        private System.Windows.Forms.Button btnIniciarCorte;
        private System.Windows.Forms.GroupBox groupBoxDesgloseInicial;
       
        private System.Windows.Forms.Label lblTotalEfectivoInicial;
    }
}