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
using System.Threading;
using BarcodeLib;
namespace BarkodOkuyucu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            

             
        }
       string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\BarkodOkuyucu";
       string path2= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BarkodOkuyucu\veri1.txt";
       string path3= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BarkodOkuyucu\satis.txt";
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
              if (Directory.Exists(path) == true && Directory.Exists(path2) == true && Directory.Exists(path3) == true)
              {
                  KontrolcuTimer.Enabled = true;

              }
              else if (Directory.Exists(path)==false || Directory.Exists(path2) == false || Directory.Exists(path3) == false)
              {
                  DirectoryInfo directory = new DirectoryInfo(path);
                  directory.Create();
                  FileStream file = new FileStream(path2,FileMode.OpenOrCreate,FileAccess.Write);
                  StreamWriter stream = new StreamWriter(file);
                  stream.Write("");
                  stream.Close();             
                  file.Close();

                  FileStream file2 = new FileStream(path3, FileMode.OpenOrCreate, FileAccess.Write);
                  StreamWriter stream2 = new StreamWriter(file2);

                  stream2.Write("");
                  stream2.Close();
                  file2.Close();
                  KontrolcuTimer.Enabled = true;
              }
             
           
         /*   if (Directory.Exists(path) && Directory.Exists(path2) && Directory.Exists(path3))
            {
       
              KontrolcuTimer.Enabled = true;   

            }
            else if (!Directory.Exists(path))
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Create();
                if (!Directory.Exists(path2))
                {
                    FileStream file = new FileStream(path2, FileMode.CreateNew, FileAccess.Write);
                    StreamWriter stream = new StreamWriter(file);
                    stream.Write("");
                    stream.Close();
                    file.Close();
                    if (!Directory.Exists(path3))
                    {
                        FileStream file2 = new FileStream(path3, FileMode.CreateNew, FileAccess.Write);
                        StreamWriter stream2 = new StreamWriter(file2);

                        stream2.Write("");
                        stream2.Close();
                        file2.Close();
                        KontrolcuTimer.Enabled = true;
                    }
                }
            }
            */
        }

        private void KontrolcuTimer_Tick(object sender, EventArgs e)
        {
            int lbl =int.Parse(label3.Text);
           
            string txtBox = textBox1.Text;
            string str;
            ArrayList ayi2 = new ArrayList();
            ArrayList array = new ArrayList();
            FileStream file = new FileStream(path2, FileMode.Open, FileAccess.Read);
            StreamReader stream = new StreamReader(file);
            if (Application.OpenForms["Form2"]!=null || Application.OpenForms["Form4"] != null)
            {
                stream.Close();
                file.Close();
            }
            else if(Application.OpenForms["Form2"] == null && Application.OpenForms["Form4"] == null)
            {
                while ((str = stream.ReadLine()) != null)
                {
                    array.Add(str);

                }



                for (int i = 0; i < array.Count; i++)
                {

                    ayi2.AddRange(array[i].ToString().Split(' '));
                    if (ayi2[1].ToString() == txtBox)
                    {

                        textBox1.Text = "";
                        dataGridView1.Rows.Add("1", ayi2[1].ToString(), ayi2[0].ToString().Replace(">", " "), ayi2[4].ToString());

                        lbl = lbl + Convert.ToInt32(ayi2[4]);
                        label3.Text = lbl.ToString();
                        array.Clear();
                    }
                    else if (ayi2[1].ToString() != txtBox)
                    {

                        ayi2.Clear();
                    }




                }
            }
           

               

            
          
        }
        public static string OdemeMiktari="";

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            int cel = dataGridView1.Rows[1].Cells.Count;
            OdemeMiktari = label3.Text;
            Form5 form5 = new Form5();
            form5.Show();
            form5.BringToFront();
            label3.Text = "0";
            
            FileStream file = new FileStream(path3,FileMode.Append,FileAccess.Write);
            StreamWriter stream = new StreamWriter(file);
            for (int i = 0; i<dataGridView1.Rows.Count; i++)
            {
                for (int k = 0; k < cel ; k++)
                {
                    if (dataGridView1.Rows[i].Cells[k].Value==null)
                    {
                        dataGridView1.Rows[i].Cells[k].Value = "null";
                        break;
                    }
              
                    if (k==3)
                    {
                        stream.Write(dataGridView1.Rows[i].Cells[k].Value.ToString() + "*"+DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year+"-"+DateTime.Now.Hour+":"+DateTime.Now.Minute+":"+DateTime.Now.Second + Environment.NewLine);
                    }
                    else if (k==2)
                    {
                        stream.Write(dataGridView1.Rows[i].Cells[k].Value.ToString()+ " "+"*");
                    }
                    else
                    {
                        stream.Write(dataGridView1.Rows[i].Cells[k].Value.ToString() + "*");
                    }
                }
               
            }
            dataGridView1.Rows.Clear();
            stream.Close();
            file.Close();
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
          /*  if (e.KeyChar == (char)Keys.F5)
            {
                MessageBox.Show("f5");

            }*/
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.BringToFront();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
        }
    }
}
