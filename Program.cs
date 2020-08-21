using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack2
{

    class Hand
    {
        public List<Card> Cards = new List<Card>();
        public int TotalValue()
        {
            var total = 0;
            foreach (var card in Cards)
            {
                total = total + card.Value();
            }
            return total;
        }
        public void AddCardToHand(Card cardToAdd)
        {
            Cards.Add(cardToAdd);
        }
    }
    class Card
    {
        public int answer;

        public string Face { get; set; }
        public string Suit { get; set; }

        public int Value()
        {
            var answers = 0;
            switch (Face)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    answers = int.Parse(Face);
                    break;

                case "Jack":
                case "Queen":
                case "King":
                    answers = 10;
                    break;

                case "Ace":
                    answers = 11;
                    break;
            }
            return answers;

        }
    }

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




            // 1. Create a new deck

            var suits = new List<string>() { "Hearts", "Diamonds", "Spade", "Club" };
            var faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            var deck = new List<Card>();


            for (var indexsuits = 0; indexsuits < suits.Count(); indexsuits++)
            {
                for (var indexfaces = 0; indexfaces < faces.Count(); indexfaces++)
                {
                    var ourCard = new Card();

                    ourCard.Face = faces[indexfaces];
                    ourCard.Suit = suits[indexsuits];
                    deck.Add(ourCard);
                    // { Console.WriteLine($"working with {ourCard.Face} and {ourCard.Suit}"); }
                }
            }


            // Console.WriteLine("We have our deck of cards");
            // System.Threading.Thread.Sleep(1500);



            // 2. Ask the deck to make a new shuffled 52 cards

            // make n = number of cards in our deck
            var fullDeck = deck.Count();

            // for rightIndex from n - 1 down to 1 do:
            for (var rightIndex = fullDeck - 1; rightIndex >= 1; rightIndex--)
            {
                var randomNumberGenerator = new Random();

                //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex
                var leftIndex = randomNumberGenerator.Next(rightIndex);


                //   Now swap the values at rightIndex and leftIndex by doing this:
                //     leftCard = the value from deck[rightIndex]
                var leftCard = deck[rightIndex];

                //     rightChard = the value from deck[leftIndex]
                var rightCard = deck[leftIndex];

                //     deck[rightIndex] = rightCard
                deck[rightIndex] = rightCard;

                //     deck[leftIndex] = leftCard
                deck[leftIndex] = leftCard;
            }


            var topCard = deck[0];
            // Console.WriteLine($"The top card on the deck is the {topCard.Face} of {topCard.Suit}");  CHECKING CODE

            // 3. Create a player hand - create a Class
            var player = new Hand();



            // 4. Create a dealer hand - create a Class
            var dealer = new Hand();


            // 5. Ask the deck for a card and place it in the player hand
            //      PEDAC
            //           - deck
            //           - get the card from the deck
            var firstCardForPlayer = deck[0];

            //          - remove the card from the deck so its not dealt again (getting rid of an element from a list)
            //    these two lines is essentially the same
            // deck.RemoveAt(0);
            deck.Remove(firstCardForPlayer);

            //          - Add it to the hand
            player.AddCardToHand(firstCardForPlayer);


            // 6. Ask the deck for a card and place it in the player hand
            var secondCardForPlayer = deck[0];
            deck.Remove(secondCardForPlayer);
            player.AddCardToHand(secondCardForPlayer);


            // 7. Ask the deck for a card and place it in the dealer hand
            var firstCardForDealer = deck[0];
            deck.Remove(firstCardForDealer);
            dealer.AddCardToHand(firstCardForDealer);


            // 8. Ask the deck for a card and place it in the dealer hand
            var secondCardForDealer = deck[0];
            deck.Remove(secondCardForDealer);
            dealer.AddCardToHand(secondCardForDealer);


            // 9. Show the player the cards in their hand and the TotalValue of their Hand

            // 10. If they have BUSTED, then goto step 15
            var choice = "";

            while (choice != "STAND" && player.TotalValue() <= 21)
            {

                foreach (var card in player.Cards)
                {
                    Console.WriteLine($"The {card.Face} of {card.Suit}");

                }
                // Print the total
                Console.WriteLine($"The total is: {player.TotalValue()}");

                // 11. Ask the player if they want to HIT or STAND
                Console.Write("HIT or STAND? ");
                choice = Console.ReadLine();

                // 12. If HIT
                if (choice == "HIT")
                {
                    // asking deck for a card and place it in the player hand, repeat step 10

                    var additionalCard = deck[0];
                    deck.Remove(additionalCard);
                    player.AddCardToHand(additionalCard);
                }

            }
            // 13. If STAND continue on
            foreach (var card in player.Cards)
            {
                Console.WriteLine($"The {card.Face} of {card.Suit}");

            }
            // Print the total
            Console.WriteLine($"The Player's total is: {player.TotalValue()}");

            // 14. If the dealer has less then goto step 17
            while (dealer.TotalValue() < 17)
            {
                //     - Add a card to the dealer hand and go back to 14
                var additionalCard = deck[0];
                deck.Remove(additionalCard);
                dealer.AddCardToHand(additionalCard);
            }

            // 16. Show the dealer's hand TotalValue
            foreach (var card in dealer.Cards)
            {
                // print that card
                Console.WriteLine($"The {card.Face} of {card.Suit}");

            }
            // Print the total
            Console.WriteLine($"The dealer total is: {dealer.TotalValue()}");


            // 17. If the player busted show "DEALER WINS"
            if (player.TotalValue() > 21)
            {
                Console.WriteLine("Dealer Wins!");
            }
            else
            {
                if (dealer.TotalValue() > 21)
                {
                    Console.WriteLine("Player Wins!");
                }
                else
                {
                    if (dealer.TotalValue() > player.TotalValue())
                    {
                        Console.WriteLine("Dealer Wins!");
                    }
                    else
                    {
                        if (player.TotalValue() > dealer.TotalValue())
                        {
                            Console.WriteLine("Player Wins!");
                        }
                        else
                        {
                            if (player.TotalValue() > dealer.TotalValue())
                            {
                                Console.WriteLine("Player Wins!");
                            }
                            else
                            {
                                Console.WriteLine("Tie goes to the dealer");
                            }
                        }
                    }

                }
            }

        }
    }
}





















