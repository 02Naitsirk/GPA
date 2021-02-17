using System;

namespace GPA
{
    class ExpectedGrade
    {
        /// <summary>
        /// Calculates a grade / GPA given a percentage.
        /// </summary>

        public static int CalculateGrade(double percent)
        {
            if (percent < 0.6)
            {
                return 0;
            }
            else if (percent < 0.7)
            {
                return 1;
            }
            else if (percent < 0.8)
            {
                return 2;
            }
            else if (percent < 0.9)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        /// <summary>
        /// Calculates a grade / GPA given the number of questions, and the number of questions correct.
        /// </summary>
        /// <param name="questionsCorrect">
        /// Number of questions correct.
        /// </param>
        /// <param name="questionCount">
        /// Number of questions.
        /// </param>
        /// <returns>
        /// The grade or GPA.
        /// </returns>

        public static int CalculateGrade(int questionsCorrect, int questionCount)
        {
            double percent = (double)questionsCorrect / questionCount;
            int GPA = CalculateGrade(percent);
            return GPA;
        }

        /// <summary>
        /// Uses a binomial distribution with success probability "skillLevel" and number of trials "questions" to calculate
        /// the expected grade / GPA given a number of questions and skill level.
        /// </summary>
        /// <param name="questions">
        /// Number of questions.
        /// </param>
        /// <param name="skillLevel">
        /// The probability to get each question correct, from 0 to 1, or 0% to 100%.
        /// </param>
        /// <returns>
        /// Expected grade / GPA.
        /// </returns>

        public static double CalculateExpectedGrade(int questions, double skillLevel)
        {
            double expectedGPA = 0;

            for (int i = 0; i <= questions; i++)
            {
                expectedGPA += CalculateGrade(i, questions) * Binomial.BinomialProbability(questions, i, skillLevel);
            }

            return expectedGPA;
        }

        /// <summary>
        /// Creates an array with indices representing GPAs and values representing the probabilities to get that GPA, given
        /// a skill level.
        /// </summary>
        /// <param name="questions">
        /// Number of questions.
        /// </param>
        /// <param name="skillLevel">
        /// The probability to get each question correct, from 0 to 1, or 0% to 100%.
        /// </param>
        /// <returns></returns>

        public static double[] CalculateGradeProbabilities(int questions, double skillLevel)
        {
            double[] GPAprobabilities = new double[5] { 0.0, 0.0, 0.0, 0.0, 0.0 };

            for (int i = 0; i <= questions; i++)
            {
                int currentGPA = CalculateGrade(i, questions);
                double GPAprobability = Binomial.BinomialProbability(questions, i, skillLevel);
                GPAprobabilities[currentGPA] += GPAprobability;
            }

            return GPAprobabilities;
        }

        /// <summary>
        /// Print results.
        /// </summary>

        public static void Print(int questions, double skillLevel)
        {
            double[] gradeProbabilities = ExpectedGrade.CalculateGradeProbabilities(questions, skillLevel);
            double expectedGrade = ExpectedGrade.CalculateExpectedGrade(questions, skillLevel);

            double[] gradeOdds = new double[5];

            for (int i = 0; i < 5; i++)
            {
                gradeOdds[i] = 1 / gradeProbabilities[i];
            }

            Console.WriteLine("\nQuestions: " + questions);
            Console.WriteLine($"Skill Level: {skillLevel} ({Math.Round(100 * skillLevel)}% chance to get each question correct)\n");

            Console.WriteLine($"{"Grade", -10} {"Chance", -10} {"Odds", -10}\n");

            for (int i = 0; i < gradeProbabilities.Length; i++)
            {
                Console.WriteLine($"{(double)i, -10} {Math.Round(gradeProbabilities[i], 5), -10} 1 in {Math.Round(gradeOdds[i], 1), -10}");
            }

            Console.WriteLine("\nExpected Grade: " + Math.Round(expectedGrade, 2) + "\n");
        }
    }
}
