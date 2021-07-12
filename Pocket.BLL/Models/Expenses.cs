using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocket.BLL.Models
{
    public class Expenses
    {        
        public int IDExpenses { get; set; }
        public int IDUser { get; set; }
        public int ExpensesCategory { get; set; }
        public int ExpensesType { get; set; }
        public double TotalExpenses { get; set; }
        public string ExpensesDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
        public bool Payed { get; set; }
    }
}
