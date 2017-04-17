using System;

namespace PrayerApp
{
	/// <summary>
	/// Summary description for City.
	/// </summary>
	public class City
	{

		private double latitude;
		private double longitude;
		private double delta;//  MCH 
		private double place;
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
		public double Latitude
		{
			get{ return this.latitude;}
			set{ this.latitude = value;}
		}
		public double Longitude
		{
			get{ return this.longitude;}
			set{ this.longitude = value;}
		}

		public double Delta //MCh 
		{
			get{ return this.delta;}
			set{ this.delta = value;}
		}

		public double Place
		{
			get{ return this.place;}
			set{ this.place = value;}
		}

		public City()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
