﻿using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace picview
{
    public partial class FormPicView : Form
    {
        float dpi_zoom;
        string menuCustomColorText;

        public FormPicView()
        {
            InitializeComponent();
            topmostToolStripMenuItem.Checked = TopMost;
            Graphics testGraphic = CreateGraphics();
            dpi_zoom = Math.Min(testGraphic.DpiX / 96.0f, testGraphic.DpiY / 96.0f);
            testGraphic.Dispose();
            menuCustomColorText = colorCustomToolStripMenuItem.Text;
            ChangeBackgroundColor(Color.White);
            useSystemDPIToolStripMenuItem.Text = String.Format(useSystemDPIToolStripMenuItem.Text, dpi_zoom * 100);
            if (Environment.GetCommandLineArgs().Length > 1)
                SetImageSource(Environment.GetCommandLineArgs()[1]);
        }

        private void topmostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = topmostToolStripMenuItem.Checked = !TopMost;
        }

        private void fitImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowFitImage();
        }

        void WindowFitImage()
        {
            if (pictureBoxMain.Image != null && WindowState == FormWindowState.Normal)
            {
                if (useSystemDPIToolStripMenuItem.Checked)
                    SetClientSizeCore((int)(pictureBoxMain.Image.Width * dpi_zoom), (int)(pictureBoxMain.Image.Height * dpi_zoom));
                else
                    SetClientSizeCore(pictureBoxMain.Image.Width, pictureBoxMain.Image.Height);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(imagePath!=null)
            {
                FileInfo fileInfo = new FileInfo(imagePath);
                openFileDialogImagePath.InitialDirectory = fileInfo.DirectoryName;
                openFileDialogImagePath.FileName = fileInfo.Name;
            }
            if (openFileDialogImagePath.ShowDialog() == DialogResult.OK)
                SetImageSource(openFileDialogImagePath.FileName);
        }

        String imagePath;

        void SetImageSource(string path)
        {
            try
            {
                if (pictureBoxMain.Image != null)
                    pictureBoxMain.Image.Dispose();
                pictureBoxMain.Image = new Bitmap(path);
                imagePath = path;
                Text=String.Format("{0} ({1}x{2})", path, pictureBoxMain.Image.Width, pictureBoxMain.Image.Height);
                WindowFitImage();
            }
            catch(Exception e)
            {
                pictureBoxMain.Image = null;
                Text = String.Format("{0} ({1})", path, e.Message);
            }
        }

        private void FormPicView_DragDrop(object sender, DragEventArgs e)
        {
            SetImageSource(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
        }

        private void FormPicView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void timerControlTimeOut_Tick(object sender, EventArgs e)
        {
            buttonToNext.Visible = buttonToPrevious.Visible = false;
            timerControlTimeOut.Stop();
        }

        Point previousMouseLocation;

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location != previousMouseLocation)
            {
                previousMouseLocation = e.Location;
                buttonToNext.Visible = buttonToPrevious.Visible = true;
                timerControlTimeOut.Start();
            }
        }

        Regex imageReg = new Regex("^.*\\.(bmp|dib|jp.+|jfif|png|gif|tif.*)$");

        public class FileNameSorter : IComparer
        {
            [System.Runtime.InteropServices.DllImport("Shlwapi.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            private static extern int StrCmpLogicalW(string s1, string s2);
            public int Compare(object o1,object o2)
            {
                return StrCmpLogicalW(o1.ToString(), o2.ToString());
            }
        }

        void NavigateImageSource(bool toRight)
        {
            if (imagePath == null)
                return;
            FileInfo fileInfo = new FileInfo(imagePath);
            DirectoryInfo dir = fileInfo.Directory;
            FileInfo[] fileList = dir.GetFiles();
            if (useSystemSortToolStripMenuItem.Checked)
                Array.Sort(fileList, new FileNameSorter());
            int index = -1;
            int attempts = fileList.Length;
            for(int i=0;i<attempts;i++)
            {
                if(fileList[i].FullName==fileInfo.FullName)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                return;
            while(attempts>1)
            {
                attempts--;
                if (toRight)
                    index = (index + 1) % fileList.Length;
                else
                    index = (index + fileList.Length - 1) % fileList.Length;
                if (imageReg.Match(fileList[index].FullName.ToLower()).Success)
                {
                    SetImageSource(fileList[index].FullName);
                    break;
                }
            }
        }

        private void buttonToPrevious_Click(object sender, EventArgs e)
        {
            NavigateImageSource(false);
        }

        private void buttonToNext_Click(object sender, EventArgs e)
        {
            NavigateImageSource(true);
        }

        private void FormPicView_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:NavigateImageSource(false);break;
                case Keys.Right:NavigateImageSource(true);break;
            }
        }

        private void useSystemDPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useSystemDPIToolStripMenuItem.Checked = !useSystemDPIToolStripMenuItem.Checked;
        }

        void ChangeBackgroundColor(Color c)
        {
            colorBlackToolStripMenuItem.Checked = c == Color.Black;
            colorWhiteToolStripMenuItem.Checked = c == Color.White;
            colorCustomToolStripMenuItem.Checked = (c != Color.Black && c != Color.White);
            pictureBoxMain.BackColor = c;
            colorCustomToolStripMenuItem.Text = String.Format(menuCustomColorText, c.R, c.G, c.B);
        }

        private void colorBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackgroundColor(Color.Black);
        }

        private void colorWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackgroundColor(Color.White);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //参考：https://blog.csdn.net/genganpeng/article/details/8649191
            if (keyData == Keys.Left || keyData == Keys.Right)
                return false;
            return base.ProcessDialogKey(keyData);
        }

        private void pictureBoxMain_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                WindowFitImage();
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void RotateImage(bool toRight)
        {
            if (pictureBoxMain.Image == null)
                return;
            pictureBoxMain.Image.RotateFlip(toRight ? RotateFlipType.Rotate90FlipNone : RotateFlipType.Rotate270FlipNone);
            pictureBoxMain.Invalidate();
        }

        private void rotateRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(true);
        }

        private void rotateLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(false);
        }

        private void colorCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialogBackground.Color = pictureBoxMain.BackColor;
            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
                ChangeBackgroundColor(colorDialogBackground.Color);
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(imagePath))
                Process.Start("explorer", "/select,\"" + imagePath + "\"");
        }
    }
}
