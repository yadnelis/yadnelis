using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StealPileGame
{
	internal class StealPileGame
	{
		const int HEART = 0;
		const int DIAMOND = 1;
		const int SPADE = 2;
		const int CLUB = 3;

		Player player1;
		Player player2;
		Board board;

		UI ui;

		public StealPileGame()
		{
			board = new Board();
			player1 = new Player();
			player2 = new Player();
			ui = new UI();

			for (int i = 0; i < Card.allSuits.Count(); i++)
			{
				for (int j = 0; j < Card.allRanks.Count(); j++)
				{
					board.deck.Push(new Card(j, i));
				}
			}
		}

		public void Start()
		{
			string[] input;
			WelcomeScreen();
			Shuffle();
			AssignCards();
			do
			{
				do
				{
					GameScreen();
					input = TakeInput();
				}
				while (IsInputValid(input));
				PressEnterToContinue();

			}
			while (true);
		}

		public void Shuffle()
		{
			Random rnd = new Random();
			List<Card> deckCopy = new List<Card>(board.deck);
			board.deck.Clear();

			for (int i = deckCopy.Count - 1; i >= 0; i--)
			{
				int b = rnd.Next(0, i);
				board.deck.Push(deckCopy[b]);
				deckCopy.RemoveAt(b);
			}
		}

		public void AssignCards()
		{
			for (int i = 0; i < 4; i++)
			{
				player1.AddToHand(board.deck.Pop());
				player2.AddToHand(board.deck.Pop());
				board.centerCards.Add(board.deck.Pop());
			}

			board.centerCards.Add(board.deck.Pop());

			board.centerCards.Add(board.deck.Pop());

			/* DEBUG: remember to remove
			Console.WriteLine("Player 1: " + String.Join(" | ", player1.GetHand()));
			Console.WriteLine("Player 2: " + String.Join(" | ", player2.GetHand()));
			Console.WriteLine("Playing cards: " + String.Join(" | ", board.centerCards));
			Console.WriteLine("Deck: " + String.Join(" | ", board.deck));
			*/

			PressEnterToContinue();
		}

		public void WelcomeScreen()
		{
			ui.NewScreen(6);
			Console.WriteLine("Welcome to the Steal Pile Game!!");
			Console.WriteLine("Press enter to continue...");
			while (Console.ReadKey().Key != ConsoleKey.Enter) ;
		}

		public void GameScreen()
		{
			ui.NewScreen(4);
			board.DrawBoard();
			Console.CursorTop = 2;
			UI.PlaceText(player1.DrawHand(), Console.WindowWidth / 10);

			Console.CursorTop = 2;
			UI.PlaceText(player2.DrawHand(), Console.WindowWidth - (Console.WindowWidth / 10) * 2);
		}

		public string[] TakeInput()
		{
			Console.WriteLine("Type the index of card in hand: ");
			string hand = Console.ReadLine().Trim();

			Console.WriteLine("Type the index of card you want to take or [p] to steal: ");
			string middleCard = Console.ReadLine().Trim();

			return new string[] { hand, middleCard };
		}

		public bool IsInputValid(string[] input)
		{
			int b;
			if(input.Length != 2)
			{
				return false;
			}
			else if(!int.TryParse(input[0], out b))
			{
				return false;
			}
			else if (input[1].ToLower().Equals("p"))
			{
				return true;
			}
			else if(!int.TryParse(input[1], out b))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public void MakePlay(string[] input)
		{
			if (true)
			{

			}
		}

		public void PressEnterToContinue()
		{
			while (Console.ReadKey().Key != ConsoleKey.Enter) ;
		}
	}
}
