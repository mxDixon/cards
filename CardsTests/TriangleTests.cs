using System;
using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod()]
        public void Constructor_WithIntegers_SetsSides()
        {
            var expected = new int[] { 1, 2, 3 };
            var tri = new Triangle(1, 2, 3);

            CollectionAssert.AreEqual(expected, tri.sides);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
        "Triangle sides must have a positive length")]
        public void Constructor_InvalidSizeSide_ThrowsError()
        {
            var tri = new Triangle(1, 2, 0);
            string type = tri.Type();

        }

        [TestMethod()]
        public void Type_WithEquilateralSides_ReturnsEquilateral()
        {
            Triangle tri = new Triangle(1, 1, 1);
            string type = tri.Type();

            Assert.AreEqual(type, "Equilateral");
        }

        [TestMethod()]
        public void Type_WithIsoscelesSides_ReturnsIsosceles()
        {
            var tri = new Triangle(1, 1, 2);
            string type = tri.Type();

            Assert.AreEqual(type, "Isosceles");
        }

        [TestMethod()]
        public void Type_WithScaleneSides_ReturnsScalene()
        {
            var tri = new Triangle(1, 2, 3);
            string type = tri.Type();

            Assert.AreEqual(type, "Scalene");
        }
    }
}
