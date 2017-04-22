using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RT.Equality.Test
{
    /// <summary>
    /// Standard set of tests on objects that derive from EqualityDefiniton and their compatablility with HashSets.
    /// </summary>
    [TestClass]
    public class EqualityDefinitionHashSetTest
    {
        /// <summary>
        /// Tests that a HashSet will not allow duplicates object references 
        /// but will allow equal objects in a different memory locations
        /// </summary>
        [TestMethod]
        public void HashSetControlTest()
        {
            var test1 = new object();
            var test2 = new object();
            var hashSet = new HashSet<object> {test1, test1, test2};

            Assert.IsTrue(hashSet.Count == 2);
        }

        /// <summary>
        /// Tests that a HashSet will not allow duplicates (as defined by the EqualityDefinition)
        /// </summary>
        [TestMethod]
        public void HashSetDuplicateTest()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(1);
            var hashSet = new HashSet<TestEntities.Test> {test1, test1, test2};

            Assert.IsTrue(hashSet.Count == 1);
        }

        /// <summary>
        /// Tests that a HashSet will allow non-duplicates (as defined by the EqualityDefinition)
        /// </summary>
        [TestMethod]
        public void HashSetNonDuplicateTest()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(2);
            var hashSet = new HashSet<TestEntities.Test> {test1, test2};

            Assert.IsTrue(hashSet.Count == 2);
        }
    }
}
