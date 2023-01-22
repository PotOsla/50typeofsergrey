using System;
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
			double median = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
					var pix = original[i, j];
					if (pix == 0 || pix == 1)
					{

					}
						
                }
            }
            return original;
		}
	}
}