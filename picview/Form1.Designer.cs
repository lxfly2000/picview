namespace picview
{
    partial class FormPicView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSystemDPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorBlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToPrevious = new System.Windows.Forms.Button();
            this.buttonToNext = new System.Windows.Forms.Button();
            this.timerControlTimeOut = new System.Windows.Forms.Timer(this.components);
            this.toolTipToPrevious = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipToNext = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogImagePath = new System.Windows.Forms.OpenFileDialog();
            this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.contextMenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.ContextMenuStrip = this.contextMenuMain;
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMain.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.DoubleClick += new System.EventHandler(this.pictureBoxMain_DoubleClick);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.rotateRightToolStripMenuItem,
            this.rotateLeftToolStripMenuItem,
            this.fitImageToolStripMenuItem,
            this.useSystemDPIToolStripMenuItem,
            this.changeBackgroundColorToolStripMenuItem,
            this.topmostToolStripMenuItem});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(440, 381);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(439, 46);
            this.openToolStripMenuItem.Text = "打开(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // rotateRightToolStripMenuItem
            // 
            this.rotateRightToolStripMenuItem.Name = "rotateRightToolStripMenuItem";
            this.rotateRightToolStripMenuItem.Size = new System.Drawing.Size(439, 46);
            this.rotateRightToolStripMenuItem.Text = "顺时针旋转90°(&R)";
            this.rotateRightToolStripMenuItem.Click += new System.EventHandler(this.rotateRightToolStripMenuItem_Click);
            // 
            // rotateLeftToolStripMenuItem
            // 
            this.rotateLeftToolStripMenuItem.Name = "rotateLeftToolStripMenuItem";
            this.rotateLeftToolStripMenuItem.Size = new System.Drawing.Size(439, 46);
            this.rotateLeftToolStripMenuItem.Text = "逆时针旋转90°(&L)";
            this.rotateLeftToolStripMenuItem.Click += new System.EventHandler(this.rotateLeftToolStripMenuItem_Click);
            // 
            // fitImageToolStripMenuItem
            // 
            this.fitImageToolStripMenuItem.Name = "fitImageToolStripMenuItem";
            this.fitImageToolStripMenuItem.Size = new System.Drawing.Size(439, 46);
            this.fitImageToolStripMenuItem.Text = "调整窗口为图片大小(&F)";
            this.fitImageToolStripMenuItem.Click += new System.EventHandler(this.fitImageToolStripMenuItem_Click);
            // 
            // useSystemDPIToolStripMenuItem
            // 
            this.useSystemDPIToolStripMenuItem.Checked = true;
            this.useSystemDPIToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSystemDPIToolStripMenuItem.Name = "useSystemDPIToolStripMenuItem";
            this.useSystemDPIToolStripMenuItem.Size = new System.Drawing.Size(439, 46);
            this.useSystemDPIToolStripMenuItem.Text = "调整时使用系统&DPI[{0}%]";
            this.useSystemDPIToolStripMenuItem.Click += new System.EventHandler(this.useSystemDPIToolStripMenuItem_Click);
            // 
            // changeBackgroundColorToolStripMenuItem
            // 
            this.changeBackgroundColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorBlackToolStripMenuItem,
            this.colorWhiteToolStripMenuItem,
            this.colorCustomToolStripMenuItem});
            this.changeBackgroundColorToolStripMenuItem.Name = "changeBackgroundColorToolStripMenuItem";
            this.changeBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(439, 46);
            this.changeBackgroundColorToolStripMenuItem.Text = "背景色(&C)";
            // 
            // colorBlackToolStripMenuItem
            // 
            this.colorBlackToolStripMenuItem.Name = "colorBlackToolStripMenuItem";
            this.colorBlackToolStripMenuItem.Size = new System.Drawing.Size(429, 46);
            this.colorBlackToolStripMenuItem.Text = "黑色(&B)";
            this.colorBlackToolStripMenuItem.Click += new System.EventHandler(this.colorBlackToolStripMenuItem_Click);
            // 
            // colorWhiteToolStripMenuItem
            // 
            this.colorWhiteToolStripMenuItem.Name = "colorWhiteToolStripMenuItem";
            this.colorWhiteToolStripMenuItem.Size = new System.Drawing.Size(429, 46);
            this.colorWhiteToolStripMenuItem.Text = "白色(&W)";
            this.colorWhiteToolStripMenuItem.Click += new System.EventHandler(this.colorWhiteToolStripMenuItem_Click);
            // 
            // colorCustomToolStripMenuItem
            // 
            this.colorCustomToolStripMenuItem.Name = "colorCustomToolStripMenuItem";
            this.colorCustomToolStripMenuItem.Size = new System.Drawing.Size(429, 46);
            this.colorCustomToolStripMenuItem.Text = "自定义({0},{1},{2})(&C)...";
            this.colorCustomToolStripMenuItem.Click += new System.EventHandler(this.colorCustomToolStripMenuItem_Click);
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(439, 46);
            this.topmostToolStripMenuItem.Text = "置顶显示(&T)";
            this.topmostToolStripMenuItem.Click += new System.EventHandler(this.topmostToolStripMenuItem_Click);
            // 
            // buttonToPrevious
            // 
            this.buttonToPrevious.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonToPrevious.AutoSize = true;
            this.buttonToPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonToPrevious.FlatAppearance.BorderSize = 0;
            this.buttonToPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToPrevious.Location = new System.Drawing.Point(30, 198);
            this.buttonToPrevious.Margin = new System.Windows.Forms.Padding(8);
            this.buttonToPrevious.Name = "buttonToPrevious";
            this.buttonToPrevious.Size = new System.Drawing.Size(38, 40);
            this.buttonToPrevious.TabIndex = 1;
            this.buttonToPrevious.Text = "&<";
            this.toolTipToPrevious.SetToolTip(this.buttonToPrevious, "上一个");
            this.buttonToPrevious.UseVisualStyleBackColor = true;
            this.buttonToPrevious.Click += new System.EventHandler(this.buttonToPrevious_Click);
            // 
            // buttonToNext
            // 
            this.buttonToNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonToNext.AutoSize = true;
            this.buttonToNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonToNext.FlatAppearance.BorderSize = 0;
            this.buttonToNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToNext.Location = new System.Drawing.Point(732, 198);
            this.buttonToNext.Margin = new System.Windows.Forms.Padding(8);
            this.buttonToNext.Name = "buttonToNext";
            this.buttonToNext.Size = new System.Drawing.Size(38, 40);
            this.buttonToNext.TabIndex = 2;
            this.buttonToNext.Text = "&>";
            this.toolTipToNext.SetToolTip(this.buttonToNext, "下一个");
            this.buttonToNext.UseVisualStyleBackColor = true;
            this.buttonToNext.Click += new System.EventHandler(this.buttonToNext_Click);
            // 
            // timerControlTimeOut
            // 
            this.timerControlTimeOut.Enabled = true;
            this.timerControlTimeOut.Interval = 3000;
            this.timerControlTimeOut.Tick += new System.EventHandler(this.timerControlTimeOut_Tick);
            // 
            // openFileDialogImagePath
            // 
            this.openFileDialogImagePath.Filter = "图像文件|*.bmp;*.dib;*.jp*;*.jfif;*.gif;*.tif*;*.png|所有文件|*";
            this.openFileDialogImagePath.RestoreDirectory = true;
            // 
            // FormPicView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonToPrevious);
            this.Controls.Add(this.buttonToNext);
            this.Controls.Add(this.pictureBoxMain);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPicView";
            this.Text = "请选择图片";
            this.TopMost = true;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormPicView_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormPicView_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPicView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.contextMenuMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topmostToolStripMenuItem;
        private System.Windows.Forms.Button buttonToPrevious;
        private System.Windows.Forms.Button buttonToNext;
        private System.Windows.Forms.Timer timerControlTimeOut;
        private System.Windows.Forms.ToolTip toolTipToPrevious;
        private System.Windows.Forms.ToolTip toolTipToNext;
        private System.Windows.Forms.OpenFileDialog openFileDialogImagePath;
        private System.Windows.Forms.ToolStripMenuItem useSystemDPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorBlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorCustomToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogBackground;
    }
}

