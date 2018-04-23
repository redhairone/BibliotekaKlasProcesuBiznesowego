using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    [Serializable]
    public class Faktura : ISerializable
    {
        //REFERENCES TO COPY AND CLIENT
        private Egzemplarz copy;
        private Klient client;

        #region ATTRIBUTES
        private Guid index;
        private DateTime purchaseDate;
        private double purchasePrice;
        #endregion

        //CONSTRUCTOR
        public Faktura(DateTime _purchaseDate, Egzemplarz _copy, Klient _klient)
        {
            PurchaseDate = _purchaseDate;
            Copy = _copy;
            Client = _klient;

            if (Client != null && Copy != null) { PurchasePrice = Copy.Price * Client.Discount / 100; }
            else PurchasePrice = 0;

            Index = System.Guid.NewGuid();
        }

        //CONSTRUCTOR USED TO DESERIALIZE CLASS
        public Faktura(SerializationInfo info, StreamingContext context)
        {
            //Loads all attributes from the file into a new object.
            Index = (Guid)info.GetValue("index", typeof(Guid));
            PurchaseDate = (DateTime)info.GetValue("purchaseDate", typeof(DateTime));
            PurchasePrice = (double)info.GetValue("purchasePrice", typeof(double));
        }

        //METHOD USED TO GET INFORMATION ABOUT OBJECT
        public override string ToString()
        {
            string result = "ID: " + Index.ToString() + ". Data zakupu: " + PurchaseDate.ToString() + ". Koszt: " + PurchasePrice + ".";
            return result;
        }

        //METHOD USED SERIALIZE DATA 
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Saves all the attributes into the file
            info.AddValue("index", Index, typeof(Guid));
            info.AddValue("purchaseDate", PurchaseDate, typeof(DateTime));
            info.AddValue("purchasePrice", PurchasePrice, typeof(double));
        }

        #region PROPERTIES
        public Egzemplarz Copy { get => copy; set => copy = value; }
        public Klient Client { get => client; set => client = value; }
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public Guid Index { get => index; set => index = value; }
        #endregion
    }
}
