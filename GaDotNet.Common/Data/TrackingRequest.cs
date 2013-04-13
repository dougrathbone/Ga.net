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
		public string AnalyticsAccountCode;
		public string PageTitle;
		public string PageDomain;
		public string PageUrl;
		public string ReferralSource = "(direct)";
		public string Medium = "(none)";
		public string Campaign = "(direct)";

		public GoogleEvent TrackingEvent;
		public GoogleTransaction TrackingTransaction;

		private delegate void Action<T1, T2> (T1 arg1, T2 arg2);
		private readonly string timeStampCurrent = GoogleHashHelper.ConvertToUnixTimestamp (DateTime.Now).ToString ();
		private const string visitCount = "2";

		protected internal TrackingRequest()
		{
		}

		public Uri TrackingGifUri
		{
			get { return new Uri (getTrackingGifURL ()); }
		}

		private int getDomainHash()
		{
			if (PageDomain == null)
				return 0;

			// converted from the google domain hash code listed here:
			// http://www.google.com/support/forum/p/Google+Analytics/thread?tid=626b0e277aaedc3c&hl=en
			int a = 1;
			int c = 0;
			int h;

			a = 0;
			for (h = PageDomain.Length - 1; h >= 0; h--)
			{
				int intCharacter = (int)char.Parse (PageDomain.Substring (h, 1));
				a = (a << 6 & 268435455) + intCharacter + (intCharacter << 14);
				c = a & 266338304;
				a = c != 0 ? a ^ c >> 21 : a;
			}
			return a;
		}

		private string getUtmcCookieString()
		{
			int domainHash = getDomainHash ();

			string utma = String.Format ("{0}.{1}.{2}.{3}.{4}.{5}",
				domainHash,
				new Random ().Next (1000000000),
				timeStampCurrent,
				timeStampCurrent,
				timeStampCurrent,
				visitCount);

			//referral informaiton
			string utmz = String.Format ("{0}.{1}.{2}.{3}.utmcsr={4}|utmccn={5}|utmcmd={6}",
				domainHash,
				timeStampCurrent,
				"1",
				"1",
				ReferralSource,
				Campaign,
				Medium);

			//return String.Format("__utma%3D{0}.{1}.{2}.{3}.{4}.{5}",)))
			string utmcc = String.Format ("__utma={0};+__utmz={1};",
				utma,
				utmz);

			return (Uri.EscapeDataString (utmcc));
		}

		private string getTrackingGifURL()
		{
			// REQUEST URL FORMAT:
			// http://www.google-analytics.com/__utm.gif?utmwv=4.6.5&utmn=488134812&utmhn=facebook.com&utmcs=UTF-8&utmsr=1024x576&utmsc=24-bit&utmul=en-gb&utmje=0&utmfl=10.0%20r42&utmdt=Facebook%20Contact%20Us&utmhid=700048481&utmr=-&utmp=%2Fwebdigi%2Fcontact&utmac=UA-3659733-5&utmcc=__utma%3D155417661.474914265.1263033522.1265456497.1265464692.6%3B%2B__utmz%3D155417661.1263033522.1.1.utmcsr%3D(direct)%7Cutmccn%3D(direct)%7Cutmcmd%3D(none)%3B

			var paramList = new List<KeyValuePair<string, string>>();

			// Helper functions
			var addKvp = ((Action<string, string>) ((k, v) =>
				paramList.Add (new KeyValuePair<string, string> (k, v))));
			var addEsc = ((Action<string, string>) ((k, v) =>
				addKvp (k, Uri.EscapeDataString (v))));
			var addDec = ((Action<string, Decimal>) ((k, v) =>
				addKvp (k, v.ToString("#.##"))));

			var pageTitleSafe = PageTitle != null
				? Uri.EscapeDataString (PageTitle)
				: string.Empty;

			var random = new Random();
			var utmhidRandom = random.Next (1000000000).ToString();
			var utmnRandom = random.Next (1000000000).ToString();

			addKvp ("utmwv", "4.7.2");				// Analytics version
			addKvp ("utmn", utmnRandom);			// Random request number
			addKvp ("utmhn", PageDomain);           // Your domain name
			addKvp ("utmcs", "UTF-8");              // Document encoding
			addKvp ("utmsr", "-");                  // Screen Resolution
			addKvp ("utmsc", "-");                  // Screen Resolution
			addKvp ("utmul", "-");                  // user language
			addKvp ("utmje", "0");                  // java enabled or not
			addKvp ("utmfl", "-");                  // user flash version
			addEsc ("utmdt", pageTitleSafe);		// page title
			addKvp ("utmhid", utmhidRandom);		// page title
			addKvp ("utmr", "-");					// referrer URL
			addKvp ("utmp", PageUrl);				// document page URL (relative to root)
			addKvp ("utmac", AnalyticsAccountCode); // Your GA account code
			addKvp ("utmcc", getUtmcCookieString());// cookie string (encoded)

			if (TrackingEvent != null) {
				//taken from http://code.google.com/apis/analytics/docs/tracking/gaTrackingTroubleshooting.html
				var eventString = String.Format ("5({0}*{1}*{2})({3}",
					TrackingEvent.Category,
					TrackingEvent.Action,
					TrackingEvent.Label,
					TrackingEvent.Value);

				addKvp ("utme", Uri.EscapeDataString (eventString));
				addKvp ("utmt", "event");
			}

			if (TrackingTransaction != null) {
				//taken from http://code.google.com/apis/analytics/docs/tracking/gaTrackingTroubleshooting.html
				addEsc ("utmipn", TrackingTransaction.ProductName);				//add product name
				addEsc ("utmipc", TrackingTransaction.ProductSku);				//add product code/SKU
				addEsc ("utmiva", TrackingTransaction.ProductVariant);			//add unit variation (ie Red)
				addDec ("utmipr", TrackingTransaction.UnitPrice);				//add unit price
				addKvp ("utmiqt", TrackingTransaction.Quantity.ToString ());	//add quantity
				addEsc ("utmtci", TrackingTransaction.City);					//add quantity
				addEsc ("utmtco", TrackingTransaction.Country);					//add billing country
				addKvp ("utmtid", TrackingTransaction.OrderID);					//add order ID
				addDec ("utmtsp", TrackingTransaction.ShippingCost);			//add shipping cost
				addDec ("utmtto", TrackingTransaction.TotalCost);				//add transaction total
				addDec ("utmttx", TrackingTransaction.TaxCost);					//add tax total
				addKvp ("utmt", "transaction");
			}

			//build final param string
			var GaParams = new StringBuilder();
			foreach (var pair in paramList) {
				GaParams.Append (String.Format ("{0}={1}&", pair.Key, pair.Value));
			}

			//cut off trailing ampersand
			string paramsFinal = GaParams.ToString ();
			paramsFinal = paramsFinal.Substring (0, paramsFinal.Length - 1);

			//return the google gif plus all our params
			return "http://www.google-analytics.com/__utm.gif?" + paramsFinal;
		}
	}
}
