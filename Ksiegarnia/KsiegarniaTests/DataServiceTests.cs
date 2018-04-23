using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ksiegarnia;

namespace KsiegarniaTest
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void AddInvoiceTest()
        {
            DataService DS = new DataService(new DataRepository(new WypelnianieStalymi()));

            Klient K1 = new Klient("AAA", "BBB", 10);
            Egzemplarz E1 = new Egzemplarz(9.99, "AAA", new DateTime(2009), null);

            DS.AddInvoice(K1, E1);

            Assert.AreEqual(DS.DataRepository.GetAllInvoices().Count, 4);
        }

        [TestMethod]
        public void LookForClientTest()
        {
            DataService DS = new DataService(new DataRepository(new WypelnianieStalymi()));

            Klient K1 = new Klient("AAA", "BBB", 10);

            Assert.AreEqual(null, DS.LookForClient(K1.Surname));

            DS.DataRepository.AddClient(K1);

            Assert.AreEqual(K1, DS.LookForClient(K1.Surname));
        }

        [TestMethod]
        public void LookForCopyTest()
        {
            DataService DS = new DataService(new DataRepository(new WypelnianieStalymi()));

            Egzemplarz E1 = new Egzemplarz(9.99, "Orbita", new DateTime(2009), null);

            Assert.AreEqual(null, DS.LookForCopy(E1.Index));

            DS.DataRepository.AddCopy(E1);

            Assert.AreEqual(E1, DS.LookForCopy(E1.Index));
        }

        [TestMethod]
        public void LookForInvoiceTest()
        {
            DataService DS = new DataService(new DataRepository(new WypelnianieStalymi()));

            Faktura F1 = new Faktura(new DateTime(2015), null, null);

            Assert.AreEqual(null, DS.LookForInvoice(F1.Index));

            DS.DataRepository.AddInvoice(F1);

            Assert.AreEqual(F1, DS.LookForInvoice(F1.Index));
        }

        [TestMethod]
        public void LookForInvoicesBetweenTest()
        {
            DataService DS = new DataService(new DataRepository(new WypelnianieStalymi()));

            Faktura F1 = new Faktura(new DateTime(1990), null, null);

            DS.DataRepository.AddInvoice(F1);

            Assert.AreEqual(F1, DS.LookForInvoicesBetween(new DateTime(1989), new DateTime(1991))[0]);
        }
    }
}
