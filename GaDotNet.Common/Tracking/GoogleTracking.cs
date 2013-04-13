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
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using GaDotNet.Common.Data;
using GaDotNet.Common.Helpers;

namespace GaDotNet.Common
{
	public static class GoogleTracking
	{
		/// <summary>
		/// Tracks the page view  with GA and stream a GIF image
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="analyticsCode">Analytics code in the form UA-XXXXXX-X</param>
		public static void TrackPageViewWithImage (HttpContext context, string analyticsCode)
		{
			TrackingRequest request = new RequestFactory (analyticsCode)
				.BuildRequest(context);

			FireTrackingEvent(request);
			ShowTrackingImage(context);

		}

		/// <summary>
		/// Tracks the page view and streams a GIF image.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="pageView">The page view.</param>
		/// <param name="analyticsCode">Analytics code in the form UA-XXXXXX-X</param>
		public static void TrackPageViewWithImage (HttpContext context, GooglePageView pageView, string analyticsCode)
		{
			TrackingRequest request = new RequestFactory (analyticsCode)
				.BuildRequest(pageView);

			FireTrackingEvent(request);
			ShowTrackingImage(context);
		}

		private static void ShowTrackingImage (HttpContext context)
		{
			context.Response.ContentType = "image/gif";
			context.Response.TransmitFile(context.Server.MapPath("spacer.gif"));
			context.Response.End();
		}

		/// <summary>
		/// Fires the tracking event with Google Analytics
		/// </summary>
		/// <param name="request">The request.</param>
		public static void FireTrackingEvent (TrackingRequest request)
		{
			//Create a request for the Google Analytics GIF
            var gifRequest = WebRequest
				.Create(request.TrackingGifUri);

            gifRequest.BeginGetResponse(r =>
			{
				//ignore the response
	            try { gifRequest.EndGetResponse (r); }
                catch {
					//suppress error
				}
            }, null);
		}        
	}
}
