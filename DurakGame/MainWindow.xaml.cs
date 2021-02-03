using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DurakGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Card> gameField = new List<Card>();
        Card Card1;
        Card Card2;
        
        

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Колода
            List<Card> deck = new List<Card>();

            for (int i = 1; i < 5; i++)
            {
                for (int j = 6; j < 15; j++)
                {
                    deck.Add(new Card((CardSuit)i, (CardNominal)j));

                }

            }
            List<Card> playerhand = new List<Card>();
            List<Card> bothand = new List<Card>();
            Random random = new Random();
            ///Рука бота
            for (int i = 0; i < 6; i++)
            {
                int randomcardBot = random.Next(0, deck.Count);
                bothand.Add(deck[randomcardBot]);
                deck.RemoveAt(randomcardBot);
            }
            ///Рука Человека
            for (int i = 0; i < 6; i++)
            {
                int randomcardUser = random.Next(0, deck.Count);
                playerhand.Add(deck[randomcardUser]);
                deck.RemoveAt(randomcardUser);
            }

            int KozirRandom = random.Next(0, deck.Count);
            Card Trump = deck[KozirRandom];
            deck.RemoveAt(KozirRandom);
            Kozir.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + Trump.sourse));


            int User = 0;
            int Bot = 0;
            //foreach (Image img in UserHand.Children)
            //{
            //    img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + playerhand[User].sourse));
            //    User++;
            //}

            int left = 35;
            for (int i = 0; i < 6; i++)
            {
                left += 70;
                CardImage img = new CardImage
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(left, 80, 0, 0),
                    card = playerhand[User],
                };

                img.MouseDown += OneUser_MouseDown;

                img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + playerhand[User].sourse));
                User++;
                UserHand.Children.Add(img);
            }


            left = 35;
            for (int i = 0; i < 6; i++)
            {
                left += 70;
                CardImage img = new CardImage
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(left,70 ,0, 0),
                    card = bothand[Bot],
                };

                img.MouseDown += OneBot_MouseDown;

                img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + bothand[Bot].sourse));
                Bot++;
                BotHand.Children.Add(img);
            }

            //foreach (Image img in BotHand.Children)
            //{
            //    img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + bothand[Bot].sourse));
            //    Bot++;
            //}

            


        }

        private void OneUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CardImage transform = (CardImage)sender;
            Card1 = transform.card;
            int LeftMargin = 30;
            double otstupTop;
            otstupTop = 116;
            transform.Margin = new Thickness(LeftMargin, otstupTop, 0, 0);
            UserHand.Children.Remove(transform);
            GameField.Children.Add(transform);

            LeftMargin += 100;
        }

        private void OneBot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int LeftMargin = 30;
            CardImage transform = (CardImage)sender;
            Card2 = transform.card;
            double otstupTop;
            otstupTop = 65;
            transform.Margin = new Thickness(LeftMargin, otstupTop, 0, 50);
            BotHand.Children.Remove(transform);
            GameField.Children.Add(transform);
            LeftMargin += 75;
            MessageBox.Show(Card2.Suit.ToString());
            
        }
        private void ClearGameField()
        {
            if(GameField.Children.Count==2)
            {
                if(Card1.Suit==Card2.Suit)
                {
                    if(Card1.Nominal>Card2.Nominal)
                    {
                        Bito.IsEnabled = true;
                        GameField.Children.Clear();
                    }
                }
            }
        }

        private void Bito_Click(object sender, RoutedEventArgs e)
        {
            ClearGameField();
        }
    }
}
