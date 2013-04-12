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

namespace GaDotNet.Common.Data
{
	/// <summary>
	/// A Google Analytics event for tracking purposes.
	/// </summary>
	public class GoogleEvent
	{
		public string DomainName { get; private set; }
		public string Category { get; private set; }
		public string Action { get; private set; }
		public string Label { get; private set; }
		public int? Value { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GoogleEvent"/> class.
		/// </summary>
		/// <param name="category">The event category.</param>
		/// <param name="action">The event action.</param>
		/// <param name="value">The event value.</param>
		/// <param name="label">The optional event label.</param>
		public GoogleEvent (string domainName, string category, string action,
			string label=null, int? value=null)
		{
			if (domainName == null) {
				throw new Exception ("'Category' is a required field");
			}
			if (category == null) {
				throw new Exception ("'Category' is a required field");
			}
			if (action == null) {
				throw new Exception ("'Action' is a required field");
			}

			DomainName = domainName;
			Category = category;
			Action = action;
			Label = label;
			Value = value;
		}
	}
}
