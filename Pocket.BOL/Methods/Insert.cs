using Pocket.DAL.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pocket.BOL.Methods
{
    public class Insert
    {
        Encrypt encrypt = new Encrypt();
        DataAccess da = new DataAccess();
        Select select = new Select();

        public void InsertUser(string fullname, string username, string email, string password, string language)
        {
            try
            {
                da.returnDataUser(String.Format("INSERT INTO [User](FullName, Username, Email, [Password]) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}');", fullname, username, email, encrypt.EncryptPassword(password)));
                InsertLanguage(username, language);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void InsertExpense(string username, string categoryexpenses, string typeExpenses, string dateExpenses, string paymentMethod, double cost, string notes)
        {
            try
            {
                da.returnDataExpenses(String.Format("INSERT INTO Expenses(IDUser, ExpensesCategory, ExpensesType, TotalExpenses, ExpensesDate, PaymentMethod, Notes, Payed) " +
                    "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', 0);",  select.GetIDUser(username), select.GetIDCategoryExpenses(categoryexpenses), select.GetIDTypeExpenses(typeExpenses,categoryexpenses), cost, dateExpenses, paymentMethod, notes));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void InsertIncome(string username, double totalincome)
        {
            try
            {
                da.returnDataExpenses(String.Format("INSERT INTO Income(IDUser, TotalIncome) " +
                    "VALUES({0}, {1});", select.GetIDUser(username), totalincome));
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void InsertType(string username, string typeCategory, string typeName)
        {
            try
            {
                da.returnDataType(String.Format("INSERT INTO ExpensesType(IDUser, TypeCategory, TypeName) " +
                    "VALUES({0}, '{1}', '{2}');", select.GetIDUser(username), select.GetIDCategoryExpenses(typeCategory), typeName));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void InsertLanguage(string username, string language)
        {
            try
            {
                da.returnLanguage(String.Format("INSERT INTO Language(IDUser, LanguageName) " +
                    "VALUES({0}, '{1}');", select.GetIDUser(username)));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
