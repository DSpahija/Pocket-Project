using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocket.BLL.Models
{
    public class Income
    {
        public int IDIncome { get; set; }
        public int IDUser { get; set; }
        public string PersonName { get; set; }
        public double TotalIncome { get; set; }
        public string SalaryDate { get; set; }
    }
}
