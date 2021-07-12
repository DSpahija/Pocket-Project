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
    public class Delete
    {
        DataAccess da = new DataAccess();
        Select select = new Select();

        public List<Expenses> DeleteExpense(string username, int idexpenses)
        {
            try
            {
                return da.returnDataExpenses("DELETE FROM Expenses WHERE IDUser=" + select.GetIDUser(username) +
                    " AND IDExpenses=" + idexpenses);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
