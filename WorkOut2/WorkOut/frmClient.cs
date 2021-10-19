using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
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

            //datagrid에 지금까지 운동했던 내용을 보여줌
            Encoding enc;
            enc = Encoding.UTF8;

            byte[] barrOrg = File.ReadAllBytes(address);
            byte[] barr = Encoding.Convert(enc, Encoding.Default, barrOrg);
            string str = Encoding.Default.GetString(barr);

            string[] sarr = str.Split('\n');                //줄 별로 array만듬
            string[] sa1 = sarr[0].Trim().Split(',');       //줄 안에서 ,단위로 나눔

            for (int i = 0; i < sa1.Length; i++)
            {
                dbGrid.Columns.Add(sa1[i], sa1[i]);
            }
            for (int j = 1; j < sarr.Length; j++)
            {
                sa1 = sarr[j].Trim().Split(',');
                dbGrid.Rows.Add(sa1);
            }

            string[] name = new string[512];

            int limit = 5;


            // sql 연결
            sqlConn.ConnectionString = ConnString;
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;


            for (int i = 0; i < limit; i++)
            {
                name[i] = GetString($"SELECT Name FROM WorkOutMem where Code = {i + 2}");
            }
            Mnu1.Text = name[0];
            Mnu2.Text = name[1];
            Mnu3.Text = name[2];
            Mnu4.Text = name[3];
            Mnu5.Text = name[4];

            //InitServer();

            // 글씨 속성


        }


        public string GetString(string sql)     // 단일 데이터 (1st record  1st field)
        {       //select name from users where name = "Noname"

            try
            {
                sqlCmd.CommandText = sql;
                return sqlCmd.ExecuteScalar().ToString();

            }

            catch (Exception e1)
            {
                return e1.Message;
            }
        }



        SqlConnection sqlConn = new SqlConnection();    //Application Program과 DB를 연결시켜주는 도로 
        SqlCommand sqlCmd = new SqlCommand();           //그 도로를 타고 가는 자동차
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Desktop\WorkOut1-master\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        
        string path = @"C:\Users\KOSTA\Desktop\WorkOut1-master\workoutprogram.csv";
        string address = @"C:\Users\KOSTA\Desktop\WorkOut1-master\workoutprogram.csv";



        /// <summary>
        /// <calculation 함수>
        /// 클릭 이벤트를 실행할 때 
        /// frmset, frminfo를 실행시키고 값을 받아와서
        /// str에 값을 넣어준다.
        /// </summary>
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
                        if(textBox1.Text=="")
                        {
                            textBox1.Text += $"DATE,DAY,TYPE,SETS,WEIGHT,REPS,Total Reps,Volume\r\n";
                        }
                    }
                    
                    volume[i] = rep[i] * weight[i];
                    for (int j = 0; j < i + 1; j++)
                    {
                        trep[i] += rep[j];
                        Volume[i] += volume[j];
                    }
                    textBox1.Text += $"{f2.tbBoxDate.Text},{f2.tbBoxDoW.Text},{ExerType},{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


                }
                //textBox1.Text += $"\r\n";

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


        string SetText = "";

        private void MnuSohp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuSohp.Text);
        }
        private void MnuSarere_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuSarere.Text);
        }
        private void MnuRearDelt_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuRearDelt.Text);
        }
        private void MnuOhp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuOhp.Text);
        }
        private void MnuSquat_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuSquat.Text);
        }
        private void MnuLegExtention_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuLegExtention.Text);
        }
        private void MnuLegCurl_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuLegCurl.Text);
        }
        private void MnuDumbelCurl_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuDumbelCurl.Text);
        }
        private void MnuBarbelCurl_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuBarbelCurl.Text);
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




        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Position", "LocationX", $"{Location.X}");
            ini.WriteString("Position", "LocationY", $"{Location.Y}");

            File.AppendAllText(address, SetText,Encoding.UTF8);

            MnuClientIndex.Visible = false;
            MnuSend.Visible = false;

            CloseServer();
        }





        private void btnOk_Click(object sender, EventArgs e)
        {
            //btnOk.DialogResult = DialogResult.OK;
        }
        private void bicepsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dbGrid.Rows.Clear();
            //dbGrid.Columns.Clear();

            string day = dateTimePicker1.Value.ToString("yyyy.MM.dd");

            Encoding ec =  Encoding.UTF8 ;
            StreamReader sr = new StreamReader(address, ec, true);

            while (true)
            {
                string str = sr.ReadLine();
                if (str == null) break;
                string[] sarr = str.Split(',');

                
                for (int i = 0; i < sarr.Length; i++)
                {
                    if (sarr[i]==day)
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

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /*
        class TcpEx
        {
            public TcpClient tp;
            public string id;
            public TcpEx(TcpClient t, string s)
            { tp = t; id = s; }
        };
        List<TcpEx> tcp = new List<TcpEx>();      //TcpClient type의 제네릭 List Object 선언
        */

        Socket sock = null;
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadRead = null;

        public string ConnectIP = "127.0.0.1";
        public int ConnectPort = 9000;
        public int serverPort = 9000;
        int CP1 = 9001;
        int CP2 = 9002;
        int CP3 = 9003;
        int CP4 = 9004;
        int CP5 = 9005;

        
        delegate void CB1(string s);
        void AddText(string str)
        {
            if (tbChat.InvokeRequired)
            {
                CB1 cb = new CB1(AddText);
                Invoke(cb, new object[] { str });
            }
            else
            {
                tbChat2.Text += str;
            }
        }

        /*
        void InitServer()
        {
            if (listen != null) listen.Stop();
            listen = new TcpListener(serverPort);
            listen.Start();

            if (threadRead != null) threadServer.Abort(); //thread가 돌아가고있었다면 thread 중지
            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            if (threadRead != null) threadRead.Abort();
            threadRead = new Thread(ReadProcess);
            threadRead.Start();
        }
        */
        void CloseServer()
        {
            //timer1.Stop();
            if (listen != null) listen.Stop();          //기존에 수행되고있는 listener를 중지 
            if (threadServer != null) threadServer.Abort(); //thread가 돌아가고있었다면 thread 중지
            if (threadRead != null) threadRead.Abort(); //thread가 돌아가고있었다면 thread 중지
            if (threadClient != null) threadClient.Abort();
        }
        /*
        void ServerProcess()
        {
            byte[] buf = new byte[100];
            while(true)
            {
                if(listen.Pending())
                {
                    TcpClient tp = listen.AcceptTcpClient();
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            TcpClient tp = listen.AcceptTcpClient();

            byte[] buf = new byte[100];
            while (true)
            {
                for(int i = 0; i<tcp.Count;i++)
                {
                    if (tcp[i].tp.Available>0)
                    {
                        int n = tcp[i].tp.Client.Receive(buf);
                        AddText(Encoding.Default.GetString(buf, 0, n));
                    }
                }
                Thread.Sleep(100);
            }
        }*/
        Thread threadClient = null;
        private void Mnu1_Click(object sender, EventArgs e)
        {

            Mnu1.Checked = true;
            Mnu2.Checked = false;
            Mnu3.Checked = false;
            Mnu4.Checked = false;
            Mnu5.Checked = false;


            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ConnectIP, CP1);
            tbChat2.Text += "Connection with Header OK. \r\n";

            threadClient = new Thread(ClientProcess);
            threadClient.Start();

        }

        private void Mnu2_Click(object sender, EventArgs e)
        {
            Mnu1.Checked = false;
            Mnu2.Checked = true;
            Mnu3.Checked = false;
            Mnu4.Checked = false;
            Mnu5.Checked = false;

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ConnectIP, CP2);
            tbChat2.Text += "Connection with Header OK. \r\n";

            threadClient = new Thread(ClientProcess);
            threadClient.Start();
        }

        private void Mnu3_Click(object sender, EventArgs e)
        {
            Mnu1.Checked = false;
            Mnu2.Checked = false;
            Mnu3.Checked = true;
            Mnu4.Checked = false;
            Mnu5.Checked = false;

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ConnectIP, CP3);
            tbChat2.Text += "Connection with Header OK. \r\n";

            threadClient = new Thread(ClientProcess);
            threadClient.Start();
        }

        private void Mnu4_Click(object sender, EventArgs e)
        {
            Mnu1.Checked = false;
            Mnu2.Checked = false;
            Mnu3.Checked = false;
            Mnu4.Checked = true;
            Mnu5.Checked = false;

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ConnectIP, CP4);
            tbChat2.Text += "Connection with Header OK. \r\n";

            threadClient = new Thread(ClientProcess);
            threadClient.Start();
        }

        private void Mnu5_Click(object sender, EventArgs e)
        {
            Mnu1.Checked = false;
            Mnu2.Checked = false;
            Mnu3.Checked = false;
            Mnu4.Checked = false;
            Mnu5.Checked = true;

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ConnectIP, CP5);
            tbChat2.Text += "Connection with Header OK. \r\n";

            threadClient = new Thread(ClientProcess);
            threadClient.Start();
        }

        void ClientProcess()
        {
            byte[] buf = new byte[1024];
            while(true)
            {
                if(sock.Available > 0)
                {
                    int n = sock.Receive(buf);
                    AddText(Encoding.Default.GetString(buf, 0, n));
                }
                Thread.Sleep(100);
            }
        }

        private void tbChat_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (sock != null)
                {
                    string str;
                    str = tbChat.Text;
                    str += "\r\n";

                    string str2 = str;
                    if (Mnu1.Checked == true) str = "[수신 : SONG]" + str;
                    if (Mnu2.Checked == true) str = "[수신 : KIM]" + str;
                    if (Mnu3.Checked == true) str = "[수신 : LEE]" + str;
                    if (Mnu4.Checked == true) str = "[수신 : PARK]" + str;
                    if (Mnu5.Checked == true) str = "[수신 : NA]" + str;

                    sock.Send(Encoding.Default.GetBytes(str));
                    tbChat2.Text += "[송신 : 본인] " + str2;
                    tbChat.Text = "";
                }
            }
            
        }


        //-------------------------------------------------------------------------------------
        private void dbGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void MnuClientIndex_Click(object sender, EventArgs e)
        {

        }

        private void sendToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
