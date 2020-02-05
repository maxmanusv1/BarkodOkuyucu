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
using System.Collections;

namespace BarkodOkuyucu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int alis, satis, oran;
            alis = int.Parse(textBox4.Text);

            oran = int.Parse(textBox6.Text);

            satis = ((alis / 100) * oran)+alis;

            textBox5.Text = satis.ToString();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           


        }

        private void label8_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox4.Text!="" && textBox5.Text!="")
            {
             
                    int kar;
                    int alis, satis;
                    alis = int.Parse(textBox4.Text);

                    satis = int.Parse(textBox5.Text);

                    kar = satis - alis;

                    label8.Text = kar.ToString();
                  
            }
            else if (textBox4.Text=="" || textBox5.Text=="")
            {
                label8.Text = "0";
            }
            
        }
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ @"\BarkodOkuyucu\veri1.txt";
       
        private void button1_Click(object sender, EventArgs e)
        {
            var a = textBox1.Text;
            string urunismi = a.Replace(" ",">"),barkod=textBox2.Text,adet=textBox3.Text,alisfiyati=textBox4.Text,satisfiyati=textBox5.Text;
          
           
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
     
            StreamWriter writer = new StreamWriter(stream); 
               
            writer.WriteLine(urunismi + " " + barkod + " " + adet + " " + alisfiyati + " " + satisfiyati);
                
           
            writer.Close();

            stream.Close();


            MessageBox.Show("başarılı");
        }
    }
}
