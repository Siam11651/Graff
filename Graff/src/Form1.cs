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
        const float PIXEL_TO_TRANSFORM = 10.0f;
        const float SCALE_MULTIPLIER = 2.0f;
        const float INITIAL_SCALE_LEVEL = 10.0f;
        const float TARGET_PIXEL_GAP = 50.0f;
        const float SCALE_POINT_MULTIPLIER = 2.0f;
        PointF origin = new PointF();
        float scale = INITIAL_SCALE_LEVEL;
        float currentUnitGap = 1.0f;

        public form_main()
        {
            origin = new PointF();

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

            while(true)
            {
                PointF originF = PointF.GraphToScreen(new PointF(0, 0), origin, scale,
                    canvas.Width);
                PointF unitGapF = PointF.GraphToScreen(new PointF(currentUnitGap, 0), origin, scale,
                    canvas.Width);
                float xDist = Math.Abs(unitGapF.x - originF.x);

                if(xDist >= TARGET_PIXEL_GAP * SCALE_POINT_MULTIPLIER)
                {
                    currentUnitGap /= SCALE_POINT_MULTIPLIER;
                }
                else if(xDist <= TARGET_PIXEL_GAP / SCALE_POINT_MULTIPLIER)
                {
                    currentUnitGap *= SCALE_POINT_MULTIPLIER;
                }
                else
                {
                    break;
                }
            }

            PointF leftEnd = PointF.ScreenToGraph(new PointF(0, canvas.Height / 2),
                origin, scale, canvas.Width);
            PointF rightEnd = PointF.ScreenToGraph(new PointF(canvas.Width, canvas.Height / 2),
                origin, scale, canvas.Width);

            for(float i = 0; i * currentUnitGap <= rightEnd.x; i++)
            {
                PointF linePosF = PointF.GraphToScreen(new PointF(currentUnitGap * i, 0),
                    origin, scale, canvas.Width);
                Point linePos = linePosF.ConvertToPoint();

                graphics.DrawLine(penBlue, new Point(linePos.X, linePos.Y + 1),
                    new Point(linePos.X, linePos.Y - 1));
                graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, 5.0f), brushBlue,
                    new Point(linePos.X, linePos.Y + 5));
            }

            for(float i = -1; leftEnd.x <= i * currentUnitGap; i--)
            {
                PointF linePosF = PointF.GraphToScreen(new PointF(currentUnitGap * i, 0),
                    origin, scale, canvas.Width);
                Point linePos = linePosF.ConvertToPoint();

                graphics.DrawLine(penBlue, new Point(linePos.X, linePos.Y + 1),
                    new Point(linePos.X, linePos.Y - 1));
                graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, 5.0f), brushBlue,
                    new Point(linePos.X, linePos.Y + 5));
            }

            PointF upEnd = PointF.ScreenToGraph(new PointF(canvas.Width / 2, 0),
                origin, scale, canvas.Width);
            PointF downEnd = PointF.ScreenToGraph(new PointF(canvas.Width / 2, canvas.Height),
                origin, scale, canvas.Width);

            for (float i = 1; i * currentUnitGap <= upEnd.y; i++)
            {
                PointF linePosF = PointF.GraphToScreen(new PointF(0, currentUnitGap * i),
                    origin, scale, canvas.Width);
                Point linePos = linePosF.ConvertToPoint();

                graphics.DrawLine(penRed, new Point(linePos.X + 1, linePos.Y),
                    new Point(linePos.X - 1, linePos.Y));
                graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, 5.0f), brushRed,
                    new Point(linePos.X + 5, linePos.Y));
            }

            for (float i = -1; downEnd.y <= i * currentUnitGap; i--)
            {
                PointF linePosF = PointF.GraphToScreen(new PointF(0, currentUnitGap * i),
                    origin, scale, canvas.Width);
                Point linePos = linePosF.ConvertToPoint();

                graphics.DrawLine(penRed, new Point(linePos.X + 1, linePos.Y),
                    new Point(linePos.X - 1, linePos.Y));
                graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, 5.0f), brushRed,
                    new Point(linePos.X + 5, linePos.Y));
            }
        }

        void DrawGraph(Graphics graphics)
        {
            ResetCanvas(graphics, origin);

            List<PointF> pointfs = new List<PointF>();

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

                    pointfs.Add(pointf);
                }
            }

            Pen penBlack = new Pen(Color.Black);

            for(int i = 0; i < pointfs.Count - 1; i++)
            {
                if (!float.IsNaN(pointfs[i].y) && !float.IsNaN(pointfs[i + 1].y))
                {
                    Point point0 = pointfs[i].ConvertToPoint();
                    Point point1 = pointfs[i + 1].ConvertToPoint();
                    graphics.DrawLine(penBlack, point0, point1);
                }
            }
        }

        private void Click_button_sketch(object sender, EventArgs e)
        {
            DrawGraph(canvas.CreateGraphics());
        }

        private void Paint_canvas(object sender, PaintEventArgs e)
        {
            ResetCanvas(e.Graphics, new PointF());
        }

        private void Click_button_clear(object sender, EventArgs e)
        {
            ResetCanvas(canvas.CreateGraphics(), new PointF());
        }

        private void Click_button_right(object sender, EventArgs e)
        {
            origin.Set(origin.x + PIXEL_TO_TRANSFORM / scale, origin.y);
            DrawGraph(canvas.CreateGraphics());
        }

        private void Click_button_left(object sender, EventArgs e)
        {
            origin.Set(origin.x - PIXEL_TO_TRANSFORM / scale, origin.y);
            DrawGraph(canvas.CreateGraphics());
        }

        private void Click_button_up(object sender, EventArgs e)
        {
            origin.Set(origin.x, origin.y + PIXEL_TO_TRANSFORM / scale);
            DrawGraph(canvas.CreateGraphics());
        }

        private void Click_button_down(object sender, EventArgs e)
        {
            origin.Set(origin.x, origin.y - PIXEL_TO_TRANSFORM / scale);
            DrawGraph(canvas.CreateGraphics());
        }

        private void Click_button_zoom_in(object sender, EventArgs e)
        {
            if(scale <= 20.0f)
            {
                scale *= SCALE_MULTIPLIER;
                label_zoom_level.Text = (scale / INITIAL_SCALE_LEVEL).ToString("F2") + "x";
                DrawGraph(canvas.CreateGraphics());
            }
        }

        private void Click_button_zoom_out(object sender, EventArgs e)
        {
            if (scale >= 5.0f)
            {
                scale /= SCALE_MULTIPLIER;
                label_zoom_level.Text = (scale / INITIAL_SCALE_LEVEL).ToString("F2") + "x";
                DrawGraph(canvas.CreateGraphics());
            }
        }
    }
}
