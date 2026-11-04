using Microsoft.Data.Sqlite;
namespace Cigi
{
    public partial class Form1 : Form
    {
        private readonly DbHelper dbHelper = new(@"C:\Users\marky\OneDrive\Dokumentumok\AdatBazisok\DohanyUj.db");
        // cigiDohany ára változó
        private decimal cigiDohanyAr;
        // pipaDohany ára változó
        private decimal pipaDohanyAr;
        // szipka ára változó
        private decimal szipkaAr;
        // hüvely ára változó
        private decimal huvelyAr;
        // cigiDohany gr változó
        private decimal cigiDohanyGr;
        // pipaDohany gr változó
        private decimal pipaDohanyGr;
        // szipka db változó
        private int szipkaDb;
        // hüvely db változó
        private int huvelyDb;

        // Legutolsó készlet és vásárlás objektumok
        private KeszletInfo? utolsoKeszlet;
        private VasarlasInfo? utolsoMaradek;
        // Kezdés befelyezés objekum változója
        private KezdesBefejezesInfo? kezdesBefejezesInfo;
        // OsszVasarlasInfo objektum változója
        private OsszVasarlasInfo? osszVasarlasInfo;
        // VasarlasInfo objektum változója
        private VasarlasInfo? vasarlasInfo;
        // KeszletInfo objektum változója
        private KeszletInfo? keszletInfo;
        // OsszKeszletInfo objektum változója
        private OsszKeszletInfo? osszKeszletInfo;

        public Form1()
        {
            InitializeComponent();
        }

        private void TextBoxDohanyMaradek_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Csak számokat és vezérlõ karaktereket (pl. backspace) engedélyezünk
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBoxPluszMinusz_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Engedélyezünk számot, vezérlõ karaktert
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;

            // Engedélyezzük a mínusz jelet csak az elsõ pozícióban, ha még nincs benne
            if (e.KeyChar == '-' && sender is TextBox tb && tb.SelectionStart == 0 && !tb.Text.Contains('-'))
                return;

            // Egyébként tiltjuk
            e.Handled = true;
        }

        private void CalculateHuvelyMaradek()
        {
            if (double.TryParse(textBoxMmeter.Text, out double mertMm) &&
                int.TryParse(textBoxPluszMinusz.Text, out int korrekcio))
            {
                int huvelySorban = 25;
                int sorokSzama = 8;
                double dobozMagassag = 62.0;
                double atlagHuvelyMagassag = dobozMagassag / sorokSzama;

                int maradekSorMin = sorokSzama - (int)Math.Floor((mertMm + 2) / atlagHuvelyMagassag);
                //int maradekSorMax = sorokSzama - (int)Math.Floor((mertMm - 2) / atlagHuvelyMagassag);

                int maradekDarabMin = maradekSorMin * huvelySorban;
                //int maradekDarabMax = maradekSorMax * huvelySorban;

                // Végsõ maradék: hozzáadjuk a korrekciót
                int vegsoMaradek = maradekDarabMin + korrekcio;

                labelDarabInfo.Text = $"{maradekSorMin} sor, {maradekDarabMin} darab";
                textBoxHuvelyMaradek.Text = vegsoMaradek.ToString();
            }
            else
            {
                labelDarabInfo.Text = "Hibás adat";
                textBoxHuvelyMaradek.Text = "";
            }
        }
        // Amikor az ûrlap betöltõdik, ha az adatbázis elérhetõ, akkor lekérdezzük a legutóbbi nem nulla cigidohany és pipadohány árakat
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cigiDohanyAr = dbHelper.GetLastNonZeroCigiDohanyAr();
                pipaDohanyAr = dbHelper.GetLastNonZeroPipaDohanyAr();
                textBoxCigiFt.Text = cigiDohanyAr.ToString("F0");
                textBoxPipaFt.Text = pipaDohanyAr.ToString("F0");
                szipkaAr = dbHelper.GetLastNonZeroSzipkaAr();
                huvelyAr = dbHelper.GetLastNonZeroHuvelyAr();
                textBoxSzipkaFt.Text = szipkaAr.ToString("F0");
                textBoxHuvelyFt.Text = huvelyAr.ToString("F0");
                cigiDohanyGr = dbHelper.GetLastNonZeroCigiDohanyGr();
                pipaDohanyGr = dbHelper.GetLastNonZeroPipaDohanyGr();
                szipkaDb = dbHelper.GetLastNonZeroSzipkaDb();
                huvelyDb = dbHelper.GetLastNonZeroHuvelyDb();
                textBoxCigiGr.Text = cigiDohanyGr.ToString("F0");
                textBoxPipaGr.Text = pipaDohanyGr.ToString("F0");
                textBoxSzipkaDb.Text = szipkaDb.ToString();
                textBoxHuvelyDb.Text = huvelyDb.ToString();

                utolsoKeszlet = dbHelper.GetLastKeszlet();
                utolsoMaradek = dbHelper.GetLastMaradek();
                kezdesBefejezesInfo = dbHelper.GetKezdesBefejezes();
                osszVasarlasInfo = dbHelper.GetOsszVasarlas();
                vasarlasInfo = dbHelper.GetLastVasarlas();
                keszletInfo = dbHelper.GetLastKeszlet();
                osszKeszletInfo = dbHelper.GetOsszKeszlet();

                datePickerGoal.Value = DateTime.Today;
                datePickerStart.Value = DateTime.Today.AddYears(-1);

                FrissitStatisztika();
                FrissitVasarlasOta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba az adatbázis elérésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SomeMethod()
        {
            var result = dbHelper.ExecuteScalar("SELECT COUNT(*) FROM Vasarlasok");
            if (result != null)
            {
                // feldolgozás
            }
        }

        private void ButtonKiszamol_Click(object sender, EventArgs e)
        {
            CalculateHuvelyMaradek();
        }

        private bool AreAllVasarlasFieldsFilled()
        {
            foreach (Control control in groupBoxVasarlas.Controls)
            {
                if (control is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreAllVasarlasAndMaradekFieldsFilled()
        {
            // Ellenõrzi a Vásárlás mezõket
            foreach (Control control in groupBoxVasarlas.Controls)
            {
                if (control is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
                {
                    return false;
                }
            }
            // Ellenõrzi a Maradék mezõket
            foreach (Control control in groupBoxMaradek.Controls)
            {
                if (control is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Minden mezõ ki van töltve?
            if (!AreAllVasarlasAndMaradekFieldsFilled())
            {
                MessageBox.Show("Kérem, töltse ki az összes mezõt a Vásárlás és Maradék csoportokban!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // --- Maradék példány létrehozása ---
                decimal dohanMaradek = decimal.Parse(textBoxDohanyMaradek.Text);
                decimal osszesEredeti = cigiDohanyGr + pipaDohanyGr;

                int maradekCigiGr = 0;
                int maradekPipaGr = 0;
                if (osszesEredeti > 0)
                {
                    maradekCigiGr = (int)Math.Round((dohanMaradek / osszesEredeti) * cigiDohanyGr);
                    maradekPipaGr = (int)Math.Round((dohanMaradek / osszesEredeti) * pipaDohanyGr);
                }
                int maradekHuvelyDb = int.Parse(textBoxHuvelyMaradek.Text);
                int maradekSzipkaDb = int.Parse(textBoxSzipkaMaradek.Text);

                var maradek = new VasarlasInfo
                {
                    Datum = DateTime.Now,
                    CigiDohanyAr = 0,
                    PipaDohanyAr = 0,
                    SzipkaAr = 0,
                    HuvelyAr = 0,
                    CigiDohanyGr = maradekCigiGr,
                    PipaDohanyGr = maradekPipaGr,
                    SzipkaDb = maradekSzipkaDb,
                    HuvelyDb = maradekHuvelyDb,
                    VasarlasMaradek = 0
                };

                // --- Vásárlás példány létrehozása ---
                var vasarlas = new VasarlasInfo
                {
                    Datum = DateTime.Now,
                    CigiDohanyAr = (int)decimal.Parse(textBoxCigiFt.Text),
                    PipaDohanyAr = (int)decimal.Parse(textBoxPipaFt.Text),
                    SzipkaAr = (int)decimal.Parse(textBoxSzipkaFt.Text),
                    HuvelyAr = (int)decimal.Parse(textBoxHuvelyFt.Text),
                    CigiDohanyGr = (int)decimal.Parse(textBoxCigiGr.Text),
                    PipaDohanyGr = (int)decimal.Parse(textBoxPipaGr.Text),
                    SzipkaDb = int.Parse(textBoxSzipkaDb.Text),
                    HuvelyDb = int.Parse(textBoxHuvelyDb.Text),
                    VasarlasMaradek = 1
                };

                // --- Elõzõ készlet lekérése ---
                var elozoKeszlet = dbHelper.GetLastKeszlet();

                // --- Új készlet példány létrehozása ---
                var ujKeszlet = new KeszletInfo
                {
                    Datum = DateTime.Now,
                    DohanyGr = vasarlas.CigiDohanyGr + vasarlas.PipaDohanyGr + maradek.CigiDohanyGr + maradek.PipaDohanyGr,
                    SzipkaDb = vasarlas.SzipkaDb + maradek.SzipkaDb,
                    HuvelyDb = vasarlas.HuvelyDb + maradek.HuvelyDb,
                    FDohanyGr = elozoKeszlet != null ? elozoKeszlet.DohanyGr - (maradek.CigiDohanyGr + maradek.PipaDohanyGr) : 0,
                    FSzipkaDb = elozoKeszlet != null ? elozoKeszlet.SzipkaDb - maradek.SzipkaDb : 0,
                    FHuvelyDb = elozoKeszlet != null ? elozoKeszlet.HuvelyDb - maradek.HuvelyDb : 0,
                    Napok = elozoKeszlet != null ? (int)(DateTime.Now.Date - elozoKeszlet.Datum.Date).TotalDays : 0
                };

                // --- Maradék mentése ---
                string insertMaradekQuery = @"
                    INSERT INTO Vasarlasok 
                    (CigiDohanyAr, PipaDohanyAr, SzipkaAr, HuvelyAr, CigiDohanyGr, PipaDohanyGr, SzipkaDb, HuvelyDb, VasarlasMaradek, Datum)
                    VALUES (0, 0, 0, 0, @CigiDohanyGr, @PipaDohanyGr, @SzipkaDb, @HuvelyDb, 0, @Datum)";
                var maradekParams = new[]
                {
                    new SqliteParameter("@CigiDohanyGr", maradek.CigiDohanyGr),
                    new SqliteParameter("@PipaDohanyGr", maradek.PipaDohanyGr),
                    new SqliteParameter("@SzipkaDb", maradek.SzipkaDb),
                    new SqliteParameter("@HuvelyDb", maradek.HuvelyDb),
                    new SqliteParameter("@Datum", maradek.Datum)
                };
                dbHelper.ExecuteNonQuery(insertMaradekQuery, maradekParams);

                // --- Vásárlás mentése ---
                string insertVasarlasQuery = @"
                    INSERT INTO Vasarlasok 
                    (CigiDohanyAr, PipaDohanyAr, SzipkaAr, HuvelyAr, CigiDohanyGr, PipaDohanyGr, SzipkaDb, HuvelyDb, VasarlasMaradek, Datum)
                    VALUES (@CigiDohanyAr, @PipaDohanyAr, @SzipkaAr, @HuvelyAr, @CigiDohanyGr, @PipaDohanyGr, @SzipkaDb, @HuvelyDb, 1, @Datum)";
                var vasarlasParams = new[]
                {
                    new SqliteParameter("@CigiDohanyAr", vasarlas.CigiDohanyAr),
                    new SqliteParameter("@PipaDohanyAr", vasarlas.PipaDohanyAr),
                    new SqliteParameter("@SzipkaAr", vasarlas.SzipkaAr),
                    new SqliteParameter("@HuvelyAr", vasarlas.HuvelyAr),
                    new SqliteParameter("@CigiDohanyGr", vasarlas.CigiDohanyGr),
                    new SqliteParameter("@PipaDohanyGr", vasarlas.PipaDohanyGr),
                    new SqliteParameter("@SzipkaDb", vasarlas.SzipkaDb),
                    new SqliteParameter("@HuvelyDb", vasarlas.HuvelyDb),
                    new SqliteParameter("@Datum", vasarlas.Datum)
                };
                dbHelper.ExecuteNonQuery(insertVasarlasQuery, vasarlasParams);

                // --- Új készlet mentése ---
                string insertKeszletQuery = @"
                    INSERT INTO Keszlet 
                    (DohanyGr, SzipkaDb, HuvelyDb, FDohanyGr, FSzipkaDb, FHuvelyDb, Napok, Datum)
                    VALUES (@DohanyGr, @SzipkaDb, @HuvelyDb, @FDohanyGr, @FSzipkaDb, @FHuvelyDb, @Napok, @Datum)";
                var keszletParams = new[]
                {
                    new SqliteParameter("@DohanyGr", ujKeszlet.DohanyGr),
                    new SqliteParameter("@SzipkaDb", ujKeszlet.SzipkaDb),
                    new SqliteParameter("@HuvelyDb", ujKeszlet.HuvelyDb),
                    new SqliteParameter("@FDohanyGr", ujKeszlet.FDohanyGr),
                    new SqliteParameter("@FSzipkaDb", ujKeszlet.FSzipkaDb),
                    new SqliteParameter("@FHuvelyDb", ujKeszlet.FHuvelyDb),
                    new SqliteParameter("@Napok", ujKeszlet.Napok),
                    new SqliteParameter("@Datum", ujKeszlet.Datum)
                };
                dbHelper.ExecuteNonQuery(insertKeszletQuery, keszletParams);

                MessageBox.Show("Adatok sikeresen elmentve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba mentés közben: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FrissitStatisztika();
        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox priceBox)
            {
                // Ha üres, automatikusan "0"-t ír be és kijelöli
                if (string.IsNullOrWhiteSpace(priceBox.Text))
                {
                    priceBox.Text = "0";
                    priceBox.SelectionStart = 0;
                    priceBox.SelectionLength = priceBox.Text.Length;
                }

                // Kapcsolt mennyiségi mezõ beállítása
                if (priceBox == textBoxCigiFt)
                {
                    if (priceBox.Text == "0")
                        textBoxCigiGr.Text = "0";
                    else
                        textBoxCigiGr.Text = cigiDohanyGr.ToString("F0");
                }
                else if (priceBox == textBoxPipaFt)
                {
                    if (priceBox.Text == "0")
                        textBoxPipaGr.Text = "0";
                    else
                        textBoxPipaGr.Text = pipaDohanyGr.ToString("F0");
                }
                else if (priceBox == textBoxHuvelyFt)
                {
                    if (priceBox.Text == "0")
                        textBoxHuvelyDb.Text = "0";
                    else
                        textBoxHuvelyDb.Text = huvelyDb.ToString();
                }
                else if (priceBox == textBoxSzipkaFt)
                {
                    if (priceBox.Text == "0")
                        textBoxSzipkaDb.Text = "0";
                    else
                        textBoxSzipkaDb.Text = szipkaDb.ToString();
                }
            }
        }

        private void SaveMaradek()
        {
            // ...Ar mezõk üresen (0), gr-ek kalkulálva, VasarlasMaradek = 0
            decimal dohanMaradek = decimal.Parse(textBoxDohanyMaradek.Text);
            decimal osszesEredeti = cigiDohanyGr + pipaDohanyGr;

            decimal savedCigiDohanyGr = (int)Math.Round((dohanMaradek / osszesEredeti) * cigiDohanyGr);
            decimal savedPipaDohanyGr = (int)Math.Round((dohanMaradek / osszesEredeti) * pipaDohanyGr);

            int savedHuvelyDb = int.Parse(textBoxHuvelyMaradek.Text);
            int savedSzipkaDb = int.Parse(textBoxSzipkaMaradek.Text);

            string insertQuery = @"
                INSERT INTO Vasarlasok 
                (CigiDohanyAr, PipaDohanyAr, SzipkaAr, HuvelyAr, CigiDohanyGr, PipaDohanyGr, SzipkaDb, HuvelyDb, VasarlasMaradek)
                VALUES (0, 0, 0, 0, @CigiDohanyGr, @PipaDohanyGr, @SzipkaDb, @HuvelyDb, 0)";
            var parameters = new[]
            {
                new SqliteParameter("@CigiDohanyGr", cigiDohanyGr),
                new SqliteParameter("@PipaDohanyGr", pipaDohanyGr),
                new SqliteParameter("@SzipkaDb", szipkaDb),
                new SqliteParameter("@HuvelyDb", huvelyDb)
            };
            dbHelper.ExecuteNonQuery(insertQuery, parameters);
        }

        private void SaveVasarlas()
        {
            // ...Ar és gr/db mezõk kitöltve, VasarlasMaradek automatikus (1)
            string insertQuery = @"
        INSERT INTO Vasarlasok 
        (CigiDohanyAr, PipaDohanyAr, SzipkaAr, HuvelyAr, CigiDohanyGr, PipaDohanyGr, SzipkaDb, HuvelyDb)
        VALUES (@CigiDohanyAr, @PipaDohanyAr, @SzipkaAr, @HuvelyAr, @CigiDohanyGr, @PipaDohanyGr, @SzipkaDb, @HuvelyDb)";
            var parameters = new[]
            {
                new SqliteParameter("@CigiDohanyAr", decimal.Parse(textBoxCigiFt.Text)),
                new SqliteParameter("@PipaDohanyAr", decimal.Parse(textBoxPipaFt.Text)),
                new SqliteParameter("@SzipkaAr", decimal.Parse(textBoxSzipkaFt.Text)),
                new SqliteParameter("@HuvelyAr", decimal.Parse(textBoxHuvelyFt.Text)),
                new SqliteParameter("@CigiDohanyGr", decimal.Parse(textBoxCigiGr.Text)),
                new SqliteParameter("@PipaDohanyGr", decimal.Parse(textBoxPipaGr.Text)),
                new SqliteParameter("@SzipkaDb", int.Parse(textBoxSzipkaDb.Text)),
                new SqliteParameter("@HuvelyDb", int.Parse(textBoxHuvelyDb.Text))
            };
            dbHelper.ExecuteNonQuery(insertQuery, parameters);
        }

        private void SaveKeszlet(
            decimal savedCigiDohanyGr, decimal savedPipaDohanyGr,
            int savedSzipkaDb, int savedHuvelyDb, DateTime aktualisDatum)
        {
            // Vásárlás mennyiségei
            decimal vasarlasCigiGr = decimal.Parse(textBoxCigiGr.Text);
            decimal vasarlasPipaGr = decimal.Parse(textBoxPipaGr.Text);
            int vasarlasSzipkaDb = int.Parse(textBoxSzipkaDb.Text);
            int vasarlasHuvelyDb = int.Parse(textBoxHuvelyDb.Text);

            // Készlet = maradék + vásárlás
            int dohanGr = (int)Math.Round(savedCigiDohanyGr + savedPipaDohanyGr + vasarlasCigiGr + vasarlasPipaGr);
            int szipkaDb = savedSzipkaDb + vasarlasSzipkaDb;
            int huvelyDb = savedHuvelyDb + vasarlasHuvelyDb;

            int fDohanyGr = 0, fSzipkaDb = 0, fHuvelyDb = 0, napok = 0;

            if (utolsoKeszlet != null)
            {
                fDohanyGr = utolsoKeszlet.DohanyGr - dohanGr;
                fSzipkaDb = utolsoKeszlet.SzipkaDb - szipkaDb;
                fHuvelyDb = utolsoKeszlet.HuvelyDb - huvelyDb;
                napok = (int)(aktualisDatum - utolsoKeszlet.Datum).TotalDays;
            }

            string insertQuery = @"
                INSERT INTO Keszlet 
                (DohanyGr, SzipkaDb, HuvelyDb, FDohanyGr, FSzipkaDb, FHuvelyDb, Napok, Datum)
                VALUES (@DohanyGr, @SzipkaDb, @HuvelyDb, @FDohanyGr, @FSzipkaDb, @FHuvelyDb, @Napok, @Datum)";
            var parameters = new[]
            {
                new SqliteParameter("@DohanyGr", dohanGr),
                new SqliteParameter("@SzipkaDb", szipkaDb),
                new SqliteParameter("@HuvelyDb", huvelyDb),
                new SqliteParameter("@FDohanyGr", fDohanyGr),
                new SqliteParameter("@FSzipkaDb", fSzipkaDb),
                new SqliteParameter("@FHuvelyDb", fHuvelyDb),
                new SqliteParameter("@Napok", napok),
                new SqliteParameter("@Datum", aktualisDatum)
            };
            dbHelper.ExecuteNonQuery(insertQuery, parameters);
        }

        private void FrissitStatisztika()
        {
            // Készlet-alapú statisztika, ha van legalább egy fogyás
            bool vanFogyasztas = osszKeszletInfo != null
                && osszKeszletInfo.Napok > 0
                && (osszKeszletInfo.FHuvelyDb > 0 || osszKeszletInfo.FSzipkaDb > 0 || osszKeszletInfo.FDohanyGr > 0);

            if (vanFogyasztas)
            {
                var keszlet = osszKeszletInfo!; // biztosan nem null, mert a feltételben ellenõrizted

                double napiHuvely = keszlet.FHuvelyDb / (double)keszlet.Napok;
                double napiFt = (
                    (double)keszlet.FHuvelyDb * (double)huvelyAr +
                    (double)keszlet.FSzipkaDb * (double)szipkaAr +
                    (double)keszlet.FDohanyGr * ((double)cigiDohanyAr + (double)pipaDohanyAr) / 2
                ) / (double)keszlet.Napok;
                double haviFt = napiFt * 30;
                string szipkaPerDb = keszlet.FSzipkaDb > 0
                    ? (keszlet.FHuvelyDb / (double)keszlet.FSzipkaDb).ToString("F2")
                    : "-";

                labelNapiDb.Text = napiHuvely.ToString("F2");
                labelNapiFt.Text = napiFt.ToString("F0") + " Ft";
                labelHaviFt.Text = haviFt.ToString("F0") + " Ft";
                labelSzipkaPerDb.Text = szipkaPerDb;
}
            // Vásárlás-alapú statisztika, ha nincs fogyás
            else if (
                osszVasarlasInfo != null &&
                kezdesBefejezesInfo != null &&
                kezdesBefejezesInfo.Kezd.HasValue &&
                kezdesBefejezesInfo.Befejez.HasValue
            )
            {
                int napok = (int)(kezdesBefejezesInfo.Befejez.Value - kezdesBefejezesInfo.Kezd.Value).TotalDays + 1;
                if (napok <= 0) napok = 1; // elkerülni a nullával osztást

                double napiHuvely = (double)osszVasarlasInfo.Huvely / (double)napok;
                double napiFt = (double)osszVasarlasInfo.Osszeg / (double)napok;
                double haviFt = napiFt * 30;
                string szipkaPerDb = osszVasarlasInfo.Szipka > 0
                    ? (osszVasarlasInfo.Huvely / (double)osszVasarlasInfo.Szipka).ToString("F2")
                    : "-";

                labelNapiDb.Text = napiHuvely.ToString("F2");
                labelNapiFt.Text = napiFt.ToString("F0") + " Ft";
                labelHaviFt.Text = haviFt.ToString("F0") + " Ft";
                labelSzipkaPerDb.Text = szipkaPerDb;
            }
            // 3. Ha nincs elég adat
            else
            {
                labelNapiDb.Text = "-";
                labelNapiFt.Text = "-";
                labelHaviFt.Text = "-";
                labelSzipkaPerDb.Text = "-";
            }

            // Készlet tábla frissítése
            dataGridViewKeszlet.DataSource = dbHelper.GetKeszlet();
        }

        private void ButtonFrissit_Click(object sender, EventArgs e)
        {
            DateTime start = datePickerStart.Value.Date;
            DateTime end = datePickerGoal.Value.Date.AddDays(1).AddTicks(-1); // hogy a teljes utolsó nap is benne legyen

            var dt = dbHelper.GetVasarlasokByDateRange(start, end);
            dataGridViewDohanyUj.DataSource = dt;
        }

        private void FrissitVasarlasOta()
        {
            if (vasarlasInfo != null)
            {
                DateTime utolsoVasarlas = vasarlasInfo.Datum;
                int napok = (DateTime.Today - utolsoVasarlas.Date).Days;
                if (napok < 0) napok = 0;
                labelVasarlasOta.Text = $"{napok} nap";
            }
            else
            {
                labelVasarlasOta.Text = "-";
            }
        }
    }
}
