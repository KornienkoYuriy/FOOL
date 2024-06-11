using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace РГР
{
    internal class Deck
    {
        public Card[] Cards { get; set; } = new Card[36];
        public List<Card> cardsShaffle; 

        public void NewDeck()
        {
            string[] suits = { "Чірва", "Бубна", "Хреста", "Піка" };
            string[] ranks = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int[] power = { 6,7,8,9,10,11,12,13,14 };
            int index = 0;

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    if (index < Cards.Length)
                    {
                        Cards[index] = new Card { CardRank = ranks[j], CardSuit = suits[i], CardPower = power[j] };
                        index++;
                    }
                }
            }
        }

        public void ShaffleDeck()
        {
            NewDeck();
            Random random = new Random();
            cardsShaffle = Cards.OrderBy(x => random.Next()).ToList();
            ////foreach (var item in cardsShaffle)
            ////{
            ////    Console.WriteLine(item.CardSuit + " " + item.CardRank + " ");
            ////}
            //Console.WriteLine(cardsShaffle.Count);
            //cardsShaffle.Remove(cardsShaffle[31]);
            //foreach (var item in cardsShaffle)
            //{
            //    Console.WriteLine(item.CardSuit + " " + item.CardRank + " ");
            //}
            //Console.WriteLine(cardsShaffle.Count);
        }
    }
}
