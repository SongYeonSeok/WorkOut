using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkOut
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }
        SqlDB sqldb = new SqlDB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\조석훈\source\repos\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = tbBoxName.Text;
            string pw = tbBoxPW.Text;

            string ret = sqldb.GetString($"select name from WorkOutMem where name = '{name}'");
            string ret2 = sqldb.GetString($"select PW from WorkOutMem where PW = '{pw}'and Name = '{name}' ");

            form1 f1 = new form1();
            

            if (name==ret)
            {
                if(pw==ret2)
                {
                    MessageBox.Show($"환영합니다 {name}님");
                    f1.ShowDialog();
                    
                }
                else if(pw!=ret2)
                {
                    MessageBox.Show("잘못된 PW입니다.");
                    
                }
            }
            else if(name!=ret)
            {
                MessageBox.Show("이름을 확인해주시길 바랍니다.");
                
            }


        }
    }
}
