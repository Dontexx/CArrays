using System;

class Program
{
    static void Main()
    {
        // ===== RUN TASKS =====
        Console.WriteLine("=== TASKS ===\n");

        // Task 1
        int[] arr1 = { 10, 5, 3, 4 };
        PrintArray(arr1, "Task 1 Original:");
        SwapEvenPairs(arr1);
        PrintArray(arr1, "Task 1 Result:");

        Console.WriteLine();

        // Task 2
        int[] arr2 = { 5, 350, 350, 4, 350 };
        PrintArray(arr2, "Task 2 Array:");
        Console.WriteLine("Distance = " + MaxDistance(arr2));

        Console.WriteLine();

        // Task 3
        int[,] matrix =
        {
            {2, 4, 3},
            {5, 7, 8},
            {2, 4, 3}
        };

        Console.WriteLine("Task 3 Original matrix:");
        PrintMatrix(matrix);

        TransformMatrix(matrix);

        Console.WriteLine("Task 3 Transformed matrix:");
        PrintMatrix(matrix);

        // ===== RUN TESTS =====
        Console.WriteLine("\n=== TESTS ===\n");

        TestTask1();
        TestTask2();
        TestTask3();
    }

    // ===== TASK 1 =====
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

    // ===== TASK 2 =====
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

    // ===== TASK 3 =====
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

    // ===== TESTS =====
    static void TestTask1()
    {
        Console.WriteLine("Task 1 Tests:");

        int[] input = { 10, 5, 3, 4 };
        int[] expected = { 4, 5, 3, 10 };

        SwapEvenPairs(input);

        PrintTestResult(AreArraysEqual(input, expected));
    }

    static void TestTask2()
    {
        Console.WriteLine("Task 2 Tests:");

        int[] input = { 5, 350, 350, 4, 350 };
        int expected = 3;

        int result = MaxDistance(input);

        PrintTestResult(result == expected);
    }

    static void TestTask3()
    {
        Console.WriteLine("Task 3 Tests:");

        int[,] input =
        {
            {2, 4, 3},
            {5, 7, 8},
            {2, 4, 3}
        };

        int[,] expected =
        {
            {2, 1, 1},
            {0, 7, 1},
            {0, 0, 3}
        };

        TransformMatrix(input);

        PrintTestResult(AreMatricesEqual(input, expected));
    }

    // ===== HELPERS =====
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

    static void PrintTestResult(bool passed)
    {
        if (passed)
            Console.WriteLine("✅ Test passed");
        else
            Console.WriteLine("❌ Test failed");

        Console.WriteLine();
    }

    static bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length)
            return false;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
                return false;
        }

        return true;
    }

    static bool AreMatricesEqual(int[,] a, int[,] b)
    {
        int n = a.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (a[i, j] != b[i, j])
                    return false;
            }
        }

        return true;
    }
}