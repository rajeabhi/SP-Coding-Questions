import sys

def main():
    run_again = True
    while run_again:
        print("\nWelcome to the Heroes vs Villains Battle Simulator!")
        print("You will need to enter the following values:")
        print("1. Number of Villains (N)")
        print("2. Number of Heroes (M)")
        print("3. Health of each Hero (H)")        
        print("4. Health of each Villain (one per line, total of N values)")
        print("--------------------------------------------------------")

        try:

            # 1. Read Number of Villains (N)
            while True:
                try:
                    N = int(input("Enter the number of villains (N): "))
                    # N must be a positive integer as per problem constraints (1 to 2e5)
                    # However, for the binary search, N can be 0 if all villains are skipped.
                    # We'll allow N=0 here for robustness, although problem statement implies N>=1.
                    if N < 0:
                        print("Error: Please enter a non-negative integer for N!")
                        continue
                    break
                except ValueError:
                    print("Error: Please enter a non-negative integer for N!")

            # 2. Read Number of Heroes (M)
            while True:
                try:
                    M = int(input("Enter the number of heroes (M): "))
                    # M must be a positive integer as per problem constraints (1 to 2e5)
                    if M < 1:
                        print("Error: Please enter a positive integer for M!")
                        continue
                    break
                except ValueError:
                    print("Error: Please enter a positive integer for M!")

            # 3. Read Health of each Hero (H)
            while True:
                try:
                    H = int(input("Enter the health of each hero (H): "))
                    # H must be a positive integer as per problem constraints (1 to 10^9)
                    if H < 1:
                        print("Error: Please enter a positive integer for H!")
                        continue
                    break
                except ValueError:
                    print("Error: Please enter a positive integer for H!")
            
            # 4. Read Health of each Villain (V)
            V = []
            if N > 0: # Only ask for villain health if N > 0
                print(f"Enter the health of each villain (one per line, {N} values):")
                for i in range(N):
                    while True:
                        try:
                            v = int(input(f"Villain {i+1}: "))
                            if v < 1:
                                print("Error: Please enter a positive integer for each villain's health!")
                                continue
                            V.append(v)
                            break
                        except ValueError:
                            print("Error: Please enter a positive integer for each villain's health!")

            # 5. Calculate the minimum number of villains to skip using binary search
            left = 0
            right = N # It's possible to remove all N villains
            answer = N # Initialize with the worst-case scenario (remove all villains)

            while left <= right:
                mid = (left + right) // 2 # Calculate mid using integer division
                
                # Simulate battle for villains starting from index 'mid'
                possible = True
                current_hero_count = 0 # Tracks how many heroes have been used/defeated
                current_hero_health = H # Health of the *current* hero fighting

                # Use a while loop to control villain index 'i' manually
                i = mid 
                while i < N:
                    # If all heroes are defeated before all villains
                    if current_hero_count >= M:
                        possible = False
                        break # Heroes lose, cannot defeat remaining villains

                    villain_health = V[i]

                    if current_hero_health > villain_health:
                        # Hero wins: hero's health decreases, villain is defeated.
                        current_hero_health -= villain_health
                        i += 1 # Move to the next villain
                    elif current_hero_health < villain_health:
                        # Villain wins: current hero is defeated.
                        # The *same villain* remains to fight the next hero.
                        current_hero_count += 1 # One hero used/defeated
                        current_hero_health = H # New hero steps up with full health
                        # i does NOT increment, the same villain (V[i]) will fight the next hero
                    else: # current_hero_health == villain_health (Both are defeated)
                        # Both are defeated.
                        # Next hero steps up with full health. Move to the next villain.
                        current_hero_count += 1 # One hero used/defeated
                        current_hero_health = H # New hero starts with full health
                        i += 1 # Move to the next villain
                
                # After simulating the battle for 'mid' skipped villains:
                if possible:
                    # If it's possible to win, try to skip fewer villains
                    answer = mid
                    right = mid - 1
                else:
                    # If not possible, need to skip more villains
                    left = mid + 1

            # 6. Output the result
            print(f"\nMinimum number of villains to skip from the front: {answer}")

        except Exception as ex:
            print(f"An unexpected error occurred: {ex}")
            print("Please try again.")
            continue

        # 7. Ask if user wants to run again
        user_choice = input("\nDo you want to run the program again? (Y/N): ").strip().lower()
        if user_choice not in ('y', 'yes'):
            run_again = False
            print("\nThank you for using the Heroes vs Villains Battle Simulator!")

if __name__ == "__main__":
    main()