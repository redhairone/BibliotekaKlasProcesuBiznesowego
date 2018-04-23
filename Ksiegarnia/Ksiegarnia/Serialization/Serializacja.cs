using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    [Serializable]
    class Serializacja : ISerializable
    {
        //REFERENCE TO DATA REPOSITORY WHICH WILL BE SERIALIZED
        DataRepository dataRepository;
        #region ATTRIBUTES NEEDED TO SERIALIZE USING OUR SERIALIZATION
        int clientAmount;
        int bookAmount;
        int copyAmount;
        int invoiceAmount;
        #endregion

        //CONSTUCTOR
        public Serializacja(DataRepository _DR)
        {
            DataRepository = _DR;
        }

        //CONSTRUCTOR NEEDED TO DESERIALIZE USING OUR METHOD
        public Serializacja(SerializationInfo info, StreamingContext context)
        {
            //When we create Serializacja object through this constructor we create new DataRepository object, so we can refill it with saved data.
            DataRepository = new DataRepository();
            //Saving the DataContex collection sizes into attributes.
            ClientAmount = (int)info.GetValue("clientAmount", typeof(int));
            BookAmount = (int)info.GetValue("bookAmount", typeof(int));
            CopyAmount = (int)info.GetValue("copyAmount", typeof(int));
            InvoiceAmount = (int)info.GetValue("invoiceAmount", typeof(int));
        }

        //METHOD THAT DESERIALIZES USING OUR METHOD
        public DataRepository Deserialize(IFormatter formatter, FileStream FS)
        {
            //Recreating all Klient and Ksiazka objects from the file.
            for (int i = 0; i<ClientAmount; i++) DataRepository.AddClient((Klient)formatter.Deserialize(FS));
            for(int i = 0; i < BookAmount; i++)
            {
                Ksiazka K = (Ksiazka)formatter.Deserialize(FS);
                DataRepository.AddBook(K);
            }
            //Recreating all Egzemplarz objects from the file and setting their references at the same time.
            for(int i = 0; i<CopyAmount; i++)
            {
                Egzemplarz E = (Egzemplarz)formatter.Deserialize(FS);
                E.Book = DataRepository.GetBook((Guid)formatter.Deserialize(FS));
                DataRepository.AddCopy(E);
            }
            //Recreating all Faktura objects from the file and setting their references at the same time.
            for (int i = 0; i < InvoiceAmount; i++)
            {
                Faktura F = (Faktura)formatter.Deserialize(FS);
                F.Client = DataRepository.GetClient((Guid)formatter.Deserialize(FS));
                F.Copy = DataRepository.GetCopy((Guid)formatter.Deserialize(FS));

                DataRepository.AddInvoice(F);
            }
            //Closing file from which we deserialized data.
            FS.Close();
            //Returning the recreated DataRepository object.
            return DataRepository;
        }

        //METHOD THAT SERIALIZES USING OUR METHOD
        public void Serialize(string _filename)
        {
            //Creating and opening a file into which we are going to serialize data. Creating binary formatter needed to serialize data.
            FileStream FS = new FileStream(_filename, FileMode.Create);
            IFormatter formatter = new BinaryFormatter();
            
            //Serializing sizes of collections in DataContext.
            formatter.Serialize(FS, this);
            
            //Serializing Ksiazka and Klient objects into file.
            foreach (Klient K in DataRepository.GetAllClients()) formatter.Serialize(FS, K);
            foreach (KeyValuePair<Guid, Ksiazka> K in DataRepository.GetAllBooks()) formatter.Serialize(FS, K.Value);
            //Serialing Egzemplarz objects, after each object we also save ID of Ksiazka object that the Egzemplarz references.
            foreach (Egzemplarz E in DataRepository.GetAllCopies())
            {
                formatter.Serialize(FS, E);
                formatter.Serialize(FS, E.Book.Index);
            }
            //Serializing Faktura object, after each object we also save ID of Egzemplarz and Klient objects that the Faktura references.
            foreach (Faktura F in DataRepository.GetAllInvoices()) 
            {
                formatter.Serialize(FS, F);
                formatter.Serialize(FS, F.Client.Index);
                formatter.Serialize(FS, F.Copy.Index);
            }
            //Closing file that we used to serialize data.
            FS.Close();
        }

        //METHOD NEEDED TO SERIALIZE DATA
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Saves all DataContext's collections' sizes into the file
            info.AddValue("clientAmount", DataRepository.GetAllClients().Count, typeof(int));
            info.AddValue("bookAmount", DataRepository.GetAllBooks().Count, typeof(int));
            info.AddValue("copyAmount", DataRepository.GetAllCopies().Count, typeof(int));
            info.AddValue("invoiceAmount", DataRepository.GetAllInvoices().Count, typeof(int));
        }

        #region PROPERTIES
        public DataRepository DataRepository { get => dataRepository; set => dataRepository = value; }
        public int ClientAmount { get => clientAmount; set => clientAmount = value; }
        public int BookAmount { get => bookAmount; set => bookAmount = value; }
        public int CopyAmount { get => copyAmount; set => copyAmount = value; }
        public int InvoiceAmount { get => invoiceAmount; set => invoiceAmount = value; }
        #endregion PROPERTIES
    }
}
