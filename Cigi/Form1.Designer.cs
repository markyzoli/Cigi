namespace Cigi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlStatisztika = new TabControl();
            tabPageVasarlas = new TabPage();
            label22 = new Label();
            dataGridViewKeszlet = new DataGridView();
            groupBoxVasarlas = new GroupBox();
            labeUtolsoVasarlasOtaNap = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            textBoxSzipkaDb = new TextBox();
            textBoxHuvelyDb = new TextBox();
            textBoxPipaGr = new TextBox();
            textBoxCigiGr = new TextBox();
            label12 = new Label();
            buttonSave = new Button();
            textBoxSzipkaFt = new TextBox();
            textBoxHuvelyFt = new TextBox();
            textBoxPipaFt = new TextBox();
            textBoxCigiFt = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            groupBoxMaradek = new GroupBox();
            labelDarabInfo = new Label();
            buttonKiszamol = new Button();
            textBoxPluszMinusz = new TextBox();
            textBoxMmeter = new TextBox();
            label7 = new Label();
            label6 = new Label();
            textBoxSzipkaMaradek = new TextBox();
            textBoxHuvelyMaradek = new TextBox();
            textBoxDohanyMaradek = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            tabPageStatisztika = new TabPage();
            groupBox2 = new GroupBox();
            dataGridViewDohanyUj = new DataGridView();
            groupBoxSzures = new GroupBox();
            label21 = new Label();
            labelVasarlasOta = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            labelSzipkaPerDb = new Label();
            labelHaviFt = new Label();
            labelNapiFt = new Label();
            labelNapiDb = new Label();
            buttonFrissit = new Button();
            datePickerGoal = new DateTimePicker();
            datePickerStart = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            tabControlStatisztika.SuspendLayout();
            tabPageVasarlas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeszlet).BeginInit();
            groupBoxVasarlas.SuspendLayout();
            groupBoxMaradek.SuspendLayout();
            tabPageStatisztika.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDohanyUj).BeginInit();
            groupBoxSzures.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlStatisztika
            // 
            tabControlStatisztika.Controls.Add(tabPageVasarlas);
            tabControlStatisztika.Controls.Add(tabPageStatisztika);
            tabControlStatisztika.Dock = DockStyle.Fill;
            tabControlStatisztika.Location = new Point(0, 0);
            tabControlStatisztika.Name = "tabControlStatisztika";
            tabControlStatisztika.SelectedIndex = 0;
            tabControlStatisztika.Size = new Size(800, 523);
            tabControlStatisztika.TabIndex = 1;
            // 
            // tabPageVasarlas
            // 
            tabPageVasarlas.Controls.Add(label22);
            tabPageVasarlas.Controls.Add(dataGridViewKeszlet);
            tabPageVasarlas.Controls.Add(groupBoxVasarlas);
            tabPageVasarlas.Controls.Add(groupBoxMaradek);
            tabPageVasarlas.Location = new Point(4, 24);
            tabPageVasarlas.Name = "tabPageVasarlas";
            tabPageVasarlas.Padding = new Padding(3);
            tabPageVasarlas.Size = new Size(792, 495);
            tabPageVasarlas.TabIndex = 0;
            tabPageVasarlas.Text = "Vásárlás";
            tabPageVasarlas.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(15, 287);
            label22.Name = "label22";
            label22.Size = new Size(43, 15);
            label22.TabIndex = 3;
            label22.Text = "Készlet";
            // 
            // dataGridViewKeszlet
            // 
            dataGridViewKeszlet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKeszlet.Dock = DockStyle.Bottom;
            dataGridViewKeszlet.Location = new Point(3, 305);
            dataGridViewKeszlet.Name = "dataGridViewKeszlet";
            dataGridViewKeszlet.Size = new Size(786, 187);
            dataGridViewKeszlet.TabIndex = 2;
            // 
            // groupBoxVasarlas
            // 
            groupBoxVasarlas.Controls.Add(labeUtolsoVasarlasOtaNap);
            groupBoxVasarlas.Controls.Add(label15);
            groupBoxVasarlas.Controls.Add(label14);
            groupBoxVasarlas.Controls.Add(label13);
            groupBoxVasarlas.Controls.Add(textBoxSzipkaDb);
            groupBoxVasarlas.Controls.Add(textBoxHuvelyDb);
            groupBoxVasarlas.Controls.Add(textBoxPipaGr);
            groupBoxVasarlas.Controls.Add(textBoxCigiGr);
            groupBoxVasarlas.Controls.Add(label12);
            groupBoxVasarlas.Controls.Add(buttonSave);
            groupBoxVasarlas.Controls.Add(textBoxSzipkaFt);
            groupBoxVasarlas.Controls.Add(textBoxHuvelyFt);
            groupBoxVasarlas.Controls.Add(textBoxPipaFt);
            groupBoxVasarlas.Controls.Add(textBoxCigiFt);
            groupBoxVasarlas.Controls.Add(label11);
            groupBoxVasarlas.Controls.Add(label10);
            groupBoxVasarlas.Controls.Add(label9);
            groupBoxVasarlas.Controls.Add(label8);
            groupBoxVasarlas.Location = new Point(15, 135);
            groupBoxVasarlas.Name = "groupBoxVasarlas";
            groupBoxVasarlas.Size = new Size(477, 146);
            groupBoxVasarlas.TabIndex = 1;
            groupBoxVasarlas.TabStop = false;
            groupBoxVasarlas.Text = "Vásárlás (Ft)";
            // 
            // labeUtolsoVasarlasOtaNap
            // 
            labeUtolsoVasarlasOtaNap.AutoSize = true;
            labeUtolsoVasarlasOtaNap.Location = new Point(322, 85);
            labeUtolsoVasarlasOtaNap.Name = "labeUtolsoVasarlasOtaNap";
            labeUtolsoVasarlasOtaNap.Size = new Size(145, 15);
            labeUtolsoVasarlasOtaNap.TabIndex = 18;
            labeUtolsoVasarlasOtaNap.Text = "labeUtolsoVasarlasOtaNap";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(208, 110);
            label15.Name = "label15";
            label15.Size = new Size(74, 15);
            label15.TabIndex = 17;
            label15.Text = "Kiszerelés db";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(208, 81);
            label14.Name = "label14";
            label14.Size = new Size(74, 15);
            label14.TabIndex = 16;
            label14.Text = "Kiszerelés db";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(208, 53);
            label13.Name = "label13";
            label13.Size = new Size(71, 15);
            label13.TabIndex = 15;
            label13.Text = "Kiszerelés gr";
            // 
            // textBoxSzipkaDb
            // 
            textBoxSzipkaDb.Location = new Point(146, 106);
            textBoxSzipkaDb.Name = "textBoxSzipkaDb";
            textBoxSzipkaDb.Size = new Size(56, 23);
            textBoxSzipkaDb.TabIndex = 14;
            // 
            // textBoxHuvelyDb
            // 
            textBoxHuvelyDb.Location = new Point(146, 77);
            textBoxHuvelyDb.Name = "textBoxHuvelyDb";
            textBoxHuvelyDb.Size = new Size(56, 23);
            textBoxHuvelyDb.TabIndex = 13;
            // 
            // textBoxPipaGr
            // 
            textBoxPipaGr.Location = new Point(146, 49);
            textBoxPipaGr.Name = "textBoxPipaGr";
            textBoxPipaGr.Size = new Size(56, 23);
            textBoxPipaGr.TabIndex = 12;
            // 
            // textBoxCigiGr
            // 
            textBoxCigiGr.Location = new Point(146, 22);
            textBoxCigiGr.Name = "textBoxCigiGr";
            textBoxCigiGr.Size = new Size(56, 23);
            textBoxCigiGr.TabIndex = 11;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(208, 26);
            label12.Name = "label12";
            label12.Size = new Size(71, 15);
            label12.TabIndex = 10;
            label12.Text = "Kiszerelés gr";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(319, 53);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Mentés";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // textBoxSzipkaFt
            // 
            textBoxSzipkaFt.Location = new Point(82, 106);
            textBoxSzipkaFt.Name = "textBoxSzipkaFt";
            textBoxSzipkaFt.Size = new Size(56, 23);
            textBoxSzipkaFt.TabIndex = 8;
            textBoxSzipkaFt.TextChanged += PriceTextBox_TextChanged;
            textBoxSzipkaFt.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // textBoxHuvelyFt
            // 
            textBoxHuvelyFt.Location = new Point(82, 77);
            textBoxHuvelyFt.Name = "textBoxHuvelyFt";
            textBoxHuvelyFt.Size = new Size(56, 23);
            textBoxHuvelyFt.TabIndex = 7;
            textBoxHuvelyFt.TextChanged += PriceTextBox_TextChanged;
            textBoxHuvelyFt.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // textBoxPipaFt
            // 
            textBoxPipaFt.Location = new Point(82, 49);
            textBoxPipaFt.Name = "textBoxPipaFt";
            textBoxPipaFt.Size = new Size(56, 23);
            textBoxPipaFt.TabIndex = 6;
            textBoxPipaFt.TextChanged += PriceTextBox_TextChanged;
            textBoxPipaFt.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // textBoxCigiFt
            // 
            textBoxCigiFt.Location = new Point(82, 22);
            textBoxCigiFt.Name = "textBoxCigiFt";
            textBoxCigiFt.Size = new Size(56, 23);
            textBoxCigiFt.TabIndex = 5;
            textBoxCigiFt.TextChanged += PriceTextBox_TextChanged;
            textBoxCigiFt.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(38, 110);
            label11.Name = "label11";
            label11.Size = new Size(40, 15);
            label11.TabIndex = 3;
            label11.Text = "Szipka";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(34, 81);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 2;
            label10.Text = "Hüvely";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 53);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 1;
            label9.Text = "Pipadohány";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 26);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 0;
            label8.Text = "Cigidohány";
            // 
            // groupBoxMaradek
            // 
            groupBoxMaradek.Controls.Add(labelDarabInfo);
            groupBoxMaradek.Controls.Add(buttonKiszamol);
            groupBoxMaradek.Controls.Add(textBoxPluszMinusz);
            groupBoxMaradek.Controls.Add(textBoxMmeter);
            groupBoxMaradek.Controls.Add(label7);
            groupBoxMaradek.Controls.Add(label6);
            groupBoxMaradek.Controls.Add(textBoxSzipkaMaradek);
            groupBoxMaradek.Controls.Add(textBoxHuvelyMaradek);
            groupBoxMaradek.Controls.Add(textBoxDohanyMaradek);
            groupBoxMaradek.Controls.Add(label5);
            groupBoxMaradek.Controls.Add(label4);
            groupBoxMaradek.Controls.Add(label3);
            groupBoxMaradek.Location = new Point(15, 11);
            groupBoxMaradek.Name = "groupBoxMaradek";
            groupBoxMaradek.Size = new Size(477, 117);
            groupBoxMaradek.TabIndex = 0;
            groupBoxMaradek.TabStop = false;
            groupBoxMaradek.Text = "Maradék";
            // 
            // labelDarabInfo
            // 
            labelDarabInfo.AutoSize = true;
            labelDarabInfo.Location = new Point(322, 50);
            labelDarabInfo.Name = "labelDarabInfo";
            labelDarabInfo.Size = new Size(87, 15);
            labelDarabInfo.TabIndex = 8;
            labelDarabInfo.Text = "@ sor, @ darab";
            // 
            // buttonKiszamol
            // 
            buttonKiszamol.Location = new Point(319, 17);
            buttonKiszamol.Name = "buttonKiszamol";
            buttonKiszamol.Size = new Size(152, 23);
            buttonKiszamol.TabIndex = 3;
            buttonKiszamol.Text = "Kiszámolja a hüvelyeket";
            buttonKiszamol.UseVisualStyleBackColor = true;
            buttonKiszamol.Click += ButtonKiszamol_Click;
            // 
            // textBoxPluszMinusz
            // 
            textBoxPluszMinusz.Location = new Point(267, 46);
            textBoxPluszMinusz.Name = "textBoxPluszMinusz";
            textBoxPluszMinusz.Size = new Size(36, 23);
            textBoxPluszMinusz.TabIndex = 2;
            textBoxPluszMinusz.KeyPress += TextBoxPluszMinusz_KeyPress;
            // 
            // textBoxMmeter
            // 
            textBoxMmeter.Location = new Point(267, 17);
            textBoxMmeter.Name = "textBoxMmeter";
            textBoxMmeter.Size = new Size(36, 23);
            textBoxMmeter.TabIndex = 1;
            textBoxMmeter.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(168, 50);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 7;
            label7.Text = "Plusz/minusz";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(166, 21);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 6;
            label6.Text = "Miliméter";
            // 
            // textBoxSzipkaMaradek
            // 
            textBoxSzipkaMaradek.Location = new Point(82, 76);
            textBoxSzipkaMaradek.Name = "textBoxSzipkaMaradek";
            textBoxSzipkaMaradek.Size = new Size(70, 23);
            textBoxSzipkaMaradek.TabIndex = 4;
            textBoxSzipkaMaradek.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // textBoxHuvelyMaradek
            // 
            textBoxHuvelyMaradek.Location = new Point(82, 46);
            textBoxHuvelyMaradek.Name = "textBoxHuvelyMaradek";
            textBoxHuvelyMaradek.Size = new Size(70, 23);
            textBoxHuvelyMaradek.TabIndex = 4;
            textBoxHuvelyMaradek.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // textBoxDohanyMaradek
            // 
            textBoxDohanyMaradek.Location = new Point(82, 17);
            textBoxDohanyMaradek.Name = "textBoxDohanyMaradek";
            textBoxDohanyMaradek.Size = new Size(70, 23);
            textBoxDohanyMaradek.TabIndex = 0;
            textBoxDohanyMaradek.KeyPress += TextBoxDohanyMaradek_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 80);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 2;
            label5.Text = "Szipka( (db)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 50);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 1;
            label4.Text = "Hüvely(db)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 21);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 0;
            label3.Text = "Dohány(gr)";
            // 
            // tabPageStatisztika
            // 
            tabPageStatisztika.Controls.Add(groupBox2);
            tabPageStatisztika.Controls.Add(groupBoxSzures);
            tabPageStatisztika.Location = new Point(4, 24);
            tabPageStatisztika.Name = "tabPageStatisztika";
            tabPageStatisztika.Padding = new Padding(3);
            tabPageStatisztika.Size = new Size(792, 495);
            tabPageStatisztika.TabIndex = 1;
            tabPageStatisztika.Text = "Statisztika";
            tabPageStatisztika.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewDohanyUj);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 126);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(786, 366);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Adatok";
            // 
            // dataGridViewDohanyUj
            // 
            dataGridViewDohanyUj.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDohanyUj.Dock = DockStyle.Fill;
            dataGridViewDohanyUj.Location = new Point(3, 19);
            dataGridViewDohanyUj.Name = "dataGridViewDohanyUj";
            dataGridViewDohanyUj.Size = new Size(780, 344);
            dataGridViewDohanyUj.TabIndex = 0;
            // 
            // groupBoxSzures
            // 
            groupBoxSzures.Controls.Add(label21);
            groupBoxSzures.Controls.Add(labelVasarlasOta);
            groupBoxSzures.Controls.Add(label20);
            groupBoxSzures.Controls.Add(label19);
            groupBoxSzures.Controls.Add(label18);
            groupBoxSzures.Controls.Add(label17);
            groupBoxSzures.Controls.Add(label16);
            groupBoxSzures.Controls.Add(labelSzipkaPerDb);
            groupBoxSzures.Controls.Add(labelHaviFt);
            groupBoxSzures.Controls.Add(labelNapiFt);
            groupBoxSzures.Controls.Add(labelNapiDb);
            groupBoxSzures.Controls.Add(buttonFrissit);
            groupBoxSzures.Controls.Add(datePickerGoal);
            groupBoxSzures.Controls.Add(datePickerStart);
            groupBoxSzures.Controls.Add(label2);
            groupBoxSzures.Controls.Add(label1);
            groupBoxSzures.Dock = DockStyle.Top;
            groupBoxSzures.Location = new Point(3, 3);
            groupBoxSzures.Name = "groupBoxSzures";
            groupBoxSzures.Size = new Size(786, 123);
            groupBoxSzures.TabIndex = 0;
            groupBoxSzures.TabStop = false;
            groupBoxSzures.Text = "Szűrés";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(701, 42);
            label21.Name = "label21";
            label21.Size = new Size(36, 15);
            label21.TabIndex = 17;
            label21.Text = "telt el";
            // 
            // labelVasarlasOta
            // 
            labelVasarlasOta.AutoSize = true;
            labelVasarlasOta.Location = new Point(663, 42);
            labelVasarlasOta.Name = "labelVasarlasOta";
            labelVasarlasOta.Size = new Size(36, 15);
            labelVasarlasOta.TabIndex = 16;
            labelVasarlasOta.Text = "0 nap";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(557, 42);
            label20.Name = "label20";
            label20.Size = new Size(105, 15);
            label20.TabIndex = 15;
            label20.Text = "Utolsó vásárlás óta";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(557, 23);
            label19.Name = "label19";
            label19.Size = new Size(67, 15);
            label19.TabIndex = 14;
            label19.Text = "Szipka/cigi:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(420, 61);
            label18.Name = "label18";
            label18.Size = new Size(47, 15);
            label18.TabIndex = 13;
            label18.Text = "Havi Ft:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(419, 42);
            label17.Name = "label17";
            label17.Size = new Size(48, 15);
            label17.TabIndex = 12;
            label17.Text = "Napi Ft:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(410, 23);
            label16.Name = "label16";
            label16.Size = new Size(57, 15);
            label16.TabIndex = 11;
            label16.Text = "Napi cigi:";
            // 
            // labelSzipkaPerDb
            // 
            labelSzipkaPerDb.AutoSize = true;
            labelSzipkaPerDb.Location = new Point(627, 23);
            labelSzipkaPerDb.Name = "labelSzipkaPerDb";
            labelSzipkaPerDb.Size = new Size(97, 15);
            labelSzipkaPerDb.TabIndex = 10;
            labelSzipkaPerDb.Text = "labelSzipkaPerDb";
            // 
            // labelHaviFt
            // 
            labelHaviFt.AutoSize = true;
            labelHaviFt.Location = new Point(473, 61);
            labelHaviFt.Name = "labelHaviFt";
            labelHaviFt.Size = new Size(66, 15);
            labelHaviFt.TabIndex = 9;
            labelHaviFt.Text = "labelHaviFt";
            // 
            // labelNapiFt
            // 
            labelNapiFt.AutoSize = true;
            labelNapiFt.Location = new Point(473, 42);
            labelNapiFt.Name = "labelNapiFt";
            labelNapiFt.Size = new Size(67, 15);
            labelNapiFt.TabIndex = 8;
            labelNapiFt.Text = "labelNapiFt";
            // 
            // labelNapiDb
            // 
            labelNapiDb.AutoSize = true;
            labelNapiDb.Location = new Point(473, 23);
            labelNapiDb.Name = "labelNapiDb";
            labelNapiDb.Size = new Size(72, 15);
            labelNapiDb.TabIndex = 7;
            labelNapiDb.Text = "labelNapiDb";
            // 
            // buttonFrissit
            // 
            buttonFrissit.Location = new Point(321, 54);
            buttonFrissit.Name = "buttonFrissit";
            buttonFrissit.Size = new Size(75, 23);
            buttonFrissit.TabIndex = 6;
            buttonFrissit.Text = "Frissítés";
            buttonFrissit.UseVisualStyleBackColor = true;
            buttonFrissit.Click += ButtonFrissit_Click;
            // 
            // datePickerGoal
            // 
            datePickerGoal.Location = new Point(115, 55);
            datePickerGoal.Name = "datePickerGoal";
            datePickerGoal.Size = new Size(200, 23);
            datePickerGoal.TabIndex = 5;
            // 
            // datePickerStart
            // 
            datePickerStart.Location = new Point(115, 23);
            datePickerStart.Name = "datePickerStart";
            datePickerStart.Size = new Size(200, 23);
            datePickerStart.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 59);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 3;
            label2.Text = "Befelyező dátum";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 27);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 2;
            label1.Text = "Kezdő dátum";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 523);
            Controls.Add(tabControlStatisztika);
            Name = "Form1";
            Text = "Dohány vásárlás és statisztika";
            Load += Form1_Load;
            tabControlStatisztika.ResumeLayout(false);
            tabPageVasarlas.ResumeLayout(false);
            tabPageVasarlas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeszlet).EndInit();
            groupBoxVasarlas.ResumeLayout(false);
            groupBoxVasarlas.PerformLayout();
            groupBoxMaradek.ResumeLayout(false);
            groupBoxMaradek.PerformLayout();
            tabPageStatisztika.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDohanyUj).EndInit();
            groupBoxSzures.ResumeLayout(false);
            groupBoxSzures.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlStatisztika;
        private TabPage tabPageVasarlas;
        private TabPage tabPageStatisztika;
        private GroupBox groupBoxVasarlas;
        private GroupBox groupBoxMaradek;
        private GroupBox groupBoxSzures;
        private Label label2;
        private Label label1;
        private DateTimePicker datePickerGoal;
        private DateTimePicker datePickerStart;
        private GroupBox groupBox2;
        private DataGridView dataGridViewDohanyUj;
        private Button buttonFrissit;
        private TextBox textBoxSzipkaMaradek;
        private TextBox textBoxHuvelyMaradek;
        private TextBox textBoxDohanyMaradek;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBoxMmeter;
        private Label label7;
        private Label label6;
        private TextBox textBoxPluszMinusz;
        private Button buttonKiszamol;
        private TextBox textBoxHuvelyFt;
        private TextBox textBoxPipaFt;
        private TextBox textBoxCigiFt;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button buttonSave;
        private TextBox textBoxSzipkaFt;
        private Label labelSzipkaPerDb;
        private Label labelHaviFt;
        private Label labelNapiFt;
        private Label labelNapiDb;
        private Label labelDarabInfo;
        private TextBox textBoxHuvelyDb;
        private TextBox textBoxPipaGr;
        private TextBox textBoxCigiGr;
        private Label label12;
        private Label label15;
        private Label label14;
        private Label label13;
        private TextBox textBoxSzipkaDb;
        private Label label17;
        private Label label16;
        private Label label19;
        private Label label18;
        private Label label21;
        private Label labelVasarlasOta;
        private Label label20;
        private DataGridView dataGridViewKeszlet;
        private Label label22;
        private Label labeUtolsoVasarlasOtaNap;
    }
}
