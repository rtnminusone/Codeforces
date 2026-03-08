#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

using System.Text;

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

	public static int N = 2, M;
	public static char[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = null;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == N - 1 && p.y == M - 1) return "YES";

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					if (T[pos.x, pos.y] == '<')
					{
						if (Create(pos.x, pos.y - 1, out Pos nextp1) && !V[nextp1.x, nextp1.y])
						{
							Q.Enqueue(nextp1);
							V[nextp1.x, nextp1.y] = true;
						}
					}
					else
					{
						if (Create(pos.x, pos.y + 1, out Pos nextp2) && !V[nextp2.x, nextp2.y])
						{
							Q.Enqueue(nextp2);
							V[nextp2.x, nextp2.y] = true;
						}
					}
				}
			}
		}

		return "NO";
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			M = int.Parse(Console.ReadLine());
			T = new char[N, M];
			V = new bool[N, M];
			for (int i = 0; i < N; i++)
			{
				string S = Console.ReadLine();
				for (int j = 0; j < M; j++)
				{
					T[i, j] = S[j];
				}
			}
			Q.Clear();
			Q.Enqueue(new Pos(0, 0));

			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}