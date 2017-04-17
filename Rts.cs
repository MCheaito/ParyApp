using System;

namespace PrayerApp
{
	/// <summary>
	/// Summary description for City.
	/// </summary>
	public class Rts
	{
		public double twam;				//Fajr or Twilight begin
		public double rise;				//Shorook or Sunrise
		public double transit;			//Zuhr or Noon 
		public double shadow;			//Before sunset /Asr
		public double set;				//SunSet or Magrib
		public double twpm;				//Ishaa or twilight ends

		public Rts()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
