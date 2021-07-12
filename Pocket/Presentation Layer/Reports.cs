using Pocket.BOL.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pocket.Presentation_Layer
{
    public partial class Reports : Form
    {
        Select select = new Select();
        Update update = new Update();
        Delete delete = new Delete();

        PrintPdf printPdf = new PrintPdf();

        public Reports()
        {
            InitializeComponent();
            RemoveTitleBar();
            GridColumns();
        }
        

        private void GridColumns()
        {
            Datagrid_Reports.DataSource = select.GetAllExpensesNoLoan(LoginPage.username);
            Datagrid_Reports.Columns["IDExpenses"].Visible = false;
            Datagrid_Reports.Columns["TypeCategory"].ReadOnly = true;
            Datagrid_Reports.Columns["TypeName"].ReadOnly = true;
            Datagrid_Reports.Columns["ExpensesDate"].ReadOnly = true;
            Datagrid_Reports.Columns["PaymentMethod"].ReadOnly = true;
        }

        private void UpdateDatabase()
        {
            for (int i = 0; i < Datagrid_Reports.Rows.Count; i++)
            {
                update.UpdateExpenses(LoginPage.username, Int32.Parse(Datagrid_Reports.Rows[i].Cells[0].Value.ToString()), 
                    Convert.ToDouble(Datagrid_Reports.Rows[i].Cells["TotalExpenses"].Value), Datagrid_Reports.Rows[i].Cells["Notes"].Value.ToString());
            }
        }

        private void DeleteRow()
        {
            if(MessageBox.Show("Are you sure you want to delete this expense?", "Expenses", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete.DeleteExpense(LoginPage.username, Int32.Parse(Datagrid_Reports.CurrentRow.Cells[0].Value.ToString()));
            }
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

        private void Button_PrintReport_Click(object sender, EventArgs e)
        {
            printPdf.ExportToPdf(Datagrid_Reports, "Reports");
        }

        private void Button_UpdateExpenses_Click(object sender, EventArgs e)
        {
            Datagrid_Reports.CurrentCell = null;
            UpdateDatabase();
        }

        private void Datagrid_Reports_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(Datagrid_Reports.CurrentCell.ColumnIndex == 3)
            {
                e.Control.KeyPress += Control_KeyPress;
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
            if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void Button_DeleteExpenses_Click(object sender, EventArgs e)
        {
            DeleteRow();
            GridColumns();
        }
    }
}
