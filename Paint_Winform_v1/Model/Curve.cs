using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Winform_v1.Model
{
    public class Curve : Shape
    {
        List<Point> listPoint = new List<Point>();

        public List<Point> ListPoint { get => listPoint; set => listPoint = value; }

        public Curve()
        {
            Name = "Curve";
            this.CurveOrPolugon = true;
        }
        public override void Draw(Graphics graphics)
        {
            
            if(ListPoint.Count > 1)
                graphics.DrawCurve(myPen, ListPoint.ToArray());
            if (this.IsSelected == true)
            {
                Pen penTemp = new Pen(Color.Black, 1);
                penTemp.DashStyle = DashStyle.Dot;
                Rectangle rectangle = new Rectangle();
                rectangle.Begin = Begin;
                rectangle.End = End;
                rectangle.myPen = penTemp;
                rectangle.Draw(graphics);
                Line lineTemp = new Line();
                penTemp.Color = Color.Yellow;
                penTemp.Width = 8;
                lineTemp.myPen = penTemp;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    lineTemp.Begin = new Point(ListPoint[i].X - 4, ListPoint[i].Y);
                    lineTemp.End = new Point(ListPoint[i].X + 4, ListPoint[i].Y);
                    lineTemp.Draw(graphics);
                }
            }

        }
        public override void Move(int x, int y)
        {
            for (int i = 0; i < ListPoint.Count; i++)
            {
                ListPoint[i] = new Point(ListPoint[i].X + x, ListPoint[i].Y + y);
            }
            Begin = new Point(Begin.X + x, Begin.Y + y);
            End = new Point(End.X + x, End.Y + y);
        }
        public override List<Shape> UnGroup()
        {
            return null;
        }
        public override void TempListShape(List<Shape> shapes)
        {
            throw new NotImplementedException();
        }
        public override List<Point> SelectedPoint()
        {
            return this.ListPoint;
        }
        public override void TempPoint(List<Point> points)
        {
            this.ListPoint = points;
        }
        public override void RepairPoint(int SelectedIndex, int x, int y)
        {
            if (SelectedIndex >= 0)
            {
                if (SelectedIndex == this.ListPoint.Count - 1 || SelectedIndex == this.ListPoint.Count - 2)
                {
                    this.ListPoint[this.ListPoint.Count - 1] = new Point(this.ListPoint[this.ListPoint.Count - 1].X + x, this.ListPoint[this.ListPoint.Count - 1].Y + y);
                    this.ListPoint[this.ListPoint.Count - 2] = new Point(this.ListPoint[this.ListPoint.Count - 2].X + x, this.ListPoint[this.ListPoint.Count - 2].Y + y);
                }
                else
                    this.ListPoint[SelectedIndex] = new Point(this.ListPoint[SelectedIndex].X + x, this.ListPoint[SelectedIndex].Y + y);
                this.Begin = this.ListPoint[0];
                this.End = this.ListPoint[0];
                for (int i = 1; i < this.ListPoint.Count; i++)
                {
                    if (this.ListPoint[i].X < this.Begin.X)
                        Begin = new Point(this.ListPoint[i].X, Begin.Y);
                    if (this.ListPoint[i].Y < this.Begin.Y)
                        Begin = new Point(Begin.X, this.ListPoint[i].Y);
                    if (this.ListPoint[i].X > this.End.X)
                        End = new Point(this.ListPoint[i].X, End.Y);
                    if (this.ListPoint[i].Y > this.End.Y)
                        End = new Point(End.X, this.ListPoint[i].Y);
                }
            }
        }
    }
}
