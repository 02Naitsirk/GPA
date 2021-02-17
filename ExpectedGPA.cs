namespace GPA
{
    class ExpectedGPA
    {
        public static int CalculateGPA(double percent)
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

        public static int CalculateGPA(int questionsCorrect, int questionCount)
        {
            double percent = (double)questionsCorrect / questionCount;
            int GPA = CalculateGPA(percent);
            return GPA;
        }

        public static double CalculateExpectedGPA(int questions, double skillLevel)
        {
            double expectedGPA = 0;

            for (int i = 0; i <= questions; i++)
            {
                expectedGPA += CalculateGPA(i, questions) * Binomial.BinomialProbability(questions, i, skillLevel);
            }

            return expectedGPA;
        }

        public static double[] CalculateExpectedGPAArray(int questions, double skillLevel)
        {
            double[] GPAprobabilities = new double[5] { 0.0, 0.0, 0.0, 0.0, 0.0 };

            for (int i = 0; i <= questions; i++)
            {
                int currentGPA = CalculateGPA(i, questions);
                double GPAprobability = Binomial.BinomialProbability(questions, i, skillLevel);
                GPAprobabilities[currentGPA] += GPAprobability;
            }

            return GPAprobabilities;
        }
    }
}
