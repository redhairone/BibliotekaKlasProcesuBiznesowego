using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    [Serializable]
    public class Klient : ISerializable
    {
        #region ATTRIBUTES
        private Guid index;
        private string name;
        private string surname;
        private int discount;
        #endregion

        // CONSTRUCTOR
        public Klient(string _name, string _surname, int _discount)
        {
            Name = _name;
            Surname = _surname;
            Discount = _discount;

            Index = System.Guid.NewGuid();
        }

        //CONSTRUCTOR USED TO DESERIALIZE DATA
        public Klient(SerializationInfo info, StreamingContext context)
        {
            //Loading all the attributes from the file into a new object
            Index = (Guid)info.GetValue("index", typeof(Guid));
            Name = (string)info.GetValue("name", typeof(string));
            Surname = (string)info.GetValue("surname", typeof(string));
            Discount = (int)info.GetValue("discount", typeof(int));
        }

        //METHOD USE TO GET INFORMATION ABOUT OBJECT
        public override string ToString()
        {
            string result = "ID: " + Index.ToString() + ". Godność: " + Surname + " " + Name + ". Zniżka: " + Discount + "%.";
            return result;
        }

        //METHOD USED SERIALIZE DATA
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Saves all the attributes into the file.
            info.AddValue("index", Index, typeof(Guid));
            info.AddValue("name", Name, typeof(string));
            info.AddValue("surname", Surname, typeof(string));
            info.AddValue("discount", Discount, typeof(int));
        }

        #region PROPERTIES
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Discount { get => discount; set => discount = value; }
        public Guid Index { get => index; set => index = value; }
        #endregion
    }
}
