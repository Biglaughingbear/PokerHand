using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PokerHand
{
    public static class Hand
    {
        public static int SettleHighCard(Player player1, Player player2)
        {
            var handOne = player1.Hand.OrderBy(x => x.Value).ToList();
            var handTwo = player2.Hand.OrderBy(x => x.Value).ToList();

            for (int i = 0; i < handOne.Count(); i++)
            {
                if (handOne[i].Value > handTwo[i].Value)
                    return 1;

                else if (handOne[i].Value > handTwo[i].Value)
                    return 2;
            }

            return 0;
        }

        public static bool HasPair(List<Card> hand)
        {
            return hand.GroupBy(x => x.Value).Where(y => y.Count() == 2).Count() >= 1;
        }
        public static bool HasTwoPair(List<Card> hand)
        {
            return hand.GroupBy(x => x.Value).Where(y => y.Count() == 2).Count() >= 2;
        }
        public static bool HasThreeOfAKind(List<Card> hand)
        {
            return hand.GroupBy(x => x.Value).Where(y => y.Count() == 3).Count() >= 1;
        }
        public static bool HasFourOfAKind(List<Card> hand)
        {
            return hand.GroupBy(x => x.Value).Where(y => y.Count() == 4).Count() >= 1;
        }
        public static bool HasFlush (List<Card> hand)
        {
            return hand.GroupBy(x => x.Suit).Count() == 1;  
        }
    }
}
