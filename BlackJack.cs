using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

// 블랙잭 게임을 구현하세요. 
public class Blackjack
{
    // 코드를 여기에 작성하세요
    public Player Player { get; set; }
    public Player Dealer { get; set; }
    public Deck Deck { get; set; }

    public Blackjack()
    {
        Player = new Player();
        Dealer = new Player();
        Deck = new Deck();
    }

    public void Start()
    {
        SetCards();
    }

    private void PrintHands()
    {
        Console.Clear();
        Console.WriteLine($"딜러의 패 : {Dealer.Hand.ToString()}");
        Console.WriteLine($"당신의 패 : {Player.Hand.ToString()}");
    }

    private void SetCards()
    {
        // 플레이어에게 카드 두 장
        Player.DrawCardFromDeck(Deck);
        Player.DrawCardFromDeck(Deck);

        // 딜러에게 카드 한 장
        Dealer.DrawCardFromDeck(Deck);

        // 현재 핸드 표시
        PrintHands();

        Thread.Sleep(1000);
        CheckInitialStatus();
    }

    private void CheckInitialStatus()
    {
        if (Player.Hand.GetTotalValue() == 21 && Dealer.Hand.GetTotalValue() != 21)
            Victory();
        else if (Player.Hand.GetTotalValue() == 21 && Dealer.Hand.GetTotalValue() == 21)
            Push();

        PlayerPlay();
    }

    private void PlayerPlay()
    {
        Console.WriteLine("\n-----------------------------------------");
        Console.WriteLine("\n1. 스탠드 (더 이상 카드를 받지 않습니다.)");
        Console.WriteLine("2. 히트 (카드를 한 장 더 받습니다.)");
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>> ");

        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DealerPlay();
                break;
            case 2:
                PlayerHit();
                break;
        }
    }

    private void PlayerHit()
    {
        Player.DrawCardFromDeck(Deck);
        PrintHands();
        Thread.Sleep(1000);

        if (Player.Hand.GetTotalValue() > 21)
            Lose();
        else if (Player.Hand.GetTotalValue() == 21)
            DealerPlay();
        else
            PlayerPlay();
    }

    private void DealerPlay()
    {
        Dealer.DrawCardFromDeck(Deck);
        PrintHands();
        Thread.Sleep(1000);

        if (Dealer.Hand.GetTotalValue() >= 17)
            DealerStand();
        else // < 17
            DealerPlay();
    }

    private void DealerStand()
    {
        if (Dealer.Hand.GetTotalValue() > 21)
            Victory();
        else if (Player.Hand.GetTotalValue() > Dealer.Hand.GetTotalValue())
            Victory();
        else if (Player.Hand.GetTotalValue() == Dealer.Hand.GetTotalValue())
            Push();
        else
            Lose();
    }

    private void Push()
    {
        Console.WriteLine("\n\n  푸시입니다!\n");
    }

    private void Victory()
    {
        Console.WriteLine("\n\n  당신의 승리!\n");
    }

    private void Lose()
    {
        Console.WriteLine("\n\n  당신의 패배!\n");
    }

    public int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력입니다.");
            Console.Write(">>>");
        }
    }
}