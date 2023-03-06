using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public class Hand
    {      

        public bool HasPair(List<Card> hand)
        {
            return hand.GroupBy(x => x.NumericValue).Where(y => y.Count() == 2).Count() >= 1;
        }
        public bool HasTwoPair(List<Card> hand)
        {
            return hand.GroupBy(x => x.NumericValue).Where(y => y.Count() == 2).Count() >= 2;
        }
        public bool HasThreeOfAKind(List<Card> hand)
        {
            return hand.GroupBy(x => x.NumericValue).Where(y => y.Count() == 3).Count() >= 1;
        }
        public bool HasFourOfAKind(List<Card> hand)
        {
            return hand.GroupBy(x => x.NumericValue).Where(y => y.Count() == 4).Count() >= 1;
        }
        public bool HasFlush (List<Card> hand)
        {
            return hand.GroupBy(x => x.Suit).Count() == 1;  
        }

        public int SettleHighCard(Player player1, Player player2)
        {
            var handOne = player1.Hand.OrderBy(x => x.NumericValue).ToList();
            var handTwo = player2.Hand.OrderBy(x => x.NumericValue).ToList();

            for (int i = 0; i < handOne.Count(); i++)
            {
                if (handOne[i].NumericValue > handTwo[i].NumericValue)
                    return 1;

                else if (handOne[i].NumericValue < handTwo[i].NumericValue)
                    return 2;
            }

            return 0;
        }

        public int SettlePair(Player player1, Player player2)
        {
            var handOneValue = player1.Hand.GroupBy(x => x.NumericValue).FirstOrDefault(y => y.Count() == 2).Key;
            var handTwoValue = player2.Hand.GroupBy(x => x.NumericValue).FirstOrDefault(y => y.Count() == 2).Key;

            if (handOneValue > handTwoValue)
                return 1;

            else if (handOneValue < handTwoValue)
                return 2;

            return SettleHighCard(player1, player2);
        }

        public int SettleTwoPair(Player player1, Player player2)
        {
            var handOnePairs = player1.Hand.GroupBy(x => x.NumericValue).Where(y => y.Count() == 2).ToList();
            var handTwoPairs = player2.Hand.GroupBy(x => x.NumericValue).Where(y => y.Count() == 2).ToList();

            for (int i = 0; i < handOnePairs.Count(); i++)
            {
                if (handOnePairs[i].Key > handTwoPairs[i].Key)
                    return 1;

                else if (handOnePairs[i].Key < handTwoPairs[i].Key)
                    return 2;
            }

            return SettleHighCard(player1, player2);
        }

        public int SettleThreeOfAKind(Player player1, Player player2)
        {
            var handOneValue = player1.Hand.GroupBy(x => x.NumericValue).FirstOrDefault(y => y.Count() == 3).Key;
            var handTwoValue = player2.Hand.GroupBy(x => x.NumericValue).FirstOrDefault(y => y.Count() == 3).Key;

            if (handOneValue > handTwoValue)
                return 1;

            else if (handOneValue < handTwoValue)
                return 2;

            return SettleHighCard(player1, player2);
        }

        public int SettleFourOfAKind(Player player1, Player player2)
        {
            var handOneValue = player1.Hand.GroupBy(x => x.NumericValue).FirstOrDefault(y => y.Count() == 4).Key;
            var handTwoValue = player2.Hand.GroupBy(x => x.NumericValue).FirstOrDefault(y => y.Count() == 4).Key;

            if (handOneValue > handTwoValue)
                return 1;

            else if (handOneValue < handTwoValue)
                return 2;

            return SettleHighCard(player1, player2);
        }

        public List<Player> SettleHand(List<Player> players)
        {
            var winningPlayer = players.Where(x => HasFourOfAKind(x.Hand)).ToList();
            
            if (winningPlayer.Count() > 1)
                winningPlayer = SettleHand(winningPlayer, SettleFourOfAKind);

            else if (winningPlayer.Count() == 0)
            {
                winningPlayer = players.Where(x => HasFlush(x.Hand)).ToList();

                if (winningPlayer.Count() > 1)
                    winningPlayer = SettleHand(winningPlayer, SettleHighCard);

                else if (winningPlayer.Count() == 0)
                {
                    winningPlayer = players.Where(x => HasThreeOfAKind(x.Hand)).ToList();

                    if (winningPlayer.Count() > 1)
                        winningPlayer = SettleHand(winningPlayer, SettleThreeOfAKind);

                    else if (winningPlayer.Count() == 0)
                    {
                        winningPlayer = players.Where(x => HasTwoPair(x.Hand)).ToList();

                        if (winningPlayer.Count() > 1)
                            winningPlayer = SettleHand(winningPlayer, SettleTwoPair);

                        else if (winningPlayer.Count() == 0)
                        {
                            winningPlayer = players.Where(x => HasPair(x.Hand)).ToList();

                            if (winningPlayer.Count() > 1)
                                winningPlayer = SettleHand(winningPlayer, SettlePair);

                            else if (winningPlayer.Count() == 0)
                                winningPlayer = SettleHand(players, SettleHighCard);
                        }
                    }
                }
            }

            return winningPlayer;
        }

        private List<Player> SettleHand(List<Player> players, Func<Player, Player, int> comparison)
        {
            var result = new List<Player>();

            for (int i = players.Count-1; i >= 1; i--)
            {
                var winner = comparison(players[i], players[i-1]);
                if (winner == 0)
                {
                    result.Add(players[i]);
                    result.Add(players[i-1]);
                }
                else
                    result.Add(winner == 1 ? players[i] : players[i-1]);
            }
            
            return result;
        }
    }
}
