using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;

namespace BarkodOkuyucu
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            Image image = barcode.Encode(TYPE.EAN13, textBox1.Text, Color.Black, Color.Transparent, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter =  "PNG|*.png" })
            {
                if (saveFile.ShowDialog()==DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFile.FileName);
                }
            }
          
        }
    }
}
