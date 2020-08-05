using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Winform_v1.Model
{
    public class Line : Shape
    {
        public Line()
        {
            Name = "Line";
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(myPen, Begin, End);
            if (this.IsSelected == true)
            {
                Pen penTemp = new Pen(Color.Black, 1);
                Line lineTemp = new Line();
                penTemp.Color = Color.Yellow;
                penTemp.Width = 8;
                lineTemp.myPen = penTemp;
                lineTemp.Begin = new Point(Begin.X - 4, Begin.Y);
                lineTemp.End = new Point(Begin.X + 4, Begin.Y);
                lineTemp.Draw(graphics);
                lineTemp.Begin = new Point(End.X - 4, End.Y);
                lineTemp.End = new Point(End.X + 4, End.Y);
                lineTemp.Draw(graphics);
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
        public override void RepairPoint(int SelectedIndex, int x , int y)
        {
            if (SelectedIndex == -1)
            {
                Begin = new Point(Begin.X + x, Begin.Y + y);
            }
            else if (SelectedIndex == -2)
            {
                End = new Point(End.X + x, End.Y + y);
            }
        }
    }
}
