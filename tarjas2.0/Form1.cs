using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text.pdf;
using System.IO;

namespace tarjas2._0
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static MySqlConnection conectar, conectar2;
        //VARIABLE QUE ME ALMACENA CUANTAS CAJAS HAY
        //public static int contador = 1;
        //VARIABLE QUE ME DICE CUAL ES EL ULTIMO ID INGRESADO EN EL DATAGRIDVIEW1
        //public static int contador2 = 1;
        //VARIABLE QUE ME DICE EL NUMERO ASCII DE LA TECLA PRESIONADA EN LA CASILLA DE INGRESO DE CAJAS
        //VARIABLE QUE ALMACENA EL CODIGO DEL PALLET CUANDO SE ENCUENTRA YA DEFINIDO
        //PARA NO CREAR OTRO CODIGO SI ESTE YA SE IMPRIMIO
        public static string codigo_pallet_def = "";
        //VARIABLE QUE GUARDA LA CATEGORIA DEL PALLET
        public static string CatPallet = "";
        //VARIABLE QUE GUARDA LA EXPORTADORA DEL PALLET
        public static string ExpPallet = "";
        //VARIABLE QUE GUARDA EL ENBALAJE DEL PALLET
        public static string EmbPallet = "";
        //VARIABLE QUE GUARDA EL TIPO DE FRIO OCUPADO
        public static string FrioPallet = "";
        //VARIABLE QUE GUARDA LA ESPECIE DEL PALLET
        public static string EspPallet = "";
        //VARIABLE QUE ALMACENA LA ULTIMA FILA IMPRESA DEL DETALLE DE PALLET, SIRVE PARA SEGUIR IMPRIMIENDO
        //EN MAS PAGINAS SI ES NECESARIO
        public static int ultimafila = 0;
        //VARIABLE QUE ALMACENA SI ES NECESARIO SEGUIR IMPRIMIENDO EN MAS PÁGINAS
        public static bool maspaginas = false;
        //VARIABLE QUE ALMACENA EL TOTAL DE FILAS DEL DETALLE A IMPRIMIR
        public static int total = 0;
        //VARIABLE QUE ALMACENA EL TOTAL DE FILAS QUE SE IMPRIMEN POR PÁGINA
        public static int porpagina = 40;
        //VARIABLE QUE ALMACENA EL TOTAL DE FILAS QUE SE IMPRIMEN POR PÁGINA EN RESUMEN TARJA
        public static int porpaginaTarja = 18;
        //VARIABLE QUE ALMACENA EL PRODUCTOR DE LAS ETIQUETAS
        public static string productor_etiq = "";
        //VARIABLE QUE ALMACENA LA ESPECIE DE LAS ETIQUETAS
        public static string especie_etiq = "";
        //VARIABLE QUE ALMACENA LA VARIEDAD DE LAS ETIQUETAS
        public static string variedad_etiq = "";
        //VARIABLE QUE ALMACENA EL CALIBRE DE LAS ETIQUETAS
        public static string calibre_etiq = "";
        //VARIABLE QUE ALMACENA EL CODIGO DEL PALLET QUE SE DEVUELVE A BUSCARLO POR EL CODIGO DE UNA CAJA
        public static string codigo_pallet_desde_caja = "";
        public static int fila_caja = -1;
		public static int hora_apaga = 0;
		public static string[] codigos_embalajes = new string[999];
		public static string[] nombres_embalajes = new string[999];
		public static string[] codigos_calibres = new string[999];
		public static string[] nombres_calibres = new string[999];
		public static string[] codigos_variedades = new string[999];
		public static string[] nombres_variedades = new string[999];
        public static string codigointeligente;

        public Form1()
        {
            InitializeComponent();
        }
       
        
        private void Form1_Load(object sender, EventArgs e)
        {
			//OBTENGO LOS CODIGOS DE EMBALAJE POR EL TXT EN LA CARPETA DEL PROGRAMA
			StreamReader lectura = new StreamReader("id_embalaje.txt");
			int i = 0;
			string linea = "";
			while ((linea = lectura.ReadLine()) != null)
			{
				codigos_embalajes[i] = linea;
				i++;
			}
			lectura.Close();
			//OBTENGO LOS NOMBRES DE CADA EMBALAJE
			StreamReader lectura2 = new StreamReader("nombre_embalaje.txt");
			i = 0;
			linea = "";
			EmbalajeTxt.Items.Clear();
			while ((linea = lectura2.ReadLine()) != null)
			{
				nombres_embalajes[i] = linea;
				EmbalajeTxt.Items.Add(nombres_embalajes[i]);
				i++;
			}
			lectura2.Close();
			//OBTENGO CODIGO DE CADA CALIBRE
			StreamReader lectura3 = new StreamReader("id_calibre.txt");
			i = 0;
			linea = "";
			while ((linea = lectura3.ReadLine()) != null)
			{
				codigos_calibres[i] = linea;
				i++;
			}
			lectura3.Close();
			//OBTENGO LOS NOMBRES DE CADA CALIBRE
			StreamReader lectura4 = new StreamReader("nombre_calibre.txt");
			i = 0;
			linea = "";
			CalibreTxt.Items.Clear();
			while ((linea = lectura4.ReadLine()) != null)
			{
				nombres_calibres[i] = linea;
				CalibreTxt.Items.Add(nombres_calibres[i]);
				i++;
			}
			lectura4.Close();
			//OBTENGO CODIGO DE CADA VARIEDAD
			StreamReader lectura5 = new StreamReader("id_variedad.txt");
			i = 0;
			linea = "";
			while ((linea = lectura5.ReadLine()) != null)
			{
				codigos_variedades[i] = linea;
				i++;
			}
			lectura5.Close();
			//OBTENGO LOS NOMBRES DE CADA VARIEDAD
			StreamReader lectura6 = new StreamReader("nombre_variedad.txt");
			i = 0;
			linea = "";
			VariedadTxt.Items.Clear();
			while ((linea = lectura6.ReadLine()) != null)
			{
				nombres_variedades[i] = linea;
				VariedadTxt.Items.Add(nombres_variedades[i]);
				i++;
			}
			lectura6.Close();
		}
        static int Asc(char c)
        {
            int converted = c;
            if (converted >= 0x80)
            {
                byte[] buffer = new byte[2];
                // if the resulting conversion is 1 byte in length, just use the value
                if (System.Text.Encoding.Default.GetBytes(new char[] { c }, 0, 1, buffer, 0) == 1)
                {
                    converted = buffer[0];
                }
                else
                {
                    // byte swap bytes 1 and 2;
                    converted = buffer[0] << 16 | buffer[1];
                }
            }
            return converted;
        }
        private void CodigoCajaTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //enter2 = Asc(e.KeyChar);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
           
        }


        //FUNCION PARA CREAR LA HOJA VIRTUAL CON EL DIBUJO DE LA TARJA DETALLE A IMPRIMIR 2
        private void Print_PrintPage2(Object sender, PrintPageEventArgs e)
        {
            Barcode128 bcode = new Barcode128();
            Barcode128 bcode2 = new Barcode128();
            codigo_pallet_def = NroFolioTxt.Text;
            bcode.Code = NroFolioTxt.Text;
            bcode2.Code = codigointeligente;
            //ESTABLESCO LA CODIFICACION DEL CODIGO DE BARRAS
            bcode.GenerateChecksum = true;
            bcode.CodeType = Barcode.CODE128_UCC;
            bcode2.GenerateChecksum = true;
            bcode2.CodeType = Barcode.CODE128_UCC;
            try
            {
                Pen blackPen = new Pen(Color.Black, 3);
                e.Graphics.DrawRectangle(blackPen, new Rectangle(20, 20, 892, 394));
                e.Graphics.DrawString("IDENTIFICACIÓN PRODUCTO", new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 40, 40);
                e.Graphics.DrawString("Realizado por: Agricola San Luis de Yaquil S.A.", new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, 40, 68);
                int x = 55, y = 110;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y - 10, 445, 60));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y + 50, 445, 60));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y + 110, 445, 60));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y + 170, 445, 60));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y + 230, 445, 60));
                e.Graphics.DrawString("PRODUCTOR", new Font("Verdana", 12), Brushes.Black, x, y + 5);
                e.Graphics.DrawString("FECHA COSECHA", new Font("Verdana", 12), Brushes.Black, x, y + 65);
                e.Graphics.DrawString("VARIEDAD", new Font("Verdana", 12), Brushes.Black, x, y + 125);
                e.Graphics.DrawString("EMBALAJE", new Font("Verdana", 12), Brushes.Black, x, y + 185);
                e.Graphics.DrawString("CATEGORIA", new Font("Verdana", 12), Brushes.Black, x, y + 245);
                x = 250;
                string codigoproductor = "";
                if (ProductorTxt.Text.Equals("FUNDO EL CARDAL")) { codigoproductor = "90905"; }
                if (ProductorTxt.Text.Equals("FUNDO EL CARMEN")) { codigoproductor = "113470"; }
                if (ProductorTxt.Text.Equals("FUNDO LA ESTRELLA")) { codigoproductor = "110987"; }
                if (ProductorTxt.Text.Equals("FUNDO SAN DAMIAN")) { codigoproductor = "170590"; }
                if (ProductorTxt.Text.Equals("FUNDO SAN LUIS")) { codigoproductor = "90803"; }
                if (ProductorTxt.Text.Equals("FUNDO SANTA BLANCA")) { codigoproductor = "92463"; }
                if (ProductorTxt.Text.Equals("FUNDO TIERRA CHILENA")) { codigoproductor = "151810"; }
                if (ProductorTxt.Text.Equals("FUNDO TRES VERTIENTES")) { codigoproductor = "153770"; }
                e.Graphics.DrawString(codigoproductor, new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 5);
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 65);
                e.Graphics.DrawString(VariedadTxt.Text, new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 125);
                e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 185);
                e.Graphics.DrawString("CAT-1", new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 245);

                x = 500;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y - 10, 400, 60));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y + 50, 400, 60));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y + 110, 400, 60));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x - 10, y + 170, 400, 60));
                e.Graphics.DrawString("RECIBIDOR", new Font("Verdana", 12), Brushes.Black, x, y + 5);
                e.Graphics.DrawString("TIPO PALLET", new Font("Verdana", 12), Brushes.Black, x, y + 65);
                e.Graphics.DrawString("CALIBRE", new Font("Verdana", 12), Brushes.Black, x, y + 125);
                e.Graphics.DrawString("CAJAS", new Font("Verdana", 12), Brushes.Black, x, y + 185);
                x = 640;
                e.Graphics.DrawString("PALLET TACO", new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 65);
                e.Graphics.DrawString(CalibreTxt.Text, new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 125);
                e.Graphics.DrawString(CantCajasTxt.Text, new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, x, y + 185);

                //e.Graphics.DrawRectangle(Pens.Black, new Rectangle(590, 30, 290, 40));
                e.Graphics.DrawString("N° "+NroFolioTxt.Text, new Font("Verdana", 18, FontStyle.Bold), Brushes.Black, 600, 25);
                e.Graphics.DrawImage(bcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White), 560, 53, 330, 40);
                x = 500;
                e.Graphics.DrawImage(bcode2.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White), x + 20, y + 237, 330, 40);
                e.Graphics.DrawString(codigointeligente, new Font("Verdana", 12), Brushes.Black, x + 40, y + 280);

                e.HasMorePages = maspaginas;
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error al imprimir detalle de tarja. Error L175", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    }
        //FUNCION PARA CREAR LA HOJA VIRTUAL CON EL DIBUJO DE LA TARJA DETALLE A IMPRIMIR 1 
        private void Print_PrintPage(Object sender, PrintPageEventArgs e)
        {
            //ESTABLESCO LAS FUENTES A OCUPAR DENTRO DEL DISEÑO DE LA HOJA DEL DETALLE DE TARJA
            Font desFont = new Font("Verdana", 10, FontStyle.Bold);
            Font desFont2 = new Font("Verdana", 10);
            Font desFont3 = new Font("Verdana", 6);
            Font desFont4 = new Font("Verdana", 14, FontStyle.Bold);
			codigointeligente = "U";
            Barcode128 bcode = new Barcode128();
			Barcode128 bcode2 = new Barcode128();
			codigo_pallet_def = NroFolioTxt.Text;
			bcode.Code = NroFolioTxt.Text;
			//genero codigo inteligente
			if (PalletCompletoTxt.Checked.Equals(true)) { codigointeligente += "0"; } else { codigointeligente += "1"; }
			codigointeligente += NroFolioTxt.Text.Substring(NroFolioTxt.Text.Length - 4);

			if (ProductorTxt.Text.Equals("FUNDO EL CARDAL")) { codigointeligente += "1"; }
			if (ProductorTxt.Text.Equals("FUNDO EL CARMEN")) { codigointeligente += "2"; }
			if (ProductorTxt.Text.Equals("FUNDO LA ESTRELLA")) { codigointeligente += "3"; }
			if (ProductorTxt.Text.Equals("FUNDO SAN DAMIAN")) { codigointeligente += "4"; }
			if (ProductorTxt.Text.Equals("FUNDO SAN LUIS")) { codigointeligente += "5"; }
			if (ProductorTxt.Text.Equals("FUNDO SANTA BLANCA")) { codigointeligente += "6"; }
			if (ProductorTxt.Text.Equals("FUNDO TIERRA CHILENA")) { codigointeligente += "7"; }
			if (ProductorTxt.Text.Equals("FUNDO TRES VERTIENTES")) { codigointeligente += "8"; }

			codigointeligente += ObtenerCodigoVariedad(VariedadTxt.Text);
			//if (VariedadTxt.Text.Equals("AUTUMN ROYAL")) { codigointeligente += "0"; }
			//if (VariedadTxt.Text.Equals("CRIMSON SEEDLESS")) { codigointeligente += "1"; }
			//if (VariedadTxt.Text.Equals("FLAME SEED LESS")) { codigointeligente += "2"; }
			//if (VariedadTxt.Text.Equals("PRINCESS SEEDLESS")) { codigointeligente += "3"; }
			//if (VariedadTxt.Text.Equals("RED GLOBE")) { codigointeligente += "4"; }
			//if (VariedadTxt.Text.Equals("SUGRAONE")) { codigointeligente += "5"; }
			//if (VariedadTxt.Text.Equals("SUGRAONE / FLAME")) { codigointeligente += "6"; }
			//if (VariedadTxt.Text.Equals("THOMPSON SEEDLESS")) { codigointeligente += "7"; }
			//if (VariedadTxt.Text.Equals("THOMPSON/CRIMSON")) { codigointeligente += "8"; }

			codigointeligente += ObtenerCodigoCalibre(CalibreTxt.Text);
			//if (CalibreTxt.Text.Equals("500")) { codigointeligente += "03"; }
			//if (CalibreTxt.Text.Equals("700")) { codigointeligente += "04"; }
			//if (CalibreTxt.Text.Equals("900")) { codigointeligente += "05"; }
			//if (CalibreTxt.Text.Equals("1000")) { codigointeligente += "06"; }
			//if (CalibreTxt.Text.Equals("L")) { codigointeligente += "09"; }
			//if (CalibreTxt.Text.Equals("XXL")) { codigointeligente += "16"; }
			//if (CalibreTxt.Text.Equals("18MM")) { codigointeligente += "21"; }
			//if (CalibreTxt.Text.Equals("16MM")) { codigointeligente += "22"; }
			//if (CalibreTxt.Text.Equals("17.5MM")) { codigointeligente += "35"; }
			//if (CalibreTxt.Text.Equals("17 MM")) { codigointeligente += "37"; }
			//if (CalibreTxt.Text.Equals("22MM")) { codigointeligente += "44"; }
			//if (CalibreTxt.Text.Equals("MA")) { codigointeligente += "45"; }
			//if (CalibreTxt.Text.Equals("700A")) { codigointeligente += "47"; }
			//if (CalibreTxt.Text.Equals("LA")) { codigointeligente += "48"; }
			//if (CalibreTxt.Text.Equals("XL")) { codigointeligente += "49"; }

			if (CantCajasTxt.Text.Length.Equals(1)) { codigointeligente += "00" + CantCajasTxt.Text; }
			if (CantCajasTxt.Text.Length.Equals(2)) { codigointeligente += "0" + CantCajasTxt.Text; }
			if (CantCajasTxt.Text.Length.Equals(3)) { codigointeligente += CantCajasTxt.Text; }
			codigointeligente += DateTime.Now.ToString("yyyyMMdd");

			if (PackingTxt.Text.Equals("FUNDO EL CARDAL")) { codigointeligente += "1"; }
			if (PackingTxt.Text.Equals("FUNDO SANTA BLANCA")) { codigointeligente += "2"; }
			if (PackingTxt.Text.Equals("FUNDO SAN LUIS LO MOSCOSO")) { codigointeligente += "3"; }
			if (PackingTxt.Text.Equals("FUNDO TIERRA CHILENA")) { codigointeligente += "4"; }
			if (PackingTxt.Text.Equals("JOHNSON FRUITS S.A.")) { codigointeligente += "5"; }

			codigointeligente += ObtenerCodigoEmbalaje(EmbalajeTxt.Text);
			//if (EmbalajeTxt.Text.Equals("08KPM")) { codigointeligente += "066"; }
			//if (EmbalajeTxt.Text.Equals("10x2 LB")) { codigointeligente += "179"; }
			//if (EmbalajeTxt.Text.Equals("10x500")) { codigointeligente += "031"; }
			//if (EmbalajeTxt.Text.Equals("10x500 AN")) { codigointeligente += "125"; }
			//if (EmbalajeTxt.Text.Equals("10x500 AS")) { codigointeligente += "122"; }
			//if (EmbalajeTxt.Text.Equals("10x500 ASA")) { codigointeligente += "121"; }
			//if (EmbalajeTxt.Text.Equals("10x500 BELGICA")) { codigointeligente += "070"; }
			//if (EmbalajeTxt.Text.Equals("10X500 BI")) { codigointeligente += "021"; }
			//if (EmbalajeTxt.Text.Equals("10x500 BRASIL")) { codigointeligente += "130"; }
			//if (EmbalajeTxt.Text.Equals("10x500 CAPE")) { codigointeligente += "139"; }
			//if (EmbalajeTxt.Text.Equals("10x500 COP BRASIL")) { codigointeligente += "067"; }
			//if (EmbalajeTxt.Text.Equals("10X500 DANSK")) { codigointeligente += "182"; }
			//if (EmbalajeTxt.Text.Equals("10x500 EU")) { codigointeligente += "157"; }
			//if (EmbalajeTxt.Text.Equals("10x500 J")) { codigointeligente += "091"; }
			//if (EmbalajeTxt.Text.Equals("10x500 JF")) { codigointeligente += "060"; }
			//if (EmbalajeTxt.Text.Equals("10x500 JF EU.")) { codigointeligente += "097"; }
			//if (EmbalajeTxt.Text.Equals("10X500 K37")) { codigointeligente += "160"; }
			//if (EmbalajeTxt.Text.Equals("10x500 M&S")) { codigointeligente += "025"; }
			//if (EmbalajeTxt.Text.Equals("10x500 MMUK")) { codigointeligente += "098"; }
			//if (EmbalajeTxt.Text.Equals("10X500 PUNNET")) { codigointeligente += "118"; }
			//if (EmbalajeTxt.Text.Equals("10x500 S/E")) { codigointeligente += "090"; }
			//if (EmbalajeTxt.Text.Equals("10X500 S/E A/C")) { codigointeligente += "119"; }
			//if (EmbalajeTxt.Text.Equals("10x500 S/E BRASIL")) { codigointeligente += "136"; }
			//if (EmbalajeTxt.Text.Equals("10X500 S/E CAPE")) { codigointeligente += "143"; }
			//if (EmbalajeTxt.Text.Equals("10x500 S/E EU.")) { codigointeligente += "096"; }
			//if (EmbalajeTxt.Text.Equals("10x500 S/E V")) { codigointeligente += "124"; }
			//if (EmbalajeTxt.Text.Equals("10x500 UL")) { codigointeligente += "155"; }
			//if (EmbalajeTxt.Text.Equals("10x500 UNI")) { codigointeligente += "073"; }
			//if (EmbalajeTxt.Text.Equals("10x500 UNI BRASIL")) { codigointeligente += "068"; }
			//if (EmbalajeTxt.Text.Equals("10x500gr")) { codigointeligente += "170"; }
			//if (EmbalajeTxt.Text.Equals("11x500 CAPE")) { codigointeligente += "089"; }
			//if (EmbalajeTxt.Text.Equals("11x500 s/e")) { codigointeligente += "054"; }
			//if (EmbalajeTxt.Text.Equals("12X1,5 LB")) { codigointeligente += "178"; }
			//if (EmbalajeTxt.Text.Equals("12x500 BRASIL")) { codigointeligente += "142"; }
			//if (EmbalajeTxt.Text.Equals("12X500 S/E BRASIL")) { codigointeligente += "147"; }
			//if (EmbalajeTxt.Text.Equals("12X500 UL")) { codigointeligente += "158"; }
			//if (EmbalajeTxt.Text.Equals("20X20 OZ")) { codigointeligente += "006"; }
			//if (EmbalajeTxt.Text.Equals("20X500")) { codigointeligente += "173"; }
			//if (EmbalajeTxt.Text.Equals("4x4 LB A")) { codigointeligente += "123"; }
			//if (EmbalajeTxt.Text.Equals("4x4 LB A SMRT")) { codigointeligente += "168"; }
			//if (EmbalajeTxt.Text.Equals("4x4 LB P")) { codigointeligente += "128"; }
			//if (EmbalajeTxt.Text.Equals("4x4 LB P SMRT")) { codigointeligente += "169"; }
			//if (EmbalajeTxt.Text.Equals("4x4 LB STEVCO")) { codigointeligente += "063"; }
			//if (EmbalajeTxt.Text.Equals("4X4 LB T")) { codigointeligente += "162"; }
			//if (EmbalajeTxt.Text.Equals("4X4LB AMC SE")) { codigointeligente += "094"; }
			//if (EmbalajeTxt.Text.Equals("4x5 LB A")) { codigointeligente += "133"; }
			//if (EmbalajeTxt.Text.Equals("4x5 LB P")) { codigointeligente += "132"; }
			//if (EmbalajeTxt.Text.Equals("C10GR SMRT")) { codigointeligente += "164"; }
			//if (EmbalajeTxt.Text.Equals("C12 GR PANDOL")) { codigointeligente += "172"; }
			//if (EmbalajeTxt.Text.Equals("C12GR")) { codigointeligente += "171"; }
			//if (EmbalajeTxt.Text.Equals("C8")) { codigointeligente += "022"; }
			//if (EmbalajeTxt.Text.Equals("C8 CANADA")) { codigointeligente += "120"; }
			//if (EmbalajeTxt.Text.Equals("C8 EU")) { codigointeligente += "137"; }
			//if (EmbalajeTxt.Text.Equals("C8 GRANEL MMUK")) { codigointeligente += "149"; }
			//if (EmbalajeTxt.Text.Equals("C8 MOLLY")) { codigointeligente += "056"; }
			//if (EmbalajeTxt.Text.Equals("C8 POUCH")) { codigointeligente += "017"; }
			//if (EmbalajeTxt.Text.Equals("C8 SP")) { codigointeligente += "116"; }
			//if (EmbalajeTxt.Text.Equals("C8 SW")) { codigointeligente += "161"; }
			//if (EmbalajeTxt.Text.Equals("C8 UNIVEG UK")) { codigointeligente += "140"; }
			//if (EmbalajeTxt.Text.Equals("C8 ZP")) { codigointeligente += "117"; }
			//if (EmbalajeTxt.Text.Equals("C8 ZP BRASIL")) { codigointeligente += "126"; }
			//if (EmbalajeTxt.Text.Equals("C8 ZP CANADA")) { codigointeligente += "127"; }
			//if (EmbalajeTxt.Text.Equals("C82")) { codigointeligente += "061"; }
			//if (EmbalajeTxt.Text.Equals("C82 SP")) { codigointeligente += "135"; }
			//if (EmbalajeTxt.Text.Equals("C82GUSP")) { codigointeligente += "101"; }
			//if (EmbalajeTxt.Text.Equals("C8BR")) { codigointeligente += "181"; }
			//if (EmbalajeTxt.Text.Equals("C8G")) { codigointeligente += "018"; }
			//if (EmbalajeTxt.Text.Equals("C8G POUCH")) { codigointeligente += "019"; }
			//if (EmbalajeTxt.Text.Equals("C8GR SMRT")) { codigointeligente += "163"; }
			//if (EmbalajeTxt.Text.Equals("C8GR UK")) { codigointeligente += "166"; }
			//if (EmbalajeTxt.Text.Equals("C8J 2")) { codigointeligente += "100"; }
			//if (EmbalajeTxt.Text.Equals("C8J MMUK")) { codigointeligente += "112"; }
			//if (EmbalajeTxt.Text.Equals("C8J POUCH")) { codigointeligente += "064"; }
			//if (EmbalajeTxt.Text.Equals("C8PL")) { codigointeligente += "029"; }
			//if (EmbalajeTxt.Text.Equals("C8Z")) { codigointeligente += "004"; }
			//if (EmbalajeTxt.Text.Equals("C9GR")) { codigointeligente += "165"; }
			//if (EmbalajeTxt.Text.Equals("C9GR SMRT")) { codigointeligente += "167"; }
			//if (EmbalajeTxt.Text.Equals("CSL")) { codigointeligente += "156"; }
			//if (EmbalajeTxt.Text.Equals("M73")) { codigointeligente += "180"; }
			//if (EmbalajeTxt.Text.Equals("M8 BRASIL")) { codigointeligente += "145"; }
			//if (EmbalajeTxt.Text.Equals("M8 GR")) { codigointeligente += "183"; }
			//if (EmbalajeTxt.Text.Equals("M8H")) { codigointeligente += "016"; }
			//if (EmbalajeTxt.Text.Equals("M8J")) { codigointeligente += "024"; }
			//if (EmbalajeTxt.Text.Equals("M8J BRASIL")) { codigointeligente += "148"; }
			//if (EmbalajeTxt.Text.Equals("P8 BRASIL")) { codigointeligente += "146"; }
			//if (EmbalajeTxt.Text.Equals("P8H GR")) { codigointeligente += "184"; }
			//if (EmbalajeTxt.Text.Equals("P8J LO")) { codigointeligente += "150"; }
			//if (EmbalajeTxt.Text.Equals("PUNNET 10x500 Subsole")) { codigointeligente += "138"; }
			
			
			//codigointeligente = "U00011000120201901146000";//por mientras
			//fin generar codigo inteligente
			bcode2.Code = codigointeligente;
			//ESTABLESCO LA CODIFICACION DEL CODIGO DE BARRAS
			bcode.GenerateChecksum = true;
            bcode.CodeType = Barcode.CODE128_UCC;
			bcode2.GenerateChecksum = true;
			bcode2.CodeType = Barcode.CODE128_UCC;
			try
			{
				//Image img;
				Bitmap bmpimg = new Bitmap(360, 105);
                Graphics gra = Graphics.FromImage(bmpimg);
                gra.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                //cargo logo
                Image logo;
                logo = Image.FromFile("logo_negro.jpg");
                e.Graphics.DrawImage(logo, 127, 15, 163, 80);

                e.Graphics.DrawLine(Pens.Black, new Point(20, 100), new Point(380, 100));
                Font desFont5 = new Font("Verdana", 42, FontStyle.Bold);
                Font desFont6 = new Font("Verdana", 12, FontStyle.Bold);
                Font desFont7 = new Font("Verdana", 12);
                e.Graphics.DrawString("UVA DE MESA", new Font("Verdana", 32, FontStyle.Bold), Brushes.Black, 17, 90);

				e.Graphics.DrawImage(bcode2.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White), 28, 142, 330, 40);
				e.Graphics.DrawString(codigointeligente, new Font("Verdana", 12), Brushes.Black, 55, 180);

				e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 200, 350, 80));
				if (VariedadTxt.Text.Length.Equals(8))
				{
					e.Graphics.DrawString(VariedadTxt.Text, new Font("Verdana", 39, FontStyle.Bold), Brushes.Black, 18, 204);
				}
				if (VariedadTxt.Text.Length.Equals(9))
				{
					e.Graphics.DrawString(VariedadTxt.Text, new Font("Verdana", 39, FontStyle.Bold), Brushes.Black, 15, 204);
				}
				if (VariedadTxt.Text.Length.Equals(12))
				{
					e.Graphics.DrawString(VariedadTxt.Text, new Font("Verdana", 28, FontStyle.Bold), Brushes.Black, 15, 208);
				}
				if (VariedadTxt.Text.Length.Equals(15))
				{
					e.Graphics.DrawString(VariedadTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 15, 210);
				}
				if (VariedadTxt.Text.Length.Equals(16))
				{
					e.Graphics.DrawString(VariedadTxt.Text, new Font("Verdana", 20, FontStyle.Bold), Brushes.Black, 16, 216);
				}
				if (VariedadTxt.Text.Length.Equals(17))
				{
					e.Graphics.DrawString(VariedadTxt.Text, new Font("Verdana", 20, FontStyle.Bold), Brushes.Black, 16, 220);
				}

				e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 280, 350, 30));
                e.Graphics.DrawString("PRODUCTOR", desFont6, Brushes.Black, 30, 285);
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 310, 350, 120));

				e.Graphics.DrawString("AGRICOLA SAN LUIS DE YAQUIL S.A.", desFont7, Brushes.Black, 30, 315);
				e.Graphics.DrawString(ProductorTxt.Text, desFont7, Brushes.Black, 30, 335);
				if (ProductorTxt.Text.Equals("FUNDO EL CARDAL"))
				{
					e.Graphics.DrawString("COLCHAGUA - NANCAGUA", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 90905", desFont7, Brushes.Black, 30, 395);
				}
				if (ProductorTxt.Text.Equals("FUNDO SANTA BLANCA"))
				{
					e.Graphics.DrawString("COLCHAGUA - CHEPICA", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 92463", desFont7, Brushes.Black, 30, 395);
				}
				if (ProductorTxt.Text.Equals("FUNDO SAN LUIS"))
				{
					e.Graphics.DrawString("COLCHAGUA - PLACILLA", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 90803", desFont7, Brushes.Black, 30, 395);
				}
				if (ProductorTxt.Text.Equals("FUNDO TIERRA CHILENA"))
				{
					e.Graphics.DrawString("COLCHAGUA - NANCAGUA", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 151810", desFont7, Brushes.Black, 30, 395);
				}
				if (ProductorTxt.Text.Equals("FUNDO EL CARMEN"))
				{
					e.Graphics.DrawString("COLCHAGUA - NANCAGUA", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 113470", desFont7, Brushes.Black, 30, 395);
				}
				if (ProductorTxt.Text.Equals("FUNDO LA ESTRELLA"))
				{
					e.Graphics.DrawString("CURICO - TENO", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VII - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 110987", desFont7, Brushes.Black, 30, 395);
				}
				if (ProductorTxt.Text.Equals("FUNDO SAN DAMIAN"))
				{
					e.Graphics.DrawString("COLCHAGUA - NANCAGUA", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 170590", desFont7, Brushes.Black, 30, 395);
				}
				if (ProductorTxt.Text.Equals("FUNDO TRES VERTIENTES"))
				{
					e.Graphics.DrawString("COLCHAGUA - PLACILLA", desFont7, Brushes.Black, 30, 355);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 375);
					e.Graphics.DrawString("CSG : 153770", desFont7, Brushes.Black, 30, 395);
				}
				e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 430, 350, 30));
                e.Graphics.DrawString("PACKING", desFont6, Brushes.Black, 30, 435);
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 460, 350, 120));
                e.Graphics.DrawString(PackingTxt.Text, desFont7, Brushes.Black, 30, 480);
				if (PackingTxt.Text.Equals("AURORA AUSTRALIS S.A."))
				{
					e.Graphics.DrawString("TENO - CURICO", desFont7, Brushes.Black, 30, 500);
					e.Graphics.DrawString("REGION VII - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 520);
					e.Graphics.DrawString("CSP : 110083", desFont7, Brushes.Black, 30, 540);
				}
				if (PackingTxt.Text.Equals("FUNDO SANTA BLANCA"))
				{
					e.Graphics.DrawString("COLCHAGUA - CHEPICA", desFont7, Brushes.Black, 30, 500);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 520);
					e.Graphics.DrawString("CSP : 111092", desFont7, Brushes.Black, 30, 540);
				}
				if (PackingTxt.Text.Equals("FUNDO EL CARDAL"))
				{
					e.Graphics.DrawString("COLCHAGUA - NANCAGUA", desFont7, Brushes.Black, 30, 500);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 520);
					e.Graphics.DrawString("CSP : 111093", desFont7, Brushes.Black, 30, 540);
				}
				if (PackingTxt.Text.Equals("FUNDO SAN LUIS LO MOSCOSO"))
				{
					e.Graphics.DrawString("COLCHAGUA - PLACILLA", desFont7, Brushes.Black, 30, 500);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 520);
					e.Graphics.DrawString("CSP : 111095", desFont7, Brushes.Black, 30, 540);
				}
				if (PackingTxt.Text.Equals("EXP. ANDINEXIA S.A."))
				{
					e.Graphics.DrawString("TENO - CURICO", desFont7, Brushes.Black, 30, 500);
					e.Graphics.DrawString("REGION VII - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 520);
					e.Graphics.DrawString("CSP : 118292", desFont7, Brushes.Black, 30, 540);
				}
				if (PackingTxt.Text.Equals("FUNDO TIERRA CHILENA"))
				{
					e.Graphics.DrawString("COLCHAGUA - NANCAGUA", desFont7, Brushes.Black, 30, 500);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 520);
					e.Graphics.DrawString("CSP : 169744", desFont7, Brushes.Black, 30, 540);
				}
				if (PackingTxt.Text.Equals("JOHNSON FRUITS S.A."))
				{
					e.Graphics.DrawString("COLCHAGUA - CHIMBARONGO", desFont7, Brushes.Black, 30, 500);
					e.Graphics.DrawString("REGION VI - REPUBLIC OF CHILE", desFont7, Brushes.Black, 30, 520);
					e.Graphics.DrawString("CSP : 99409", desFont7, Brushes.Black, 30, 540);
				}
				

                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 580, 121, 140));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(141, 580, 107, 140));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(248, 580, 122, 140));
                e.Graphics.DrawString("SIZE", desFont6, Brushes.Black, 60, 582);
                e.Graphics.DrawString("PACKAGE", desFont6, Brushes.Black, 150, 582);
                e.Graphics.DrawString("CAJAS", desFont6, Brushes.Black, 276, 582);

				// el maximo de caracteres es 6
				if (CalibreTxt.Text.Length.Equals(1))
				{
					e.Graphics.DrawString(CalibreTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 68, 635);
				}
				if (CalibreTxt.Text.Length.Equals(2))
				{
					e.Graphics.DrawString(CalibreTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 51, 635);
				}
				if (CalibreTxt.Text.Length.Equals(3))
				{
					e.Graphics.DrawString(CalibreTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 42, 635);
				}
				if (CalibreTxt.Text.Length.Equals(4))
				{
					e.Graphics.DrawString(CalibreTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 20, 635);
				}
				if (CalibreTxt.Text.Length.Equals(5))
				{
					e.Graphics.DrawString(CalibreTxt.Text, new Font("Verdana", 22, FontStyle.Bold), Brushes.Black, 20, 635);
				}
				if (CalibreTxt.Text.Length.Equals(6))
				{
					e.Graphics.DrawString(CalibreTxt.Text, new Font("Verdana", 19, FontStyle.Bold), Brushes.Black, 17, 638);
				}
				//imprimir embalaje
				if (EmbalajeTxt.Text.Length.Equals(2))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 153, 635);
				}
				if (EmbalajeTxt.Text.Length.Equals(3))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 24, FontStyle.Bold), Brushes.Black, 148, 635);
				}
				if (EmbalajeTxt.Text.Length.Equals(4))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 24, FontStyle.Bold), Brushes.Black, 139, 635);
				}
				if (EmbalajeTxt.Text.Length.Equals(5))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 19, FontStyle.Bold), Brushes.Black, 139, 638);
				}
				if (EmbalajeTxt.Text.Length.Equals(6))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 17, FontStyle.Bold), Brushes.Black, 138, 640);
				}
				if (EmbalajeTxt.Text.Length.Equals(7))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 138, 644);
				}
				if (EmbalajeTxt.Text.Length.Equals(8))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, 141, 650);
				}
				if (EmbalajeTxt.Text.Length.Equals(9))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text, new Font("Verdana", 11, FontStyle.Bold), Brushes.Black, 141, 650);
				}
				if (EmbalajeTxt.Text.Length.Equals(10))
				{
					int indice = DondeEspacio(EmbalajeTxt.Text);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 630);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(indice+1), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 655);
				}
				if (EmbalajeTxt.Text.Length.Equals(11))
				{
					int indice = DondeEspacio(EmbalajeTxt.Text);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 630);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(indice + 1), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 655);
				}
				if (EmbalajeTxt.Text.Length.Equals(12))
				{
					int indice = DondeEspacio(EmbalajeTxt.Text);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 630);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(indice + 1), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 655);
				}
				if (EmbalajeTxt.Text.Length.Equals(13))
				{
					int indice = DondeEspacio(EmbalajeTxt.Text);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 630);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(indice + 1), new Font("Verdana", 16, FontStyle.Bold), Brushes.Black, 141, 655);
				}
				if (EmbalajeTxt.Text.Length.Equals(14))
				{
					int indice = DondeEspacio(EmbalajeTxt.Text);
					if (indice > 6)
					{
						e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 11, FontStyle.Bold), Brushes.Black, 141, 630);
					}
					else
					{
						e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 141, 630);
					}
					
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(indice + 1), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 141, 655);
				}
				if (EmbalajeTxt.Text.Length.Equals(15))
				{
					int indice = DondeEspacio(EmbalajeTxt.Text);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 141, 630);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(indice + 1), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 141, 655);
				}
				if (EmbalajeTxt.Text.Length.Equals(17))
				{
					int indice = DondeEspacio(EmbalajeTxt.Text);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, indice), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 141, 630);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(indice + 1), new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, 141, 655);
				}
				if (EmbalajeTxt.Text.Length.Equals(21))
				{
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(0, 7), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 145, 620);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(8, 6), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 145, 645);
					e.Graphics.DrawString(EmbalajeTxt.Text.Substring(15), new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 145, 670);
				}
				 
				//imprimir numero de cajas

				if (CantCajasTxt.Text.Length.Equals(1))
				{
					e.Graphics.DrawString(CantCajasTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 290, 635);
				}
				if (CantCajasTxt.Text.Length.Equals(2))
				{
					e.Graphics.DrawString(CantCajasTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 283, 635);
				}
				if (CantCajasTxt.Text.Length.Equals(3))
				{
					e.Graphics.DrawString(CantCajasTxt.Text, new Font("Verdana", 25, FontStyle.Bold), Brushes.Black, 270, 635);
				}

				//imprimir numero de folio y el codigo de barras
				e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 720, 350, 180));
				e.Graphics.DrawString(NroFolioTxt.Text, new Font("Verdana", 30, FontStyle.Bold), Brushes.Black, 20, 735);
				
				
				e.Graphics.DrawImage(bcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White), 28, 800, 330, 60);

                e.HasMorePages = maspaginas;
			}
			catch(Exception)
			{
				MetroFramework.MetroMessageBox.Show(this, "Error al imprimir detalle de tarja. Error L945", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
	}
		private int DondeEspacio(string cadena)
		{
			int retorno = 0;
			int i = 0;
			while (i < cadena.Length)
			{
				if(cadena.Substring(i,1).Equals(" ") && i>5)
				{
					retorno = i;
					i = 1000;
				}
				i++;
			}
			return retorno;
		}
        
        private void MetroTile1_Click(object sender, EventArgs e)
        {
           if(NroFolioTxt.Text.Length > 0 && ProductorTxt.Text.Length > 0 && VariedadTxt.Text.Length > 0 && CalibreTxt.Text.Length > 0 && CantCajasTxt.Text.Length > 0 && FechaTxt.Text.Length > 0 && PackingTxt.Text.Length > 0)
			{
				PrinterSettings prtSettings = new PrinterSettings();
                PrinterSettings prtSettings2 = new PrinterSettings();
                prtSettings.DefaultPageSettings.Landscape = false;//										384
				prtSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 414, 912);
                prtSettings2.DefaultPageSettings.Landscape = true;//										384
                prtSettings2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 414, 912);
                PrintDocument prtDoc = new System.Drawing.Printing.PrintDocument();
                PrintDocument prtDoc2 = new System.Drawing.Printing.PrintDocument();
                prtDoc.PrintPage += new PrintPageEventHandler(Print_PrintPage);
                prtDoc2.PrintPage += new PrintPageEventHandler(Print_PrintPage2);
                //la configuración a usar en la impresión
                //por defecto se deja la impresora predeterminada a ocupar
                prtDoc.PrinterSettings = prtSettings;
                prtDoc2.PrinterSettings = prtSettings2;
                int i = 0;
				int copias = Convert.ToInt32(CopiasTxt.Text);
				while (i < copias)
				{
					prtDoc.Print();
                    i++;
				}
                i = 0;
                while (i < copias)
                {
                    prtDoc2.Print();
                    i++;
                }
            }
			else
			{
				MetroFramework.MetroMessageBox.Show(this, "Favor de rellenar todos los campos solicitados.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
            
					
		}

		private void PalletCompletoTxt_CheckedChanged(object sender, EventArgs e)
		{
			if (NroFolioTxt.Text.Length > 0)
			{
				if (PalletCompletoTxt.Checked.Equals(true))
				{
					NroFolioTxt.Text = "G" + NroFolioTxt.Text.Substring(1);
				}
				else
				{
					NroFolioTxt.Text = "T" + NroFolioTxt.Text.Substring(1);
				}
			}
			
		}

		private void ProductorTxt_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

		private void PackingTxt_SelectedIndexChanged(object sender, EventArgs e)
		{
			/*FUNDO EL CARDAL
			FUNDO SAN LUIS LO MOSCOSO
			FUNDO SANTA BLANCA
			FUNDO TIERRA CHILENA*/
			if (NroFolioTxt.Text.Length > 0)
			{
				if (PackingTxt.Text.Equals("FUNDO EL CARDAL"))
				{
					NroFolioTxt.Text = NroFolioTxt.Text.Substring(0, 6) + "1" + NroFolioTxt.Text.Substring(7);
				}
				if (PackingTxt.Text.Equals("FUNDO SANTA BLANCA"))
				{
					NroFolioTxt.Text = NroFolioTxt.Text.Substring(0, 6) + "2" + NroFolioTxt.Text.Substring(7);
				}
				if (PackingTxt.Text.Equals("FUNDO SAN LUIS LO MOSCOSO"))
				{
					NroFolioTxt.Text = NroFolioTxt.Text.Substring(0, 6) + "3" + NroFolioTxt.Text.Substring(7);
				}
				if (PackingTxt.Text.Equals("FUNDO TIERRA CHILENA"))
				{
					NroFolioTxt.Text = NroFolioTxt.Text.Substring(0, 6) + "4" + NroFolioTxt.Text.Substring(7);
				}
				if(PackingTxt.Text.Equals("JOHNSON FRUITS S.A."))
				{
					NroFolioTxt.Text = NroFolioTxt.Text.Substring(0, 6) + "5" + NroFolioTxt.Text.Substring(7);
				}

			}
		}

		public string ObtenerCodigoEmbalaje(string embalaje)
		{
			string codigo_de_embalaje = "";
			int i = 0;
			while (i < 999)
			{
				if (nombres_embalajes[i].Equals(embalaje))
				{
					codigo_de_embalaje = codigos_embalajes[i];
					if (codigo_de_embalaje.Length.Equals(1)) { codigo_de_embalaje = "00" + codigo_de_embalaje; }
					if (codigo_de_embalaje.Length.Equals(2)) { codigo_de_embalaje = "0" + codigo_de_embalaje; }
					i = 1000;
				}
				i++;
			}
			return codigo_de_embalaje;
		}
		public string ObtenerCodigoCalibre(string calibre)
		{
			string codigo_de_calibre = "";
			int i = 0;
			while (i < 999)
			{
				if (nombres_calibres[i].Equals(calibre))
				{
					codigo_de_calibre = codigos_calibres[i];
					if (codigo_de_calibre.Length.Equals(1)) { codigo_de_calibre = "0" + codigo_de_calibre; }
					i = 1000;
				}
				i++;
			}
			return codigo_de_calibre;
		}
		public string ObtenerCodigoVariedad(string variedad)
		{
			string codigo_de_variedad = "";
			int i = 0;
			while (i < 999)
			{
				if (nombres_variedades[i].Equals(variedad))
				{
					codigo_de_variedad = codigos_variedades[i];
					if (codigo_de_variedad.Length.Equals(1)) { codigo_de_variedad = "0" + codigo_de_variedad; }
					i = 1000;
				}
				i++;
			}
			return codigo_de_variedad;
		}

	}
}
