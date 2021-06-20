using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graff
{
    public partial class FormMain : Form
    {
        const float SCALE_MULTIPLIER = 2.0f;
        const float INITIAL_SCALE_LEVEL = 10.0f;
        const float TARGET_PIXEL_GAP = 50.0f;
        const float SCALE_POINT_MULTIPLIER = 2.0f;
        const int axesCharSize = 5;
        const int axesCharGap = 5;
        PointF origin = new PointF();
        Point mouseDown, initialCenter, center = new Point(150, 150);
        float scale = INITIAL_SCALE_LEVEL;
        float currentUnitGap = 1.0f;

        public FormMain()
        {
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
            Point verStart = new Point(graphCenter.X, 0); ; 
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

                int stringSize = axesCharSize * 2;

                if (linePos.Y > canvas.Height - stringSize - axesCharGap)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushBlue,
                    new Point(linePos.X, canvas.Height - stringSize));
                }
                else if (linePos.Y < 0)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushBlue,
                    new Point(linePos.X, 0));
                }
                else
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushBlue,
                    new Point(linePos.X, linePos.Y + axesCharGap));
                }
            }

            for(float i = -1; leftEnd.x <= i * currentUnitGap; i--)
            {
                PointF linePosF = PointF.GraphToScreen(new PointF(currentUnitGap * i, 0),
                    origin, scale, canvas.Width);
                Point linePos = linePosF.ConvertToPoint();

                graphics.DrawLine(penBlue, new Point(linePos.X, linePos.Y + 1),
                    new Point(linePos.X, linePos.Y - 1));

                int stringSize = axesCharSize * 2;

                if (linePos.Y > canvas.Height - stringSize - axesCharGap)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushBlue,
                    new Point(linePos.X, canvas.Height - stringSize));
                }
                else if (linePos.Y < 0)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushBlue,
                    new Point(linePos.X, 0));
                }
                else
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushBlue,
                    new Point(linePos.X, linePos.Y + axesCharGap));
                }
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

                int stringSize = (currentUnitGap * i).ToString("F2").Length * axesCharSize;

                if (linePos.X > canvas.Width - stringSize - axesCharGap)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushRed,
                    new Point(canvas.Width - stringSize, linePos.Y));
                }
                else if(linePos.X < 0)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushRed,
                    new Point(0, linePos.Y));
                }
                else
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushRed,
                    new Point(linePos.X + axesCharGap, linePos.Y));
                }
            }

            for (float i = -1; downEnd.y <= i * currentUnitGap; i--)
            {
                PointF linePosF = PointF.GraphToScreen(new PointF(0, currentUnitGap * i),
                    origin, scale, canvas.Width);
                Point linePos = linePosF.ConvertToPoint();

                graphics.DrawLine(penRed, new Point(linePos.X + 1, linePos.Y),
                    new Point(linePos.X - 1, linePos.Y));

                int stringSize = (currentUnitGap * i).ToString("F2").Length * axesCharSize;

                if (linePos.X > canvas.Width - stringSize - axesCharGap)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushRed,
                    new Point(canvas.Width - stringSize, linePos.Y));
                }
                else if (linePos.X < 0)
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushRed,
                    new Point(0, linePos.Y));
                }
                else
                {
                    graphics.DrawString((currentUnitGap * i).ToString("F2"),
                    new Font(FontFamily.GenericMonospace, axesCharSize), brushRed,
                    new Point(linePos.X + axesCharGap, linePos.Y));
                }
            }
        }

        void DrawGraph(Graphics graphics)
        {
            ResetCanvas(graphics, origin);

            List<PointF> pointfs = new List<PointF>();

            for (int i = 0; i < canvas.Width; i++)
            {
                string expression = textBox_expression.Text;
                PointF pointf = PointF.ScreenToGraph(new PointF(i, canvas.Width / 2), origin, scale, canvas.Width);

                Calculations.FormatStringX(pointf.x, ref expression);

                string result = Calculations.Calculate(expression);

                if (float.TryParse(result, out float yVal))
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

                    if(0 <= point0.X && point0.X <= canvas.Width &&
                        0 <= point0.Y && point0.Y <= canvas.Height &&
                        0 <= point1.X && point1.X <= canvas.Width &&
                        0 <= point1.Y && point1.Y <= canvas.Height)
                    {
                        graphics.DrawLine(penBlack, point0, point1);
                    }
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
            label_zoom_level.Text = (scale / INITIAL_SCALE_LEVEL).ToString("F2") + "x";
            textBox_expression.Clear();

            ResetCanvas(canvas.CreateGraphics(), origin);
        }

        private void Click_button_reset(object sender, EventArgs e)
        {
            scale = 10.0f;
            origin = new PointF(0, 0);
            label_zoom_level.Text = (scale / INITIAL_SCALE_LEVEL).ToString("F2") + "x";

            DrawGraph(canvas.CreateGraphics());
        }

        private void MouseDown_canvas(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                center = PointF.GraphToScreen(origin, new PointF(),
                    scale, canvas.Width).ConvertToPoint();
                initialCenter = center;
                mouseDown = e.Location;
            }
        }

        private void MouseMove_canvas(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                center = new Point(mouseDown.X - e.Location.X + initialCenter.X,
                    mouseDown.Y - e.Location.Y + initialCenter.Y);
                origin = PointF.ScreenToGraph(new PointF(center.X, center.Y),
                    new PointF(), scale, canvas.Width);

                DrawGraph(canvas.CreateGraphics());
            }
        }

        private void MouseWheel_canvas(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && scale * 2.0 < 5000)
            {
                scale *= SCALE_MULTIPLIER;
                label_zoom_level.Text = (scale / INITIAL_SCALE_LEVEL).ToString("F2") + "x";

                DrawGraph(canvas.CreateGraphics());
            }
            else if (e.Delta < 0 && scale / 2.0 > 0.1)
            {
                scale /= SCALE_MULTIPLIER;
                label_zoom_level.Text = (scale / INITIAL_SCALE_LEVEL).ToString("F2") + "x";

                DrawGraph(canvas.CreateGraphics());
            }
        }
    }
}
