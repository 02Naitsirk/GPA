using System;

namespace GPA
{
    class Binomial
    {
        public static double BinomialProbability(int trials, int successes, double successProbability)
        {
            double choose = Factorial(trials) / (Factorial(successes) * Factorial(trials - successes));
            double success = Math.Pow(successProbability, successes);
            double failure = Math.Pow(1 - successProbability, trials - successes);

            return choose * success * failure;
        }

        private static double Factorial(int n)
        {
            double product = 1.0;
            for (int i = 1; i <= n; i++)
            {
                product *= i;
            }

            return product;
        }
    }
}
