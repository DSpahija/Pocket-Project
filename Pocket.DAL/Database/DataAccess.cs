using Pocket.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Pocket.DAL.Database
{
    public class DataAccess
    {        
        //IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PocketDB"));
        public List<ExpensesType> returnDataExpensesType(string query)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                var output = connection.Query<ExpensesType>(query).ToList();
                return output;
            }
        }

        public List<User> returnDataUser(string query)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                var output = connection.Query<User>(query).ToList();
                return output;
            }
        }

        public List<Expenses> returnDataExpenses(string query)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                var output = connection.Query<Expenses>(query).ToList();
                return output;
            }
        }

        public List<Income> returnDataIncome(string query)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                var output = connection.Query<Income>(query).ToList();
                return output;
            }
        }

        public List<ExpensesType> returnDataType(string query)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                var output = connection.Query<ExpensesType>(query).ToList();
                return output;
            }
        }

        public List<ExpensesCategory> returnDataExpensesCategory(string query)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                var output = connection.Query<ExpensesCategory>(query).ToList();
                return output;
            }
        }

        public List<Language> returnLanguage(string query)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                var output = connection.Query<Language>(query).ToList();
                return output;
            }
        }

        public string returnLanguage(string query, string retrieveData)
        {
            Language language = new Language();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        language.LanguageName = reader[retrieveData].ToString();
                    }
                }
            }
            return language.LanguageName;
        }

        public DataTable returnLoansData(string query)
        {
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                return dt;
            }
        }

        public double returnDataIncome(string query, string retrieveData)
        {
            Income income = new Income();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        income.TotalIncome = Convert.ToDouble(reader[retrieveData]);
                    }
                }
            }
            return income.TotalIncome;
        }

        public double returnDataExpenses(string query, string retrieveData)
        {
            Expenses income = new Expenses();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        income.TotalExpenses = Convert.ToDouble(reader[retrieveData]);
                    }
                }
            }
            return income.TotalExpenses;
        }

        public string returnDataUser(string query, string retrieveData)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.FullName = reader[retrieveData].ToString();
                    }
                }
            }
            return user.FullName;
        }


        public int returnDataUserID(string query, string retrieveData)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.IDUser = (int)reader[retrieveData];
                    }
                }
            }
            return user.IDUser;
        }

        public int returnDataCategoryID(string query, string retrieveData)
        {
            ExpensesCategory category = new ExpensesCategory();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        category.IDExpensesCategory = (int)reader[retrieveData];
                    }
                }
            }
            return category.IDExpensesCategory;
        }

        public string returnDataCategory(string query, string retrieveData)
        {
            ExpensesCategory category = new ExpensesCategory();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        category.TypeCategory = reader[retrieveData].ToString();
                    }
                }
            }
            return category.TypeCategory;
        }

        public string returnDataType(string query, string retrieveData)
        {
            ExpensesType type = new ExpensesType();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        type.TypeName = reader[retrieveData].ToString();
                    }
                }
            }
            return type.TypeName;
        }

        public int returnDataTypeID(string query, string retrieveData)
        {
            ExpensesType type = new ExpensesType();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        type.IDExpensesType = (int)reader[retrieveData];
                    }
                }
            }
            return type.IDExpensesType;
        }

        public bool CountRows(string query)
        {
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("PocketDB")))
            {
                connection.Open();

                int result = (int)connection.ExecuteScalar(query);

                if (result != 0)
                    return true; //Ekziston
                else
                    return false; //Nuk ekziston
            }
        }
    }
}
