using System;
using System.Collections.Generic;
using System.Linq;

namespace RT.Equality
{
    /// <summary>
    /// The EqualityDefinition class simplifies the process of changing the meaning of equality for a type.
    /// When your own type derives from EqualityDefinition of T, you only need to add the EqualityMember attribute
    /// to the fields and properties that should be evaluated when checking for equality. Everything else, including 
    /// the object.Equals virtual method, object.Equals static method, object.GetHashCode method, IEquatable of T Equals 
    /// method, and C# equality operators will be automatically implemented/overridden/overloaded to use your equality 
    /// definition!  
    /// 
    /// If you do not specify any properties and/or fields for evaluation using the EqualityMember attribute,
    /// the default implementation (reference equality) will be used for your type.  You also have the option of 
    /// overriding the IsEqualTo and GetHashCode methods if your equality definition is more complex than what can be 
    /// expressed with the attributes alone.
    /// 
    /// Any non-primitive members marked with the EqualityMember attribute will be evaluated using reference equality. If one
    /// of your marked fields and/or properties has a custom equality implementation, it will be necessary to override the 
    /// IsEqualTo and GetHashCode methods and perform the necessary evaluation with the strongly-typed values. 
    /// 
    /// **Please Note** Changing the standard out of the box definition of equality for is type is rarely a good practice.
    /// So do your best to exercise good judgement and avoid confusing other developers.
    /// </summary>
    /// <typeparam name="T">The derived type</typeparam>
    /// <author>Richard Tom</author>
    public class EqualityDefinition<T> : IEquatable<T>
    {
        /// <summary>
        /// IsEqualTo virtual method.
        /// If this method is not overridden by your type, it will use fields and properties decorated with
        /// the EqualityMember attribute as the basis for its equality evaluation.
        /// If no fields or properties are decorated with the EqualityMember attribute, this method
        /// will revert to the typical reference equality evaluation.
        /// </summary>
        /// <param name="other">The instance of T to be compared for equality</param>
        /// <returns>bool value, true if equal</returns>
        protected virtual bool IsEqualTo(T other)
        {
            //return false if the parameter is null
            if (ReferenceEquals(other, null)) return false;

            //Initialize values
            var equal = true;
            var values = new Dictionary<dynamic, dynamic>();

            //Use reflection to get all properties of T that have the EqualityMember attribute
            var properties = other.GetType().GetProperties().Where(x => Attribute.IsDefined(x, typeof(EqualityMember))).ToList();

            //Use reflection to get all fields of T that have the EqualityMember attribute
            var fields = other.GetType().GetFields().Where(x => Attribute.IsDefined(x, typeof(EqualityMember))).ToList();
            
            //Process results
            if (properties.Count == 0 && fields.Count == 0)
            {
                //No attributes were used, fall back to a normal reference equality evaulation
                equal = ReferenceEquals(this, other);
            }

            //Add property values to dictionary
            properties.ForEach(x =>
            {
                values.Add(EqualityUtils.CastObject(x.GetValue(this)), EqualityUtils.CastObject(x.GetValue(other)));
            });

            //Add field values to dictionary
            fields.ForEach(x =>
            {
                values.Add(EqualityUtils.CastObject(x.GetValue(this)), EqualityUtils.CastObject(x.GetValue(other)));
            });

            //Compare properties and/or fields for equality
            if (values.Any(value => value.Key != value.Value))
            {
                equal = false;
            }

            //Return result
            return equal;
        }

        /// <summary>
        /// The IEquatable of T Equals implementation
        /// Exposes a type safe equals method
        /// </summary>
        /// <param name="other">The instance of T to be compared for equality</param>
        /// <returns>bool value, true if equal</returns>
        /// <author>Richard Tom</author>
        public bool Equals(T other)
        {
            //Return false if object is null, otherwise test equality via the IsEqualTo virtual method
            return !ReferenceEquals(other, null) && IsEqualTo(other);
        }

        /// <summary>
        /// The object.Equals virtual method override
        /// Exposes a non type safe equals method
        /// </summary>
        /// <param name="obj">The instance of object to be compared for equality</param>
        /// <returns>bool value, true if equal</returns>
        /// <author>Richard Tom</author>
        public override bool Equals(object obj)
        {
            //Return false if object is null of is not of expected type
            if (ReferenceEquals(obj, null) || !(obj is T)) return false;

            //Test equality via the IsEqualTo virtual method
            return IsEqualTo((T)obj);
        }

        /// <summary>
        /// Overload of the == operator
        /// </summary>
        /// <param name="leftSide">The left side instance to be compared for equality</param>
        /// <param name="rightSide">The right side instance to be compared for equality</param>
        /// <returns>bool value, true if equal</returns>
        /// <author>Richard Tom</author>
        public static bool operator ==(EqualityDefinition<T> leftSide, EqualityDefinition<T> rightSide)
        {
            //Return true if both objects are null
            if (ReferenceEquals(leftSide, null) && ReferenceEquals(rightSide, null)) return true;

            //Return false if either object is null
            if (ReferenceEquals(leftSide, null) || ReferenceEquals(rightSide, null)) return false;

            //Test equality via the IsEqualTo virtual method
            return leftSide.IsEqualTo((T)(object)rightSide);
        }

        /// <summary>
        /// Overload of the != operator
        /// </summary>
        /// <param name="leftSide">The left side instance to be compared for equality</param>
        /// <param name="rightSide">The right side instance to be compared for equality</param>
        /// <returns>bool value, true if not equal</returns>
        /// <author>Richard Tom</author>
        public static bool operator !=(EqualityDefinition<T> leftSide, EqualityDefinition<T> rightSide)
        {
            //Return false if both objects are null
            if (ReferenceEquals(leftSide, null) && ReferenceEquals(rightSide, null)) return false;

            //Return true if either object is null
            if (ReferenceEquals(leftSide, null) || ReferenceEquals(rightSide, null)) return true;

            //Test equality via the IsEqualTo virtual method
            return !leftSide.IsEqualTo((T)(object)rightSide);
        }

        /// <summary>
        /// object.GetHashCode oveeride.
        /// If this method is not overridden by your type, it will use fields and properties decorated with
        /// EqualityMember attribute as the basis for its hash code calculation.
        /// If no fields or properties are decorated with the EqualityMember attribute, this method
        /// will revert to the typical method of hash code calculation.
        /// </summary>
        /// <returns>int representation of the hash code</returns>
        public override int GetHashCode()
        {
            //Initialize return value
            var hashcode = 0;

            //Use reflection to get all properties of T that have the EqualityMember attribute
            var properties = GetType().GetProperties().Where(x => Attribute.IsDefined(x, typeof(EqualityMember))).ToList();

            //Use reflection to get all fields of T that have the EqualityMember attribute
            var fields = GetType().GetFields().Where(x => Attribute.IsDefined(x, typeof(EqualityMember))).ToList();

            //Add each applicable property to the hashcode calculation
            properties.ForEach(x =>
            {
                hashcode += EqualityUtils.CastObject(x.GetValue(this)).GetHashCode() + 17;
            });

            //Add each applicable field to the hashcode calculation
            fields.ForEach(x =>
            {
                hashcode += EqualityUtils.CastObject(x.GetValue(this)).GetHashCode() + 17;
            });

            //If the hashcode was not set, use the base implementation
            if (hashcode == 0)
            {
                hashcode = base.GetHashCode();
            }

            //Return result
            return hashcode;
        }
    }
}
