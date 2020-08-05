using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Winform_v1.Model
{
    public abstract class Shape 
    {
        public Point Begin { get; set; }
        public Point End { get; set; }
        public Pen myPen { get; set; }
        public Brush myBrush { get; set; }
        public bool Fill { get; set; }
        public bool IsSelected { get; set; }
        public bool CurveOrPolugon { get; set; }
        public string Name { get;protected set; }
        public Shape()
        {
            this.Fill = false;
            this.IsSelected = false;
            this.CurveOrPolugon = false;
        }

        public abstract void Draw(Graphics graphics);
        public override string ToString()
        {
            return $"{Name} [({Begin.X}, {Begin.Y}); ({End.X}, {End.Y})]";
        }
        public abstract void Move(int x, int y);
        public abstract List<Shape> UnGroup();
        public abstract void TempListShape(List<Shape> shapes);// dùng cho group để tạo ra list hình phụ
        public abstract List<Point> SelectedPoint();
        public abstract void TempPoint(List<Point> points);// dùng cho hình đa giác và hình cong
        public abstract void RepairPoint(int SelectedIndex, int x, int y);
    }
}
