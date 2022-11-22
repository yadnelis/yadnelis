using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StealPileGame
{
	public class Card
	{
		public static readonly string[] allRanks = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
		public static readonly char[] allSuits = new char[] { '♥', '♦', '♠', '♣' };

		private string rank;
		private char suit;

		public Card(int rank, int suit)
		{
			this.rank = allRanks[rank];
			this.suit = allSuits[suit];
		}

		public string Draw()
		{
			string s = "";
			switch (rank)
			{
				case "10":
					s += $"_________\n";
					s += $"|{rank}   {rank}||\n";
					s += $"|       ||\n";
					s += $"|   {suit}   ||\n";
					s += $"|       ||\n";
					s += $"|{rank}   {rank}||\n";
					s += $"========//\n";
					break;
				case "J":
				case "Q":
				case "K":
					s += @$" ________" + "\n";
					s += @$"|{rank} \|/ {rank}||" + "\n";
					s += @$"|  -_-  ||" + "\n";
					s += @$"| /---\ ||" + "\n";
					s += @$"| / {suit} \ ||" + "\n";
					s += @$"|{rank}    {rank} ||" + "\n";
					s += @$"========//" + "\n";
					break;
				default:
					s += $" ________\n";
					s += $"|{rank}     {rank}||\n";
					s += $"|       ||\n";
					s += $"|   {suit}   ||\n";
					s += $"|       ||\n";
					s += $"|{rank}     {rank}||\n";
					s += $"========//\n";
					break;
			}

			return s;
		}

		public override string ToString()
		{
			return $"[{rank}, {suit}]";
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override bool Equals(object? obj)
		{
			if (obj == null)
			{
				return false;
			}
			else if (this.GetType != obj.GetType)
			{
				return false;
			}
			else if (base.Equals(obj))
			{
				return true;
			}
			Card other = (Card)obj;
			return Equals(rank, other.rank);
		}
	}
}
