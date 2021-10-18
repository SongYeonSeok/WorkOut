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
        public string RunSql(string sql)  // 모든 SQL 명령어를 처리  -  조회 결과를 문자열로 반환
        {  // ex)  select * from          student where code < 4 / SELECT  /Select  / selEct
            sqlCmd.CommandText = sql;

            try
            {
                string sCmd = sql.Trim().Substring(0, 6); //mylib.GetToken(0, sql.Trim(), ' ');
                if (sCmd.ToLower() == "select")
                {
                    int n1 = sql.ToLower().IndexOf("from");
                    string s1 = sql.Substring(n1 + 4).Trim();    //student  where code < 4 
                    string CurrentTable = s1.Split(ca)[0];
                    //CurrentTable = sql.Substring(sql.ToLower().IndexOf("from") + 4).Trim().Split(ca)[0];
                    //sbLabel2.Text = CurrentTable;

                    SqlDataReader sdr = sqlCmd.ExecuteReader();

                    string sRet = sdr.GetName(0);
                    for (int i = 1; i < sdr.FieldCount; i++)
                    {
                        sRet += $",{sdr.GetName(i)}";
                    }
                    sRet += "\r\n";

                    for (int i = 0; sdr.Read(); i++)
                    {
                        sRet += sdr.GetValue(0);
                        for (int j = 1; j < sdr.FieldCount; j++)
                        {
                            sRet += $",{sdr.GetValue(j)}";
                        }
                        sRet += "\r\n";
                    }
                    sdr.Close();
                    return sRet;
                }
                else
                {
                    return $"{sqlCmd.ExecuteNonQuery()}";
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message); return e1.Message;
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
            try
            {
                SetText = calculation(MnuSohp.Text);
            }
            catch
            {
                if(MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuSarere_Click(object sender, EventArgs e)
        {
            try
            { 
                SetText = calculation(MnuSarere.Text);
            }
            catch
            {
                if(MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuRearDelt_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuRearDelt.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuOhp_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuOhp.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuSquat_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuSquat.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }

        }
        private void MnuLegExtention_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuLegExtention.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuLegCurl_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuLegCurl.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuDumbelCurl_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuDumbelCurl.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuBarbelCurl_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuBarbelCurl.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuBenchpress_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuBenchpress.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuDumbelpress_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuDumbelpress.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuInclinebenchpress_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuInclinebenchpress.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuDips_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuDips.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuFly_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuFly.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuPullUp_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuPullUp.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuRatpulldown_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuRatpulldown.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void Mnudumbelrow_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(Mnudumbelrow.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuRow_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuRow.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuDeadlift_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuDeadlift.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuBarbelrow_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuBarbelrow.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuArmpulldown_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuArmpulldown.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
        }
        private void MnuCablepushdown_Click(object sender, EventArgs e)
        {
            try
            {
                SetText = calculation(MnuCablepushdown.Text);
            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
            }
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
            string year = dt1.ToString("yyyy");
            string month = dt1.ToString("MM");
            string day = dt1.ToString("ss");
            string dateStr = dt1.ToString("yyyy.MM.dd");

            string sql = $"SELECT TYPE, SETS, WEIGHT, REPS, Total Reps, Volume FROM workoutprogram WHERE DATE == '{year}.{month}.{day}'";
            RunSql(sql);




        }


    }
}
