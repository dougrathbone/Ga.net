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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GaDotNet.Common;
using GaDotNet.Common.Data;
using GaDotNet.Common.Helpers;

namespace GaDotNet.HandlerDemo
{
	public static class AccountID
	{
		public static string value = "UA-4040403-8";
	}

	public partial class Demo : System.Web.UI.Page
	{
		protected void btnPageSubmit_Click(object sender, EventArgs e)
		{
			GooglePageView pageView = new GooglePageView (
				txtPageTitle.Text,
				txtPageDomainName.Text,
				txtPageURL.Text);

			TrackingRequest request = new RequestFactory (ConfigurationSettings.GoogleAccountCode)
				.BuildRequest (pageView);
			GoogleTracking.FireTrackingEvent(request);

			divAction.InnerText = "Page view successfully tracked";
			divAction.Visible = true;
		}
		
		protected void btnEventSubmit_Click (object sender, EventArgs e)
		{
			int parsed;
			bool found = int.TryParse(txtEventValue.Text, out parsed);
			int? eventValue = found ? parsed : (int?)null;

			GoogleEvent eventToTrack = new GoogleEvent (
				txtEventDomain.Text,
				txtEventCategory.Text,
				txtEventAction.Text,
				txtEventLabel.Text,
				eventValue);

			TrackingRequest request = new RequestFactory (ConfigurationSettings.GoogleAccountCode)
				.BuildRequest (eventToTrack);
			GoogleTracking.FireTrackingEvent(request);

			divAction.InnerText = "Event successfully tracked";
			divAction.Visible = true;
		}
	}
}