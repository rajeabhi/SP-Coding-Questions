using System;
using System.Text;

namespace EnergyEexerciseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information

            try
            {
                // Read and validate first line
                string[] firstLine = Console.ReadLine()?.Split();
                if (firstLine == null || firstLine.Length != 2)
                {
                    Console.WriteLine("Invalid input: First line must contain exactly two integers.");
                    return;
                }

                if (!int.TryParse(firstLine[0], out int E) || !int.TryParse(firstLine[1], out int N))
                {
                    Console.WriteLine("Invalid input: Energy and exercise count must be integers.");
                    return;
                }
                if (E < 1 || N < 1)
                {
                    Console.WriteLine("Invalid input: Energy and exercise count must be positive.");
                    return;
                }

                // Read and validate second line
                string[] secondLine = Console.ReadLine()?.Split();
                if (secondLine == null || secondLine.Length != N)
                {
                    Console.WriteLine($"Invalid input: Second line must contain exactly {N} integers.");
                    return;
                }

                int[] A = new int[N];
                for (int i = 0; i < N; i++)
                {
                    if (!int.TryParse(secondLine[i], out A[i]) || A[i] < 1)
                    {
                        Console.WriteLine("Invalid input: All exercise drains must be positive integers.");
                        return;
                    }
                }

                calculateEnergy(E, N, A);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static void calculateEnergy(int N, int P, int[] K)
        {
            if (K.Length < P)
            {
                Console.WriteLine(-1);
                return;
            }
            else
            {
                int[] sorted = K.OrderByDescending(x => x).ToArray();

                int cnt = 0;
                foreach (int k in sorted)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        N = N - k;
                        cnt++;
                        if (N <= 0)
                        {
                            Console.WriteLine(cnt);
                            return;
                        }
                    }
                    if (N <= 0)
                    {
                        Console.WriteLine(cnt);
                        return;
                    }
                }
                if (N > 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }
    }
}
