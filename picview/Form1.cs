using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picview
{
    public partial class FormPicView : Form
    {
        float dpi_zoom;

        public FormPicView()
        {
            InitializeComponent();
            topmostToolStripMenuItem.Checked = TopMost;
            Graphics testGraphic = CreateGraphics();
            dpi_zoom = Math.Min(testGraphic.DpiX / 96.0f, testGraphic.DpiY / 96.0f);
            testGraphic.Dispose();
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

        void NavigateImageSource(bool toRight)
        {
            if (imagePath == null)
                return;
            FileInfo fileInfo = new FileInfo(imagePath);
            DirectoryInfo dir = fileInfo.Directory;
            int index = -1;
            int attempts = dir.GetFiles().Length;
            for(int i=0;i<attempts;i++)
            {
                if(dir.GetFiles()[i].FullName==fileInfo.FullName)
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
                    index = (index + 1) % dir.GetFiles().Length;
                else
                    index = (index + dir.GetFiles().Length - 1) % dir.GetFiles().Length;
                if (imageReg.Match(dir.GetFiles()[index].FullName.ToLower()).Success)
                {
                    SetImageSource(dir.GetFiles()[index].FullName);
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
            pictureBoxMain.BackColor = c;
        }

        private void colorBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackgroundColor(Color.Black);
        }

        private void colorWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackgroundColor(Color.White);
        }
    }
}
