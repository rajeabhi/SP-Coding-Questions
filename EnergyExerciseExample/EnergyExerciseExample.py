def calculate_energy(E, N, drains):
    if len(drains) < N:
        print("Total exercises done:", -1)
        return
    
    sorted_drains = sorted(drains, reverse=True)
    count = 0
    energy = E
    
    for drain in sorted_drains:
        for _ in range(2):  # each exercise can be done at most twice
            energy -= drain
            count += 1
            if energy <= 0:
                print("Total exercises done:", count)
                return
    if energy > 0:
        print("Total exercises done:", -1)

def main():
    try:
        print("Enter Energy and Exercise Count (Number only) separated by space. :")
        # Read and validate first line
        first_line = input().strip().split()
        if len(first_line) != 2:
            print("Invalid input: First line must contain exactly two integers.")
            return
        
        E_str, N_str = first_line
        if not (E_str.isdigit() and N_str.isdigit()):
            print("Invalid input: Energy and exercise count must be integers.")
            return
        
        E = int(E_str)
        N = int(N_str)
        
        if E < 1 or N < 1:
            print("Invalid input: Energy and exercise count must be positive.")
            return
        
        print("Enter Exercise Drains (Number only) separated by space. :")
        # Read and validate second line
        second_line = input().strip().split()
        if len(second_line) != N:
            print(f"Invalid input: Second line must contain exactly {N} integers.")
            return
        
        drains = []
        for val in second_line:
            if not val.isdigit() or int(val) < 1:
                print("Invalid input: All exercise drains must be positive integers.")
                return
            drains.append(int(val))
        
        calculate_energy(E, N, drains)
        
    except Exception as e:
        print("An unexpected error occurred:", e)

if __name__ == "__main__":
    main()
