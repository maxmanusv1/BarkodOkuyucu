using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodOkuyucu
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string path2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BarkodOkuyucu\veri1.txt";
        private void button2_Click(object sender, EventArgs e)
        {
           

            string txtBox = textBox1.Text;
            string str;
            ArrayList ayi2 = new ArrayList();
            ArrayList array = new ArrayList();
            FileStream file = new FileStream(path2, FileMode.Open, FileAccess.Read);
            StreamReader stream = new StreamReader(file);
          
            
                while ((str = stream.ReadLine()) != null)
                {
                    array.Add(str);

                }



                for (int i = 0; i < array.Count; i++)
                {

                    ayi2.AddRange(array[i].ToString().Split(' '));
                    if (ayi2[1].ToString() == txtBox)
                    {


                    // dataGridView1.Rows.Add("1", ayi2[1].ToString(), ayi2[0].ToString().Replace(">", " "), ayi2[4].ToString());
                    this.Width = 539;
                    this.Height = 520;
                    pictureBox1.Visible = false;
                    label3.Text = ayi2[0].ToString().Replace(">", " ");
                    label5.Text = ayi2[1].ToString();
                    label7.Text = ayi2[3].ToString();
                    label9.Text = ayi2[4].ToString();
                    label11.Text = ayi2[2].ToString();
                    array.Clear();
                    }
                    else if (ayi2[1].ToString() != txtBox)
                    {

                        ayi2.Clear();
                    }
               



                }
          
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Width = 539;
            this.Height = 148;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Width = 539;
            this.Height = 520;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Width = 539;
            this.Height = 148;
            pictureBox1.Visible = true;
           
        }
    }
}
