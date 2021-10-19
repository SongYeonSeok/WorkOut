using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace WorkOut
{
    // 일종의 서버 역할
    public partial class frmHeader : Form
    {
        SqlConnection sqlConn = new SqlConnection();    //Application Program과 DB를 연결시켜주는 도로 
        SqlCommand sqlCmd = new SqlCommand();           //그 도로를 타고 가는 자동차
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Desktop\WorkOut1-master\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";


        public frmHeader()
        {
            InitializeComponent();
        }

        delegate void CB1(string str);      // CB : Call Back
        void AddText(string str)
        {
            if (textBox1.InvokeRequired) // 대리 호출이 필요한가?
            {
                CB1 cb = new CB1(AddText);
                Invoke(cb, new object[] { str });
            }
            else tbText.Text += str;   // if에 해당되는 조건이 있을 때, 바로 끝내기 위해 else를 지정함
        }
        class TcpEx
        {
            public TcpClient tp;
            public string id;
            public TcpEx(TcpClient t, string s)
            {
                tp = t;
                id = s;
            }
        }
        //----------------------------------------------------
        Socket sock = null;
        TcpClient tcp = null;
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadRead = null;
        //----------------------------------------------------

        string ConnectIP = "127.0.0.1";
        int ServerPort = 9000;      // default
        int ConnectPort = 9000;     // default
        int CP1 = 9001;             // Client 1 
        int CP2 = 9002;             // Client 2
        int CP3 = 9003;             // Client 3
        int CP4 = 9004;             // Client 4
        int CP5 = 9005;             // Client 5

        //------------------------------------------------------
        string[] name = new string[512];
        private void frmHeader_Load(object sender, EventArgs e)
        {
            int limit = 5;

            // sql 연결하기
            sqlConn.ConnectionString = ConnString;
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;

            for (int i = 0; i < limit; i++)
            {
                name[i] = GetString($"SELECT Name FROM WorkOutMem where Code = {i + 2}");
                ClientList.DropDownItems.Add(name[i]);
            }



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

        //------------------------------------------------------

        /// <summary>
        /// 네트워크 연결하기.
        /// Header(Server) -> Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pmnuServer_Click(object sender, EventArgs e)
        {

            frmHeaderConnect dlg = new frmHeaderConnect();

            // serverPort, connectPort 지정하기

            if (ClientList.Text == name[0])
            {
                dlg.tbConnectPort.Text = CP1.ToString();
                dlg.tbServerPort.Text = CP1.ToString();
            }
            if (ClientList.Text == name[1])
            {
                dlg.tbConnectPort.Text = CP2.ToString();
                dlg.tbServerPort.Text = CP2.ToString();
            }
            if (ClientList.Text == name[2])
            {
                dlg.tbConnectPort.Text = CP3.ToString();
                dlg.tbServerPort.Text = CP3.ToString();
            }
            if (ClientList.Text == name[3])
            {
                dlg.tbConnectPort.Text = CP4.ToString();
                dlg.tbServerPort.Text = CP4.ToString();
            }
            if (ClientList.Text == name[4])
            {
                dlg.tbConnectPort.Text = CP5.ToString();
                dlg.tbServerPort.Text = CP5.ToString();
            }


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ConnectIP = dlg.tbConnectIP.Text;
                ServerPort = int.Parse(dlg.tbServerPort.Text);
                ConnectPort = int.Parse(dlg.tbConnectPort.Text);

                // --------------서버 시작------------------------------
                if(listen != null)
                {
                    DialogResult ret = MessageBox.Show("현재 연결이 끊어집니다.\r\n계속 하시겠습니까?", "", MessageBoxButtons.YesNo);
                    if (ret == DialogResult.No) return;
                    listen.Stop();  //현재 오픈되어있는 리스너 중지
                    listen = null;
                    threadServer.Abort();
                    if (threadRead != null && threadRead.IsAlive) threadRead.Abort();
                    if (tcp != null) tcp.Close();
                }
                listen = new TcpListener(ServerPort);
                listen.Start();

                threadServer = new Thread(ServerProcess);
                threadServer.Start();

                threadRead = new Thread(ReadProcess);

                AddText($"Server Port [{ServerPort}] started. \r\n");
                //------------------------------------------------------
            }
            
        }



        //--------------------------------------------------
        void ServerProcess()        // call back, thread 구성을 위한 작업
        {
            while (true)
            {
                if (!listen.Pending())      // 현재 보류중인 요청이 있는가?
                {
                    tcp = listen.AcceptTcpClient();     // 외부로부터 연결이 올 때까지 아무것도 못함. (Blocking Mode)
                    threadRead.Start();
                    break;
                }
                Thread.Sleep(100);
            }
        }


        void ReadProcess()      // 소속 : ReadThread // 호출할 때 invoke 문제를 해결하기 위해
        {
            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while(true)
            {

                if (ns.DataAvailable)
                {
                    int n = ns.Read(bArr, 0, 512);
                    AddText(Encoding.Default.GetString(bArr, 0, n));        // 인코딩 과정이 필요하다.
                }

                Thread.Sleep(100);
            }
        }


        //---------------------------------------------------

        private void frmHeader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadServer != null) threadServer.Abort();
            if (threadRead != null) threadRead.Abort();
            if (listen != null) listen.Stop();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ClientList.Text = e.ClickedItem.Text;
        }

        private void tbChat_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(tcp.Client != null)
                {
                    string str;
                    str = tbChat.Text;
                    str += "\r\n";

                    tcp.Client.Send(Encoding.Default.GetBytes("[수신 : 관리자]" + str));
                    tbText.Text += "[송신 : 본인] " + str;
                    tbChat.Text = "";
                }
            }
        }




        //--------------------------------------------------
    }
}
