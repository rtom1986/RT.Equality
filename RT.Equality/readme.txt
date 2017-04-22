The EqualityDefinition class simplifies the process of changing the meaning of equality for a type.
When your own type derives from EqualityDefinition of T, you only need to add the EqualityMember attribute
to the fields and properties that should be evaluated when checking for equality. Everything else, including 
the object.Equals virtual method, object.Equals static method, object.GetHashCode method, IEquatable of T Equals 
method, and C# equality operators will be automatically implemented/overridden/overloaded to use your equality 
definition!  
 
If you do not specify any properties and/or fields for evaluation using the EqualityMember attribute,
the default implementation (reference equality) will be used for your type.  You also have the option of 
overriding the IsEqualTo and GetHashCode methods if your equality definition is more complex than what can be 
expressed with the attributes alone.
 
Any non-primitive members marked with the EqualityMember attribute will be evaluated using reference equality. If one
of your marked fields and/or properties has a custom equality implementation, it will be necessary to override the 
IsEqualTo and GetHashCode methods and perform the necessary evaluation with the strongly-typed values. 
 
**Please Note** Changing the standard out of the box definition of equality for is type is rarely a good practice.
So do your best to exercise good judgement and avoid confusing other developers.

Author: Richard Tom