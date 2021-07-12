using Pocket.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocket.DAL.Database;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Pocket.BOL.Methods
{
    public class Select
    {
        Encrypt encrypt = new Encrypt();
        DataAccess da = new DataAccess();

        //USER VERIFICATION
        public bool UserVerificationDuplicate(string username)
        {
            try
            {
                if (da.CountRows("SELECT * FROM [User] WHERE Username ='" + username + "';") == true)
                    return true; //Ekziston
                else
                    return false; //Nuk ekziston
            }
            catch
            {
                return false;
            }
        }

        public bool UserLogin(string username, string password)
        {
            try
            {
                if (da.CountRows(String.Format("SELECT * FROM [User] WHERE Username='{0}' AND Password='{1}';",
                    username, encrypt.EncryptPassword(password))) == true)
                    return true;
                else
                    return false;
            }
            catch
            {
                MessageBox.Show("Username or Password is wrong!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string GetFullName(string username)
        {
            try
            {
                return da.returnDataUser("SELECT FullName FROM [User] WHERE Username='" + username + "';", "FullName");
            }
            catch
            {
                return "Friend!";
            }
        }

        public int GetIDUser(string username)
        {
            try
            {
                return da.returnDataUserID("SELECT IDUser FROM [User] WHERE Username='" + username + "';", "IDUser");
            }
            catch
            {
                return 0;
            }
        }
        //CATEGORIES

        public List<ExpensesCategory> GetCategories()
        {
            try
            {
                return da.returnDataExpensesCategory("SELECT * FROM ExpensesCategory");
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int GetIDCategoryExpenses(string category)
        {
            try
            {
                return da.returnDataCategoryID("SELECT IDExpensesCategory FROM ExpensesCategory WHERE " +
                    "TypeCategory='" + category + "';", "IDExpensesCategory");
            }
            catch
            {
                return 0;
            }
        }

        public int GetIDTypeExpenses(string type, string category)
        {
            try
            {
                return da.returnDataTypeID("SELECT IDExpensesType FROM ExpensesType WHERE " +
                    "TypeCategory=" + GetIDCategoryExpenses(category) + " AND TypeName='" + type +"';", "IDExpensesType");
                    }
            catch
            {
                return 0;
            }
        }

        //EXPENSES

        public string GetExpensesName(int id)
        {
            try
            {
                return da.returnDataCategory("SELECT TypeCategory FROM ExpensesCategory WHERE IDExpensesCategory='" + id  + "';", "TypeCategory");
            }
            catch(SqlException e)
            {
                return e.Message;
            }
        }

        public List<Expenses> GetExpenses(string username)
        {
            try
            {
                return da.returnDataExpenses("SELECT ExpensesCategory, SUM(TotalExpenses) as TotalExpenses FROM Expenses as a " +
                    " INNER JOIN ExpensesCategory as b " +
                    " ON a.ExpensesCategory = b.IDExpensesCategory " +
                    " WHERE IDUser="
                    + GetIDUser(username) + " GROUP BY ExpensesCategory;");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Expenses> GetExpensesByDate(string username, string dateBegin, string dateEnd)
        {
            try
            {
                return da.returnDataExpenses("SELECT ExpensesCategory, SUM(TotalExpenses) as TotalExpenses FROM Expenses as a " +
                    " INNER JOIN ExpensesCategory as b ON a.ExpensesCategory = b.IDExpensesCategory " +
                    " WHERE IDUser=" + GetIDUser(username) + " AND (CONVERT(DATETIME, ExpensesDate) BETWEEN '" + dateBegin + "' AND '" + dateEnd + "') " +
                    "GROUP BY ExpensesCategory;");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesHomecare(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=1 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)  
            {

                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesUtilities(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=2 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesWardrobe(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=3 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesHolidays(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=4 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesMedical(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=5 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public List<ExpensesType> GetTypesLoans(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=6 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesSavings(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=7 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesEmergency(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=8 AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ExpensesType> GetTypesExtra(string username)
        {
            try
            {
                return da.returnDataExpensesType("SELECT * FROM ExpensesType WHERE TypeCategory=9  AND (IDUser=" + GetIDUser(username) + " OR IDUser is NULL)");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetAllExpensesNoLoan(string username)
        {
            try
            {
                return da.returnLoansData("SELECT a.IDExpenses, b.TypeCategory, c.TypeName, TotalExpenses, (CONVERT(VARCHAR,ExpensesDate,101)) as ExpensesDate, PaymentMethod, Notes " +
                    "FROM Expenses as a, ExpensesCategory as b, ExpensesType as c WHERE " +
                    " a.ExpensesCategory = b.IDExpensesCategory AND a.ExpensesType = c.IDExpensesType" +
                    " AND a.IDUser = " + GetIDUser(username));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //INCOMES
        public bool IncomesVerification(string username)
        {
            try
            {
                if (da.CountRows("SELECT * FROM Income WHERE IDUser=" + GetIDUser(username) + ";") == true)
                    return true; //Ekziston
                else
                    return false; //Nuk ekziston
            }
            catch
            {
                return false;
            }
        }

        public List<Income> GetIncomes(string username)
        {
            try
            {
                return da.returnDataIncome("SELECT TotalIncome FROM Income WHERE IDUser=" + GetIDUser(username));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetAllLoans(string username)
        {
            try
            {
                return da.returnLoansData("SELECT a.IDExpenses, c.TypeName, TotalExpenses, ExpensesDate, PaymentMethod, Notes, Payed " +
                    "FROM Expenses as a, ExpensesCategory as b, ExpensesType as c WHERE ExpensesCategory=6" +
                    " AND a.ExpensesCategory = b.IDExpensesCategory AND a.ExpensesType = c.IDExpensesType" +
                    " AND a.IDUser = " + GetIDUser(username));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public double GetIncome(string username)
        {
            try
            {
                return da.returnDataIncome("SELECT TotalIncome FROM Income WHERE IDUser=" + GetIDUser(username), "TotalIncome");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        public double GetBudgetNoLoans(string username,string dateNow, string dayOne)
        {
            try
            {
                return da.returnDataExpenses("SELECT TotalIncome, Sum(TotalExpenses), (TotalIncome - Sum(TotalExpenses)) as " +
                    "SUB FROM Income as i, Expenses as e WHERE i.IDUser = e.IDUser AND i.IDUSER=" + GetIDUser(username) +
                    " AND e.ExpensesCategory != 6 AND (CONVERT(VARCHAR,ExpensesDate,101) BETWEEN '" + dayOne + "' AND '" + dateNow + "') GROUP BY TotalIncome", "SUB");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        public double GetLoans(string username)
        {
            try
            {
                return da.returnDataExpenses("SELECT SUM(TotalExpenses) as TotalExpenses FROM Expenses as a " +
                    "INNER JOIN ExpensesCategory as b ON a.ExpensesCategory = b.IDExpensesCategory" +
                    "  WHERE IDUser=" + GetIDUser(username) + " AND a.ExpensesCategory=6 AND Payed=0 GROUP BY ExpensesCategory;", "TotalExpenses");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        public double GetAllExpenses(string username)
        {
            try
            {
                return da.returnDataExpenses("SELECT SUM(TotalExpenses) as TotalExpenses FROM Expenses" +
                    "  WHERE IDUser=" + GetIDUser(username), "TotalExpenses");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        public double GetMonthExpenses(string username, string dateBegin, string dateEnd)
        {
            try
            {
                return da.returnDataExpenses("SELECT SUM(TotalExpenses) as TotalExpenses FROM Expenses as a " +
                    "  WHERE IDUser=" + GetIDUser(username) + " AND (CONVERT(VARCHAR, ExpensesDate, 101) BETWEEN '" + dateBegin +"' AND '" + dateEnd + "')", "TotalExpenses");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        public string GetLanguage(string username)
        {
            try
            {
                return da.returnLanguage("SELECT LanguageName FROM [Language]" +
                    "  WHERE IDUser=" + GetIDUser(username), "LanguageName");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "English";
            }
        }
    }
}
