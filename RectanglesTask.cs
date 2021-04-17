using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			// так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
			return (r1.Right >= r2.Left) && (r1.Left <= r2.Right) && (r1.Bottom >= r2.Top) && (r1.Top <= r2.Bottom);
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (!AreIntersected(r1, r2)) return 0;
			int MinX = System.Math.Min(System.Math.Max(r1.Left, r1.Right), System.Math.Max(r2.Left, r2.Right));
			int MaxX = System.Math.Max(System.Math.Min(r1.Left, r1.Right), System.Math.Min(r2.Left, r2.Right);
            int xl = MinX - MaxX;
			int MinY = System.Math.Min(System.Math.Max(r1.Top, r1.Bottom), Math.Max(r2.Top, r2.Bottom));
			int MaxY = Math.Max(Math.Min(r1.Top, r1.Bottom), Math.Min(r2.Top, r2.Bottom));
            int yl = MinY - MaxY;
            if (xl < 0 || yl < 0) return 0;
            return xl * yl;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			Rectangle ra;
            Rectangle rb;
            int index;
            bool first = (r1.Width == r2.Width && r1.Height >= r2.Height) || (r1.Width > r2.Width);
            if (first) { ra = r1; rb = r2; index = 1; } else { ra = r2; rb = r1; index = 0; }
            // вписывается по высоте
            if (ra.Height < rb.Height) return -1;
            if (ra.Left <= rb.Left && ra.Right >= rb.Right && ra.Top <= rb.Top && ra.Bottom >= rb.Bottom) return index;
            else return -1;
		}
	}
}