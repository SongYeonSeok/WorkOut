using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkOut
{
    public partial class frmHeader : Form
    {
        public frmHeader()
        {
            InitializeComponent();
        }

        //---------------------- 0. 변수 선언 및 초기화 ----------------------------
        Socket sock = null;
        TcpListener listen = null;
        List<TcpEx> tcp = new List<TcpEx>();    // TcpClient type의 제네릭 List Object 선언

        Thread threadServer = null;
        Thread threadread = null;

        //-----------------------1. 필요한 함수 선언 --------------------------------

        delegate void CB1(string s);

        void AddText(string str)
        {
            if(textBox1.InvokeRequired)
            {
                CB1 cb = new CB1(AddText);
                object[] obj = { str };
                Invoke(cb, obj);
            }
            else
            {
                textBox1.Text += str;
            }
        }

        void AddList(string str)
        {
            if(statusStrip1.InvokeRequired)
            {
                CB1 cb = new CB1(AddList);
                Invoke(cb, new object[] { str });
            }
            else
            {
                ClientList.DropDownItems.Add(str);
            }
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


        
        //-----------------------------2. 서버 스타트 및 연결 --------------------------------------


        private void pmnuConnect_Click(object sender, EventArgs e)
        {
            frmConnect dlg = new frmConnect();
            string ConnectIP = "", ConnectPort = "", CID = "";
            if (dlg.DialogResult == DialogResult.OK)
            {
                ConnectIP = dlg.tbConnectIP.Text;
                ConnectPort = dlg.tbConnectPort.Text;
                CID = dlg.tbID.Text;
            }

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if(sock != null)
                {
                    if (MessageBox.Show("연결을 다시 수립하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    sock.Close();
                }

                byte[] buf = new byte[100];
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(ConnectIP, int.Parse(ConnectPort));

                int n = sock.Receive(buf);
                string myIP = Encoding.Default.GetString(buf, 0, n).Split(':')[1];
                AddText($"Return Message : {myIP}\r\n");

                n = sock.Receive(buf);      // 최종 수락/거부 통보
                string sRet = Encoding.Default.GetString(buf, 0, n).Split(':')[0];
                if(sRet == "REJECT")
                {
                    AddText("서버로부터 접속이 거부되었습니다.\r\n");
                    return;
                }
                AddText("서버와 접속되었습니다.\r\n");
                threadClient = new Thread(ClientProcess);
                threadClient.Start();
                textBox1.Text = "";
            }
        }

        Thread threadClient = null;
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

        void InitServer()
        {
            if (listen != null) listen.Stop();      // 기존에 수행되고 있는 리스너를 중지
            frmConnect dlg = new frmConnect();
            int HeaderPort = int.Parse(dlg.tbServerPort.Text);
            listen = new TcpListener(HeaderPort);
            listen.Start();

            if (threadServer != null) threadServer.Abort();
            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            if (threadread != null) threadread.Abort();
            threadread = new Thread(ReadProcess);
            threadread.Start();

        }

        void ServerProcess()
        {
            byte[] buf = new byte[100];
            while(true)
            {
                if(listen.Pending())
                {
                    TcpClient tp = listen.AcceptTcpClient();        // AcceptTcpClient() : Blocking 함수
                    tp.Client.Send(Encoding.Default.GetBytes($"REQ:{tp.Client.RemoteEndPoint.ToString()}"));
                    int n = tp.Client.Receive(buf);
                    string sId = Encoding.Default.GetString(buf, 0, n).Split(':')[1];   // NAM:name
                                                                                        // 
                    tp.Client.Send(Encoding.Default.GetBytes($"ACCEPT:접속이 허가되었습니다\r\n"));
                    tcp.Add(new TcpEx(tp, sId));     //     Add : List object의 method
                    AddText($"{sId}({tp.Client.RemoteEndPoint.ToString()})로부터 접속되었습니다.\r\n");

                    if (InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate () { ClientList.DropDownItems.Add(sId); }));
                    }

                }
            }
        }

        void ReadProcess()
        {
            byte[] buf = new byte[1024];
            while(true)
            {
                for(int i=0;i<tcp.Count;i++)
                {
                    if(tcp[i].tp.Available >0)
                    {
                        int n = tcp[i].tp.Client.Receive(buf);
                        AddText(Encoding.Default.GetString(buf, 0, n));
                    }
                }
                Thread.Sleep(100);
            }
        }

        //---------------------3. 프로그램 종료 시에 서버와 리스너, 스레드 닫기--------------------------------


        void CloseServer()
        {
            if (listen != null) listen.Stop();  // 기존에 수행되고 있는 리스너를 중지
            if (threadServer != null) threadServer.Abort();
            if (threadread != null) threadread.Abort();
        }

        /// <summary>
        /// 폼 닫을 때, 서버와 스레드 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHeader_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseServer();
            // if (threadClient != null) threadClient.Abort();
        }
        //--------------------------------------------------------------
    }
}
