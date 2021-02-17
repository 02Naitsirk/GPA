using System;

namespace GPA
{
    class Program
    {
        static void Main(string[] args)
        {
            int questionCount = Convert.ToInt32(args[0]);
            double skillLevel = Convert.ToDouble(args[1]);

            double[] GPAprobabilities = ExpectedGPA.CalculateExpectedGPAArray(questionCount, skillLevel);
            double expectedGPA = ExpectedGPA.CalculateExpectedGPA(questionCount, skillLevel);

            double[] GPAodds = new double[5];

            for (int i = 0; i < 5; i++)
            {
                GPAodds[i] = 1 / GPAprobabilities[i];
            }

            Console.WriteLine();
            Console.WriteLine("Questions: " + questionCount);
            Console.WriteLine("Skill Level: " + skillLevel);
            Console.WriteLine();

            Console.WriteLine($"{"GPA", -5} {"Chance", -10} {"Odds", -10}\n");

            for (int i = 0; i < GPAprobabilities.Length; i++)
            {
                Console.WriteLine($"{(double)i, -5} {Math.Round(GPAprobabilities[i], 5), -10} 1 in {Math.Round(GPAodds[i], 1), -10}");
            }

            Console.WriteLine();

            Console.WriteLine("Expected GPA: " + Math.Round(expectedGPA, 2) + "\n");
        }
    }
}
