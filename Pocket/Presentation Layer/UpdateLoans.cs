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
    public partial class UpdateLoans : Form
    {
        Select select = new Select();
        Update update = new Update();

        public UpdateLoans()
        {
            InitializeComponent();
            RemoveTitleBar();
            GridColumns();
        }

        private void RemoveTitleBar()
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            totalLoans = select.GetLoans(LoginPage.username);
            this.Close();
        }

        private void Button_Minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        public void GridColumns()
        {
            Datagrid_Loans.DataSource = select.GetAllLoans(LoginPage.username);
            Datagrid_Loans.Columns["IDExpenses"].Visible = false;
            for (int i = 1; i < Datagrid_Loans.ColumnCount - 1 ; i++)
            {
                Datagrid_Loans.Columns[i].ReadOnly = true;
            }
        }

        public static double totalLoans;
        private void Button_UpdateLoan_Click(object sender, EventArgs e)
        {
            UpdateDatabase();
            totalLoans = select.GetLoans(LoginPage.username);
            this.Close();
        }

        private void UpdateDatabase()
        {
            for (int i = 0; i < Datagrid_Loans.Rows.Count; i++)
            {
                bool isChecked = (bool)Datagrid_Loans.Rows[i].Cells[Datagrid_Loans.ColumnCount - 1].Value;
                if (isChecked == false)
                {
                    update.UpdatePayedLoan(LoginPage.username, "0" , Int32.Parse(Datagrid_Loans.Rows[i].Cells[0].Value.ToString()));
                }
                else
                {
                    update.UpdatePayedLoan(LoginPage.username, "1", Int32.Parse(Datagrid_Loans.Rows[i].Cells[0].Value.ToString()));
                }
            }
        }

        public string GetMyResult()
        {
            return totalLoans.ToString();
        }

        private void Datagrid_Loans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Datagrid_Loans.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
