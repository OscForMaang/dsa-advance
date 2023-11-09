﻿namespace DynamicProgramming.Knapsack
{
    internal class KnapsackProblem
    {
        /// <summary>
        /// Recursive knapsnap
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="values"></param>
        /// <param name="w"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Knapsack(int[] weights, int[] values, int w, int n)
        {
            if (w == 0 || n == 0)
                return 0;

            if (weights[n-1] <= w)
            {
                return Math.Max(values[n - 1] + Knapsack(weights, values, w - weights[n - 1], n - 1), Knapsack(weights, values, w, n - 1));

            }else
            {
                return Knapsack(weights, values, w, n - 1);
            }
        }

       /// <summary>
       /// Knapsack with memorization
       /// dp size n + 1 * w + 1
       /// </summary>
       /// <param name="weights"></param>
       /// <param name="values"></param>
       /// <param name="w"></param>
       /// <param name="n"></param>
       /// <param name="dp"></param>
       /// <returns></returns>
       public int Knapsack(int[] weights, int[] values, int w, int n, int[, ] dp)
       {
            if (w == 0 || n == 0)
                return 0;
            if (dp[n, w] != -1) // if sub problem is already solved
                return dp[n, w];
            // if sub problem is not solved 
            if (weights[n-1] <= w)
            {
                return dp[n, w] = Math.Max(values[n - 1] + Knapsack(weights, values, w - weights[n - 1], n - 1, dp), Knapsack(weights, values, w, n - 1));

            }
            else
            {
                return dp[n, w] = Knapsack(values, weights, w, n - 1);
            }
       }

        // Knapsack bottom approach 
        // knapsack dynamic programming
        /// <summary>
        /// n * w => n length of 
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="values"></param>
        /// <param name="w"></param>
        /// <param name="n"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public int Knapsapk1(int[] weights, int[] values, int w, int n, int[,] dp)
        {
            // Step 1: Base condition -> Initialization
            for (int i = 0; i < n + 1; i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i < w + 1; i++)
            {
                dp[0, i] = 0;
            }
            // Step 2: Convert Recursive to Iterative
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < w + 1; j++)
                {
                    if (weights[i-1] <= j)
                    {
                        dp[i, j] = Math.Max(values[i - 1] + dp[j - weights[i - 1], i - 1], dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[n, w];
        }

    }
}
