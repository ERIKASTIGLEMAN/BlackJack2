using System;

namespace BlackJack2
{
    class Program
    {
        static void DisplayBlackJackGreeting()

        {
            Console.WriteLine("♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎");
            Console.WriteLine();
            Console.WriteLine(" Welcome! Try Your Hand at BlackJack ");
            Console.WriteLine();
            Console.WriteLine("♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎ ♠︎ ♣︎ ♥︎ ♦︎");
            Console.WriteLine();
        }






        static void Main(string[] args)
        {
            // recalling Black Jack greeting from method adding to top

            DisplayBlackJackGreeting();

            //  create a deck

            var suits = new list<string>() { "Hearts", "Diamonds", "Spade", "Club" };
            var face = new list<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            var deck = new List<string>();

            for (var index = 0; index < suits.Count(); index++) { for (var numbers = 0; numbers < face.Count(); numbers++)};


            Console.WriteLine("We have our deck of cards");
            System.Threading.Thread.Sleep(1500);


            //  shuffle deck

            //  PlayerHand

            //  DealerHand

            //  ask deck for card for players hand 2x

            //  ask deck for card for dealers hand 2x

            //  show the players card and total of hand

            //  create conditions based on Busted, Stand, Hit, BlackJack, Winner

            //  Show Dealers Hand and total value of hand

            //  create conditions based on Busted, Stand, Hit, BlackJack, Winner

            //  

        }
    }
}
