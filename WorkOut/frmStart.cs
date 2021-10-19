using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myLibrary;
using static myLibrary.frminput;

namespace WorkOut
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        
        iniFile ini = new iniFile(".\\WorkOut.ini");


        private void form1_Load(object sender, EventArgs e)
        {
            int x = int.Parse(ini.GetString("Position", "LocationX", "0"));
            int y = int.Parse(ini.GetString("Position", "LocationY", "0"));
            Location = new Point(x, y);
            
        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Position", "LocationX", $"{Location.X}");
            ini.WriteString("Position", "LocationY", $"{Location.Y}");

        }

        SqlConnection sqlConn = new SqlConnection();    //Application Program과 DB를 연결시켜주는 도로 
        SqlCommand sqlCmd = new SqlCommand();           //그 도로를 타고 가는 자동차
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\조석훈\source\repos\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        string address = "C:\\Users\\조석훈\\source\\repos\\C#\\workoutprogram.csv";




        private void MnuSohp_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0 ;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);
                
            }
            frmInfo f2 = new frmInfo(10,5);
            for (int i =0; i<set; i++)
            {
                
                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }

            for (int i=0;i<set;i++)
            {
                if(i==0)
                {
                    if(textBox1.Text=="") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";
                    textBox1.Text += $"S_OHP,WEIGHT,REPS,Total Reps,Volume\r\n";
                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i+1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";
                

            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);





            //string[] weight = null;
            //string[] Reps = null;
            //int[] total=null;

            //for (int j=0;j<set;j++)
            //{
            //    weight[j] = TbWeight.Text;
            //    Reps[j] = TbReps.Text;
            //    total[j] = (int.Parse(weight[j])) * (int.Parse(Reps[j]));
            //    textBox1.Text = $"{weight[j]}  {Reps[j]}  {total[j]} \r\n";
            //}




        }
        private void MnuSarere_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";
                    textBox1.Text += $"Sarere,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuRearDelt_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                    textBox1.Text += $"RearDelt,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                volume[i] = rep[i] * weight[i];
                for (int j=0;j<i+1;j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuOhp_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                    textBox1.Text += $"OHP,WEIGHT,REPS,Total Reps,Volume\r\n ";

                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuSquat_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                    textBox1.Text += $"SQUAT,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuLegExtention_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                    textBox1.Text += $"LegExt,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuLegCurl_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                    textBox1.Text += $"LegCurl,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }


        private void dumbelCurlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                    textBox1.Text += $"DumCurl,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void barbelCurlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            frmSet f3 = new frmSet(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            frmInfo f2 = new frmInfo(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    if (textBox1.Text == "") textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                    textBox1.Text += $"BarCurl,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                volume[i] = rep[i] * weight[i];
                for (int j = 0; j < i + 1; j++)
                {
                    trep[i] += rep[j];
                    Volume[i] += volume[j];
                }
                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }











        private void btnOk_Click(object sender, EventArgs e)
        {
            //btnOk.DialogResult = DialogResult.OK;
        }
        private void bicepsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
