using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ksiegarnia;
using System.Collections.Generic;

namespace KsiegarniaTest
{
    [TestClass]
    public class KsiazkaTests
    {
        [TestMethod]
        public void KsiazkaToStringTest()
        {
            Ksiazka K1 = new Ksiazka(new Guid(), "Tytul","Autor");

            string result = "ID: " + K1.Index.ToString() + ". Tytuł: " + K1.Name + ". Autor: " + K1.Author + ".";

            Assert.AreEqual(K1.ToString(), result);
        }
    }
}
