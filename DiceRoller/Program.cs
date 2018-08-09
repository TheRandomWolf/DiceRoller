using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
	class Program
	{
		static bool firstTime = true;
		static void Main()
		{
			if (firstTime == true)
			{
				Console.WriteLine("Hello! Please input the amount of dice you want to roll and the dice's number of sides with the letter 'd' inbetween them like this: 3d5");
				Console.WriteLine("the example above would roll 3 dice with 5 sides.");
				Console.WriteLine("If you want to exit the program please type 'exit'");
				firstTime = false;
			}
			string input = Console.ReadLine();
			if (input.ToLower() == "exit")
			{
				Environment.Exit(0);
			}
			else
			{
				string[] diceInfo = input.ToLower().Split('d');
				int times, sides;
				int.TryParse(diceInfo[0], out times);
				int.TryParse(diceInfo[1], out sides);
				int[] rolls =GetDiceRolls(sides, times);
				string output = FormatResults(rolls);
				Console.WriteLine(output);
				Main();
			}
		}
		static int[] GetDiceRolls(int sides, int times)
		{
			Dice d = new Dice(sides);
			int[] rolls = d.Roll(times);
			return rolls;
		}
		static string FormatResults(int[] results)
		{
			int total = results.Sum();
			StringBuilder sb = new StringBuilder(total + ": ");
			foreach (int roll in results) sb.Append(roll + ", ");
			return sb.ToString();
		}
	}
}
