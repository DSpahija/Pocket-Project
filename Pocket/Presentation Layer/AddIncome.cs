using Pocket.BOL.Methods;
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
    public partial class AddIncome : Form
    {
        Insert insert = new Insert();
        Select select = new Select();
        Update update = new Update();

        HomePage homepage = new HomePage();

        public AddIncome()
        {
            InitializeComponent();
            RemoveTitleBar();
        }

        private void InsertIncome()
        {
            if(select.IncomesVerification(LoginPage.username) == true)
            {
                update.UpdateIncomes(LoginPage.username, Convert.ToDouble(Textbox_TotalIncome.Text));
            }
            else
            {
                insert.InsertIncome(LoginPage.username, Convert.ToDouble(Textbox_TotalIncome.Text));
            }
        }

        public double lastIncome;
        private void Button_AddIncome_Click(object sender, EventArgs e)
        {
            InsertIncome();
            lastIncome = select.GetIncome(LoginPage.username);
            this.Close();
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

        public string GetMyResult()
        {
            return lastIncome.ToString();
        }
    }
}
