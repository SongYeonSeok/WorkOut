using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myLibrary;

namespace WorkOut
{
    public partial class frmInfo : Form
    {
        public delegate void FormSendDataHandler(string sendstring);

        public event FormSendDataHandler FormSendEvent;



        int Weight, Rep;


        public frmInfo(int weight = 10, int rep = 10)
        {
            InitializeComponent();
            Weight = weight;
            Rep = rep;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnoutput_Click(object sender, EventArgs e)
        {
            
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            TbBox1.Visible = true;
            TbBox2.Visible = true;

            // 현재의 요일표시
            DateTime datetime = DateTime.Now;
            if (datetime.DayOfWeek == DayOfWeek.Monday) tbBoxDoW.Text = "월요일";
            else if (datetime.DayOfWeek == DayOfWeek.Tuesday) tbBoxDoW.Text = "화요일";
            else if (datetime.DayOfWeek == DayOfWeek.Wednesday) tbBoxDoW.Text = "수요일";
            else if (datetime.DayOfWeek == DayOfWeek.Thursday) tbBoxDoW.Text = "목요일";
            else if (datetime.DayOfWeek == DayOfWeek.Friday) tbBoxDoW.Text = "금요일";
            else if (datetime.DayOfWeek == DayOfWeek.Saturday) tbBoxDoW.Text = "토요일";
            else if (datetime.DayOfWeek == DayOfWeek.Sunday) tbBoxDoW.Text = "일요일";

            // 현재의 날짜표시
            string s = DateTime.Now.ToString("yyyy.MM.dd");
            tbBoxDate.Text = s;

        }
    }
}
