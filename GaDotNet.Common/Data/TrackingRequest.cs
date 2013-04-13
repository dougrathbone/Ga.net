/*
 * Facebook Google Analytics Tracker
 * Copyright 2010 Doug Rathbone
 * http://www.diaryofaninja.com
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Text;
using GaDotNet.Common.Helpers;

namespace GaDotNet.Common.Data
{
	/// <summary>
	/// The data class for the Facbook Google Analytics request
	/// Took data from:
	/// - http://ga.webdigi.co.uk/
	/// - http://www.mattromaine.com/projects/code/AnalyticsCode.html
	/// - http://www.google.com/support/forum/p/Google+Analytics/thread?tid=626b0e277aaedc3c&hl=en
	/// </summary>
	public class TrackingRequest
	{
		public string Referrer;
		public string ScreenColourDepth;
		public string AcceptedCharSet;
		public string AcceptedLanguage;

		public string PageTitle;
		public string PageDomain;
		public string PageUrl;

		public string ReferralSource = "(direct)";
		public string Medium = "(none)";
		public string Campaign = "(direct)";

		public GoogleEvent TrackingEvent;
		public GoogleTransaction TrackingTransaction;


		public string AnalyticsAccountCode;

		//private string rand1 = new Random().Next(10000).ToString();
		private string timeStampCurrent = GoogleHashHelper.ConvertToUnixTimestamp(DateTime.Now).ToString();
		private string visitCount = "2";		

		protected internal TrackingRequest()
		{
			
		}

		#region Calculated Values

		private int DomainHash
		{
			get
			{
				if (PageDomain != null)
				{
					// converted from the google domain hash code listed here:
					// http://www.google.com/support/forum/p/Google+Analytics/thread?tid=626b0e277aaedc3c&hl=en
					int a = 1;
					int c = 0;
					int h;
					char chrCharacter;
					int intCharacter;

					a = 0;
					for (h = PageDomain.Length - 1; h >= 0; h--)
					{
						chrCharacter = char.Parse(PageDomain.Substring(h, 1));
						intCharacter = (int) chrCharacter;
						a = (a << 6 & 268435455) + intCharacter + (intCharacter << 14);
						c = a & 266338304;
						a = c != 0 ? a ^ c >> 21 : a;
					}

					return a;
				}
				return 0;
			}
		}
		
		private string UtmtRequestType
		{
			get
			{
				if (TrackingEvent != null)
					return "event";
				if (TrackingTransaction != null)
					return "transaction";

				return "page";
			}
		}

		//the cookie collection string (we fake it)
		private string UtmcCookieString  {
			get
			{

				Random randomNumber = new Random();



				string utma = String.Format("{0}.{1}.{2}.{3}.{4}.{5}",
				                            DomainHash,
				                            int.Parse(randomNumber.Next(1000000000).ToString()),
				                            timeStampCurrent,
				                            timeStampCurrent,
				                            timeStampCurrent,
				                            visitCount);

				//referral informaiton
				string utmz = String.Format("{0}.{1}.{2}.{3}.utmcsr={4}|utmccn={5}|utmcmd={6}",
				                            DomainHash,
				                            timeStampCurrent,
											"1",
				                            "1",
											ReferralSource,
											Campaign,
											Medium);

				//return String.Format("__utma%3D{0}.{1}.{2}.{3}.{4}.{5}",)))
				string utmcc = Uri.EscapeDataString(String.Format("__utma={0};+__utmz={1};",
				                                                  utma,
				                                                  utmz
				                                    	));

				return (utmcc);
			}
		}

		public Uri TrackingGifUri { get { return new Uri(TrackingGifURL); } }
		
		public string TrackingGifURL
		{
			get
			{
				Random randomNumber = new Random();

				// REQUEST URL FORMAT:
				// http://www.google-analytics.com/__utm.gif?utmwv=4.6.5&utmn=488134812&utmhn=facebook.com&utmcs=UTF-8&utmsr=1024x576&utmsc=24-bit&utmul=en-gb&utmje=0&utmfl=10.0%20r42&utmdt=Facebook%20Contact%20Us&utmhid=700048481&utmr=-&utmp=%2Fwebdigi%2Fcontact&utmac=UA-3659733-5&utmcc=__utma%3D155417661.474914265.1263033522.1265456497.1265464692.6%3B%2B__utmz%3D155417661.1263033522.1.1.utmcsr%3D(direct)%7Cutmccn%3D(direct)%7Cutmcmd%3D(none)%3B

				var pageTitleSafe = PageTitle != null
					? Uri.EscapeDataString (PageTitle)
					: string.Empty;

				List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>
				{
					new KeyValuePair<string,string>("utmwv","4.7.2"),										// Analytics version
					new KeyValuePair<string,string>("utmn",randomNumber.Next(1000000000).ToString()),	// Random request number
					new KeyValuePair<string,string>("utmhn",PageDomain),								// Your domain name
					new KeyValuePair<string,string>("utmcs","UTF-8"),									// Document encoding
					new KeyValuePair<string,string>("utmsr","-"),										// Screen Resolution
					new KeyValuePair<string,string>("utmsc","-"),										// Screen Resolution
					new KeyValuePair<string,string>("utmul","-"),										// user language
					new KeyValuePair<string,string>("utmje","0"),										// java enabled or not
					new KeyValuePair<string,string>("utmfl","-"),										// user flash version
					new KeyValuePair<string,string>("utmdt",Uri.EscapeDataString (pageTitleSafe)),				// page title
					new KeyValuePair<string,string>("utmhid",randomNumber.Next(1000000000).ToString()),										// page title
					new KeyValuePair<string,string>("utmr","-"),											// referrer URL
					new KeyValuePair<string,string>("utmp",PageUrl),									// document page URL (relative to root)
					new KeyValuePair<string,string>("utmac",AnalyticsAccountCode),						// Your GA account code
					new KeyValuePair<string,string>("utmcc",UtmcCookieString),					// cookie string (encoded)
					new KeyValuePair<string,string>("utmt",UtmtRequestType)						// type of request (page view or event etc)
				};

				//check if our tracking event is null and if not add to the params
				if (TrackingEvent!=null)
				{
					//taken from http://code.google.com/apis/analytics/docs/tracking/gaTrackingTroubleshooting.html
					string eventString = String.Format("5({0}*{1}*{2})({3}",
						TrackingEvent.Category,
						TrackingEvent.Action,
						TrackingEvent.Label,
						TrackingEvent.Value
						);
					paramList.Add(new KeyValuePair<string, string>("utme", Uri.EscapeDataString(eventString)));
				}

				//check if the transaction object is null and if not add the transaction params
				if (TrackingTransaction!=null)
				{
					//taken from http://code.google.com/apis/analytics/docs/tracking/gaTrackingTroubleshooting.html

					//add product name
					paramList.Add(new KeyValuePair<string, string>("utmipn", Uri.EscapeDataString(TrackingTransaction.ProductName)));

					//add product code/SKU
					paramList.Add(new KeyValuePair<string, string>("utmipc", Uri.EscapeDataString(TrackingTransaction.ProductSku)));

					//add unit variation (ie Red)
					paramList.Add(new KeyValuePair<string, string>("utmiva", Uri.EscapeDataString(TrackingTransaction.ProductVariant)));

					//add unit price
					paramList.Add(new KeyValuePair<string, string>("utmipr", TrackingTransaction.UnitPrice.ToString("#.##")));

					//add quantity
					paramList.Add(new KeyValuePair<string, string>("utmiqt", TrackingTransaction.Quantity.ToString()));

					//add billing city
					paramList.Add(new KeyValuePair<string, string>("utmtci", Uri.EscapeDataString(TrackingTransaction.City)));
					
					//add billing country
					paramList.Add(new KeyValuePair<string, string>("utmtco", Uri.EscapeDataString(TrackingTransaction.Country)));

					// add order ID
					paramList.Add(new KeyValuePair<string, string>("utmtid", TrackingTransaction.OrderID));

					//add shipping cost
					paramList.Add(new KeyValuePair<string, string>("utmtsp", TrackingTransaction.ShippingCost.ToString("#.##")));

					//add transaction total
					paramList.Add(new KeyValuePair<string, string>("utmtto", TrackingTransaction.TotalCost.ToString("#.##")));

					//add tax total
					paramList.Add(new KeyValuePair<string, string>("utmttx", TrackingTransaction.TaxCost.ToString("#.##")));
				}





				//get final param string
				StringBuilder GaParams = new StringBuilder();
				foreach (KeyValuePair<string, string> pair in paramList)
				{
					GaParams.Append(String.Format("{0}={1}&", pair.Key, pair.Value));
				}
				string paramsFinal = GaParams.ToString();
				paramsFinal = paramsFinal.Substring(0, paramsFinal.Length - 1);


				//return the google gif plus all our params
				return String.Format("http://www.google-analytics.com/__utm.gif?{0}",
									 paramsFinal);
			}
		}
		

		#endregion
	}
}
