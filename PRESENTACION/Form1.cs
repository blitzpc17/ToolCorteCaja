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
        private Dictionary<double, NumericUpDown> desgloseInicialControls;
        private Dictionary<double, NumericUpDown> desgloseFinalControls;
        private bool corteIniciado = false;

        public Form1()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void InitializeApp()
        {
            try
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

                // Inicialmente deshabilitar la captura de conceptos hasta que se inicie el corte
                SetCorteControlsEnabled(false);

                // Configurar DateTimePicker
                dateTimePicker.Format = DateTimePickerFormat.Short;
                dateTimePicker.Value = DateTime.Today;
                dateTimePicker.ValueChanged += (s, e) => CargarHistorialPorFecha();

                // Cargar historial
                CargarHistorialPorFecha();

                // Estilo moderno
                ApplyModernStyle();

                // Configurar validaciones
                ConfigureValidations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la aplicación: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDesgloseControls()
        {
            // Desglose inicial
            desgloseInicialControls = new Dictionary<double, NumericUpDown>
            {
                { 500, numeric500Inicial },
                { 200, numeric200Inicial },
                { 100, numeric100Inicial },
                { 50, numeric50Inicial },
                { 20, numeric20Inicial },
                { 10, numeric10Inicial },
                { 5, numeric5Inicial },
                { 2, numeric2Inicial },
                { 1, numeric1Inicial },
                { 0.5, numeric050Inicial }
            };

            // Desglose final
            desgloseFinalControls = new Dictionary<double, NumericUpDown>
            {
                { 500, numeric500Final },
                { 200, numeric200Final },
                { 100, numeric100Final },
                { 50, numeric50Final },
                { 20, numeric20Final },
                { 10, numeric10Final },
                { 5, numeric5Final },
                { 2, numeric2Final },
                { 1, numeric1Final },
                { 0.5, numeric050Final }
            };

            // Configurar eventos para desglose inicial
            foreach (var control in desgloseInicialControls.Values)
            {
                control.ValueChanged += (s, e) => CalcularTotalDesgloseInicial();
                ConfigureNumericUpDown(control);
            }

            // Configurar eventos para desglose final
            foreach (var control in desgloseFinalControls.Values)
            {
                control.ValueChanged += (s, e) => CalcularTotalDesgloseFinal();
                ConfigureNumericUpDown(control);
            }

            // Inicialmente ocultar el desglose final
            groupBoxDesgloseFinal.Visible = false;
            btnCerrarCorte.Visible = false;
        }

        private void ConfigureNumericUpDown(NumericUpDown numeric)
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
        }

        private void ConfigureValidations()
        {
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

        private void SetCorteControlsEnabled(bool enabled)
        {
            groupBoxConceptos.Enabled = enabled;
            btnAgregarConcepto.Enabled = enabled;
            dataGridViewConceptos.Enabled = enabled;
        }

        private void CalcularTotalDesgloseInicial()
        {
            decimal total = CalcularTotalEfectivoExacto(desgloseInicialControls);
            lblTotalEfectivoInicial.Text = total.ToString("C2");
        }

        private void CalcularTotalDesgloseFinal()
        {
            decimal total = CalcularTotalEfectivoExacto(desgloseFinalControls);
            lblTotalEfectivoFinal.Text = total.ToString("C2");
        }

        private decimal CalcularTotalEfectivoExacto(Dictionary<double, NumericUpDown> controles)
        {
            decimal total = 0;
            foreach (var kvp in controles)
            {
                double denominacion = kvp.Key;
                int cantidad = (int)kvp.Value.Value;
                total += (decimal)(denominacion * cantidad);
            }
            return Math.Round(total, 2);
        }

        // Evento para iniciar corte
        private void btnIniciarCorte_Click(object sender, EventArgs e)
        {
            decimal totalInicial = CalcularTotalEfectivoExacto(desgloseInicialControls);
            if (totalInicial == 0)
            {
                MessageBox.Show("Por favor, ingrese el desglose de efectivo inicial.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            corteIniciado = true;
            SetCorteControlsEnabled(true);
            btnIniciarCorte.Enabled = false;
            btnCerrarCorte.Visible = true;
            groupBoxDesgloseFinal.Visible = true;

            MessageBox.Show($"Corte iniciado con efectivo inicial: {totalInicial:C2}", "Corte Iniciado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento para cerrar corte
        private void btnCerrarCorte_Click(object sender, EventArgs e)
        {
            decimal totalFinal = CalcularTotalEfectivoExacto(desgloseFinalControls);
            if (totalFinal == 0)
            {
                MessageBox.Show("Por favor, ingrese el desglose de efectivo final.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calcular totales
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
            decimal totalInicial = CalcularTotalEfectivoExacto(desgloseInicialControls);
            decimal diferencia = totalFinal - (totalInicial + totalCaja);

            // Mostrar resumen antes de guardar
            string mensaje = $"RESUMEN DEL CORTE:\n\n" +
                           $"Efectivo Inicial: {totalInicial:C2}\n" +
                           $"Total Entradas: {totalEntradas:C2}\n" +
                           $"Total Salidas: {totalSalidas:C2}\n" +
                           $"Total en Caja: {totalCaja:C2}\n" +
                           $"Efectivo Esperado: {totalInicial + totalCaja:C2}\n" +
                           $"Efectivo Final: {totalFinal:C2}\n" +
                           $"Diferencia: {diferencia:C2}\n\n" +
                           $"¿Desea guardar el corte?";

            DialogResult result = MessageBox.Show(mensaje, "Cerrar Corte",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GuardarCorte(totalEntradas, totalSalidas, totalCaja, totalInicial, totalFinal, diferencia);
            }
        }

        private void GuardarCorte(decimal totalEntradas, decimal totalSalidas, decimal totalCaja,
                                decimal totalInicial, decimal totalFinal, decimal diferencia)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Insertar corte principal
                    string insertCorte = @"
                        INSERT INTO CortesCaja (Descripcion, TotalEntradas, TotalSalidas, TotalCaja, 
                                              TotalEfectivoInicial, TotalEfectivoFinal, Diferencia)
                        VALUES (@Descripcion, @TotalEntradas, @TotalSalidas, @TotalCaja, 
                                @TotalEfectivoInicial, @TotalEfectivoFinal, @Diferencia);
                        SELECT last_insert_rowid();";

                    long corteId = 0;
                    using (var command = new SQLiteCommand(insertCorte, connection))
                    {
                        command.Parameters.AddWithValue("@Descripcion", "Corte de Caja " + DateTime.Now.ToString("dd/MM/yyyy"));
                        command.Parameters.AddWithValue("@TotalEntradas", totalEntradas);
                        command.Parameters.AddWithValue("@TotalSalidas", totalSalidas);
                        command.Parameters.AddWithValue("@TotalCaja", totalCaja);
                        command.Parameters.AddWithValue("@TotalEfectivoInicial", totalInicial);
                        command.Parameters.AddWithValue("@TotalEfectivoFinal", totalFinal);
                        command.Parameters.AddWithValue("@Diferencia", diferencia);

                        corteId = (long)command.ExecuteScalar();
                    }

                    // Insertar desglose inicial
                    InsertarDesglose(connection, corteId, "Inicial", desgloseInicialControls);

                    // Insertar desglose final
                    InsertarDesglose(connection, corteId, "Final", desgloseFinalControls);

                    // Insertar conceptos individuales
                    string insertConcepto = @"
                        INSERT INTO Conceptos (CorteId, Descripcion, Tipo, Valor)
                        VALUES (@CorteId, @Descripcion, @Tipo, @Valor)";

                    foreach (DataRow row in conceptosTable.Rows)
                    {
                        using (var command = new SQLiteCommand(insertConcepto, connection))
                        {
                            command.Parameters.AddWithValue("@CorteId", corteId);
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
                CargarHistorialPorFecha();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDesglose(SQLiteConnection connection, long corteId, string tipo,
                                    Dictionary<double, NumericUpDown> controles)
        {
            string insertDesglose = @"
                INSERT INTO DesgloseEfectivo (CorteId, Tipo, Denominacion, Cantidad, Subtotal)
                VALUES (@CorteId, @Tipo, @Denominacion, @Cantidad, @Subtotal)";

            foreach (var kvp in controles)
            {
                using (var command = new SQLiteCommand(insertDesglose, connection))
                {
                    command.Parameters.AddWithValue("@CorteId", corteId);
                    command.Parameters.AddWithValue("@Tipo", tipo);
                    command.Parameters.AddWithValue("@Denominacion", kvp.Key);
                    command.Parameters.AddWithValue("@Cantidad", (int)kvp.Value.Value);
                    command.Parameters.AddWithValue("@Subtotal", kvp.Key * (int)kvp.Value.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Evento para agregar concepto
        private void btnAgregarConcepto_Click(object sender, EventArgs e)
        {
            if (!corteIniciado)
            {
                MessageBox.Show("Debe iniciar el corte primero antes de agregar conceptos.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos del concepto.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor) || valor <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor válido mayor a cero.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string descripcion = txtDescripcion.Text;
            string tipo = radioEntrada.Checked ? "Entrada" : "Salida";

            conceptosTable.Rows.Add(descripcion, tipo, valor);

            // Limpiar campos
            txtDescripcion.Clear();
            txtValor.Clear();
            txtDescripcion.Focus();

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
                            TotalEfectivoInicial as 'Efectivo Inicial',
                            TotalEfectivoFinal as 'Efectivo Final',
                            Diferencia as 'Diferencia'
                        FROM CortesCaja 
                        WHERE date(Fecha) = date(@Fecha)
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

        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!corteIniciado)
                {
                    MessageBox.Show("Debe iniciar y completar un corte antes de generar el reporte.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                worksheet.Range("A1:H1").Merge();

                // Desglose de efectivo INICIAL (izquierda - parte superior)
                worksheet.Cell("A3").Value = "DESGLOSE DE EFECTIVO INICIAL";
                worksheet.Cell("A3").Style.Font.Bold = true;

                int row = 4;
                decimal totalInicial = CalcularTotalEfectivoExacto(desgloseInicialControls);

                foreach (var kvp in desgloseInicialControls.OrderByDescending(x => x.Key))
                {
                    if ((int)kvp.Value.Value > 0)
                    {
                        worksheet.Cell($"A{row}").Value = $"${kvp.Key:N2}";
                        worksheet.Cell($"B{row}").Value = (int)kvp.Value.Value;
                        worksheet.Cell($"C{row}").Value = (decimal)(kvp.Key * (int)kvp.Value.Value);
                        row++;
                    }
                }

                worksheet.Cell($"A{row}").Value = "TOTAL EFECTIVO INICIAL:";
                worksheet.Cell($"A{row}").Style.Font.Bold = true;
                worksheet.Cell($"C{row}").Value = totalInicial;
                worksheet.Cell($"C{row}").Style.Font.Bold = true;

                // Corte de caja (derecha - parte superior)
                int rightColStart = 5; // Columna E
                int rightRow = 3;

                worksheet.Cell(rightRow, rightColStart).Value = "MOVIMIENTOS DE CAJA";
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;

                rightRow = 4;
                worksheet.Cell(rightRow, rightColStart).Value = "CONCEPTO";
                worksheet.Cell(rightRow, rightColStart + 1).Value = "TIPO";
                worksheet.Cell(rightRow, rightColStart + 2).Value = "VALOR";

                var headerRange = worksheet.Range(rightRow, rightColStart, rightRow, rightColStart + 2);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                rightRow++;

                decimal totalEntradas = 0;
                decimal totalSalidas = 0;

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
                    worksheet.Cell(rightRow, rightColStart).Value = "No hay movimientos registrados";
                    worksheet.Range(rightRow, rightColStart, rightRow, rightColStart + 2).Merge();
                    rightRow++;
                }

                decimal totalCaja = totalEntradas - totalSalidas;

                // Totales movimientos
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

                worksheet.Cell(rightRow, rightColStart).Value = "TOTAL EN CAJA:";
                worksheet.Cell(rightRow, rightColStart + 1).Value = totalCaja;
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;
                worksheet.Cell(rightRow, rightColStart + 1).Style.Font.Bold = true;
                rightRow++;

                worksheet.Cell(rightRow, rightColStart).Value = "EFECTIVO ESPERADO:";
                worksheet.Cell(rightRow, rightColStart + 1).Value = totalInicial + totalCaja;
                worksheet.Cell(rightRow, rightColStart).Style.Font.Bold = true;
                worksheet.Cell(rightRow, rightColStart + 1).Style.Font.Bold = true;
                rightRow++;

                // Desglose de efectivo FINAL (parte inferior)
                int finalRow = row + 3; // Espacio después del desglose inicial

                worksheet.Cell($"A{finalRow}").Value = "DESGLOSE DE EFECTIVO FINAL";
                worksheet.Cell($"A{finalRow}").Style.Font.Bold = true;

                finalRow++;
                decimal totalFinal = CalcularTotalEfectivoExacto(desgloseFinalControls);

                foreach (var kvp in desgloseFinalControls.OrderByDescending(x => x.Key))
                {
                    if ((int)kvp.Value.Value > 0)
                    {
                        worksheet.Cell($"A{finalRow}").Value = $"${kvp.Key:N2}";
                        worksheet.Cell($"B{finalRow}").Value = (int)kvp.Value.Value;
                        worksheet.Cell($"C{finalRow}").Value = (decimal)(kvp.Key * (int)kvp.Value.Value);
                        finalRow++;
                    }
                }

                worksheet.Cell($"A{finalRow}").Value = "TOTAL EFECTIVO FINAL:";
                worksheet.Cell($"A{finalRow}").Style.Font.Bold = true;
                worksheet.Cell($"C{finalRow}").Value = totalFinal;
                worksheet.Cell($"C{finalRow}").Style.Font.Bold = true;

                finalRow++;

                // Diferencia
                decimal diferencia = totalFinal - (totalInicial + totalCaja);
                worksheet.Cell($"A{finalRow}").Value = "DIFERENCIA:";
                worksheet.Cell($"A{finalRow}").Style.Font.Bold = true;
                worksheet.Cell($"C{finalRow}").Value = diferencia;
                worksheet.Cell($"C{finalRow}").Style.Font.Bold = true;
                worksheet.Cell($"C{finalRow}").Style.Font.FontColor =
                    diferencia == 0 ? XLColor.Green : XLColor.Red;

                // Formato de moneda
                worksheet.Columns("C").Style.NumberFormat.Format = "$#,##0.00";
                worksheet.Columns("G").Style.NumberFormat.Format = "$#,##0.00";

                // Autoajustar columnas
                worksheet.Columns().AdjustToContents();

                // Bordes para mejor presentación
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
            foreach (var control in desgloseInicialControls.Values)
            {
                control.Value = 0;
            }
            foreach (var control in desgloseFinalControls.Values)
            {
                control.Value = 0;
            }
            txtDescripcion.Clear();
            txtValor.Clear();
            radioEntrada.Checked = true;

            // Resetear estado del corte
            corteIniciado = false;
            SetCorteControlsEnabled(false);
            btnIniciarCorte.Enabled = true;
            btnCerrarCorte.Visible = false;
            groupBoxDesgloseFinal.Visible = false;

            CalcularTotales();
            CalcularTotalDesgloseInicial();
            CalcularTotalDesgloseFinal();
        }

        private void btnNuevoCorte_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            tabControl.SelectedTab = tabCaptura;
        }

        private void ApplyModernStyle()
        {
            // Colores modernos
            Color primaryColor = Color.FromArgb(41, 128, 185);
            Color secondaryColor = Color.FromArgb(52, 152, 219);
            Color backgroundColor = Color.FromArgb(236, 240, 241);
            Color successColor = Color.FromArgb(46, 204, 113);
            Color dangerColor = Color.FromArgb(231, 76, 60);

            this.BackColor = backgroundColor;
            panelHeader.BackColor = primaryColor;
            labelTitle.ForeColor = Color.White;

            // Estilo para botones
            foreach (Control control in GetAllControls(this))
            {
                if (control is Button button)
                {
                    if (button == btnIniciarCorte)
                    {
                        button.BackColor = successColor;
                    }
                    else if (button == btnCerrarCorte)
                    {
                        button.BackColor = dangerColor;
                    }
                    else
                    {
                        button.BackColor = secondaryColor;
                    }

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

        // Evento para el DateTimePicker
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CargarHistorialPorFecha();
        }
    }
}