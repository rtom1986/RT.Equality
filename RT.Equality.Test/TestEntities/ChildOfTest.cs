namespace RT.Equality.Test.TestEntities
{
    /// <summary>
    /// Test entity used for testing the EqualityDefinition class in cases involving inheritance
    /// </summary>
    public class ChildOfTest : Test
    {
        /// <summary>
        /// A simple property holding a string value
        /// </summary>
        [EqualityMember]
        public string StringProperty { get; }

        /// <summary>
        /// A simple property holding a string value
        /// </summary>
        public string OtherStringProperty { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="numericValue">The value that NumericProperty should be set to</param>
        /// <param name="stringValue">The value that StringProperty should be set to</param>
        public ChildOfTest(int numericValue, string stringValue):base(numericValue)
        {
            StringProperty = stringValue;
        }
    }
}
