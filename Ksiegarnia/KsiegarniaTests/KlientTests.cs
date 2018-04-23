using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ksiegarnia;

namespace BibliotekaTests
{
    [TestClass]
    public class KlientTests
    {
        [TestMethod]
        public void KlientToStringTest()
        {
            Klient K1 = new Klient("Imie","Nazwisko",20);

            string result = "ID: " + K1.Index.ToString() + ". Godność: " + K1.Surname + " " + K1.Name + ". Zniżka: " + K1.Discount + "%.";

            Assert.AreEqual(K1.ToString(), result);
        }
    }
}
