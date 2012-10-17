/*
 * .NET Google Analytics Tracker
 * Modifications by Erik Weiss
 * Copyright 2012 The Nerdery
 * http://www.nerdery.com/
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
    public class GoogleUserTiming
    {
        public string Category { get; private set; }

        public string Variable { get; private set; }

        public int Time { get; private set; }

        public string Label { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleUserTiming" /> class.
        /// </summary>
        /// <param name="category">The category: A string for categorizing all user timing variables into logical groups for easier reporting purposes. 
        /// For example you might use value of jQuery if you were tracking the time it took to load that particular 
        /// JavaScript library.</param>
        /// <param name="variable">The variable: A string to indicate the name of the action of the resource being tracked. For example you might use 
        /// the value of JavaScript Load if you wanted to track the time it took to load the jQuery JavaScript library. 
        /// Note that same variables can be used across multiple categories to track timings for an event common to 
        /// these categories such as Javascript Load and Page Ready Time, etc.</param>
        /// <param name="time">The time: The number of milliseconds in elapsed time to report to Google Analytics. If the jQuery library took 
        /// 20 milliseconds to load, then you would send the value of 20.</param>
        /// <param name="label">The label: A string that can be used to add flexibility in visualizing user timings in the reports. Labels can 
        /// also be used to focus on different sub experiments for the same category and variable combination. 
        /// For example if we loaded jQuery from the Google Content Delivery Network, we would use the value of Google CDN.</param>
        public GoogleUserTiming(string category, string variable, int time, string label)
        {
            Category = category;

            Variable = variable;

            Time = time;

            Label = label;
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
            if (String.IsNullOrEmpty(Variable))
            {
                throw new Exception("'Variable' is a required field");
            }
            if (Time < 0)
            {
                throw new Exception("'Time' is a required field");
            }
            if (String.IsNullOrEmpty(Label))
            {
                throw new Exception("'Label' is a required field");
            }
        }
    }
}
