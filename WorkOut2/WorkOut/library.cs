using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace WorkOut
{
    class library
    {
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
                catch (Exception e)
                {
                    return null;
                }

            }

            public void Close()
            {
                cmd.Dispose();
                conn.Close();
            }
            public string GetString(string sql)     // 단일 데이터 (1st record  1st field)
            {       //select name from users where name = "Noname"
                try
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteScalar().ToString();

                }

                catch (Exception e1)
                {
                    return e1.Message;
                }
            }

        }




    }


}
