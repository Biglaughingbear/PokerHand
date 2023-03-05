using PokerHand;

namespace PokerHandTest
{
    public class HandsProperRecognitionTest
    {
        [Theory]
        [MemberData(nameof(PairData))]
        public void HandHasPair(List<Card> hand, bool result)
        {
            Assert.True(Hand.HasPair(hand) == result);
        }

        [Theory]
        [MemberData(nameof(TwoPairData))]
        public void HandHasTwoPair(List<Card> hand, bool result)
        {
            Assert.True(Hand.HasTwoPair(hand) == result);
        }

        [Theory]
        [MemberData(nameof(ThreeOfAKindData))]
        public void HandHasThreeOfAKind(List<Card> hand, bool result)
        {
            Assert.True(Hand.HasThreeOfAKind(hand) == result);
        }

        [Theory]
        [MemberData(nameof(FourOfAKindData))]
        public void HandHasFourOfAKind(List<Card> hand, bool result)
        {
            Assert.True(Hand.HasFourOfAKind(hand) == result);
        }

        [Theory]
        [MemberData(nameof(FlushData))]
        public void HandHasFlush(List<Card> hand, bool result)
        {
            Assert.True(Hand.HasFlush(hand) == result);
        }

        public static IEnumerable<object[]> PairData =>
        new List<object[]>
        {
            new object[] { new List<Card> { 
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, true },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 8 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, false },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, true }
        };

        public static IEnumerable<object[]> TwoPairData =>
        new List<object[]>
        {
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, false },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 8 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 8 }
            }, true },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 5 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, false }
        };

        public static IEnumerable<object[]> ThreeOfAKindData =>
        new List<object[]>
        {
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 3 }
            }, true },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 8 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 8 }
            }, false },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 5 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, false }
        };

        public static IEnumerable<object[]> FourOfAKindData =>
        new List<object[]>
        {
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 4 }
            }, false },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 8 },
                new Card() { Suit = "C", Value = 8 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 8 },
                new Card() { Suit = "C", Value = 8 }
            }, true },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 5 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, false }
        };

        public static IEnumerable<object[]> FlushData =>
        new List<object[]>
        {
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 2 },
                new Card() { Suit = "C", Value = 4 }
            }, true },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 8 },
                new Card() { Suit = "S", Value = 3 },
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "C", Value = 8 }
            }, false },
            new object[] { new List<Card> {
                new Card() { Suit = "C", Value = 1 },
                new Card() { Suit = "C", Value = 3 },
                new Card() { Suit = "S", Value = 5 },
                new Card() { Suit = "H", Value = 2 },
                new Card() { Suit = "D", Value = 4 }
            }, false }
        };
    }
}