// Clase para manejar la base de datos - DatabaseHelper.cs
using System;
using System.Data.SQLite;
using System.IO;

public static class DatabaseHelper
{
    private static string databasePath = "CortesCaja.db";
    private static string connectionString = $"Data Source={databasePath};Version=3;";

    public static void InitializeDatabase()
    {

        if (!File.Exists(databasePath))
        {
            SQLiteConnection.CreateFile(databasePath);
        }

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string createCortesTable = @"
            CREATE TABLE IF NOT EXISTS CortesCaja (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
                Descripcion TEXT,
                TotalEntradas REAL,
                TotalSalidas REAL,
                TotalCaja REAL,
                TotalEfectivoInicial REAL,
                TotalEfectivoFinal REAL,
                Diferencia REAL
            );";

            string createDesgloseTable = @"
            CREATE TABLE IF NOT EXISTS DesgloseEfectivo (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                CorteId INTEGER,
                Tipo TEXT, -- 'Inicial' o 'Final'
                Denominacion REAL,
                Cantidad INTEGER,
                Subtotal REAL,
                FOREIGN KEY(CorteId) REFERENCES CortesCaja(Id)
            );";

            string createConceptosTable = @"
            CREATE TABLE IF NOT EXISTS Conceptos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                CorteId INTEGER,
                Descripcion TEXT,
                Tipo TEXT,
                Valor REAL,
                FOREIGN KEY(CorteId) REFERENCES CortesCaja(Id)
            );";

            using (var command = new SQLiteCommand(createConceptosTable, connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(createCortesTable, connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(createDesgloseTable, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(connectionString);
    }
}