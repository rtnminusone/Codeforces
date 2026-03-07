#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

class Program
{
	public class Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N, K;
	public static char[,] T;
	public static bool[,] V;
	public static Queue<(Pos, int)> Q = new Queue<(Pos, int)>();

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = null;

		if (x < 0 || x >= 2 || y < 0) return false;
		if (y < N && (T[x, y] == 'X')) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			var (p, w) = Q.Dequeue();

			if (p.y < w) continue;

			if (p.y + K >= N) return "YES";
			if (p.y + K >= w + 1 && Create(1 - p.x, p.y + K, out Pos pos))
			{
				if (!V[pos.x, pos.y])
				{
					Q.Enqueue((pos, w + 1));
					V[pos.x, pos.y] = true;
				}
			}
			if (p.y + 1 >= N) return "YES";
			if (p.y + 1 >= w + 1 && Create(p.x, p.y + 1, out Pos pos2))
			{
				if (!V[pos2.x, pos2.y])
				{
					Q.Enqueue((pos2, w + 1));
					V[pos2.x, pos2.y] = true;
				}
			}
			if (p.y - 1 >= w + 1 && Create(p.x, p.y - 1, out Pos pos3))
			{
				if (!V[pos3.x, pos3.y])
				{
					Q.Enqueue((pos3, w + 1));
					V[pos3.x, pos3.y] = true;
				}
			}
		}

		return "NO";
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new char[2, N];
		V = new bool[2, N];
		for (int i = 0; i < 2; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = S[0][j];
			}
		}

		Q.Enqueue((new Pos(0, 0), 0));
		V[0, 0] = true;

		Console.WriteLine(BFS());
	}
}