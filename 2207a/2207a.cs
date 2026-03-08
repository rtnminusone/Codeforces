#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

using System.Text;

class Program
{
	public static void Solve(string S, int l, int r, ref int min, ref int max)
	{
		int first = -1, last = -1;

		for (int i = l; i <= r; i++)
		{
			if (S[i] == '1')
			{
				if (first == -1) first = i;
				last = i;
			}
		}

		if (first == -1) return;

		int e = last - first + 1;
		max += e;
		min += (e + 2) / 2;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			int N = int.Parse(Console.ReadLine());
			string S = Console.ReadLine();

			int min = 0, max = 0, start = 0;
			for (int i = 0; i < N - 1; i++)
			{
				if (S[i] == '0' && S[i + 1] == '0')
				{
					Solve(S, start, i, ref min, ref max);
					start = i + 1;
				}
			}

			Solve(S, start, N - 1, ref min, ref max);

			sb.AppendLine(min + " " + max);
		}

		Console.WriteLine(sb.ToString());
	}
}