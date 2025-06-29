import sys

def main():
    run_again = True
    while run_again:
        print("\nWelcome to the Heroes vs Villains Battle Simulator!")
        print("You will need to enter the following values:")
        print("1. Number of Heroes (M)")
        print("2. Health of each Hero (H)")
        print("3. Number of Villains (N)")
        print("4. Health of each Villain (one per line, total of N values)")
        print("--------------------------------------------------------")

        try:
            # 1. Read Number of Heroes (M)
            while True:
                try:
                    M = int(input("Enter the number of heroes (M): "))
                    if M < 1:
                        print("Error: Please enter a positive integer for M!")
                        continue
                    break
                except ValueError:
                    print("Error: Please enter a positive integer for M!")

            # 2. Read Health of each Hero (H)
            while True:
                try:
                    H = int(input("Enter the health of each hero (H): "))
                    if H < 1:
                        print("Error: Please enter a positive integer for H!")
                        continue
                    break
                except ValueError:
                    print("Error: Please enter a positive integer for H!")

            # 3. Read Number of Villains (N)
            while True:
                try:
                    N = int(input("Enter the number of villains (N): "))
                    if N < 1:
                        print("Error: Please enter a positive integer for N!")
                        continue
                    break
                except ValueError:
                    print("Error: Please enter a positive integer for N!")

            # 4. Read Health of each Villain (V)
            V = []
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

            # 5. Calculate the minimum number of villains to skip
            left = 0
            right = N
            answer = N
            while left <= right:
                mid = (left + right) // 2
                possible = True
                hero_index = 0
                current_hero_health = H
                for i in range(mid, N):
                    if V[i] > H:
                        possible = False
                        break
                    if current_hero_health > V[i]:
                        current_hero_health -= V[i]
                    else:
                        hero_index += 1
                        if hero_index >= M:
                            possible = False
                            break
                        current_hero_health = H - V[i]
                if possible:
                    answer = mid
                    right = mid - 1
                else:
                    left = mid + 1

            # 6. Output the result
            print(f"\nMinimum number of villains to skip from the front: {answer}")

        except Exception as ex:
            print(f"An error occurred: {ex}")
            print("Please try again.")
            continue

        # 7. Ask if user wants to run again
        user_choice = input("\nDo you want to run the program again? (Y/N): ").strip().lower()
        if user_choice not in ('y', 'yes'):
            run_again = False
            print("\nThank you for using the Heroes vs Villains Battle Simulator!")

if __name__ == "__main__":
    main()
