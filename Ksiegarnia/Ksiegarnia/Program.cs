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
    class Program
    {
        public static string FileName = "TryOut.txt";

        static void Main(string[] args)
        {
            //Creating new DataRepository with data in it, that we can serialize.
            DataFiller DF = new WypelnianieStalymi();
            DataRepository DR = new DataRepository(DF);

            #region WRITE EVERY OBJECT INFO ON SCREEN

            Console.WriteLine("BEFORE SERIALIZATION:");
            Console.WriteLine(    "==========KLIENCI:==========");
            foreach (Klient K in DR.GetAllClients()) Console.WriteLine(K.ToString());
            Console.WriteLine("\n\n==========KSIAZKI:==========");
            foreach (KeyValuePair<Guid,Ksiazka> K in DR.GetAllBooks()) Console.WriteLine(K.ToString());
            Console.WriteLine("\n\n==========EGZEMPLARZE:======");
            foreach (Egzemplarz E in DR.GetAllCopies())
            {
                Console.WriteLine(E.ToString());
                Console.WriteLine("KSIAZKI => " + E.Book.ToString() + "\n");
            }
            Console.WriteLine("\n\n==========FAKTURY:==========");
            foreach (Faktura Fak in DR.GetAllInvoices())
            {
                Console.WriteLine(Fak.ToString());
                Console.WriteLine("Klient => " + Fak.Client.ToString());
                Console.WriteLine("Kopia => " + Fak.Copy.ToString() + "\n");
            }

            #endregion  
            
            //Creating new Serialization class so we can Serialize data
            Serializacja S = new Serializacja(DR);
            //Serializing data into file.
            S.Serialize(FileName);


            //Creating formatter and new FileStream to deserialize data.
            IFormatter F = new BinaryFormatter();
            FileStream FS = new FileStream("TryOut.txt", FileMode.Open);
            //Recreating Serializacja object so we can deserialize DataRepository object.
            Serializacja SS = (Serializacja)F.Deserialize(FS);
            //Deserializing DataRepostiory object.
            DataRepository DR2 = SS.Deserialize(F, FS);
            //Closing file.
            FS.Close();

            #region WRITE EVERY OBJECT INFO ON SCREEN AFTER DESERIALIZATION
            Console.WriteLine("\n\nAFTER SERIALIZATION:");
            Console.WriteLine("==========KLIENCI:==========");
            foreach (Klient K in DR2.GetAllClients()) Console.WriteLine(K.ToString());
            Console.WriteLine("\n\n==========KSIAZKI:==========");
            foreach (KeyValuePair<Guid, Ksiazka> K in DR2.GetAllBooks()) Console.WriteLine(K.ToString());
            Console.WriteLine("\n\n==========EGZEMPLARZE:======");
            foreach (Egzemplarz E in DR2.GetAllCopies())
            {
                Console.WriteLine(E.ToString());
                Console.WriteLine("KSIAZKI => " + E.Book.ToString() + "\n");
            }
            Console.WriteLine("\n\n==========FAKTURY:==========");
            foreach (Faktura Fak in DR2.GetAllInvoices())
            {
                Console.WriteLine(Fak.ToString());
                Console.WriteLine("Klient => " + Fak.Client.ToString());
                Console.WriteLine("Kopia => " + Fak.Copy.ToString() + "\n");
            }
            #endregion

            Console.ReadKey();
        }
    }
}
