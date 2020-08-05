namespace Paint_Winform_v1
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pPaint = new System.Windows.Forms.Panel();
            this.pMenu = new System.Windows.Forms.Panel();
            this.cbxHatchStyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rbNoFill = new System.Windows.Forms.RadioButton();
            this.rbFill = new System.Windows.Forms.RadioButton();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDashStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tkbThickNess = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCricle = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.pResult = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUnGroup = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.clbResult = new System.Windows.Forms.CheckedListBox();
            this.pMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbThickNess)).BeginInit();
            this.pResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // pPaint
            // 
            this.pPaint.AutoSize = true;
            this.pPaint.BackColor = System.Drawing.Color.White;
            this.pPaint.Location = new System.Drawing.Point(-3, 92);
            this.pPaint.Name = "pPaint";
            this.pPaint.Size = new System.Drawing.Size(1176, 472);
            this.pPaint.TabIndex = 0;
            this.pPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.pPaint_Paint);
            this.pPaint.Leave += new System.EventHandler(this.pPaint_Leave);
            this.pPaint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pPaint_MouseClick);
            this.pPaint.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pPaint_MouseDoubleClick);
            this.pPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pPaint_MouseDown);
            this.pPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pPaint_MouseMove);
            this.pPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pPaint_MouseUp);
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pMenu.Controls.Add(this.cbxHatchStyle);
            this.pMenu.Controls.Add(this.label6);
            this.pMenu.Controls.Add(this.btnColor2);
            this.pMenu.Controls.Add(this.label5);
            this.pMenu.Controls.Add(this.rbNoFill);
            this.pMenu.Controls.Add(this.rbFill);
            this.pMenu.Controls.Add(this.btnPolygon);
            this.pMenu.Controls.Add(this.btnCurve);
            this.pMenu.Controls.Add(this.btnColor1);
            this.pMenu.Controls.Add(this.label3);
            this.pMenu.Controls.Add(this.cbxDashStyle);
            this.pMenu.Controls.Add(this.label2);
            this.pMenu.Controls.Add(this.tkbThickNess);
            this.pMenu.Controls.Add(this.label1);
            this.pMenu.Controls.Add(this.btnCricle);
            this.pMenu.Controls.Add(this.btnEllipse);
            this.pMenu.Controls.Add(this.btnSquare);
            this.pMenu.Controls.Add(this.btnRectangle);
            this.pMenu.Controls.Add(this.btnLine);
            this.pMenu.Location = new System.Drawing.Point(0, 0);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(1171, 87);
            this.pMenu.TabIndex = 1;
            // 
            // cbxHatchStyle
            // 
            this.cbxHatchStyle.FormattingEnabled = true;
            this.cbxHatchStyle.Location = new System.Drawing.Point(990, 48);
            this.cbxHatchStyle.Name = "cbxHatchStyle";
            this.cbxHatchStyle.Size = new System.Drawing.Size(178, 24);
            this.cbxHatchStyle.TabIndex = 24;
            this.cbxHatchStyle.SelectedIndexChanged += new System.EventHandler(this.cbxHatchStyle_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(1031, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "HatchStyle";
            // 
            // btnColor2
            // 
            this.btnColor2.BackColor = System.Drawing.Color.Red;
            this.btnColor2.Location = new System.Drawing.Point(703, 41);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(51, 39);
            this.btnColor2.TabIndex = 22;
            this.btnColor2.UseVisualStyleBackColor = false;
            this.btnColor2.BackColorChanged += new System.EventHandler(this.btnColor2_BackColorChanged);
            this.btnColor2.Click += new System.EventHandler(this.btnColor2_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(687, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Màu sắc 2";
            // 
            // rbNoFill
            // 
            this.rbNoFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoFill.Location = new System.Drawing.Point(389, 39);
            this.rbNoFill.Name = "rbNoFill";
            this.rbNoFill.Size = new System.Drawing.Size(98, 45);
            this.rbNoFill.TabIndex = 20;
            this.rbNoFill.Text = "No Fill";
            this.rbNoFill.UseVisualStyleBackColor = true;
            // 
            // rbFill
            // 
            this.rbFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFill.Location = new System.Drawing.Point(389, 5);
            this.rbFill.Name = "rbFill";
            this.rbFill.Size = new System.Drawing.Size(85, 45);
            this.rbFill.TabIndex = 19;
            this.rbFill.Text = "Fill";
            this.rbFill.UseVisualStyleBackColor = true;
            this.rbFill.CheckedChanged += new System.EventHandler(this.rbFill_CheckedChanged);
            // 
            // btnPolygon
            // 
            this.btnPolygon.Location = new System.Drawing.Point(288, 12);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(86, 68);
            this.btnPolygon.TabIndex = 18;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnCurve
            // 
            this.btnCurve.Location = new System.Drawing.Point(196, 49);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(86, 31);
            this.btnCurve.TabIndex = 16;
            this.btnCurve.Text = "Curve";
            this.btnCurve.UseVisualStyleBackColor = true;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnColor1
            // 
            this.btnColor1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnColor1.Location = new System.Drawing.Point(609, 41);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(51, 39);
            this.btnColor1.TabIndex = 15;
            this.btnColor1.UseVisualStyleBackColor = false;
            this.btnColor1.BackColorChanged += new System.EventHandler(this.btnColor1_BackColorChanged);
            this.btnColor1.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(582, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Màu sắc 1";
            // 
            // cbxDashStyle
            // 
            this.cbxDashStyle.FormattingEnabled = true;
            this.cbxDashStyle.Items.AddRange(new object[] {
            "Dash",
            "DashDot",
            "DashDotDot",
            "Dot",
            "Solid"});
            this.cbxDashStyle.Location = new System.Drawing.Point(791, 48);
            this.cbxDashStyle.Name = "cbxDashStyle";
            this.cbxDashStyle.Size = new System.Drawing.Size(178, 24);
            this.cbxDashStyle.TabIndex = 12;
            this.cbxDashStyle.SelectedIndexChanged += new System.EventHandler(this.cbxDashStyle_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(831, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "DashStyle";
            // 
            // tkbThickNess
            // 
            this.tkbThickNess.AutoSize = false;
            this.tkbThickNess.Location = new System.Drawing.Point(484, 46);
            this.tkbThickNess.Minimum = 1;
            this.tkbThickNess.Name = "tkbThickNess";
            this.tkbThickNess.Size = new System.Drawing.Size(110, 28);
            this.tkbThickNess.TabIndex = 10;
            this.tkbThickNess.Value = 3;
            this.tkbThickNess.ValueChanged += new System.EventHandler(this.tkbThickNess_ValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(480, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "ThickNess";
            // 
            // btnCricle
            // 
            this.btnCricle.Location = new System.Drawing.Point(196, 12);
            this.btnCricle.Name = "btnCricle";
            this.btnCricle.Size = new System.Drawing.Size(86, 31);
            this.btnCricle.TabIndex = 4;
            this.btnCricle.Text = "Cricle";
            this.btnCricle.UseVisualStyleBackColor = true;
            this.btnCricle.Click += new System.EventHandler(this.btnCricle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(104, 49);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(86, 31);
            this.btnEllipse.TabIndex = 3;
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.Location = new System.Drawing.Point(104, 12);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(86, 31);
            this.btnSquare.TabIndex = 2;
            this.btnSquare.Text = "Square";
            this.btnSquare.UseVisualStyleBackColor = true;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Location = new System.Drawing.Point(12, 49);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(86, 31);
            this.btnRectangle.TabIndex = 1;
            this.btnRectangle.Text = "Rectangle";
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(12, 12);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(86, 31);
            this.btnLine.TabIndex = 0;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // pResult
            // 
            this.pResult.BackColor = System.Drawing.Color.Black;
            this.pResult.Controls.Add(this.btnAll);
            this.pResult.Controls.Add(this.btnDeleteAll);
            this.pResult.Controls.Add(this.btnDelete);
            this.pResult.Controls.Add(this.btnUnGroup);
            this.pResult.Controls.Add(this.btnGroup);
            this.pResult.Controls.Add(this.label4);
            this.pResult.Controls.Add(this.clbResult);
            this.pResult.Location = new System.Drawing.Point(1177, 0);
            this.pResult.Name = "pResult";
            this.pResult.Size = new System.Drawing.Size(305, 564);
            this.pResult.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(110, 59);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(86, 31);
            this.btnAll.TabIndex = 22;
            this.btnAll.Text = " All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click_1);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(204, 59);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(86, 31);
            this.btnDeleteAll.TabIndex = 21;
            this.btnDeleteAll.Text = "Del - All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(204, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 31);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUnGroup
            // 
            this.btnUnGroup.Location = new System.Drawing.Point(110, 18);
            this.btnUnGroup.Name = "btnUnGroup";
            this.btnUnGroup.Size = new System.Drawing.Size(86, 31);
            this.btnUnGroup.TabIndex = 19;
            this.btnUnGroup.Text = "UnGroup";
            this.btnUnGroup.UseVisualStyleBackColor = true;
            this.btnUnGroup.Click += new System.EventHandler(this.btnUnGroup_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(15, 18);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(86, 31);
            this.btnGroup.TabIndex = 18;
            this.btnGroup.Text = "Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(0, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "HÌNH ĐÃ VẼ";
            // 
            // clbResult
            // 
            this.clbResult.FormattingEnabled = true;
            this.clbResult.Location = new System.Drawing.Point(0, 93);
            this.clbResult.Name = "clbResult";
            this.clbResult.Size = new System.Drawing.Size(297, 514);
            this.clbResult.TabIndex = 0;
            this.clbResult.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbResult_ItemCheck);
            // 
            // fMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1478, 567);
            this.Controls.Add(this.pResult);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.pPaint);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyUp);
            this.pMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tkbThickNess)).EndInit();
            this.pResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pPaint;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Panel pResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCricle;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.TrackBar tkbThickNess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDashStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbResult;
        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUnGroup;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.RadioButton rbNoFill;
        private System.Windows.Forms.RadioButton rbFill;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxHatchStyle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnAll;
    }
}

