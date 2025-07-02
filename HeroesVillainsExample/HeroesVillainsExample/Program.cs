using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroVillainExample
{
    public class Program
    {
        public static void Main()
        {
            bool runAgain = true;
            while (runAgain)
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to the Heroes vs Villains Battle Simulator!");
                Console.WriteLine("You will need to enter the following values:");
                Console.WriteLine("1. Number of Villains (N)");
                Console.WriteLine("2. Number of Heroes (M)");
                Console.WriteLine("3. Health of each Hero (H)");
                Console.WriteLine("4. Health of each Villain (one per line, total of N values)");
                Console.WriteLine("--------------------------------------------------------");

                int N = 0;
                int M = 0;
                long H = 0; // Use long for H to match problem constraints and prevent potential overflow
                int[] V = null;

                try
                {
                    // 1. Read Number of Villains (N)
                    Console.Write("Enter the number of villains (N): ");
                    if (!int.TryParse(Console.ReadLine(), out N) || N < 0) // N can be 0 if all villains are skipped
                    {
                        Console.WriteLine("Error: Please enter a non-negative integer for N!");
                        continue;
                    }

                    // 2. Read Number of Heroes (M)
                    Console.Write("Enter the number of heroes (M): ");
                    if (!int.TryParse(Console.ReadLine(), out M) || M < 0) // M can be 0
                    {
                        Console.WriteLine("Error: Please enter a non-negative integer for M!");
                        continue;
                    }

                    // 3. Read Health of each Hero (H)
                    Console.Write("Enter the health of each hero (H): ");
                    if (!long.TryParse(Console.ReadLine(), out H) || H < 1) // H must be positive
                    {
                        Console.WriteLine("Error: Please enter a positive integer for H!");
                        continue;
                    }

                    // 4. Read Health of each Villain (V)
                    V = new int[N];
                    if (N > 0) // Only ask for villain health if N > 0
                    {
                        Console.WriteLine($"Enter the health of each villain (one per line, {N} values):");
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
                    }

                    // 5. Calculate the minimum number of villains to skip using binary search
                    int left = 0;
                    int right = N; // It's possible to remove all N villains
                    int answer = N; // Initialize with the worst-case scenario (remove all villains)

                    while (left <= right)
                    {
                        int mid = left + (right - left) / 2; // Calculate mid to prevent overflow for large left/right

                        // Simulate battle for villains starting from index 'mid'
                        bool possible = true;
                        int currentHeroCount = 0; // Tracks how many heroes have been used/defeated
                        long tempHeroHealth = H; // Health of the *current* hero fighting

                        // Iterate through the villains that are *not* skipped
                        for (int i = mid; i < N; /* No i++ here, controlled inside the loop */)
                        {
                            // If all heroes are defeated before all villains
                            if (currentHeroCount >= M)
                            {
                                possible = false;
                                break; // Heroes lose, cannot defeat remaining villains
                            }

                            int villainHealth = V[i];

                            if (tempHeroHealth > villainHealth)
                            {
                                // Hero wins: hero's health decreases, villain is defeated.
                                tempHeroHealth -= villainHealth;
                                i++; // Move to the next villain
                            }
                            else if (tempHeroHealth < villainHealth)
                            {
                                // Villain wins: current hero is defeated.
                                // The *same villain* remains to fight the next hero.
                                currentHeroCount++; // One hero used/defeated
                                tempHeroHealth = H; // New hero steps up with full health
                                // i does NOT increment, the same villain (V[i]) will fight the next hero
                            }
                            else // tempHeroHealth == villainHealth (Both are defeated)
                            {
                                // Both are defeated.
                                // Next hero steps up with full health. Move to the next villain.
                                currentHeroCount++; // One hero used/defeated
                                tempHeroHealth = H; // New hero starts with full health
                                i++; // Move to the next villain
                            }
                        }

                        // After simulating the battle for 'mid' skipped villains:
                        if (possible)
                        {
                            // If it's possible to win, try to skip fewer villains
                            answer = mid;
                            right = mid - 1;
                        }
                        else
                        {
                            // If not possible, need to skip more villains
                            left = mid + 1;
                        }
                    }

                    // 6. Output the result
                    Console.WriteLine($"\nMinimum number of villains to skip from the front: {answer}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.WriteLine("Please try again.");
                    continue;
                }

                // 7. Ask if user wants to run again
                Console.Write("\nDo you want to run the program again? (Y/N): ");
                string userChoice = Console.ReadLine().Trim().ToLower();
                if (userChoice != "y" && userChoice != "Y")
                {
                    runAgain = false;
                    Console.WriteLine("\nThank you for using the Heroes vs Villains Battle Simulator!");
                }
            }
        }
    }
}