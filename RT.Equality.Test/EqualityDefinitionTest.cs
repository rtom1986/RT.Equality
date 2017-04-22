using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RT.Equality.Test
{
    /// <summary>
    /// Standard set of tests on objects that derive directly from EqualityDefiniton.
    /// </summary>
    [TestClass]
    public class EqualityDefinitionTest
    {
        /// <summary>
        /// Tests the IEquatable implementation of T
        /// </summary>
        [TestMethod]
        public void TestIEquatableImplementation()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(1);
            var test3 = new TestEntities.Test(2);
            var test4 = test1;

            //Assert that two variables pointing to the same object reference are equal
            Assert.IsTrue(test1.Equals(test4));

            //Assert that a reference type variable is found to be equal with itself
            Assert.IsTrue(test1.Equals(test1));

            //Assert that two objects with equal values are found to be equal
            Assert.IsTrue(test1.Equals(test2));

            //Assert that two objects with non-equal values are found to be not equal
            Assert.IsFalse(test1.Equals(test3));

            //Assert that a non-null object does not equal null
            Assert.IsFalse(test1.Equals(null));
        }

        /// <summary>
        /// Tests the object.Equals virtual method override
        /// </summary>
        [TestMethod]
        public void TestObjectEqualsVirtualOverride()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(1);
            var test3 = new TestEntities.Test(2);
            var test4 = test1;

            //Assert that two variables pointing to the same object reference are equal
            Assert.IsTrue(test1.Equals((object)test4));

            //Assert that a reference type variable is found to be equal with itself
            Assert.IsTrue(test1.Equals((object)test1));

            //Assert that two objects with equal values are found to be equal
            Assert.IsTrue(test1.Equals((object)test2));

            //Assert that two objects with non-equal values are found to be not equal
            Assert.IsFalse(test1.Equals((object)test3));

            //Assert that a non-null object does not equal null
            Assert.IsFalse(test1.Equals((object)null));
        }

        /// <summary>
        /// Tests the object.Equals static method
        /// </summary>
        [TestMethod]
        public void TestObjectEqualsStatic()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(1);
            var test3 = new TestEntities.Test(2);
            var test4 = test1;

            //Assert that two variables pointing to the same object reference are equal
            Assert.IsTrue(Equals(test1, test4));

            //Assert that a reference type variable is found to be equal with itself
            //ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(Equals(test1, test1));

            //Assert that two objects with equal values are found to be equal
            Assert.IsTrue(Equals(test1, test2));

            //Assert that two objects with non-equal values are found to be not equal
            Assert.IsFalse(Equals(test1, test3));

            //Assert that a non-null object does not equal null
            Assert.IsFalse(Equals(test1, null));
        }

        /// <summary>
        /// Tests the C# == operator
        /// </summary>
        [TestMethod]
        public void TestEqualsOperator()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(1);
            var test3 = new TestEntities.Test(2);
            var test4 = test1;
            TestEntities.Test test5 = null;
            TestEntities.Test test6 = null;

            //Assert that two variables pointing to the same object reference are equal
            Assert.IsTrue(test1 == test4);

            //Assert that a reference type variable is found to be equal with itself
#pragma warning disable
            //ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(test1 == test1);
#pragma warning restore

            //Assert that two objects with equal values are found to be equal
            Assert.IsTrue(test1 == test2);

            //Assert that two objects with non-equal values are found to be not equal
            Assert.IsFalse(test1 == test3);

            //Assert that a non-null object does not equal null
            Assert.IsFalse(test1 == null);

            //Assert that two null objects are found to be equal
            Assert.IsTrue(test5 == test6);
        }

        /// <summary>
        /// Tests the C# != operator
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOperator()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(1);
            var test3 = new TestEntities.Test(2);
            var test4 = test1;
            TestEntities.Test test5 = null;
            TestEntities.Test test6 = null;

            //Assert that two variables pointing to the same object reference are equal
            Assert.IsFalse(test1 != test4);

            //Assert that a reference type variable is found to be equal with itself
#pragma warning disable
            //ReSharper disable once EqualExpressionComparison
            Assert.IsFalse(test1 != test1);
#pragma warning restore

            //Assert that two objects with equal values are found to be equal
            Assert.IsFalse(test1 != test2);

            //Assert that two objects with non-equal values are found to be not equal
            Assert.IsTrue(test1 != test3);

            //Assert that a non-null object does not equal null
            Assert.IsTrue(test1 != null);

            //Assert that two null objects are found to be equal
            Assert.IsFalse(test5 != test6);
        }

        /// <summary>
        /// Tests the object.GetHashCode virtual method override
        /// </summary>
        [TestMethod]
        public void TestObjectGetHashCodeVirtualOverride()
        {
            var test1 = new TestEntities.Test(1);
            var test2 = new TestEntities.Test(1);
            var test3 = new TestEntities.Test(2);
            var test4 = test1;

            //Assert that two variables pointing to the same object reference have equal hash codes
            Assert.IsTrue(test1.GetHashCode() == test4.GetHashCode());

            //Assert that a reference type variable produces the same hashcode consistently 
#pragma warning disable
            //ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(test1.GetHashCode() == test1.GetHashCode());
#pragma warning restore

            //Assert that two objects with equal values are found to have equal hash codes
            Assert.IsTrue(test1.GetHashCode() == test2.GetHashCode());

            //Assert that two objects with non-equal values are found to have differing hash codes
            Assert.IsFalse(test1.GetHashCode() == test3.GetHashCode());
        }
    }
}
