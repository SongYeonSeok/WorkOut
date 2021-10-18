using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace myLibrary
{
    public partial class frminput: Form
    {
        public frminput()
        {
            InitializeComponent();
        }
        public frminput(string str)
        {
            InitializeComponent();
            Prompt.Text = str;
            Prompt.Visible = true;
        }
        public frminput(int i)
        {
            InitializeComponent();
            Prompt.Text = i.ToString();
            Prompt.Visible = true;
        }
        public string retStr="";
        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                retStr = tbInput.Text;
                Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                retStr = "";

                Close();
            }
            
        }

        




        public class iniClass
        {
            string iniPath;

            [DllImport("kernel32.dll")]
            static extern int GetPrivateProfileString(string sec, string key, string def, StringBuilder buf, int bsize, string path);

            [DllImport("kernel32.dll")]
            static extern bool WritePrivateProfileString(string sec, string key, string val, string path);

            public iniClass(string path)
            {
                iniPath = path;
            }

            public string GetString(string sec, string key)
            {
                StringBuilder buf = new StringBuilder(512);

                GetPrivateProfileString(sec, key, " ", buf, 512, iniPath);
                return buf.ToString();
            }

            public string GetString(string sec, string key, string def)
            {
                StringBuilder buf = new StringBuilder(512);

                GetPrivateProfileString(sec, key, def, buf, 512, iniPath);
                return buf.ToString();
            }

            public bool WriteString(string sec, string key, string val)
            {
                return WritePrivateProfileString(sec, key, val, iniPath);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        
    }

    public static class mylib
    {

        //GetToken함수_ex) GetToken(1,"a,b,c,d",',')은 a 출력

        public static string GetToken(int n, string str, char d)
        {
            string[] sarr = str.Split(d);
            if (n < sarr.Length) return sarr[n];
            return "";
        }
        public static string GetTokenEX(int n, string str, char d)
        {
            int i, j, k, n1, n2;
            for (i = j = k = n1 = n2 = 0; i < str.Length; i++)
            {
                if (str[i] == d) k++;
                if (k == n) n1 = i;
                if (k == n + 1) n2 = i;
            }
            if (n1 == 0) return "";
            if (n2 == 0) n2 = str.Length + 1;

            return str.Substring(n1, n2 - 1 - n1);
        }
        public static string GetInput(string str)
        {
            frminput dlg = new frminput(str);
            dlg.ShowDialog();
            return dlg.retStr;
        }


    }

    public class iniFile
    {
        [DllImport("kernel32.dll")]
        static extern int GetPrivateProfileString(string s, string k, string d, StringBuilder b, int n, string p);
        [DllImport("kernel32.dll")]
        static extern bool WritePrivateProfileString(string s, string k, string v, string p);

        public string fPath;
        public iniFile(string str)
        {
            fPath = str;
        }
        public string GetString(string sec, string key, string def = "")
        {
            StringBuilder buf = new StringBuilder(512);
            GetPrivateProfileString(sec, key, def, buf, 512, fPath);
            return buf.ToString();
        }
        public bool WriteString(string sec, string key, string val)
        {
            return WritePrivateProfileString(sec, key, val, fPath);
        }

    }

    public class SqlDB
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string ConnString = null;

        public SqlDB(string str)
        {
            ConnString = str;
            conn = new SqlConnection(ConnString);
            conn.Open();
            cmd = new SqlCommand("", conn);
        }

        public object Run(string sql)
        {
            try
            {
                char[] ca = { ' ', '\t', '\r', '\n' };
                cmd.CommandText = sql;
                //"Select * from table"
                string s = sql.Trim().Split(ca)[0].ToLower();
                if (s == "select")
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();             //2차원 Array와 비슷한 놈 
                    dt.Load(sdr);
                    sdr.Close();
                    return dt;
                }
                else
                {
                    return cmd.ExecuteNonQuery();   //int
                }

            }
            catch(Exception e)
            {
                return null;
            }

        }

        public string GetString(string sql)     // 단일 데이터 (1st record  1st field)
        {       //select name from users where name = "Noname"
            try
            {
                cmd.CommandText = sql;
                return cmd.ExecuteScalar().ToString();

            }

            catch(Exception e1)
            {
                return e1.Message;
            }
        }

    }




}
