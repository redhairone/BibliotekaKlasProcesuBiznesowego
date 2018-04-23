using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ksiegarnia;

namespace KsiegarniaTest
{
    [TestClass]
    public class FakturaTests
    {
        [TestMethod]
        public void FakturaToStringTest()
        {
            Faktura F1 = new Faktura(new DateTime(2010), null, null);

            string result = "ID: " + F1.Index.ToString() + ". Data zakupu: " + F1.PurchaseDate.ToString() + ". Koszt: " + F1.PurchasePrice + ".";

            Assert.AreEqual(F1.ToString(), result);
        }
    }
}
