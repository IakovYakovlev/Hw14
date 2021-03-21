using System;

namespace AdditionalLibrary
{
    public static class Extensions
    {
        /// <summary>
        /// Метод для вычисления разницы x и y, округляет до 2 цифр после запятой.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double RoundSubtraction(this double x, double y)
        {
            return Math.Round(x - y, 2);
        }

        /// <summary>
        /// Метод для вычисления результат сложения x и y, округляет до 2 цифр после запятой.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double RoundAddition(this double x, double y)
        {
            return Math.Round(x + y, 2);
        }
    }
}
