#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public class Pos
	{
		public int x;
		public int y;
		public string s;
		public Pos? p;

		public Pos(int x, int y, string s, Pos? p)
		{
			this.x = x;
			this.y = y;
			this.s = s;
			this.p = p;
		}
	}

	public static int N = 8, X, Y;
	public static bool[,] V = new bool[N, N];
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
	public static string[] dt = { "LU", "U", "RU", "L", "R", "LD", "D", "RD" };

	public static Pos Create(int x, int y, string s, Pos p)
	{
		if (x < 0 || x >= N || y < 0 || y >= N) return null;
		if (V[x, y]) return null;

		return new Pos(x, y, s, p);
	}

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == X && p.y == Y)
			{
				List<string> L = new List<string>();
				while (p != null)
				{
					L.Add(p.s);
					p = p.p;
				}
				L.Reverse();
				Console.WriteLine((L.Count - 1) + string.Join("\n", L));
				return;
			}

			for (int i = 0; i < 8; i++)
			{
				Pos nextp = Create(p.x + dx[i], p.y + dy[i], dt[i], p);
				if (nextp == null) continue;
				Q.Enqueue(nextp);
				V[nextp.x, nextp.y] = true;
			}
		}
	}

	public static void Main()
	{
		string S = Console.ReadLine();
		Y = S[0] - 'a';
		X = 7 - (S[1] - '1');
		Q.Enqueue(new Pos(X, Y, "", null));
		V[X, Y] = true;
		S = Console.ReadLine();
		Y = S[0] - 'a';
		X = 7 - (S[1] - '1');

		BFS();
	}
}