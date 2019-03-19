using PokerHandBayshoreCodeTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerHandBayshoreCodeTest.Models.Home
{
    public class Card
    {
        public Suit Suit { get; set; }
        public CardValue Value { get; set; }

        public Card(Suit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
        

        public static Card TryParseCard(string cardText)
        {
            // Return null if the entered text is not valid
            if(cardText == null || cardText.Length < 2 || cardText.Length > 3)
            {
                return null;
            }

            var valueText = cardText.Substring(0, cardText.Length - 1);
            var suitText = cardText.Substring(cardText.Length - 1, 1);

            var cardValue = ParseCardValue(valueText);
            var cardSuit = ParseSuit(suitText);

            if(cardValue == null || cardSuit == null)
            {
                return null;
            }

            return new Card(cardSuit.Value, cardValue.Value);
        }

        public static CardValue? ParseCardValue(string valueText)
        {
            switch (valueText)
            {
                case ("A"):
                    return CardValue.Ace;
                case ("2"):
                    return CardValue.Two;
                case ("3"):
                    return CardValue.Three;
                case ("4"):
                    return CardValue.Four;
                case ("5"):
                    return CardValue.Five;
                case ("6"):
                    return CardValue.Six;
                case ("7"):
                    return CardValue.Seven;
                case ("8"):
                    return CardValue.Eight;
                case ("9"):
                    return CardValue.Nine;
                case ("10"):
                    return CardValue.Ten;
                case ("J"):
                    return CardValue.Jack;
                case ("Q"):
                    return CardValue.Queen;
                case ("K"):
                    return CardValue.King;
                default:
                    return null;
            }
        }

        public static Suit? ParseSuit(string suitText)
        {
            switch (suitText)
            {
                case ("s"):
                    return Suit.Spades;
                case ("c"):
                    return Suit.Clubs;
                case ("d"):
                    return Suit.Diamonds;
                case ("h"):
                    return Suit.Hearts;
                default:
                    return null;
            }
        }
    }
}