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
using System.Threading;

namespace GaDotNet.Common.Data
{
	/// <summary>
	/// A Google Analytics event for tracking purposes.
	/// </summary>
	public class GoogleEvent
	{
		public string Category { get; private set; }

		public string Action { get; private set; }

		public string Label { get; private set; }

		public int? Value { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GoogleEvent"/> class.
		/// </summary>
		/// <param name="category">The event category.</param>
		/// <param name="action">The event action.</param>
		/// <param name="label">The event label.</param>
		/// <param name="value">The event value.</param>
		public GoogleEvent(string category, string action, string label, int? value)
		{
			Category = category;

			Action = action;

			Label = label;

			Value = value;

			Validate();
		}

		/// <summary>
		/// Validates this instance.
		/// </summary>
		public void Validate()
		{
			if (String.IsNullOrEmpty(Category))
			{
				throw new Exception("'Category' is a required field");
			}
			if (String.IsNullOrEmpty(Action))
			{
				throw new Exception("'Action' is a required field");
			}
			if (String.IsNullOrEmpty(Label))
			{
				throw new Exception("'Label' is a required field");
			}
			if (Value!=null)
			{
				throw new Exception("'Value' is a required field");
			}
		}
	}
}
