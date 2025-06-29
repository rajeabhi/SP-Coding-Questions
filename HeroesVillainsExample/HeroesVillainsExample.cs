using System;

namespace HeroVillainExample
{
    public class Program
    {
        public static void Main()
        {
            bool runAgain = true;
            while (runAgain)
            {
                Console.WriteLine("\nWelcome to the Heroes vs Villains Battle Simulator!");
                Console.WriteLine("You will need to enter the following values:");
                Console.WriteLine("1. Number of Villains (N)");
                Console.WriteLine("2. Number of Heroes (M)");
                Console.WriteLine("3. Health of each Hero (H)");
                Console.WriteLine("4. Health of each Villain (one per line, total of N values)");
                Console.WriteLine("--------------------------------------------------------");

                int N = 0, M = 0, H = 0;
                int[] V = null;

                try
                {
                    // 1. Read Number of Villains (N)
                    Console.Write("Enter the number of villains (N): ");
                    if (!int.TryParse(Console.ReadLine(), out N) || N < 1)
                    {
                        Console.WriteLine("Error: Please enter a positive integer for N!");
                        continue;
                    }

                    // 2. Read Number of Heroes (M)
                    Console.Write("Enter the number of heroes (M): ");
                    if (!int.TryParse(Console.ReadLine(), out M) || M < 1)
                    {
                        Console.WriteLine("Error: Please enter a positive integer for M!");
                        continue;
                    }

                    // 3. Read Health of each Hero (H)
                    Console.Write("Enter the health of each hero (H): ");
                    if (!int.TryParse(Console.ReadLine(), out H) || H < 1)
                    {
                        Console.WriteLine("Error: Please enter a positive integer for H!");
                        continue;
                    }

                    // 4. Read Health of each Villain (V)
                    Console.WriteLine($"Enter the health of each villain (one per line, {N} values):");
                    V = new int[N];
                    for (int i = 0; i < N; i++)
                    {
                        Console.Write($"Villain {i + 1}: ");
                        if (!int.TryParse(Console.ReadLine(), out V[i]) || V[i] < 1)
                        {
                            Console.WriteLine("Error: Please enter a positive integer for each villain's health!");
                            i--; // Try this villain again
                            continue;
                        }
                    }

                    // 5. Calculate the minimum number of villains to skip
                    int left = 0, right = N, answer = N;
                    while (left <= right)
                    {
                        int mid = (left + right) / 2;
                        bool possible = true;
                        int heroIndex = 0;
                        long currentHeroHealth = H;
                        for (int i = mid; i < N; i++)
                        {
                            if (V[i] > H)
                            {
                                possible = false;
                                break;
                            }
                            if (currentHeroHealth > V[i])
                            {
                                currentHeroHealth -= V[i];
                            }
                            else
                            {
                                heroIndex++;
                                if (heroIndex >= M)
                                {
                                    possible = false;
                                    break;
                                }
                                currentHeroHealth = H - V[i];
                            }
                        }
                        if (possible)
                        {
                            answer = mid;
                            right = mid - 1;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }

                    // 6. Output the result
                    Console.WriteLine($"\nMinimum number of villains to skip from the front: {answer}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine("Please try again.");
                    continue;
                }

                // 7. Ask if user wants to run again
                Console.Write("\nDo you want to run the program again? (yes/no): ");
                string userChoice = Console.ReadLine().Trim().ToLower();
                if (userChoice != "yes")
                {
                    runAgain = false;
                    Console.WriteLine("\nThank you for using the Heroes vs Villains Battle Simulator!");
                }
            }
        }
    }
}