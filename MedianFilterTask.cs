using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        public static double[,] MedianFilter(double[,] original)
        {
            var result = new double[original.GetLength(0), original.GetLength(1)];
            var rows = original.GetLength(0);
            var columns = original.GetLength(1);
            List<double> values = new List<double>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    values.Clear();
                    var iStart = i == 0 ? 0 : i - 1;
                    var iEnd = i == rows - 1 ? i : i + 1;
                    var jStart = j == 0 ? 0 : j - 1;
                    var jEnd = j == columns - 1 ? j : j + 1;
                    for (int m = iStart; m <= iEnd; m++)
                    {
                        for (int n = jStart; n <= jEnd; n++)
                        {
                            values.Add(original[m, n]);
                        }
                    }
                    values = values.OrderBy(x => x).ToList();
                    if (values.Count % 2 == 0)
                    {
                        int median = values.Count / 2;
                        result[i, j] = (values[median] + values[median - 1]) / 2;
                    }
                    else
                    {
                        int median = (values.Count - 1) / 2;
                        result[i, j] = values[median];
                    }
                }
            }
            return result;
        }
    }
}