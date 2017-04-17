using System;
using System.Collections.Generic;
using System.Text;

namespace Nour.Athan.Lib
{
    public class PrayerTime
    {
        private City city;
		private int month = 0;
		private int day = 0;
		private int year = 0;

        #region variables
        private double lat = 0.0;
		private double lng = 0.0;
		private int dtime = 0;
		//		private int m_lat = 0; 
		//		private int m_lng = 0; 
		//		private int m_dtime = 0;      

		private int ampm = 1;      
		private int dst = 0;      

		private double r_to_d = 180 / Math.PI;      
		private double d_to_r = (Math.PI/180 ); 
      
		private double convday = 4.16666666666667E-02;      
		//		private double convhour = 6.66666666666667E-02;      
		//		private double convmin = 1.66666666666667E-02;      
		//		private double convsec = 2.77777777777778E-04;      
		private double convcircle = 2.77777777777778E-03;      
		private double SUNSET = -.833333333333333;      
		//		private double CIVIL = -6.0;      
		//		private double NAUTICAL = -12.0;      
		//		private double ASTRONOMICAL = -18.0;      

		//		var X = 0,Y = 0; // Netscape bug 

		//private int  maxDay = 31;

		private double SunDia = 0.53;		// Sunradius degrees
		private double AirRefr = 34.0/60.0; // athmospheric refraction degrees //
        public static string[] TimeZone = new string[] {
                                                      "GMT-12",
                                                      "GMT-11",              
                                                      "GMT-10",              
                                                      "GMT-09",              
                                                      "GMT-08 (PST)",              
                                                      "GMT-07 (MST)",              
                                                      "GMT-06 (CST)",              
                                                      "GMT-05 (EST)",              
                                                      "GMT-04",              
                                                      "GMT-03",              
                                                      "GMT-02",              
                                                      "GMT-01",              
                                                      "GMT+00 (GMT)",              
                                                      "GMT+01",              
                                                      "GMT+02",              
                                                      "GMT+03",              
                                                      "GMT+04",              
                                                      "GMT+05",              
                                                      "GMT+06",              
                                                      "GMT+07",              
                                                      "GMT+08",              
                                                      "GMT+09",              
                                                      "GMT+10",              
                                                      "GMT+11",              
                                                      "GMT+12" };


		#endregion

        public PrayerTime(City city)
        {
            this.city = city;

        }
        public PrayerTime()
        { }

        #region radians

        private double radians(double x)
        {
            return x * d_to_r;
        }
        #endregion

        #region calcsu
        public City calcsun(double xjd, int hh, int mm, int ss) // compute sun's position on this date      
        {
            City s = new City();
            double jd = xjd - (Convert.ToDouble(dtime) / 24.0); /* convert to GMT */
            double h = ((hh) + (mm / 60) + (ss / 3600)) * 15;
            double t = (jd - 2451545) * 2.7378507871321E-05;
            double lo = 280.46645 + (36000.76983 * t) + (0.0003032 * t * t);
            double m = 357.5291 + (35999.0503 * t) - (0.0001559 * t * t) - (0.00000048 * t * t * t);
            double rm = radians(m);
            double e = 0.016708617 - (0.000042037 * t) - (0.0000001236 * t * t);
            double c = (1.9146 - 0.004817 * t - 0.000014 * t * t) * Math.Sin(rm);
            c = c + (0.019993 - 0.000101 * t) * Math.Sin(2 * rm);
            c = c + 0.00029 * Math.Sin(3 * rm);
            double tl = lo + c;
            double v = m + c;
            double r = (1.000001018 * (1 - e * e)) / (1 + (e * Math.Cos(radians(v))));
            double nut = 125.04 - 1934.136 * t;
            double al = radians(tl - 0.00569 - 0.00478 * Math.Sin(radians(nut)));
            double obliq = 23.4391666666667 - 1.30041666666666E-02 * t - 0.000000163888888 * t * t + 5.03611111111E-08 * t * t * t;

            obliq = radians(obliq + 0.00256 * Math.Cos(radians(nut)));
            double sunra = myatan2(Math.Cos(obliq) * Math.Sin(al), Math.Cos(al));
            if (sunra < 0)
                sunra = 360 + sunra;


            //double sundecl = degrees(Math.Asin(Math.Sin(obliq) * Math.Sin(al)));   
            double delta = Math.Asin(Math.Sin(obliq) * Math.Sin(al));
            double sundecl = degrees(delta);

            s.Latitude = sundecl;
            s.Longitude = sunra;
            s.Delta = delta;	//MCH 

            return (s);

        }

        #endregion

        #region myatan2
        private double myatan2(double y, double x)
        { // returns degrees      

            double a;
            x = (x == 0) ? 1e-30 : x;
            a = degrees(Math.Atan(y / x));
            if (x < 0)
            {
                a = 180 + a;
            }
            if (a < 0)
            {
                a = 360 + a;
            }
            return a;

        }
        #endregion

        #region degrees
        private double degrees(double x)
        {
            return x * r_to_d;
        }
        #endregion

        ////#region dt_hms
        ////public static string dt_hms(double x, double amdsp, double dst)
        ////{

        ////    double h, m, s;

        ////    string ampm;

        ////    string outstr;

        ////    if ((x > -100) && (x < 100))
        ////    {
        ////        x = (x < 0) ? 0 : x;
        ////        h = Math.Floor(x);
        ////        x = (x - h) * 60;
        ////        h = (h + dst) % 24; // daylight time adjustment      
        ////        m = Math.Floor(x);
        ////        x = (x - m) * 60;
        ////        s = Math.Floor(x);
        ////        if (amdsp > 0)
        ////        {
        ////            ampm = (h > 11) ? " PM" : " AM";
        ////            h = h % 12;
        ////            h = (h < 1) ? 12 : h;
        ////        }
        ////        else
        ////        {
        ////            ampm = "";
        ////        }

        ////        outstr = Utils.fix_places(h.ToString()) + ":" + Utils.fix_places(m.ToString()) + ":" + Utils.fix_places(s.ToString()) + ampm;
        ////    }

        ////    else
        ////    {
        ////        outstr = (x < 0) ? "[Below]" : "[Above]";
        ////    }
        ////    return outstr;
        ////}
        ////#endregion
        
    }
}
