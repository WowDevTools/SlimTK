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
using OpenTK;

namespace SlimTK
{
	public static class VectorMath
	{
		/// <summary>
		/// Projects a 3D vector from screen space into object space.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <param name="x">The X position of the viewport.</param>
		/// <param name="y">The Y position of the viewport.</param>
		/// <param name="width">The width of the viewport.</param>
		/// <param name="height">The height of the viewport.</param>
		/// <param name="minZ">The minimum depth of the viewport.</param>
		/// <param name="maxZ">The maximum depth of the viewport.</param>
		/// <param name="worldViewProjection">The combined world-view-projection matrix.</param>
		/// <param name="result">When the method completes, contains the vector in object space.</param>
		public static void Unproject(ref Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ,
			ref Matrix4 worldViewProjection, out Vector3 result)
		{
			Vector3 v = new Vector3();
			Matrix4 matrix;
			Matrix4.Invert(ref worldViewProjection, out matrix);

			v.X = (((vector.X - x) / width) * 2.0f) - 1.0f;
			v.Y = -((((vector.Y - y) / height) * 2.0f) - 1.0f);
			v.Z = (vector.Z - minZ) / (maxZ - minZ);

			Vector3.TransformVector(ref v, ref matrix, out result);
		}

		/// <summary>
		/// Projects a 3D vector from screen space into object space.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <param name="x">The X position of the viewport.</param>
		/// <param name="y">The Y position of the viewport.</param>
		/// <param name="width">The width of the viewport.</param>
		/// <param name="height">The height of the viewport.</param>
		/// <param name="minZ">The minimum depth of the viewport.</param>
		/// <param name="maxZ">The maximum depth of the viewport.</param>
		/// <param name="worldViewProjection">The combined world-view-projection matrix.</param>
		/// <returns>The vector in object space.</returns>
		public static Vector3 Unproject(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ,
			Matrix4 worldViewProjection)
		{
			Vector3 result;
			Unproject(ref vector, x, y, width, height, minZ, maxZ, ref worldViewProjection, out result);
			return result;
		}

		/// <summary>
		/// Calculates the distance between two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The distance between the two vectors.</returns>
		/// <remarks>
		/// <see cref="VectorMath.DistanceSquared(Vector3, Vector3)"/> may be preferred when only the relative distance is needed
		/// and speed is of the essence.
		/// </remarks>
		public static float Distance(Vector3 value1, Vector3 value2)
		{
			float x = value1.X - value2.X;
			float y = value1.Y - value2.Y;
			float z = value1.Z - value2.Z;

			return (float) Math.Sqrt((x * x) + (y * y) + (z * z));
		}

		/// <summary>
		/// Calculates the squared distance between two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The squared distance between the two vectors.</returns>
		/// <remarks>Distance squared is the value before taking the square root.
		/// Distance squared can often be used in place of distance if relative comparisons are being made.
		/// For example, consider three points A, B, and C. To determine whether B or C is further from A,
		/// compare the distance between A and B to the distance between A and C. Calculating the two distances
		/// involves two square roots, which are computationally expensive. However, using distance squared
		/// provides the same information and avoids calculating two square roots.
		/// </remarks>
		public static float DistanceSquared(Vector3 value1, Vector3 value2)
		{
			float x = value1.X - value2.X;
			float y = value1.Y - value2.Y;
			float z = value1.Z - value2.Z;

			return (x * x) + (y * y) + (z * z);
		}
	}
}