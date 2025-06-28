# SP-Coding-Questions
Coding Questions

| Question | Description | C# Code | Python Code |
|----------|-------------|---------|-------------|
| **1.**   | **Energy Exercise Example**<br>There are N exercises in the gym. Each of these exercises drains Ai
amount of energy from your body.
You feel tired if your energy reaches 0 or below. Calculate the
minimum number of exercises you have to perform such that you
become tired. Every unique exercise can only be performed at
most 2 times as others also have to use the machines.
If performing all the exercises does not make you feel tired, return
-1.
Parameters:
E :: INTEGER
The first line contains an integer, E, denoting the Energy.
E :: 1 -> 10^5
N :: INTEGER
The next line contains an integer, N, denoting the number of
exercises.
N :: 1 -> 10^5
A :: INTEGER ARRAY
Each line i of the N subsequent lines (where 0 ≤ i < N) contains an
integer describing the amount of energy drained by ith exercise.
A[i] :: 1 -> 10^5
Case\#: 1
Input:
6
2
1
2
Output:
4
E = 6
Do 1st exercise 2 times
Do 2nd exercise 2 times
Hence, total exercise done 4.
Case\#: 2
Input:
10
2
1
2
Output:
-1
E = 10
By doing both the exercises 2 times you won’t feel tired.
Case\#: 3
Input:
2
3
1
5
2
Output:
1
E = 2
Use 3rd exercise 1 time.
Hence, total exercise done 1

give me markdown of above example

Here is a Markdown-formatted version of your example, including all three cases:

## Gym Energy Drain Problem — Example Cases

### Problem Statement

You have **E** energy.
There are **N** exercises in the gym.
Each exercise drains a certain amount of energy (**A[i]**) from your body.
You feel tired if your energy reaches **0 or below**.
Each unique exercise can be performed at most **2 times**.
Calculate the **minimum number of exercises** you need to perform to become tired.
If performing all exercises (at most 2 times each) does not make you tired, return **-1**.

### Case 1

**Input:**

```
6
2
1
2
```

**Explanation:**

- E = 6
- N = 2
- A = [^1][^2]

**Steps:**

- Do 1st exercise 2 times (drains 2 × 1 = 2)
- Do 2nd exercise 2 times (drains 2 × 2 = 4)
- Total energy drained = 2 + 4 = 6

**Total exercises done:** 4

**Output:**

```
4
```


### Case 2

**Input:**

```
10
2
1
2
```

**Explanation:**

- E = 10
- N = 2
- A = [^1][^2]

**Steps:**

- Do 1st exercise 2 times (drains 2)
- Do 2nd exercise 2 times (drains 4)
- Total energy drained = 2 + 4 = 6

**Energy left:** 10 - 6 = 4 (still not tired)

**Output:**

```
-1
```


### Case 3

**Input:**

```
2
3
1
5
2
```

**Explanation:**

- E = 2
- N = 3
- A = [^1][^5][^2]

**Steps:**

- Use 3rd exercise (drains 2), energy becomes 0

**Total exercises done:** 1

**Output:**

```
1
```
| [Click here to see the C# code](https://github.com/rajeabhi/SP-Coding-Questions/blob/main/EnergyExerciseExample/EnergyExerciseExample.cs) 
| [Click here to see the Python code](https://github.com/rajeabhi/SP-Coding-Questions/blob/main/EnergyExerciseExample/EnergyExerciseExample.py) 

| **2.**   | | | |
| **3.**   | | | |
| **4.**   | | | |
| **5.**   | | | |

