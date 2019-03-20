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
    }
}