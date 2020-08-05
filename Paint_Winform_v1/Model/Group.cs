using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Winform_v1.Model
{
    public class Group : Shape
    {
        List<Shape> listGroup = new List<Shape>();

        public List<Shape> ListGroup { get => listGroup; set => listGroup = value; }
        public Group()
        {
            Name = "Group";
        }
        public override void Move(int x , int y)
        {
            for (int i = 0; i < ListGroup.Count; i++)
            {
                ListGroup[i].Move(x,y);
            }
            Begin = new Point(Begin.X + x, Begin.Y + y);
            End = new Point(End.X + x, End.Y + y);
        }
        public override void Draw(Graphics graphics)
        {
            for (int i = 0; i < listGroup.Count; i++)
            {
                ListGroup[i].Draw(graphics);
            }
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
        public override string ToString()
        {
            this.Begin = this.ListGroup[0].Begin;
            this.End = this.ListGroup[0].End;
            // tìm hình chữ nhật bự nhất
            for (int i = 0; i < this.ListGroup.Count; i++)
            {
                if (this.ListGroup[i].Begin.X < this.Begin.X)
                    Begin = new Point(this.ListGroup[i].Begin.X, Begin.Y);

                if (this.ListGroup[i].Begin.Y < this.Begin.Y)
                    Begin= new Point(Begin.X, this.ListGroup[i].Begin.Y);

                if (this.ListGroup[i].End.X > this.End.X)
                    End = new Point(this.ListGroup[i].End.X, End.Y);

                if (this.ListGroup[i].End.Y > this.End.Y)
                    End = new Point(End.X, this.ListGroup[i].End.Y);

                if (this.ListGroup[i].End.X < this.Begin.X)
                    Begin = new Point(this.ListGroup[i].End.X, Begin.Y);

                if (this.ListGroup[i].End.Y < this.Begin.Y)
                    Begin = new Point(Begin.X, this.ListGroup[i].End.Y);

                if (this.ListGroup[i].Begin.X > this.End.X)
                    End = new Point(this.ListGroup[i].Begin.X, End.Y);
                if (this.ListGroup[i].Begin.Y > this.End.Y)
                    End = new Point(End.X, this.ListGroup[i].Begin.Y);
            }
            return $"{Name} [({Begin.X}, {Begin.Y}); ({End.X}, {End.Y})]";
        }
        public override List<Shape> UnGroup()
        {
            return this.ListGroup;
        }
        public override void TempListShape(List<Shape> shapes)
        {
            this.ListGroup = shapes;
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
            for (int i = 0; i < ListGroup.Count; i++)
            {
                this.ListGroup[i].RepairPoint(SelectedIndex,x,y);
            }
        }
    }
}
