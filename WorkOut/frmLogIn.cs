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
        /// <summary>
        /// myLibraryURL : 각자의 mdf 파일 주소
        /// </summary>
        const string myLibraryURL = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Desktop\WorkOut1-master\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        SqlDB sqldb = new SqlDB(myLibraryURL);

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = tbBoxName.Text;
            string pw = tbBoxPW.Text;

            string ret = sqldb.GetString($"select name from WorkOutMem where name = '{name}'");
            string ret2 = sqldb.GetString($"select PW from WorkOutMem where PW = '{pw}'and Name = '{name}' ");
            string type = sqldb.GetString($"select Type from WorkOutMem where PW = '{pw}'and Name = '{name}' ");

            form1 f1 = new form1();
            frmHeader fh = new frmHeader();
            
            
            if (name==ret)
            {
                if(type == "Header")
                {
                    ///
                    // 로그인 할 때 로그인 후 로그인 창 사라지게 하기
                    ///
                    MessageBox.Show($"환영합니다 {name}님");
                    this.Hide();        // 숨기기
                    switch(fh.ShowDialog())
                    {
                        case DialogResult.OK:
                            fh.Close();
                            break;

                        case DialogResult.Cancel:
                            Dispose();
                            break;
                    }
                }
                else if (type == "Client")
                {
                    MessageBox.Show($"환영합니다 {name}님");
                    this.Hide();
                    switch(f1.ShowDialog())
                    {
                        case DialogResult.OK:
                            f1.Close();
                            break;

                        case DialogResult.Cancel:
                            Dispose();
                            break;
                    }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
