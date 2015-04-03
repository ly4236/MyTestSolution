using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
   
        }

        private void buttonSayHello_Click(object sender, EventArgs e)
        {
            //if (pictureBox1.Image == null)
            //{
            //    ShowPicture();
            //}
            //else
            //{
            //    pictureBox1.Image.Dispose();
            //    pictureBox2.Image.Dispose();
            //}

            Graphics g = this.CreateGraphics();
      
            Pen p = new Pen(Color.Blue);
            g.DrawRectangle(p,50,50,140,100);
            p.Dispose();
            g.Dispose();
        }
       // public void ShowPicture()
       //{
       //     pictureBox1.LoadAsync(@"E:\Anime\毛泽东思想与邓小平理论\三色坊\[三色坊] 撫鏡軼聞 上冊\f01_002.png");//Image = Image.FromFile(@"E:\Anime\毛泽东思想与邓小平理论\三色坊\[三色坊] 撫鏡軼聞 上冊\f01_002.png");
       //     pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

       //     pictureBox2.LoadAsync(@"E:\Anime\毛泽东思想与邓小平理论\三色坊\[三色坊] 撫鏡軼聞 上冊\f01_002.png");//Image = Image.FromFile(@"E:\Anime\毛泽东思想与邓小平理论\三色坊\[三色坊] 撫鏡軼聞 上冊\f01_002.png");
       //     pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            
       // } 

    }
}
