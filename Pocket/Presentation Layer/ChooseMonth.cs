using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pocket.Presentation_Layer
{
    public partial class ChooseMonth : Form
    {

        HomePage homePage = new HomePage();

        public ChooseMonth()
        {
            InitializeComponent();
            RemoveTitleBar();
            TodaysDate();
        }


        private void TodaysDate()
        {
            Datepicker_FromDate.Value = DateTime.Now;
            Datepicker_ToDate.Value = DateTime.Now;
        }
        private void RemoveTitleBar()
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public static string fromDate, toDate;
        private void Button_AddMonth_Click(object sender, EventArgs e)
        {
            if (Datepicker_ToDate.Value < Datepicker_FromDate.Value)
            {
                MessageBox.Show("From: date should be earlier than To: date");
            }
            else
            {
                toDate = Datepicker_ToDate.Value.ToString("MM/dd/yyyy");
                fromDate = Datepicker_FromDate.Value.ToString("MM/dd/yyyy");
                //homePage.GetBudget();
                GetMyResult();
                this.Close();
            }
        }

        public string GetMyResult()
        {
            return fromDate + " - " + toDate;
        }

        public static string returnFromDate()
        {
            return fromDate;
        }

        public static string returnToDate()
        {
            return toDate;
        }
    }
}
