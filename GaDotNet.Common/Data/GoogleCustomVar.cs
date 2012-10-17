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
    public class GoogleCustomVar
    {
        public string Name { get; private set; }

        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleCustomVar" /> class.
        /// </summary>
        /// <param name="name">The name: This is a string that identifies the custom variable and appears in the top-level Custom Variables report 
        /// of the Analytics reports.</param>
        /// <param name="value">The value: This is a string that is paired with a name. You can pair a number of values with a custom variable name. 
        /// The value appears in the table list of the UI for a selected variable name. Typically, you will have two 
        /// or more values for a given name. For example, you might define a custom variable name gender and supply 
        /// male and female as two possible values.</param>
        public GoogleCustomVar(string name, string value)
        {
            Name = name;

            Value = value;

            Validate();
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            if (String.IsNullOrEmpty(Name))
            {
                throw new Exception("'Name' is a required field");
            }
            if (String.IsNullOrEmpty(Value))
            {
                throw new Exception("'Value' is a required field");
            }
        }
    }
}
