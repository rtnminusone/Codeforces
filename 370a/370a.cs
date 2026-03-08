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

	public static int N = 8, M = 8, X, Y;
	public static bool[,] V = new bool[N, M];
	public static Queue<(Pos, int)> Q = new Queue<(Pos, int)>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = null;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (V[x, y]) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			var (p, w) = Q.Dequeue();

			if (p.x == X && p.y == Y) return w;

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					Q.Enqueue((pos, w + 1));
					V[pos.x, pos.y] = true;
				}
			}
		}

		return 0;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		int x = int.Parse(S[0]) - 1;
		int y = int.Parse(S[1]) - 1;
		X = int.Parse(S[2]) - 1;
		Y = int.Parse(S[3]) - 1;
		int R = (x == X || y == Y) ? 1 : 2;
		int B = ((x + y) % 2 != (X + Y) % 2) ? 0 : Math.Abs(x - X) == Math.Abs(y - Y) ? 1 : 2;
		Q.Enqueue((new Pos(x, y), 0));
		V[x, y] = true;

		Console.WriteLine(R + " " + B + " " + BFS());
	}
}