using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            var rows = original.GetLength(0);
            var columns = original.GetLength(1);
            List<double> values = new List<double>();
            var result = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    values.Add(original[i, j]);
                }
            }
            values = values.OrderByDescending(_ => _).ToList();
            var threshold = values[(int)Math.Round(whitePixelsFraction * rows)];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i,j] = original[i,j] == threshold ? 1 : 0;
                }
            }
        return result;
        }
    }
}