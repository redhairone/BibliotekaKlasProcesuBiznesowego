using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ksiegarnia;

namespace BibliotekaTests
{
    [TestClass]
    public class EgzemplarzTests
    {
        [TestMethod]
        public void EgzemplarzToStringTest()
        {
            Egzemplarz E1 = new Egzemplarz(9.99, "Dostawca", new DateTime(2009), null);

            string result = "ID: " + E1.Index.ToString() + ". Cena: " + E1.Price + " . Wydawnictwo: " + E1.Provider + ". Rok wydania:" + E1.PublishDate.Year.ToString() + ".";

            Assert.AreEqual(E1.ToString(), result);
        }
    }
}
