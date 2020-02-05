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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BarkodOkuyucu\veri1.txt";

        private void button1_Click(object sender, EventArgs e)
        {
            string txtBox = textBox1.Text;
            string str;
           

            ArrayList ayi2 = new ArrayList();
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Bu ürünü çıkartmak istediginize emin misiniz?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult==DialogResult.Yes)
            {
                ArrayList array = new ArrayList();
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader stream = new StreamReader(file);

                while ((str=stream.ReadLine())!=null)
                {
                    array.Add(str);
                    
                }
                    
                
                stream.Close();
                file.Close();
                for (int i = 0; i < array.Count; i++)
                {
                   
                    ayi2.AddRange(array[i].ToString().Split(' '));
                    if (ayi2[1].ToString()==txtBox)
                    {
                        MessageBox.Show("Bulundu Kaldırılıyor...");
                        
                    }
                    else if (ayi2[1].ToString()!=txtBox)
                    {
                      
                        ayi2.Clear();
                    }
                   
                    
                    

                }

            }
            else if(dialogResult==DialogResult.No)
            {
                MessageBox.Show("işlem iptal ediliyor...");
            }
        }
    }
}
