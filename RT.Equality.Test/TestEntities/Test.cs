namespace RT.Equality.Test.TestEntities
{
    /// <summary>
    /// Test entity used for testing the EqualityDefinition class
    /// </summary>
    public class Test : EqualityDefinition<Test>
    {
        /// <summary>
        /// A simple property holding a numeric value
        /// </summary>
        [EqualityMember]
        public int NumericProperty { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="numericValue">The value that NumericProperty should be set to</param>
        public Test(int numericValue)
        {
            NumericProperty = numericValue;
        }
    }
}
