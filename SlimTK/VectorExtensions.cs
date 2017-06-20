/*
* Copyright (c) 2007-2010 SlimDX Group
* Copyright (c) 2016 Jarl Gullberg
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;
using System.Globalization;
using OpenTK;

namespace SlimTK
{
	public static class VectorExtensions
	{
		/// <summary>
        /// Converts a <see cref="System.Numerics.Vector3"/> value to an equivalent
        /// <see cref="OpenTK.Vector3"/> value.
        /// </summary>
        /// <param name="vector">A Vector3f value.</param>
        /// <returns>The Vector3f as a Vector3.</returns>
        public static Vector3 AsOpenTKVector(this System.Numerics.Vector3 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Converts a <see cref="OpenTK.Vector3"/> value to an equivalent
        /// <see cref="System.Numerics.Vector3"/> value.
        /// </summary>
        /// <param name="vector">A Vector3 value.</param>
        /// <returns>The Vector3 as a Vector3f.</returns>
        public static System.Numerics.Vector3 AsSIMDVector(this Vector3 vector)
        {
            return new System.Numerics.Vector3 (vector.X, vector.Y, vector.Z);
        }

		/// <summary>
		/// Determines whether the specified <see cref="OpenTK.Vector3"/> is equal to this instance.
		/// </summary>
		/// <param name="other">The <see cref="OpenTK.Vector3"/> to compare with this instance.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="OpenTK.Vector3"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public static bool Equals(Vector3 vector, Vector3 other)
		{
			return (vector.X == other.X) && (vector.Y == other.Y) && (vector.Z == other.Z);
		}

		/// <summary>
		/// Determines whether the specified <see cref="OpenTK.Vector3"/> is equal to this instance.
		/// </summary>
		/// <param name="other">The <see cref="OpenTK.Vector3"/> to compare with this instance.</param>
		/// <param name="epsilon">The amount of error allowed.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="OpenTK.Vector3"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public static bool Equals(Vector3 vector, Vector3 other, float epsilon)
		{
			return ((float) Math.Abs(other.X - vector.X) < epsilon &&
			        (float) Math.Abs(other.Y - vector.Y) < epsilon &&
			        (float) Math.Abs(other.Z - vector.Z) < epsilon);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public static string ToString(this Vector3 vector, string format)
		{
			if (format == null)
			{
				return vector.ToString();
			}

			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2}", vector.X.ToString(format, CultureInfo.CurrentCulture),
				vector.Y.ToString(format, CultureInfo.CurrentCulture), vector.Z.ToString(format, CultureInfo.CurrentCulture));
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public static string ToString(this Vector3 vector, IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2}", vector.X, vector.Y, vector.Z);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public static string ToString(this Vector3 vector, string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return vector.ToString(formatProvider);
			}

			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2}", vector.X.ToString(format, formatProvider),
				vector.Y.ToString(format, formatProvider), vector.Z.ToString(format, formatProvider));
		}
	}
}