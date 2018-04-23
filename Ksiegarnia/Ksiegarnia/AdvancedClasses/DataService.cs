using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    public class DataService
    {
        // ATTRIBUTES
        private DataRepository dataRepository;

        // CONSTRUCTER
        public DataService(DataRepository DR)
        {
            DataRepository = DR;

            DR.GetAllInvoices().CollectionChanged += E_CollectionChanged;
        }

        private void E_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            string result = "";
            if (e.Action == NotifyCollectionChangedAction.Add) result = "Faktura została dodana do kolekcji.\n";
            else if (e.Action == NotifyCollectionChangedAction.Remove) result = "Faktura została usunięta z kolekcji.\n";
            else if (e.Action == NotifyCollectionChangedAction.Replace) result = "Faktura została zastąpiona.\n";

            Console.WriteLine(result);
        }


        //METHOD TO GET ALL THE CLIENTS IN STRING
        public string WszystkiePozycjeKatalogu(List<Klient> _clientList)
        {
            string result = "Wszyscy zaksięgowani klienci:\n";
            int i = 1;
            foreach (Klient K in _clientList)
            {
                result += "[ " + i + " ]\t" + K.ToString() + "\n";
                i++;
            }
            return result;
        }

        //METHOD TO GET ALL THE BOOKS IN STRING
        public string WszystkiePozycjeKatalogu(Dictionary<Guid, Ksiazka> _bookDictionary)
        {
            string result = "Wszystkie zaksięgowane książki:\n";
            int i = 1;
            foreach (KeyValuePair<Guid, Ksiazka> K in _bookDictionary)
            {
                result += "[ " + i + " ]\t" + K.ToString() + "\n";
                i++;
            }
            return result;
        }

        //METHOD TO GET ALL THE INVOICES IN STRING
        public string WszystkiePozycjeKatalogu(ObservableCollection<Faktura> _invoiceCollection)
        {
            string result = "Wszystkie zaksięgowane faktury:\n";
            int i = 1;
            foreach (Faktura F in _invoiceCollection)
            {
                result += "[ " + i + " ]\t" + F.ToString() + "\n";
                i++;
            }
            return result;
        }

        //METHOD TO GET ALL THE COPIES IN STRING
        public string WszystkiePozycjeKatalogu(List<Egzemplarz> _copyList)
        {
            string result = "Wszyscy zaksięgowani klienci:\n";
            int i = 1;
            foreach (Egzemplarz E in _copyList)
            {
                result += "[ " + i + " ]\t" + E.ToString() + "\n";
                i++;
            }
            return result;
        }

        //METHOD SHOWING ALL THE CONNECTIONS THROUGH INVOICES
        public string WszystkiePowiazania(ObservableCollection<Faktura> _invoiceCollection)
        {
            string result = "Wszystkie zaksięgowane faktury wraz z ich powiazaniami:\n\n";
            int i = 1;
            foreach (Faktura F in _invoiceCollection)
            {
                result += "[ " + i + " ]\t" + F.ToString() + "\n\tWystawione dla: " + F.Client.ToString() + "\n\tNa towar: " + F.Copy.Book.ToString() + "\n\tKopia: " + F.Copy.ToString() + "\n\n";
                i++;
            }
            return result;
        }

        //METHOD TO ADD NEW INVOICE TO THE COLLECTION
        public void AddInvoice(Klient _client, Egzemplarz _copy)
        {
            DataRepository.AddInvoice(new Faktura(DateTime.Now, _copy, _client));
        }

        //METHOD TO LOOK FOR CLIENTS BY SURNAME
        public Klient LookForClient(string _surname)
        {
            foreach (Klient K in DataRepository.GetAllClients())
            {
                if (K.Surname == _surname)
                {
                    return K;
                }
            }
            return null;
        }

        //METHOD TO LOOK FOR COPIES BY GUUID
        public Egzemplarz LookForCopy(Guid _guid)
        {
            foreach (Egzemplarz E in DataRepository.GetAllCopies())
            {
                if (E.Index == _guid)
                {
                    return E;
                }
            }
            return null;
        }

        //METHOD TO LOOK FOR INVOCIES BY GUUID
        public Faktura LookForInvoice(Guid _guid)
        {
            foreach (Faktura F in DataRepository.GetAllInvoices())
            {
                if (F.Index == _guid)
                {
                    return F;
                }
            }
            return null;
        }

        public ObservableCollection<Faktura> LookForInvoicesBetween(DateTime _begining, DateTime _end)
        {
            ObservableCollection<Faktura> result = new ObservableCollection<Faktura>();

            foreach (Faktura k in DataRepository.GetAllInvoices())
            {
                if (k.PurchaseDate > _begining && k.PurchaseDate < _end) result.Add(k);
            }

            if (result.Count == 0) return null;
            else return result;
        }

        // PROPERTIES
        public DataRepository DataRepository { get => dataRepository; set => dataRepository = value; }
    }
}
