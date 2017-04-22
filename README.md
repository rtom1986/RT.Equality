# RT.Equality

Welcome to the EqualityDefinition library!

Sometimes it is necessary to change the default meaning of equality for one of your custom C# types.  

For example, say you want two objects to be considered equal when the values of their properties and/or fields match, instead of 
comparing memory locations (value equality vs. reference equality).

To achieve this for a reference type, it is necessary to override the object.Equals virtual method and the object.GetHashCode virtual 
method.  In addition, to maintain consistency and follow best practices, it is also necessary to overload the C# == and != equality 
operators.  Last, it is often helpful to implement the IEquatable<T> interface, which allows you to define a strongly-typed Equals 
method.

All five of these (six, if you count the object.Equals static method) need to define equality in a consistent manner to ensure 
equality has a clear definition for your type.

While it's rather trivial to override/overload/implement the 5 methods described above, it is very common for developers to get it 
wrong or provide partial/inconsistent implementations.  This incomplete/inconsistent defintion of equality can cause a great deal 
of confusion to other developers using your type.

The EqualityDefinition class contained here is a lightweight library that takes care of these five implementations in an intuitive 
and automatic manner.

Simply ensure your type derives from EqualityDefinition<T> where T is your type and mark the fields and/or properties that should be
considered in the equality evaluation with an [EqualityMember] attribute.  Thats it!  This library will automatically create a 
custom implemenatation of equality for your type that matches your specifications and exposes a consistent definition via the 
five equality methods.

This library has been designed to work in cases involving inheritance and HashSets if you were wondering.

This library will not work with non-primitive value types (structs) since a stuct cannot derive from a custom type. In addition, if
your type contains a field/property that is another reference type deriving from EqualityDefinition, it will not use the definition in
the evaluation of the field/property.  It will fallback to a reference equality evaluation in that case.  To support more advanced 
use cases such as this, it is recommended that you override the IsEqualTo method and the GetHashCode method of the 
EqualityDefinition class.  There, you can provide a custom implementation that is no longer bound to the [EqualityMember] attributes.
Rest assured, your custom implementation in those two overrides will be used in the five equality methods and constitute the 
equality definiton for your type.

Also, please be aware that this library uses reflection, meaning any equality evaluation on your type will use reflection. If 
performance is of great concern in your application, this library might not be a good fit.  Otherwise, the performance hit will
typically be negligable and acceptable in most use cases.






