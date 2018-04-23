using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Ksiegarnia
{
    public class DataContext
    {
        //ALL THE COLLECTIONS OF BASE CLASSES
        private List<Klient> client = new List<Klient>();
        private Dictionary<Guid, Ksiazka> book = new Dictionary<Guid, Ksiazka>();
        private ObservableCollection<Faktura> invoice = new ObservableCollection<Faktura>();
        private List<Egzemplarz> copy = new List<Egzemplarz>();

        //CONSTRUCTOR
        public DataContext()
        {
        }

        //PROPERTIES
        public List<Klient> Client { get => client; set => client = value; }
        public Dictionary<Guid, Ksiazka> Book { get => book; set => book = value; }
        public ObservableCollection<Faktura> Invoice { get => invoice; set => invoice = value; }
        public List<Egzemplarz> Copy { get => copy; set => copy = value; }
    }
}
