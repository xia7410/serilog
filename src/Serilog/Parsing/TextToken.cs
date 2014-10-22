﻿// Copyright 2014 Serilog Contributors
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.IO;
using Serilog.Events;

namespace Serilog.Parsing
{
    /// <summary>
    /// A message template token representing literal text.
    /// </summary>
    public class TextToken : MessageTemplateToken
    {
        readonly string _text;

        /// <summary>
        /// Construct a <see cref="TextToken"/>.
        /// </summary>
        /// <param name="text">The text of the token.</param>
        /// <param name="startIndex">The token's start index in the template.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TextToken(string text, int startIndex = 0) : base(startIndex)
        {
            if (text == null) throw new ArgumentNullException("text");
            _text = text;
        }

        /// <summary>
        /// The token's length.
        /// </summary>
        public override int Length
        {
            get { return _text.Length; }
        }

        /// <summary>
        /// Render the token to the output.
        /// </summary>
        /// <param name="properties">Properties that may be represented by the token.</param>
        /// <param name="output">Output for the rendered string.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        public override void Render(IReadOnlyDictionary<string, LogEventPropertyValue> properties, TextWriter output, IFormatProvider formatProvider = null)
        {
            if (output == null) throw new ArgumentNullException("output");
            output.Write(Text);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            var tt = obj as TextToken;
            return tt != null && tt._text == _text;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return _text.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// The text of the token.
        /// </summary>
        public string Text
        {
            get { return _text; }
        }
    }
}