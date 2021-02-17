using System;

namespace GPA
{
    class Program
    {
        static void Main(string[] args)
        {
            int questions = Convert.ToInt32(args[0]);
            double skillLevel = Convert.ToDouble(args[1]);

            if (questions > 170)
            {
                throw new OverflowException("Number of questions cannot be greater than 170.");
            }
            else if (questions < 1)
            {
                throw new ArithmeticException("Number of questions cannot be less than 1.");
            }
            if (skillLevel > 1)
            {
                throw new ArithmeticException("Skill level cannot be greater than 1.");
            }
            else if (skillLevel < 0)
            {
                throw new ArithmeticException("Skill level cannot be less than 0.");
            }

            ExpectedGrade.Print(questions, skillLevel);
        }
    }
}
