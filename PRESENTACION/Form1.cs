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

            // Configurar controles de desglose
            InitializeDesgloseControls();
            ConfigureNumericUpDowns();

            // Configurar DateTimePicker
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ValueChanged += (s, e) => CargarHistorialPorFecha();

            // Validación del campo valor
            txtValor.KeyPress += (s, e) =>
            {
                // Permitir números, punto decimal, tecla de retroceso
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // Permitir solo un punto decimal
                if (e.KeyChar == '.' && ((TextBox)s).Text.Contains('.'))
                {
                    e.Handled = true;
                }
            };

            // Seleccionar todo el texto al entrar
            txtValor.Enter += (s, e) =>
            {
                txtValor.SelectAll();
            };

            txtDescripcion.Enter += (s, e) =>
            {
                txtDescripcion.SelectAll();
            };
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
            { 2, numeric2 },
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

            decimal totalCaja = totalEntradas - totalSalidas;

            lblTotalEntradas.Text = totalEntradas.ToString("C2");
            lblTotalSalidas.Text = totalSalidas.ToString("C2");
            lblTotalCaja.Text = totalCaja.ToString("C2");


            CalcularTotalDesglose();
        }

        private void CalcularTotalDesglose()
        {
            decimal total = CalcularTotalEfectivoExacto();
            lblTotalEfectivo.Text = total.ToString("C2");

            // Verificar coincidencia con total de caja
            decimal totalCaja = 0;
            if (decimal.TryParse(lblTotalCaja.Text.Replace("$", "").Replace(",", ""), out totalCaja))
            {
                if (total == totalCaja && total > 0)
                {
                    lblTotalEfectivo.ForeColor = Color.Green;
                }
                else if (total != totalCaja && total > 0)
                {
                    lblTotalEfectivo.ForeColor = Color.Red;
                }
                else
                {
                    lblTotalEfectivo.ForeColor = Color.Black;
                }
            }
        }

        // Guardar corte en base de datos
        private void btnGuardarCorte_Click(object sender, EventArgs e)
        {
            try
            {
                // Calcular totales directamente desde la tabla para mayor precisión
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

                decimal totalCaja = totalEntradas - totalSalidas;
                decimal totalEfectivo = CalcularTotalEfectivoExacto();

                // Verificar que coincidan
                if (totalCaja != totalEfectivo)
                {
                    DialogResult result = MessageBox.Show(
                        $"El total en caja (${totalCaja:N2}) no coincide con el efectivo contado (${totalEfectivo:N2}). ¿Desea guardar de todas formas?",
                        "Diferencia encontrada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Insertar corte principal
                    string insertCorte = @"
                INSERT INTO CortesCaja (Descripcion, Tipo, Valor, TotalEntradas, TotalSalidas, TotalCaja, TotalEfectivo)
                VALUES (@Descripcion, @Tipo, @Valor, @TotalEntradas, @TotalSalidas, @TotalCaja, @TotalEfectivo);
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
                        command.Parameters.AddWithValue("@TotalEfectivo", totalEfectivo);

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

        private decimal CalcularTotalEfectivoExacto()
        {
            decimal total = 0;
            foreach (var kvp in desgloseControls)
            {
                double denominacion = kvp.Key;
                int cantidad = (int)kvp.Value.Value;
                total += (decimal)(denominacion * cantidad);
            }
            return Math.Round(total, 2); // Redondear a 2 decimales
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
                worksheet.Cell("A1").Value = "CORTE DE CAJA - " + DateTime.Now.ToString("dd/MM/yyyy");
                worksheet.Cell("A1").Style.Font.Bold = true;
                worksheet.Cell("A1").Style.Font.FontSize = 16;
                worksheet.Range("A1:G1").Merge();

                // Desglose de efectivo (izquierda)
                worksheet.Cell("A3").Value = "DESGLOSE DE EFECTIVO";
                worksheet.Cell("A3").Style.Font.Bold = true;

                int row = 4;
                decimal totalEfectivo = CalcularTotalEfectivoExacto();

                // Desglose de efectivo
                foreach (var kvp in desgloseControls.OrderByDescending(x => x.Key))
                {
                    if ((int)kvp.Value.Value > 0) // Solo mostrar denominaciones con cantidad > 0
                    {
                        worksheet.Cell($"A{row}").Value = $"${kvp.Key:N2}";
                        worksheet.Cell($"B{row}").Value = (int)kvp.Value.Value;
                        worksheet.Cell($"C{row}").Value = (decimal)(kvp.Key * (int)kvp.Value.Value);
                        row++;
                    }
                }

                // Si no hay desglose, mostrar mensaje
                if (row == 4)
                {
                    worksheet.Cell("A4").Value = "No hay desglose de efectivo";
                    row++;
                }

                worksheet.Cell($"A{row}").Value = "TOTAL EFECTIVO:";
                worksheet.Cell($"A{row}").Style.Font.Bold = true;
                worksheet.Cell($"C{row}").Value = totalEfectivo;
                worksheet.Cell($"C{row}").Style.Font.Bold = true;

                // Corte de caja (derecha) - empezar en columna E
                int rightColStart = 5; // Columna E
                int rightRow = 3; // Fila 3

                worksheet.Cell(rightRow, rightColStart).Value = "CORTE DE CAJA";
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;

                rightRow = 4;
                worksheet.Cell(rightRow, rightColStart).Value = "CONCEPTO";
                worksheet.Cell(rightRow, rightColStart + 1).Value = "TIPO";
                worksheet.Cell(rightRow, rightColStart + 2).Value = "VALOR";

                // Aplicar estilo a los encabezados
                var headerRange = worksheet.Range(rightRow, rightColStart, rightRow, rightColStart + 2);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                rightRow++;

                decimal totalEntradas = 0;
                decimal totalSalidas = 0;

                // Verificar si hay conceptos
                if (conceptosTable.Rows.Count > 0)
                {
                    foreach (DataRow concepto in conceptosTable.Rows)
                    {
                        worksheet.Cell(rightRow, rightColStart).Value = concepto["Descripción"].ToString();
                        worksheet.Cell(rightRow, rightColStart + 1).Value = concepto["Tipo"].ToString();
                        worksheet.Cell(rightRow, rightColStart + 2).Value = (decimal)concepto["Valor"];

                        if (concepto["Tipo"].ToString() == "Entrada")
                            totalEntradas += (decimal)concepto["Valor"];
                        else
                            totalSalidas += (decimal)concepto["Valor"];

                        rightRow++;
                    }
                }
                else
                {
                    worksheet.Cell(rightRow, rightColStart).Value = "No hay conceptos registrados";
                    worksheet.Range(rightRow, rightColStart, rightRow, rightColStart + 2).Merge();
                    rightRow++;
                }

                decimal totalCaja = totalEntradas - totalSalidas;

                // Totales
                worksheet.Cell(rightRow, rightColStart).Value = "TOTAL ENTRADAS:";
                worksheet.Cell(rightRow, rightColStart + 1).Value = totalEntradas;
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;
                worksheet.Cell(rightRow, rightColStart + 1).Style.Font.Bold = true;
                rightRow++;

                worksheet.Cell(rightRow, rightColStart).Value = "TOTAL SALIDAS:";
                worksheet.Cell(rightRow, rightColStart + 1).Value = totalSalidas;
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;
                worksheet.Cell(rightRow, rightColStart + 1).Style.Font.Bold = true;
                rightRow++;

                worksheet.Cell(rightRow, rightColStart).Value = "TOTAL CAJA:";
                worksheet.Cell(rightRow, rightColStart + 1).Value = totalCaja;
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;
                worksheet.Cell(rightRow, rightColStart + 1).Style.Font.Bold = true;
                rightRow++;

                // Verificación
                worksheet.Cell(rightRow, rightColStart).Value = "VERIFICACIÓN:";
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;
                worksheet.Cell(rightRow, rightColStart + 1).Value = totalCaja == totalEfectivo ? "CORRECTO" : "DIFERENCIA";
                worksheet.Cell(rightRow, rightColStart + 1).Style.Font.Bold = true;
                worksheet.Cell(rightRow, rightColStart + 1).Style.Font.FontColor = totalCaja == totalEfectivo ? XLColor.Green : XLColor.Red;

                // Si hay diferencia, mostrar el monto
                if (totalCaja != totalEfectivo)
                {
                    rightRow++;
                    worksheet.Cell(rightRow, rightColStart).Value = "DIFERENCIA:";
                    worksheet.Cell(rightRow, rightColStart + 1).Value = Math.Abs(totalCaja - totalEfectivo);
                    worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;
                    worksheet.Cell(rightRow, rightColStart + 1).Style.Font.Bold = true;
                    worksheet.Cell(rightRow, rightColStart + 1).Style.Font.FontColor = XLColor.Red;
                }

                // Formato de moneda para todas las celdas numéricas
                var allDataRange = worksheet.RangeUsed();
                if (allDataRange != null)
                {
                    foreach (var cell in allDataRange.CellsUsed())
                    {
                        if (cell.Value.IsNumber)
                        {
                            cell.Style.NumberFormat.Format = "$#,##0.00";
                        }
                    }
                }

                // Formato específico para columnas de valores
                worksheet.Columns("C").Style.NumberFormat.Format = "$#,##0.00"; // Columna C - subtotales desglose
                worksheet.Columns("G").Style.NumberFormat.Format = "$#,##0.00"; // Columna G - valores conceptos

                // Autoajustar columnas
                worksheet.Columns().AdjustToContents();

                // Bordes para toda la tabla
                var usedRange = worksheet.RangeUsed();
                if (usedRange != null)
                {
                    usedRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                    usedRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                }

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


        private void ConfigureNumericUpDowns()
        {
            foreach (var numeric in desgloseControls.Values)
            {
                numeric.Enter += (s, e) =>
                {
                    numeric.Select(0, numeric.Value.ToString().Length);
                };

                numeric.KeyPress += (s, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        e.Handled = true;
                        SelectNextControl((Control)s, true, true, true, true);
                    }
                };

                numeric.Leave += (s, e) =>
                {
                    if (numeric.Value == 0 && numeric.Text != "0")
                    {
                        numeric.Text = "0";
                    }
                };
            }
        }

        private void CargarHistorialPorFecha()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    Id,
                    Fecha as 'Fecha y Hora',
                    TotalEntradas as 'Total Entradas',
                    TotalSalidas as 'Total Salidas',
                    TotalCaja as 'Total Caja',
                    TotalEfectivo as 'Efectivo Contado'
                FROM CortesCaja 
                WHERE Tipo = 'Corte' 
                AND date(Fecha) = date(@Fecha)
                ORDER BY Fecha DESC";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@Fecha", dateTimePicker.Value.ToString("yyyy-MM-dd"));
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
       








    }
}
