using Paint_Winform_v1.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Paint_Winform_v1
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }
        public Graphics graphics;
        List<Shape> listShape;
        List<Point> listPointMain;
        public List<Shape> ListShape { get => listShape; set => listShape = value; }
        public List<Point> ListPointMain { get => listPointMain; set => listPointMain = value; }

        Curve shapeCurve;
        Polygon shapePolygon;
        bool Status = false;
        bool StatusFull = false;
        bool bLine = false;
        bool bEllipse = false;
        bool bRectangle = false;
        bool bSquare = false;
        bool bCricle = false;
        bool bCurve = false;
        bool bPolygon = false;
        bool Selected = false;
        bool MoveIndex = false;
        bool IndexFix = false;
        bool Fix = false;
        bool CheckCtrl = false;
        Model.Rectangle rectangleSelect;
        Point point1;
        Point point2;
        int Index;
        int IndexSelected;
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics myBuffer;

        #region LoadForm
        private void fMain_Load(object sender, EventArgs e)
        {
           // graphics = this.pPaint.CreateGraphics();
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.pPaint.CreateGraphics(), this.pPaint.DisplayRectangle);
            ListShape = new List<Shape>();
            LoadDataSourceccbxHatchStyle();
            this.cbxDashStyle.Text = "Solid";
            this.tkbThickNess.Value = 3;
            this.rbNoFill.Checked = true;
            this.cbxHatchStyle.Enabled = false;
        }
        public void LoadDataSourceccbxHatchStyle()
        {
            string[] ListHatchStyle = { "BackwardDiagonal", "Cross", "DarkDownwardDiagonal", "DarkHorizontal", "DarkUpwardDiagonal", "DarkVertical", "DashedDownwardDiagonal", "DashedHorizontal", "DashedUpwardDiagonal",
                            "DashedVertical", "DiagonalBrick", "DiagonalCross", "Divot", "DottedDiamond","DottedGrid", "ForwardDiagonal", "Horizontal", "HorizontalBrick", "LargeCheckerBoard", "LargeConfetti",
                            "LargeGrid", "LightDownwardDiagonal", "LightHorizontal", "LightUpwardDiagonal", "LightVertical", "Max", "Min", "NarrowHorizontal", "NarrowVertical", "OutlinedDiagonal", "Percent05",
                            "Percent10", "Percent20", "Percent25", "Percent30", "Percent40", "Percent50", "Percent60", "Percent70", "Percent75", "Percent80", "Percent90", "Plaid", "Shingle", "SmallCheckerBoard",
                            "SmallConFetti", "SmallGrid", "Solid", "SolidDiamond", "Sphere", "Trellis", "Vertical", "Wave", "Weave", "WideDownwardDiagonal", "WideUpwardDiagonal", "ZigZag"
                            };
            for (int i = 0; i < 57; i++)
            {
                this.cbxHatchStyle.Items.Add(ListHatchStyle[i]);
            }
            this.cbxHatchStyle.Text = "Solid";
        }
        #endregion

        #region Button
        private void rbFill_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFill.Checked == true)
            {
                tkbThickNess.Enabled = false;
                cbxDashStyle.Enabled = false;
                btnLine.Enabled = false;
                btnCurve.Enabled = false;
                cbxDashStyle.Enabled = false;
                cbxHatchStyle.Enabled = true;
            }
            else
            {
                tkbThickNess.Enabled = true;
                cbxDashStyle.Enabled = true;
                btnLine.Enabled = true;
                btnCurve.Enabled = true;
                cbxDashStyle.Enabled = true;
                cbxHatchStyle.Enabled = false;
            }
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor1.BackColor = colorDialog.Color;
            }
        }
        private void btnColor2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor2.BackColor = colorDialog.Color;
            }
        }
        private void btnLine_Click(object sender, EventArgs e)
        {
            this.DeleteCheckclbResults();
            this.bLine = true;
            this.bSquare = false;
            this.bEllipse = false;
            this.bRectangle = false;
            this.bCricle = false;
            this.bCurve = false;
            this.bPolygon = false;
        }
        private void btnEllipse_Click(object sender, EventArgs e)
        {
            this.DeleteCheckclbResults();
            this.bEllipse = true;
            this.bLine = false;
            this.bSquare = false;
            this.bRectangle = false;
            this.bCricle = false;
            this.bCurve = false;
            this.bPolygon = false;
        }
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            this.DeleteCheckclbResults();
            this.bRectangle = true;
            this.bLine = false;
            this.bEllipse = false;
            this.bSquare = false;
            this.bCricle = false;
            this.bCurve = false;
            this.bPolygon = false;
        }
        private void btnSquare_Click(object sender, EventArgs e)
        {
            this.DeleteCheckclbResults();
            this.bRectangle = false;
            this.bLine = false;
            this.bEllipse = false;
            this.bSquare = true;
            this.bCricle = false;
            this.bCurve = false;
            this.bPolygon = false;
        }
        private void btnCricle_Click(object sender, EventArgs e)
        {
            this.DeleteCheckclbResults();
            this.bRectangle = false;
            this.bLine = false;
            this.bEllipse = false;
            this.bSquare = false;
            this.bCricle = true;
            this.bCurve = false;
            this.bPolygon = false;
        }
        private void btnCurve_Click(object sender, EventArgs e)
        {
            this.DeleteCheckclbResults();
            this.bRectangle = false;
            this.bLine = false;
            this.bEllipse = false;
            this.bSquare = false;
            this.bCricle = false;
            this.bCurve = true;
            this.bPolygon = false;
            this.ListPointMain = new List<Point>();
            shapeCurve = new Curve();
            shapeCurve.myPen = new Pen(btnColor1.BackColor, int.Parse(tkbThickNess.Value.ToString()));
            shapeCurve.myPen = this.PickDashStyle(shapeCurve.myPen);
            this.ListShape.Add(shapeCurve);
        }
        private void btnPolygon_Click(object sender, EventArgs e)
        {
            this.DeleteCheckclbResults();
            this.bRectangle = false;
            this.bLine = false;
            this.bEllipse = false;
            this.bSquare = false;
            this.bCricle = false;
            this.bCurve = false;
            this.bPolygon = true;
            this.ListPointMain = new List<Point>();
            shapePolygon = new Polygon();
            if (rbFill.Checked == true)
            {
                shapePolygon.myBrush = this.PickBrush();
                shapePolygon.Fill = true;
            }
            shapePolygon.myPen = new Pen(btnColor1.BackColor, int.Parse(tkbThickNess.Value.ToString()));
            shapePolygon.myPen = this.PickDashStyle(shapePolygon.myPen);
            this.ListShape.Add(shapePolygon);
        }
        private void btnGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            List<Shape> shapeTemp;
            for (int i = this.ListShape.Count - 1; i >= 0; i--)
            {
                if (this.ListShape[i].IsSelected == true)//// lcbResult.GetItemChecked(i)==true
                {
                    if ((shapeTemp = this.ListShape[i].UnGroup()) == null)
                    {
                        group.ListGroup.Add(this.ListShape[i]);
                    }
                    else
                    {
                        group.ListGroup.AddRange(shapeTemp);
                    }
                    this.ListShape.RemoveAt(i);
                }
            }
            if (group.ListGroup.Count > 0)
            {
                this.ListShape.Add(group);
                this.clbResult.Items.Clear();
                for (int i = 0; i < this.ListShape.Count; i++)
                    this.clbResult.Items.Add(this.ListShape[i].ToString());
                this.clbResult.SetItemChecked(this.ListShape.Count - 1, true);
            }
        }
        private void btnUnGroup_Click(object sender, EventArgs e)
        {
            int temp = this.ListShape.Count;
            List<Shape> shapeTemp;
            for (int i = this.ListShape.Count - 1; i >= 0; i--)
            {
                if (this.ListShape[i].IsSelected == true)
                {
                    shapeTemp = this.ListShape[i].UnGroup();
                    if (shapeTemp != null)
                    {
                        for (int j = 0; j < shapeTemp.Count; j++)
                            this.ListShape.Add(shapeTemp[j]);
                        this.ListShape.RemoveAt(i);
                        //temp = temp - 1;// bug
                    }
                }
            }
            this.clbResult.Items.Clear();
            for (int i = 0; i < this.ListShape.Count; i++)
                this.clbResult.Items.Add(this.ListShape[i].ToString());
            for (int i = temp; i < this.ListShape.Count; i++)
                this.clbResult.SetItemChecked(i, true);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = this.ListShape.Count - 1; i >= 0; i--)
            {
                if (clbResult.GetItemChecked(i) == true)
                {
                    this.ListShape.RemoveAt(i);
                }
            }
            this.clbResult.Items.Clear();
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                this.clbResult.Items.Add(this.ListShape[i].ToString());
            }
            //this.Refresh();
            this.RefreshUpdate();
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            for (int i = this.ListShape.Count - 1; i >= 0; i--)
            {
                this.ListShape.RemoveAt(i);
            }
            this.clbResult.Items.Clear();
            this.Refresh();
        }
        private void btnAll_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < ListShape.Count; i++)
            {
                if (clbResult.GetItemChecked(i) != true)
                {
                    clbResult.SetItemChecked(i, true);
                }
            }
        }
        #endregion

        #region Functions
        public Pen PickDashStyle(Pen p)
        {
            switch (cbxDashStyle.SelectedIndex)
            {
                case 0:
                    p.DashStyle = DashStyle.Dash;
                    break;
                case 1:
                    p.DashStyle = DashStyle.DashDot;
                    break;
                case 2:
                    p.DashStyle = DashStyle.DashDotDot;
                    break;
                case 3:
                    p.DashStyle = DashStyle.Dot;
                    break;
                case 4:
                    p.DashStyle = DashStyle.Solid;
                    break;
            }
            return p;
        }
        public HatchStyle PickHatchStyle()
        {
            switch (cbxHatchStyle.SelectedIndex)
            {
                case 0:
                    return HatchStyle.BackwardDiagonal;
                case 1:
                    return HatchStyle.Cross;
                case 2:
                    return HatchStyle.DarkDownwardDiagonal;
                case 3:
                    return HatchStyle.DarkHorizontal;
                case 4:
                    return HatchStyle.DarkUpwardDiagonal;
                case 5:
                    return HatchStyle.DarkVertical;
                case 6:
                    return HatchStyle.DashedDownwardDiagonal;
                case 7:
                    return HatchStyle.DashedHorizontal;
                case 8:
                    return HatchStyle.DashedUpwardDiagonal;
                case 9:
                    return HatchStyle.DashedVertical;
                case 10:
                    return HatchStyle.DiagonalBrick;
                case 11:
                    return HatchStyle.DiagonalCross;
                case 12:
                    return HatchStyle.Divot;
                case 13:
                    return HatchStyle.DottedDiamond;
                case 14:
                    return HatchStyle.DottedGrid;
                case 15:
                    return HatchStyle.ForwardDiagonal;
                case 16:
                    return HatchStyle.Horizontal;
                case 17:
                    return HatchStyle.HorizontalBrick;
                case 18:
                    return HatchStyle.LargeCheckerBoard;
                case 19:
                    return HatchStyle.LargeConfetti;
                case 20:
                    return HatchStyle.LargeGrid;
                case 21:
                    return HatchStyle.LightDownwardDiagonal;
                case 22:
                    return HatchStyle.LightHorizontal;
                case 23:
                    return HatchStyle.LightUpwardDiagonal;
                case 24:
                    return HatchStyle.LightVertical;
                case 25:
                    return HatchStyle.Max;
                case 26:
                    return HatchStyle.Min;
                case 27:
                    return HatchStyle.NarrowHorizontal;
                case 28:
                    return HatchStyle.NarrowVertical;
                case 29:
                    return HatchStyle.OutlinedDiamond;
                case 30:
                    return HatchStyle.Percent05;
                case 31:
                    return HatchStyle.Percent10;
                case 32:
                    return HatchStyle.Percent20;
                case 33:
                    return HatchStyle.Percent25;
                case 34:
                    return HatchStyle.Percent30;
                case 35:
                    return HatchStyle.Percent40;
                case 36:
                    return HatchStyle.Percent50;
                case 37:
                    return HatchStyle.Percent60;
                case 38:
                    return HatchStyle.Percent70;
                case 39:
                    return HatchStyle.Percent75;
                case 40:
                    return HatchStyle.Percent80;
                case 41:
                    return HatchStyle.Percent90;
                case 42:
                    return HatchStyle.Plaid;
                case 43:
                    return HatchStyle.Shingle;
                case 44:
                    return HatchStyle.SmallCheckerBoard;
                case 45:
                    return HatchStyle.SmallConfetti;
                case 46:
                    return HatchStyle.SmallGrid;
                case 47:
                    return HatchStyle.SolidDiamond;///////////////////
                case 48:
                    return HatchStyle.SolidDiamond;
                case 49:
                    return HatchStyle.Sphere;
                case 50:
                    return HatchStyle.Trellis;
                case 51:
                    return HatchStyle.Vertical;
                case 52:
                    return HatchStyle.Wave;
                case 53:
                    return HatchStyle.Weave;
                case 54:
                    return HatchStyle.WideDownwardDiagonal;
                case 55:
                    return HatchStyle.WideUpwardDiagonal;
                case 56:
                    return HatchStyle.ZigZag;
            }
            return HatchStyle.SolidDiamond;
        }
        public Brush PickBrush()
        {
            if (cbxHatchStyle.Text == "Solid")
            {
                return new SolidBrush(this.btnColor1.BackColor);
            }
            return new HatchBrush(this.PickHatchStyle(), this.btnColor1.BackColor, this.btnColor2.BackColor);
        }
        public void DeleteCheckclbResults()
        {
            for (int i = 0; i < this.clbResult.Items.Count; i++)
            {
                this.clbResult.SetItemChecked(i, false);
                this.ListShape[i].IsSelected = false;
            }
        }
        public bool CheckMouse(Point p)
        {
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                if (ListShape[i].IsSelected == true)
                {
                    Point p1 = this.ListShape[i].Begin;
                    Point p2 = this.ListShape[i].End;
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
                    if (p1.X < p.X && p1.Y < p.Y && p2.X > p.X && p2.Y > p.Y)
                        return true;
                }
            }
            return false;
        }
        public bool CheckEdidShape(Point p)
        {
            List<Shape> shapes;
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                if ((shapes = this.ListShape[i].UnGroup()) == null)
                {
                    if ((Math.Abs(ListShape[i].Begin.X - p.X) < 3) && (Math.Abs(ListShape[i].Begin.Y - p.Y) 
                        < 3))
                        this.Cursor = Cursors.SizeNWSE;
                }
            }
            return false;
        }
        public void DrawInCheck(int i)
        {
            if (this.ListShape[i].IsSelected == true)
            {
                Point p1 = this.ListShape[i].Begin;
                Point p2 = this.ListShape[i].End;
                if (p2.X > p1.X && p2.Y < p1.Y)
                {
                    int Temp = p1.Y;
                    p1.Y = p2.Y;
                    p2.Y = Temp;
                }
                else if (p2.X < p1.X && p2.Y > p1.Y)
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
                Model.Rectangle hcn = new Model.Rectangle();
                hcn.Begin = p1;
                hcn.End = p2;
                hcn.myPen = TamPen;
                hcn.Draw(this.graphics);
                Line doanthangtam = new Line();
                TamPen.Color = Color.Yellow;
                TamPen.Width = 8;
                doanthangtam.myPen = TamPen;
                List<Point> diemcham;
                if ((diemcham = this.ListShape[i].SelectedPoint()) == null)
                {
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
                else
                {
                    for (int ii = 0; ii < diemcham.Count; ii++)
                    {

                        doanthangtam.Begin = new Point(diemcham[ii].X - 4, diemcham[ii].Y);
                        doanthangtam.End = new Point(diemcham[ii].X + 4, diemcham[ii].Y);
                        doanthangtam.Draw(graphics);
                    }
                }
            }
        }
        private void RefreshUpdate()
        {
            graphics = myBuffer.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            for (int j = 0; j < this.ListShape.Count; j++)
            {
                this.ListShape[j].Draw(graphics);
            }
            myBuffer.Render(this.pPaint.CreateGraphics());
        }
        private void RefreshUpdateSelect()
        {
            graphics = myBuffer.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);

            for (int j = 0; j < this.ListShape.Count; j++)
            {
                this.ListShape[j].Draw(graphics);
            }
            rectangleSelect.Draw(graphics);

            myBuffer.Render(this.pPaint.CreateGraphics());
        }
        #endregion

        #region Event Mouse
        private void pPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.bLine == true)
            {
                Shape shape = new Line();
                shape.Begin = e.Location;
                shape.End = e.Location;
                shape.myPen = new Pen(btnColor1.BackColor, int.Parse(tkbThickNess.Value.ToString()));
                shape.myPen = this.PickDashStyle(shape.myPen);
                this.ListShape.Add(shape);
                this.Status = true;
            }
            else if (this.bEllipse == true)
            {
                Shape shape = new Ellipse();
                if (rbFill.Checked == true)
                {
                    shape.myBrush = this.PickBrush();
                    shape.Fill = true;
                }
                shape.Begin = e.Location;
                shape.End = e.Location;
                shape.myPen = new Pen(btnColor1.BackColor, int.Parse(tkbThickNess.Value.ToString()));
                shape.myPen = this.PickDashStyle(shape.myPen);
                this.ListShape.Add(shape);
                this.Status = true;
            }
            else if (this.bRectangle == true)
            {
                Shape shape = new Model.Rectangle();
                if (rbFill.Checked == true)
                {
                    shape.myBrush = this.PickBrush();
                    shape.Fill = true;
                }
                shape.Begin = e.Location;
                shape.End = e.Location;
                shape.myPen = new Pen(btnColor1.BackColor, int.Parse(tkbThickNess.Value.ToString()));
                shape.myPen = this.PickDashStyle(shape.myPen);
                this.ListShape.Add(shape);
                this.Status = true;
            }
            else if (this.bSquare == true)
            {
                Shape shape = new Square();
                if (rbFill.Checked == true)
                {
                    shape.myBrush = this.PickBrush();
                    shape.Fill = true;
                }
                shape.Begin = e.Location;
                shape.End = e.Location;
                shape.myPen = new Pen(btnColor1.BackColor, int.Parse(tkbThickNess.Value.ToString()));
                shape.myPen = this.PickDashStyle(shape.myPen);
                this.ListShape.Add(shape);
                this.Status = true;
            }
            else if (this.bCricle == true)
            {
                Shape shape = new Cricle();
                if (rbFill.Checked == true)
                {
                    shape.myBrush = this.PickBrush();
                    shape.Fill = true;
                }
                shape.Begin = e.Location;
                shape.End = e.Location;
                shape.myPen = new Pen(btnColor1.BackColor, int.Parse(tkbThickNess.Value.ToString()));
                shape.myPen = this.PickDashStyle(shape.myPen);
                this.ListShape.Add(shape);
                this.Status = true;
            }
            else if (this.IndexFix == true)
            {
                point1 = e.Location;
                point2 = e.Location;
                this.Fix = true;
            }
            else if (CheckMouse(e.Location) == false)
            {
                rectangleSelect = new Model.Rectangle();
                rectangleSelect.Begin = e.Location;
                rectangleSelect.End = e.Location;
                rectangleSelect.myPen = new Pen(Color.Black, 2);
                rectangleSelect.myPen.DashStyle = DashStyle.Dot;
                this.Selected = true;
            }
            else
            {
                this.point1 = e.Location;
                this.point2 = e.Location;
                this.MoveIndex = true;
            }
        }
        private void pPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Status == true)
            {
                ListShape[ListShape.Count - 1].End = e.Location;
                //this.Refresh();
                this.RefreshUpdate();
            }
            else if (this.StatusFull == true)
            {
                if (this.bCurve == true)
                {
                    shapeCurve.ListPoint[shapeCurve.ListPoint.Count - 1] = e.Location;
                    this.ListShape[ListShape.Count - 1] = shapeCurve;
                }
                else
                {
                    shapePolygon.ListPoint[shapePolygon.ListPoint.Count - 1] = e.Location;
                    this.ListShape[ListShape.Count - 1] = shapePolygon;
                }
                //this.Refresh();
                RefreshUpdateSelect();
            }
            else if (this.Selected == true)
            {
                rectangleSelect.End = e.Location;
                this.Refresh();
                rectangleSelect.Draw(graphics);
            }
            else if (this.MoveIndex == true)
            {
                this.point2 = e.Location;
                for (int i = 0; i < this.ListShape.Count; i++)
                {
                    if (this.ListShape[i].IsSelected == true)
                        this.ListShape[i].Move(point2.X - point1.X, point2.Y - point1.Y);
                }
                //this.Refresh();
                this.RefreshUpdate();
                this.point1 = e.Location;
            }
            else if (this.Fix == true)
            {
                this.point2 = e.Location;
                this.ListShape[Index].RepairPoint(this.IndexSelected, this.point2.X - this.point1.X, this.point2.Y - this.point1.Y);
                //this.Refresh();
                this.RefreshUpdate();
                this.point1 = this.point2;
            }
            else
            {
                this.Cursor = Cursors.Default;
                for (int i = 0; i < this.ListShape.Count; i++)
                {
                    if (this.ListShape[i].IsSelected == true)
                    {
                        if (this.ListShape[i].CurveOrPolugon == false)
                        {
                            if ((Math.Abs(ListShape[i].Begin.X - e.X) < 4) && (Math.Abs(ListShape[i].Begin.Y - e.Y) < 4))
                            {
                                this.IndexSelected = -1;
                                this.Index = i;
                                this.Cursor = Cursors.SizeAll;
                                this.IndexFix = true;
                            }
                            else if ((Math.Abs(ListShape[i].End.X - e.X) < 4) && (Math.Abs(ListShape[i].End.Y - e.Y) < 4))
                            {
                                this.IndexSelected = -2;
                                this.Index = i;
                                this.Cursor = Cursors.SizeAll;
                                this.IndexFix = true;
                            }
                            else if ((Math.Abs(ListShape[i].Begin.X - e.X) < 4) && (Math.Abs(ListShape[i].End.Y - e.Y) < 4))
                            {
                                this.IndexSelected = -3;
                                this.Index = i;
                                this.Cursor = Cursors.SizeAll;
                                this.IndexFix = true;
                            }
                            else if ((Math.Abs(ListShape[i].End.X - e.X) < 4) && (Math.Abs(ListShape[i].Begin.Y - e.Y) < 4))
                            {
                                this.IndexSelected = -4;
                                this.Index = i;
                                this.Cursor = Cursors.SizeAll;
                                this.IndexFix = true;
                            }
                            else
                                this.IndexFix = false;
                        }
                        else
                        {
                            List<Point> lp = this.ListShape[i].SelectedPoint();
                            for (int j = 0; j < lp.Count; j++)
                            {
                                if ((Math.Abs(lp[j].X - e.X) < 3) && (Math.Abs(lp[j].Y - e.Y) < 3))
                                {
                                    this.IndexSelected = j;
                                    this.Index = i;
                                    this.Cursor = Cursors.SizeAll;
                                    this.IndexFix = true;
                                }
                            }
                        }
                    }
                }
            }

        }
        private void pPaint_MouseClick(object sender, MouseEventArgs e)
        {
            if (bCurve == true)
            {
                shapeCurve.ListPoint.Add(e.Location);
                if (shapeCurve.ListPoint.Count < 2)
                {
                    shapeCurve.ListPoint.Add(e.Location);
                    shapeCurve.Begin = e.Location;
                    shapeCurve.End = e.Location;
                }
                if (e.Location.X < shapeCurve.Begin.X)
                    shapeCurve.Begin = new Point(e.X, shapeCurve.Begin.Y);
                if (e.Location.Y < shapeCurve.Begin.Y)
                    shapeCurve.Begin = new Point(shapeCurve.Begin.X, e.Y);
                if (e.Location.X > shapeCurve.End.X)
                    shapeCurve.End = new Point(e.X, shapeCurve.End.Y);
                if (e.Location.Y > shapeCurve.End.Y)
                    shapeCurve.End = new Point(shapeCurve.End.X, e.Y);
                this.StatusFull = true;
            }
            else if (bPolygon == true)
            {
                shapePolygon.ListPoint.Add(e.Location);
                if (shapePolygon.ListPoint.Count < 2)
                {
                    shapePolygon.ListPoint.Add(e.Location);
                    shapePolygon.Begin = e.Location;
                    shapePolygon.End = e.Location;
                }
                if (e.Location.X < shapePolygon.Begin.X)
                    shapePolygon.Begin = new Point(e.X, shapePolygon.Begin.Y);
                if (e.Location.Y < shapePolygon.Begin.Y)
                    shapePolygon.Begin = new Point(shapePolygon.Begin.X, e.Y);
                if (e.Location.X > shapePolygon.End.X)
                    shapePolygon.End = new Point(e.X, shapePolygon.End.Y);
                if (e.Location.Y > shapePolygon.End.Y)
                    shapePolygon.End = new Point(shapePolygon.End.X, e.Y);
                this.StatusFull = true;
            }
            else if ((this.Status == false || this.StatusFull == false) && this.Fix == false)
            {
                if (this.CheckCtrl == false)
                    this.DeleteCheckclbResults();
                //chọn hình đã vẽ
                for (int i = this.ListShape.Count - 1; i >= 0; i--)
                {
                    Point p1 = this.ListShape[i].Begin;
                    Point p2 = this.ListShape[i].End;
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
                    if (p1.X < e.X && p1.Y < e.Y && p2.X > e.X && p2.Y > e.Y)
                    {
                        clbResult.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }
        private void pPaint_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.bPolygon == true || this.bCurve == true)
            {
                this.clbResult.Items.Add(this.ListShape[ListShape.Count - 1].ToString());
            }
            this.StatusFull = false;
            this.bPolygon = false;
            this.bCurve = false;
        }
        private void pPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.bLine == true || this.bCricle == true || this.bEllipse == true 
                || this.bRectangle == true || this.bSquare == true)
                clbResult.Items.Add(ListShape[ListShape.Count - 1].ToString());
            if (this.Selected == true && this.bCurve == false && this.bPolygon == false)
            {
                this.Selected = false;
                if (rectangleSelect.End.X > rectangleSelect.Begin.X && rectangleSelect.End.Y 
                    < rectangleSelect.Begin.Y)
                {
                    int Temp = rectangleSelect.Begin.Y;
                    rectangleSelect.Begin = new Point(rectangleSelect.Begin.X, rectangleSelect.End.Y);
                    rectangleSelect.End = new Point(rectangleSelect.End.X, Temp);
                }
                else if (rectangleSelect.End.X < rectangleSelect.Begin.X && rectangleSelect.End.Y 
                    > rectangleSelect.Begin.Y)
                {
                    int Temp = rectangleSelect.Begin.X;
                    rectangleSelect.Begin = new Point(rectangleSelect.End.X, rectangleSelect.Begin.Y);
                    rectangleSelect.End = new Point(Temp, rectangleSelect.End.Y);
                }
                else if (rectangleSelect.End.X < rectangleSelect.Begin.X && rectangleSelect.End.Y 
                    < rectangleSelect.Begin.Y)
                {
                    Point Temp = rectangleSelect.Begin;
                    rectangleSelect.Begin = rectangleSelect.End;
                    rectangleSelect.End = Temp;
                }
                for (int i = this.ListShape.Count - 1; i >= 0; i--)
                {
                    if (rectangleSelect.Begin.X < ListShape[i].Begin.X && rectangleSelect.Begin.Y 
                        < ListShape[i].Begin.Y && rectangleSelect.Begin.X < ListShape[i].End.X
                        && rectangleSelect.Begin.Y < ListShape[i].End.Y && rectangleSelect.End.X
                        > ListShape[i].Begin.X && rectangleSelect.End.Y > ListShape[i].Begin.Y
                        && rectangleSelect.End.X > ListShape[i].End.X && rectangleSelect.End.Y 
                        > ListShape[i].End.Y)
                    {
                        clbResult.SetItemChecked(i, true);
                    }
                }
                //this.Refresh();
                this.RefreshUpdate();
            }
            if (this.Fix == true)
            {
                this.clbResult.Items.Clear();
                for (int i = 0; i < this.ListShape.Count; i++)
                {
                    this.clbResult.Items.Add(this.ListShape[i].ToString());
                    if (this.ListShape[i].IsSelected == true)
                        this.clbResult.SetItemChecked(i, true);
                }
            }

            this.Fix = false;
            this.IndexFix = false;
            this.MoveIndex = false;
            this.Status = false;
            this.bLine = false;
            this.bEllipse = false;
            this.bSquare = false;
            this.bCricle = false;
            this.bRectangle = false;
        }
        #endregion

        #region Event 
        private void pPaint_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                this.ListShape[i].Draw(graphics);
                this.DrawInCheck(i);
            }
        }
        private void btnColor1_BackColorChanged(object sender, EventArgs e)
        {
            List<Shape> shapeTemp;
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                if (this.ListShape[i].IsSelected == true)
                {
                    if ((shapeTemp = this.ListShape[i].UnGroup()) == null)
                    {
                        this.ListShape[i].myPen.Color = this.btnColor1.BackColor;
                        this.ListShape[i].myBrush = new HatchBrush(this.PickHatchStyle(), this.btnColor1.BackColor, this.btnColor2.BackColor);
                    }
                    else
                    {
                        for (int j = 0; j < shapeTemp.Count; j++)
                        {
                            shapeTemp[j].myPen.Color = this.btnColor1.BackColor;
                            shapeTemp[j].myBrush = new HatchBrush(this.PickHatchStyle(), this.btnColor1.BackColor, this.btnColor2.BackColor);
                        }
                        this.ListShape[i].TempListShape(shapeTemp);
                    }
                }
            }
            //this.Refresh();
            this.RefreshUpdate();
        }
        private void btnColor2_BackColorChanged(object sender, EventArgs e)
        {
            List<Shape> shapeTemp;
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                if (this.ListShape[i].IsSelected == true)
                {
                    if ((shapeTemp = this.ListShape[i].UnGroup()) == null)
                    {
                        this.ListShape[i].myBrush = new HatchBrush(this.PickHatchStyle(), this.btnColor1.BackColor, this.btnColor2.BackColor);
                    }
                    else
                    {
                        for (int j = 0; j < shapeTemp.Count; j++)
                        {
                            shapeTemp[j].myBrush = new HatchBrush(this.PickHatchStyle(), this.btnColor1.BackColor, this.btnColor2.BackColor);
                        }
                        this.ListShape[i].TempListShape(shapeTemp);
                    }
                }
            }
            //this.Refresh();
            this.RefreshUpdate();
        }
        private void clbResult_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                this.ListShape[e.Index].IsSelected = true;
            else
                this.ListShape[e.Index].IsSelected = false;
            //this.Refresh();
            this.RefreshUpdate();
        }
        private void tkbThickNess_ValueChanged(object sender, EventArgs e)
        {
            List<Shape> shapeTemp;
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                if (this.ListShape[i].IsSelected == true)
                {
                    if ((shapeTemp = this.ListShape[i].UnGroup()) == null)
                    {
                        this.ListShape[i].myPen.Width = int.Parse(this.tkbThickNess.Value.ToString());
                    }
                    else
                    {
                        for (int j = 0; j < shapeTemp.Count; j++)
                        {
                            shapeTemp[j].myPen.Width = int.Parse(this.tkbThickNess.Value.ToString());
                        }
                        this.ListShape[i].TempListShape(shapeTemp);
                    }
                }
            }
            //this.Refresh();
            this.RefreshUpdate();
        }
        private void cbxDashStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Shape> shapeTemp;
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                if (this.ListShape[i].IsSelected == true)
                {
                    if ((shapeTemp = this.ListShape[i].UnGroup()) == null)
                    {
                        this.ListShape[i].myPen = this.PickDashStyle(this.ListShape[i].myPen);
                    }
                    else
                    {
                        for (int j = 0; j < shapeTemp.Count; j++)
                        {
                            shapeTemp[j].myPen = this.PickDashStyle(shapeTemp[j].myPen);
                        }
                        this.ListShape[i].TempListShape(shapeTemp);
                    }
                }
            }
            // this.Refresh();
            this.RefreshUpdate();
        }
        private void cbxHatchStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Shape> shapeTemp;
            for (int i = 0; i < this.ListShape.Count; i++)
            {
                if (this.ListShape[i].IsSelected == true)
                {
                    if ((shapeTemp = this.ListShape[i].UnGroup()) == null)
                    {
                        this.ListShape[i].myBrush = this.PickBrush();
                    }
                    else
                    {
                        for (int j = 0; j < shapeTemp.Count; j++)
                        {
                            shapeTemp[j].myBrush = this.PickBrush();
                        }
                        this.ListShape[i].TempListShape(shapeTemp);
                    }
                }
            }
            // this.Refresh();
            this.RefreshUpdate();
        }
        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                this.CheckCtrl = true;
            else if (e.KeyCode == Keys.Delete)
                this.btnDelete_Click(sender, null);
        }
        private void fMain_KeyUp(object sender, KeyEventArgs e)
        {
            this.CheckCtrl = false;
        }
        private void pPaint_Leave(object sender, EventArgs e)
        {
            myBuffer.Dispose();
            myBuffer = currentContext.Allocate(this.pPaint.CreateGraphics(), this.pPaint.DisplayRectangle);
        }
        #endregion

        
    }
}
