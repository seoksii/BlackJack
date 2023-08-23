internal class Program
{
    static void Main(string[] args)
    {
        // 블랙잭 게임을 실행하세요
        Blackjack blackjack = new Blackjack();
        blackjack.Start();

        bool restartGame = true;
        while (restartGame) {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\n1.다시하기");
            Console.WriteLine("0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>>");

            int input = blackjack.CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    restartGame = false;
                    break;
                case 1:
                    blackjack = new Blackjack();
                    blackjack.Start();
                    break;
            }
        }
        
    }
}