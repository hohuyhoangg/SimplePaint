using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Winform_v1.Model
{
    public class Ellipse : Shape
    {
        public Ellipse()
        {
            Name = "Ellipse";
        }
        public override void Draw(Graphics graphics)
        {
            if(this.Fill ==true)
                graphics.FillEllipse(myBrush, Begin.X, Begin.Y, End.X - Begin.X, End.Y - Begin.Y);
            else
                graphics.DrawEllipse(myPen, Begin.X, Begin.Y, End.X - Begin.X, End.Y - Begin.Y);
            if (this.IsSelected == true)
            {
                Point p1 = this.Begin;
                Point p2 = this.End;
                if (p2.X > p1.X && p2.Y < p1.Y)
                {
                    int tam = p1.Y;
                    p1.Y = p2.Y;
                    p2.Y = tam;
                }
                else if (p2.X < p1.X && p2.Y > p1.Y)//
                {
                    int tam = p1.X;
                    p1.X = p2.X;
                    p2.X = tam;
                }
                else if (p2.X < p1.X && p2.Y < p1.Y)
                {
                    Point pTam = p1;
                    p1 = p2;
                    p2 = pTam;
                }
                Pen TamPen = new Pen(Color.Black, 1);
                TamPen.DashStyle = DashStyle.Dot;
                Rectangle hcn = new Rectangle();
                hcn.Begin = p1;
                hcn.End = p2;
                hcn.myPen = TamPen;
                hcn.Draw(graphics);
                Line doanthangtam = new Line();
                TamPen.Color = Color.Yellow;
                TamPen.Width = 8;
                doanthangtam.myPen = TamPen;
                doanthangtam.Begin = new Point(p1.X - 4, p1.Y);
                doanthangtam.End = new Point(p1.X + 4, p1.Y);
                doanthangtam.Draw(graphics);
                doanthangtam.Begin = new Point(p2.X - 4, p2.Y);
                doanthangtam.End = new Point(p2.X + 4, p2.Y);
                doanthangtam.Draw(graphics);
                doanthangtam.Begin = new Point(p2.X - 4, p1.Y);
                doanthangtam.End = new Point(p2.X + 4, p1.Y);
                doanthangtam.Draw(graphics);
                doanthangtam.Begin = new Point(p1.X - 4, p2.Y);
                doanthangtam.End = new Point(p1.X + 4, p2.Y);
                doanthangtam.Draw(graphics);
            }
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
        public override void RepairPoint(int SelectedIndex, int x,int y)
        {
            if (SelectedIndex == -1)
            {
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
                Begin = new Point(Begin.X, Begin.Y + y);
                End = new Point(End.X + x, End.Y);
            }
        }
    }
}
