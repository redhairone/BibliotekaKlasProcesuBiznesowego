using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    [Serializable]
    public class Egzemplarz : ISerializable
    {
        //REFERENCE TO A BOOK
        private Ksiazka book;

        #region ATTRIBUTES
        private Guid index;
        private double price;
        private string provider;
        private DateTime publishDate;
        #endregion

        //CONSTRUCTOR
        public Egzemplarz(double _price, string _provider, DateTime _publishDate, Ksiazka _book)
        {
            Price = _price;
            Provider = _provider;
            Book = _book;
            PublishDate = _publishDate;

            Index = System.Guid.NewGuid();
        }

        //CONSTRUCTOR USED TO DESERIALIZE CLASS
        public Egzemplarz(SerializationInfo info, StreamingContext context)
        {
            //Loads all the attributes from the file into a new object.
            Index = (Guid)info.GetValue("index", typeof(Guid));
            Price = (double)info.GetValue("price", typeof(double));
            Provider = (string)info.GetValue("provider", typeof(string));
            PublishDate = (DateTime)info.GetValue("publishDate", typeof(DateTime));
        }

        //METHOD THAT RETURNS SHORT STRING DESCRIBING A COPY
        public override string ToString()
        {
            string result = "ID: " + index.ToString() + ". Cena: " + Price + " . Wydawnictwo: " + Provider + ". Rok wydania:" + PublishDate.Year.ToString() + ".";
            return result;
        }

        //METHOD USED TO SERIALIZE CLASS
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Saves all the attributes of an object into the file
            info.AddValue("index", Index, typeof(Guid));
            info.AddValue("price", Price, typeof(double));
            info.AddValue("provider", Provider, typeof(string));
            info.AddValue("publishDate", PublishDate, typeof(DateTime));
        }

        #region PROPERTIES
        public Ksiazka Book { get => book; set => book = value; }
        public double Price { get => price; set => price = value; }
        public string Provider { get => provider; set => provider = value; }
        public Guid Index { get => index; set => index = value; }
        public DateTime PublishDate { get => publishDate; set => publishDate = value; }
        #endregion
    }
}
