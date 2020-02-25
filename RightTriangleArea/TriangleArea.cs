using System;
using System.Collections.Generic;
using System.Linq;

namespace RightTriangleArea
{
    public class TriangleArea
    {
        public static double Area(double a, double b, double c)
        {
            List<double> sides = new List<double>() { a, b, c };
            if (sides.Any(s => s <= 0))
                throw new ArgumentException(ConstMessage.NegativeValues);
            double hyp = sides.Max();
            double eps = hyp * 1E-15;
            sides.RemoveAll(s => Math.Abs(hyp - s) <= eps);
            if (sides.Count != 2)
                throw new ArgumentException(ConstMessage.TwoBigEqualsSides);
            if (double.IsInfinity(Math.Pow(sides[0], 2)))
                throw new ArgumentException(ConstMessage.SquaredParameterInfinity, nameof(a));
            if (double.IsInfinity(Math.Pow(sides[1], 2)))
                throw new ArgumentException(ConstMessage.SquaredParameterInfinity, nameof(b));
            if (Math.Sqrt(Math.Pow((sides[0]), 2) + Math.Pow((sides[1]), 2)) != hyp)
                throw new ArgumentException(ConstMessage.WrongValues);
            return 0.5 * sides[0] * sides[1];
        }
    }
}
