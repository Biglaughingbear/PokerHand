using System;

namespace PokerHand
{
    public class Card
    {
        public string Suit { get; }
        public int NumericValue { get; private set; }
        public string FaceValue 
        { 
            get 
            {
                switch (NumericValue)
                {
                    case 11:
                        return "J";
                    case 12:
                        return "Q";
                    case 13:
                        return "K";
                    case 14:
                        return "A";
                    default:
                        return NumericValue.ToString();
                } 
            }
            private set 
            {
                switch (value)
                {
                    case "J":
                        NumericValue = 11;
                        break;
                    case "Q":
                        NumericValue = 12;
                        break;
                    case "K":
                        NumericValue = 13;
                        break;
                    case "A":
                        NumericValue = 14;
                        break;
                    default:
                        NumericValue = Convert.ToInt32(value);
                        break;
                }
            } 
        }

        public Card(string cardData)
        {
            FaceValue = cardData[0].ToString();
            Suit = cardData[1].ToString();
        }         
    }
}
