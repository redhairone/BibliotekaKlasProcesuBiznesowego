using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ksiegarnia;

namespace KsiegarniaTest
{
    [TestClass]
    public class DataRepositoryTests
    {
        //C.R.U.D. TESTS FOR CLIENT//
        [TestMethod]
        public void AddClientTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Klient K1 = new Klient("AAA", "BBB", 10);

            DR.AddClient(K1);

            Assert.AreEqual(K1, DR.GetClient(5));
        }

        [TestMethod]
        public void GetClientTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Assert.AreEqual(DR.GetClient(3), DR.GetClient(3));
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Assert.AreEqual(DR.GetAllClients(), DR.GetAllClients());
        }

        [TestMethod]
        public void DeleteClientTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Klient BackUp = DR.GetClient(3);
            Klient BackUp4 = DR.GetClient(4);

            DR.DeleteClient(BackUp);

            Assert.AreEqual(DR.GetAllClients().Count, 4);
            Assert.AreEqual(DR.GetClient(3), BackUp4);
        }

        [TestMethod]
        public void DeleteClientByPositionTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Klient BackUp = DR.GetClient(3);

            DR.DeleteClient(3);

            Assert.AreEqual(DR.GetAllClients().Count, 4);
            Assert.AreNotEqual(DR.GetClient(3), BackUp);
        }


        //C.R.U.D. TESTS FOR BOOK//
        [TestMethod]
        public void AddBookTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Guid ID = System.Guid.NewGuid();
            Ksiazka K1 = new Ksiazka(ID, "Tytul", "Autor");

            DR.AddBook(K1);

            Assert.AreEqual(K1, DR.GetBook(ID));
        }
        
        [TestMethod]
        public void GetBookTest() 
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Guid ID = System.Guid.NewGuid();
            Ksiazka K1 = new Ksiazka(ID, "Tytul", "Autor");

            DR.AddBook(K1);

            Assert.AreEqual(DR.GetBook(ID), K1);
        }
        
        [TestMethod]
        public void GetAllBooksTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Assert.AreEqual(DR.GetAllBooks(), DR.GetAllBooks());
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Guid ID = System.Guid.NewGuid();
            Ksiazka K1 = new Ksiazka(ID, "Tytul", "Autor");

            DR.DeleteBook(ID);

            Assert.AreEqual(DR.GetAllBooks().Count, 5);
        }


        //C.R.U.D TESTS FOR INVOICE//
        [TestMethod]
        public void AddInvoiceTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);


            Faktura F1 = new Faktura(new DateTime(2009), null, null);

            DR.AddInvoice(F1);

            Assert.AreEqual(F1, DR.GetInvoice(3));
        }

        [TestMethod]
        public void GetInvoiceTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Assert.AreEqual(DR.GetInvoice(1), DR.GetAllInvoices()[1]);
        }

        [TestMethod]
        public void GetAllInvoicesTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Assert.AreEqual(DR.GetAllInvoices().Count, 3);
        }

        [TestMethod]
        public void DeleteInvoiceTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Faktura BackUp = DR.GetInvoice(1);

            DR.DeleteInvoice(BackUp);

            Assert.AreEqual(DR.GetAllInvoices().Count, 2);
            Assert.AreNotEqual(DR.GetClient(1), BackUp);
        }

        [TestMethod]
        public void DeleteInvoiceByPositionTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Faktura BackUp = DR.GetInvoice(1);

            DR.DeleteInvoice(1);

            Assert.AreEqual(DR.GetAllInvoices().Count, 2);
            Assert.AreNotEqual(DR.GetInvoice(1), BackUp);
        }


        //C.R.U.D. TESTS FOR COPY//
        [TestMethod]
        public void AddCopyTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Egzemplarz E1 = new Egzemplarz(9.99, "AAA", new DateTime(2009), null);

            DR.AddCopy(E1);

            Assert.AreEqual(E1, DR.GetCopy(5));
        }

        [TestMethod]
        public void GetCopyTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Assert.AreEqual(DR.GetCopy(3), DR.GetAllCopies()[3]);
        }

        [TestMethod]
        public void GetAllCopiesTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Assert.AreEqual(DR.GetAllCopies().Count, 5);
        }

        [TestMethod]
        public void DeleteCopyTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Egzemplarz BackUp = DR.GetCopy(3);

            DR.DeleteCopy(BackUp);

            Assert.AreEqual(DR.GetAllCopies().Count, 4);
            Assert.AreNotEqual(DR.GetCopy(3), BackUp);
        }

        [TestMethod]
        public void DeleteCopyByPositionTest()
        {
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            Egzemplarz BackUp = DR.GetCopy(3);

            DR.DeleteCopy(3);

            Assert.AreEqual(DR.GetAllCopies().Count, 4);
            Assert.AreNotEqual(DR.GetCopy(3), BackUp);
        }
    }
}
