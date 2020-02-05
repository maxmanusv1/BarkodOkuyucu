using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodOkuyucu
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.OdemeMiktari;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                int a = int.Parse(Form1.OdemeMiktari);
                int b = int.Parse(textBox1.Text);
                int c = b - a;
                label5.Text = c.ToString();
            }
            else if (textBox1.Text=="")
            {
                label5.Text = "0";
            }
          
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
