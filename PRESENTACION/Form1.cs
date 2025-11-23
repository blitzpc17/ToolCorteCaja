using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using ClosedXML.Excel;
using System.IO;

namespace PRESENTACION
{
    public partial class Form1 : Form
    {
        private DataTable conceptosTable;
        private Dictionary<double, NumericUpDown> desgloseControls;

        public Form1()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void InitializeApp()
        {
            // Inicializar base de datos
            DatabaseHelper.InitializeDatabase();

            // Configurar tabla de conceptos
            conceptosTable = new DataTable();
            conceptosTable.Columns.Add("Descripción", typeof(string));
            conceptosTable.Columns.Add("Tipo", typeof(string));
            conceptosTable.Columns.Add("Valor", typeof(decimal));

            dataGridViewConceptos.DataSource = conceptosTable;

            // Configurar controles de desglose
            InitializeDesgloseControls();

            // Cargar historial
            CargarHistorial();

            // Estilo moderno
            ApplyModernStyle();
        }

        private void InitializeDesgloseControls()
        {
            desgloseControls = new Dictionary<double, NumericUpDown>
        {
            { 500, numeric500 },
            { 200, numeric200 },
            { 100, numeric100 },
            { 50, numeric50 },
            { 20, numeric20 },
            { 10, numeric10 },
            { 5, numeric5 },
            { 1, numeric1 },
            { 0.5, numeric050 }
        };

            foreach (var control in desgloseControls.Values)
            {
                control.ValueChanged += (s, e) => CalcularTotalDesglose();
            }
        }

        private void ApplyModernStyle()
        {
            // Colores modernos
            Color primaryColor = Color.FromArgb(41, 128, 185);
            Color secondaryColor = Color.FromArgb(52, 152, 219);
            Color backgroundColor = Color.FromArgb(236, 240, 241);

            this.BackColor = backgroundColor;
            panelHeader.BackColor = primaryColor;
            labelTitle.ForeColor = Color.White;

            // Estilo para botones
            foreach (Control control in GetAllControls(this))
            {
                if (control is Button button)
                {
                    button.BackColor = secondaryColor;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Cursor = Cursors.Hand;
                    button.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                    yield return child;
            }
        }

        // Evento para agregar concepto
        private void btnAgregarConcepto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos del concepto.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string descripcion = txtDescripcion.Text;
            string tipo = radioEntrada.Checked ? "Entrada" : "Salida";
            decimal valor = decimal.Parse(txtValor.Text);

            conceptosTable.Rows.Add(descripcion, tipo, valor);

            // Limpiar campos
            txtDescripcion.Clear();
            txtValor.Clear();

            // Calcular totales
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal totalEntradas = 0;
            decimal totalSalidas = 0;

            foreach (DataRow row in conceptosTable.Rows)
            {
                decimal valor = (decimal)row["Valor"];
                if ((string)row["Tipo"] == "Entrada")
                    totalEntradas += valor;
                else
                    totalSalidas += valor;
            }

            lblTotalEntradas.Text = totalEntradas.ToString("C2");
            lblTotalSalidas.Text = totalSalidas.ToString("C2");
            lblTotalCaja.Text = (totalEntradas - totalSalidas).ToString("C2");
        }

        private void CalcularTotalDesglose()
        {
            decimal total = 0;

            foreach (var kvp in desgloseControls)
            {
                double denominacion = kvp.Key;
                int cantidad = (int)kvp.Value.Value;
                total += (decimal)(denominacion * cantidad);
            }

            lblTotalEfectivo.Text = total.ToString("C2");
        }

        // Guardar corte en base de datos
        private void btnGuardarCorte_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalEntradas = decimal.Parse(lblTotalEntradas.Text.Replace("$", "").Replace(",", ""));
                decimal totalSalidas = decimal.Parse(lblTotalSalidas.Text.Replace("$", "").Replace(",", ""));
                decimal totalCaja = decimal.Parse(lblTotalCaja.Text.Replace("$", "").Replace(",", ""));

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Insertar corte principal
                    string insertCorte = @"
                    INSERT INTO CortesCaja (Descripcion, Tipo, Valor, TotalEntradas, TotalSalidas, TotalCaja)
                    VALUES (@Descripcion, @Tipo, @Valor, @TotalEntradas, @TotalSalidas, @TotalCaja);
                    SELECT last_insert_rowid();";

                    long corteId = 0;
                    using (var command = new SQLiteCommand(insertCorte, connection))
                    {
                        command.Parameters.AddWithValue("@Descripcion", "Corte de Caja");
                        command.Parameters.AddWithValue("@Tipo", "Corte");
                        command.Parameters.AddWithValue("@Valor", totalCaja);
                        command.Parameters.AddWithValue("@TotalEntradas", totalEntradas);
                        command.Parameters.AddWithValue("@TotalSalidas", totalSalidas);
                        command.Parameters.AddWithValue("@TotalCaja", totalCaja);

                        corteId = (long)command.ExecuteScalar();
                    }

                    // Insertar desglose de efectivo
                    string insertDesglose = @"
                    INSERT INTO DesgloseEfectivo (CorteId, Denominacion, Cantidad, Subtotal)
                    VALUES (@CorteId, @Denominacion, @Cantidad, @Subtotal)";

                    foreach (var kvp in desgloseControls)
                    {
                        using (var command = new SQLiteCommand(insertDesglose, connection))
                        {
                            command.Parameters.AddWithValue("@CorteId", corteId);
                            command.Parameters.AddWithValue("@Denominacion", kvp.Key);
                            command.Parameters.AddWithValue("@Cantidad", (int)kvp.Value.Value);
                            command.Parameters.AddWithValue("@Subtotal", kvp.Key * (int)kvp.Value.Value);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Insertar conceptos individuales
                    string insertConcepto = @"
                    INSERT INTO CortesCaja (Descripcion, Tipo, Valor, TotalEntradas, TotalSalidas, TotalCaja)
                    VALUES (@Descripcion, @Tipo, @Valor, 0, 0, 0)";

                    foreach (DataRow row in conceptosTable.Rows)
                    {
                        using (var command = new SQLiteCommand(insertConcepto, connection))
                        {
                            command.Parameters.AddWithValue("@Descripcion", row["Descripción"]);
                            command.Parameters.AddWithValue("@Tipo", row["Tipo"]);
                            command.Parameters.AddWithValue("@Valor", row["Valor"]);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Corte guardado exitosamente!", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"
                    SELECT 
                        Id,
                        Fecha,
                        TotalEntradas as 'Total Entradas',
                        TotalSalidas as 'Total Salidas',
                        TotalCaja as 'Total Caja'
                    FROM CortesCaja 
                    WHERE Tipo = 'Corte'
                    ORDER BY Fecha DESC";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewHistorial.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files|*.xlsx";
                    saveDialog.Title = "Guardar reporte de corte";
                    saveDialog.FileName = $"Corte_Caja_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        GenerarExcel(saveDialog.FileName);
                        MessageBox.Show("Reporte Excel generado exitosamente!", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar Excel: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarExcel(string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Corte de Caja");

                // Título
                worksheet.Cell("A1").Value = "CORTE DE CAJA";
                worksheet.Cell("A1").Style.Font.Bold = true;
                worksheet.Cell("A1").Style.Font.FontSize = 16;
                worksheet.Range("A1:D1").Merge();

                // Desglose de efectivo (izquierda)
                worksheet.Cell("A3").Value = "DESGLOSE DE EFECTIVO";
                worksheet.Cell("A3").Style.Font.Bold = true;

                int row = 4;
                decimal totalEfectivo = 0;

                foreach (var kvp in desgloseControls.OrderByDescending(x => x.Key))
                {
                    worksheet.Cell($"A{row}").Value = $"${kvp.Key:N2}";
                    worksheet.Cell($"B{row}").Value = (int)kvp.Value.Value;
                    worksheet.Cell($"C{row}").Value = (decimal)(kvp.Key * (int)kvp.Value.Value);
                    totalEfectivo += (decimal)(kvp.Key * (int)kvp.Value.Value);
                    row++;
                }

                worksheet.Cell($"A{row}").Value = "TOTAL EFECTIVO:";
                worksheet.Cell($"A{row}").Style.Font.Bold = true;
                worksheet.Cell($"C{row}").Value = totalEfectivo;
                worksheet.Cell($"C{row}").Style.Font.Bold = true;

                // Corte de caja (derecha)
                worksheet.Cell("E3").Value = "CORTE DE CAJA";
                worksheet.Cell("E3").Style.Font.Bold = true;

                row = 4;
                worksheet.Cell($"E{row}").Value = "CONCEPTO";
                worksheet.Cell($"F{row}").Value = "TIPO";
                worksheet.Cell($"G{row}").Value = "VALOR";
                worksheet.Cell($"E{row}:G{row}").Style.Font.Bold = true;
                row++;

                decimal totalEntradas = 0;
                decimal totalSalidas = 0;

                foreach (DataRow concepto in conceptosTable.Rows)
                {
                    worksheet.Cell($"E{row}").Value = concepto["Descripción"].ToString();
                    worksheet.Cell($"F{row}").Value = concepto["Tipo"].ToString();
                    worksheet.Cell($"G{row}").Value = (decimal)concepto["Valor"];

                    if (concepto["Tipo"].ToString() == "Entrada")
                        totalEntradas += (decimal)concepto["Valor"];
                    else
                        totalSalidas += (decimal)concepto["Valor"];

                    row++;
                }

                worksheet.Cell($"E{row}").Value = "TOTAL ENTRADAS:";
                worksheet.Cell($"F{row}").Value = totalEntradas;
                worksheet.Cell($"E{row}:F{row}").Style.Font.Bold = true;
                row++;

                worksheet.Cell($"E{row}").Value = "TOTAL SALIDAS:";
                worksheet.Cell($"F{row}").Value = totalSalidas;
                worksheet.Cell($"E{row}:F{row}").Style.Font.Bold = true;
                row++;

                worksheet.Cell($"E{row}").Value = "TOTAL CAJA:";
                worksheet.Cell($"F{row}").Value = totalEntradas - totalSalidas;
                worksheet.Cell($"E{row}:F{row}").Style.Font.Bold = true;

                // Formato de moneda
                worksheet.Range("C4:C" + (desgloseControls.Count + 4)).Style.NumberFormat.Format = "$#,##0.00";
                worksheet.Range("F4:G" + (row)).Style.NumberFormat.Format = "$#,##0.00";

                // Autoajustar columnas
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        private void LimpiarFormulario()
        {
            conceptosTable.Clear();
            foreach (var control in desgloseControls.Values)
            {
                control.Value = 0;
            }
            txtDescripcion.Clear();
            txtValor.Clear();
            radioEntrada.Checked = true;
            CalcularTotales();
            CalcularTotalDesglose();
        }

        private void btnNuevoCorte_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            tabControl.SelectedTab = tabCaptura;
        }
    }
}
