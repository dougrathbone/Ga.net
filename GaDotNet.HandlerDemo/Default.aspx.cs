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
	public partial class Demo : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnPageSubmit_Click (object sender, EventArgs e)
		{
			var pageView = new GooglePageView (
				txtPageTitle.Text,
				txtPageDomainName.Text,
				txtPageURL.Text);

			TrackingRequest request = new RequestFactory ().BuildRequest (pageView);
			GoogleTracking.FireTrackingEvent(request);

			divAction.InnerText = "Page view successfully tracked";
			divAction.Visible = true;
		}


		#region Under Development & Testing
		//protected void btnEventSubmit_Click(object sender, EventArgs e)
		//{
		//    GoogleEvent eventToTrack = new GoogleEvent(txtEventCategory.Text, 
		//        txtEventAction.Text, 
		//        txtEventLabel.Text, 
		//        int.Parse(txtEventValue.Text));

		//    TrackingRequest request = new RequestFactory().BuildRequest(eventToTrack);
		//    GoogleTracking.FireTrackingEvent(request);

		//    divAction.InnerText = "Event successfully tracked";
		//    divAction.Visible = true;
		//}

		//protected void btnTransactionSubmit_Click(object sender, EventArgs e)
		//{
		//    GoogleTransaction transaction = new GoogleTransaction(txtTransactionProdName.Text,
		//        txtTransactionProdSku.Text,
		//        txtTransactionOrderID.Text,
		//        txtTransactionAffiliation.Text,
		//        decimal.Parse(txtTransactionTotalCost.Text),
		//        decimal.Parse(txtTransactionTaxCost.Text),
		//        decimal.Parse(txtTransactionShippingCost.Text),
		//        txtTransactionCity.Text,
		//        txtTransactionState.Text,
		//        txtTransactionCounty.Text
		//        );

		//    TrackingRequest request = new RequestFactory().BuildRequest(transaction);
		//    GoogleTracking.FireTrackingEvent(request);

		//    divAction.InnerText = "Transaction successfully tracked";
		//    divAction.Visible = true;
		//}
		#endregion
	}
}