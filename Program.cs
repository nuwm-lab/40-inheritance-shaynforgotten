using System;

namespace Lab4_Inheritance
{
    public class Point3D
    {
        public double X, Y, Z;
        public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }
        public override string ToString() => $"({X}; {Y}; {Z})";
    }

    class Triangle
    {
        protected Point3D p1, p2, p3;
        public void SetPoints(Point3D a, Point3D b, Point3D c) { p1 = a; p2 = b; p3 = c; }
        public void PrintPoints() => Console.WriteLine($"Трикутник: {p1}, {p2}, {p3}");
        
        public double GetArea()
        {
            double ab_x = p2.X - p1.X, ab_y = p2.Y - p1.Y, ab_z = p2.Z - p1.Z;
            double ac_x = p3.X - p1.X, ac_y = p3.Y - p1.Y, ac_z = p3.Z - p1.Z;
            double i = ab_y * ac_z - ab_z * ac_y;
            double j = ab_z * ac_x - ab_x * ac_z;
            double k = ab_x * ac_y - ab_y * ac_x;
            return 0.5 * Math.Sqrt(i * i + j * j + k * k);
        }
    }

    class Tetrahedron : Triangle
    {
        private Point3D p4;
        public void SetTetraPoints(Point3D a, Point3D b, Point3D c, Point3D d)
        {
            SetPoints(a, b, c);
            p4 = d;
        }
        public double GetVolume()
        {
            double ab_x = p2.X - p1.X, ab_y = p2.Y - p1.Y, ab_z = p2.Z - p1.Z;
            double ac_x = p3.X - p1.X, ac_y = p3.Y - p1.Y, ac_z = p3.Z - p1.Z;
            double ad_x = p4.X - p1.X, ad_y = p4.Y - p1.Y, ad_z = p4.Z - p1.Z;
            double det = ab_x * (ac_y * ad_z - ac_z * ad_y) -
                         ab_y * (ac_x * ad_z - ac_z * ad_x) +
                         ab_z * (ac_x * ad_y - ac_y * ad_x);
            return Math.Abs(det) / 6.0;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Tetrahedron t = new Tetrahedron();
            t.SetTetraPoints(new Point3D(0,0,0), new Point3D(10,0,0), new Point3D(0,10,0), new Point3D(0,0,10));
            Console.WriteLine($"Об'єм тетраедра: {t.GetVolume():F2}");
        }
    }
}
