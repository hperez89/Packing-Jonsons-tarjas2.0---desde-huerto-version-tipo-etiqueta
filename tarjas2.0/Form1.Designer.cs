namespace tarjas2._0
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.metroTile1 = new MetroFramework.Controls.MetroTile();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.CopiasTxt = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
			this.EmbalajeTxt = new MetroFramework.Controls.MetroComboBox();
			this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
			this.PackingTxt = new MetroFramework.Controls.MetroComboBox();
			this.FechaTxt = new MetroFramework.Controls.MetroDateTime();
			this.CantCajasTxt = new MetroFramework.Controls.MetroTextBox();
			this.CalibreTxt = new MetroFramework.Controls.MetroComboBox();
			this.VariedadTxt = new MetroFramework.Controls.MetroComboBox();
			this.ProductorTxt = new MetroFramework.Controls.MetroComboBox();
			this.NroFolioTxt = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.PalletCompletoTxt = new MetroFramework.Controls.MetroToggle();
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// metroTile1
			// 
			this.metroTile1.ActiveControl = null;
			this.metroTile1.Location = new System.Drawing.Point(768, 215);
			this.metroTile1.Name = "metroTile1";
			this.metroTile1.Size = new System.Drawing.Size(203, 117);
			this.metroTile1.Style = MetroFramework.MetroColorStyle.Green;
			this.metroTile1.TabIndex = 11;
			this.metroTile1.Text = "Imprimir Tarja";
			this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
			this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.metroTile1.UseSelectable = true;
			this.metroTile1.Click += new System.EventHandler(this.MetroTile1_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// CopiasTxt
			// 
			this.CopiasTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			// 
			// 
			// 
			this.CopiasTxt.CustomButton.Image = null;
			this.CopiasTxt.CustomButton.Location = new System.Drawing.Point(65, 2);
			this.CopiasTxt.CustomButton.Name = "";
			this.CopiasTxt.CustomButton.Size = new System.Drawing.Size(25, 25);
			this.CopiasTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.CopiasTxt.CustomButton.TabIndex = 1;
			this.CopiasTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.CopiasTxt.CustomButton.UseSelectable = true;
			this.CopiasTxt.CustomButton.Visible = false;
			this.CopiasTxt.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.CopiasTxt.Lines = new string[] {
        "4"};
			this.CopiasTxt.Location = new System.Drawing.Point(872, 366);
			this.CopiasTxt.MaxLength = 32767;
			this.CopiasTxt.Name = "CopiasTxt";
			this.CopiasTxt.PasswordChar = '\0';
			this.CopiasTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.CopiasTxt.SelectedText = "";
			this.CopiasTxt.SelectionLength = 0;
			this.CopiasTxt.SelectionStart = 0;
			this.CopiasTxt.ShortcutsEnabled = true;
			this.CopiasTxt.Size = new System.Drawing.Size(93, 30);
			this.CopiasTxt.TabIndex = 10;
			this.CopiasTxt.Text = "4";
			this.CopiasTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.CopiasTxt.UseSelectable = true;
			this.CopiasTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.CopiasTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel9
			// 
			this.metroLabel9.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel9.AutoSize = true;
			this.metroLabel9.Location = new System.Drawing.Point(800, 370);
			this.metroLabel9.Name = "metroLabel9";
			this.metroLabel9.Size = new System.Drawing.Size(68, 19);
			this.metroLabel9.TabIndex = 109;
			this.metroLabel9.Text = "N° Copias";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.metroLabel10, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.EmbalajeTxt, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel8, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.PackingTxt, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.FechaTxt, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.CantCajasTxt, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.CalibreTxt, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.VariedadTxt, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.ProductorTxt, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.NroFolioTxt, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel7, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel6, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel5, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.PalletCompletoTxt, 3, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 99);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 290);
			this.tableLayoutPanel1.TabIndex = 112;
			// 
			// metroLabel10
			// 
			this.metroLabel10.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel10.AutoSize = true;
			this.metroLabel10.Location = new System.Drawing.Point(356, 251);
			this.metroLabel10.Name = "metroLabel10";
			this.metroLabel10.Size = new System.Drawing.Size(103, 19);
			this.metroLabel10.TabIndex = 113;
			this.metroLabel10.Text = "Pallet Completo";
			// 
			// EmbalajeTxt
			// 
			this.EmbalajeTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EmbalajeTxt.DropDownWidth = 220;
			this.EmbalajeTxt.FormattingEnabled = true;
			this.EmbalajeTxt.ItemHeight = 23;
			this.EmbalajeTxt.Items.AddRange(new object[] {
            "08KPM",
            "10x2 LB",
            "10x500",
            "10x500 AN",
            "10x500 AS",
            "10x500 ASA",
            "10x500 BELGICA",
            "10X500 BI",
            "10x500 BRASIL",
            "10x500 CAPE",
            "10x500 COP BRASIL",
            "10X500 DANSK",
            "10x500 EU",
            "10x500 J",
            "10x500 JF",
            "10x500 JF EU.",
            "10X500 K37",
            "10x500 M&S",
            "10x500 MMUK",
            "10X500 PUNNET",
            "10x500 S/E",
            "10X500 S/E A/C",
            "10x500 S/E BRASIL",
            "10X500 S/E CAPE",
            "10x500 S/E EU.",
            "10x500 S/E V",
            "10x500 UL",
            "10x500 UNI",
            "10x500 UNI BRASIL",
            "10x500gr",
            "11x500 CAPE",
            "11x500 s/e",
            "12X1,5 LB",
            "12x500 BRASIL",
            "12X500 S/E BRASIL",
            "12X500 UL",
            "20X20 OZ",
            "20X500",
            "4x4 LB A",
            "4x4 LB A SMRT",
            "4x4 LB P",
            "4x4 LB P SMRT",
            "4x4 LB STEVCO",
            "4X4 LB T",
            "4X4LB AMC SE",
            "4x5 LB A",
            "4x5 LB P",
            "C10GR SMRT",
            "C12 GR PANDOL",
            "C12GR",
            "C8",
            "C8 CANADA",
            "C8 EU",
            "C8 GRANEL MMUK",
            "C8 MOLLY",
            "C8 POUCH",
            "C8 SP",
            "C8 SW",
            "C8 UNIVEG UK",
            "C8 ZP",
            "C8 ZP BRASIL",
            "C8 ZP CANADA",
            "C82",
            "C82 SP",
            "C82GUSP",
            "C8BR",
            "C8G",
            "C8G POUCH",
            "C8GR SMRT",
            "C8GR UK",
            "C8J 2",
            "C8J MMUK",
            "C8J POUCH",
            "C8PL",
            "C8Z",
            "C9GR",
            "C9GR SMRT",
            "CSL",
            "M73",
            "M8 BRASIL",
            "M8 GR",
            "M8H",
            "M8J",
            "M8J BRASIL",
            "P8 BRASIL",
            "P8H GR",
            "P8J LO",
            "PUNNET 10x500 Subsole"});
			this.EmbalajeTxt.Location = new System.Drawing.Point(495, 188);
			this.EmbalajeTxt.Name = "EmbalajeTxt";
			this.EmbalajeTxt.Size = new System.Drawing.Size(153, 29);
			this.EmbalajeTxt.TabIndex = 8;
			this.EmbalajeTxt.UseSelectable = true;
			// 
			// metroLabel8
			// 
			this.metroLabel8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel8.AutoSize = true;
			this.metroLabel8.Location = new System.Drawing.Point(376, 193);
			this.metroLabel8.Name = "metroLabel8";
			this.metroLabel8.Size = new System.Drawing.Size(63, 19);
			this.metroLabel8.TabIndex = 112;
			this.metroLabel8.Text = "Embalaje";
			// 
			// PackingTxt
			// 
			this.PackingTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.PackingTxt.DropDownWidth = 220;
			this.PackingTxt.FormattingEnabled = true;
			this.PackingTxt.ItemHeight = 23;
			this.PackingTxt.Items.AddRange(new object[] {
            "FUNDO EL CARDAL",
            "FUNDO SANTA BLANCA",
            "FUNDO SAN LUIS LO MOSCOSO",
            "FUNDO TIERRA CHILENA",
            "JOHNSON FRUITS S.A."});
			this.PackingTxt.Location = new System.Drawing.Point(495, 130);
			this.PackingTxt.Name = "PackingTxt";
			this.PackingTxt.Size = new System.Drawing.Size(153, 29);
			this.PackingTxt.TabIndex = 7;
			this.PackingTxt.UseSelectable = true;
			this.PackingTxt.SelectedIndexChanged += new System.EventHandler(this.PackingTxt_SelectedIndexChanged);
			// 
			// FechaTxt
			// 
			this.FechaTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.FechaTxt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.FechaTxt.Location = new System.Drawing.Point(495, 72);
			this.FechaTxt.MinimumSize = new System.Drawing.Size(0, 29);
			this.FechaTxt.Name = "FechaTxt";
			this.FechaTxt.Size = new System.Drawing.Size(153, 29);
			this.FechaTxt.TabIndex = 6;
			// 
			// CantCajasTxt
			// 
			this.CantCajasTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			// 
			// 
			// 
			this.CantCajasTxt.CustomButton.Image = null;
			this.CantCajasTxt.CustomButton.Location = new System.Drawing.Point(125, 2);
			this.CantCajasTxt.CustomButton.Name = "";
			this.CantCajasTxt.CustomButton.Size = new System.Drawing.Size(25, 25);
			this.CantCajasTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.CantCajasTxt.CustomButton.TabIndex = 1;
			this.CantCajasTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.CantCajasTxt.CustomButton.UseSelectable = true;
			this.CantCajasTxt.CustomButton.Visible = false;
			this.CantCajasTxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
			this.CantCajasTxt.Lines = new string[0];
			this.CantCajasTxt.Location = new System.Drawing.Point(495, 14);
			this.CantCajasTxt.MaxLength = 32767;
			this.CantCajasTxt.Name = "CantCajasTxt";
			this.CantCajasTxt.PasswordChar = '\0';
			this.CantCajasTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.CantCajasTxt.SelectedText = "";
			this.CantCajasTxt.SelectionLength = 0;
			this.CantCajasTxt.SelectionStart = 0;
			this.CantCajasTxt.ShortcutsEnabled = true;
			this.CantCajasTxt.Size = new System.Drawing.Size(153, 30);
			this.CantCajasTxt.TabIndex = 5;
			this.CantCajasTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.CantCajasTxt.UseSelectable = true;
			this.CantCajasTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.CantCajasTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// CalibreTxt
			// 
			this.CalibreTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.CalibreTxt.FormattingEnabled = true;
			this.CalibreTxt.ItemHeight = 23;
			this.CalibreTxt.Items.AddRange(new object[] {
            "1000",
            "16MM",
            "17 MM",
            "17.5MM",
            "18MM",
            "22MM",
            "500",
            "700",
            "700A",
            "900",
            "L",
            "LA",
            "MA",
            "XL",
            "XXL"});
			this.CalibreTxt.Location = new System.Drawing.Point(168, 188);
			this.CalibreTxt.Name = "CalibreTxt";
			this.CalibreTxt.Size = new System.Drawing.Size(153, 29);
			this.CalibreTxt.TabIndex = 4;
			this.CalibreTxt.UseSelectable = true;
			// 
			// VariedadTxt
			// 
			this.VariedadTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.VariedadTxt.DropDownWidth = 160;
			this.VariedadTxt.FormattingEnabled = true;
			this.VariedadTxt.ItemHeight = 23;
			this.VariedadTxt.Items.AddRange(new object[] {
            "AUTUMN ROYAL",
            "CRIMSON SEEDLESS",
            "FLAME SEED LESS",
            "PRINCESS SEEDLESS",
            "RED GLOBE",
            "SUGRAONE",
            "SUGRAONE / FLAME",
            "THOMPSON SEEDLESS",
            "THOMPSON/CRIMSON"});
			this.VariedadTxt.Location = new System.Drawing.Point(168, 130);
			this.VariedadTxt.Name = "VariedadTxt";
			this.VariedadTxt.Size = new System.Drawing.Size(153, 29);
			this.VariedadTxt.TabIndex = 3;
			this.VariedadTxt.UseSelectable = true;
			// 
			// ProductorTxt
			// 
			this.ProductorTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ProductorTxt.DropDownWidth = 200;
			this.ProductorTxt.FormattingEnabled = true;
			this.ProductorTxt.ItemHeight = 23;
			this.ProductorTxt.Items.AddRange(new object[] {
            "FUNDO EL CARDAL",
            "FUNDO EL CARMEN",
            "FUNDO LA ESTRELLA",
            "FUNDO SAN DAMIAN",
            "FUNDO SAN LUIS",
            "FUNDO SANTA BLANCA",
            "FUNDO TIERRA CHILENA",
            "FUNDO TRES VERTIENTES"});
			this.ProductorTxt.Location = new System.Drawing.Point(168, 72);
			this.ProductorTxt.Name = "ProductorTxt";
			this.ProductorTxt.Size = new System.Drawing.Size(153, 29);
			this.ProductorTxt.TabIndex = 2;
			this.ProductorTxt.UseSelectable = true;
			this.ProductorTxt.SelectedIndexChanged += new System.EventHandler(this.ProductorTxt_SelectedIndexChanged);
			// 
			// NroFolioTxt
			// 
			this.NroFolioTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			// 
			// 
			// 
			this.NroFolioTxt.CustomButton.Image = null;
			this.NroFolioTxt.CustomButton.Location = new System.Drawing.Point(125, 2);
			this.NroFolioTxt.CustomButton.Name = "";
			this.NroFolioTxt.CustomButton.Size = new System.Drawing.Size(25, 25);
			this.NroFolioTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.NroFolioTxt.CustomButton.TabIndex = 1;
			this.NroFolioTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.NroFolioTxt.CustomButton.UseSelectable = true;
			this.NroFolioTxt.CustomButton.Visible = false;
			this.NroFolioTxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
			this.NroFolioTxt.Lines = new string[0];
			this.NroFolioTxt.Location = new System.Drawing.Point(168, 14);
			this.NroFolioTxt.MaxLength = 32767;
			this.NroFolioTxt.Name = "NroFolioTxt";
			this.NroFolioTxt.PasswordChar = '\0';
			this.NroFolioTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.NroFolioTxt.SelectedText = "";
			this.NroFolioTxt.SelectionLength = 0;
			this.NroFolioTxt.SelectionStart = 0;
			this.NroFolioTxt.ShortcutsEnabled = true;
			this.NroFolioTxt.Size = new System.Drawing.Size(153, 30);
			this.NroFolioTxt.TabIndex = 1;
			this.NroFolioTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NroFolioTxt.UseSelectable = true;
			this.NroFolioTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.NroFolioTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel7
			// 
			this.metroLabel7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.Location = new System.Drawing.Point(381, 135);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new System.Drawing.Size(53, 19);
			this.metroLabel7.TabIndex = 111;
			this.metroLabel7.Text = "Packing";
			// 
			// metroLabel6
			// 
			this.metroLabel6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.Location = new System.Drawing.Point(386, 77);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(43, 19);
			this.metroLabel6.TabIndex = 111;
			this.metroLabel6.Text = "Fecha";
			// 
			// metroLabel5
			// 
			this.metroLabel5.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new System.Drawing.Point(349, 19);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(116, 19);
			this.metroLabel5.TabIndex = 111;
			this.metroLabel5.Text = "Cantidad de Cajas";
			// 
			// metroLabel4
			// 
			this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.Location = new System.Drawing.Point(56, 193);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(51, 19);
			this.metroLabel4.TabIndex = 111;
			this.metroLabel4.Text = "Calibre";
			// 
			// metroLabel3
			// 
			this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(51, 135);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(60, 19);
			this.metroLabel3.TabIndex = 111;
			this.metroLabel3.Text = "Variedad";
			// 
			// metroLabel2
			// 
			this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(47, 77);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(68, 19);
			this.metroLabel2.TabIndex = 111;
			this.metroLabel2.Text = "Productor";
			// 
			// metroLabel1
			// 
			this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(43, 19);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(76, 19);
			this.metroLabel1.TabIndex = 0;
			this.metroLabel1.Text = "N° de Folio";
			// 
			// PalletCompletoTxt
			// 
			this.PalletCompletoTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.PalletCompletoTxt.AutoSize = true;
			this.PalletCompletoTxt.Checked = true;
			this.PalletCompletoTxt.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PalletCompletoTxt.DisplayStatus = false;
			this.PalletCompletoTxt.Location = new System.Drawing.Point(546, 252);
			this.PalletCompletoTxt.Name = "PalletCompletoTxt";
			this.PalletCompletoTxt.Size = new System.Drawing.Size(50, 17);
			this.PalletCompletoTxt.TabIndex = 9;
			this.PalletCompletoTxt.Tag = "";
			this.PalletCompletoTxt.Text = "On";
			this.PalletCompletoTxt.UseSelectable = true;
			this.PalletCompletoTxt.CheckedChanged += new System.EventHandler(this.PalletCompletoTxt_CheckedChanged);
			// 
			// metroPanel1
			// 
			this.metroPanel1.BackgroundImage = global::PalletHuertoUVA.Properties.Resources.logo_spsi_2018;
			this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 10;
			this.metroPanel1.Location = new System.Drawing.Point(738, 42);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(236, 167);
			this.metroPanel1.TabIndex = 111;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(988, 414);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.metroLabel9);
			this.Controls.Add(this.CopiasTxt);
			this.Controls.Add(this.metroPanel1);
			this.Controls.Add(this.metroTile1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(988, 414);
			this.MinimumSize = new System.Drawing.Size(988, 414);
			this.Name = "Form1";
			this.Text = "Pallet Huerto UVA";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Timer timer1;
		private MetroFramework.Controls.MetroTextBox CopiasTxt;
		private MetroFramework.Controls.MetroLabel metroLabel9;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private MetroFramework.Controls.MetroTextBox NroFolioTxt;
		private MetroFramework.Controls.MetroLabel metroLabel7;
		private MetroFramework.Controls.MetroLabel metroLabel6;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroComboBox PackingTxt;
		private MetroFramework.Controls.MetroDateTime FechaTxt;
		private MetroFramework.Controls.MetroTextBox CantCajasTxt;
		private MetroFramework.Controls.MetroComboBox CalibreTxt;
		private MetroFramework.Controls.MetroComboBox VariedadTxt;
		private MetroFramework.Controls.MetroComboBox ProductorTxt;
		private MetroFramework.Controls.MetroComboBox EmbalajeTxt;
		private MetroFramework.Controls.MetroLabel metroLabel8;
		private MetroFramework.Controls.MetroLabel metroLabel10;
		private MetroFramework.Controls.MetroToggle PalletCompletoTxt;
	}
}

