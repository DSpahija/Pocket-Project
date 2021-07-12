using Pocket.BLL.Models;
using Pocket.DAL.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pocket.BOL.Methods
{
   public class Update
    {
        DataAccess da = new DataAccess();
        Select select = new Select();

        public List<Income> UpdateIncomes(string username, double incomes)
        {
            try
            {
                return da.returnDataIncome("UPDATE Income SET TotalIncome=" + incomes  + " WHERE IDUser=" + select.GetIDUser(username));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Expenses> UpdatePayedLoan(string username, string payed, int idexpenses)
        {
            try
            {
                return da.returnDataExpenses("UPDATE Expenses SET Payed=" + payed + " WHERE IDUser=" + select.GetIDUser(username) 
                    + " AND IDExpenses=" + idexpenses);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Expenses> UpdateExpenses(string username, int idexpenses, double totalExpense, string notes)
        {
            try
            {
                return da.returnDataExpenses("UPDATE Expenses SET TotalExpenses=" + totalExpense
                    + ", Notes='" + notes
                    + "' WHERE IDUser=" + select.GetIDUser(username)
                    + " AND IDExpenses=" + idexpenses);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Language> UpdateLanguage(string username, string language)
        {
            try
            {
                return da.returnLanguage("UPDATE Language SET LanguageName='" + language +
                    "' WHERE IDUser=" + select.GetIDUser(username));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
