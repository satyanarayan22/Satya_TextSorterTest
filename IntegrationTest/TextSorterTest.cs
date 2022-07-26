using SimpleTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest
{
    [TestClass]
    public class TextSorterTest
    {
        [TestMethod]
        public void WordSort()
        {
            Assert.AreEqual("Boom Zoom", TextSorter.SortString("Zoom Boom"));
        }

        [TestMethod]
        public void CaseSort()
        {
            Assert.AreEqual("Boom boom", TextSorter.SortString("boom Boom"));
        }

        [TestMethod]
        public void RemoveInvalidChars()
        {
            Assert.AreEqual("b b", TextSorter.SortString("b, b"));
        }

        [TestMethod]
        public void SimpleTest1()
        {
            Assert.AreEqual("baby Go go", TextSorter.SortString("Go baby, go"));
        }

        [TestMethod]
        public void SimpleTest2()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", TextSorter.SortString("CBA, abc aBc ABC cba CBA."));
        }

        [DataTestMethod]
        [DataRow("Try Hard", "Hard Try")]
        [DataRow("try Try Hard", "Hard Try try")]
        [DataRow("try,.,' Try; Hard", "Hard Try try")]
        [DataRow("aBba, Abba", "Abba aBba")]
        [DataRow("Zebra Abba", "Abba Zebra")]
        [DataRow("aBba Abba", "Abba aBba")]
        public void CanSortDifferentStringInput(string input, string result)
        {
            Assert.AreEqual(TextSorter.SortString(input), result);
        }
    }
}