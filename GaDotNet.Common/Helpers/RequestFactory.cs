/*
 * Facebook Google Analytics Tracker
 * Copyright 2010 Doug Rathbone
 * http://www.diaryofaninja.com
 * 
 * Modifications Copyright 2012 Erik Weiss
 * http://www.technicallyerik.com
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
using System.Linq;
using System.Text;
using System.Web;
using GaDotNet.Common.Data;
using GaDotNet.Common.Data;

namespace GaDotNet.Common.Helpers
{
	/// <summary>
	/// The TrackingRequest factory - this helps you build your request with whatever data
	/// </summary>
	public class RequestFactory
	{
		/// <summary>
		/// Builds the tracking request.
		/// </summary>
		/// <param name="context">The HTTP context.</param>
		/// <param name="urlToTrack">The URL to track.</param>
		/// <returns></returns>
		public TrackingRequest BuildRequest(HttpContext context)
		{
			var r = new TrackingRequest();

			r.PageTitle = context.Request.QueryString["pagetitle"];
			r.PageDomain = context.Request.QueryString["domain"];
			r.AnalyticsAccountCode = context.Request.QueryString["ua"] ?? ConfigurationSettings.GoogleAccountCode;
			r.PageUrl = context.Request.QueryString["url"];

			return r;
		}

		/// <summary>
		/// Builds the request from a page view request and the appSettings 'GoogleAnalyticsAccountCode'
		/// </summary>
		/// <param name="pageView">The page view.</param>
		/// <returns></returns>
        public TrackingRequest BuildRequest(GaDotNet.Common.Data.GooglePageView pageView, GaDotNet.Common.Data.GoogleUserTiming googleTiming = null, List<GaDotNet.Common.Data.GoogleCustomVar> customVariables = null)
		{
			var r = new TrackingRequest();

			r.PageTitle = pageView.PageTitle;
			r.PageDomain = pageView.DomainName;
			r.AnalyticsAccountCode = ConfigurationSettings.GoogleAccountCode;
			r.PageUrl = pageView.Url;
            r.CustomTiming = googleTiming;
            r.CustomVariables = customVariables;

			return r;
		}


		/// <summary>
		/// Builds the tracking request from a Google Event.
		/// </summary>
		/// <param name="googleEvent">The google event.</param>
		/// <returns></returns>
        public TrackingRequest BuildRequest(GaDotNet.Common.Data.GoogleEvent googleEvent, GaDotNet.Common.Data.GoogleUserTiming googleTiming = null, List<GaDotNet.Common.Data.GoogleCustomVar> customVariables = null)
		{
			var r = new TrackingRequest();
			
			r.AnalyticsAccountCode = ConfigurationSettings.GoogleAccountCode;
			r.TrackingEvent = googleEvent;
            r.CustomTiming = googleTiming;
            r.CustomVariables = customVariables;

			return r;
		}

		/// <summary>
		/// Builds the tracking request from a Google Transaction.
		/// </summary>
		/// <param name="googleTransaction">The google transaction.</param>
		/// <returns></returns>
		public TrackingRequest BuildRequest(GaDotNet.Common.Data.GoogleTransaction googleTransaction)
		{
			var r = new TrackingRequest();

			r.AnalyticsAccountCode = ConfigurationSettings.GoogleAccountCode;
			r.TrackingTransaction = googleTransaction;

			return r;
		}
	}
}
