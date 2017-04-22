using System;

namespace RT.Equality
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EqualityMember : Attribute { }
}
