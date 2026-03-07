#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[] T, R;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			R[T[q]] = w;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);
		T = new int[N];
		R = new int[K];
		V = new bool[N];
		L = new List<int>[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]) - 1;
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
		}

		Q.Enqueue((0, 0));
		V[0] = true;

		BFS();

		Console.WriteLine(string.Join(" ", R));
	}
}