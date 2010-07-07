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
using System.Security.Policy;
using System.Text;

namespace GaDotNet.Common.Data
{
	public class GoogleTransaction
	{
		public string ProductName { get; set; }

		public string ProductSku { get; set; }

		public string ProductVariant { get; set; }

		public decimal UnitPrice { get; set; }

		public int Quantity { get; set; }
		
		public string OrderID { get; set; }

		public string Affiliation { get; set; }

		public decimal TotalCost { get; set; }

		public decimal TaxCost { get; set; }

		public decimal ShippingCost { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string Country { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GoogleTransaction"/> class.
		/// </summary>
		/// <param name="productName">Name of the product.</param>
		/// <param name="productSku">The product sku.</param>
		/// <param name="orderID">The order ID. (required)</param>
		/// <param name="affiliation">The affiliation. (required)</param>
		/// <param name="totalCost">The total cost. (required)</param>
		/// <param name="taxCost">The tax cost. (required)</param>
		/// <param name="shippingCost">The shipping cost (required).</param>
		/// <param name="city">The city. (required)</param>
		/// <param name="state">The state.</param>
		/// <param name="country">The country. (required)</param>
		public GoogleTransaction(string productName, string productSku, string orderID, string affiliation, 
			decimal totalCost, decimal taxCost, decimal shippingCost, string city, string state, string country)
		{
			ProductName = productName;

			ProductSku = productSku;

			OrderID = orderID;

			Affiliation = affiliation;

			TotalCost = totalCost;

			TaxCost = taxCost;

			ShippingCost = shippingCost;

			City = city;

			State = state;

			Country = country;

			Validate();
		}

		/// <summary>
		/// Validates this instance.
		/// </summary>
		public void Validate()
		{
			if (String.IsNullOrEmpty(OrderID))
			{
				throw new Exception("'OrderID' is a required field");
			}
			if (String.IsNullOrEmpty(Affiliation))
			{
				throw new Exception("'Affiliation' is a required field");
			}
			if (String.IsNullOrEmpty(City))
			{
				throw new Exception("'City' is a required field");
			}
			if (String.IsNullOrEmpty(State))
			{
				throw new Exception("'State' is a required field");
			}
			if (String.IsNullOrEmpty(Country))
			{
				throw new Exception("'Country' is a required field");
			}
		}
	}
}
