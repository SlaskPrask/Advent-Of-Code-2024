using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCR.Old
{
    public struct Vec2
    {
        public long X;
        public long Y;

        public Vec2(string x, string y)
        {
            X = long.Parse(x);
            Y = long.Parse(y);
        }

        public Vec2(long x, long y)
        {
            X = x; 
            Y = y;
        }

        public static Vec2 operator+(Vec2 v1, Vec2 v2)
        {
            return new Vec2 { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }

        public static Vec2 operator -(Vec2 v1, Vec2 v2)
        {
            return new Vec2 { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }

        public static Vec2 operator *(Vec2 v1, long s)
        {
            return new Vec2 { X = v1.X * s, Y = v1.Y * s };
        }

        public static bool operator ==(Vec2 v1, Vec2 v2)
        {
            return (v1.X == v2.X && v1.Y == v2.Y);
        }

        public static bool operator !=(Vec2 v1, Vec2 v2)
        {
            return (v1.X != v2.X || v1.Y != v2.Y);
        }

        public double Length()
        {
            return (double)Math.Sqrt(X * X + Y * Y);
        }
    };

    public struct Vec3
    {
        public long X;
        public long Y;
        public long Z;

        public Vec3(string x, string y, string z)
        {
            X = long.Parse(x);
            Y = long.Parse(y);
            Z = long.Parse(z);
        }

        public Vec3(long x, long y)
        {
            X = x;
            Y = y;
            Z = Z;
        }

        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3 { X = v1.X + v2.X, Y = v1.Y + v2.Y, Z = v1.Z + v2.Z };
        }

        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3 { X = v1.X - v2.X, Y = v1.Y - v2.Y, Z = v1.Z - v2.Z };
        }

        public static Vec3 operator *(Vec3 v1, long s)
        {
            return new Vec3 { X = v1.X * s, Y = v1.Y * s, Z = v1.Z * s };
        }

        public static bool operator ==(Vec3 v1, Vec3 v2)
        {
            return (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z);
        }

        public static bool operator !=(Vec3 v1, Vec3 v2)
        {
            return (v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z);
        }

        public double Length()
        {
            return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
        }
    };
}
