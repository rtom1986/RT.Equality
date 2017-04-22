using System;

namespace RT.Equality
{
    public class EqualityUtils
    {
        /// <summary>
        /// Method casts object types to primitive types, if possible
        /// </summary>
        /// <param name="obj">The object to be cast</param>
        /// <returns>a dynamic type value</returns>
        internal static dynamic CastObject(object obj)
        {
            //Check for Byte
            if (obj is byte)
            {
                return (byte)obj;
            }

            //Check for Int16
            if (obj is short)
            {
                return (short)obj;
            }

            //Check for Int32
            if (obj is int)
            {
                return (int)obj;
            }

            //Check for Int64
            if (obj is long)
            {
                return (long)obj;
            }

            //Check for Single
            if (obj is float)
            {
                return (float)obj;
            }

            //Check for Double
            if (obj is double)
            {
                return (double)obj;
            }

            //Check for Decimal
            if (obj is decimal)
            {
                return (decimal)obj;
            }

            //Check for Boolean
            if (obj is bool)
            {
                return (bool)obj;
            }

            //Check for Boolean
            if (obj is DateTime)
            {
                return (DateTime)obj;
            }

            //Check for Char
            if (obj is char)
            {
                return (char)obj;
            }

            //Check for String
            var stringVal = obj as string;
            return stringVal ?? obj;
        }
    }
}
