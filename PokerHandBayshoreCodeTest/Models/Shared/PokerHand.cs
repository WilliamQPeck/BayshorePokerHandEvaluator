using PokerHandBayshoreCodeTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerHandBayshoreCodeTest.Models.Home
{
    public class PokerHand
    {
        public List<Card> Cards { get; set; }

        public PokerHand()
        {
            Cards = new List<Card>();
        }

        public string BestHandString()
        {
            bool straight = HasStraight();
            bool flush = HasFlush();
            var pairs = FindPairs();
            var trips = FindTriples();
            var quads = FindFourOfAKind();
            var highCard = FindHighCard();

            // First check for straight flushes
            if (flush && straight)
            {
                return $"Straight flush, {highCard.Value.ToString()} high";
            }

            // Then four of a kind
            if (quads.Any())
            {
                return $"Four {quads.First().ToString()}s";
            }

            // Then check for full houses
            if(trips.Any() && pairs.Any())
            {
                return $"Full house: {trips.First().ToString()}s full of {pairs.First().ToString()}s";
            }

            // Next best is a flush
            if (flush)
            {
                return $"Flush";
            }

            // Next best is straight
            if (straight)
            {
                return $"Straight";
            }

            // Then three of a kind
            if (trips.Any())
            {
                return $"Three {trips.First().ToString()}s";
            }

            // Now two pair
            if(pairs.Count > 1)
            {
                return $"Two pair, {pairs[0].ToString()}s and {pairs[1].ToString()}s";
            }

            // Finally, a lowly pair
            if (pairs.Any())
            {
                return $"Pair of {pairs.First().ToString()}s";
            }

            // If nothing else, you have high card
            return $"High card: {highCard.Value.ToString()} of {highCard.Suit.ToString()}";
        }
        
        #region Hand Evaluation Methods

        // If the cards are sequential, we have a straight. This means all different values
        public bool HasStraight()
        {
            bool allDifferentValues = !Cards.GroupBy(x => x.Value).Select(y => y.Count()).Any(z => z > 1);

            // It can't be a straight with 5 cards if they aren't all different values
            if (!allDifferentValues) return false;

            var minVal = Cards.Select(x => x.Value).Min();
            var maxVal = Cards.Select(x => x.Value).Max();

            if((int)maxVal - (int)minVal == 4)
            {
                return true;
            }

            // Special case for "the wheel" straight, which is Ace - 5
            if (Cards.Any(x => x.Value == CardValue.Ace))
            {
                var newHand = Cards.Where(x => x.Value != CardValue.Ace);
                var wheelMinVal = newHand.Select(x => x.Value).Min();
                var wheelMaxVal = newHand.Select(x => x.Value).Max();

                if((int)wheelMaxVal - (int)wheelMinVal == 3)
                {
                    return true;
                }
            }

            return false;
        }

        // If all of the cards are the same suit, we have a flush
        public bool HasFlush()
        {
            var suitCount = Cards.GroupBy(x => x.Suit).Count();

            return suitCount == 1;
        }

        public Card FindHighCard()
        {
            return Cards.OrderByDescending(x => x.Value).FirstOrDefault();
        }

        public List<CardValue> FindPairs()
        {
            var valueCounts = Cards.GroupBy(x => x.Value).Select(y => new { Count = y.Count(), CardValue = y.Key }).Where(z => z.Count == 2).Select(a => a.CardValue).ToList();
            return valueCounts;
        }

        public List<CardValue> FindTriples()
        {
            var valueCounts = Cards.GroupBy(x => x.Value).Select(y => new { Count = y.Count(), CardValue = y.Key }).Where(z => z.Count == 3).Select(a => a.CardValue).ToList();
            return valueCounts;
        }

        public List<CardValue> FindFourOfAKind()
        {
            var valueCounts = Cards.GroupBy(x => x.Value).Select(y => new { Count = y.Count(), CardValue = y.Key }).Where(z => z.Count == 4).Select(a => a.CardValue).ToList();
            return valueCounts;
        }

        #endregion
    }
}