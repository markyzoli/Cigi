using Microsoft.Data.Sqlite;
using System;
using System.Data;
using SQLitePCL;

namespace Cigi
{
    internal class DbHelper(string dbPath)
    {
        private readonly string _connectionString = $"Data Source={dbPath}";        

        // Általános lekérdezés, ami DataTable-t ad vissza
        public DataTable ExecuteQuery(string query, params SqliteParameter[] parameters)
        {
            using var conn = new SqliteConnection(_connectionString);
            using var cmd = new SqliteCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        // Általános nem-lekérdező parancs (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, params SqliteParameter[] parameters)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            using var cmd = new SqliteCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        // Egyetlen érték lekérdezése (pl. COUNT, MAX, MIN)
        public object? ExecuteScalar(string query, params SqliteParameter[] parameters)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            using var cmd = new SqliteCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
        // A legutóbbi CigiDohanyAr, ami nem nulla
        public decimal GetLastNonZeroCigiDohanyAr()
        {
            string query = "SELECT CigiDohanyAr FROM Vasarlasok WHERE CigiDohanyAr > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        // A legutóbbi PipaDohanyAr, ami nem nulla
        public decimal GetLastNonZeroPipaDohanyAr()
        {
            string query = "SELECT PipaDohanyAr FROM Vasarlasok WHERE PipaDohanyAr > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        // A legutóbbi HuvelyAr, ami nem nulla
        public decimal GetLastNonZeroHuvelyAr()
        {
            string query = "SELECT HuvelyAr FROM Vasarlasok WHERE HuvelyAr > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        // A legutóbbi SzipkaAr, ami nem nulla
        public decimal GetLastNonZeroSzipkaAr()
        {
            string query = "SELECT SzipkaAr FROM Vasarlasok WHERE SzipkaAr > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        // A legutóbbi CigiDohanyGr, ami nem nulla
        public decimal GetLastNonZeroCigiDohanyGr()
        {
            string query = "SELECT CigiDohanyGr FROM Vasarlasok WHERE CigiDohanyGr > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        // A legutóbbi PipaDohanyGr, ami nem nulla
        public decimal GetLastNonZeroPipaDohanyGr() {
            string query = "SELECT PipaDohanyGr FROM Vasarlasok WHERE PipaDohanyGr > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        // A legutóbbi HuvelyDb, ami nem nulla
        public int GetLastNonZeroHuvelyDb()
        {
            string query = "SELECT HuvelyDb FROM Vasarlasok WHERE HuvelyDb > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
        // A legutóbbi SzipkaDb, ami nem nulla
        public int GetLastNonZeroSzipkaDb()
        {
            string query = "SELECT SzipkaDb FROM Vasarlasok WHERE SzipkaDb > 0 ORDER BY Datum DESC LIMIT 1";
            var result = ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
        // A legutóbbi készlet
        public KeszletInfo? GetLastKeszlet()
        {
            string query = "SELECT * FROM Keszlet ORDER BY Datum DESC LIMIT 1";
            var dt = ExecuteQuery(query);
            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];
            return new KeszletInfo
            {
                ID = Convert.ToInt32(row["ID"]),
                Datum = DateTime.Parse(row["Datum"].ToString()!),
                DohanyGr = Convert.ToInt32(row["DohanyGr"]),
                SzipkaDb = Convert.ToInt32(row["SzipkaDb"]),
                HuvelyDb = Convert.ToInt32(row["HuvelyDb"]),
                FDohanyGr = Convert.ToInt32(row["FDohanyGr"]),
                FSzipkaDb = Convert.ToInt32(row["FSzipkaDb"]),
                FHuvelyDb = Convert.ToInt32(row["FHuvelyDb"]),
                Napok = Convert.ToInt32(row["Napok"])
            };
        }
        // A legutóbbi maradék nélküli vásárlás
        public VasarlasInfo? GetLastMaradek()
        {
            string query = "SELECT * FROM Vasarlasok WHERE VasarlasMaradek = 0 ORDER BY Datum DESC LIMIT 1";
            var dt = ExecuteQuery(query);
            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];
            return new VasarlasInfo
            {
                Id = Convert.ToInt32(row["Id"]),
                Datum = DateTime.Parse(row["Datum"].ToString()!),
                CigiDohanyAr = row["CigiDohanyAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["CigiDohanyAr"]),
                PipaDohanyAr = row["PipaDohanyAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["PipaDohanyAr"]),
                HuvelyAr = row["HuvelyAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["HuvelyAr"]),
                SzipkaAr = row["SzipkaAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["SzipkaAr"]),
                CigiDohanyGr = row["CigiDohanyGr"] == DBNull.Value ? 0 : Convert.ToInt32(row["CigiDohanyGr"]),
                PipaDohanyGr = row["PipaDohanyGr"] == DBNull.Value ? 0 : Convert.ToInt32(row["PipaDohanyGr"]),
                HuvelyDb = row["HuvelyDb"] == DBNull.Value ? 0 : Convert.ToInt32(row["HuvelyDb"]),
                SzipkaDb = row["SzipkaDb"] == DBNull.Value ? 0 : Convert.ToInt32(row["SzipkaDb"]),
                VasarlasMaradek = row["VasarlasMaradek"] == DBNull.Value ? 0 : Convert.ToInt32(row["VasarlasMaradek"])
            };
        }
        // Legutóbbi vásárlás lekérdezése maradék függetlenül
        public VasarlasInfo? GetLastVasarlas()
        {
            string query = "SELECT * FROM Vasarlasok ORDER BY Datum DESC LIMIT 1";
            var dt = ExecuteQuery(query);
            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];
            return new VasarlasInfo
            {
                Id = Convert.ToInt32(row["Id"]),
                Datum = DateTime.Parse(row["Datum"].ToString()!),
                CigiDohanyAr = row["CigiDohanyAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["CigiDohanyAr"]),
                PipaDohanyAr = row["PipaDohanyAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["PipaDohanyAr"]),
                HuvelyAr = row["HuvelyAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["HuvelyAr"]),
                SzipkaAr = row["SzipkaAr"] == DBNull.Value ? 0 : Convert.ToInt32(row["SzipkaAr"]),
                CigiDohanyGr = row["CigiDohanyGr"] == DBNull.Value ? 0 : Convert.ToInt32(row["CigiDohanyGr"]),
                PipaDohanyGr = row["PipaDohanyGr"] == DBNull.Value ? 0 : Convert.ToInt32(row["PipaDohanyGr"]),
                HuvelyDb = row["HuvelyDb"] == DBNull.Value ? 0 : Convert.ToInt32(row["HuvelyDb"]),
                SzipkaDb = row["SzipkaDb"] == DBNull.Value ? 0 : Convert.ToInt32(row["SzipkaDb"]),
                VasarlasMaradek = row.Table.Columns.Contains("VasarlasMaradek") && row["VasarlasMaradek"] != DBNull.Value ? Convert.ToInt32(row["VasarlasMaradek"]) : 0
            };
        }
        // Összesítés a vásárlásokra
        public OsszVasarlasInfo GetOsszVasarlas()
        {
            string query = @"
                SELECT 
                    IFNULL(SUM(CigiDohanyAr),0) + IFNULL(SUM(PipaDohanyAr),0) + IFNULL(SUM(HuvelyAr),0) + IFNULL(SUM(SzipkaAr),0) AS Osszeg,
                    IFNULL(SUM(PipaDohanyGr),0) + IFNULL(SUM(CigiDohanyGr),0) AS CigiGr,
                    IFNULL(SUM(HuvelyDb),0) AS Huvely,
                    IFNULL(SUM(SzipkaDb),0) AS Szipka
                FROM Vasarlasok
                WHERE VasarlasMaradek IS NULL OR VasarlasMaradek = 1";
            var dt = ExecuteQuery(query);
            if (dt.Rows.Count == 0)
                return new OsszVasarlasInfo();

            var row = dt.Rows[0];
            return new OsszVasarlasInfo
            {
                Osszeg = row["Osszeg"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Osszeg"]),
                CigiGr = row["CigiGr"] == DBNull.Value ? 0 : Convert.ToDecimal(row["CigiGr"]),
                Huvely = row["Huvely"] == DBNull.Value ? 0 : Convert.ToInt32(row["Huvely"]),
                Szipka = row["Szipka"] == DBNull.Value ? 0 : Convert.ToInt32(row["Szipka"])
            };
        }
        // KezdesBefejezes lekérdezés
        public KezdesBefejezesInfo GetKezdesBefejezes()
        {
            string query = @"
                SELECT MIN(Datum) AS Kezd, MAX(Datum) AS Befejez
                FROM Vasarlasok
                WHERE VasarlasMaradek = 1";
            var dt = ExecuteQuery(query);
            if (dt.Rows.Count == 0)
                return new KezdesBefejezesInfo();

            var row = dt.Rows[0];
            return new KezdesBefejezesInfo
            {
                Kezd = row["Kezd"] == DBNull.Value ? null : DateTime.Parse(row["Kezd"].ToString()!),
                Befejez = row["Befejez"] == DBNull.Value ? null : DateTime.Parse(row["Befejez"].ToString()!)
            };
        }
        public OsszKeszletInfo GetOsszKeszlet()
        {
            string query = @"
        SELECT 
            IFNULL(SUM(DohanyGr),0) as Dohany, 
            IFNULL(SUM(HuvelyDb),0) as Huvely, 
            IFNULL(SUM(SzipkaDb),0) as Szipka, 
            IFNULL(SUM(FDohanyGr),0) as FDohanyGr,
            IFNULL(SUM(FSzipkaDb),0) as FSzipkaDb,
            IFNULL(SUM(FHuvelyDb),0) as FHuvelyDb,
            IFNULL(SUM(Napok),0) as Napok
        FROM Keszlet";
            var dt = ExecuteQuery(query);
            if (dt.Rows.Count == 0)
                return new OsszKeszletInfo();

            var row = dt.Rows[0];
            return new OsszKeszletInfo
            {
                Dohany = row["Dohany"] == DBNull.Value ? 0 : Convert.ToInt32(row["Dohany"]),
                Huvely = row["Huvely"] == DBNull.Value ? 0 : Convert.ToInt32(row["Huvely"]),
                Szipka = row["Szipka"] == DBNull.Value ? 0 : Convert.ToInt32(row["Szipka"]),
                FDohanyGr = row["FDohanyGr"] == DBNull.Value ? 0 : Convert.ToInt32(row["FDohanyGr"]),
                FSzipkaDb = row["FSzipkaDb"] == DBNull.Value ? 0 : Convert.ToInt32(row["FSzipkaDb"]),
                FHuvelyDb = row["FHuvelyDb"] == DBNull.Value ? 0 : Convert.ToInt32(row["FHuvelyDb"]),
                Napok = row["Napok"] == DBNull.Value ? 0 : Convert.ToInt32(row["Napok"])
            };
        }

        public KeszletIdoInfo GetKeszletIdo()
        {
            string query = "SELECT MIN(Datum) AS Kezd, MAX(Datum) AS Befejez FROM Keszlet";
            var dt = ExecuteQuery(query);
            if (dt.Rows.Count == 0)
                return new KeszletIdoInfo();

            var row = dt.Rows[0];
            return new KeszletIdoInfo
            {
                Kezd = row["Kezd"] == DBNull.Value ? null : DateTime.Parse(row["Kezd"].ToString()!),
                Befejez = row["Befejez"] == DBNull.Value ? null : DateTime.Parse(row["Befejez"].ToString()!)
            };
        }
        // Vásárlások lekérdezése dátumtartomány alapján
        public DataTable GetVasarlasokByDateRange(DateTime start, DateTime end)
        {
            string query = @"
                SELECT *
                FROM Vasarlasok
                WHERE Datum >= @Start AND Datum <= @End
                ORDER BY Datum DESC";
            var parameters = new[]
            {
                new SqliteParameter("@Start", start),
                new SqliteParameter("@End", end)
            };
            return ExecuteQuery(query, parameters);
        }
        static DbHelper()
        {
            Batteries.Init();
        }

        public DataTable GetKeszlet()
        {
            string query = "SELECT * FROM Keszlet ORDER BY Datum DESC";
            return ExecuteQuery(query);
        }
    }
}
