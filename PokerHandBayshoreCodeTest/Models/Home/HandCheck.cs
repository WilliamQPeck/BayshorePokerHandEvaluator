using PokerHandBayshoreCodeTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerHandBayshoreCodeTest.Models.Home
{
    public class HandCheck
    {
        public string HandString { get; set; }
        public string HandValueString { get; set; }
        public bool ValidInput { get; set; }

        public HandCheck(string init)
        {
            HandString = init;
            ValidInput = true;

            var cardStrings = init.Trim().Split(' ');

            if (cardStrings.Count() != 5)
            {
                ValidInput = false;
                HandValueString = "Please input exactly 5 cards";
            }

            else
            {
                var parsedCards = new List<Card>();
                foreach (var str in cardStrings)
                {
                    var newCard = Helpers.TryParseCard(str);
                    if (newCard == null)
                    {
                        ValidInput = false;
                        HandValueString = $"Could not interpret card \"{str}\", please check your input and try again";
                        break;
                    }
                    else
                    {
                        parsedCards.Add(newCard);
                    }
                }

                if (ValidInput)
                {
                    PokerHand hand = new PokerHand(parsedCards);

                    HandValueString = hand.BestHandString();
                }
            }
        }
    }
}