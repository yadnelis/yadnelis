using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StealPileGame
{
	//There is no assignment relevant material here
	//Someone asked why I put so much work, the answer is because it is fun.
	internal class UI
	{
		ConsoleColor prefBackroundColor;
		ConsoleColor prefForgroundColor;

		public UI() : this(ConsoleColor.Black, ConsoleColor.Gray) { }

		public UI(ConsoleColor prefBackroundColor, ConsoleColor prefForgroundColor)
		{
			this.prefBackroundColor = prefBackroundColor;
			this.prefForgroundColor = prefForgroundColor;
		}

		public void NewScreen(int cursorTop = 0)
		{
			Console.BackgroundColor = prefBackroundColor;
			Console.ForegroundColor = prefForgroundColor;
			Console.Clear();
			Console.CursorTop = cursorTop;
		}

		public static void PlaceText<T>(T s, int margin)
		{
			string row = "";
			string text = s.ToString();

			//So I don't have to add "/n" at the end of everything.
			if (text.Length != 0 && text[text.Length - 1] != '\n') { text += '\n'; }
			
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '\n')
				{
					Console.SetCursorPosition(margin, Console.CursorTop);
					Console.WriteLine(row);
					row = "";
				}
				else
				{
					row += text[i];
				}
			}
		}

		public static void CenterText<T>(T s)
		{
			string row = "";
			string text = s.ToString();

			//So I don't have to add "/n" at the end of everything.
			if (text.Length != 0 && text[text.Length - 1] != '\n') { text += '\n'; }

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '\n')
				{
					Console.SetCursorPosition((Console.WindowWidth - row.Length) / 2, Console.CursorTop);
					Console.Write(row);
					row = "";
					Console.CursorTop++;
					Console.CursorLeft = 0;
				}
				else
				{
					row += text[i];
				}
			}
		}
	}
}
