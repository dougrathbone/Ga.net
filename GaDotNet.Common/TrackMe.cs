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

using System.Web;

namespace GaDotNet.Common
{
	public class TrackMe : IHttpHandler
	{
		#region IHttpHandler Members

		public bool IsReusable
		{
			get { return true; }
		}

		/// <summary>
		/// Http Handler for sending custom tracking gifs to google analytics
		//  Takes in the following querystring elements:
		//  "pagetitle" = Page title
		//  "domain" = Domain (usually facebook.com)
		//  "ua" = Google analytics account code
		//  "url" = URL of page to track (format is from root: "/default.htm)
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
		public void ProcessRequest(HttpContext context)
		{
			// takes in the following querystring elements:
			// "pagetitle" = Page title
			// "domain" = Domain (usually facebook.com)
			// "ua" = Google analytics account code
			// "url" = URL of page to track (format is from root: "/default.htm)

			Common.GoogleTracking.TrackPageViewWithImage(context);
		}


		#endregion
	}
}
