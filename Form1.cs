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

namespace PrayerApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		#region variables
		private DataSet dsCities = new DataSet();

		private int month = 0;
		private int day = 0;
		private int year = 0;

		private double lat = 0.0;
		private double lng = 0.0;
		private int dtime = 0;
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

		#region  var user
		private System.Windows.Forms.TextBox txtTimeZone;
		private System.Windows.Forms.TextBox txtLatitude;
		private System.Windows.Forms.TextBox txtLongitude;
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
		private System.Windows.Forms.TextBox sunrise1;
		private System.Windows.Forms.TextBox sunset1;
		private System.Windows.Forms.TextBox sunlen1;
		private System.Windows.Forms.TextBox suntransit;
		private System.Windows.Forms.TextBox txtMon;
		private System.Windows.Forms.TextBox txtYear;
		private System.Windows.Forms.TextBox txtDay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtTwam;
		private System.Windows.Forms.TextBox txtTwPm;


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
        PrayerTime prayerTime;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//			this.tz.Items.Clear();
			//			foreach (string str in TimeZone)
			//				tz.Items.Add(str);

            prayerTime = new PrayerTime();
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
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
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
            this.sunrise1 = new System.Windows.Forms.TextBox();
            this.sunset1 = new System.Windows.Forms.TextBox();
            this.sunlen1 = new System.Windows.Forms.TextBox();
            this.suntransit = new System.Windows.Forms.TextBox();
            this.txtMon = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTwam = new System.Windows.Forms.TextBox();
            this.txtTwPm = new System.Windows.Forms.TextBox();
            this.lats.SuspendLayout();
            this.lngs.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "T_Cities", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("city_id", "city_id"),
                        new System.Data.Common.DataColumnMapping("Country_name", "Country_name"),
                        new System.Data.Common.DataColumnMapping("City_name", "City_name"),
                        new System.Data.Common.DataColumnMapping("City_Latitude", "City_Latitude"),
                        new System.Data.Common.DataColumnMapping("City_Longitude", "City_Longitude")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT city_id, Country_name, City_name, City_Latitude, City_Longitude FROM T_Cit" +
                "ies ORDER BY City_name";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=BASE;packet size=4096;integrated security=SSPI;data source=\"(local" +
                ")\";persist security info=False;initial catalog=PrayerDB";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(8, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(304, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select City";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(256, 8);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(40, 20);
            this.txtLatitude.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(8, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Latitude:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(8, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Longitude:";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(304, 8);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(48, 20);
            this.txtLongitude.TabIndex = 5;
            // 
            // txtTimeZone
            // 
            this.txtTimeZone.Location = new System.Drawing.Point(8, 168);
            this.txtTimeZone.Name = "txtTimeZone";
            this.txtTimeZone.Size = new System.Drawing.Size(304, 20);
            this.txtTimeZone.TabIndex = 7;
            // 
            // btDoIt
            // 
            this.btDoIt.Location = new System.Drawing.Point(232, 232);
            this.btDoIt.Name = "btDoIt";
            this.btDoIt.Size = new System.Drawing.Size(75, 23);
            this.btDoIt.TabIndex = 8;
            this.btDoIt.Text = "Calculate";
            this.btDoIt.Click += new System.EventHandler(this.DoIt_Click);
            // 
            // lngd
            // 
            this.lngd.Location = new System.Drawing.Point(72, 136);
            this.lngd.Name = "lngd";
            this.lngd.Size = new System.Drawing.Size(48, 20);
            this.lngd.TabIndex = 10;
            // 
            // latd
            // 
            this.latd.Location = new System.Drawing.Point(72, 96);
            this.latd.Name = "latd";
            this.latd.Size = new System.Drawing.Size(48, 20);
            this.latd.TabIndex = 9;
            // 
            // lats
            // 
            this.lats.Controls.Add(this.South);
            this.lats.Controls.Add(this.North);
            this.lats.Location = new System.Drawing.Point(184, 80);
            this.lats.Name = "lats";
            this.lats.Size = new System.Drawing.Size(128, 40);
            this.lats.TabIndex = 12;
            this.lats.TabStop = false;
            // 
            // South
            // 
            this.South.Location = new System.Drawing.Point(64, 16);
            this.South.Name = "South";
            this.South.Size = new System.Drawing.Size(56, 16);
            this.South.TabIndex = 1;
            this.South.Text = "South";
            // 
            // North
            // 
            this.North.Location = new System.Drawing.Point(8, 16);
            this.North.Name = "North";
            this.North.Size = new System.Drawing.Size(56, 16);
            this.North.TabIndex = 0;
            this.North.Text = "North";
            // 
            // lngm
            // 
            this.lngm.Location = new System.Drawing.Point(128, 136);
            this.lngm.Name = "lngm";
            this.lngm.Size = new System.Drawing.Size(48, 20);
            this.lngm.TabIndex = 14;
            // 
            // latm
            // 
            this.latm.Location = new System.Drawing.Point(128, 96);
            this.latm.Name = "latm";
            this.latm.Size = new System.Drawing.Size(48, 20);
            this.latm.TabIndex = 13;
            // 
            // lngs
            // 
            this.lngs.Controls.Add(this.East);
            this.lngs.Controls.Add(this.West);
            this.lngs.Location = new System.Drawing.Point(184, 128);
            this.lngs.Name = "lngs";
            this.lngs.Size = new System.Drawing.Size(128, 40);
            this.lngs.TabIndex = 15;
            this.lngs.TabStop = false;
            // 
            // East
            // 
            this.East.Location = new System.Drawing.Point(64, 16);
            this.East.Name = "East";
            this.East.Size = new System.Drawing.Size(56, 16);
            this.East.TabIndex = 1;
            this.East.Text = "East";
            // 
            // West
            // 
            this.West.Location = new System.Drawing.Point(8, 16);
            this.West.Name = "West";
            this.West.Size = new System.Drawing.Size(56, 16);
            this.West.TabIndex = 0;
            this.West.Text = "West";
            // 
            // sunrise1
            // 
            this.sunrise1.Location = new System.Drawing.Point(64, 200);
            this.sunrise1.Name = "sunrise1";
            this.sunrise1.Size = new System.Drawing.Size(72, 20);
            this.sunrise1.TabIndex = 16;
            // 
            // sunset1
            // 
            this.sunset1.Location = new System.Drawing.Point(64, 245);
            this.sunset1.Name = "sunset1";
            this.sunset1.Size = new System.Drawing.Size(72, 20);
            this.sunset1.TabIndex = 17;
            // 
            // sunlen1
            // 
            this.sunlen1.Location = new System.Drawing.Point(64, 264);
            this.sunlen1.Name = "sunlen1";
            this.sunlen1.Size = new System.Drawing.Size(72, 20);
            this.sunlen1.TabIndex = 18;
            // 
            // suntransit
            // 
            this.suntransit.Location = new System.Drawing.Point(64, 224);
            this.suntransit.Name = "suntransit";
            this.suntransit.Size = new System.Drawing.Size(72, 20);
            this.suntransit.TabIndex = 19;
            // 
            // txtMon
            // 
            this.txtMon.Location = new System.Drawing.Point(128, 32);
            this.txtMon.Name = "txtMon";
            this.txtMon.Size = new System.Drawing.Size(48, 20);
            this.txtMon.TabIndex = 27;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(72, 32);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(48, 20);
            this.txtYear.TabIndex = 26;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(184, 32);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(48, 20);
            this.txtDay.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Sunrise";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Noon";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Sunset";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Lenght";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(232, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTwam
            // 
            this.txtTwam.Location = new System.Drawing.Point(142, 200);
            this.txtTwam.Name = "txtTwam";
            this.txtTwam.Size = new System.Drawing.Size(72, 20);
            this.txtTwam.TabIndex = 35;
            // 
            // txtTwPm
            // 
            this.txtTwPm.Location = new System.Drawing.Point(144, 248);
            this.txtTwPm.Name = "txtTwPm";
            this.txtTwPm.Size = new System.Drawing.Size(72, 20);
            this.txtTwPm.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(344, 315);
            this.Controls.Add(this.txtTwPm);
            this.Controls.Add(this.txtTwam);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.txtMon);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.suntransit);
            this.Controls.Add(this.sunlen1);
            this.Controls.Add(this.sunset1);
            this.Controls.Add(this.lngs);
            this.Controls.Add(this.lngm);
            this.Controls.Add(this.latm);
            this.Controls.Add(this.lats);
            this.Controls.Add(this.lngd);
            this.Controls.Add(this.latd);
            this.Controls.Add(this.btDoIt);
            this.Controls.Add(this.txtTimeZone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.sunrise1);
            this.Name = "Form1";
            this.Text = "Form1";
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
			Application.Run(new Form1());
		}


		private void Form1_Load(object sender, System.EventArgs e)
		{
			sqlConnection1.Open();
			sqlDataAdapter1.Fill(dsCities,"T_Cities");
			comboBox1.DataSource = dsCities;
			comboBox1.DisplayMember = "T_Cities.City_name";
			string path  = Directory.GetCurrentDirectory();
			dsCities.WriteXml(path + "\\" + "Cities.dat");

			this.txtLatitude.DataBindings.Add("Text",dsCities,"T_Cities.City_Latitude");
			this.txtLongitude.DataBindings.Add("Text",dsCities,"T_Cities.City_Longitude");
			this.txtYear.Text= DateTime.Now.Year.ToString();
			this.txtMon.Text= DateTime.Now.Month.ToString();
			this.txtDay.Text= DateTime.Now.Day.ToString();

			//sqlConnection1.Close();

		}
		private void  List_pos(City w) 
		{      
			lat = w.Latitude;
			lng = w.Longitude;

			if((lat != 0) && (lng != 0)) 
			{      
				dtime = (int)-Math.Floor((lng+7.5)/15);
				this.txtTimeZone.Text =PrayerTime.TimeZone[12+dtime];
				this.DoIt();      
			}      
		}

        private void DoIt_Click(object sender, System.EventArgs e)
        {

            Double longtitude = Double.Parse(txtLongitude.Text.ToString().Replace('.', ','), CultureInfo.CurrentCulture.NumberFormat); // Convert.ToDouble();
            Double Latitude = Double.Parse(txtLatitude.Text.ToString().Replace('.', ','), CultureInfo.CurrentCulture.NumberFormat);

            //City w = new City(comboBox1.Text.ToString(), longtitude, Latitude);

            City w = new City();

            month = Convert.ToInt32(txtMon.Text);
            day = Convert.ToInt32(txtDay.Text);
            year = Convert.ToInt32(txtYear.Text);

            List_pos(w);
        }

        //#region  fix places function
        //private string fix_places(string x) 
        //{      
        //    return ((x.Trim().Length <2)? "0"+x:x);
        //}  
        //#endregion

        //#region  dd_dm function
        //private string  dd_dm(double x,int f) 
        //{      

        //    string sgn =((x>=0)?"0":"1");      
			
        //    double x1 = Math.Abs(x)+.008333;      

        //    double d = Math.Floor(x1);      
		
        //    x1 = (x1-d) * 60;      

        //    double m = Math.Floor(x1);      
	       
        //    if(f == 0)  return Utils.fix_places(d.ToString());
        //    if (f == 1) return Utils.fix_places(m.ToString());      
        //    if(f == 2) return sgn;

        //    return null;
        //}      

        //#endregion

        //#region mdy_jd function 
        //private double  mdy_jd(int mo,int da,int yr,int hh,int mm,int ss) // was struct datim q 

        //{      

        //    double jd;      
        //    double  a; 
        //    double b;

        //    if (mo < 3)      
        //    {      
        //        yr -= 1;      
        //        mo += 12;      
        //    }      
        //    a = da + (mo * 100) + (yr * 10000);      

        //    if (a < 15821015.0) /* Julian calendar */      //1582 -10-15
        //    {      
        //        b = 0;      
        //    }      
        //    else /* Gregorian */      
        //    {      
        //        a = (double)Math.Floor((double)yr/100);      
        //        b = 2 - a + Math.Floor(a/4);      

        //    }      

        //    jd = Math.Floor(365.25*(yr+4716.0)) + Math.Floor(30.6001*(mo+1)) + da + b - 1524.5;      
        //    jd += (hh/24) + (mm/1440) + (ss/86400);      

        //    return(jd);      
        //}    
        //#endregion

        //#region hourAngle

        //private double hourAngle(double zenith, double latitude, double declination) 
        //{
        //    double cosha;
        //    double ha;
        //    cosha = Math.Cos(zenith)/Math.Cos(d_to_r*latitude)/Math.Cos(d_to_r *declination)
        //        - Math.Tan(d_to_r *latitude)*Math.Tan(d_to_r *declination);
        //    if (cosha<-1.0) cosha= -1.0; // no darkness
        //    ha = Math.Acos(cosha)/d_to_r; // Hour angle for given zenith angle [degr]
        //    return ha;
        //}

        //#endregion

        //#region Range
        ////
        ////   the function below returns an angle in the range
        ////   0 to two pi
        ////
        //private double  range(double x) 
        //{
        //    double  b = x /Math.PI/2.0;
        //    double  a = 2.0*Math.PI * (b - Math.Round(b));
        //    if (a < 0) a = 2*Math.PI + a;
        //    return a;
        //}
        //#endregion

		#region  calculation twildev
//		private double Twidev()
//		{
//
//
//
//			double AirRefr = 159.4/(273.0+1.0*ta);
//			double df0 = 0.5*SunDia +AirRefr;
//			double fo = hourAngle(radians(90.0+df0),Convert.ToDouble(this.txtLatitude.Text),dekl);
//			double fi = hourAngle(1.675516,Convert.ToDouble(this.txtLatitude.Text),dekl);
//			double tdev = (fi - fo);
//			return tdev;
//		}



		#endregion

        //#region radians

        //private double radians(double x) 
        //{      
        //    return x * d_to_r;      
        //}
        //#endregion

        //#region degrees
        //private double degrees(double x) 
        //{      
        //    return x * r_to_d;      
        //}      
        //#endregion

        //#region sidtime
        ///* sidereal time from Julian Date */      
        //private double  sidtime(double jd,double lng)      
        //{      
        //    double t,x;      

        //    t = ((Math.Floor(jd) + 0.5) - 2451545) *2.73785078713210E-05;      

        //    x = 280.46061837;      

        //    x = x + 360.98564736629 * (jd - 2451545);      

        //    x = x + 0.000387933 * t * t;      

        //    x = x - (t * t * t) * 2.583311805734950E-08;      

        //    x = x - lng;      

        //    x = x * convcircle;      

        //    x = x - Math.Floor(x);      

        //    x = x * 360;      

        //    return(x);      

        //}      
        //#endregion

        //#region mod1
        //private double  mod1(double t)      
        //{      
        //    double ot;      
        //    ot = t;      
        //    t = Math.Abs(t);      
        //    t = t - Math.Floor(t);      
        //    if(ot < 0)      
        //        t = 1-t;      

        //    return(t);      
        //}      
        //#endregion

        //#region myatan2
        //private double  myatan2(double y, double x) 
        //{ // returns degrees      

        //    double  a;      
        //    x = (x == 0)?1e-30:x;      
        //    a = Utils.degrees(Math.Atan(y/x));      
        //    if(x < 0) 
        //    {      
        //        a = 180 + a;      
        //    }      
        //    if(a < 0) 
        //    {      
        //        a = 360 + a;      
        //    }      
        //    return a;      

        //}   
        //#endregion

        //#region rmstime
        //private Rts rmstime(double jd, double lat,double lng,double timezone, double atcr,City cty /*double ra,double decl*/)      
        //{      

        //    double  x,gmtsid;      
        //    double ra = cty.Longitude;		//MCH 
        //    double decl = cty.Latitude;		// MCH 

        //    Rts r = new Rts();      

        //    timezone *= convday;      

        //    gmtsid  =Utils.sidtime(Math.Floor(jd) + 0.5, 0);      

        //    r.transit = ((ra + lng - gmtsid) / 360);      

        //    atcr = Utils.radians(atcr); 
	
        //    #region MCH 
        //    double ha = Utils.f0(lat,cty.Delta);	//MCH 
        //    double hb = Utils.f1(lat,cty.Delta);	//MCH 
        //    double twx = hb - ha;	// length of twilight in radians
        //    twx = 12.0*twx/Math.PI;		// length of twilight in hours
        //    #endregion

        //    lat = Utils.radians(lat);      

        //    decl = Utils.radians(decl);      

        //    x = Math.Sin(atcr) - (Math.Sin(lat) * Math.Sin(decl));      

        //    x = x / (Math.Cos(lat) * Math.Cos(decl));      

        //    if ((x < 1) && (x > -1))      
        //    {      

        //        x = Utils.degrees(Math.Acos(x)) * Utils.Convcircle;      

        //        r.rise = (mod1((r.transit - x)+timezone)) * 24.0;      

        //        r.set = (mod1((r.transit + x)+timezone)) * 24.0;      

        //        r.transit = (mod1(r.transit+timezone)) * 24.0;   
   
        //        r.twam = r.rise - mod1(twx);	// MCh 

        //        r.twpm = r.set + mod1(twx);	//MCH 
        //    }      

        //    else      

        //    {      

        //        x = (x >= 0)?-100:100;      

        //        r.rise = x;      

        //        r.transit = x;      

        //        r.set = x;   

        //        r.twam = x;	// MCh 

        //        r.twpm = x;	//MCH 
   
        //    }      

        //    return r;      

        //}      

        //#endregion

        //#region f1: Calculating the hourangle for twilight times / to calculate Fajr And Isha
        //// Calculating the hourangle for twilight times
        ////
        //private double f1(double lat, double declin) 
        //{
        //    double fi,df1;
        //    // Correction: different sign at S HS
        //    df1 = d_to_r * 6.0; if (lat < 0.0) df1 = -df1;
        //    fi = Math.Tan(declin + df1) * Math.Tan(lat*d_to_r);
        //    if (fi>0.99999) fi=1.0; // to avoid overflow //
        //    fi = Math.Asin(fi) + Math.PI/2.0;
        //    return fi;
        //}
        //#endregion

        //#region f0: Calculating the hourangle to calculate Fajr And Isha
        //// Calculating the hourangle
        ////
        //private double f0(double lat, double declin) 
        //{
        //    double fo,dfo;
        //    // Correction: different sign at S HS
        //    dfo = d_to_r*(0.5*SunDia + AirRefr); if (lat < 0.0) dfo = -dfo;
        //    fo = Math.Tan(declin + dfo) * Math.Tan(lat*d_to_r);
        //    if (fo>0.99999) fo=1.0; // to avoid overflow //
        //    fo = Math.Asin(fo) + Math.PI/2.0;
        //    return fo;
        //}
        //#endregion
		

        //#region dt_hms
        //private string  dt_hms(double x,double amdsp,double dst) 
        //{      

        //    double h,m,s;      

        //    string ampm;      

        //    string outstr;      

        //    if((x > -100) && (x < 100)) 
        //    {      
        //        x = (x < 0)?0:x;      
        //        h = Math.Floor(x);      
        //        x = (x-h) * 60;      
        //        h = (h+dst) % 24; // daylight time adjustment      
        //        m = Math.Floor(x);      
        //        x = (x-m) * 60;      
        //        s = Math.Floor(x);      
        //        if(amdsp > 0) 
        //        {      
        //            ampm = (h > 11)?" PM":" AM";      
        //            h = h % 12;      
        //            h = (h < 1)?12:h;      
        //        }      
        //        else 
        //        {      
        //            ampm = "";      
        //        }

        //        outstr = Utils.fix_places(h.ToString()) + ":" + Utils.fix_places(m.ToString()) + ":" + Utils.fix_places(s.ToString()) + ampm;      
        //    }      

        //    else 
        //    {      
        //        outstr = (x < 0)?"[Below]":"[Above]";      
        //    }      
        //    return outstr;      
        //}      
        //#endregion

		private void DoIt() 
		{      
			double jd;
            PrayerTime prayer = new PrayerTime();

			City s = new  City();      
			Rts r = new Rts();      
         

			latd.Text = Utils.dd_dm(lat,0);
            latm.Text = Utils.dd_dm(lat, 1);
            North.Checked = (Utils.dd_dm(lat, 2) == "0");
            South.Checked = (Utils.dd_dm(lat, 2) == "1");

            lngd.Text = Utils.dd_dm(lng, 0);
            lngm.Text = Utils.dd_dm(lng, 1);
            West.Checked = (Utils.dd_dm(lng, 2) == "0");
            East.Checked = (Utils.dd_dm(lng, 2) == "1");



            jd = Utils.mdy_jd(month, day, year, 0, 0, 0);

            //s = prayer.calcsun(jd, 0, 0, 0);
           // r = Utils.rmstime(jd,lat,lng,dtime,s); //s.Longitude,s.Latitude);    
  
			sunrise1.Text = Utils.dt_hms(r.rise,1,0);
            suntransit.Text = Utils.dt_hms(r.transit, 1, 0);
            sunset1.Text = Utils.dt_hms(r.set, 1, 0);
            sunlen1.Text = Utils.dt_hms(r.set - r.rise, 0, 0);
            txtTwam.Text = Utils.dt_hms(r.twam, 1, 0);
            txtTwPm.Text = Utils.dt_hms(r.twpm, 1, 0);


      
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DateConvertor d = new DateConvertor();
			//MessageBox.Show(d.GregToHijri(DateTime.Now.GetDateTimeFormats("dd-M-yyyy").ToString()));
			MessageBox.Show(d.GregToHijri("2006-03-01"));
		}


	}
}
