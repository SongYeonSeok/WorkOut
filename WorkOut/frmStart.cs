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
        /// <summary>
        /// 날짜와 요일 중복 입력 여부
        /// true : 가능(처음 입력인 경우, default)
        /// false : 불가능(같은 날 두번 이상 입력한 경우)
        /// </summary>
        //private static bool IsToday = null;


        public string calculation(string ExerType)
        {
            string str = "";
            try
            {
                int sets = 0;
                int set = 0;
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
                        if (textBox1.Text == "")
                        {
                            textBox1.Text += $"{f2.tbBoxDate.Text} {f2.tbBoxDoW.Text}\r\n";

                        }
                        textBox1.Text += $"{ExerType},WEIGHT,REPS,Total Reps,Volume\r\n";
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

                str = textBox1.Text;
                return str;
                //IsToday = false;    // 오늘 날짜, 요일 중복 입력 불가능 지정 

            }
            catch (Exception e1)
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
                return str;
            }
        }


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



        SqlConnection sqlConn = new SqlConnection();    //Application Program과 DB를 연결시켜주는 도로 
        SqlCommand sqlCmd = new SqlCommand();           //그 도로를 타고 가는 자동차
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\조석훈\source\repos\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        /// <summary>
        /// 저장할 주소/workoutprogram.csv 파일
        /// </summary>
        string address = @"C:\Users\KOSTA\Desktop\WorkOut1-master\workoutprogram.csv";



        string SetText = "";
        private void MnuSohp_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuSohp.Text);
        }
        private void MnuSarere_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuSarere.Text);
        }

        private void MnuRearDelt_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuRearDelt.Text);
        }

        private void MnuOhp_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuOhp.Text);
        }

        private void MnuSquat_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuSquat.Text);
        }

        private void MnuLegExtention_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuLegExtention.Text);
        }

        private void MnuLegCurl_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuLegCurl.Text);        }


        private void MnuDumbelCurl_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuDumbelCurl.Text);
        }

        private void MnuBarbelCurl_Click(object sender, EventArgs e)
        {
            SetText += calculation(MnuBarbelCurl.Text);
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            //btnOk.DialogResult = DialogResult.OK;
        }
        private void bicepsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Position", "LocationX", $"{Location.X}");
            ini.WriteString("Position", "LocationY", $"{Location.Y}");
            File.AppendAllText(address, SetText, Encoding.UTF8);

        }
    }
}
