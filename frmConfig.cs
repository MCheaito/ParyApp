using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using System.Globalization;
using Nour.Athan.Lib;
//using Gen.Config.Manager;
using System.Reflection;

namespace PrayerApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    /// 
	public class frmConfig : System.Windows.Forms.Form
    {
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

        #region variables
        #region variables
        //private DataSet dsCities = new DataSet();

        //private int month = 0;
        //private int day = 0;
        //private int year = 0;

        //private double lat = 0.0;
        //private double lng = 0.0;
        //private int dtime = 0;
        //		private int m_lat = 0; 
        //		private int m_lng = 0; 
        //		private int m_dtime = 0;      



        //private double r_to_d = 180 / Math.PI;      
        //private double d_to_r = (Math.PI/180 ); 

        //private double convday = 4.16666666666667E-02;      
        //		private double convhour = 6.66666666666667E-02;      
        //		private double convmin = 1.66666666666667E-02;      
        //		private double convsec = 2.77777777777778E-04;      
        //private double convcircle = 2.77777777777778E-03;      
        //private double SUNSET = -.833333333333333;      
        //		private double CIVIL = -6.0;      
        //		private double NAUTICAL = -12.0;      
        //		private double ASTRONOMICAL = -18.0;      

        //		var X = 0,Y = 0; // Netscape bug 

        //private int  maxDay = 31;

        //private double SunDia = 0.53;		// Sunradius degrees
        //private double AirRefr = 34.0/60.0; // athmospheric refraction degrees //
        #endregion

//        private Config config;
        private Object config;
        private PrayerTime prayer;
        private MainApp mainContainer;
        #endregion

        #region  var user
        private System.Windows.Forms.TextBox txtTimeZone;
		private System.Windows.Forms.GroupBox lats;
		private System.Windows.Forms.TextBox lngm;
		private System.Windows.Forms.RadioButton North;
		private System.Windows.Forms.RadioButton South;
		private System.Windows.Forms.RadioButton East;
		private System.Windows.Forms.RadioButton West;
		private System.Windows.Forms.TextBox lngd;
		private System.Windows.Forms.TextBox latd;
		private System.Windows.Forms.TextBox latm;
		private System.Windows.Forms.GroupBox lngs;
        private System.Windows.Forms.Button btDoIt;
        private Label label3;
        private TextBox txtTimerBySec;
        private Button button1;
        private Label label7;

        //private string [] TimeZone = new string[] {
        //                                              "GMT-12",
        //                                              "GMT-11",              
        //                                              "GMT-10",              
        //                                              "GMT-09",              
        //                                              "GMT-08 (PST)",              
        //                                              "GMT-07 (MST)",              
        //                                              "GMT-06 (CST)",              
        //                                              "GMT-05 (EST)",              
        //                                              "GMT-04",              
        //                                              "GMT-03",              
        //                                              "GMT-02",              
        //                                              "GMT-01",              
        //                                              "GMT+00 (GMT)",              
        //                                              "GMT+01",              
        //                                              "GMT+02",              
        //                                              "GMT+03",              
        //                                              "GMT+04",              
        //                                              "GMT+05",              
        //                                              "GMT+06",              
        //                                              "GMT+07",              
        //                                              "GMT+08",              
        //                                              "GMT+09",              
        //                                              "GMT+10",              
        //                                              "GMT+11",              
        //                                              "GMT+12" };
        #endregion


//        public frmConfig(MainApp mainContainer, PrayerTime prayer, Config config)
        public frmConfig(MainApp mainContainer, PrayerTime prayer, object config)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
			//			this.tz.Items.Clear();
			//			foreach (string str in TimeZone)
			//				tz.Items.Add(str);
            this.mainContainer = mainContainer;
            this.prayer = prayer;
            this.config = config; //new Config(Directory.GetCurrentDirectory() + @"\Data.Dat");
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}





		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeZone = new System.Windows.Forms.TextBox();
            this.btDoIt = new System.Windows.Forms.Button();
            this.lngd = new System.Windows.Forms.TextBox();
            this.latd = new System.Windows.Forms.TextBox();
            this.lats = new System.Windows.Forms.GroupBox();
            this.South = new System.Windows.Forms.RadioButton();
            this.North = new System.Windows.Forms.RadioButton();
            this.lngm = new System.Windows.Forms.TextBox();
            this.latm = new System.Windows.Forms.TextBox();
            this.lngs = new System.Windows.Forms.GroupBox();
            this.East = new System.Windows.Forms.RadioButton();
            this.West = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimerBySec = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lats.SuspendLayout();
            this.lngs.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.Location = new System.Drawing.Point(8, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 20);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Latitude:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Longitude:";
            // 
            // txtTimeZone
            // 
            this.txtTimeZone.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeZone.Location = new System.Drawing.Point(173, 28);
            this.txtTimeZone.Name = "txtTimeZone";
            this.txtTimeZone.Size = new System.Drawing.Size(99, 18);
            this.txtTimeZone.TabIndex = 7;
            // 
            // btDoIt
            // 
            this.btDoIt.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDoIt.Location = new System.Drawing.Point(95, 135);
            this.btDoIt.Name = "btDoIt";
            this.btDoIt.Size = new System.Drawing.Size(75, 23);
            this.btDoIt.TabIndex = 8;
            this.btDoIt.Text = "Save";
            this.btDoIt.Click += new System.EventHandler(this.DoIt_Click);
            // 
            // lngd
            // 
            this.lngd.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lngd.Location = new System.Drawing.Point(62, 84);
            this.lngd.Name = "lngd";
            this.lngd.Size = new System.Drawing.Size(48, 18);
            this.lngd.TabIndex = 10;
            // 
            // latd
            // 
            this.latd.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latd.Location = new System.Drawing.Point(62, 58);
            this.latd.Name = "latd";
            this.latd.Size = new System.Drawing.Size(48, 18);
            this.latd.TabIndex = 9;
            // 
            // lats
            // 
            this.lats.Controls.Add(this.South);
            this.lats.Controls.Add(this.North);
            this.lats.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lats.Location = new System.Drawing.Point(167, 48);
            this.lats.Name = "lats";
            this.lats.Size = new System.Drawing.Size(110, 40);
            this.lats.TabIndex = 12;
            this.lats.TabStop = false;
            // 
            // South
            // 
            this.South.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.South.Location = new System.Drawing.Point(56, 16);
            this.South.Name = "South";
            this.South.Size = new System.Drawing.Size(49, 16);
            this.South.TabIndex = 1;
            this.South.Text = "South";
            // 
            // North
            // 
            this.North.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.North.Location = new System.Drawing.Point(8, 16);
            this.North.Name = "North";
            this.North.Size = new System.Drawing.Size(46, 17);
            this.North.TabIndex = 0;
            this.North.Text = "North";
            // 
            // lngm
            // 
            this.lngm.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lngm.Location = new System.Drawing.Point(114, 84);
            this.lngm.Name = "lngm";
            this.lngm.Size = new System.Drawing.Size(48, 18);
            this.lngm.TabIndex = 14;
            // 
            // latm
            // 
            this.latm.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latm.Location = new System.Drawing.Point(116, 57);
            this.latm.Name = "latm";
            this.latm.Size = new System.Drawing.Size(48, 18);
            this.latm.TabIndex = 13;
            // 
            // lngs
            // 
            this.lngs.Controls.Add(this.East);
            this.lngs.Controls.Add(this.West);
            this.lngs.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lngs.Location = new System.Drawing.Point(167, 89);
            this.lngs.Name = "lngs";
            this.lngs.Size = new System.Drawing.Size(110, 40);
            this.lngs.TabIndex = 15;
            this.lngs.TabStop = false;
            // 
            // East
            // 
            this.East.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.East.Location = new System.Drawing.Point(56, 16);
            this.East.Name = "East";
            this.East.Size = new System.Drawing.Size(42, 16);
            this.East.TabIndex = 1;
            this.East.Text = "East";
            // 
            // West
            // 
            this.West.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.West.Location = new System.Drawing.Point(8, 16);
            this.West.Name = "West";
            this.West.Size = new System.Drawing.Size(45, 16);
            this.West.TabIndex = 0;
            this.West.Text = "West";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Current City";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Timer (Sec)";
            // 
            // txtTimerBySec
            // 
            this.txtTimerBySec.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimerBySec.Location = new System.Drawing.Point(62, 107);
            this.txtTimerBySec.Name = "txtTimerBySec";
            this.txtTimerBySec.Size = new System.Drawing.Size(48, 18);
            this.txtTimerBySec.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(176, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Test";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(281, 165);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lngs);
            this.Controls.Add(this.lngm);
            this.Controls.Add(this.latm);
            this.Controls.Add(this.lats);
            this.Controls.Add(this.txtTimerBySec);
            this.Controls.Add(this.lngd);
            this.Controls.Add(this.latd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btDoIt);
            this.Controls.Add(this.txtTimeZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "frmConfig";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.lats.ResumeLayout(false);
            this.lngs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{

			//Application.Run(new frmConfig());
            MainApp m = new MainApp();
            Application.Run();
		}


		private void Form1_Load(object sender, System.EventArgs e)
		{
           // comboBox1.DataSource = prayer.Cities;
			comboBox1.DisplayMember = "T_Cities.City_name";
          //  comboBox1.Text = config.Read(mainContainer.ConfigName(enumConfig.CurrentCity));
           // txtTimerBySec.Text = config.Read(mainContainer.ConfigName(enumConfig.CurrentDelay));

            #region
            //sqlConnection1.Open();
            //sqlDataAdapter1.Fill(dsCities,"T_Cities");

            //string path  = Directory.GetCurrentDirectory();
            //dsCities.WriteXml(path + "\\" + "Cities.dat");
            //this.txtLatitude.DataBindings.Add("Text",prayer.Cities,"T_Cities.City_Latitude");
            //this.txtLongitude.DataBindings.Add("Text", prayer.Cities, "T_Cities.City_Longitude");
            //this.txtYear.Text= DateTime.Now.Year.ToString();
            //this.txtMon.Text= DateTime.Now.Month.ToString();
            //this.txtDay.Text= DateTime.Now.Day.ToString();
            //sqlConnection1.Close();
            #endregion

        }


        private void DoIt_Click(object sender, System.EventArgs e)
        {
            #region
            //Double longtitude = Double.Parse(txtLongitude.Text.ToString().Replace('.', ','), CultureInfo.CurrentCulture.NumberFormat); // Convert.ToDouble();
            //Double Latitude = Double.Parse(txtLatitude.Text.ToString().Replace('.', ','), CultureInfo.CurrentCulture.NumberFormat);

            //City w = new City(comboBox1.Text.ToString(), longtitude, Latitude);
            //month = Convert.ToInt32(txtMon.Text);
            //day = Convert.ToInt32(txtDay.Text);
            //year = Convert.ToInt32(txtYear.Text);

            //if ((w.Latitude == 0) || (w.Longitude == 0)) return;

            //prayer.Init(w, year, month, day);

            //this.txtTimeZone.Text = prayer.TimeZone();
            //latd.Text = prayer.LatitudeD(); 
            //latm.Text = prayer.LatitudeM(); 
            //North.Checked = prayer.North(); 
            //South.Checked = prayer.South();
            //lngd.Text = prayer.LongitudeD();
            //lngm.Text = prayer.LongitudeM();
            //West.Checked = prayer.West();
            //East.Checked = prayer.East();
            //sunrise1.Text = prayer.Sunrise();
            //suntransit.Text = prayer.Suntransit(); 
            //sunset1.Text = prayer.Sunset(); 
            //sunlen1.Text = prayer.Sunlen(); 
            //txtTwam.Text = prayer.TwilightBegin(); 
            //txtTwPm.Text = prayer.TwilightEnd();
            #endregion
          //  config.Write(mainContainer.ConfigName(enumConfig.CurrentCity), this.comboBox1.Text);
          //  config.Write(mainContainer.ConfigName(enumConfig.CurrentDelay), this.txtTimerBySec.Text);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedData = (DataRowView)comboBox1.SelectedItem;
            //City cty = prayer.GetCityByID(Convert.ToInt32(selectedData.Row.ItemArray[0].ToString()));
            //if (cty == null) return;
            //prayer.Init(cty, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            //txtTimeZone.Text = prayer.TimeZone();
            //latd.Text = prayer.LatitudeD();
            //latm.Text = prayer.LatitudeM();
            //North.Checked = prayer.North();
            //South.Checked = prayer.South();
            //lngd.Text = prayer.LongitudeD();
            //lngm.Text = prayer.LongitudeM();
            //West.Checked = prayer.West();
            //East.Checked = prayer.East();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotifyWindow nw = new NotifyWindow("مواعيد الصلاة", "test kal", @"PrayerApp.Resources.pic3.gif");
            nw.TextClicked += new System.EventHandler(textClick);
            nw.SetDimensions(110, 230);
            nw.Notify();
          
        }
        protected void textClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("Text clicked");
        }

	}
    public enum enumConfig {
        CurrentCity,
        CurrentDelay
    }
    public class MainApp : Control
    {
        private NotifyIcon nfty = new NotifyIcon();
        private PrayerTime prayer = new PrayerTime();
        //private Config config;
        private object config;
        public MainApp()
        {


            //ComponentResourceManager resources = new ComponentResourceManager(typeof(PrayerApp));
            //this.nfty.Icon = new Icon(@"C:\Users\cheaito\project\Ressources\icons\Calendar Day.ico");


            // Get this type's assembly
            Assembly assem = this.GetType().Assembly;
            Stream stream = assem.GetManifestResourceStream(@"PrayerApp.Resources.Calendar Day.ico");
            this.nfty.Icon = new Icon(stream);
            this.nfty.Visible = true;
            this.nfty.ContextMenu = new ContextMenu();
            this.nfty.ContextMenu.MenuItems.Add("Options...", OnConfig);
            this.nfty.ContextMenu.MenuItems.Add("Exit", OnExit);
            this.config = null;  //new Config(Directory.GetCurrentDirectory() + @"\Data.Dat");
            City cty = null; // prayer.GetCityByName(config.Read(ConfigName(enumConfig.CurrentCity)));
            if (cty == null) return;
         //   prayer.Init(cty, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
          //  int delay = Convert.ToInt32(config.Read(ConfigName(enumConfig.CurrentDelay)));
           // prayer.SetTimer(delay*1000);
        }
        public string ConfigName(enumConfig cfg)
        {

            if (cfg == enumConfig.CurrentCity) return "currentCity";
            if (cfg == enumConfig.CurrentDelay) return "currentTimer";
            return "";

        }
        void OnConfig(object sender, EventArgs e)
        {
            (new frmConfig(this,prayer, config)).Show();
        }
        void OnExit(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            Application.Exit();
        }
    }

}
