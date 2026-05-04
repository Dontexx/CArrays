using System;

class Program
{
    static void Main()
    {
        // ===== Завдання 1 =====
        Console.WriteLine("Завдання 1:");

        int[] arr1 = { 10, 5, 3, 4 };
        PrintArray(arr1, "Original:");
        SwapEvenPairs(arr1);
        PrintArray(arr1, "Result:");

        Console.WriteLine();

        // ===== Завдання 2 =====
        Console.WriteLine("Завдання 2:");

        int[] arr2 = { 5, 350, 350, 4, 350 };
        PrintArray(arr2, "Array:");
        int distance = MaxDistance(arr2);
        Console.WriteLine("Distance = " + distance);

        Console.WriteLine();

        // ===== Завдання 3 =====
        Console.WriteLine("Завдання 3:");

        int[,] matrix =
        {
            {2, 4, 3, 3},
            {5, 7, 8, 5},
            {2, 4, 3, 3},
            {5, 7, 8, 5}
        };

        Console.WriteLine("Original matrix:");
        PrintMatrix(matrix);

        TransformMatrix(matrix);

        Console.WriteLine("Transformed matrix:");
        PrintMatrix(matrix);
    }

    // ===== Завдання 1 функції =====
    static void SwapEvenPairs(int[] nums)
    {
        int n = nums.Length;

        for (int i = 0; i < n / 2; i++)
        {
            int j = n - 1 - i;

            if (nums[i] % 2 == 0 && nums[j] % 2 == 0)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }

    // ===== Завдання 2 функції =====
    static int MaxDistance(int[] nums)
    {
        int max = nums[0];

        foreach (int num in nums)
        {
            if (num > max)
                max = num;
        }

        int first = -1;
        int last = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == max)
            {
                if (first == -1)
                    first = i;

                last = i;
            }
        }

        return last - first;
    }

    // ===== Завдання 3 функції =====
    static void TransformMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j < i)
                    matrix[i, j] = 0;
                else if (j > i)
                    matrix[i, j] = 1;
            }
        }
    }

    // ===== Допоміжні функції =====
    static void PrintArray(int[] arr, string message)
    {
        Console.WriteLine(message + " " + string.Join(", ", arr));
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}