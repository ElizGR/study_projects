using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Drawing.Drawing2D;


namespace рпис4
{
    public partial class Form1 : Form
    {
        int n = 0;
        int k = 0;
        public Form1()
        {

            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] str = Directory.GetFiles("D:\\");
        }
        private void addImage(string imageToLoad)
        {
            if (imageToLoad != "")
            {
                imageList1.Images.Add(Image.FromFile(imageToLoad));

            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                addImage(fileName);
                n++;
                label1.Text = n.ToString();
                for (int i = k; i < n; i++)
                {
                    pictureBox1.Image = imageList1.Images[i];
                    ListViewItem item = new ListViewItem();
                    // item.Text = openFileDialog1.FileName[i];
                    item.ImageIndex = i;
                    this.listView1.Items.Add(item);
                    dataGridView1.Rows.Add(openFileDialog1.FileName, imageList1.Images[i].Width, imageList1.Images[i].Height, i.ToString());
                    k++;
                }
            }


        }



        private void addimage(string fileName)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = DrawText2("Специально для Елизаветы;)", imageList1.Images[0]);
            pictureBox1.Image.Save("d:\\newImage.bmp");
        }

        private void DrawText2(string text)
        {
            throw new NotImplementedException();
        }
        public Image ResizeImg(Image b, int nWidth, int nHeight, float deg = 0f)
        {
            Image result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // b.RotateFlip(RotateFlipType.Rotate270FlipY);
                g.RotateTransform(deg);
                g.DrawImage(b, 0, 0, nWidth, nHeight);
                // g.Clear(Color.White);
                g.Dispose();

            }
            return result;
        }
        private Image DrawText2(String text, Image img)
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            Image newImage = img;
            formGraphics = Graphics.FromImage(newImage);
            formGraphics.DrawString(text, new Font("Arial", 35), Brushes.Blue, new Point(100, 20));
            formGraphics.Dispose();
            myPen.Dispose();
            formGraphics.Dispose();
            return newImage;
        }
        private void copyrightTextToolStripMenuItem_Click()
        {
        
        }
    }
}
