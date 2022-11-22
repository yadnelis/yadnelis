namespace StealPileGame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StealPileGame game = new StealPileGame();
			Console.SetWindowSize(150, 40);
			game.Start();
		}
	}
}