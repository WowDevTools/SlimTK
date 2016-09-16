# SlimTK

SlimTK is a bridging library for SlimDX and OpenTK, meant to ease porting of applications from SlimDX to OpenTK (DirectX to OpenGL). 

OpenTK lacks a number of ease-of-life methods and types used in rendering and optimization thereof which exists in SlimDX.

This library implements these missing types and extension methods for equivalent types in OpenTK using code taken from the SlimMath library.

Currently, SlimTK implements the following types:
* BoundingBox
* BoundingSphere
* BoundingFrustrum
* Plane
* Ray

In addition to these types, the library also adds the following method. These methods are meant to replace and emulate equivalent SlimDX methods as closely as possible.
* VectorMath.Distance (for OpenTK.Vector3)
* VectorMath.DistanceSquared (for OpenTK.Vector3)
* Equals (as a static method for OpenTK.Vector3)
* ToString (as a static method for OpenTK.Vector3)

SlimTK also implements all collision calculation methods available in SlimDX. 


## License
SlimTK is licensed under the MIT license.