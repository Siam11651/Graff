using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graff
{
    class PointF
    {
        float _x, _y;

        public PointF()
        {
            _x = 0;
            _y = 0;
        }

        public PointF(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public PointF(PointF other)
        {
            _x = other.x;
            _y = other.y;
        }

        public PointF(Point point)
        {
            _x = point.X;
            _y = point.Y;
        }

        public float x
        {
            get
            {
                return _x;
            }
        }

        public float y
        {
            get
            {
                return _y;
            }
        }

        public void Set(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static PointF operator +(PointF other1, PointF other2)
        {
            PointF result = new PointF(other1.x + other2.x, other1.y + other2.y);

            return result;
        }

        public static PointF operator -(PointF other1, PointF other2)
        {
            PointF result = new PointF(other1.x - other2.x, other1.y - other2.y);

            return result;
        }

        public static PointF operator *(PointF other, float number)
        {
            PointF result = new PointF(other.x * number, other.y * number);

            return result;
        }

        public static PointF operator /(PointF other, float number)
        {
            PointF result = new PointF(other.x / number, other.y / number);

            return result;
        }

        public static PointF operator -(PointF that)
        {
            PointF result = new PointF(-that.x, -that.y);

            return result;
        }

        public static PointF GraphToScreen(PointF point, PointF origin, float scale, int size)
        {
            PointF result = new PointF(point - origin);
            result *= scale;
            result.Set(result.x, result.y * -1);
            result.Set(result.x + size / 2, result.y + size / 2);

            return result;
        }

        public static PointF ScreenToGraph(PointF point, PointF origin, float scale, int size)
        {
            PointF result = point;
            result.Set(result.x - size / 2, result.y);
            result.Set(result.x, result.y - size / 2);
            result.Set(result.x, result.y * -1);
            result /= scale;
            result += origin;

            return result;
        }

        public Point ConvertToPoint()
        {
            Point result = new Point((int)_x, (int)_y);

            return result;
        }
    }
}
