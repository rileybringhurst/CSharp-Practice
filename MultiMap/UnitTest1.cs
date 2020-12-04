using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MM.Util;


namespace MultiMapUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIntString()
        {
            MultiMap<int,string> intString = new MultiMap<int, string>();
            intString.Add(1, "hello world");
            Assert.AreEqual(intString.dictionary[1][0], "hello world");
        }

        [TestMethod]
        public void TestStringInt()
        {
            MultiMap<string, int> intS = new MultiMap<string, int>();
            intS.Add("key1", 1);
            Assert.AreEqual(intS.dictionary["key1"][0], 1);
        }

        [TestMethod]
        public void TestRemoveValueOnce()
        {
            MultiMap<int, int> m = new MultiMap<int, int>();
            m.Add(1, 1);
            m.Add(1, 2);
            m.Add(1, 2);
            m.removeValue(1, 2, true);
            Assert.AreEqual(m.dictionary[1][0], 1);
            Assert.AreEqual(m.dictionary[1].Count, 2);
        }

        [TestMethod]
        public void TestRemoveValueAllAtKey()
        {
            MultiMap<int, int> m = new MultiMap<int, int>();
            m.Add(1, 1);
            m.Add(1, 2);
            m.Add(1, 2);
            m.Add(2, 2);
            m.removeValue(1, 2, false);
            Assert.AreEqual(m.dictionary[1][0], 1);
            Assert.AreEqual(m.dictionary[2][0], 2);
            Assert.AreEqual(m.dictionary[1].Count, 1);
        }

        [TestMethod]
        public void TestRemoveValueEverywhere()
        {
            MultiMap<int, int> m = new MultiMap<int, int>();
            m.Add(1, 1);
            m.Add(1, 2);
            m.Add(1, 2);
            m.Add(2, 2);
            m.removeValue(2);
            Assert.AreEqual(m.dictionary[1][0], 1);
            Assert.AreEqual(m.dictionary.ContainsKey(2) , false);
            Assert.AreEqual(m.dictionary[1].Count, 1);
        }

    }
}
