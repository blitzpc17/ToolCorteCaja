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
                    Tipo TEXT,
                    Valor REAL,
                    TotalEntradas REAL,
                    TotalSalidas REAL,
                    TotalCaja REAL
                );";

            string createDesgloseTable = @"
                CREATE TABLE IF NOT EXISTS DesgloseEfectivo (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    CorteId INTEGER,
                    Denominacion REAL,
                    Cantidad INTEGER,
                    Subtotal REAL,
                    FOREIGN KEY(CorteId) REFERENCES CortesCaja(Id)
                );";

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