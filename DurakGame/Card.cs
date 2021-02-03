using DurakGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DurakGame
{
    public enum CardSuit { Kresti = 4, Bubi = 3, Chervi = 2, Piki = 1 }
    public enum CardNominal { six = 6, seven = 7, eight = 8, nine = 9, ten = 10, jack = 11, queen = 12, king = 13, ace = 14 }
    
    class Card
    {

        public CardSuit Suit { get; set; }
        public CardNominal Nominal { get; set; }

        public Card(CardSuit suit, CardNominal nominal)
        {
            Suit = suit;
            Nominal = nominal;

            sourse = $"/Карты/{(int)suit}-{(int)nominal}.bmp";
            //sourse = $"Source/single.bmp";
        }

        public string sourse;

        
        


    }
}
