using System;

namespace PointExample
{
	enum CoordinateSystem
	{
		Cartesian,
		Polar
	}
	public class Point
	{
		//private double x, y;

		/// <summary>
		/// Initializes a point from EITHER cartesian or polar
		/// </summary>
		/// <param name="a">x if cartesian, rho if polar</param>
		/// <param name="b"></param>
		/// <param name="system"></param>
		//public Point(double a
		//	, double b
		//	, CoordinateSystem system = CoordinateSystem.Cartesian)
		//{
		//	switch (system)
		//	{
		//		case CoordinateSystem.Cartesian:
		//			x = a;
		//			y = b;
		//			break;
		//		case CoordinateSystem.Polar:
		//			x = a * Math.Cos(b);
		//			y = a * Math.Sin(b);
		//			break;
		//		default:
		//			throw new ArgumentOutOfRangeException("system", system, null);
		//	}
		//}

		// factory method
		public static Point NewCartesianPoint(double x, double y)
		{
			return new Point(x, y);
		}

		public static Point NewPolarPoint(double rho, double theta)
		{
			return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
		}

		private double x, y;

		private Point(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return string.Format("X: {0}, Y: {1}", x, y);
		}
	}

	public class Demo
	{
		static void Main(string[] args)
		{
			var point = Point.NewPolarPoint(1.0, Math.PI / 2);
			Console.WriteLine(point);
		}
	}
}
