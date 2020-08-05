using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Winform_v1.Model
{
    public class Cricle : Shape
    {
        private bool cricleSelect = false;
        public Cricle()
        {
            Name = "Cricle";
        }
        public override void Draw(Graphics graphics)
        {
            if (this.Fill == true)
            {
                if ((End.X - Begin.X > 0 && End.Y - Begin.Y < 0) || (End.X - Begin.X < 0 && End.Y - Begin.Y > 0))
                    graphics.FillEllipse(myBrush, Begin.X, Begin.Y, End.X - Begin.X, -End.X + Begin.X);
                else
                    graphics.FillEllipse(myBrush, Begin.X, Begin.Y, End.X - Begin.X, End.X - Begin.X);
            }
            else
            {
                if ((End.X - Begin.X > 0 && End.Y - Begin.Y < 0) || (End.X - Begin.X < 0 && End.Y - Begin.Y > 0))
                    graphics.DrawEllipse(myPen, Begin.X, Begin.Y, End.X - Begin.X, -End.X + Begin.X);
                else
                    graphics.DrawEllipse(myPen, Begin.X, Begin.Y, End.X - Begin.X, End.X - Begin.X);
            }
            if (this.IsSelected == true)
            {
                Point p1 = this.Begin;
                Point p2 = this.End;
                if (p2.X > p1.X && p2.Y < p1.Y)
                {
                    int Temp = p1.Y;
                    p1.Y = p2.Y;
                    p2.Y = Temp;
                }
                else if (p2.X < p1.X && p2.Y > p1.Y)//
                {
                    int Temp = p1.X;
                    p1.X = p2.X;
                    p2.X = Temp;
                }
                else if (p2.X < p1.X && p2.Y < p1.Y)
                {
                    Point Temp = p1;
                    p1 = p2;
                    p2 = Temp;
                }
                Pen TamPen = new Pen(Color.Black, 1);
                TamPen.DashStyle = DashStyle.Dot;
                Rectangle hcn = new Rectangle();
                hcn.Begin = p1;
                hcn.End = p2;
                hcn.myPen = TamPen;
                hcn.Draw(graphics);
                Line line = new Line();
                TamPen.Color = Color.Yellow;
                TamPen.Width = 8;
                line.myPen = TamPen;
                line.Begin = new Point(p1.X - 4, p1.Y);
                line.End = new Point(p1.X + 4, p1.Y);
                line.Draw(graphics);
                line.Begin = new Point(p2.X - 4, p2.Y);
                line.End = new Point(p2.X + 4, p2.Y);
                line.Draw(graphics);
                line.Begin = new Point(p2.X - 4, p1.Y);
                line.End = new Point(p2.X + 4, p1.Y);
                line.Draw(graphics);
                line.Begin = new Point(p1.X - 4, p2.Y);
                line.End = new Point(p1.X + 4, p2.Y);
                line.Draw(graphics);
            }
        }
        public override string ToString()
        {
            if ((this.End.X - this.Begin.X > 0 && this.End.Y - this.Begin.Y < 0) || (this.End.X - this.Begin.X < 0 && this.End.Y - this.Begin.Y > 0))
                End = new Point(End.X, this.Begin.Y - (this.End.X - this.Begin.X));

            else
                End = new Point(End.X, this.Begin.Y - (this.End.X - this.Begin.X));//bug chưa fixx

            return $"{Name} [({Begin.X}, {Begin.Y}); ({End.X}, {End.Y})]";
        }
        public override void Move(int x, int y)
        {
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
            return null;
        }
        public override void TempPoint(List<Point> points)
        {
            throw new NotImplementedException();
        }
        public override void RepairPoint(int SelectedIndex, int x, int y)
        {
            if (SelectedIndex == -1)
            {
                if (this.cricleSelect == false)
                {
                    Point ptam = Begin;
                    Begin = End;
                    End = ptam;
                    this.cricleSelect = true;
                }
                Begin = new Point(Begin.X + x, Begin.Y + y);
            }
            else if (SelectedIndex == -2)
            {
                End = new Point(End.X + x, End.Y + y);
            }
            else if (SelectedIndex == -3)
            {
                Begin = new Point(Begin.X + x, Begin.Y);
                End = new Point(End.X, End.Y + y);
            }
            else
            {
                if (this.cricleSelect == false)
                {
                    Point ptam = Begin;
                    Begin = End;
                    End = ptam;
                    this.cricleSelect = true;
                }
                Begin = new Point(Begin.X, Begin.Y + y);
                End = new Point(End.X + x, End.Y);
            }
        }
    }

}
