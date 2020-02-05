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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        string path =Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BarkodOkuyucu\satis.txt";
        private void Form7_Load(object sender, EventArgs e)
        {
            /*  ArrayList duzdeger = new ArrayList();
              ArrayList deger2 = new ArrayList();
              string satir;
              FileStream file = new FileStream(path,FileMode.Open,FileAccess.Read);
              StreamReader stream = new StreamReader(file);

              while ((satir = stream.ReadLine()) != null)
              {
                  duzdeger.Add(satir);
              }
              for (int i = 0; i < duzdeger.Count; i++)
              {
                  deger2.AddRange(duzdeger[i].ToString().Split(' '));
              }
              */
            string[] lines = File.ReadAllLines(path);
            string[] values;
           
            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('*');
                string[] row = new string[values.Length];

                for (int d = 0; d < values.Length; d++)
                {
                    row[d] = values[d].Trim();
                }
                dataGridView1.Rows.Add(row);
            }
           
        }
    }
}
