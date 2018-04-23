using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    [Serializable]
    public class Ksiazka : ISerializable
    {
        #region ATTRIBUTES
        private Guid index;
        private string name;
        private string author;
        #endregion

        // CONSTRUCTOR
        public Ksiazka(Guid _index, string _name, string _author)
        {
            Name = _name;
            Author = _author;

            Index = _index;
        }

        //CONSTRUCTOR USED TO DESERIALIZE DATA
        public Ksiazka(SerializationInfo info, StreamingContext context)
        {
            //Loads all the attributes from the file into a new object.
            Index = (Guid)info.GetValue("index", typeof(Guid));
            Name = (string)info.GetValue("name", typeof(string));
            Author = (string)info.GetValue("author", typeof(string));
        }

        //METHOD USE TO GET INFORMATION ABOUT OBJECT
        public override string ToString()
        {
            string result = "ID: " + Index.ToString() + ". Tytuł: " + Name + ". Autor: " + Author + ".";
            return result;
        }

        //METHOD USED SERIALIZE DATA
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Saves all the attributes into the file.
            info.AddValue("index", Index, typeof(Guid));
            info.AddValue("name", Name, typeof(string));
            info.AddValue("author", Author, typeof(string));
        }

        #region PROPERTIES
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public Guid Index { get => index; set => index = value; }
        #endregion
    }
}
