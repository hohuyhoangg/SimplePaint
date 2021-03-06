﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Winform_v1.Model
{
    public class Square : Shape
    {
        private bool squareSelect = false;
        public Square()
        {
            Name = "Square";
        }
        public override void Draw(Graphics graphics)
        {
            //trên xuống -trái qua
            if (this.Fill == true)
            {
                if (Begin.X >= End.X && Begin.Y >= End.Y)
                    graphics.FillRectangle(myBrush, End.X, End.Y, Begin.X - End.X, Begin.X - End.X);
                else if (Begin.X < End.X && Begin.Y > End.Y)
                    graphics.FillRectangle(myBrush, Begin.X, End.Y, End.X - Begin.X, End.X - Begin.X);
                else if (Begin.X < End.X && Begin.Y < End.Y)
                    graphics.FillRectangle(myBrush, Begin.X, Begin.Y, End.X - Begin.X, End.X - Begin.X);
                else
                    graphics.FillRectangle(myBrush, End.X, Begin.Y, Begin.X - End.X, Begin.X - End.X);
            }
            else
            {
                if (Begin.X >= End.X && Begin.Y >= End.Y)
                    graphics.DrawRectangle(myPen, End.X, End.Y, Begin.X - End.X, Begin.X - End.X);
                else if (Begin.X < End.X && Begin.Y > End.Y)
                    graphics.DrawRectangle(myPen, Begin.X, End.Y, End.X - Begin.X, End.X - Begin.X);
                else if (Begin.X < End.X && Begin.Y < End.Y)
                    graphics.DrawRectangle(myPen, Begin.X, Begin.Y, End.X - Begin.X, End.X - Begin.X);
                else
                    graphics.DrawRectangle(myPen, End.X, Begin.Y, Begin.X - End.X, Begin.X - End.X);

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
            if (End.X > Begin.X && End.Y < Begin.Y)
            {
                int temp = this.Begin.Y;
                Begin = new Point(Begin.X, End.Y);
                End = new Point(End.X, temp);
            }
            else if (End.X < Begin.X && End.Y > Begin.Y)
            {
                int temp = this.Begin.X;
                Begin = new Point(End.X, Begin.Y);
                End = new Point(temp, End.Y);
            }
            else if (End.X < Begin.X && End.Y < Begin.Y)
            {
                Point ptemp = this.Begin;
                Begin = End;
                End = ptemp;
            }
            else
            {
                End = new Point(End.X, this.Begin.Y + (this.End.X - this.Begin.X));
            }
            return $"{Name} [({Begin.X}, {Begin.Y}); ({End.X}, {End.Y})]";
        }
        public override void Move(int x , int y)
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
                if (this.squareSelect == false)
                {
                    Point ptam = Begin;
                    Begin = End;
                    End = ptam;
                    this.squareSelect = true;
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
                if (this.squareSelect == false)
                {
                    Point ptam = Begin;
                    Begin = End;
                    End = ptam;
                    this.squareSelect = true;
                }
                Begin = new Point(Begin.X, Begin.Y + y);
                End = new Point(End.X + x, End.Y);
            }
        }
    }


}
