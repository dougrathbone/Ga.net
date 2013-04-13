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

namespace GaDotNet.Common.Helpers
{
	public static class GoogleHashHelper
	{
		/// <summary>
		/// Converts a DateTime to a UNIX timestamp in local time.
		/// </summary>
		/// <param name="value">The DateTime to convert to unix time</param>
		/// <returns>Timestamp in local unix time</returns>
		public static uint ConvertToUnixTimestamp (DateTime value)
		{
			// Unix time is seconds since August 1st, 1970
			TimeSpan span = (value - new DateTime (1970, 1, 1).ToLocalTime());
			return (uint)span.TotalSeconds;
		} 
	}
}
