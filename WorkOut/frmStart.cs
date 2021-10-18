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
        /// 클릭 이벤트를 실행할 때, frmset, frminfo를 실행시키고 값을 받아와서
        /// str에 값을 넣어준다.
        /// </summary>
        /// <param name="ExerType"></param>
        /// <returns></returns>
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
                        if (textBox1.Text == "") textBox1.Text += $"DATE,DAY,TYPE,SETS,WEIGHT,REPS,Total Reps,Volume\r\n";

                    }

                    volume[i] = rep[i] * weight[i];
                    for (int j = 0; j < i + 1; j++)
                    {
                        trep[i] += rep[j];
                        Volume[i] += volume[j];
                    }
                    textBox1.Text += $"{f2.tbBoxDate.Text},{f2.tbBoxDoW.Text},{ExerType},{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


                }
                textBox1.Text += $"\r\n";

                str = textBox1.Text;
                return str;

            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
                return str;
            }
        }
        
        /// <summary>
        /// ca : white space array
        /// </summary>
        char[] ca = { ' ', '\t', '\r', '\n' };  // white space array


        /// <summary>
        /// sql 실행문
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int RunSql(string sql)  // 모든 SQL 명령어를 처리
        {  // ex)  select * from          student where code < 4 / SELECT  /Select  / selEct
            sqlCmd.CommandText = sql;

            try
            {
                string sCmd = sql.Trim().Substring(0, 6); //mylib.GetToken(0, sql.Trim(), ' ');
                if (sCmd.ToLower() == "select")
                {
                    int n1 = sql.ToLower().IndexOf("from");
                    string s1 = sql.Substring(n1 + 4).Trim();    //student  where code < 4 

                    SqlDataReader sdr = sqlCmd.ExecuteReader();

                    dbGrid.Rows.Clear();
                    dbGrid.Columns.Clear();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        string s = sdr.GetName(i);
                        dbGrid.Columns.Add(s, s);
                    }
                    for (int i = 0; sdr.Read(); i++)
                    {
                        int rIdx = dbGrid.Rows.Add();
                        for (int j = 0; j < sdr.FieldCount; j++)
                        {
                            object obj = sdr.GetValue(j);
                            dbGrid.Rows[rIdx].Cells[j].Value = obj;
                        }
                    }
                    sdr.Close();
                    return 0;
                }
                else
                {
                    return sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message); return -1;
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

            // csv 파일 불러오기
            Encoding enc = Encoding.UTF8;
            // StreamReader sr = new StreamReader(address, enc, true);     // 한번 다시 해 보기

            byte[] bArrOrg = File.ReadAllBytes(address);
            byte[] bArr = Encoding.Convert(enc, Encoding.Default, bArrOrg);     // Raw Data
            string str = Encoding.Default.GetString(bArr);  // All Text
            string[] sArr = str.Split('\n');

            string[] sa1 = sArr[0].Trim().Split(',');
            for (int i = 0; i < sa1.Length; i++) dbGrid.Columns.Add(sa1[i], sa1[i]);
            for(int k=1;k<sArr.Length;k++)
            {
                sa1 = sArr[k].Trim().Split(',');
                dbGrid.Rows.Add(sa1);
            }
            
        }



        SqlConnection sqlConn = new SqlConnection();    //Application Program과 DB를 연결시켜주는 도로 
        SqlCommand sqlCmd = new SqlCommand();           //그 도로를 타고 가는 자동차
        
        
        // sql 주소(각자 다름)
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Desktop\WorkOut1-master\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        /// <summary>
        /// 저장할 주소/workoutprogram.csv 파일
        /// </summary>
        
        string address = "C:\\Users\\KOSTA\\Desktop\\WorkOut1-master\\workoutprogram.csv";

        string SetText = "";

        

        /// <summary>
        /// 운동 종류 // 변경한 부분 : try ~ catch
        /// // x를 클릭하면 운동족목을 재설정하시겠습니까?라는 문구와 함께 버튼 YES.NO
        /// Yes 선택 -> frmstart로 돌아감
        /// No 선택 -> 다시 frminfo 열어줌
        /// </summary>
        private void MnuSohp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuSohp.Text);
        }
        private void MnuSarere_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuSarere.Text);
        }
        private void MnuRearDelt_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuRearDelt.Text);
        }
        private void MnuOhp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuOhp.Text);
        }
        private void MnuSquat_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuSquat.Text);
        }
        private void MnuLegExtention_Click(object sender, EventArgs e)
        {

            SetText = calculation(MnuLegExtention.Text);

        }
        private void MnuLegCurl_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuLegCurl.Text);
        }
        private void MnuDumbelCurl_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuDumbelCurl.Text);
        }
        private void MnuBarbelCurl_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuBarbelCurl.Text);
        }
        private void MnuBenchpress_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuBenchpress.Text);
        }
        private void MnuDumbelpress_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuDumbelpress.Text);
        }
        private void MnuInclinebenchpress_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuInclinebenchpress.Text);
        }
        private void MnuDips_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuDips.Text);
        }
        private void MnuFly_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuFly.Text);
        }
        private void MnuPullUp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuPullUp.Text);
        }
        private void MnuRatpulldown_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuRatpulldown.Text);
        }
        private void Mnudumbelrow_Click(object sender, EventArgs e)
        {
            SetText = calculation(Mnudumbelrow.Text);
        }
        private void MnuRow_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuRow.Text);
        }
        private void MnuDeadlift_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuDeadlift.Text);
        }
        private void MnuBarbelrow_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuBarbelrow.Text);
        }
        private void MnuArmpulldown_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuArmpulldown.Text);
        }
        private void MnuCablepushdown_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuCablepushdown.Text);
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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = DateTimePicker1.Value;
            string dateStr = dt1.ToString("yyyy.MM.dd");

            Encoding ec = Encoding.UTF8;
            StreamReader sr = new StreamReader(address, ec, true);

            while(true)
            {
                string str = sr.ReadLine();     // 한줄 씩 읽어온다.
                if (str == null) break;         // 읽을 것이 없다면 break
                string[] sarr = str.Split(',');

                for (int i=0;i<sarr.Length;i++)
                {
                    if(sarr[i] == dateStr)
                    {
                        int indx = dbGrid.Rows.Add();       
                        for (int j=0;j<sarr.Length;j++)
                        {
                            dbGrid.Rows[indx].Cells[j].Value = sarr[j];
                        }
                    }
                }
            }
            sr.Close();




        }


    }
}
