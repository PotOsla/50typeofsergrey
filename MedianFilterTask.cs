using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        /* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
        public static double[,] MedianFilter(double[,] original)
        {
            var rows = original.GetUpperBound(0) + 1;
            var colums = original.Length / rows;
            var result = new double[rows, colums];
            List<double> values = new List<double>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    var iStart = i == 0 ? 0 : i - 1;
                    var iEnd = i == rows - 1 ? i : i + 1;
                    var jStart = j == 0 ? 0 : j - 1;
                    var jEnd = j == colums - 1 ? j : j + 1;
                    for (int x = iStart; x < iEnd; x++)
                    {
                        for (int y = jStart; y < jEnd; y++)
                        {
                            values.Add(original[x, y]);
                        }
                    }
                    values = values.OrderBy(x => x).ToList();
                    if (values.Count % 2 == 0)
                    {
                        int middle = values.Count / 2;
                        result[i,j] = (values[middle-1] + values[middle])/2;
                    }
                    else
                    {
                        result[i, j] = values[(values.Count - 1) / 2];
                    }
                    
                }
            }
            return result;
        }
    }
}