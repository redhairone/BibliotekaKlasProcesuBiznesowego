using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    public class DataRepository
    {
        #region ATTRIBUTES
        private DataFiller dataFiller;
        private DataContext DataContext = new DataContext();
        #endregion

        // CONSTRUCTER WITH AND WITHOUT DATA INJECTION
        public DataRepository() { }
        public DataRepository(DataFiller DF)
        {
            DataFiller = DF;
            DataFiller.Fill(DataContext);
        }

        #region PROPERTIES
        public DataFiller DataFiller { get => dataFiller; set => dataFiller = value; }
        #endregion

        // C.R.U.D. METHODS
        public void AddClient(Klient C) { DataContext.Client.Add(C); }
        public Klient GetClient(int N) { return DataContext.Client[N]; }
        public Klient GetClient(Guid ID)
        {
            Klient KL = null;
            foreach (Klient K in GetAllClients())
            {
                if (ID == K.Index)
                {
                    KL = K;
                    break;
                }
                else continue;
            }
            return KL;
        }
        public List<Klient> GetAllClients() { return DataContext.Client; }
        public void DeleteClient(int N) { DataContext.Client.RemoveAt(N); }
        public void DeleteClient(Klient C) { DataContext.Client.Remove(C); }

        public void AddBook(Ksiazka B) { DataContext.Book.Add(B.Index, B); }
        public Ksiazka GetBook(Guid index) { return DataContext.Book[index]; }
        public Dictionary<Guid, Ksiazka> GetAllBooks() { return DataContext.Book; }
        public void DeleteBook(Guid index) { DataContext.Book.Remove(index); }

        public void AddInvoice(Faktura I) { DataContext.Invoice.Add(I); }
        public Faktura GetInvoice(int N) { return DataContext.Invoice[N]; }
        public ObservableCollection<Faktura> GetAllInvoices() { return DataContext.Invoice; }
        public void DeleteInvoice(int N) { DataContext.Invoice.RemoveAt(N); }
        public void DeleteInvoice(Faktura I) { DataContext.Invoice.Remove(I); }

        public void AddCopy(Egzemplarz C) { DataContext.Copy.Add(C); }
        public Egzemplarz GetCopy(int N) { return DataContext.Copy[N]; }
        public Egzemplarz GetCopy(Guid ID)
        {
            Egzemplarz EG = null;
            foreach (Egzemplarz E in GetAllCopies())
            {
                if (ID == E.Index)
                {
                    EG = E;
                    break;
                }
                else continue;
            }
            return EG;
        }
        public List<Egzemplarz> GetAllCopies() { return DataContext.Copy; }
        public void DeleteCopy(int N) { DataContext.Copy.RemoveAt(N); }
        public void DeleteCopy(Egzemplarz C) { DataContext.Copy.Remove(C); }
    }
}
