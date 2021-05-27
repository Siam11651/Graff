using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graff
{
    public partial class form_main : Form
    {
        PointF origin;
        float scale;
        float pixelToTransform;
        bool sketched;

        public form_main()
        {
            origin = new PointF();
            scale = 10.0f;
            pixelToTransform = 10.0f;
            sketched = false;

            InitializeComponent();
        }

        void ResetCanvas(Graphics graphics, PointF origin)
        {
            PointF graphCenterF = PointF.GraphToScreen(-origin, new PointF(), scale, canvas.Width);
            Point graphCenter = graphCenterF.ConvertToPoint();
            int triangleSize = 5;
            Pen penBlue = new Pen(Color.Blue);
            Pen penRed = new Pen(Color.Red);
            SolidBrush brushBlue = new SolidBrush(Color.Blue);
            SolidBrush brushRed = new SolidBrush(Color.Red);
            SolidBrush brushWhite = new SolidBrush(Color.White);
            Point horStart = new Point(0, graphCenter.Y);
            Point horEnd = new Point(canvas.Width, graphCenter.Y);
            Point[] leftHorLineArrowPoints = new Point[]
            {
                new Point(0, graphCenter.Y),
                new Point(triangleSize, graphCenter.Y + triangleSize),
                new Point(triangleSize, graphCenter.Y - triangleSize)
            };
            Point[] rightHorLineArrowPoints = new Point[]
            {
                new Point(canvas.Width, graphCenter.Y),
                new Point(canvas.Width - triangleSize, graphCenter.Y + triangleSize),
                new Point(canvas.Width - triangleSize, graphCenter.Y - triangleSize)
            };
            Point verStart = new Point(graphCenter.X, 0);
            Point verEnd = new Point(graphCenter.X, canvas.Height);
            Point[] upVerLineArrowPoints = new Point[]
            {
                new Point(graphCenter.X, 0),
                new Point(graphCenter.X + triangleSize, triangleSize),
                new Point(graphCenter.X - triangleSize, triangleSize)
            };
            Point[] downVerLineArrowPoints = new Point[]
            {
                new Point(graphCenter.X, canvas.Height),
                new Point(graphCenter.X + triangleSize, canvas.Height - triangleSize),
                new Point(graphCenter.X - triangleSize, canvas.Height - triangleSize)
            };

            graphics.FillRectangle(brushWhite, new Rectangle(new Point(0, 0),
                new Size(canvas.Width, canvas.Height)));
            graphics.DrawLine(penBlue, horStart, horEnd);
            graphics.FillPolygon(brushBlue, rightHorLineArrowPoints);
            graphics.FillPolygon(brushBlue, leftHorLineArrowPoints);
            graphics.DrawLine(penRed, verStart, verEnd);
            graphics.FillPolygon(brushRed, upVerLineArrowPoints);
            graphics.FillPolygon(brushRed, downVerLineArrowPoints);
        }

        void DrawGraph(Graphics graphics)
        {
            ResetCanvas(graphics, origin);

            List<Point> points = new List<Point>();

            for (int i = 0; i < canvas.Width; i++)
            {
                string expression = textBox_expression.Text;
                PointF pointf = PointF.ScreenToGraph(new PointF(i, canvas.Width / 2), origin, 10.0f, canvas.Width);

                Calculations.FormatStringX(pointf.x, ref expression);

                float yVal;
                string result = Calculations.Calculate(expression, Calculations.Functions.NONE);

                if (float.TryParse(result, out yVal))
                {
                    pointf.Set(pointf.x, yVal);

                    pointf = PointF.GraphToScreen(pointf, origin, scale, canvas.Width);
                    Point point = pointf.ConvertToPoint();

                    points.Add(point);
                }
            }

            Pen penBlack = new Pen(Color.Black);

            for(int i = 0; i < points.Count - 1; i++)
            {
                graphics.DrawLine(penBlack, points[i], points[i + 1]);
            }
        }

        private void Click_button_sketch(object sender, EventArgs e)
        {
            sketched = true;
            DrawGraph(canvas.CreateGraphics());
        }

        private void Paint_canvas(object sender, PaintEventArgs e)
        {
            ResetCanvas(e.Graphics, new PointF());
        }

        private void Click_button_clear(object sender, EventArgs e)
        {
            sketched = false;
            ResetCanvas(canvas.CreateGraphics(), new PointF());
        }

        private void Click_button_right(object sender, EventArgs e)
        {
            if(sketched)
            {
                origin.Set(origin.x + pixelToTransform / scale, origin.y);
                DrawGraph(canvas.CreateGraphics());
            }
        }

        private void Click_button_left(object sender, EventArgs e)
        {
            if(sketched)
            {
                origin.Set(origin.x - pixelToTransform / scale, origin.y);
                DrawGraph(canvas.CreateGraphics());
            }
        }

        private void Click_button_up(object sender, EventArgs e)
        {
            if(sketched)
            {
                origin.Set(origin.x, origin.y + pixelToTransform / scale);
                DrawGraph(canvas.CreateGraphics());
            }
        }

        private void Click_button_down(object sender, EventArgs e)
        {
            if(sketched)
            {
                origin.Set(origin.x, origin.y - pixelToTransform / scale);
                DrawGraph(canvas.CreateGraphics());
            }
        }
    }
}
