using System;
using System.Collections.Generic;

namespace StealPileGame
{
	internal class Player
	{
		private List<Card> hand;
		private Stack<Card> pile;

		public Player()
		{
			hand = new List<Card>(4);
			pile = new Stack<Card>(52);
		}

		public void AddToHand(Card card)
		{
			if (hand.Count == 4)
			{
				throw new Exception($"{this}: cannot add more than 4 cards to the player's hand.");
			}
			hand.Add(card);
		}

		public void SetHand(List<Card> hand)
		{
			if (hand.Count > 4)
			{
				throw new Exception($" {this}: cannot add more than 4 cards to the player's hand.");
			}
			this.hand = hand;
		}

		public List<Card> GetHand()
		{
			return hand;
		}

		public string DrawHand()
		{
			string s = "";
			for (int i = 0; i < hand.Count; i++)
			{
				s += $"[{i}]\n";
				s += hand[i].Draw();
			}
			return s;
		}

		public void AddToPile(Card card)
		{
			pile.Push(card);
		}

		public Stack<Card> GetPile()
		{
			return pile;
		}
	}
}
