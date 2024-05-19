using System;

namespace DoodleJumpClone
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Length => Math.Sqrt(X * X + Y * Y);
        public double Angle => Math.Atan2(Y, X);
        public override string ToString() => $"X: {X}, Y: {Y}";

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static readonly Vector ZeroVector = new Vector(0, 0);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);

        public static Vector operator *(Vector a, double k) => new Vector(a.X * k, a.Y * k);

        public static Vector operator /(Vector a, double k) => new Vector   (a.X / k, a.Y / k);

        public static Vector operator *(double k, Vector a) => a * k;

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        
        public bool Equals(Vector a, Vector b) => a.X == b.X && a.Y == b.Y;

        public Vector Normalize() => Length > 0 ? this * (1 / Length) : this;

        public Vector Rotate(double angle) =>
            new Vector(
                X * Math.Cos(angle) - Y * Math.Sin(angle),
                X * Math.Sin(angle) + Y * Math.Cos(angle));

        public Vector BoundTo(Vector size) => new Vector(Math.Max(0, Math.Min(size.X, X)), Math.Max(0, Math.Min(size.Y, Y)));

        public static Vector GetZeroVector() => new Vector(0, 0);
        public void GravityCorrection()
        {
            this.X = this.X * 0.9;
            this.Y = this.Y - 10;
        }
    }
}
