////////////////////////////////////Disclaimer////////////////////////////////////////////
///This library has been wrote by : Anas Reslan Bahsas  if you are going to use it		//	
///please dont remove this line .														//					
///you have to add this class to a asp.net web project to work well.					//		//	
///I will be grateful to receive any commments or suggestion to anasbahsas@hotmail.com	//								//	
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Web;
using System.Diagnostics;
using System.Globalization;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace Nour.Athan.Lib
{
	/// <summary>
	/// Summary description for DateConvertor.
	/// </summary>
	public class DateConvertor
	{
		private string[] monthsE = {"January","February","March","April","May","June","July","August","September","October","November","December"};
        private string[] monthsH = { "محرم", "صفر", "ربيع الأول", "ربيع الثاني", "جمادى الأول", "جمادى الآخر", "رجب ", "شعبان", "رمضان", "شوال", "ذو القعدة", "ذو الحجة" };

		#region 

//			private HttpContext cur;
		
			private const int startGreg=1900;
			private const int endGreg=2100;
			private string[] allFormats={"yyyy/MM/dd","yyyy/M/d","dd/MM/yyyy","d/M/yyyy","dd/M/yyyy","d/MM/yyyy","yyyy-MM-dd","yyyy-M-d","dd-MM-yyyy","d-M-yyyy","dd-M-yyyy","d-MM-yyyy","yyyy MM dd","yyyy M d","dd MM yyyy","d M yyyy","dd M yyyy","d MM yyyy"};
			private CultureInfo arCul;
			private CultureInfo enCul;
			private HijriCalendar h;
			private GregorianCalendar g;

			
			public DateConvertor()
			{
				//cur = HttpContext.Current;

				arCul=new CultureInfo("ar-SA");
				enCul=new CultureInfo("en-US");

				h=new  HijriCalendar();
				g=new GregorianCalendar(GregorianCalendarTypes.USEnglish);

				arCul.DateTimeFormat.Calendar=h;
			
			}
		
			/// <summary>
			/// Check if string is hijri date and then return true 
			/// </summary>
			/// <param name="hijri"></param>
			/// <returns></returns>
			public bool IsHijri(string hijri)
			{
				if (hijri.Length<=0)
				{
				
					MessageBox.Show("IsHijri Error: Date String is Empty");
					return false;
				}
				try
				{	
					DateTime tempDate=DateTime.ParseExact(hijri,allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					if (tempDate.Year>=startGreg && tempDate.Year<=endGreg)
						return true;
					else
						return false;
				}
				catch (Exception ex)
				{
					MessageBox.Show("IsHijri Error :"+hijri.ToString()+"\n"+ex.Message);
					return false;
				}

			}
			/// <summary>
			/// Check if string is Gregorian date and then return true 
			/// </summary>
			/// <param name="greg"></param>
			/// <returns></returns>
			public bool IsGreg(string greg)
			{
				if (greg.Length<=0)
				{
				
					MessageBox.Show("IsGreg :Date String is Empty");
					return false;
				}
				try
				{	
					DateTime tempDate=DateTime.ParseExact(greg,allFormats,enCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					if (tempDate.Year>=startGreg && tempDate.Year<=endGreg)
						return true;
					else
						return false;
				}
				catch (Exception ex)
				{
					MessageBox.Show("IsGreg Error :"+greg.ToString()+"\n"+ex.Message);
					return false;
				}

			}

			/// <summary>
			/// Return Formatted Hijri date string 
			/// </summary>
			/// <param name="date"></param>
			/// <param name="format"></param>
			/// <returns></returns>
			public string FormatHijri(string date ,string format)
			{
				if (date.Length<=0)
				{
				
					MessageBox.Show("Format :Date String is Empty");
					return "";
				}
				try
				{					   
					DateTime tempDate=DateTime.ParseExact(date,allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					return tempDate.ToString(format,arCul.DateTimeFormat);
							
				}
				catch (Exception ex)
				{
					MessageBox.Show("Date :\n"+ex.Message);
					return "";
				}

			}
			/// <summary>
			/// Returned Formatted Gregorian date string
			/// </summary>
			/// <param name="date"></param>
			/// <param name="format"></param>
			/// <returns></returns>
			public string FormatGreg(string date ,string format)
			{
				if (date.Length<=0)
				{
				
					MessageBox.Show("Format :Date String is Empty");
					return "";
				}
				try
				{
					DateTime tempDate=DateTime.ParseExact(date,allFormats,enCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					return tempDate.ToString(format,enCul.DateTimeFormat);
							
				}
				catch (Exception ex)
				{
					MessageBox.Show("Date :\n"+ex.Message);
					return "";
				}

			}
			/// <summary>
			/// Return Today Gregorian date and return it in yyyy/MM/dd format
			/// </summary>
			/// <returns></returns>
			public string GDateNow()
			{
				try
				{
					return DateTime.Now.ToString("yyyy/MM/dd",enCul.DateTimeFormat);
				}
				catch (Exception ex)
				{
					MessageBox.Show("GDateNow :\n"+ex.Message);
					return "";
				}
			}
			/// <summary>
			/// Return formatted today Gregorian date based on your format
			/// </summary>
			/// <param name="format"></param>
			/// <returns></returns>
			public string GDateNow(string format)
			{
				try
				{
					return DateTime.Now.ToString(format,enCul.DateTimeFormat);
				}
				catch (Exception ex)
				{
					MessageBox.Show("GDateNow :\n"+ex.Message);
					return "";
				}
			} 
		
			/// <summary>
			/// Return Today Hijri date and return it in yyyy/MM/dd format
			/// </summary>
			/// <returns></returns>
			public string HDateNow()
			{
				try
				{
					return DateTime.Now.ToString("yyyy/MM/dd",arCul.DateTimeFormat);
				}
				catch (Exception ex)
				{
					MessageBox.Show("HDateNow :\n"+ex.Message);
					return "";
				}
			}
			/// <summary>
			/// Return formatted today hijri date based on your format
			/// </summary>
			/// <param name="format"></param>
			/// <returns></returns>

			public string HDateNow(string format)
			{
				try
				{
					return DateTime.Now.ToString(format,arCul.DateTimeFormat);
				}
				catch (Exception ex)
				{
					MessageBox.Show("HDateNow :\n"+ex.Message);
					return "";
				}
			
			}
		
			/// <summary>
			/// Convert Hijri Date to it's equivalent Gregorian Date
			/// </summary>
			/// <param name="hijri"></param>
			/// <returns></returns>
			public string HijriToGreg(string hijri)
			{
			
				if (hijri.Length<=0)
				{
				
					MessageBox.Show("HijriToGreg :Date String is Empty");
					return "";
				}
				try
				{
					DateTime tempDate=DateTime.ParseExact(hijri,allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					return tempDate.ToString("yyyy/MM/dd",enCul.DateTimeFormat);
				}
				catch (Exception ex)
				{
					MessageBox.Show("HijriToGreg :"+hijri.ToString()+"\n"+ex.Message);
					return "";
				}
			}
			/// <summary>
			/// Convert Hijri Date to it's equivalent Gregorian Date and return it in specified format
			/// </summary>
			/// <param name="hijri"></param>
			/// <param name="format"></param>
			/// <returns></returns>
			public string HijriToGreg(string hijri,string format)
			{
			
				if (hijri.Length<=0)
				{
				
					MessageBox.Show("HijriToGreg :Date String is Empty");
					return "";
				}
				try
				{
					DateTime tempDate=DateTime.ParseExact(hijri,allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					return tempDate.ToString(format,enCul.DateTimeFormat);
				
				}
				catch (Exception ex)
				{
					MessageBox.Show("HijriToGreg :"+hijri.ToString()+"\n"+ex.Message);
					return "";
				}
			}

		
			/// <summary>
			/// Convert Gregoian Date to it's equivalent Hijir Date
			/// </summary>
			/// <param name="greg"></param>
			/// <returns></returns>
			public string GregToHijri(string greg)
			{
			
				if (greg.Length<=0)
				{
				
					MessageBox.Show("GregToHijri :Date String is Empty");
					return "";
				}
				try
				{
					DateTime tempDate=DateTime.ParseExact(greg,allFormats,enCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					return tempDate.ToString("yyyy/MM/dd",arCul.DateTimeFormat);
				
				}
				catch (Exception ex)
				{
					MessageBox.Show("GregToHijri :"+greg.ToString()+"\n"+ex.Message);
					return "";
				}
			}
			/// <summary>
			/// Convert Hijri Date to it's equivalent Gregorian Date and return it in specified format
			/// </summary>
			/// <param name="greg"></param>
			/// <param name="format"></param>
			/// <returns></returns>
			public string GregToHijri(string greg,string format)
			{
			
				if (greg.Length<=0)
				{
				
					MessageBox.Show("GregToHijri :Date String is Empty");
					return "";
				}
				try
				{
				
					DateTime tempDate=DateTime.ParseExact(greg,allFormats,enCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					return tempDate.ToString(format,arCul.DateTimeFormat);
				
				}
				catch (Exception ex)
				{
					MessageBox.Show("GregToHijri :"+greg.ToString()+"\n"+ex.Message);
					return "";
				}
			}
		
			/// <summary>
			/// Return Gregrian Date Time as digit stamp
			/// </summary>
			/// <returns></returns>
			public string GTimeStamp()
			{
				return GDateNow("yyyyMMddHHmmss");
			}
			/// <summary>
			/// Return Hijri Date Time as digit stamp
			/// </summary>
			/// <returns></returns>
			public string HTimeStamp()
			{
				return HDateNow("yyyyMMddHHmmss");
			}

			/// <summary>
			/// Compare if the Hijri date between  other financial year and return True if within , False in not within
			/// </summary>
			/// <param name="dt">Data Table contain start date and end date ,,start date is the first column in table , end date is the second column in table</param>
			/// <param name="fromDate"></param>
			/// <param name="endDate"></param>
			/// <returns></returns>
		
		
			/// <summary>
			/// Compare two instaces of string date and return indication of thier values 
			/// </summary>
			/// <param name="d1"></param>
			/// <param name="d2"></param>
			/// <returns>positive d1 is greater than d2,negative d1 is smaller than d2, 0 both are equal</returns>
			public int Compare(string d1,string d2)
			{
				try
				{
					DateTime date1=DateTime.ParseExact(d1,allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					DateTime date2=DateTime.ParseExact(d2,allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
					return DateTime.Compare(date1,date2);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Compare :"+"\n"+ex.Message);
					return -1;
				}

			}

		
		
		#endregion
		//
		#region GregorianMonths

		//		function GregorianMonths(formelement)
		//		{
		//
		//			var monthsE=new Array(13);
		//															if(formelement.year.value < 1500)
		//																formelement.year.value=2004; 
		//			formelement.day.options.length=31;
		//			for (var j=0; j<31; j++)
		//			{
		//				formelement.day.options[j].text=j+1; 
		//				formelement.day.options[j].value=j+1;
		//			}
		//
		//			formelement.month.options.length=12;
		//
		//			for (var k=0; k<12; k++)
		//			{
		//		
		//				formelement.month.options[k].text=months[k]; 
		//				formelement.month.options[k].value=k+1;
		//				if(k==0)
		//				{
		//					formelement.month.options[0].selected="true";
		//				}
		//			}
		//		}


		#endregion //GregorianMonths
		//
		#region GregorianArabicMonths
		//		function GregorianArabicMonths(formelement)
		//		{
		//
		//			var months=new Array(13);
		//			months[0]="يناير"
		//				months[1]="فبراير"
		//					months[2]="مارس"
		//						months[3]="إبريل"
		//							months[4]="مايو"
		//								months[5]="يونيو"
		//									months[6]="يوليو"
		//										months[7]="أغسطس"
		//											months[8]="سبتمبر"
		//												months[9]="أكنوبر"
		//													months[10]="نوفمبر"
		//														months[11]="ديسمبر"
		//
		//															if(formelement.year.value < 1500)
		//																formelement.year.value=2004; 
		//			formelement.day.options.length=31;
		//			for (var j=0; j<31; j++)
		//			{
		//				formelement.day.options[j].text=j+1; 
		//				formelement.day.options[j].value=j+1;
		//			}
		//
		//			formelement.month.options.length=12;
		//
		//			for (var k=0; k<12; k++)
		//			{
		//		
		//				formelement.month.options[k].text=months[k]; 
		//				formelement.month.options[k].value=k+1;
		//				if(k==0)
		//				{
		//					formelement.month.options[0].selected="true";
		//				}
		//			}
		//		}
		//
		#endregion

		#region HijriMonths
		//		function HijriMonths(formelement)
		//		{
		//			var months=new Array(13);
		//			months[0]="Muharram"
		//				months[1]="Safar"
		//					months[2]="Rabi Al-Awwal"
		//						months[3]="Rabi Al-Akhar"
		//							months[4]="Jumada Al-Awwal"
		//								months[5]="Jumada Al-Akhirah"
		//									months[6]="Rajab"
		//										months[7]="Shaban"
		//											months[8]="Ramadan"
		//												months[9]="Shawwal"
		//													months[10]="Dhul-Qadah"
		//														months[11]="Dhul-Hijjah"
		//
		//															if(formelement.year.value > 1500)
		//																formelement.year.value=1425; 
		//			formelement.day.options.length=30;
		//			for (var j=0; j<30; j++)
		//			{
		//		
		//				formelement.day.options[j].text=j+1; 
		//				formelement.day.options[j].value=j+1;
		//			}
		//   
		//			formelement.month.options.length=12;
		//
		//			for (var k=0; k<12; k++)
		//			{
		//		
		//				formelement.month.options[k].text=months[k]; 
		//				formelement.month.options[k].value=k+1;
		//				if(k==0)
		//				{
		//					formelement.month.options[0].selected="true";
		//				}
		//			}
		//		}
		#endregion

		#region HijriArabicMonths
		private void HijriArabicMonths(Object formelement)
        {
		//
		//															if(formelement.year.value > 1500)
		//																formelement.year.value=1425; 
		//
		//			formelement.day.options.length=30;
		//			for (var j=0; j<30; j++)
		//			{
		//		
		//				formelement.day.options[j].text=j+1; 
		//				formelement.day.options[j].value=j+1;
		//			}
		//   
		//			formelement.month.options.length=12;
		//
		//			for (var k=0; k<12; k++)
		//			{
		//		
		//				formelement.month.options[k].text=months[k]; 
		//				formelement.month.options[k].value=k+1;
		//				if(k==0)
		//				{
		//					formelement.month.options[0].selected="true";
		//				}
		//			}
        }
		#endregion
	}
}
