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
        bool b;
        string TextCopyright= "djhgd1111";
          
        public Form1()
        {

            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (ListViewItem it in listView1.Items)
            //   {
            //        int i = 0;
            //        i = it.ImageIndex;
            //        pictureBox1.Image =imageList1.Images[i];
            //    }
            try
            {
                pictureBox1.Image = imageList1.Images[listView1.Items[listView1.SelectedIndices[0]].ImageIndex];
            }
            catch (Exception e1)
            {
            }
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
               for (int i = k; i < n; i++)
                {
                    pictureBox1.Image = imageList1.Images[i];
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = i;
                    this.listView1.Items.Add(item);
                    dataGridView1.Rows.Add(openFileDialog1.FileName, imageList1.Images[i].Width, imageList1.Images[i].Height,TextCopyright );//i.ToString()
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
            foreach (Image ig in imageList1.Images)
            { 
                pictureBox1.Image = DrawText2(TextCopyright, ig);
                pictureBox1.Image.Save("d:\\newImage.bmp");
            }
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
            formGraphics.DrawString(text, new Font("Arial", 15), Brushes.Blue, new Point(20, 20));
            formGraphics.Dispose();
            myPen.Dispose();
            formGraphics.Dispose();
            return newImage;
        }
        private void copyrightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible=true;
            textBox1.Visible = true;
            TextCopyright = textBox1.Text;
            label1.Text = "new text for copyright:";
            
        }
        
        private void listView1_Click(object sender, EventArgs e)
        {
            // Add these file names to the ImageList on load.
            // string[] files = { "image.png", "logo.jpg" };
            if (b)
                b = false;
            else
                b = true;
            var images = imageList1.Images;
            //  MessageBox.Show(""+imageList1.Images.Count);
            List<Image> imList = new List<Image>();
            int index = 0;
            foreach (ListViewItem k in listView1.Items)
            {
                index++;
                if (k.Checked)
                {
                    break;
                }
            }
            int index2 = 0;
            foreach (Image t in images)
            {
                // Use Image.FromFile to load the file.
                // images.Add(Image.FromFile(file));
                ////  index2++;
                // if (index == index2)


                imList.Add(DrawText2("12323", t));
            }
            // MessageBox.Show(""+imageList1.Images.Count);
            imageList1.Images.Clear();
            if (b)
                imageList1.Images.AddRange(imList.ToArray());
            else
                imageList1.Images.AddRange(imList.ToArray());
            // pictureBox1.Image = imageList1.Images[2];
            listView1.SmallImageList = imageList1;

            //   listView1.SelectedItems.Clear();
        }

        private void copyrightTextToolStripMenuItem_Click()
        {

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Visible = false;
                label1.Visible = false;
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //for (ListViewItem it in listView1.Items)
            //{
            //    int i = 0;
            //    i = it.ImageIndex;
            //    pictureBox1.Image = imageList1.Images[i];
            //}
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
