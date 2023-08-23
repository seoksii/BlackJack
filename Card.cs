using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Suit { Hearts, Diamonds, Clubs, Spades }
public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

// 카드 한 장을 표현하는 클래스
public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit s, Rank r)
    {
        Suit = s;
        Rank = r;
    }

    public int GetValue()
    {
        if ((int)Rank <= 10)
        {
            return (int)Rank;
        }
        else if ((int)Rank <= 13)
        {
            return 10;
        }
        else
        {
            return 11;
        }
    }

    public override string ToString()
    {
        string symbol = string.Empty;
        switch (this.Suit)
        {
            case Suit.Hearts:
                symbol = "♥";
                break;
            case Suit.Diamonds:
                symbol = "◆";
                break;
            case Suit.Clubs:
                symbol = "♣";
                break;
            case Suit.Spades:
                symbol = "♠";
                break;
            default: throw new InvalidDataException();
        }
        string denom = string.Empty;
        switch (this.Rank)
        {
            case Rank.Ace:
                denom = "A";
                break;
            case Rank.King:
                denom = "K";
                break;
            case Rank.Queen:
                denom = "Q";
                break;
            case Rank.Jack:
                denom = "J";
                break;
            default:
                denom = ((int)Rank).ToString("");
                break;
        }
        return $"{symbol} {denom, 2}";
    }
}