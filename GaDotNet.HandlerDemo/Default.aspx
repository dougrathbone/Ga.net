<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GaDotNet.HandlerDemo.Demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<b>GoogleAnalytics.Net Demo</b><br />
		<br />
		The purpose of this page is to see in the code behind how i fire these requests
		through code.<br />
		<br />
		Forgive the use of tables... its a demo page :)<br />
		<br />
		<div id="divAction" runat="server" style="padding: 5px; border: solid 1px DarkGreen;
			background-color: LightGreen; color: White" visible="false">
		</div>
		&nbsp;<table style="width: 100%;">
			<tr valign="top">
				<td>
					<b>Submit page view</b><br />
					<table>
						<tr>
							<td valign="top">
								Domain Name:
							</td>
							<td>
								<asp:TextBox ID="txtPageDomainName" runat="server" ValidationGroup="page"></asp:TextBox>
								<asp:RequiredFieldValidator ID="requiredPageDomain" runat="server" ValidationGroup="page" ControlToValidate="txtPageDomainName">*</asp:RequiredFieldValidator>
								<br />
								Needs to be your GA account domain
							</td>
						</tr><tr>
							<td valign="top">
								Page Title
							</td>
							<td>
								<asp:TextBox ID="txtPageTitle" runat="server" ValidationGroup="page"></asp:TextBox>
								<asp:RequiredFieldValidator ID="requiredPageTitle" runat="server" ValidationGroup="page" ControlToValidate="txtPageTitle">*</asp:RequiredFieldValidator>
								<br />
								Your page title
							</td>
						</tr>
						
						<tr>
							<td valign="top">
								Page URL
							</td>
							<td>
								<asp:TextBox ID="txtPageURL" runat="server" ValidationGroup="page"></asp:TextBox>
								<asp:RequiredFieldValidator ID="requiredPageURL" runat="server" ValidationGroup="page" ControlToValidate="txtPageURL">*</asp:RequiredFieldValidator>
								<br />
								relative to root (ie. /test.aspx)
							</td>
						</tr>
						<tr>
							<td>
								&nbsp;
							</td>
							<td>
								<asp:Button ID="btnPageSubmit" runat="server" Text="Send to GA" 
									OnClick="btnPageSubmit_Click" ValidationGroup="page" />
							</td>
						</tr>
					</table>
				</td>
								<td>
					<b>Submit event</b><br />
					<table>
					<tr>
							<td valign="top">
								Domain Name:
							</td>
							<td>
								<asp:TextBox ID="txtEventDomain" runat="server" ValidationGroup="event"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="event" ControlToValidate="txtEventDomain">*</asp:RequiredFieldValidator>
								<br />
								Needs to be your GA account domain
							</td>
						</tr>
						<tr>
							<td>
								Category
							</td>
							<td>
								<asp:TextBox ID="txtEventCategory" runat="server" ValidationGroup="event"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="event" ControlToValidate="txtEventCategory">*</asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td>
								Action
							</td>
							<td>
								<asp:TextBox ID="txtEventAction" runat="server" ValidationGroup="event"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="event" ControlToValidate="txtEventAction">*</asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td>
								Label
							</td>
							<td>
								<asp:TextBox ID="txtEventLabel" runat="server" ValidationGroup="event"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								Value
							</td>
							<td>
								<asp:TextBox ID="txtEventValue" runat="server" ValidationGroup="event"></asp:TextBox>
								<br />
								<a href="http://code.google.com/apis/analytics/docs/gaJS/gaJSApiEventTracking.html">
								Has to be Int </a>
							</td>
						</tr>
						<tr>
							<td>
								&nbsp;
							</td>
							<td>
								<asp:Button ID="btnEventSubmit" runat="server" Text="Send to GA" 
									onclick="btnEventSubmit_Click" ValidationGroup="event" />
							</td>
						</tr>
					</table>
				</td>
				<%--
				<td>
					<b>Submit transaction</b><br />
					<table>
						<tr>
							<td>
								Product Name
							</td>
							<td>
								<asp:TextBox ID="txtTransactionProdName" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								ProductSku
							</td>
							<td>
								<asp:TextBox ID="txtTransactionProdSku" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								ProductVariant
							</td>
							<td>
								<asp:TextBox ID="txtTransactionProdVariant" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								UnitPrice
							</td>
							<td>
								<asp:TextBox ID="txtTransactionProdUnitPrice" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								Quantity
							</td>
							<td>
								<asp:TextBox ID="txtTransactionQuantity" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								OrderID
							</td>
							<td>
								<asp:TextBox ID="txtTransactionOrderID" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								Affiliation
							</td>
							<td>
								<asp:TextBox ID="txtTransactionAffiliation" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								TotalCost
							</td>
							<td>
								<asp:TextBox ID="txtTransactionTotalCost" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								TaxCost
							</td>
							<td>
								<asp:TextBox ID="txtTransactionTaxCost" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								ShippingCost
							</td>
							<td>
								<asp:TextBox ID="txtTransactionShippingCost" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								City
							</td>
							<td>
								<asp:TextBox ID="txtTransactionCity" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								State
							</td>
							<td>
								<asp:TextBox ID="txtTransactionState" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								Country
							</td>
							<td>
								<asp:TextBox ID="txtTransactionCounty" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								&nbsp;
							</td>
							<td>
								<asp:Button ID="btnTransactionSubmit" runat="server" Text="Send to GA" 
									onclick="btnTransactionSubmit_Click" />
							</td>
						</tr>
					</table>
				</td>
				--%>
			</tr>
		</table>
	</div>
	</form>
</body>
</html>
