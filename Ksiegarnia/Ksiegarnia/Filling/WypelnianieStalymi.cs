using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    public class WypelnianieStalymi : DataFiller
    {
		// METHOD THAT FILLS DATA REPOSITORY
		public void Fill(DataContext DC)
        {
			// ADDING CLIENTS TO THE DATA REPOSITORY;
            Klient K1 = new Klient("Dorian", "Grzybiarczyk", 20);
            Klient K2 = new Klient("Przemyslaw", "Sosnka", 10);
            Klient K3 = new Klient("Gracjan", "Graala", 44);
            Klient K4 = new Klient("Edyta", "Piotrkarczyk", 0);
            Klient K5 = new Klient("Dominik", "Nieciesielski", 0);

            DC.Client.Add(K1);
            DC.Client.Add(K2);
            DC.Client.Add(K3);
            DC.Client.Add(K4);
            DC.Client.Add(K5);
			
			// ADDING NEW BOOKS TO THE BOOKSTORE
            Ksiazka KS1 = new Ksiazka(System.Guid.NewGuid(), "Pan Tadeusz", "Mickiewicz");
            Ksiazka KS2 = new Ksiazka(System.Guid.NewGuid(), "Dziady", "Mickiewicz");
            Ksiazka KS3 = new Ksiazka(System.Guid.NewGuid(), "Harry Potter", "Rolling");
            Ksiazka KS4 = new Ksiazka(System.Guid.NewGuid(), "Ludzie bezdomni", "Żeromski");
            Ksiazka KS5 = new Ksiazka(System.Guid.NewGuid(), "Zbrodnia i Kara", "Dostojewski");

            DC.Book.Add(KS1.Index, KS1);
            DC.Book.Add(KS2.Index, KS2);
            DC.Book.Add(KS3.Index, KS3);
            DC.Book.Add(KS4.Index, KS4);
            DC.Book.Add(KS5.Index, KS5);

            // ADDING THE COPIES AVAIABLE
            Egzemplarz E1 = new Egzemplarz(20, "Helium", new DateTime(2009), KS1);
            Egzemplarz E2 = new Egzemplarz(15.5, "WSIP", new DateTime(1997), KS2);
            Egzemplarz E3 = new Egzemplarz(9.99, "Znak", new DateTime(2001), KS3);
            Egzemplarz E4 = new Egzemplarz(2.99, "Helium", new DateTime(2005), KS4);
            Egzemplarz E5 = new Egzemplarz(99.95, "WSIP", new DateTime(1990), KS5);

            DC.Copy.Add(E1);
            DC.Copy.Add(E2);
            DC.Copy.Add(E3);
            DC.Copy.Add(E4);
            DC.Copy.Add(E5);

            // ADDING INVOICES
            Faktura F1 = new Faktura(new DateTime(2018, 11, 3), E5, K5);
            Faktura F2 = new Faktura(new DateTime(2018, 11, 3), E4, K1);
            Faktura F3 = new Faktura(new DateTime(2018, 11, 5), E3, K4);

            DC.Invoice.Add(F1);
            DC.Invoice.Add(F2);
            DC.Invoice.Add(F3);
        }
    }
}
