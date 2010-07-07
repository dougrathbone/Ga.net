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
using System.Text;

namespace GaDotNet.Common.Data
{
	public class GooglePageView
	{
		public string PageTitle { get; private set; }

		public string DomainName { get; private set; }

		public string Url { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GooglePageView"/> class.
		/// </summary>
		/// <param name="pageTitle">The page title. (required)</param>
		/// <param name="domainName">domain hostname ie www.yourdomain.com (required)</param>
		/// <param name="url">The URL. (required)</param>
		public GooglePageView(string pageTitle, string domainName, string url)
		{
			PageTitle = pageTitle;
			DomainName = domainName;
			Url = url;

			Validate();
		}

		/// <summary>
		/// Validates this instance.
		/// </summary>
		public void Validate()
		{
			if (String.IsNullOrEmpty(PageTitle))
			{
				throw new Exception("'PageTitle' is a required field");
			}
			if (String.IsNullOrEmpty(DomainName))
			{
				throw new Exception("'DomainName' is a required field");
			}
			if (String.IsNullOrEmpty(Url))
			{
				throw new Exception("'Url' is a required field");
			}
		}
	}
}
