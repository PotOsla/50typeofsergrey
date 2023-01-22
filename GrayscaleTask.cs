using System;

namespace Recognizer
{
	public static class GrayscaleTask
	{
		/* 
		 * Переведите изображение в серую гамму.
		 * 
		 * original[x, y] - массив пикселей с координатами x, y. 
		 * Каждый канал R,G,B лежит в диапазоне от 0 до 255.
		 * 
		 * Получившийся массив должен иметь те же размеры, 
		 * grayscale[x, y] - яркость пикселя (x,y) в диапазоне от 0.0 до 1.0
		 *
		 * Используйте формулу:
		 * Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
		 * 
		 * Почему формула именно такая — читайте в википедии 
		 * http://ru.wikipedia.org/wiki/Оттенки_серого
		 */

		public static double[,] ToGrayscale(Pixel[,] original)
		{
			var rows = original.GetUpperBound(0) + 1;
			var colums = original.Length / rows;
            double[,] result = new double[rows, colums];
            for (int i=0; i < rows; i++ )
			{
				for ( int j=0; j < colums; j++)
				{
					var pix = original[i, j];
                    var bright = (pix.R * 0.299 + pix.G * 0.587 + pix.B * 0.114) / 255;
					result[i, j] = bright;
                }
			}
			return result;
		}
	}
}