using System;
using System.Collections.Generic;
using System.Text;

namespace Nour.Athan.Lib
{
    public class Utils
    {
        const double convcircle = 2.77777777777778E-03;
        const double r_to_d = 180 / Math.PI;
        const double d_to_r = (Math.PI / 180);
        const double SunDia = 0.53;		// Sunradius degrees
        const double AirRefr = 34.0 / 60.0; // athmospheric refraction degrees //
        const double convday = 4.16666666666667E-02;
        const double SUNSET = -.833333333333333;
 
        public static double Convcircle
        {
            get { return convcircle; }
        }

        public  Utils()
        {
        }

        #region degrees
        public static double degrees(double x)
        {
            return x * r_to_d;
        }
        #endregion


        #region  public methods
        #region mdy_jd function
        public static double mdy_jd(int mo, int da, int yr, int hh, int mm, int ss) // was struct datim q 
        {

            double jd;
            double a;
            double b;

            if (mo < 3)
            {
                yr -= 1;
                mo += 12;
            }
            a = da + (mo * 100) + (yr * 10000);

            if (a < 15821015.0) /* Julian calendar */      //1582 -10-15
            {
                b = 0;
            }
            else /* Gregorian */
            {
                a = (double)Math.Floor((double)yr / 100);
                b = 2 - a + Math.Floor(a / 4);

            }

            jd = Math.Floor(365.25 * (yr + 4716.0)) + Math.Floor(30.6001 * (mo + 1)) + da + b - 1524.5;
            jd += (hh / 24) + (mm / 1440) + (ss / 86400);

            return (jd);
        }
        #endregion

        #region  dd_dm function
        public static string dd_dm(double x, int f)
        {

            string sgn = ((x >= 0) ? "0" : "1");

            double x1 = Math.Abs(x) + .008333;

            double d = Math.Floor(x1);

            x1 = (x1 - d) * 60;

            double m = Math.Floor(x1);

            if (f == 0) return fix_places(d.ToString());
            if (f == 1) return fix_places(m.ToString());
            if (f == 2) return sgn;

            return null;
        }

        #endregion

        #region dt_hms
        public static string dt_hms(double x,double amdsp, double dst)
        {

            double h, m, s;
            
            string ampm;

            string outstr;

            if ((x > -100) && (x < 100))
            {
                x = (x < 0) ? 0 : x;
                h = Math.Floor(x);
                x = (x - h) * 60;
                h = (h + dst) % 24; // daylight time adjustment      
                m = Math.Floor(x);
                x = (x - m) * 60;
                s = Math.Floor(x);
                if (amdsp > 0)
                {
                    ampm = (h > 11) ? " PM" : " AM";
                    h = h % 12;
                    h = (h < 1) ? 12 : h;
                }
                else
                {
                    ampm = "";
                }

                outstr = fix_places(h.ToString()) + ":" + fix_places(m.ToString()) + ":" + fix_places(s.ToString()) + ampm;
            }

            else
            {
                outstr = (x < 0) ? "[Below]" : "[Above]";
            }
            return outstr;
        }
        #endregion

        #region rmstime
        public static Rts rmstime(double jd, double lat, double lng, double timezone,  City cty /*double ra,double decl*/)
        {

            double x, gmtsid;
            double ra = cty.Longitude;		//MCH 
            double decl = cty.Latitude;		// MCH 

            Rts r = new Rts();

            timezone *= convday;

            gmtsid = Utils.sidtime(Math.Floor(jd) + 0.5, 0);

            r.transit = ((ra + lng - gmtsid) / 360);

            double atcr = Utils.radians(SUNSET);

            #region MCH
            double ha = Utils.f0(lat, cty.Delta);	//MCH 
            double hb = Utils.f1(lat, cty.Delta);	//MCH 
            double twx = hb - ha;	// length of twilight in radians
            twx = 12.0 * twx / Math.PI;		// length of twilight in hours
            #endregion

            lat = Utils.radians(lat);

            decl = Utils.radians(decl);

            x = Math.Sin(atcr) - (Math.Sin(lat) * Math.Sin(decl));

            x = x / (Math.Cos(lat) * Math.Cos(decl));

            if ((x < 1) && (x > -1))
            {

                x = Utils.degrees(Math.Acos(x)) * Utils.Convcircle;

                r.rise = (mod1((r.transit - x) + timezone)) * 24.0;

                r.set = (mod1((r.transit + x) + timezone)) * 24.0;

                r.transit = (mod1(r.transit + timezone)) * 24.0;

                r.twam = r.rise - mod1(twx);	// MCh 

                r.twpm = r.set + mod1(twx);	//MCH 
            }

            else
            {

                x = (x >= 0) ? -100 : 100;

                r.rise = x;

                r.transit = x;

                r.set = x;

                r.twam = x;	// MCh 

                r.twpm = x;	//MCH 

            }

            return r;

        }

        #endregion
        #endregion

        #region Private methodes

        #region radians

        private static double radians(double x)
        {
            return x * d_to_r;
        }
        #endregion
        #region mod1
        private static double mod1(double t)
        {
            double ot;
            ot = t;
            t = Math.Abs(t);
            t = t - Math.Floor(t);
            if (ot < 0)
                t = 1 - t;

            return (t);
        }
        #endregion
        #region sidtime
        /* sidereal time from Julian Date */
        private static double sidtime(double jd, double lng)
        {
            double t, x;

            t = ((Math.Floor(jd) + 0.5) - 2451545) * 2.73785078713210E-05;

            x = 280.46061837;

            x = x + 360.98564736629 * (jd - 2451545);

            x = x + 0.000387933 * t * t;

            x = x - (t * t * t) * 2.583311805734950E-08;

            x = x - lng;

            x = x * convcircle;

            x = x - Math.Floor(x);

            x = x * 360;

            return (x);

        }
        #endregion
        #region  fix places function
        private static string fix_places(string x)
        {
            return ((x.Trim().Length < 2) ? "0" + x : x);
        }
        #endregion
        #region f1: Calculating the hourangle for twilight times / to calculate Fajr And Isha
        // Calculating the hourangle for twilight times
        //
        private static double f1(double lat, double declin)
        {
            double fi, df1;
            // Correction: different sign at S HS
            df1 = d_to_r * 6.0; if (lat < 0.0) df1 = -df1;
            fi = Math.Tan(declin + df1) * Math.Tan(lat * d_to_r);
            if (fi > 0.99999) fi = 1.0; // to avoid overflow //
            fi = Math.Asin(fi) + Math.PI / 2.0;
            return fi;
        }
        #endregion
        #region f0: Calculating the hourangle to calculate Fajr And Isha
        // Calculating the hourangle
        //
        private static double f0(double lat, double declin)
        {
            double fo, dfo;
            // Correction: different sign at S HS
            dfo = d_to_r * (0.5 * SunDia + AirRefr); if (lat < 0.0) dfo = -dfo;
            fo = Math.Tan(declin + dfo) * Math.Tan(lat * d_to_r);
            if (fo > 0.99999) fo = 1.0; // to avoid overflow //
            fo = Math.Asin(fo) + Math.PI / 2.0;
            return fo;
        }
        #endregion
        #region hourAngle

        private static double hourAngle(double zenith, double latitude, double declination)
        {
            double cosha;
            double ha;
            cosha = Math.Cos(zenith) / Math.Cos(d_to_r * latitude) / Math.Cos(d_to_r * declination)
                - Math.Tan(d_to_r * latitude) * Math.Tan(d_to_r * declination);
            if (cosha < -1.0) cosha = -1.0; // no darkness
            ha = Math.Acos(cosha) / d_to_r; // Hour angle for given zenith angle [degr]
            return ha;
        }

        #endregion
        #region myatan2
        private static double myatan2(double y, double x)
        { // returns degrees      

            double a;
            x = (x == 0) ? 1e-30 : x;
            a = Utils.degrees(Math.Atan(y / x));
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
        #region Range
        //
        //   the function below returns an angle in the range
        //   0 to two pi
        //
        private static double range(double x)
        {
            double b = x / Math.PI / 2.0;
            double a = 2.0 * Math.PI * (b - Math.Round(b));
            if (a < 0) a = 2 * Math.PI + a;
            return a;
        }
        #endregion

        #region  calculation twildev
        //private static double Twidev()
        //{
        //    double AirRefr = 159.4 / (273.0 + 1.0 * ta);
        //    double df0 = 0.5 * SunDia + AirRefr;
        //    double fo = hourAngle(radians(90.0 + df0), Convert.ToDouble(this.txtLatitude.Text), dekl);
        //    double fi = hourAngle(1.675516, Convert.ToDouble(this.txtLatitude.Text), dekl);
        //    double tdev = (fi - fo);
        //    return tdev;
        //}
        #endregion

        #endregion


    }
}
