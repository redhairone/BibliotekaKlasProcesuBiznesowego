using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    public class WypelnianieLosowe : DataFiller
    {
        private string[] clientNameBase = { "Adrian", "Paweł", "Monika", "Czarek", "Dorian", "Gracjan", "Edyta", "Ania", "Dominika" };
        private string[] clientSurnameBase = { "Kowalski", "Ciechowicz", "Martyńkiewicz", "Wajda", "Małopolczyk", "Kucharczyk", "Miśkiewicz" };

        private string[] copyProviderBase = { "Sowa", "Orbita", "WSiP", "Nowa Era", "WOŚP" };

        private string[] bookNameBase = { "W pustyni i w puszczy", "Czerwony Kapturek", "Wojna i Pokój", "Krzyżacy", "Anegdotki", "Jezioro Łabędzi" };
        private string[] bookAuthorBase = { "Mickiewicz", "Słowacki", "Dostoyevsky", "Shakespear", "Sienkiewicz", "Prus", "Dickens", "Conrad" };

        private int amount = 5;

        public WypelnianieLosowe(int _amount)
        {
            amount = _amount;
        }

        public void Fill(DataContext DC)
        {
            Random rand = new Random();

            for (int i = 0; i < amount; i++)
            {

                Klient _client = new Klient(clientNameBase[rand.Next(8)], clientSurnameBase[rand.Next(6)], rand.Next(90));
                Ksiazka _book = new Ksiazka(System.Guid.NewGuid(), bookNameBase[rand.Next(5)], bookAuthorBase[rand.Next(7)]);
                Egzemplarz _copy = new Egzemplarz(rand.NextDouble() * 100, copyProviderBase[rand.Next(4)], new DateTime(rand.Next(1900, 2018), rand.Next(1, 12), rand.Next(1, 28)), _book);
                Faktura _invoice = new Faktura(new DateTime(rand.Next(1900, 2018), rand.Next(1, 12), rand.Next(1, 28)), _copy, _client);

                DC.Client.Add(_client);
                DC.Book.Add( _book.Index, _book );
                DC.Copy.Add( _copy );
                DC.Invoice.Add( _invoice );
            }
        }
    }
}
