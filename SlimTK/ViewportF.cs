// Copyright (c) 2010-2014 OpenTK - Alexandre Mutel
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenTK;

namespace SlimTK
{
	/// <summary>
	/// Defines the viewport dimensions using float coordinates for (X,Y,Width,Height).
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct ViewportF : IEquatable<ViewportF>
	{
		/// <summary>
		/// Position of the pixel coordinate of the upper-left corner of the viewport.
		/// </summary>
		public float X;

		/// <summary>
		/// Position of the pixel coordinate of the upper-left corner of the viewport.
		/// </summary>
		public float Y;

		/// <summary>
		/// Width dimension of the viewport.
		/// </summary>
		public float Width;

		/// <summary>
		/// Height dimension of the viewport.
		/// </summary>
		public float Height;

		/// <summary>
		/// Gets or sets the minimum depth of the clip volume.
		/// </summary>
		public float MinDepth;

		/// <summary>
		/// Gets or sets the maximum depth of the clip volume.
		/// </summary>
		public float MaxDepth;

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewportF"/> struct.
		/// </summary>
		/// <param name="x">The x coordinate of the upper-left corner of the viewport in pixels.</param>
		/// <param name="y">The y coordinate of the upper-left corner of the viewport in pixels.</param>
		/// <param name="width">The width of the viewport in pixels.</param>
		/// <param name="height">The height of the viewport in pixels.</param>
		public ViewportF(float x, float y, float width, float height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
			this.MinDepth = 0f;
			this.MaxDepth = 1f;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewportF"/> struct.
		/// </summary>
		/// <param name="x">The x coordinate of the upper-left corner of the viewport in pixels.</param>
		/// <param name="y">The y coordinate of the upper-left corner of the viewport in pixels.</param>
		/// <param name="width">The width of the viewport in pixels.</param>
		/// <param name="height">The height of the viewport in pixels.</param>
		/// <param name="minDepth">The minimum depth of the clip volume.</param>
		/// <param name="maxDepth">The maximum depth of the clip volume.</param>
		public ViewportF(float x, float y, float width, float height, float minDepth, float maxDepth)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
			this.MinDepth = minDepth;
			this.MaxDepth = maxDepth;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewportF"/> struct.
		/// </summary>
		/// <param name="bounds">A bounding box that defines the location and size of the viewport in a render target.</param>
		public ViewportF(RectangleF bounds)
		{
			this.X = bounds.X;
			this.Y = bounds.Y;
			this.Width = bounds.Width;
			this.Height = bounds.Height;
			this.MinDepth = 0f;
			this.MaxDepth = 1f;
		}

		/// <summary>
		/// Gets the size of this resource.
		/// </summary>
		/// <value>The bounds.</value>
		public RectangleF Bounds
		{
			get { return new RectangleF(this.X, this.Y, this.Width, this.Height); }

			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ViewportF"/> is equal to this instance.
		/// </summary>
		/// <param name="other">The <see cref="ViewportF"/> to compare with this instance.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ViewportF"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public bool Equals(ref ViewportF other)
		{
			return MathUtil.NearEqual(this.X, other.X) &&
			       MathUtil.NearEqual(this.Y, other.Y) &&
			       MathUtil.NearEqual(this.Width, other.Width) &&
			       MathUtil.NearEqual(this.Height, other.Height) &&
			       MathUtil.NearEqual(this.MinDepth, other.MinDepth) &&
			       MathUtil.NearEqual(this.MaxDepth, other.MaxDepth);
		}

		/// <summary>
		/// Determines whether the specified <see cref="ViewportF"/> is equal to this instance.
		/// </summary>
		/// <param name="other">The <see cref="ViewportF"/> to compare with this instance.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ViewportF"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ViewportF other)
		{
			return Equals(ref other);
		}

		/// <summary>
		/// Determines whether the specified object is equal to this instance.
		/// </summary>
		/// <param name="obj">The object to compare with this instance.</param>
		/// <returns>
		/// <c>true</c> if the specified object is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (!(obj is ViewportF))
			{
				return false;
			}

			var strongValue = (ViewportF) obj;
			return Equals(ref strongValue);
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
		/// </returns>
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = this.X.GetHashCode();
				hashCode = (hashCode * 397) ^ this.Y.GetHashCode();
				hashCode = (hashCode * 397) ^ this.Width.GetHashCode();
				hashCode = (hashCode * 397) ^ this.Height.GetHashCode();
				hashCode = (hashCode * 397) ^ this.MinDepth.GetHashCode();
				hashCode = (hashCode * 397) ^ this.MaxDepth.GetHashCode();
				return hashCode;
			}
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(ViewportF left, ViewportF right)
		{
			return left.Equals(ref right);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(ViewportF left, ViewportF right)
		{
			return !left.Equals(ref right);
		}

		/// <summary>
		/// Retrieves a string representation of this object.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{{X:{0} Y:{1} Width:{2} Height:{3} MinDepth:{4} MaxDepth:{5}}}", this.X, this.Y, this.Width, this.Height, this.MinDepth, this.MaxDepth);
		}

		/// <summary>
		/// Projects a 3D vector from object space into screen space.
		/// </summary>
		/// <param name="source">The vector to project.</param>
		/// <param name="projection">The projection matrix.</param>
		/// <param name="view">The view matrix.</param>
		/// <param name="world">The world matrix.</param>
		/// <returns>The projected vector./returns>
		public Vector3 Project(Vector3 source, Matrix4 projection, Matrix4 view, Matrix4 world)
		{
			Matrix4 matrix = projection * view * world;

			Vector3 vector;
			Project(ref source, ref matrix, out vector);
			return vector;
		}

		/// <summary>
		/// Projects a 3D vector from object space into screen space.
		/// </summary>
		/// <param name="source">The vector to project.</param>
		/// <param name="matrix">A combined WorldViewProjection matrix.</param>
		/// <param name="vector">The projected vector.</param>
		public void Project(ref Vector3 source, ref Matrix4 matrix, out Vector3 vector)
		{
			Vector3.Transform(ref source, ref matrix, out vector);
			float a = (((source.X * matrix.M14) + (source.Y * matrix.M24)) + (source.Z * matrix.M34)) + matrix.M44;

			if (!MathUtil.IsOne(a))
			{
				vector = (vector / a);
			}

			vector.X = (((vector.X + 1f) * 0.5f) * this.Width) + this.X;
			vector.Y = (((-vector.Y + 1f) * 0.5f) * this.Height) + this.Y;
			vector.Z = (vector.Z * (this.MaxDepth - this.MinDepth)) + this.MinDepth;
		}

		/// <summary>
		/// Converts a screen space point into a corresponding point in world space.
		/// </summary>
		/// <param name="source">The vector to project.</param>
		/// <param name="projection">The projection matrix.</param>
		/// <param name="view">The view matrix.</param>
		/// <param name="world">The world matrix.</param>
		/// <returns>The unprojected Vector.</returns>
		public Vector3 Unproject(Vector3 source, Matrix4 projection, Matrix4 view, Matrix4 world)
		{
			Matrix4 matrix = projection * view * world;
			Matrix4.Invert(ref matrix, out matrix);

			Vector3 vector;
			Unproject(ref source, ref matrix, out vector);
			return vector;
		}

		/// <summary>
		/// Converts a screen space point into a corresponding point in world space.
		/// </summary>
		/// <param name="source">The vector to project.</param>
		/// <param name="matrix">An inverted combined WorldViewProjection matrix.</param>
		/// <param name="vector">The unprojected vector.</param>
		public void Unproject(ref Vector3 source, ref Matrix4 matrix, out Vector3 vector)
		{
			vector.X = (((source.X - this.X) / (this.Width)) * 2f) - 1f;
			vector.Y = -((((source.Y - this.Y) / (this.Height)) * 2f) - 1f);
			vector.Z = (source.Z - this.MinDepth) / (this.MaxDepth - this.MinDepth);

			float a = (((vector.X * matrix.M14) + (vector.Y * matrix.M24)) + (vector.Z * matrix.M34)) + matrix.M44;
			Vector3.Transform(ref vector, ref matrix, out vector);

			if (!MathUtil.IsOne(a))
			{
				vector = (vector / a);
			}
		}

		/// <summary>
		/// Gets the aspect ratio used by the viewport.
		/// </summary>
		/// <value>The aspect ratio.</value>
		public float AspectRatio
		{
			get
			{
				if (!MathUtil.IsZero(this.Height))
				{
					return this.Width / this.Height;
				}
				return 0f;
			}
		}

		/*
		/// <summary>
		/// Performs an explicit conversion from <see cref="Viewport"/> to <see cref="ViewportF"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ViewportF(Viewport value)
		{
			return new ViewportF(value.X, value.Y, value.Width, value.Height, value.MinDepth, value.MaxDepth);
		}


		/// <summary>
		/// Performs an implicit conversion from <see cref="ViewportF"/> to <see cref="RawViewportF"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public unsafe static implicit operator RawViewportF(ViewportF value)
		{
			return *(RawViewportF*) &value;
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="RawViewportF"/> to <see cref="ViewportF"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public unsafe static implicit operator ViewportF(RawViewportF value)
		{
			return *(ViewportF*) &value;
		}
		*/
	}
}