using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DiceRoller
{
	public class Dice
	{
		protected static Random r;
		public Dice(int sides)
		{
			Sides = sides;
			byte[] seed = new byte[1];
			new RNGCryptoServiceProvider().GetBytes(seed);
			r = new Random(seed[0]);
		}
		public int Sides { get; protected set; }
		public int[] Roll(int times = 1) 
		{
			int[] results = new int[times];
			for(int i = 0; i < results.Length; i++)
			{
				results[i] = r.Next(1, Sides);
			}
			return results;
		}
	}
}
