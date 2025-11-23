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

                        // Ocultar la columna Id si no quieres que sea visible
                        if (dataGridViewHistorial.Columns.Contains("Id"))
                        {
                            dataGridViewHistorial.Columns["Id"].Visible = false;
                        }
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
                // Verificar si hay un corte seleccionado en el historial
                if (dataGridViewHistorial.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un corte del historial para generar el reporte.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el ID del corte seleccionado
                int corteId = Convert.ToInt32(dataGridViewHistorial.SelectedRows[0].Cells["Id"].Value);

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files|*.xlsx";
                    saveDialog.Title = "Guardar reporte de corte";
                    saveDialog.FileName = $"Corte_Caja_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        GenerarExcelDesdeHistorial(saveDialog.FileName, corteId);
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

        private void GenerarExcelDesdeHistorial(string filePath, int corteId)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Corte de Caja");

                // Obtener datos del corte desde la base de datos
                var datosCorte = ObtenerDatosCorte(corteId);
                var desgloseInicial = ObtenerDesgloseEfectivo(corteId, "Inicial");
                var desgloseFinal = ObtenerDesgloseEfectivo(corteId, "Final");
                var conceptos = ObtenerConceptos(corteId);

                // Título
                worksheet.Cell("A1").Value = "REPORTE DE CORTE DE CAJA";
                worksheet.Cell("A1").Style.Font.Bold = true;
                worksheet.Cell("A1").Style.Font.FontSize = 16;
                worksheet.Range("A1:G1").Merge();

                worksheet.Cell("A2").Value = $"Fecha: {datosCorte.Fecha:dd/MM/yyyy HH:mm}";
                worksheet.Cell("A2").Style.Font.Bold = true;

                // ===== COLUMNA IZQUIERDA: DESGLOSE INICIAL =====
                worksheet.Cell("A4").Value = "EFECTIVO INICIAL";
                worksheet.Cell("A4").Style.Font.Bold = true;
                worksheet.Cell("A4").Style.Fill.BackgroundColor = XLColor.LightBlue;

                int row = 5;
                worksheet.Cell($"A{row}").Value = "DENOMINACIÓN";
                worksheet.Cell($"B{row}").Value = "CANTIDAD";
                worksheet.Cell($"C{row}").Value = "SUBTOTAL";
                var headerInicial = worksheet.Range($"A{row}:C{row}");
                headerInicial.Style.Font.Bold = true;
                headerInicial.Style.Fill.BackgroundColor = XLColor.LightGray;

                row++;

                decimal totalInicial = 0;
                foreach (var desglose in desgloseInicial.OrderByDescending(x => x.Denominacion))
                {
                    if (desglose.Cantidad > 0)
                    {
                        worksheet.Cell($"A{row}").Value = $"${desglose.Denominacion:N2}";
                        worksheet.Cell($"B{row}").Value = desglose.Cantidad;
                        worksheet.Cell($"C{row}").Value = desglose.Subtotal;
                        totalInicial += (decimal)desglose.Subtotal;
                        row++;
                    }
                }

                worksheet.Cell($"A{row}").Value = "TOTAL INICIAL:";
                worksheet.Cell($"A{row}").Style.Font.Bold = true;
                worksheet.Cell($"C{row}").Value = totalInicial;
                worksheet.Cell($"C{row}").Style.Font.Bold = true;

                // ===== COLUMNA CENTRAL: MOVIMIENTOS =====
                int centerCol = 4; // Columna D
                int centerRow = 4;

                worksheet.Cell(centerRow, centerCol).Value = "MOVIMIENTOS DE CAJA";
                worksheet.Cell(centerRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(centerRow, centerCol).Style.Fill.BackgroundColor = XLColor.LightGreen;
                worksheet.Range(centerRow, centerCol, centerRow, centerCol + 2).Merge();

                centerRow++;
                worksheet.Cell(centerRow, centerCol).Value = "DESCRIPCIÓN";
                worksheet.Cell(centerRow, centerCol + 1).Value = "TIPO";
                worksheet.Cell(centerRow, centerCol + 2).Value = "VALOR";
                var headerMovimientos = worksheet.Range(centerRow, centerCol, centerRow, centerCol + 2);
                headerMovimientos.Style.Font.Bold = true;
                headerMovimientos.Style.Fill.BackgroundColor = XLColor.LightGray;

                centerRow++;

                decimal totalEntradas = 0;
                decimal totalSalidas = 0;

                if (conceptos.Count > 0)
                {
                    foreach (var concepto in conceptos)
                    {
                        worksheet.Cell(centerRow, centerCol).Value = concepto.Descripcion;
                        worksheet.Cell(centerRow, centerCol + 1).Value = concepto.Tipo;
                        worksheet.Cell(centerRow, centerCol + 2).Value = concepto.Valor;

                        if (concepto.Tipo == "Entrada")
                            totalEntradas += (decimal)concepto.Valor;
                        else
                            totalSalidas += (decimal)concepto.Valor;

                        centerRow++;
                    }
                }
                else
                {
                    worksheet.Cell(centerRow, centerCol).Value = "No hay movimientos registrados";
                    worksheet.Range(centerRow, centerCol, centerRow, centerCol + 2).Merge();
                    centerRow++;
                }

                // Totales de movimientos
                decimal totalCaja = totalEntradas - totalSalidas;

                worksheet.Cell(centerRow, centerCol).Value = "TOTAL ENTRADAS:";
                worksheet.Cell(centerRow, centerCol + 1).Value = totalEntradas;
                worksheet.Cell(centerRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(centerRow, centerCol + 1).Style.Font.Bold = true;
                centerRow++;

                worksheet.Cell(centerRow, centerCol).Value = "TOTAL SALIDAS:";
                worksheet.Cell(centerRow, centerCol + 1).Value = totalSalidas;
                worksheet.Cell(centerRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(centerRow, centerCol + 1).Style.Font.Bold = true;
                centerRow++;

                worksheet.Cell(centerRow, centerCol).Value = "TOTAL EN CAJA:";
                worksheet.Cell(centerRow, centerCol + 1).Value = totalCaja;
                worksheet.Cell(centerRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(centerRow, centerCol + 1).Style.Font.Bold = true;
                centerRow++;

                // ===== PARTE INFERIOR CENTRAL: DESGLOSE FINAL Y RESUMEN =====
                int bottomRow = Math.Max(row, centerRow) + 2;

                // Desglose Final
                worksheet.Cell(bottomRow, centerCol).Value = "EFECTIVO FINAL";
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(bottomRow, centerCol).Style.Fill.BackgroundColor = XLColor.LightYellow;
                worksheet.Range(bottomRow, centerCol, bottomRow, centerCol + 2).Merge();

                bottomRow++;
                worksheet.Cell(bottomRow, centerCol).Value = "DENOMINACIÓN";
                worksheet.Cell(bottomRow, centerCol + 1).Value = "CANTIDAD";
                worksheet.Cell(bottomRow, centerCol + 2).Value = "SUBTOTAL";
                var headerFinal = worksheet.Range(bottomRow, centerCol, bottomRow, centerCol + 2);
                headerFinal.Style.Font.Bold = true;
                headerFinal.Style.Fill.BackgroundColor = XLColor.LightGray;

                bottomRow++;

                decimal totalFinal = 0;
                foreach (var desglose in desgloseFinal.OrderByDescending(x => x.Denominacion))
                {
                    if (desglose.Cantidad > 0)
                    {
                        worksheet.Cell(bottomRow, centerCol).Value = $"${desglose.Denominacion:N2}";
                        worksheet.Cell(bottomRow, centerCol + 1).Value = desglose.Cantidad;
                        worksheet.Cell(bottomRow, centerCol + 2).Value = desglose.Subtotal;
                        totalFinal += (decimal)desglose.Subtotal;
                        bottomRow++;
                    }
                }

                worksheet.Cell(bottomRow, centerCol).Value = "TOTAL FINAL:";
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(bottomRow, centerCol + 2).Value = totalFinal;
                worksheet.Cell(bottomRow, centerCol + 2).Style.Font.Bold = true;

                bottomRow += 2;

                // ===== RESUMEN FINAL =====
                worksheet.Cell(bottomRow, centerCol).Value = "RESUMEN FINAL";
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(bottomRow, centerCol).Style.Font.FontSize = 12;
                worksheet.Range(bottomRow, centerCol, bottomRow, centerCol + 1).Merge();

                bottomRow++;
                worksheet.Cell(bottomRow, centerCol).Value = "Efectivo Inicial:";
                worksheet.Cell(bottomRow, centerCol + 1).Value = totalInicial;
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;

                bottomRow++;
                worksheet.Cell(bottomRow, centerCol).Value = "Total en Caja:";
                worksheet.Cell(bottomRow, centerCol + 1).Value = totalCaja;
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;

                bottomRow++;
                worksheet.Cell(bottomRow, centerCol).Value = "Efectivo Esperado:";
                worksheet.Cell(bottomRow, centerCol + 1).Value = totalInicial + totalCaja;
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;

                bottomRow++;
                worksheet.Cell(bottomRow, centerCol).Value = "Efectivo Final:";
                worksheet.Cell(bottomRow, centerCol + 1).Value = totalFinal;
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;

                bottomRow++;
                decimal diferencia = totalFinal - (totalInicial + totalCaja);
                worksheet.Cell(bottomRow, centerCol).Value = "DIFERENCIA:";
                worksheet.Cell(bottomRow, centerCol + 1).Value = diferencia;
                worksheet.Cell(bottomRow, centerCol).Style.Font.Bold = true;
                worksheet.Cell(bottomRow, centerCol + 1).Style.Font.Bold = true;
                worksheet.Cell(bottomRow, centerCol + 1).Style.Font.FontColor =
                    diferencia == 0 ? XLColor.Green : XLColor.Red;

                // Formato de moneda para todas las celdas numéricas
                var numberCells = worksheet.RangeUsed().CellsUsed()
                    .Where(c => c.Value.IsNumber);
                foreach (var cell in numberCells)
                {
                    cell.Style.NumberFormat.Format = "$#,##0.00";
                }

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

        // Métodos auxiliares para obtener datos de la base de datos
        private CorteData ObtenerDatosCorte(int corteId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM CortesCaja WHERE Id = @CorteId";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CorteId", corteId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CorteData
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                TotalEntradas = Convert.ToDecimal(reader["TotalEntradas"]),
                                TotalSalidas = Convert.ToDecimal(reader["TotalSalidas"]),
                                TotalCaja = Convert.ToDecimal(reader["TotalCaja"]),
                                TotalEfectivoInicial = Convert.ToDecimal(reader["TotalEfectivoInicial"]),
                                TotalEfectivoFinal = Convert.ToDecimal(reader["TotalEfectivoFinal"]),
                                Diferencia = Convert.ToDecimal(reader["Diferencia"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        private List<DesgloseData> ObtenerDesgloseEfectivo(int corteId, string tipo)
        {
            var desglose = new List<DesgloseData>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM DesgloseEfectivo WHERE CorteId = @CorteId AND Tipo = @Tipo";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CorteId", corteId);
                    command.Parameters.AddWithValue("@Tipo", tipo);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            desglose.Add(new DesgloseData
                            {
                                Denominacion = Convert.ToDouble(reader["Denominacion"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Subtotal = Convert.ToDouble(reader["Subtotal"])
                            });
                        }
                    }
                }
            }
            return desglose;
        }
        private List<ConceptoData> ObtenerConceptos(int corteId)
        {
            var conceptos = new List<ConceptoData>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Conceptos WHERE CorteId = @CorteId";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CorteId", corteId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            conceptos.Add(new ConceptoData
                            {
                                Descripcion = reader["Descripcion"].ToString(),
                                Tipo = reader["Tipo"].ToString(),
                                Valor = Convert.ToDecimal(reader["Valor"])
                            });
                        }
                    }
                }
            }
            return conceptos;
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