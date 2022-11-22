using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StealPileGame
{
	internal class Board
	{
		public List<Card> centerCards;
		public Stack<Card> deck;

		public Board()
		{
			deck = new Stack<Card>(52);
			centerCards = new List<Card>(6);
		}

		public void DrawBoard()
		{
			Console.Clear();
			Console.CursorTop = 3;
			string d =	@" ____________  " + "\n" +
							@"|           |\ " +	"\n" +
							@"|           |||" +	"\n" +
							@"|           |||" +	"\n" +
							@"\===========\||" +	"\n" +
							@" \===========\|";
			UI.CenterText("Cards in deck: " + deck.Count.ToString());
			UI.CenterText(d);

			string cc = "";
			int baseWidth = Console.WindowWidth / 2;
			int Margin = 0;
			int top = Console.CursorTop -= 6;
			for (int i = 0; i < centerCards.Count; i++)
			{
				if (i % 2 == 0)
				{
					Margin = Console.WindowWidth / 5;
					top = Console.CursorTop;
					UI.PlaceText($"[{i}]", baseWidth - Margin);
					UI.PlaceText(centerCards[i].Draw(), baseWidth - Margin);
				}
				else
				{
					Margin = Console.WindowWidth / 9;
					Console.CursorTop = top;
					UI.PlaceText($"[{i}]", baseWidth + Margin);
					UI.PlaceText(centerCards[i].Draw(), baseWidth + Margin);
				}
			}
		}
	}
}
